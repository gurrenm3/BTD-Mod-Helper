using System.IO;
using BTD_Mod_Helper.Tools;
using Xunit;

namespace BTD_Mod_Helper.Tools.Tests;

public class ProgramTests
{
    [Fact]
    public void ReportsAndChecksVersion()
    {
        using var output = new StringWriter();
        using var error = new StringWriter();

        Assert.Equal(0, Program.Run(["--version"], output, error));
        var version = output.ToString().Trim();
        Assert.True(SemanticVersion.TryParse(version, out _));
        Assert.Equal(0, Program.Run(["--version", version], output, error));
        Assert.Equal(1, Program.Run(["--version", "999999.0.0"], output, error));
        Assert.Equal(string.Empty, error.ToString());
    }

    [Fact]
    public void HelpOnlyListsHookCommands()
    {
        using var output = new StringWriter();
        using var error = new StringWriter();

        var exitCode = Program.Run(["--help"], output, error);

        Assert.Equal(0, exitCode);
        Assert.Contains("btd6mh pre-commit", output.ToString());
        Assert.Contains("btd6mh post-commit", output.ToString());
        Assert.DoesNotContain("changelog check", output.ToString());
        Assert.Equal(string.Empty, error.ToString());
    }

    [Fact]
    public void OldImplementationCommandIsRejected()
    {
        using var output = new StringWriter();
        using var error = new StringWriter();

        var exitCode = Program.Run(["changelog", "check"], output, error);

        Assert.Equal(1, exitCode);
        Assert.Contains("Unknown command", error.ToString());
    }
}
