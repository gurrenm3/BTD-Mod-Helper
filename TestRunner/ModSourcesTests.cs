using System.Text.RegularExpressions;
using Xunit;
using Xunit.Abstractions;

namespace TestRunner;

/// <summary>
/// Builds and runs tests for every discovered mod in the Mod Sources folder.
/// Each mod's DLL location (Mods vs Disabled Mods) is restored after the run.
/// </summary>
[Collection(nameof(Btd6Collection))]
public partial class ModSourcesTests(ITestOutputHelper output)
{
    public static TheoryData<string> DiscoveredMods => new(ModSourcesDiscovery.DiscoveredMods.Select(mod => mod.Name));

    [SkippableTheory]
    [MemberData(nameof(DiscoveredMods))]
    public async Task Mod_builds_and_tests_pass(string modName)
    {
        var mod = ModSourcesDiscovery.Find(modName) ??
                  throw new InvalidOperationException(
                      $"Mod '{modName}' no longer discoverable in {ModSourcesDiscovery.ModSourcesPath}");

        try
        {
            var build = await ModTestRunner.BuildAsync(mod.ProjectDirectory, output);
            if (build.ExitCode != 0)
            {
                Assert.Fail($"dotnet build failed for '{mod.Name}':\n{SummariseBuildErrors(build.Lines)}");
            }

            Skip.IfNot(
                ModSourcesDiscovery.HasLaunchProfile(mod.ProjectDirectory, ModTestRunner.DefaultLaunchProfile),
                $"Launch profile '{ModTestRunner.DefaultLaunchProfile}' not defined in {mod.Name}/Properties/launchSettings.json");

            var run = await ModTestRunner.RunTestsAsync(mod.ProjectDirectory, output);

            SaveLog(mod.Name);
            EmitSummary(run.Lines);

            if (run.ExitCode != 0)
            {
                Assert.Fail($"Tests failed for '{mod.Name}':\n{SummariseRunFailure(run.Lines)}");
            }
        }
        finally
        {
            RestoreDllLocation(mod);
        }
    }

    private static string SummariseBuildErrors(IReadOnlyList<string> lines)
    {
        var errors = lines
            .Where(l => BuildErrorLine().IsMatch(l))
            .Distinct()
            .Take(10)
            .ToList();
        return errors.Count == 0
            ? "(no compile error lines detected; see full test output)"
            : string.Join('\n', errors);
    }

    private static string SummariseRunFailure(IReadOnlyList<string> lines)
    {
        var problems = lines.Where(IsWarningOrError).Take(10).ToList();
        return problems.Count == 0
            ? "(no warning/error lines detected; see full test output)"
            : string.Join('\n', problems);
    }

    private void EmitSummary(IReadOnlyList<string> lines)
    {
        output.WriteLine("");
        output.WriteLine("===== Summary =====");

        var problems = lines.Where(IsWarningOrError).ToList();
        if (problems.Count > 0)
        {
            output.WriteLine("--- Warnings / Errors ---");
            foreach (var line in problems) output.WriteLine(line);
        }

        var runningIdx = -1;
        for (var i = 0; i < lines.Count; i++)
        {
            if (RunningTestsLine().IsMatch(lines[i]))
            {
                runningIdx = i;
                break;
            }
        }
        if (runningIdx >= 0)
        {
            output.WriteLine("--- Test output ---");
            for (var i = runningIdx; i < lines.Count; i++) output.WriteLine(lines[i]);
        }
    }

    private static void SaveLog(string modName)
    {
        var source = Path.Combine(ModSourcesDiscovery.Btd6Path, "MelonLoader", "Latest.log");
        if (!File.Exists(source)) return;

        var dir = Path.Combine(ModSourcesDiscovery.ThisProjectPath, "TestResults");
        Directory.CreateDirectory(dir);
        File.Copy(source, Path.Combine(dir, $"{modName}.log"), overwrite: true);
    }

    private static void RestoreDllLocation(ModInfo mod)
    {
        if (mod.InitialDllLocation != DllLocation.DisabledMods) return;

        var modsDll = ModSourcesDiscovery.DllPath(mod.Name, DllLocation.Mods);
        if (!File.Exists(modsDll)) return;

        var disabledDll = ModSourcesDiscovery.DllPath(mod.Name, DllLocation.DisabledMods);
        Directory.CreateDirectory(Path.GetDirectoryName(disabledDll)!);
        File.Move(modsDll, disabledDll, overwrite: true);
    }

    private static bool IsWarningOrError(string line) =>
        line.Contains("[WARNING]", StringComparison.Ordinal) ||
        line.Contains("[ERROR]", StringComparison.Ordinal);

    [GeneratedRegex(@": error [A-Z]+\d+:", RegexOptions.IgnoreCase)]
    private static partial Regex BuildErrorLine();

    [GeneratedRegex(@"Running \d+ test\(s\)")]
    private static partial Regex RunningTestsLine();
}
