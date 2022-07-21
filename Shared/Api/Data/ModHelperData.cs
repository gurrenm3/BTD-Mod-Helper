using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace BTD_Mod_Helper.Api;

/// <summary>
/// Class representing all the data ModHelper can utilize about a mod as separate from the MelonMod / .dll itself.
/// <br />
/// This is used for getting mod information from its GitHub repo, for getting information about enabled mods even
/// if they don't want to have Mod Helper as a dependency, and keeping track of info about disabled mods.
/// </summary>
internal partial class ModHelperData
{
    private const string DefaultIcon = "Icon.png";

    /// <summary>
    /// The ModHelperData objects for currently enabled mods
    /// </summary>
    internal static readonly Dictionary<MelonMod, ModHelperData> Cache = new();

    /// <summary>
    /// ModHelperData for mods that are present in the Mods folder
    /// </summary>
    internal static readonly List<ModHelperData> Active = new();

    /// <summary>
    /// ModHelperData for mods that are in the disabled mods folder
    /// </summary>
    internal static readonly List<ModHelperData> Inactive = new();

    private Sprite icon;

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
    public string SubPath { get; protected set; }

    /// <summary>
    /// The currently active mod that this is associated with, if any
    /// </summary>
    internal MelonMod Mod { get; }

    /// <summary>
    /// Whether this mod is correctly in the Enabled mods folder
    /// </summary>
    internal bool Enabled => FilePath != null &&
                             DllName != null &&
                             FilePath == Path.Combine(MelonHandler.ModsDirectory, DllName);

    /// <summary>
    /// Either a Mod's "Enabled" status is different from whether or not it's loaded into the game,
    /// or the data Version is ahead of the currently loaded mod's version
    /// </summary>
    internal bool RestartRequired =>
        Enabled == (Mod == null) || Mod != null && Version != null && IsUpdate(Mod.Info.Version, Version, RepoOwner);


    internal string DisplayName => Name ?? Mod?.Info.Name ?? Repository?.Name;

    internal string DisplayDescription => Description ?? Repository?.Description ?? "No description provided.";

    public ModHelperData()
    {
    }

    public ModHelperData(MelonMod mod)
    {
        Mod = mod;
        Name = mod.Info.Name;
        Version = mod.Info.Version;
        Author = mod.Info.Author;
        FilePath = mod.MelonAssembly.Assembly.Location;
        DllName = FilePath.Split('\\').Last();

        var data = mod is MelonMain
            ? typeof(ModHelper)
            : mod.MelonAssembly.Assembly
                .GetValidTypes()
                .FirstOrDefault(type => type.Name == nameof(ModHelperData));

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
        else if (mod.MelonAssembly.Assembly.TryGetEmbeddedResource(ModHelperDataJson, out var jsonStream))
        {
            using (jsonStream)
            using (var reader = new StreamReader(jsonStream, Encoding.UTF8))
            {
                ReadValuesFromJson(reader.ReadToEnd());
            }
        }
        else if (mod.MelonAssembly.Assembly.TryGetEmbeddedResource(ModHelperDataTxt, out var txtStream))
        {
            using (txtStream)
            using (var reader = new StreamReader(txtStream, Encoding.UTF8))
            {
                ReadValuesFromString(reader.ReadToEnd());
            }
        }

        // ReSharper disable once ConstantNullCoalescingCondition
        var iconPath = Icon ?? DefaultIcon;
        var assemblyPath = "." + iconPath.Replace("/", ".");
        var resource = mod.MelonAssembly.Assembly
            .GetManifestResourceNames()
            .FirstOrDefault(s => s.EndsWith(assemblyPath));
        if (resource != null)
        {
            IconBytes = mod.MelonAssembly.Assembly.GetManifestResourceStream(resource)?.GetByteArray();
        }
        else
        {
            HasNoIcon = true;
        }
    }


    public static void Load(MelonMod mod)
    {
        var modHelperData = new ModHelperData(mod);
        Cache[mod] = modHelperData;
        Active.Add(modHelperData);
    }


    public bool ModInstalledLocally(out ModHelperData modHelperData)
    {
        var result = All.FirstOrDefault(
            data =>
                data.RepoName?.Equals(RepoName) == true &&
                data.RepoOwner?.Equals(RepoOwner) == true &&
                data.SubPath == SubPath ||
                data.DllName != null && data.DllName == DllName && RepoName == null && RepoOwner == null
        );
        modHelperData = result!;
        return result != null;
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

    public void SetVersion(string version)
    {
        Version = version;
    }


    public static void LoadAll()
    {
        foreach (var melonMod in ModHelper.Melons)
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

                    var dataFile = Path.Combine(ModHelper.DataDirectory, file.Name.Replace(".dll", ".json"));
                    if (!File.Exists(dataFile))
                    {
                        continue;
                    }

                    try
                    {
                        using var fs = new StreamReader(dataFile);
                        var contents = await fs.ReadToEndAsync();
                        var data = new ModHelperData();
                        data.ReadValuesFromJson(contents);

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
                            ModHelper.Msg($"{data.DisplayName} is already enabled?");
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