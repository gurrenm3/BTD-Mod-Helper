using System.Diagnostics;
using System.Text;
using System.Text.RegularExpressions;
using Newtonsoft.Json.Linq;
using Xunit;
using Xunit.Abstractions;

namespace TestRunner;

[CollectionDefinition(nameof(Btd6Collection), DisableParallelization = true)]
public class Btd6Collection; // Ensures BTD6 tests run serially

public sealed record RunResult(int ExitCode, IReadOnlyList<string> Lines);

public static partial class ModTestRunner
{
    public const string DefaultLaunchProfile = "BloonsTD6 (Tests)";

    public const string Configuration =
#if DEBUG
        "Debug";
#else
        "Release";
#endif

    public static readonly string[] IgnoredSubstrings =
    [
        "[Il2CppInterop] Class::Init signatures have been exhausted, using a substitute!",
    ];

    public static async Task<RunResult> RunTestsAsync(
        string projectDirectory,
        ITestOutputHelper output,
        string launchProfile = DefaultLaunchProfile,
        CancellationToken cancellationToken = default)
    {
        var rawArgs = ModSourcesDiscovery.ReadLaunchProfile(projectDirectory, launchProfile)
                          ?["commandLineArgs"]?.Value<string>() ??
                      throw new InvalidOperationException(
                          $"Launch profile '{launchProfile}' (or its commandLineArgs) not found in " +
                          $"{Path.Combine(projectDirectory, "Properties", "launchSettings.json")}");

        var propertyNames = MsBuildPropertyRegex().Matches(rawArgs)
            .Select(m => m.Groups[1].Value)
            .Distinct()
            .ToArray();

        var properties = propertyNames.Length == 0
            ? new Dictionary<string, string>()
            : await QueryMsBuildPropertiesAsync(projectDirectory, propertyNames, cancellationToken);

        var resolvedArgs = MsBuildPropertyRegex().Replace(rawArgs, m =>
            properties.TryGetValue(m.Groups[1].Value, out var value) ? value : m.Value);

        EnsureNoBtd6Running(output);
        try
        {
            return await RunAsync("dotnet", $"run -c {Configuration} --no-launch-profile -- {resolvedArgs}",
                output,
                workingDirectory: projectDirectory,
                cancellationToken: cancellationToken);
        }
        finally
        {
            EnsureNoBtd6Running(output);
        }
    }

    public static int EnsureNoBtd6Running(ITestOutputHelper? output = null)
    {
        var killed = 0;
        foreach (var p in Process.GetProcessesByName("BloonsTD6"))
        {
            try
            {
                p.Kill(entireProcessTree: true);
                p.WaitForExit(5000);
                killed++;
            }
            catch
            {
                // Already exited or access denied — nothing useful we can do.
            }
            finally
            {
                p.Dispose();
            }
        }
        if (killed > 0)
        {
            output?.WriteLine($"[cleanup] Killed {killed} lingering BloonsTD6 process(es).");
        }
        return killed;
    }

    public static Task<RunResult> BuildAsync(
        string projectDirectory,
        ITestOutputHelper output,
        CancellationToken cancellationToken = default) =>
        RunAsync("dotnet", $"build -c {Configuration}",
            output,
            workingDirectory: projectDirectory,
            cancellationToken: cancellationToken);

    public static async Task<RunResult> RunAsync(
        string exe,
        string args,
        ITestOutputHelper output,
        string? workingDirectory = null,
        CancellationToken cancellationToken = default)
    {
        var writer = new TestOutputWriter(output);
        var lines = new List<string>();
        var linesLock = new object();

        var psi = new ProcessStartInfo
        {
            FileName = exe,
            Arguments = args,
            WorkingDirectory = workingDirectory ?? "",
            UseShellExecute = false,
            CreateNoWindow = true,
            RedirectStandardOutput = true,
            RedirectStandardError = true,
            StandardOutputEncoding = Encoding.UTF8,
            StandardErrorEncoding = Encoding.UTF8,
        };

        using var process = new Process();
        process.StartInfo = psi;

        process.OutputDataReceived += (_, e) =>
        {
            if (e.Data is not null) OnLine(e.Data);
        };
        process.ErrorDataReceived += (_, e) =>
        {
            if (e.Data is not null) OnLine(e.Data);
        };

        process.Start();
        process.BeginOutputReadLine();
        process.BeginErrorReadLine();

        try
        {
            await process.WaitForExitAsync(cancellationToken);
        }
        catch (OperationCanceledException)
        {
            if (!process.HasExited)
            {
                // Process tree may already be tearing down
                try { process.Kill(entireProcessTree: true); }
                catch { }
            }
            throw;
        }

        return new RunResult(process.ExitCode, lines);

        void OnLine(string line)
        {
            if (IgnoredSubstrings.Any(line.Contains)) return;
            lock (linesLock) lines.Add(line);
            writer.WriteLine(line);
        }
    }

    private static async Task<Dictionary<string, string>> QueryMsBuildPropertiesAsync(
        string projectDirectory,
        string[] propertyNames,
        CancellationToken cancellationToken)
    {
        // -getProperty refuses .sln files, so we have to hand it the .csproj directly.
        var csproj = Directory.GetFiles(projectDirectory, "*.csproj").FirstOrDefault() ??
                     throw new InvalidOperationException(
                         $"No .csproj found in {projectDirectory}");

        var psi = new ProcessStartInfo
        {
            FileName = "dotnet",
            Arguments = $"msbuild \"{csproj}\" -nologo -getProperty:{string.Join(',', propertyNames)}",
            WorkingDirectory = projectDirectory,
            UseShellExecute = false,
            CreateNoWindow = true,
            RedirectStandardOutput = true,
            RedirectStandardError = true,
            StandardOutputEncoding = Encoding.UTF8,
            StandardErrorEncoding = Encoding.UTF8,
        };

        using var process = new Process();
        process.StartInfo = psi;
        process.Start();

        var stdoutTask = process.StandardOutput.ReadToEndAsync(cancellationToken);
        var stderrTask = process.StandardError.ReadToEndAsync(cancellationToken);
        await process.WaitForExitAsync(cancellationToken);
        var stdout = await stdoutTask;
        var stderr = await stderrTask;

        if (process.ExitCode != 0)
        {
            throw new InvalidOperationException(
                $"dotnet msbuild -getProperty failed (exit {process.ExitCode}):\n{stdout}\n{stderr}");
        }

        var trimmed = stdout.Trim();
        // -getProperty returns a bare value for a single property and a JSON object for multiple.
        if (propertyNames.Length == 1)
        {
            return new Dictionary<string, string> {[propertyNames.Single()] = trimmed};
        }

        var props = (JObject?) JObject.Parse(trimmed)["Properties"] ??
                    throw new InvalidOperationException(
                        $"dotnet msbuild -getProperty output missing 'Properties' object:\n{trimmed}");
        return props.Properties().ToDictionary(p => p.Name, p => p.Value.Value<string>() ?? "");
    }

    [GeneratedRegex(@"\$\((\w+)\)")]
    private static partial Regex MsBuildPropertyRegex();

    private sealed class TestOutputWriter(ITestOutputHelper helper) : TextWriter
    {
        public override Encoding Encoding => Encoding.UTF8;

        public override void WriteLine(string? value)
        {
            // ITestOutputHelper.WriteLine throws after the test method returns; late
            // OutputDataReceived events still need to be tolerated.
            try { helper.WriteLine(value ?? ""); }
            catch (InvalidOperationException) { }
        }
    }
}