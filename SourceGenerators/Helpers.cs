using System;
using System.IO;
using System.Linq;
using System.Text;
using Fluid;
using Microsoft.CodeAnalysis;

namespace BTD_Mod_Helper.SourceGenerators;

public static class Helpers
{
    public static bool IsEnabled(string? value) =>
        !string.Equals(value, "false", StringComparison.OrdinalIgnoreCase);

    public static string NormalizeLineEndings(string? text) => (text ?? "").Replace("\r\n", "\n");

#pragma warning disable RS1035
    public static bool UpdateManagedFile(string path, string content, bool createIfMissing, params string[] markers)
    {
        var existing = File.Exists(path) ? File.ReadAllText(path) : null;
        if (existing is null)
        {
            if (!createIfMissing) return false;
        }
        else if (!markers.Any(existing.Contains))
        {
            return false;
        }

        if (NormalizeLineEndings(existing) != NormalizeLineEndings(content))
        {
            var directory = Path.GetDirectoryName(path);
            if (!string.IsNullOrEmpty(directory)) Directory.CreateDirectory(directory);
            File.WriteAllText(path, content);
        }

        return true;
    }

#pragma warning restore RS1035

    public static string RenderFluidTemplate(string resourceName, object model)
    {
        var assembly = typeof(Helpers).Assembly;
        using var stream = assembly.GetManifestResourceStream(resourceName) ??
                           throw new InvalidOperationException($"Embedded resource not found: {resourceName}");
        using var reader = new StreamReader(stream, Encoding.UTF8);
        var parser = new FluidParser();
        if (!parser.TryParse(reader.ReadToEnd(), out var template, out var error))
            throw new InvalidOperationException("Fluid parse error: " + error);

        var options = new TemplateOptions {MemberAccessStrategy = new UnsafeMemberAccessStrategy()};
        return template.Render(new TemplateContext(model, options));
    }

    public static IncrementalValueProvider<(T1, T2, T3)> Combine<T1, T2, T3>(
        this IncrementalValueProvider<T1> a,
        IncrementalValueProvider<T2> b,
        IncrementalValueProvider<T3> c) =>
        a.Combine(b).Combine(c).Select(static (x, _) =>
            (x.Left.Left, x.Left.Right, x.Right));
}
