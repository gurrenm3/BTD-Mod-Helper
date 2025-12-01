using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Xml.Linq;
using BTD_Mod_Helper.Api.Internal;
using Il2CppAssets.Scripts.Data;
using Il2CppAssets.Scripts.Data.Legends;
using Il2CppAssets.Scripts.Models;
using Il2CppAssets.Scripts.Unity;
using Il2CppInterop.Runtime;
using Il2CppNinjaKiwi.Common;
using Il2CppSystem;
using Il2CppSystem.Linq;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using UnityEngine.AddressableAssets;
using UnityEngine.ResourceManagement.ResourceLocations;
using Exception = System.Exception;

namespace BTD_Mod_Helper.Api.Helpers;

/// <summary>
/// Class for handily exporting elements of the GameModel to json files
/// </summary>
public static class GameModelExporter
{
    private const string BaseGitIgnore =
        """
        *
        !*/
        !.gitignore
        !README.md
        """;

    private static string gitIgnore;

    private static void AddFileToGitIgnore(string path) => gitIgnore += $"\n!{path}";

    private static void AddFolderToGitIgnore(string path, string ext = ".json") => gitIgnore += $"\n!{path}/**/*{ext}";

    internal static bool clean;
    internal static bool consistent;


    /// <summary>
    /// Exports every bit of GameModel and GameData info of note to the local folder
    /// </summary>
    internal static void ExportAll()
    {
        ModHelper.Msg("Exporting game data, this will take a little bit...");

        gitIgnore = BaseGitIgnore;

        var gameModel = Game.instance.model;
        var gameData = GameData.Instance;

        Export("Towers", gameModel.towers, tower => $"{tower.baseId}/{tower.name}");
        Export("Upgrades", gameModel.upgrades, upgrade => $"{upgrade.name.Replace("/", "")}");
        Export("Bloons", gameModel.bloons, bloon => $"{bloon.baseId}/{bloon.name}");
        Export("Powers", gameModel.powers, power => $"{power.name}");
        Export("Mods", gameData.mods, mod => $"{mod.name}");
        Export("Rounds", gameData.roundSets, r => r.rounds, (r, _, i) => $"{r.name}/{i + 1}");
        Export("Maps", gameData.mapSet.Maps.items, map => $"{map.difficulty}/{map.id}");
        Export("Buffs", gameModel.buffIndicatorModels, buff => $"{buff.name}");
        Export("Skins", gameData.skinsData.SkinList.items, skin => $"{skin.baseTowerName}/{skin.name}");
        Export("Knowledge", gameModel.allKnowledge, knowledge => $"{knowledge.category}/{knowledge.name}");
        Export("GeraldoItems", gameModel.geraldoItemModels, item => $"{item.name}");
        Export("BloonOverlays", gameData.bloonOverlays.overlayTypes, (key, _) => $"{key}");
        Export("Artifacts", gameData.artifactsData.artifactDatas, (id, _) => $"{id}");
        Export("TrophyStoreItems", gameData.trophyStoreItems.storeItems, i => $"{i.storeFilter}/{i.subFilter}/{i.Id}");
        Export("Achievements", gameData.achievements.achievements, achievement => $"{achievement.name}");
        Export("IncomeSets", gameData.incomeSets, incomeSet => $"{incomeSet.name}");
        Export("Bosses", gameData.bosses.BossList.items, boss => $"{boss.id}");

        Export(LocalizationManager.Instance.textTable, "textTable.json");
        Export(gameModel.paragonDegreeDataModel, "paragonDegreeData.json");
        Export(CreateResourceMap(), "resources.json");
        Export(gameData.rogueData, "rogueData.json", o =>
        {
            o.Remove(nameof(RogueData.mapTemplates));
            o.Remove(nameof(RogueData.RogueSaveData));
            o.Remove(nameof(RogueData.LegendsData));
            o.Value<JObject>(nameof(RogueData.featsData))!.Remove(nameof(RogueData.featsData.activeFeats));
        });

#if DEBUG
        FileIOHelper.SaveFile(".gitignore", gitIgnore);
#endif
    }

    private static JObject CreateResourceMap()
    {
        var resourcesJson = new JObject();
        var resourceLocationMap = Addressables.ResourceLocators.First();
        foreach (var key in resourceLocationMap.Keys.ToArray())
        {
            if (!Guid.TryParse(key.ToString(), out _) ||
                !resourceLocationMap.Locate(key, Il2CppType.Of<Object>(), out var locations)) continue;

            var list = locations
                .Cast<Il2CppSystem.Collections.Generic.IEnumerable<IResourceLocation>>()
                .ToArray()
                .Select(location => location.InternalId)
                .Distinct()
                .Where(s => s != key.ToString())
                .ToArray();

            if (list.Length == 0) continue;

            resourcesJson[key.ToString()] = list[0];
        }
        return resourcesJson;
    }

