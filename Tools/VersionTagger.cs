namespace BTD_Mod_Helper.Tools;

internal sealed class VersionTagger(RepositoryContext repository)
{
    public string TagCommit()
    {
        const string commit = "HEAD";
        var commitHash = repository.Git.Require("rev-parse", $"{commit}^{{commit}}").Trim();
        var parent = repository.Git.Run("rev-parse", $"{commit}^");
        if (!parent.Success) return $"{commitHash} has no parent; version tagging skipped.";

        var dataPath = ResolveDataPath(parent.Output.Trim(), commitHash);
        if (dataPath is null) return "No committed ModHelperData change; version tagging skipped.";

        var oldDataResult = repository.Git.Run("show", $"{parent.Output.Trim()}:{dataPath}");
        if (!oldDataResult.Success)
            return $"{dataPath} is new; version tagging skipped because there is no previous version.";
        var oldData = ModData.Parse(oldDataResult.Output, dataPath);
        var newData = ModData.Parse(repository.Git.Require("show", $"{commitHash}:{dataPath}"), dataPath);
        if (!newData.VersionIncreasedFrom(oldData))
            return $"ModHelperData.Version did not increase ({oldData.Version} -> {newData.Version}); " +
                   "version tagging skipped.";

        var existing = repository.Git.Run("rev-parse", $"refs/tags/{newData.Version}^{{commit}}");
        if (existing.Success)
        {
            var taggedCommit = existing.Output.Trim();
            return taggedCommit == commitHash
                ? $"Tag {newData.Version} already points to {commitHash}."
                : $"Tag {newData.Version} already points to {taggedCommit}; it was not moved to {commitHash}.";
        }

        repository.Git.Require("tag", "--annotate", "--no-sign", newData.Version, "--message",
            $"Release {newData.Version}", commitHash);
        return $"Created annotated tag {newData.Version} for {commitHash}.";
    }

    private string? ResolveDataPath(string parent, string commit)
    {
        var paths = repository.Git.Require("diff", "--name-only", "--diff-filter=ACMR", "-z", parent, commit, "--");
        return ModData.FindChangedPath(paths, "committed");
    }
}
