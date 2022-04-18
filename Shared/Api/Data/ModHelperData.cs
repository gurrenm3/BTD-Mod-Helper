using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using BTD_Mod_Helper.Api.ModMenu;
using BTD_Mod_Helper.Api.Updater;
using BTD_Mod_Helper.Extensions;
using HarmonyLib;
using MelonLoader;
using Octokit;
using UnityEngine;
using FileMode = System.IO.FileMode;

namespace BTD_Mod_Helper.Api
{
    /// <summary>
    /// Class representing all the data ModHelper can utilize about a mod as separate from the MelonMod / .dll itself.
    /// <br />
    /// This is used for getting mod information from its GitHub repo, for getting information about enabled mods even
    /// if they don't want to have Mod Helper as a dependency, and keeping track of info about disabled mods.
    /// </summary>
    internal class ModHelperData
    {
        private const string ModHelperDataName = "ModHelperData.cs";
        private const string ModHelperDataName2 = "ModHelperData.txt";
        private const string DefaultIcon = "Icon.png";

        private const string VersionRegex = "\\bVersion\\s*=\\s*\"([.0-9]+)\";?[\n\r]+";
        private const string NameRegex = "\\bName\\s*=\\s*\"(.+)\";?[\n\r]+";
        private const string DescRegex = "\\bDescription\\s*=(?:[\\s+]*\"(.+)\")+;?[\n\r]+";
        private const string IconRegex = "\\bIcon\\s*=\\s*\"(.+)\\.png\";?[\n\r]+";
        private const string DllRegex = "\\bDllName\\s*=\\s*\"(.+\\.dll)\";?[\n\r]+";
        private const string RepoNameRegex = "\\bRepoName\\s*=\\s*\"(.+)\";?[\n\r]+";
        private const string RepoOwnerRegex = "\\bRepoOwner\\s*=\\s*\"(.+)\";?[\n\r]+";
        private const string ManualDownloadRegex = "\\bManualDownload\\s*=\\s*(false|true);?[\n\r]+";
        private const string ZipRegex = "\\bZipName\\s*=\\s*\"(.+)\\.zip\";?[\n\r]+";
        private const string AuthorRegex = "\\bAuthor\\s*=\\s*\"(.+)\";?[\n\r]+";

        /// <summary>
        /// The ModHelperData objects for currently enabled mods
        /// </summary>
        internal static readonly Dictionary<MelonMod, ModHelperData> Cache = new Dictionary<MelonMod, ModHelperData>();

        /// <summary>
        /// ModHelperData for mods that are present in the Mods folder (and loaded successfully)
        /// </summary>
        internal static readonly List<ModHelperData> Active = new List<ModHelperData>();

        /// <summary>
        /// ModHelperData for mods that are in the disabled mods folder
        /// </summary>
        internal static readonly List<ModHelperData> Inactive = new List<ModHelperData>();

        private static readonly Dictionary<string, MethodInfo> Setters;
        private static readonly Dictionary<string, MethodInfo> Getters;
        private Sprite icon;

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

        public ModHelperData()
        {
        }

        public ModHelperData(Repository repository)
        {
            Repository = repository;
            RepoOwner = repository.Owner.Login;
            RepoName = repository.Name;
        }

        public ModHelperData(MelonMod mod)
        {
            Mod = mod;
            Name = mod.Info.Name;
            Version = mod.Info.Version;
            Author = mod.Info.Author;
            FilePath = mod.Location;
            DllName = FilePath.Split('\\').Last();

            var data = mod.Assembly.GetValidTypes().FirstOrDefault(type => type.Name == nameof(ModHelperData));
            if (mod is MelonMain)
            {
                data = typeof(ModHelper);
            }

            if (data != null)
            {
                foreach (var fieldInfo in data
                             .GetFields(BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Static)
                             .Where(info => info.IsLiteral && !info.IsInitOnly && Setters.ContainsKey(info.Name)))
                {
                    var rawConstantValue = fieldInfo.GetRawConstantValue();
                    try
                    {
                        Setters[fieldInfo.Name].Invoke(this, new[] {rawConstantValue});
                    }
                    catch (Exception)
                    {
                        ModHelper.Warning(
                            $"The {fieldInfo.Name} of {mod.Info.Name}'s ModHelperData has incorrect type {rawConstantValue.GetType().Name}");
                    }
                }
            }

            // ReSharper disable once ConstantNullCoalescingCondition
            var iconPath = Icon ?? "Icon.png";
            var assemblyPath = "." + iconPath.Replace("/", ".");
            var resource = mod.Assembly
                .GetManifestResourceNames()
                .FirstOrDefault(s => s.EndsWith(assemblyPath));
            if (resource != null)
            {
                IconBytes = mod.Assembly.GetManifestResourceStream(resource).GetByteArray();
            }
            else
            {
                HasNoIcon = true;
            }
        }

        internal static IEnumerable<ModHelperData> All => Active.Concat(Inactive);

        internal byte[] IconBytes { get; private set; }
        internal bool HasNoIcon { get; private set; }

