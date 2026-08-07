using System;
using BTD_Mod_Helper.Tools;
using Xunit;

namespace BTD_Mod_Helper.Tools.Tests;

public class ChangelogEditingTests
{
    [Fact]
    public void RotateCreatesReleaseAndComparisonLinks()
    {
        const string changelog = """
                                 # Changelog

                                 ## [Unreleased]

                                 - New behavior

                                 ## [1.0.0] - 2026-01-01

                                 - Initial release

                                 [unreleased]: https://github.com/owner/repo/compare/1.0.0...HEAD
                                 [1.0.0]: https://github.com/owner/repo/compare/abc...1.0.0
                                 """;

        var result = ChangelogEditing.Rotate(changelog, "1.1.0", new DateOnly(2026, 8, 6),
            new ModData("1.1.0", "owner", "repo"), "1.0.0", "abc");

        var normalized = result.Replace("\r\n", "\n");
        Assert.Contains("## [Unreleased]\n\n## [1.1.0] - 2026-08-06\n\n- New behavior", normalized);
        Assert.Contains("[unreleased]: https://github.com/owner/repo/compare/1.1.0...HEAD", normalized);
        Assert.Contains("[1.1.0]: https://github.com/owner/repo/compare/1.0.0...1.1.0", normalized);
    }
}
