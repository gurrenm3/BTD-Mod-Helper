using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text.RegularExpressions;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
#if MOD_BROWSER
using BTD_Mod_Helper.Api.Helpers;
using BTD_Mod_Helper.Api.ModMenu;
using Semver;
using System.Threading;
using System.Threading.Tasks;
using System.IO;
#endif
#if MOD_HELPER
using BTD_Mod_Helper.Api.Internal;
#elif MOD_BROWSER
using BTD_Mod_Helper.Extensions;
#endif

namespace BTD_Mod_Helper.Api.Data;

[JsonObject(MemberSerialization.OptIn)]
internal partial class ModHelperData
{
    internal const string ModHelperDataCs = "ModHelperData.cs";
    internal const string ModHelperDataJson = "ModHelperData.json";
    internal const string ModHelperDataTxt = "ModHelperData.txt";
    internal const string ModHelperModsJson = "ModHelperMods.json";


    // From MelonLoader SemVersion
    private const string SemVerRegex =
        """(?:\d+)(?>\.(?:\d+))?(?>\.(?:\d+))?(?>\-(?:[0-9A-Za-z\-\.]+))?(?>\+(?:[0-9A-Za-z\-\.]+))?""";

    private const string VersionRegex = """\bVersion\s*=\s*"(""" + SemVerRegex + """)";?[\n\r]+""";
    private const string NameRegex = """\bName\s*=\s*"(.+)";?[\n\r]+""";
    private const string DescRegex = """\bDescription\s*=(?:[\s+]*"(.+)")+;?[\n\r]+""";
    private const string IconRegex = """\bIcon\s*=\s*"(.+\.png)";?[\n\r]+""";
    private const string DllRegex = """\bDllName\s*=\s*"(.+\.dll)";?[\n\r]+""";
    private const string RepoNameRegex = """\bRepoName\s*=\s*"(.+)";?[\n\r]+""";
    private const string RepoOwnerRegex = """\bRepoOwner\s*=\s*"(.+)";?[\n\r]+""";
    private const string ManualDownloadRegex = """\bManualDownload\s*=\s*(false|true);?[\n\r]+""";
    private const string ZipRegex = """\bZipName\s*=\s*"(.+\.zip)";?[\n\r]+""";
    private const string AuthorRegex = """\bAuthor\s*=\s*"(.+)";?[\n\r]+""";
    private const string SubPathRegex = """\bSubPath\s*=\s*"(.+)";?[\n\r]+""";
    private const string SquareIconRegex = """\bSquareIcon\s*=\s*(false|true);?[\n\r]+""";
    private const string ExtraTopicsRegex = """\bExtraTopics\s*=\s*"(.+)";?[\n\r]+""";
    private const string WorksOnVersionRegex = """\bWorksOnVersion\s*=\s*"(.+)";?[\n\r]+""";
    private const string DependenciesRegex = """\bDependencies\s*=\s*"(.+)";?[\n\r]+""";
    private const string PluginRegex = """\bPlugin\s*=\s*(false|true);?[\n\r]+""";
    private const string DescRegex2 = """\bDescription\s*=\s+[\n\r]*\s+"{3}[\n\r]*(?:\s*(.*[\r\n]))+\s*"{3};?[\n\r]+""";
    private const string BranchRegex = """\bBranch\s*=\s*"(.+)";?[\n\r]+""";
    private const string ModHelperDataUrlRegex = """\bModHelperDataUrl\s*=\s*"(.+)";?[\n\r]+""";
    private const string DownloadUrlRegex = """\bDownloadUrl\s*=\s*"(.+)";?[\n\r]+""";
    private const string AuthorizationRegex = """\bAuthorization\s*=\s*"(.+)";?[\n\r]+""";
    private const string PrevRepoNameRegex = """\bPrevRepoName\s*=\s*"(.+)";?[\n\r]+""";
    private const string PrevRepoOwnerRegex = """\bPrevRepoOwner\s*=\s*"(.+)";?[\n\r]+""";

