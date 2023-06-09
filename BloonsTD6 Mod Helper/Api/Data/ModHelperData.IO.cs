using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text.RegularExpressions;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
namespace BTD_Mod_Helper.Api;

internal partial class ModHelperData
{
    // From MelonLoader SemVersion
    private const string SemVerRegex = @"(?:\d+)" +
                                       @"(?>\.(?:\d+))?" +
                                       @"(?>\.(?:\d+))?" +
                                       @"(?>\-(?:[0-9A-Za-z\-\.]+))?" +
                                       @"(?>\+(?:[0-9A-Za-z\-\.]+))?";

    private const string VersionRegex = "\\bVersion\\s*=\\s*\"(" + SemVerRegex + ")\";?[\n\r]+";
    private const string NameRegex = "\\bName\\s*=\\s*\"(.+)\";?[\n\r]+";
    private const string DescRegex = "\\bDescription\\s*=(?:[\\s+]*\"(.+)\")+;?[\n\r]+";
    private const string IconRegex = "\\bIcon\\s*=\\s*\"(.+\\.png)\";?[\n\r]+";
    private const string DllRegex = "\\bDllName\\s*=\\s*\"(.+\\.dll)\";?[\n\r]+";
    private const string RepoNameRegex = "\\bRepoName\\s*=\\s*\"(.+)\";?[\n\r]+";
    private const string RepoOwnerRegex = "\\bRepoOwner\\s*=\\s*\"(.+)\";?[\n\r]+";
    private const string ManualDownloadRegex = "\\bManualDownload\\s*=\\s*(false|true);?[\n\r]+";
    private const string ZipRegex = "\\bZipName\\s*=\\s*\"(.+\\.zip)\";?[\n\r]+";
    private const string AuthorRegex = "\\bAuthor\\s*=\\s*\"(.+)\";?[\n\r]+";
    private const string SubPathRegex = "\\bSubPath\\s*=\\s*\"(.+)\";?[\n\r]+";
    private const string SquareIconRegex = "\\SquareIcon\\s*=\\s*(false|true);?[\n\r]+";
    private const string ExtraTopicsRegex = "\\bExtraTopics\\s*=\\s*\"(.+)\";?[\n\r]+";
    private const string WorksOnVersionRegex = "\\bWorksOnVersion\\s*=\\s*\"(.+)\";?[\n\r]+";
    private const string DependenciesRegex = "\\bDependencies\\s*=\\s*\"(.+)\";?[\n\r]+";

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
                ModHelper.Warning($"No set method for {propertyInfo.Name}");
                continue;
            }

            var getMethod = propertyInfo.GetGetMethod(true);
            if (getMethod != null)
            {
                Getters[propertyInfo.Name] = getMethod;
            }
            else
            {
                ModHelper.Warning($"No get method for {propertyInfo.Name}");
            }
        }
    }

    private void ReadValuesFromString(string data, bool allowRepo = true)
    {
        Version = GetRegexMatch<string>(data, VersionRegex);
        Name = GetRegexMatch<string>(data, NameRegex);
        Description = GetRegexMatch<string>(data, DescRegex, true);
        Icon = GetRegexMatch<string>(data, IconRegex);
        DllName = GetRegexMatch<string>(data, DllRegex);
        ManualDownload = GetRegexMatch<bool>(data, ManualDownloadRegex);
        ZipName = GetRegexMatch<string>(data, ZipRegex);
        Author = GetRegexMatch<string>(data, AuthorRegex);
        SubPath = GetRegexMatch<string>(data, SubPathRegex);
        if (allowRepo)
        {
            RepoName = GetRegexMatch<string>(data, RepoNameRegex);
            RepoOwner = GetRegexMatch<string>(data, RepoOwnerRegex);
        }
        SquareIcon = GetRegexMatch<bool>(data, SquareIconRegex);
        ExtraTopics = GetRegexMatch<string>(data, ExtraTopicsRegex);
        WorksOnVersion = GetRegexMatch<string>(data, WorksOnVersionRegex);
        Dependencies = GetRegexMatch<string>(data, DependenciesRegex);
    }

    private void ReadValuesFromJson(string data, bool allowRepo = true)
    {
        var json = JObject.Parse(data);
        foreach (var (key, set) in Setters)
        {
            if (json.ContainsKey(key) && (allowRepo || !key.Contains("Repo")))
            {
                try
                {
                    set.Invoke(this, new object[] {json[key]?.ToObject<bool>()});
                }
                catch (Exception)
                {
                    // ignored
                }

                try
                {
                    set.Invoke(this, new object[] {json[key]?.ToObject<string>()});
                }
                catch (Exception)
                {
                    // ignored
                }
            }
        }
    }

    private static T GetRegexMatch<T>(string data, string regex, bool allowMultiline = false)
    {
        if (Regex.Match(data, regex) is {Success: true} match)
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
                return (T) (object) (bool.TryParse(result, out var b) ? b : default);
            }
        }

        return default;
    }

    public void SaveToTxt(string filePath)
    {
        using var fs = new StreamWriter(filePath);
        foreach (var (name, getter) in Getters)
        {
            var result = getter.Invoke(this, null);
            if (result != null)
            {
                string rightSide;
                switch (result)
                {
                    case string s:
                        rightSide = $"\"{s}\"";
                        break;
                    case bool b:
                        rightSide = b.ToString().ToLowerInvariant();
                        break;
                    default:
                        ModHelper.Warning($"Haven't implemented support for {result.GetType().Name}");
                        continue;
                }

                fs.WriteLine($"{name} = {rightSide}");
            }
        }
    }

    public void SaveToJson(string folderPath)
    {
        var json = new JObject();
        Directory.CreateDirectory(folderPath);
        var filePath = Path.Combine(folderPath, DllName.Replace(".dll", ".json"));
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
}