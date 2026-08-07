using System;
using System.IO;

namespace BTD_Mod_Helper.Tools;

internal sealed class RepositoryContext
{
    public RepositoryContext(string? path)
    {
        var start = Path.GetFullPath(path ?? Environment.CurrentDirectory);
        var git = new GitClient(start);
        Root = Path.GetFullPath(git.Require("rev-parse", "--show-toplevel").Trim());
        Git = new GitClient(Root);
    }

    public string Root { get; }
    public GitClient Git { get; }

    public string FullPath(string relativePath) =>
        Path.GetFullPath(relativePath.Replace('/', Path.DirectorySeparatorChar), Root);
}