        // These public properties are the serialized ones
        public string Version { get; protected set; }
        public string Name { get; protected set; }
        public string Description { get; protected set; }
        public string Icon { get; protected set; }
        public string DllName { get; protected set; }
        public string RepoName { get; protected set; }
        public string RepoOwner { get; protected set; }
        public bool ManualDownload { get; protected set; }
        public string ZipName { get; protected set; }
        public string Author { get; protected set; }

        /// <summary>
        /// The currently active mod that this is associated with, if any
        /// </summary>
        internal MelonMod Mod { get; }

        /// <summary>
        /// Whether this mod is correctly in the Enabled mods folder
        /// </summary>
        internal bool Enabled => FilePath != null &&
                                 FilePath == Path.Combine(MelonHandler.ModsDirectory, DllName);

        internal bool RestartRequired =>
            Enabled == (Mod == null) || Mod != null && UpdaterHttp.IsUpdate(Mod.Info.Version, Version);

        /// <summary>
        /// The place that the .dll file for this mod is on the local machine, if any
        /// </summary>
        internal string FilePath { get; private set; }

        // Browser Mod Info
        internal Repository Repository { get; private set; }
        internal bool RepoDataSuccess { get; private set; }
        internal string RepoVersion { get; private set; }
        internal Release LatestRelease { get; private set; }


        internal bool UpdateAvailable =>
            !RestartRequired && RepoDataSuccess && RepoVersion != null && UpdaterHttp.IsUpdate(Version, RepoVersion);

        private void ReadValuesFromString(string data)
        {
            Version = GetRegexMatch<string>(data, VersionRegex);
            Name = GetRegexMatch<string>(data, NameRegex);
            Description = GetRegexMatch<string>(data, DescRegex, true);
            Icon = GetRegexMatch<string>(data, IconRegex);
            DllName = GetRegexMatch<string>(data, DllRegex);
            RepoName = GetRegexMatch<string>(data, RepoNameRegex);
            RepoOwner = GetRegexMatch<string>(data, RepoOwnerRegex);
            ManualDownload = GetRegexMatch<bool>(data, ManualDownloadRegex);
            ZipName = GetRegexMatch<string>(data, ZipRegex);
            Author = GetRegexMatch<string>(data, AuthorRegex);
        }

