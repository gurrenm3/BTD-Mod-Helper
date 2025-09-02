using System.Linq;
using System.Text.RegularExpressions;

namespace UpdaterPlugin;

internal static class ModHelperData
{
    internal const string Name = "Updater Plugin";
    internal const string Author = "doombubbles";
    internal const string Version = "1.0.0";
    internal const string Description = "Keeps Mod Helper up to date on startup";
    internal const string RepoOwner = "gurrenm3";
    internal const string RepoName = "BTD-Mod-Helper";

    // From MelonLoader SemVersion
    public const string SemVerRegex = @"(?:\d+)" +
                                      @"(?>\.(?:\d+))?" +
                                      @"(?>\.(?:\d+))?" +
                                      @"(?>\-(?:[0-9A-Za-z\-\.]+))?" +
                                      @"(?>\+(?:[0-9A-Za-z\-\.]+))?";

    public const string VersionRegex = "\\bVersion\\s*=\\s*\"(" + SemVerRegex + ")\";?[\n\r]+";

    public const string WorksOnVersionRegex = "\\bWorksOnVersion\\s*=\\s*\"(.+)\";?[\n\r]+";

    public static T GetRegexMatch<T>(string data, string regex, bool allowMultiline = false)
    {
        if (Regex.Match(data, regex, RegexOptions.Multiline) is {Success: true} match)
        {
            var matchGroup = match.Groups[1];
            var result = allowMultiline
                             ? matchGroup.Captures.Select(c => c.Value).Join(delimiter: "")
                             : matchGroup.Value;
            if (typeof(T) == typeof(string))
            {
                return (T) (object) result;
            }

            if (typeof(T) == typeof(bool))
            {
                return (T) (object) (bool.TryParse(result, out var b) && b);
            }
        }

        return default;
    }

}