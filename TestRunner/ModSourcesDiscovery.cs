using System.Xml.Linq;
using Newtonsoft.Json.Linq;

namespace TestRunner;

public enum DllLocation
{
    Mods,
    DisabledMods,
}

public sealed record ModInfo(string Name, string ProjectDirectory, DllLocation InitialDllLocation);

public static class ModSourcesDiscovery
{
    private const string DefaultBtd6Path = @"C:\Program Files (x86)\Steam\steamapps\common\BloonsTD6";

    public static string ThisProjectPath { get; } =
        FindAncestorDirectory($"{nameof(TestRunner)}.csproj") ??
        throw new InvalidOperationException(
            $"Could not find TestRunner.csproj above '{AppContext.BaseDirectory}'");

    public static string SolutionRoot { get; } =
        FindAncestorDirectory("*.sln") ??
        throw new InvalidOperationException(
            $"Could not find a .sln above '{AppContext.BaseDirectory}'");

    public static string ModSourcesPath { get; } =
        Directory.GetParent(SolutionRoot)?.FullName ??
        throw new InvalidOperationException($"Solution root '{SolutionRoot}' has no parent");

    public static string Btd6Path { get; } = ResolveBtd6Path(ModSourcesPath);

    private static readonly Lazy<IReadOnlyDictionary<string, ModInfo>> ModsByName =
        new(() => Scan().ToDictionary(m => m.Name, StringComparer.Ordinal));

    public static IEnumerable<ModInfo> DiscoveredMods => ModsByName.Value.Values;

    public static ModInfo? Find(string name) => ModsByName.Value.GetValueOrDefault(name);

    public static DllLocation? FindDll(string name)
    {
        if (File.Exists(DllPath(name, DllLocation.Mods))) return DllLocation.Mods;
        if (File.Exists(DllPath(name, DllLocation.DisabledMods))) return DllLocation.DisabledMods;
        return null;
    }

    public static string DllPath(string name, DllLocation location) =>
        Path.Combine(Btd6Path, location == DllLocation.Mods ? "Mods" : "Disabled Mods", $"{name}.dll");

    public static JObject? ReadLaunchProfile(string projectDirectory, string profileName)
    {
        var path = Path.Combine(projectDirectory, "Properties", "launchSettings.json");
        if (!File.Exists(path)) return null;

        try
        {
            return JObject.Parse(File.ReadAllText(path))["profiles"]?[profileName] as JObject;
        }
        catch
        {
            return null;
        }
    }

    public static bool HasLaunchProfile(string projectDirectory, string profileName) =>
        ReadLaunchProfile(projectDirectory, profileName) != null;

    private static IEnumerable<ModInfo> Scan()
    {
        if (!Directory.Exists(ModSourcesPath)) yield break;

        foreach (var dir in Directory.EnumerateDirectories(ModSourcesPath))
        {
            var name = Path.GetFileName(dir);

            if (!File.Exists(Path.Combine(dir, $"{name}.csproj"))) continue;
            if (!Directory.EnumerateFiles(dir, "ModHelperData.*", SearchOption.TopDirectoryOnly).Any()) continue;

            var location = FindDll(name);
            if (location is null) continue;

            yield return new ModInfo(name, dir, location.Value);
        }
    }

    private static string? FindAncestorDirectory(string searchPattern)
    {
        var dir = new DirectoryInfo(AppContext.BaseDirectory);
        while (dir != null && dir.GetFiles(searchPattern).Length == 0)
        {
            dir = dir.Parent;
        }
        return dir?.FullName;
    }

    private static string ResolveBtd6Path(string modSourcesPath)
    {
        var fromEnv = Environment.GetEnvironmentVariable("BloonsTD6");
        if (!string.IsNullOrWhiteSpace(fromEnv)) return fromEnv;

        var targetsFile = Path.Combine(modSourcesPath, "btd6.targets");
        if (File.Exists(targetsFile))
        {
            try
            {
                var doc = XDocument.Load(targetsFile);
                var ns = doc.Root!.GetDefaultNamespace();
                var value = doc.Descendants(ns + "BloonsTD6").FirstOrDefault()?.Value;
                if (!string.IsNullOrWhiteSpace(value)) return value;
            }
            catch
            {
                // Malformed btd6.targets — fall through to default.
            }
        }

        return DefaultBtd6Path;
    }
}