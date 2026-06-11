using System.IO;
using System.Threading.Tasks;
using Xunit;
using Xunit.Abstractions;

namespace TestRunner;

/// <summary>
/// Builds and runs Mod Helper's own game tests
/// </summary>
[Collection(nameof(Btd6Collection))]
public class ModHelperTests(ITestOutputHelper output)
{
    [Fact]
    public async Task BloonsTD6_Mod_Helper_tests_pass()
    {
        var projectPath = Path.Combine(ModSourcesDiscovery.SolutionRoot, "BloonsTD6 Mod Helper");

        var result = await ModTestRunner.RunTestsAsync(projectPath, output);

        Assert.Equal(0, result.ExitCode);
    }
}
