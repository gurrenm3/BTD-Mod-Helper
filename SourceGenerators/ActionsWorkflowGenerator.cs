using System;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using BTD_Mod_Helper.Api.Data;
using Fluid;
using Microsoft.CodeAnalysis;

namespace BTD_Mod_Helper.SourceGenerators;

/// <summary>
/// Keeps the project's .github/workflows/build.yml in sync with values from the mod's
/// ModHelperData. The generator only writes the file if one already exists at that path, so deleting
/// the file opts out for the project. Can also opt out with setting csproj property GenerateActionsWorkflow to false
/// </summary>
[Generator(LanguageNames.CSharp)]
public class ActionsWorkflowGenerator : IIncrementalGenerator
{
    private const string WorkflowSuffix = ".github/workflows/build.yml";
    private const string ThunderstoreFile = "thunderstore.toml";
    private const string LatestMd = "LATEST.md";
    private const string ChangelogMd = "CHANGELOG.md";
    private const string FluidTemplateResource = "BTD_Mod_Helper.SourceGenerators.Templates.build.yml.liquid";

    public void Initialize(IncrementalGeneratorInitializationContext context)
    {
        var buildContext = context.AnalyzerConfigOptionsProvider.Select((options, _) =>
        {
            options.GlobalOptions.TryGetValue("build_property.AssemblyName", out var assemblyName);
            options.GlobalOptions.TryGetValue("build_property.MSBuildProjectName", out var projectName);
            options.GlobalOptions.TryGetValue("build_property.GenerateActionsWorkflow", out var enabled);
            var name = !string.IsNullOrEmpty(assemblyName) ? assemblyName! : projectName ?? "";
            return (
                Enabled: !string.Equals(enabled, "false", StringComparison.OrdinalIgnoreCase),
                ProjectName: name
            );
        });

        var modHelperDataSource = context.AdditionalTextsProvider
            .Where(static t => IsModHelperDataFile(t.Path))
            .Select(static (t, ct) => t.GetText(ct)?.ToString() ?? "")
            .Collect()
            .Select(static (arr, _) => arr.FirstOrDefault(c => !string.IsNullOrEmpty(c)));

        var additionalFiles = context.AdditionalTextsProvider
            .Select(static (t, _) => t.Path.Replace('\\', '/'))
            .Collect()
            .Select(static (arr, _) =>
            {
                (string? WorkflowPath, string? Thunderstore, string? Latest, string? Changelog) result = default;
                foreach (var path in arr)
                {
                    if (path.EndsWith(WorkflowSuffix, StringComparison.OrdinalIgnoreCase)) result.WorkflowPath = path;
                    else switch (Path.GetFileName(path))
                    {
                        case ThunderstoreFile:
                            result.Thunderstore = path;
                            break;
                        case LatestMd:
                            result.Latest = path;
                            break;
                        case ChangelogMd:
                            result.Changelog = path;
                            break;
                    }
                }
                return result;
            });

        var combined = buildContext.Combine(modHelperDataSource, additionalFiles);

        context.RegisterSourceOutput(combined, static (_, data) =>
        {
            var (build, modHelperDataContent, files) = data;

            if (!build.Enabled) return;
            if (string.IsNullOrEmpty(build.ProjectName)) return;
            if (string.IsNullOrEmpty(files.WorkflowPath)) return;

            string? output;
            var modData = new ModHelperData();
            string? modDataError = null;
            if (!string.IsNullOrEmpty(modHelperDataContent))
            {
                try { modData.ReadValues(modHelperDataContent!); }
                catch (Exception ex) { modDataError = FormatError("ReadValues", ex); }
            }

            var dllName = !string.IsNullOrEmpty(modData.DllName) ? modData.DllName : build.ProjectName + ".dll";

            try
            {
                var source = LoadEmbedded(FluidTemplateResource) ??
                             throw new InvalidOperationException($"Embedded resource not found: {FluidTemplateResource}");
                var parser = new FluidParser();
                if (!parser.TryParse(source, out var template, out var error))
                    throw new InvalidOperationException("Fluid parse error: " + error);

                var options = new TemplateOptions {MemberAccessStrategy = new UnsafeMemberAccessStrategy()};
                var ctx = new TemplateContext(new
                {
                    projectName = build.ProjectName,
                    dllName,
                    mod = modData,
                    thunderstore = files.Thunderstore,
                    changelogMd = files.Changelog,
                    latestMd = files.Latest
                }, options);
                var rendered = template.Render(ctx);

                output = modDataError is null ? rendered.Replace(@"${\{", "${{") : modDataError + "\n" + rendered;
            }
            catch (Exception ex)
            {
                output = FormatError("RenderFluid", ex);
            }
            WriteIfChanged(files.WorkflowPath!, output);
        });
    }

    private static string FormatError(string stage, Exception ex)
    {
        var sb = new StringBuilder();
        sb.AppendLine("# ===========================================================================");
        sb.AppendLine($"# ActionsWorkflowGenerator failed in stage: {stage}");
        sb.AppendLine($"# {ex.GetType().FullName}: {ex.Message}");
        foreach (var line in (ex.ToString() ?? "").Split('\n'))
            sb.AppendLine("#   " + line.TrimEnd('\r'));
        sb.AppendLine("# ===========================================================================");
        return sb.ToString();
    }

    private static string? LoadEmbedded(string resourceName)
    {
        var assembly = typeof(ActionsWorkflowGenerator).Assembly;
        using var stream = assembly.GetManifestResourceStream(resourceName);
        if (stream is null) return null;
        using var reader = new StreamReader(stream, Encoding.UTF8);
        return reader.ReadToEnd();
    }

    private static bool IsModHelperDataFile(string path)
    {
        var name = Path.GetFileName(path);
        return string.Equals(name, ModHelperData.ModHelperDataCs) ||
               string.Equals(name, ModHelperData.ModHelperDataJson) ||
               string.Equals(name, ModHelperData.ModHelperDataTxt);
    }

    private static string NormalizeLineEndings(string text) => text.Replace("\r\n", "\n");

#pragma warning disable RS1035
    private static void WriteIfChanged(string path, string content)
    {
        try
        {
            var existing = File.Exists(path) ? File.ReadAllText(path) : "";
            if (NormalizeLineEndings(existing) == NormalizeLineEndings(content)) return;
            File.WriteAllText(path, content);
        }
        catch (Exception ex)
        {
            try
            {
                var fallback = path + ".generator-error.txt";
                File.WriteAllText(fallback, FormatError("WriteIfChanged", ex));
            }
            catch
            {
                // ignored
            }
        }
    }
#pragma warning restore RS1035
}