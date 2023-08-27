using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using BTD_Mod_Helper.Api.Helpers;
using Il2CppAssets.Scripts.Models;
using Il2CppAssets.Scripts.Models.Towers;
using Il2CppAssets.Scripts.Models.Towers.Upgrades;
using MelonLoader.Utils;
using NAudio.Wave;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
namespace BTD_Mod_Helper.Api.Internal.JsonTowers;

internal static class JsonTowers
{
    private const string Tower = "Assets.Scripts.Models.Towers.TowerModel, Assembly-CSharp";
    private const string Upgrade = "Assets.Scripts.Models.Towers.Upgrades.UpgradeModel, Assembly-CSharp";
    private const string CustomDisplay = "BTD_Mod_Helper.Api.Internal.JsonTowers.ModJsonDisplay, BloonsTD6 Mod Helper";

    private static readonly JsonSerializer Serializer = JsonSerializer.Create(ModelConverter.Settings);

    public static string TowersFolder => Path.Combine(MelonEnvironment.GameRootDirectory, "Towers");

    private static readonly Dictionary<string, JObject> Towers = new();
    private static readonly Dictionary<string, JObject> Upgrades = new();
    private static readonly Dictionary<string, JObject> Displays = new();

    public static Task LoadTask { get; private set; }

    public static void LoadAllAsync()
    {
        LoadTask = Task.Run(async () => await TraverseFiles(TowersFolder));
    }

    private static async Task TraverseFiles(string path)
    {
        var dir = new DirectoryInfo(path);

        foreach (var file in dir.EnumerateFiles())
        {
            if (file.Name.StartsWith("workspace")) continue;

            try
            {
                switch (file.Extension)
                {
                    case ".json":
                        await LoadJson(file);
                        break;
                    case ".png":
                    case ".jpg":
                        await LoadTexture(file);
                        break;
                    case ".wav":
                        await LoadAudio(file);
                        break;
                }
            }
            catch (Exception e)
            {
                ModHelper.Warning("Failed to process file " + file.FullName);
                ModHelper.Warning(e);
            }
        }

        foreach (var directory in dir.EnumerateDirectories())
        {
            await TraverseFiles(directory.FullName);
        }
    }

    private static async Task LoadJson(FileInfo file)
    {
        var text = await File.ReadAllTextAsync(file.FullName);
        var jObject = JObject.Parse(text);

        if (!jObject.ContainsKey("$type") || !jObject.ContainsKey("name")) return;

        var type = jObject.Value<string>("$type")!;
        var name = jObject.Value<string>("name")!;

        switch (type)
        {
            case Tower:
                Towers[name] = jObject;
                break;
            case Upgrade:
                Upgrades[name] = jObject;
                break;
            case CustomDisplay:
                Displays[name] = jObject;
                break;
        }
    }

    private static async Task LoadTexture(FileInfo fileInfo)
    {
        var name = fileInfo.NameWithoutExtension();
        ResourceHandler.Resources[name] = await File.ReadAllBytesAsync(fileInfo.FullName);
    }

    private static async Task LoadAudio(FileInfo fileInfo)
    {
        var name = fileInfo.NameWithoutExtension();
        await using var reader = new WaveFileReader(fileInfo.FullName);

        ResourceHandler.CreateAudioClip(reader, name);
    }

    public static void ProcessAll(GameModel gameModel)
    {
        var towerIds = gameModel.towers.Select(tower => tower.name).ToHashSet();
        var upgradeIds = gameModel.upgrades.Select(upgrade => upgrade.name).ToHashSet();

        var vanillaTowers = Towers.Values.Where(o => towerIds.Contains(o.Value<string>("name")!));
        var vanillaUpgrades = Upgrades.Values.Where(o => upgradeIds.Contains(o.Value<string>("name")!));
        var moddedTowers = Towers.Values.Where(o => !towerIds.Contains(o.Value<string>("name")!));
        var moddedUpgrades = Upgrades.Values.Where(o => !upgradeIds.Contains(o.Value<string>("name")!));
        
        foreach (var (key, display) in Displays)
        {
            ModHelper.Main.AddContent(display.ToObject<ModJsonDisplay>(Serializer));
        }
        
        var jsonUpgrades = new List<ModJsonUpgrade>();
        foreach (var moddedUpgrade in moddedUpgrades)
        {
            if (ProcessModdedUpgrade(moddedUpgrade, out var jsonUpgrade))
            {
                jsonUpgrades.Add(jsonUpgrade);
            }
        }

        var jsonUpgradesByTower = jsonUpgrades
            .GroupBy(upgrade => upgrade.TowerId)
            .ToDictionary(upgrades => upgrades.Key);

        foreach (var moddedTower in moddedTowers)
        {
            if (!ProcessModdedTower(moddedTower, out var jsonTower)) continue;

            if (jsonUpgradesByTower.TryGetValue(jsonTower.Id, out var upgrades))
            {
                foreach (var jsonUpgrade in upgrades)
                {
                    jsonUpgrade.JsonTower = jsonTower;
                    jsonTower.JsonUpgrades.Add(jsonUpgrade);
                    ModHelper.Main.AddContent(jsonUpgrade);
                }
            }

            ModHelper.Main.AddContent(jsonTower);
        }
    }

    public static bool ProcessModdedTower(JObject moddedTower, out ModJsonTower customTower)
    {
        customTower = null;
        try
        {
            if (moddedTower.GetValue("$custom") is not JObject custom) return false;

            customTower = custom.ToObject<ModJsonTower>(Serializer)!;
            customTower.towerModel = ModelSerializer.DeserializeModel<TowerModel>(moddedTower);
            customTower.jObject = moddedTower;

            return customTower.towerModel != null;
        }
        catch (Exception e)
        {
            ModHelper.Warning($"Failed processing custom JSON tower {moddedTower.Value<string>("name")}");
            ModHelper.Warning(e);
            return false;
        }
    }

    public static bool ProcessModdedUpgrade(JObject moddedUpgrade, out ModJsonUpgrade customUpgrade)
    {
        customUpgrade = null;
        try
        {
            if (moddedUpgrade.GetValue("$custom") is not JObject custom) return false;

            customUpgrade = custom.ToObject<ModJsonUpgrade>(Serializer)!;
            customUpgrade.UpgradeModel = ModelSerializer.DeserializeModel<UpgradeModel>(moddedUpgrade);

            return customUpgrade.UpgradeModel != null;
        }
        catch (Exception e)
        {
            ModHelper.Warning($"Failed processing custom JSON upgrade {moddedUpgrade.Value<string>("name")}");
            ModHelper.Warning(e);
            return false;
        }
    }
}