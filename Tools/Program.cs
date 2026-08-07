using System;
using System.IO;
using System.Reflection;

namespace BTD_Mod_Helper.Tools;

internal static class Program
{
    private static readonly string Version = typeof(Program).Assembly
        .GetCustomAttribute<AssemblyInformationalVersionAttribute>()!.InformationalVersion;

    public static int Main(string[] args) => Run(args, Console.Out, Console.Error);

    internal static int Run(string[] args, TextWriter output, TextWriter error)
    {
        try
        {
            if (args.Length == 0 || args[0] is "-h" or "--help" or "help")
            {
                WriteHelp(output);
                return 0;
            }

            return args switch
            {
                ["--version"] => WriteVersion(output),
                ["--version", var minimum] => WriteVersion(output, error, minimum),
                ["pre-commit"] => PreCommit(output),
                ["post-commit"] => PostCommit(output),
                _ => UnknownCommand(error)
            };
        }
        catch (Exception ex)
        {
            error.WriteLine($"error: {ex.Message}");
            return 1;
        }
    }

    private static int WriteVersion(TextWriter output, TextWriter? error = null, string? minimum = null)
    {
        output.WriteLine(Version);
        if (minimum is null) return 0;
        if (!SemanticVersion.TryParse(minimum, out var minimumVersion))
        {
            error!.WriteLine($"Invalid semantic version '{minimum}'.");
            return 1;
        }

        return SemanticVersion.TryParse(Version, out var version) && version!.CompareTo(minimumVersion) >= 0 ? 0 : 1;
    }

    private static int PreCommit(TextWriter output)
    {
        var rotator = new ChangelogRotator(new RepositoryContext(null));
        output.WriteLine(rotator.RotateStaged(DateOnly.FromDateTime(DateTime.Today)).Message);
        return 0;
    }

    private static int PostCommit(TextWriter output)
    {
        var tagger = new VersionTagger(new RepositoryContext(null));
        output.WriteLine(tagger.TagCommit());
        return 0;
    }

    private static int UnknownCommand(TextWriter error)
    {
        error.WriteLine("Unknown command. Run 'btd6mh --help' for usage.");
        return 1;
    }

    private static void WriteHelp(TextWriter output)
    {
        output.WriteLine("""
                         BTD6 Mod Helper Git hooks

                         Usage:
                           btd6mh pre-commit
                           btd6mh post-commit

                         pre-commit rotates and stages CHANGELOG.md when the staged
                         ModHelperData.Version increases.

                         post-commit creates an annotated local version tag. Existing
                         tags are never moved.
                         """);
    }
}
