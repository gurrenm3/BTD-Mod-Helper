using System;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using Microsoft.CodeAnalysis;

namespace BTD_Mod_Helper.SourceGenerators;

/// <summary>
/// Creates managed Git hooks for mod projects.
/// </summary>
[Generator(LanguageNames.CSharp)]
public class GitHooksGenerator : IIncrementalGenerator
{
    private const string OwnerMarker = "# Managed by Btd6ModHelper.SourceGenerators";
    private const string TemplatePrefix = "BTD_Mod_Helper.SourceGenerators.Templates.";
    private const int ExecutableFileMode = 0x1ED; // 0755

    public void Initialize(IncrementalGeneratorInitializationContext context)
    {
        var project = context.AnalyzerConfigOptionsProvider.Select(static (options, _) =>
        {
            options.GlobalOptions.TryGetValue("build_property.ProjectDir", out var projectDirectory);
            options.GlobalOptions.TryGetValue("build_property.GenerateGitHooks", out var enabled);
            options.GlobalOptions.TryGetValue("build_property.ToolsVersion", out var toolsVersion);
            options.GlobalOptions.TryGetValue("build_property.CI", out var ci);
            return (
                Directory: projectDirectory,
                Enabled: Helpers.IsEnabled(enabled),
                ToolsVersion: toolsVersion,
                CI: !string.IsNullOrWhiteSpace(ci) &&
                    !string.Equals(ci, "false", StringComparison.OrdinalIgnoreCase)
            );
        });
        var changelog = context.AdditionalTextsProvider
            .Where(static file => string.Equals(Path.GetFileName(file.Path), "CHANGELOG.md",
                StringComparison.OrdinalIgnoreCase))
            .Select(static (file, _) => file.Path)
            .Collect()
            .Select(static (paths, _) => paths.FirstOrDefault());

        context.RegisterSourceOutput(project.Combine(changelog), static (_, value) =>
        {
            var (settings, _) = value;
            if (settings.CI || !settings.Enabled ||
                string.IsNullOrWhiteSpace(settings.Directory) ||
                string.IsNullOrWhiteSpace(settings.ToolsVersion)) return;
            CreateHooks(settings.Directory!, settings.ToolsVersion!);
        });
    }

#pragma warning disable RS1035
    internal static void CreateHooks(string projectDirectory, string toolsVersion)
    {
        try
        {
            projectDirectory = Path.GetFullPath(projectDirectory);
            var gitDirectory = FindGitDirectory(projectDirectory);
            if (gitDirectory is null) return;

            if (File.Exists(Path.Combine(projectDirectory, "CHANGELOG.md")))
                WriteHook(gitDirectory, "pre-commit", "pre-commit.liquid", toolsVersion);
            WriteHook(gitDirectory, "post-commit", "post-commit.liquid", toolsVersion);
        }
        catch
        {
            // Hook setup must never prevent a mod from building.
        }
    }

    private static void WriteHook(string gitDirectory, string name, string templateName, string toolsVersion)
    {
        var hookPath = Path.Combine(gitDirectory, "hooks", name);
        var hook = Helpers.RenderFluidTemplate(TemplatePrefix + templateName, new {toolsVersion})
            .Replace("\r\n", "\n").TrimEnd() + "\n";
        if (!Helpers.UpdateManagedFile(hookPath, hook, true, OwnerMarker)) return;
        MakeExecutable(hookPath);
    }

    private static string? FindGitDirectory(string projectDirectory)
    {
        var projectMarker = Path.Combine(projectDirectory, ".git");
        if (Directory.Exists(projectMarker)) return projectMarker;
        if (File.Exists(projectMarker)) return ReadGitDirectory(projectMarker, projectDirectory);

        for (var directory = Directory.GetParent(projectDirectory); directory is not null; directory = directory.Parent)
        {
            if (!Directory.EnumerateFiles(directory.FullName, "*", SearchOption.TopDirectoryOnly)
                    .Any(IsSolutionFile)) continue;

            var marker = Path.Combine(directory.FullName, ".git");
            if (Directory.Exists(marker)) return marker;
            if (File.Exists(marker)) return ReadGitDirectory(marker, directory.FullName);
        }

        return null;
    }

    private static bool IsSolutionFile(string path)
    {
        var extension = Path.GetExtension(path);
        return string.Equals(extension, ".sln", StringComparison.OrdinalIgnoreCase) ||
               string.Equals(extension, ".slnx", StringComparison.OrdinalIgnoreCase);
    }

    private static string? ReadGitDirectory(string marker, string repositoryDirectory)
    {
        var contents = File.ReadAllText(marker).Trim();
        const string prefix = "gitdir:";
        if (!contents.StartsWith(prefix, StringComparison.OrdinalIgnoreCase)) return null;

        var gitDirectory = contents.Substring(prefix.Length).Trim();
        if (!Path.IsPathRooted(gitDirectory)) gitDirectory = Path.Combine(repositoryDirectory, gitDirectory);
        gitDirectory = Path.GetFullPath(gitDirectory);

        var commonDirectoryFile = Path.Combine(gitDirectory, "commondir");
        if (!File.Exists(commonDirectoryFile)) return gitDirectory;

        var commonDirectory = File.ReadAllText(commonDirectoryFile).Trim();
        if (!Path.IsPathRooted(commonDirectory)) commonDirectory = Path.Combine(gitDirectory, commonDirectory);
        return Path.GetFullPath(commonDirectory);
    }

    private static void MakeExecutable(string path)
    {
        if (Path.DirectorySeparatorChar == '/') Chmod(path, ExecutableFileMode);
    }

    [DllImport("libc", EntryPoint = "chmod")]
    private static extern int Chmod(string path, int mode);
#pragma warning restore RS1035
}
