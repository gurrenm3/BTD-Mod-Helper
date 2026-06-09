using System;
using System.IO;
using System.Linq;
using System.Threading;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.CSharp.Syntax;

namespace BTD_Mod_Helper.SourceGenerators;

/// <summary>
/// When a mod declares <c>[assembly: MelonGame("Ninja Kiwi", "BloonsTD6")]</c> without an accompanying Epic variant,
/// this generator writes the line into the user's source file directly after the Steam attribute
/// </summary>
[Generator(LanguageNames.CSharp)]
public class EpicCompatibilityGenerator : IIncrementalGenerator
{
    private const string SteamGame = "BloonsTD6";
    private const string EpicGame = "BloonsTD6-Epic";

    private const string EpicSourceLine = """[assembly: MelonGame("Ninja Kiwi", "BloonsTD6-Epic")]""";

    public void Initialize(IncrementalGeneratorInitializationContext context)
    {
        var melonGameAttrs = context.SyntaxProvider.CreateSyntaxProvider(
                predicate: IsAssemblyMelonGameList,
                transform: static (ctx, _) =>
                {
                    var al = (AttributeListSyntax) ctx.Node;
                    foreach (var attr in al.Attributes)
                    {
                        if (GetSimpleName(attr) is not ("MelonGame" or "MelonGameAttribute")) continue;
                        if (attr.ArgumentList is not {Arguments.Count: >= 2} argList) continue;
                        if (argList.Arguments[1].Expression is not LiteralExpressionSyntax {Token.Value: string game})
                            continue;
                        if (game is not (SteamGame or EpicGame)) continue;

                        return (
                            Path: ctx.Node.SyntaxTree.FilePath,
                            Game: game,
                            InsertOffset: al.Span.End
                        );
                    }
                    return default;
                })
            .Where(static x => x.Path is not null)
            .Collect();

        context.RegisterSourceOutput(melonGameAttrs, static (_, attrs) =>
        {
            if (attrs.IsDefaultOrEmpty) return;

            if (attrs.Any(a => a.Game == EpicGame)) return;

            var steam = attrs.FirstOrDefault(a => a.Game == SteamGame);
            if (steam.Path is null) return;

            InsertEpicLine(steam.Path, steam.InsertOffset);
        });
    }

    private static bool IsAssemblyMelonGameList(SyntaxNode node, CancellationToken _)
    {
        if (node is not AttributeListSyntax al) return false;
        if (al.Target?.Identifier.IsKind(SyntaxKind.AssemblyKeyword) != true) return false;
        foreach (var attr in al.Attributes)
        {
            if (GetSimpleName(attr) is "MelonGame" or "MelonGameAttribute") return true;
        }
        return false;
    }

    private static string GetSimpleName(AttributeSyntax attr) => attr.Name switch
    {
        IdentifierNameSyntax id => id.Identifier.Text,
        QualifiedNameSyntax qn => qn.Right.Identifier.Text,
        AliasQualifiedNameSyntax aq => aq.Name.Identifier.Text,
        _ => ""
    };

#pragma warning disable RS1035
    private static void InsertEpicLine(string path, int afterOffset)
    {
        try
        {
            var text = File.ReadAllText(path);
            if (afterOffset > text.Length) return;

            var lineEnd = text.IndexOf('\n', afterOffset);
            int insertPos;
            string lineEnding;
            if (lineEnd < 0)
            {
                insertPos = text.Length;
                lineEnding = Environment.NewLine;
            }
            else
            {
                insertPos = lineEnd + 1;
                lineEnding = lineEnd > 0 && text[lineEnd - 1] == '\r' ? "\r\n" : "\n";
            }

            // Defensive no-op if the line is already there (e.g. concurrent write).
            if (text.Substring(insertPos).TrimStart().StartsWith(EpicSourceLine, StringComparison.Ordinal)) return;

            File.WriteAllText(path,
                text.Substring(0, insertPos) + EpicSourceLine + lineEnding + text.Substring(insertPos));
        }
        catch
        {
            // generators must never throw
        }
    }
#pragma warning restore RS1035
}