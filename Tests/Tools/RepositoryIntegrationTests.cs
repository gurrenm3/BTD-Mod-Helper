using System;
using System.Diagnostics;
using System.IO;
using BTD_Mod_Helper.Tools;
using Xunit;

namespace BTD_Mod_Helper.Tools.Tests;

public sealed class RepositoryIntegrationTests : IDisposable
{
    private readonly string directory = Path.Combine(Path.GetTempPath(), "btd6-mod-helper-tools-tests",
        Guid.NewGuid().ToString("N"));

    [Theory]
    [InlineData("ModHelperData.cs")]
    [InlineData("ModHelper.cs")]
    public void RotateStagedUpdatesWorktreeAndIndex(string dataFileName)
    {
        Directory.CreateDirectory(directory);
        Git("init");
        Git("config", "user.name", "Test User");
        Git("config", "user.email", "test@example.com");
        File.WriteAllText(Path.Combine(directory, dataFileName), Data("1.0.0"));
        File.WriteAllText(Path.Combine(directory, "CHANGELOG.md"), Changelog("Initial release"));
        Git("add", ".");
        Git("commit", "-m", "Initial");

        File.WriteAllText(Path.Combine(directory, dataFileName), Data("1.1.0"));
        File.WriteAllText(Path.Combine(directory, "CHANGELOG.md"), Changelog("New behavior"));
        Git("add", ".");

        var result = new ChangelogRotator(new RepositoryContext(directory))
            .RotateStaged(new DateOnly(2026, 8, 6));

        Assert.True(result.Modified);
        var staged = Git("show", ":CHANGELOG.md");
        Assert.Contains("## [1.1.0] - 2026-08-06", staged);
        Assert.Equal(staged.Replace("\r\n", "\n"),
            File.ReadAllText(Path.Combine(directory, "CHANGELOG.md")).Replace("\r\n", "\n"));
    }

    [Fact]
    public void RotateStagedSkipsRepositoryWithoutChangelog()
    {
        Directory.CreateDirectory(directory);
        Git("init");
        Git("config", "user.name", "Test User");
        Git("config", "user.email", "test@example.com");
        var dataPath = Path.Combine(directory, "ModHelperData.cs");
        File.WriteAllText(dataPath, Data("1.0.0"));
        Git("add", ".");
        Git("commit", "-m", "Initial");

        File.WriteAllText(dataPath, Data("1.1.0"));
        Git("add", ".");

        var result = new ChangelogRotator(new RepositoryContext(directory))
            .RotateStaged(new DateOnly(2026, 8, 6));

        Assert.False(result.Modified);
        Assert.Equal("No CHANGELOG.md found; changelog rotation skipped.", result.Message);
        Assert.Equal(["ModHelperData.cs"], Git("diff", "--cached", "--name-only")
            .Split(['\r', '\n'], StringSplitOptions.RemoveEmptyEntries));
    }

    [Theory]
    [InlineData("ModHelperData.cs")]
    [InlineData("ModHelper.cs")]
    public void VersionTagCreatesAnnotatedTagForVersionIncrease(string dataFileName)
    {
        InitializeRepository("1.0.0", dataFileName);
        File.WriteAllText(Path.Combine(directory, dataFileName), Data("1.1.0"));
        Git("add", dataFileName);
        Git("commit", "-m", "Release 1.1.0");

        var result = new VersionTagger(new RepositoryContext(directory)).TagCommit();

        Assert.Contains("Created annotated tag 1.1.0", result);
        Assert.Equal(Git("rev-parse", "HEAD").Trim(), Git("rev-parse", "1.1.0^{commit}").Trim());
        Assert.Equal("tag", Git("cat-file", "-t", "refs/tags/1.1.0").Trim());
    }

    [Fact]
    public void VersionTagNeverMovesExistingTag()
    {
        InitializeRepository("1.0.0");
        var original = Git("rev-parse", "HEAD").Trim();
        Git("tag", "--annotate", "1.1.0", "--message", "Existing tag", original);
        File.WriteAllText(Path.Combine(directory, "ModHelperData.cs"), Data("1.1.0"));
        Git("add", "ModHelperData.cs");
        Git("commit", "-m", "Release 1.1.0");

        var result = new VersionTagger(new RepositoryContext(directory)).TagCommit();

        Assert.Contains("it was not moved", result);
        Assert.Equal(original, Git("rev-parse", "1.1.0^{commit}").Trim());
    }

    public void Dispose()
    {
        if (!Directory.Exists(directory)) return;
        foreach (var file in Directory.EnumerateFiles(directory, "*", SearchOption.AllDirectories))
            File.SetAttributes(file, FileAttributes.Normal);
        Directory.Delete(directory, true);
    }

    private string Git(params string[] arguments) => RunGit(directory, arguments);

    private void InitializeRepository(string version, string dataFileName = "ModHelperData.cs")
    {
        Directory.CreateDirectory(directory);
        Git("init");
        Git("config", "user.name", "Test User");
        Git("config", "user.email", "test@example.com");
        File.WriteAllText(Path.Combine(directory, dataFileName), Data(version));
        Git("add", ".");
        Git("commit", "-m", "Initial");
    }

    private static string RunGit(string workingDirectory, params string[] arguments)
    {
        var start = new ProcessStartInfo("git")
        {
            WorkingDirectory = workingDirectory,
            RedirectStandardOutput = true,
            RedirectStandardError = true,
            UseShellExecute = false
        };
        foreach (var argument in arguments) start.ArgumentList.Add(argument);
        using var process = Process.Start(start)!;
        var output = process.StandardOutput.ReadToEnd();
        var error = process.StandardError.ReadToEnd();
        process.WaitForExit();
        Assert.True(process.ExitCode == 0, error);
        return output;
    }

    private static string Data(string version) => $$"""
                                                    public static class ModHelperData
                                                    {
                                                        public const string Version = "{{version}}";
                                                        public const string RepoOwner = "owner";
                                                        public const string RepoName = "repo";
                                                    }
                                                    """;

    private static string Changelog(string entry) => $$"""
                                                       # Changelog

                                                       ## [Unreleased]

                                                       - {{entry}}
                                                       """;
}