    private static readonly Dictionary<string, MethodInfo> Setters;
    private static readonly Dictionary<string, MethodInfo> Getters;

    /// <summary>
    /// Statically gets the Setters and Getters for easier accessing of the serialized fields
    /// </summary>
    static ModHelperData()
    {
        Setters = new Dictionary<string, MethodInfo>();
        Getters = new Dictionary<string, MethodInfo>();
        foreach (var propertyInfo in typeof(ModHelperData).GetProperties())
        {
            var setMethod = propertyInfo.GetSetMethod(true);
            if (setMethod != null)
            {
                Setters[propertyInfo.Name] = setMethod;
            }
            else
            {
                continue;
            }

            var getMethod = propertyInfo.GetGetMethod(true);
            if (getMethod != null)
            {
                Getters[propertyInfo.Name] = getMethod;
            }
        }
    }

    public ModHelperData()
    {
    }

    public ModHelperData(ModHelperData other)
    {
        foreach (var name in Getters.Keys)
        {
            var result = Getters[name].Invoke(other, null);
            Setters[name]?.Invoke(this, [result]);
        }
    }

    // These public properties are the serialized ones
    [JsonProperty] public string Version { get; internal set; } = null!;
    [JsonProperty] public string Name { get; internal set; } = null!;
    [JsonProperty] public string Description { get; internal set; } = null!;
    [JsonProperty] public string Icon { get; internal set; } = null!;
    [JsonProperty] public string DllName { get; internal set; } = null!;
    [JsonProperty] public string RepoName { get; internal set; } = null!;
    [JsonProperty] public string RepoOwner { get; internal set; } = null!;
    [JsonProperty] public bool ManualDownload { get; internal set; }
    [JsonProperty] public string ZipName { get; internal set; } = null!;
    [JsonProperty] public string Author { get; internal set; } = null!;
    [JsonProperty] public string SubPath { get; internal set; } = null!;
    [JsonProperty] public bool SquareIcon { get; internal set; }
    [JsonProperty] public string ExtraTopics { get; internal set; } = null!;
    [JsonProperty] public string WorksOnVersion { get; internal set; } = null!;
    [JsonProperty] public string Dependencies { get; internal set; } = null!;
    [JsonProperty] public bool Plugin { get; internal set; }
    [JsonProperty] public string Branch { get; internal set; } = null!;
    [JsonProperty] public string ModHelperDataUrl { get; internal set; } = null!;
    [JsonProperty] public string DownloadUrl { get; internal set; } = null!;
    [JsonProperty] public string Authorization { get; internal set; } = null!;
    [JsonProperty] public string PrevRepoName { get; internal set; } = null!;
    [JsonProperty] public string PrevRepoOwner { get; internal set; } = null!;

    internal string DataPath { get; }  = null!;
    internal string CachedModHelperData { get; private set; }  = null!;

#if MOD_BROWSER
    internal string DefaultBranch => RepoName == ModHelper.RepoName && RepoOwner == ModHelper.RepoOwner ? "master" : "main";
#endif

    public void ReadValuesFromType(Type data)
    {
        foreach (var fieldInfo in data
                     .GetFields(BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Static)
                     .Where(info => info is {IsLiteral: true, IsInitOnly: false} && Setters.ContainsKey(info.Name)))
        {
            var rawConstantValue = fieldInfo.GetRawConstantValue()!;
            try
            {
                Setters[fieldInfo.Name].Invoke(this, [rawConstantValue]);
            }
            catch (Exception)
            {
                // ignored
            }
        }
    }

    internal void ReadValues(string data, bool allowRepo = true)
    {
        if (data.StartsWith("{")) ReadValuesFromJson(data, allowRepo);
        else ReadValuesFromString(data, allowRepo);
    }

