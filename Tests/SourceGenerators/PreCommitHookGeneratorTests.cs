extern alias SourceGenerators;

using System;
using System.Diagnostics;
using System.IO;
using Xunit;
using GitHooksGenerator = SourceGenerators::BTD_Mod_Helper.SourceGenerators.GitHooksGenerator;

namespace BTD_Mod_Helper.SourceGenerators.Tests;

public sealed class GitHooksGeneratorTests : IDisposable
{
    private const string ToolsVersion = "9.8.7";
    private readonly string directory = Path.Combine(Path.GetTempPath(), "btd6-mod-helper-generator-tests",
        Guid.NewGuid().ToString("N"));

    [Fact]
    public void CreatesHookForGitProjectWithChangelog()
    {
        InitializeRepository();
        File.WriteAllText(Path.Combine(directory, "CHANGELOG.md"), "# Changelog\n");

        GitHooksGenerator.CreateHooks(directory, ToolsVersion);

        var hook = File.ReadAllText(HookPath());
        Assert.Contains("command -v btd6mh", hook);
        Assert.Contains($"btd6mh --version \"{ToolsVersion}\"", hook);
        Assert.Contains("btd6mh pre-commit || warn", hook);
        Assert.Contains($"dotnet tool exec Btd6ModHelper.Tools@{ToolsVersion} --verbosity quiet " +
                        "--ignore-failed-sources -- pre-commit || warn", hook);
        Assert.Contains("commit will continue", hook);
        Assert.DoesNotContain("exec btd6mh", hook);
        Assert.EndsWith("exit 0\n", hook);
        Assert.DoesNotContain("btd6-mod-helper", hook);
        Assert.DoesNotContain("--hook", hook);
        var postCommit = File.ReadAllText(HookPath("post-commit"));
        Assert.Contains($"btd6mh --version \"{ToolsVersion}\"", postCommit);
        Assert.Contains("btd6mh post-commit", postCommit);
        Assert.Contains($"dotnet tool exec Btd6ModHelper.Tools@{ToolsVersion} --verbosity quiet " +
                        "--ignore-failed-sources -- post-commit", postCommit);
        Assert.Contains("|| :", postCommit);
    }

    [Fact]
    public void PreCommitHookContinuesWhenToolIsUnavailable()
    {
        InitializeRepository();
        File.WriteAllText(Path.Combine(directory, "CHANGELOG.md"), "# Changelog\n");
        GitHooksGenerator.CreateHooks(directory, ToolsVersion);

        var startInfo = new ProcessStartInfo("git")
        {
            WorkingDirectory = directory,
            RedirectStandardError = true,
            UseShellExecute = false
        };
        startInfo.ArgumentList.Add("hook");
        startInfo.ArgumentList.Add("run");
        startInfo.ArgumentList.Add("pre-commit");
        startInfo.Environment["PATH"] = "";
        using var process = Process.Start(startInfo)!;
        var error = process.StandardError.ReadToEnd();
        process.WaitForExit();

        Assert.Equal(0, process.ExitCode);
        Assert.Contains("commit will continue", error);
    }

    [Theory]
    [InlineData("sln")]
    [InlineData("slnx")]
    public void CreatesHookAtSolutionRepositoryRoot(string extension)
    {
        InitializeRepository();
        File.WriteAllText(Path.Combine(directory, $"Mods.{extension}"), "");
        var projectDirectory = Path.Combine(directory, "Example Mod");
        Directory.CreateDirectory(projectDirectory);
        File.WriteAllText(Path.Combine(projectDirectory, "CHANGELOG.md"), "# Changelog\n");

        GitHooksGenerator.CreateHooks(projectDirectory, ToolsVersion);

        Assert.True(File.Exists(HookPath()));
        Assert.True(File.Exists(HookPath("post-commit")));
    }

    [Fact]
    public void SkipsProjectWithoutGit()
    {
        Directory.CreateDirectory(directory);
        GitHooksGenerator.CreateHooks(directory, ToolsVersion);
        Assert.False(File.Exists(Path.Combine(directory, ".git", "hooks", "pre-commit")));
        Assert.False(File.Exists(Path.Combine(directory, ".git", "hooks", "post-commit")));
    }

    [Fact]
    public void CreatesOnlyPostCommitWithoutChangelog()
    {
        InitializeRepository();
        GitHooksGenerator.CreateHooks(directory, ToolsVersion);

        Assert.False(File.Exists(HookPath()));
        Assert.True(File.Exists(HookPath("post-commit")));
    }

    [Fact]
    public void PreservesExistingPreCommitWhenChangelogIsDeleted()
    {
        InitializeRepository();
        var changelog = Path.Combine(directory, "CHANGELOG.md");
        File.WriteAllText(changelog, "# Changelog\n");
        GitHooksGenerator.CreateHooks(directory, ToolsVersion);
        File.Delete(changelog);

        GitHooksGenerator.CreateHooks(directory, ToolsVersion);

        Assert.True(File.Exists(HookPath()));
        Assert.True(File.Exists(HookPath("post-commit")));
    }

    [Fact]
    public void PreservesCustomizedPreCommitWithoutChangelog()
    {
        InitializeRepository();
        const string hook = "#!/bin/sh\necho custom pre-commit\n";
        File.WriteAllText(HookPath(), hook);

        GitHooksGenerator.CreateHooks(directory, ToolsVersion);

        Assert.Equal(hook, File.ReadAllText(HookPath()));
        Assert.True(File.Exists(HookPath("post-commit")));
    }

    [Fact]
    public void PreservesCustomizedHooks()
    {
        InitializeRepository();
        File.WriteAllText(Path.Combine(directory, "CHANGELOG.md"), "# Changelog\n");
        const string preCommit = "#!/bin/sh\nbtd6mh pre-commit\necho custom pre-commit\n";
        const string postCommit = "#!/bin/sh\nbtd6mh post-commit\necho custom post-commit\n";
        File.WriteAllText(HookPath(), preCommit);
        File.WriteAllText(HookPath("post-commit"), postCommit);

        GitHooksGenerator.CreateHooks(directory, ToolsVersion);

        Assert.Equal(preCommit, File.ReadAllText(HookPath()));
        Assert.Equal(postCommit, File.ReadAllText(HookPath("post-commit")));
    }

    public void Dispose()
    {
        if (!Directory.Exists(directory)) return;
        foreach (var file in Directory.EnumerateFiles(directory, "*", SearchOption.AllDirectories))
            File.SetAttributes(file, FileAttributes.Normal);
        Directory.Delete(directory, true);
    }

    private void InitializeRepository()
    {
        Directory.CreateDirectory(directory);
        using var process = Process.Start(new ProcessStartInfo("git", "init")
        {
            WorkingDirectory = directory,
            RedirectStandardError = true,
            UseShellExecute = false
        })!;
        var error = process.StandardError.ReadToEnd();
        process.WaitForExit();
        Assert.True(process.ExitCode == 0, error);
    }

    private string HookPath(string name = "pre-commit") => Path.Combine(directory, ".git", "hooks", name);
}
