using BTD_Mod_Helper.Tools;
using Xunit;

namespace BTD_Mod_Helper.Tools.Tests;

public class SemanticVersionTests
{
    [Theory]
    [InlineData("1.0.1", "1.0.0")]
    [InlineData("2", "1.99.99")]
    [InlineData("1.0.0", "1.0.0-rc.1")]
    [InlineData("1.0.0-rc.2", "1.0.0-rc.1")]
    public void GreaterVersionsCompareHigher(string newer, string older)
    {
        Assert.True(SemanticVersion.TryParse(newer, out var newVersion));
        Assert.True(SemanticVersion.TryParse(older, out var oldVersion));
        Assert.True(newVersion!.CompareTo(oldVersion) > 0);
    }

    [Theory]
    [InlineData("01.0.0")]
    [InlineData("1.0.0-")]
    [InlineData("not-a-version")]
    public void InvalidVersionsAreRejected(string value) => Assert.False(SemanticVersion.TryParse(value, out _));
}