    internal void ReadValuesFromJson(string data, bool allowRepo = true)
    {
        CachedModHelperData = data;

        var json = JObject.Parse(data);

        if (!allowRepo)
        {
            json.Remove(nameof(RepoName));
            json.Remove(nameof(RepoOwner));
        }

        using var reader = json.CreateReader();
        var serializer = JsonSerializer.CreateDefault();
        serializer.Populate(reader, this);
    }

    internal void ReadValuesFromString(string data, bool allowRepo = true)
    {
        CachedModHelperData = data;

        Version = GetRegexMatch<string>(data, VersionRegex) ?? Version;
        Name = GetRegexMatch<string>(data, NameRegex) ?? Name;
        Description = GetRegexMatch<string>(data, DescRegex2, true) ??
                      GetRegexMatch<string>(data, DescRegex, true) ??
                      Description;
        Icon = GetRegexMatch<string>(data, IconRegex) ?? Icon;
        DllName = GetRegexMatch<string>(data, DllRegex) ?? DllName;
        ManualDownload = GetRegexMatch<bool>(data, ManualDownloadRegex);
        ZipName = GetRegexMatch<string>(data, ZipRegex) ?? ZipName;
        Author = GetRegexMatch<string>(data, AuthorRegex) ?? Author;
        SubPath = GetRegexMatch<string>(data, SubPathRegex) ?? SubPath;
        SquareIcon = GetRegexMatch<bool>(data, SquareIconRegex);
        ExtraTopics = GetRegexMatch<string>(data, ExtraTopicsRegex) ?? ExtraTopics;
        WorksOnVersion = GetRegexMatch<string>(data, WorksOnVersionRegex) ?? WorksOnVersion;
        Dependencies = GetRegexMatch<string>(data, DependenciesRegex) ?? Dependencies;
        Plugin = GetRegexMatch<bool>(data, PluginRegex);
        ModHelperDataUrl = GetRegexMatch<string>(data, ModHelperDataUrlRegex) ?? ModHelperDataUrl;
        Branch = GetRegexMatch<string>(data, BranchRegex) ?? Branch;
        DownloadUrl = GetRegexMatch<string>(data, DownloadUrlRegex) ?? DownloadUrl;
        Authorization = GetRegexMatch<string>(data, AuthorizationRegex) ?? Authorization;
        PrevRepoName = GetRegexMatch<string>(data, PrevRepoNameRegex) ?? PrevRepoName;
        PrevRepoOwner = GetRegexMatch<string>(data, PrevRepoOwnerRegex) ?? PrevRepoOwner;

        if (allowRepo)
        {
            RepoName = GetRegexMatch<string>(data, RepoNameRegex) ?? RepoName;
            RepoOwner = GetRegexMatch<string>(data, RepoOwnerRegex) ?? RepoOwner;
        }
    }

