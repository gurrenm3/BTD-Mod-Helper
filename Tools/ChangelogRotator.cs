using System;
using System.IO;

namespace BTD_Mod_Helper.Tools;

internal sealed class ChangelogRotator(RepositoryContext repository)
{
    public RotationResult RotateStaged(DateOnly date)
    {
        var dataPath = ResolveStagedDataPath();
        if (dataPath is null)
            return new RotationResult(false, "No staged ModHelperData change; changelog rotation skipped.");

        var stagedDataContent = ShowIndex(dataPath) ??
                                throw new InvalidOperationException($"Unable to read staged {dataPath}.");
        var stagedData = ModData.Parse(stagedDataContent, dataPath);
        var oldDataResult = repository.Git.Run("show", $"HEAD:{dataPath}");
        if (!oldDataResult.Success)
            return new RotationResult(false,
                $"{dataPath} is new; changelog rotation skipped because there is no previous version.");
        var oldData = ModData.Parse(oldDataResult.Output, dataPath);
        if (!stagedData.VersionIncreasedFrom(oldData))
            return new RotationResult(false,
                $"ModHelperData.Version did not increase ({oldData.Version} -> {stagedData.Version}); " +
                "changelog rotation skipped.");

        var changelogPath = FindChangelogPath(dataPath);
        if (changelogPath is null)
            return new RotationResult(false, "No CHANGELOG.md found; changelog rotation skipped.");
        var stagedChangelog = ShowIndex(changelogPath) ??
                              throw new InvalidOperationException($"Unable to read staged {changelogPath}.");
        if (ChangelogEditing.HasVersion(stagedChangelog, stagedData.Version))
            return new RotationResult(false, $"{changelogPath} already contains a {stagedData.Version} section.");

        var unstaged = repository.Git.Run("diff", "--quiet", "--", changelogPath);
        if (unstaged.ExitCode == 1)
            throw new InvalidOperationException(
                $"{changelogPath} has unstaged changes. Stage or stash them before rotating the changelog.");
        if (unstaged.ExitCode != 0) throw new InvalidOperationException(unstaged.Error);

        var previousVersion = ChangelogEditing.FirstReleasedVersion(stagedChangelog);
        var genesisHash = repository.Git.Run("rev-list", "--max-parents=0", "HEAD");
        var updated = ChangelogEditing.Rotate(stagedChangelog, stagedData.Version, date, stagedData,
            previousVersion, genesisHash.Success ? genesisHash.Output.Trim() : null);
        File.WriteAllText(repository.FullPath(changelogPath), updated);
        repository.Git.Require("add", "--", changelogPath);
        return new RotationResult(true,
            $"Rotated and staged {changelogPath} for version {stagedData.Version}. Included it in this commit.");
    }

    private string? ResolveStagedDataPath()
    {
        var changed = repository.Git.Require("diff", "--cached", "--name-only", "--diff-filter=ACMR", "-z", "--");
        return ModData.FindChangedPath(changed, "staged");
    }

    private string? FindChangelogPath(string dataPath)
    {
        var directory = Path.GetDirectoryName(dataPath)?.Replace('\\', '/');
        var local = string.IsNullOrEmpty(directory) ? "CHANGELOG.md" : $"{directory}/CHANGELOG.md";
        if (ShowIndex(local) is not null) return local;
        if (local != "CHANGELOG.md" && ShowIndex("CHANGELOG.md") is not null)
            return "CHANGELOG.md";
        return null;
    }

    private string? ShowIndex(string path)
    {
        var result = repository.Git.Run("show", $":{path}");
        return result.Success ? result.Output : null;
    }
}

internal readonly record struct RotationResult(bool Modified, string Message);
