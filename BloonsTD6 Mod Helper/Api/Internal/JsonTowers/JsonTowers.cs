using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Il2CppAssets.Scripts.Models;
using Il2CppAssets.Scripts.Models.Towers;
using Il2CppAssets.Scripts.Models.Towers.Upgrades;
using MelonLoader.Utils;
using NAudio.Wave;
using Newtonsoft.Json;
namespace BTD_Mod_Helper.Api.Internal.JsonTowers;

internal static class JsonTowers
{
    public static string TowersFolder => Path.Combine(MelonEnvironment.GameRootDirectory, "Towers");

    private static readonly List<TowerModel> VanillaTowers = new();
    private static readonly List<UpgradeModel> VanillaUpgrades = new();
    private static readonly List<ModJsonTower> ModdedTowers = new();
    private static readonly List<ModJsonUpgrade> ModdedUpgrades = new();
    private static readonly List<ModJsonDisplay> Displays = new();

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
        var obj = JsonConvert.DeserializeObject(text, ModelConverter.Settings);
        
        switch (obj)
        {
            case TowerModel towerModel:
                VanillaTowers.Add(towerModel);
                break;
            case UpgradeModel upgradeModel:
                VanillaUpgrades.Add(upgradeModel);
                break;
            case ModJsonTower modJsonTower:
                ModdedTowers.Add(modJsonTower);
                break;
            case ModJsonUpgrade modJsonUpgrade:
                ModdedUpgrades.Add(modJsonUpgrade);
                break;
            case ModJsonDisplay modJsonDisplay:
                Displays.Add(modJsonDisplay);
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
        foreach (var display in Displays)
        {
            ModHelper.Main.AddContent(display);
        }

        var upgradesByTower = ModdedUpgrades
            .GroupBy(upgrade => upgrade.TowerId)
            .ToDictionary(upgrades => upgrades.Key);

        foreach (var jsonTower in ModdedTowers)
        {
            if (upgradesByTower.TryGetValue(jsonTower.Id, out var upgrades))
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
}