    internal static void Export<T>(string folder, IEnumerable<T> items, System.Func<T, string> getPath)
        where T : Object =>
        Export<T, T>(folder, items, o => [o], (o, _, _) => getPath(o));

    internal static void Export<T>(string folder, Il2CppSystem.Collections.Generic.List<T> items,
        System.Func<T, string> getPath) where T : Object =>
        Export<T, T>(folder, items.ToArray(), o => [o], (o, _, _) => getPath(o));

    internal static void Export<T, R>(string folder, IEnumerable<T> items,
        System.Func<T, R> subItems, System.Func<T, R, string> getPath) where R : Object =>
        Export<T, R>(folder, items, o => [subItems(o)], (t, o, _) => getPath(t, o));

    internal static void Export<T, R>(string folder, SerializableDictionary<T, R> items,
        System.Func<T, R, string> getPath) where R : Object =>
        Export(folder, items.keys.ToArray(), key => items[key], getPath);

    internal static void Export<T, R>(string folder, Il2CppSystem.Collections.Generic.Dictionary<T, R> items,
        System.Func<T, R, string> getPath) where R : Object =>
        Export(folder, items.Keys(), key => items[key], getPath);

    internal static void Export<T, R>(string folder, IEnumerable<T> items,
        System.Func<T, IEnumerable<R>> subItems, System.Func<T, R, int, string> getPath) where R : Object
    {
        AddFolderToGitIgnore(folder);

        if (clean) Directory.Delete(Path.Combine(FileIOHelper.sandboxRoot, folder), true);

        var total = 0;
        var success = 0;
        var start = DateTimeOffset.Now;
        var seconds = 1;

        foreach (var item in items)
        {
            var i = 0;
            foreach (var subItem in subItems(item))
            {
                if (TryExport(subItem, Path.Combine(folder, getPath(item, subItem, i) + ".json"))) success++;
                total++;
                i++;
            }

            if (DateTimeOffset.Now - start > TimeSpan.FromSeconds(seconds))
            {
                ModHelper.Log($"{total} {folder} processed...");
                seconds++;
            }
        }

        ModHelper.Log($"Exported {success}/{total} {folder} to {Path.Combine(FileIOHelper.sandboxRoot, folder)}");
    }

    internal static void Export(JObject jobject, string path)
    {
        AddFileToGitIgnore(path);

        try
        {
            FileIOHelper.SaveFile(path, jobject.ToString(Formatting.Indented));
            ModHelper.Log("Exported " + Path.Combine(FileIOHelper.sandboxRoot, path));
        }
        catch (Exception e)
        {
            ModHelper.Error("Failed to save " + Path.Combine(FileIOHelper.sandboxRoot, path));
            ModHelper.Warning(e);
        }
    }

    /// <summary>
    /// Tries to save a specific object and logs doing so
    /// </summary>
    public static void Export(Object data, string path)
    {
        AddFileToGitIgnore(path);

        try
        {
            FileIOHelper.SaveObject(path, data);
            ModHelper.Log("Exported " + Path.Combine(FileIOHelper.sandboxRoot, path));
        }
        catch (Exception e)
        {
            ModHelper.Error("Failed to save " + Path.Combine(FileIOHelper.sandboxRoot, path));
            ModHelper.Warning(e);
        }
    }

    internal static void Export(Object data, string path, System.Action<JObject> modify)
    {
        AddFileToGitIgnore(path);

        try
        {
            var jobject = JObject.FromObject(data, Il2CppJsonConvert.Serializer);
            modify?.Invoke(jobject);

            FileIOHelper.SaveFile(path, jobject.ToString(Formatting.Indented));
            ModHelper.Log("Exported " + Path.Combine(FileIOHelper.sandboxRoot, path));
        }
        catch (Exception e)
        {
            ModHelper.Error("Failed to save " + Path.Combine(FileIOHelper.sandboxRoot, path));
            ModHelper.Warning(e);
        }
    }

    /// <summary>
    /// Exports a Model to the path, returning whether it was successful. Does not log anything.
    /// </summary>
    /// <returns></returns>
    public static bool TryExport(Object data, string path)
    {
        try
        {
            if (consistent && data.Is(out Model model))
            {
                ModelSerializer.MakeConsistent(model);
            }

            FileIOHelper.SaveObject(path, data);
            return true;
        }
        catch (Exception)
        {
            return false;
        }
    }
}