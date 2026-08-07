using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;
using System.Text.RegularExpressions;

namespace BTD_Mod_Helper.Tools;

/// <summary>
/// Not reusing ModHelperData.Shared.cs here to avoid needing external nuget deps and for easier testing setup
/// </summary>
internal sealed partial class ModData
{
    private static readonly HashSet<string> ModHelperData =
        ["ModHelper.cs", "ModHelperData.cs", "ModHelperData.json", "ModHelperData.txt"];

    public static bool IsDataFile(string path) => ModHelperData.Contains(Path.GetFileName(path));

    public ModData(string version, string? repoOwner, string? repoName) :
        this(version, repoOwner, repoName, SemanticVersion.Parse(version))
    {
    }

    private ModData(string version, string? repoOwner, string? repoName, SemanticVersion parsedVersion)
    {
        Version = version;
        RepoOwner = repoOwner;
        RepoName = repoName;
        ParsedVersion = parsedVersion;
    }

    public string Version { get; }
    public string? RepoOwner { get; }
    public string? RepoName { get; }
    private SemanticVersion ParsedVersion { get; }

    public bool VersionIncreasedFrom(ModData previous) => ParsedVersion.CompareTo(previous.ParsedVersion) > 0;

    public static string? FindChangedPath(string paths, string changeState)
    {
        var matches = paths.Split('\0', StringSplitOptions.RemoveEmptyEntries)
            .Where(IsDataFile)
            .ToArray();
        return matches.Length switch
        {
            0 => null,
            1 => matches[0],
            _ => throw new InvalidOperationException($"Multiple {changeState} ModHelperData files found.")
        };
    }

    public static ModData Parse(string content, string path)
    {
        string? version = null;
        string? owner = null;
        string? name = null;
        if (Path.GetExtension(path).Equals(".json", StringComparison.OrdinalIgnoreCase))
        {
            using var document = JsonDocument.Parse(content);
            var root = document.RootElement;
            version = StringProperty(root, "Version");
            owner = StringProperty(root, "RepoOwner");
            name = StringProperty(root, "RepoName");
        }
        else
        {
            foreach (Match match in ValueRegex().Matches(content))
            {
                switch (match.Groups["name"].Value)
                {
                    case "Version":
                        version = match.Groups["value"].Value;
                        break;
                    case "RepoOwner":
                        owner = match.Groups["value"].Value;
                        break;
                    case "RepoName":
                        name = match.Groups["value"].Value;
                        break;
                }
            }
        }

        if (string.IsNullOrWhiteSpace(version)) throw new InvalidDataException($"No Version value found in {path}.");
        if (!SemanticVersion.TryParse(version, out var parsedVersion))
            throw new InvalidDataException($"Invalid semantic version '{version}' in {path}.");
        return new ModData(version, owner, name, parsedVersion!);
    }

    private static string? StringProperty(JsonElement root, string name) =>
        root.TryGetProperty(name, out var property) && property.ValueKind == JsonValueKind.String
            ? property.GetString()
            : null;

    [GeneratedRegex("\\b(?<name>Version|RepoOwner|RepoName)\\s*=\\s*\"(?<value>[^\"]+)\"",
        RegexOptions.CultureInvariant)]
    private static partial Regex ValueRegex();
}
