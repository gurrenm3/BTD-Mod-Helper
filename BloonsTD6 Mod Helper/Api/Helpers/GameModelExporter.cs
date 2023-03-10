using System.IO;
using System.Linq;
using Il2CppAssets.Scripts.Data;
using Il2CppAssets.Scripts.Unity;
using Il2CppSystem;
using Il2CppSystem.Linq;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using UnityEngine.AddressableAssets;
using UnityEngine.AddressableAssets.ResourceLocators;
using UnityEngine.ResourceManagement.ResourceLocations;
using Array = System.Array;
using Exception = System.Exception;
namespace BTD_Mod_Helper.Api.Helpers;

/// <summary>
/// Class for handily exporting elements of the GameModel to json files
/// </summary>
public static class GameModelExporter
{
    /// <summary>
    /// Exports every bit of GameModel and GameData info of note to the local folder
    /// </summary>
    internal static void ExportAll()
    {
        var total = 0;
        var success = 0;
        ModHelper.Msg("Exporting game data, this will take a couple seconds...");
        foreach (var tower in Game.instance.model.towers)
        {
            if (TryExport(tower, $"Towers/{tower.baseId}/{tower.name}.json")) success++;
            total++;

            if (total % 500 == 0)
            {
                ModHelper.Msg($"{total} TowerModels in...");
            }
        }
        ModHelper.Log($"Exported {success}/{total} TowerModels to {Path.Combine(FileIOHelper.sandboxRoot, "Towers")}");


        total = success = 0;
        foreach (var upgrade in Game.instance.model.upgrades)
        {
            if (TryExport(upgrade, $"Upgrades/{upgrade.name.Replace("/", "")}.json")) success++;
            total++;
        }
        ModHelper.Log(
            $"Exported {success}/{total} UpgradeModels to {Path.Combine(FileIOHelper.sandboxRoot, "Upgrades")}");

        total = success = 0;
        foreach (var bloon in Game.instance.model.bloons)
        {
            if (TryExport(bloon, $"Bloons/{bloon.baseId}/{bloon.name}.json")) success++;
            total++;
        }
        ModHelper.Log($"Exported {success}/{total} BloonModels to {Path.Combine(FileIOHelper.sandboxRoot, "Bloons")}");


        total = success = 0;
        foreach (var model in Game.instance.model.powers)
        {
            if (TryExport(model, $"Powers/{model.name}.json")) success++;
            total++;
        }
        ModHelper.Log($"Exported {success}/{total} PowerModels to {Path.Combine(FileIOHelper.sandboxRoot, "Powers")}");

        total = success = 0;
        foreach (var model in Game.instance.model.mods)
        {
            if (TryExport(model, $"Mods/{model.name}.json")) success++;
            total++;
        }
        ModHelper.Log($"Exported {success}/{total} ModModels to {Path.Combine(FileIOHelper.sandboxRoot, "Mods")}");

        total = success = 0;
        foreach (var roundSet in Game.instance.model.roundSets)
        {
            for (var i = 0; i < roundSet.rounds.Count; i++)
            {
                if (TryExport(roundSet.rounds[i], $"Rounds/{roundSet.name}/{i + 1}.json")) success++;
                total++;
            }
        }
        ModHelper.Log($"Exported {success}/{total} RoundModels to {Path.Combine(FileIOHelper.sandboxRoot, "Rounds")}");

        total = success = 0;
        foreach (var mapSetMap in GameData.Instance.mapSet.maps)
        {
            if (TryExport(mapSetMap, $"Maps/{mapSetMap.difficulty.ToString()}/{mapSetMap.id}.json")) success++;
            total++;
        }
        ModHelper.Log($"Exported {success}/{total} MapDetails to {Path.Combine(FileIOHelper.sandboxRoot, "Maps")}");

        total = success = 0;
        foreach (var indicatorModel in Game.instance.model.buffIndicatorModels)
        {
            if (TryExport(indicatorModel, $"Buffs/{indicatorModel.name}.json")) success++;
            total++;
        }
        ModHelper.Log(
            $"Exported {success}/{total} BuffIndicatorModels to {Path.Combine(FileIOHelper.sandboxRoot, "Buffs")}");

        total = success = 0;
        GameData.Instance.skinsData.SkinList.items.ForEach(data =>
        {
            var jobject = new JObject
            {
                ["name"] = data.name,
                ["skinName"] = data.skinName,
                ["description"] = data.description,
                ["baseTowerName"] = data.baseTowerName,
                ["mmCost"] = data.mmCost,
                ["icon"] = data.icon.GUID,
                ["iconSquare"] = data.iconSquare.GUID,
                ["isDefaultTowerSkin"] = data.isDefaultTowerSkin,
                ["textMaterialId"] = data.textMaterialId,
                ["StorePortraitsContainer"] = new JArray(
                    data.StorePortraitsContainer?.items?.ToList()?.Select(portrait =>
                        new JObject
                        {
                            ["asset"] = portrait.asset?.GUID,
                            ["levelText"] = portrait.levelTxt
                        }) ??
                    Array.Empty<JObject>()
                )
            };

            try
            {

                Directory.CreateDirectory(Path.Combine(FileIOHelper.sandboxRoot, "Skins", data.baseTowerName));
                var path = $"Skins/{data.baseTowerName}/{data.name}.json";
                File.WriteAllText(Path.Combine(FileIOHelper.sandboxRoot, path), jobject.ToString(Formatting.Indented));
                success++;
            }
            catch (Exception)
            {
                // ignored
            }
            total++;
        });
        ModHelper.Log(
            $"Exported {success}/{total} SkinDatas to {Path.Combine(FileIOHelper.sandboxRoot, "Skins")}");
        
        total = success = 0;
        foreach (var knowledgeModel in Game.instance.model.allKnowledge)
        {
            if (TryExport(knowledgeModel, $"Knowledge/{knowledgeModel.name}.json")) success++;
            total++;
        }
        ModHelper.Log(
            $"Exported {success}/{total} KnowledeModels to {Path.Combine(FileIOHelper.sandboxRoot, "Knowledge")}");
        
        
        var resourcesJson = new JObject();
        var resourceLocationMap = Addressables.ResourceLocators.First().Cast<ResourceLocationMap>();

        foreach (var (o, locations) in resourceLocationMap.Locations)
        {
            var key = o.ToString();
            
            if (!Guid.TryParse(key, out _)) continue;

            var list = locations
                .Cast<Il2CppReferenceArray<IResourceLocation>>()
                .Select(location => location.InternalId)
                .Distinct()
                .Where(s => s != key)
                .ToArray();

            if (list.Length == 0) continue;

            resourcesJson[key] = list.Length > 1 ? JArray.FromObject(list) : list[0];
        }

        var resourcesPath = Path.Combine(FileIOHelper.sandboxRoot, "resources.json");
        File.WriteAllText(resourcesPath, resourcesJson.ToString(Formatting.Indented));
        ModHelper.Log($"Exported resources to {resourcesPath}");
    }

    /// <summary>
    /// Exports a Model to the path, returning whether it was successful. Does not log anything.
    /// </summary>
    /// <returns></returns>
    public static bool TryExport(Object data, string path)
    {
        try
        {
            FileIOHelper.SaveObject(path, data);
            return true;
        }
        catch (Exception)
        {
            return false;
        }
    }

    /// <summary>
    /// Tries to save a specific Model and logs doing so
    /// </summary>
    public static void Export(Object data, string path)
    {
        try
        {
            FileIOHelper.SaveObject(path, data);
            ModHelper.Log("Saving " + Path.Combine(FileIOHelper.sandboxRoot, path));
        }
        catch (Exception e)
        {
            ModHelper.Error("Failed to save " + Path.Combine(FileIOHelper.sandboxRoot, path));
            ModHelper.Warning(e);
        }
    }
}