    internal static T GetRegexMatch<T>(string data, string regex, bool allowMultiline = false)
    {
        if (Regex.Match(data, regex, RegexOptions.Multiline) is {Success: true} match)
        {
            var matchGroup = match.Groups[1];
            var result = allowMultiline
                ? string.Join("", matchGroup.Captures)
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

        return default!;
    }


#if MOD_BROWSER && !RELEASELITE
    internal string GetContentURL(string name)
    {
        var path = Uri.EscapeDataString(name);
        if (SubPath != null && !(SubPath.EndsWith(".json") || SubPath.EndsWith(".cs") || SubPath.EndsWith(".txt")))
        {
            path = $"{SubPath}/{path}";
        }

        return $"{ModHelperGithub.RawUserContent}/{RepoOwner}/{RepoName}/{Branch ?? DefaultBranch}/{path}";
    }


    internal async Task<string> RetrieveData(string name = null, CancellationToken ct = default)
    {
        var url = name == null ? ModHelperDataUrl : GetContentURL(name);
        var data = await ModHelperHttp.Client.GetStringWithAuthAsync(url, Authorization, ct);

        if (!string.IsNullOrEmpty(data))
        {
            ModHelperDataUrl = url;
        }

        return data;
    }

    public static bool IsUpdate(string currentVersion, string latestVersion, string latestWorksOnVersion = null)
    {
        if (!SemVersion.TryParse(latestVersion, out var latestSemver) ||
            !SemVersion.TryParse(currentVersion, out var currentSemver))
        {
            return false;
        }

        if (SemVersion.TryParse(latestWorksOnVersion, out var worksOnVersion) &&
            SemVersion.TryParse(VersionCompat.GameVersion, out var gameVersion) &&
            gameVersion < worksOnVersion)
        {
            return false;
        }

        return latestSemver > currentSemver;
    }


    public async Task<string> LoadDataFromRepoAsync(CancellationToken ct = default)
    {
        try
        {
            string data = null;

            if (ModHelperDataUrl != null)
            {
                data ??= await RetrieveData(ct: ct);
            }

            if (RepoName == ModHelper.RepoName)
            {
                data ??= await RetrieveData("BloonsTD6 Mod Helper/ModHelper.cs", ct);
            }
            else if (SubPath != null &&
                     (SubPath.EndsWith(".txt") || SubPath.EndsWith(".json") || SubPath.EndsWith(".cs")))
            {
                data ??= await RetrieveData(SubPath, ct);
            }
            else if (DataPath != null)
            {
                data ??= await RetrieveData(DataPath, ct);
            }

            try
            {
                data ??= await WhenFirstSucceededOrAllFailed([
                    RetrieveData(ModHelperDataCs, ct),
                    RetrieveData(ModHelperDataJson, ct),
                    RetrieveData(ModHelperDataTxt, ct)
                ]);
            }
            catch (Exception e)
            {
                if (RepoOwner == ModHelper.MyGithubUsername)
                {
                    ModHelper.Warning(e);
                }
            }

            if (data == null)
            {
                if (RepoOwner == ModHelper.MyGithubUsername)
                {
                    ModHelper.Warning(
                        $"Did not find any mod data for {RepoOwner}/{RepoName} {SubPath} branch {Branch}");
                }

                return null;
            }

            if (RepoName == "BTD6EpicGamesModCompat")
            {
                Plugin = true;
            }

            return data;

        }
        catch (Exception e)
        {
            if (RepoOwner == ModHelper.MyGithubUsername || RepoName == ModHelper.RepoName)
            {
                ModHelper.Warning($"Failed to get ModHelperData for {Name}");
                ModHelper.Warning(e);
            }

            return null;
        }
    }

    private static async Task<T> WhenFirstSucceededOrAllFailed<T>(IEnumerable<Task<T>> tasks)
    {
        var taskList = new List<Task<T>>(tasks);
        while (taskList.Count > 0)
        {
            var firstCompleted = await Task.WhenAny(taskList).ConfigureAwait(false);
            if (firstCompleted.Status == TaskStatus.RanToCompletion)
            {
                return firstCompleted.Result;
            }

            taskList.Remove(firstCompleted);
        }

        return default;
    }

    public void SaveToJson(string folderPath)
    {
        Directory.CreateDirectory(folderPath);
        var filePath = Path.Combine(folderPath, DllName.Replace(".dll", ".json"));

        var json = new JObject();

        if (File.Exists(filePath))
        {
            try
            {
                json = JObject.Parse(File.ReadAllText(filePath));
            }
            catch (Exception)
            {
                // ignored
            }
        }

        foreach (var (name, getter) in Getters)
        {
            var result = getter.Invoke(this, null);
            if (result != null)
            {
                json[name] = result switch
                {
                    string s => s,
                    bool b => b,
                    int i => i,
                    float f => f,
                    _ => json[result]
                };
            }
        }

        File.WriteAllText(filePath, json.ToString(Formatting.Indented));
    }

#endif

}