        private static T GetRegexMatch<T>(string data, string regex, bool allowMultiline = false)
        {
            if (Regex.Match(data, regex) is Match match && match.Success)
            {
                var matchGroup = match.Groups[1];
                var result = allowMultiline
                    ? matchGroup.Captures.Cast<Capture>().Select(c => c.Value).Join(delimiter: "")
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

        public static void Load(MelonMod mod)
        {
            var modHelperData = new ModHelperData(mod);
            Cache[mod] = modHelperData;
            Active.Add(modHelperData);
        }

        private string GetContentURL(string name)
        {
            return $"{ModHelperGithub.RawUserContent}/{RepoOwner}/{RepoName}/{Repository.DefaultBranch}/{name}";
        }

        public async Task LoadDataFromRepoAsync()
        {
            try
            {
                string data = null;
                try
                {
                    data = await ModHelperHttp.Client.GetStringAsync(GetContentURL(ModHelperDataName));
                }
                catch (Exception)
                {
                    // ignored
                }

                if (data == null)
                {
                    try
                    {
                        data = await ModHelperHttp.Client.GetStringAsync(GetContentURL(ModHelperDataName2));
                    }
                    catch (Exception)
                    {
                        // ignored
                    }
                }

                if (data == null)
                {
                    return;
                }

                ReadValuesFromString(data);

                if (HasRequiredRepoData())
                {
                    RepoDataSuccess = true;
                    RepoVersion = Version;

                    if (ModInstalledLocally(out var modHelperData))
                    {
                        modHelperData.Repository = Repository;
                        modHelperData.RepoVersion = Version;
                        modHelperData.RepoDataSuccess = true;
                    }
                }
            }
            catch (Exception e)
            {
                ModHelper.Warning($"Failed to get ModHelperData for {Repository.Name}");
                ModHelper.Warning(e);
            }
        }

        public bool HasRequiredRepoData()
        {
            return Version != null && RepoName != null && RepoOwner != null;
        }

        public async Task<Release> GetLatestRelease()
        {
            try
            {
                return LatestRelease = await ModHelperGithub.Client.Repository.Release.GetLatest(Repository.Id);
            }
            catch (Exception e)
            {
                ModHelper.Warning($"Failed to get latest release for {Name}");
                ModHelper.Warning(e);
                return null;
            }
            finally
            {
                ModHelperGithub.UpdateRateLimit();
            }
        }

        public async Task<bool> LoadIconFromRepoAsync()
        {
            // Don't fetch an icon that we've already got
            // This does mean that icon changes won't be seen in the Mod Browser until you download the new version, but that's ok
            if (ModInstalledLocally(out var local))
            {
                IconBytes = local.IconBytes;
                HasNoIcon = local.HasNoIcon;
                return !HasNoIcon;
            }

            // As a precaution against trolls, only Verified Modders can have their icons shown in the Mod Browser
            // This may or may not expand to Verified Modders being the only ones with mods in the browser allowed
            if (HasNoIcon || !ModHelperGithub.VerifiedModders.Contains(RepoOwner))
            {
                return false;
            }

            if (IconBytes == null)
            {
                try
                {
                    IconBytes = await ModHelperHttp.Client.GetByteArrayAsync(GetContentURL(Icon ?? DefaultIcon));
                }
                catch (Exception)
                {
                    HasNoIcon = true;
                }
            }

            return IconBytes != null && IconBytes.Length != 0;
        }

        public bool ModInstalledLocally(out ModHelperData modHelperData)
        {
            modHelperData = All.FirstOrDefault(data => data.RepoName != null &&
                                                       data.RepoName == RepoName &&
                                                       data.RepoOwner == RepoOwner &&
                                                       data.RepoOwner != null ||
                                                       data.DllName != null &&
                                                       data.DllName == DllName);
            return modHelperData != null;
        }

        public Sprite GetIcon()
        {
            if (icon != null)
            {
                return icon;
            }

            if (IconBytes != null)
            {
                var texture = new Texture2D(2, 2) {filterMode = FilterMode.Bilinear, mipMapBias = -1};
                ImageConversion.LoadImage(texture, IconBytes);
                var sprite = Sprite.Create(texture, new Rect(0, 0, texture.width, texture.height),
                    new Vector2(0.5f, 0.5f), 10f);
                sprite.name = Name;
                icon = sprite;
                return sprite;
            }

            return null;
        }

        public void SetFilePath(string filePath)
        {
            FilePath = filePath;
            DllName = FilePath.Split('\\').Last();
        }

        public void SetVersion(string version)
        {
            Version = version;
        }

        public void SaveToFile(string filePath)
        {
            using (var fs = new StreamWriter(filePath))
            {
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
        }

        public bool MoveToDisabledModsFolder()
        {
            try
            {
                if (!Directory.Exists(ModHelper.DisabledModsDirectory))
                {
                    Directory.CreateDirectory(ModHelper.DisabledModsDirectory);
                }

                var newFilePath = Path.Combine(ModHelper.DisabledModsDirectory, DllName);
                File.Move(FilePath, newFilePath);


                if (!Directory.Exists(ModHelper.DataDirectory))
                {
                    Directory.CreateDirectory(ModHelper.DataDirectory);
                }

                SaveToFile(Path.Combine(ModHelper.DataDirectory, DllName.Replace(".dll", ".txt")));
                if (GetIcon() is Sprite sprite)
                {
                    sprite.texture.TrySaveToPNG(Path.Combine(ModHelper.DataDirectory, DllName.Replace(".dll", ".png")));
                }

                FilePath = newFilePath;
                return true;
            }
            catch (Exception e)
            {
                ModHelper.Warning($"Failed to move {FilePath} to disabled mods folder");
                ModHelper.Warning(e);
            }

            return false;
        }

        public bool MoveToEnabledModsFolder()
        {
            try
            {
                var newFilePath = Path.Combine(MelonHandler.ModsDirectory, DllName);
                File.Move(FilePath, newFilePath);
                FilePath = newFilePath;
                return true;
            }
            catch (Exception e)
            {
                ModHelper.Warning($"Failed to move {FilePath} to mods folder");
                ModHelper.Warning(e);
            }

            return false;
        }

        public static void LoadAll()
        {
            foreach (var melonMod in MelonHandler.Mods)
            {
                try
                {
                    Load(melonMod);
                }
                catch (Exception e)
                {
                    ModHelper.Warning(e);
                }
            }

            Task.Run(async () =>
            {
                var disabledMods = new DirectoryInfo(ModHelper.DisabledModsDirectory);
                if (disabledMods.Exists)
                {
                    foreach (var file in disabledMods.EnumerateFiles())
                    {
                        if (file.Extension != ".dll")
                        {
                            continue;
                        }

                        var dataFile = Path.Combine(ModHelper.DataDirectory, file.Name.Replace(".dll", ".txt"));
                        if (!File.Exists(dataFile))
                        {
                            continue;
                        }

                        try
                        {
                            using (var fs = new StreamReader(dataFile))
                            {
                                var contents = await fs.ReadToEndAsync();
                                var data = new ModHelperData();
                                data.ReadValuesFromString(contents);

                                if (!data.ModInstalledLocally(out _))
                                {
                                    var iconFile = Path.Combine(ModHelper.DataDirectory,
                                        file.Name.Replace(".dll", ".png"));
                                    if (File.Exists(iconFile))
                                    {
                                        data.IconBytes = new FileStream(iconFile, FileMode.Open).GetByteArray();
                                    }
                                    else
                                    {
                                        data.HasNoIcon = true;
                                    }

                                    data.SetFilePath(file.FullName);
                                    Inactive.Add(data);
                                    ModHelper.Msg($"Found disabled mod {file.FullName}");
                                }
                                else
                                {
                                    ModHelper.Msg($"{data.Name} is already enabled?");
                                }
                            }
                        }
                        catch (Exception e)
                        {
                            ModHelper.Warning($"Failed to read disabled mod data {file.Name}");
                            ModHelper.Warning(e);
                        }
                    }
                }
            });
        }
    }
}