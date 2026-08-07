using System;
using System.IO;
using System.Text.RegularExpressions;

namespace BTD_Mod_Helper.Tools;

internal static partial class ChangelogEditing
{
    public static string Rotate(string content, string version, DateOnly date, ModData data, string? previousVersion,
        string? genesisHash)
    {
        if (HasVersion(content, version)) return content;
        var match = UnreleasedHeading().Match(content);
        if (!match.Success)
            throw new InvalidDataException("CHANGELOG.md does not contain a '## [Unreleased]' section.");

        var newline = content.Contains("\r\n", StringComparison.Ordinal) ? "\r\n" : "\n";
        var releaseHeading = $"## [{version}] - {date:yyyy-MM-dd}";
        var rotated = content[..match.Index] + match.Value + newline + newline + releaseHeading +
                      content[(match.Index + match.Length)..];
        return UpdateLinks(rotated, newline, version, data, previousVersion, genesisHash);
    }

    public static bool HasVersion(string content, string version) =>
        Regex.IsMatch(content, $@"^## \[{Regex.Escape(version)}\](?:\s+-\s+\d{{4}}-\d{{2}}-\d{{2}})?\s*$",
            RegexOptions.Multiline | RegexOptions.CultureInvariant);

    public static string? FirstReleasedVersion(string content)
    {
        var match = ReleasedHeading().Match(content);
        return match.Success ? match.Groups["version"].Value : null;
    }

    private static string UpdateLinks(string content, string newline, string version, ModData data,
        string? previousVersion, string? genesisHash)
    {
        if (string.IsNullOrWhiteSpace(data.RepoOwner) || string.IsNullOrWhiteSpace(data.RepoName)) return content;
        var baseUrl = $"https://github.com/{data.RepoOwner}/{data.RepoName}/compare";
        var previous = previousVersion ?? genesisHash;
        if (string.IsNullOrWhiteSpace(previous)) return content;

        var unreleased = $"[unreleased]: {baseUrl}/{version}...HEAD";
        var release = $"[{version}]: {baseUrl}/{previous}...{version}";
        var link = UnreleasedLink().Match(content);
        if (link.Success)
            return content[..link.Index] + unreleased + newline + release + content[(link.Index + link.Length)..];
        return content.TrimEnd() + newline + newline + unreleased + newline + release + newline;
    }

    [GeneratedRegex("^## \\[Unreleased\\][ \\t]*(?=\\r?$)",
        RegexOptions.Multiline | RegexOptions.IgnoreCase | RegexOptions.CultureInvariant)]
    private static partial Regex UnreleasedHeading();

    [GeneratedRegex("^## \\[(?<version>[^]\\r\\n]+)\\]\\s+-\\s+\\d{4}-\\d{2}-\\d{2}\\s*$",
        RegexOptions.Multiline | RegexOptions.CultureInvariant)]
    private static partial Regex ReleasedHeading();

    [GeneratedRegex("^\\[unreleased\\]:[^\\r\\n]*",
        RegexOptions.Multiline | RegexOptions.IgnoreCase | RegexOptions.CultureInvariant)]
    private static partial Regex UnreleasedLink();
}
