using System;
using System.IO;
using System.Linq;

using Assets.Scripts.Data;
using Assets.Scripts.Unity;
using Assets.Scripts.Utils;

using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace BTD_Mod_Helper.Api.Helpers;

/// <summary>
/// Class for handily exporting elements of the GameModel to json files
/// </summary>
public static class GameModelExporter {
    /// <summary>
    /// Exports every bit of GameModel and GameData info of note to the local folder
    /// </summary>
    internal static void ExportAll() {
        ModHelper.Log("Exporting Towers to local files");
        foreach (var tower in Game.instance.model.towers) {
            Export(tower, $"Towers/{tower.baseId}/{tower.name}.json");
        }

        ModHelper.Log("Exporting Upgrades to local files");
        foreach (var upgrade in Game.instance.model.upgrades) {
            Export(upgrade, $"Upgrades/{upgrade.name.Replace("/", "")}.json");
        }

        ModHelper.Log("Exporting Bloons to local files");
        foreach (var bloon in Game.instance.model.bloons) {
            Export(bloon, $"Bloons/{bloon.baseId}/{bloon.name}.json");
        }


        ModHelper.Log("Exporting Powers to local files");
        foreach (var model in Game.instance.model.powers) {
            Export(model, $"Powers/{model.name}.json");
        }

        ModHelper.Log("Exporting Mods to local files");
        foreach (var model in Game.instance.model.mods) {
            Export(model, $"Mods/{model.name}.json");
        }

        ModHelper.Log("Exporting Rounds to local files");
        foreach (var roundSet in Game.instance.model.roundSets) {
            for (var i = 0; i < roundSet.rounds.Count; i++) {
                Export(roundSet.rounds[i], $"Rounds/{roundSet.name}/{i + 1}.json");
            }
        }

        ModHelper.Log("Exporting maps to local files");
        foreach (var mapSetMap in GameData.Instance.mapSet.maps) {
            Export(mapSetMap, $"Maps/{mapSetMap.difficulty}/{mapSetMap.id}.json");
        }

        ModHelper.Log("Exporting buff indicators to local files");
        foreach (var indicatorModel in Game.instance.model.buffIndicatorModels) {
            Export(indicatorModel, $"Buffs/{indicatorModel.name}.json");
        }

        ModHelper.Log("Exporting skins to local files");
        GameData.Instance.skinsData.SkinList.items.ForEach(data => {
            var jobject = new JObject {
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
                        new JObject {
                            ["asset"] = portrait.asset?.GUID,
                            ["levelText"] = portrait.levelTxt
                        }) ??
                    Array.Empty<JObject>()
                )
            };

            Directory.CreateDirectory(Path.Combine(FileIOUtil.sandboxRoot, "Skins", data.baseTowerName));
            var path = $"Skins/{data.baseTowerName}/{data.name}.json";
            File.WriteAllText(Path.Combine(FileIOUtil.sandboxRoot, path), jobject.ToString(Formatting.Indented));
            ModHelper.Log("Saving " + FileIOUtil.sandboxRoot + path);
        });
    }

    /// <summary>
    /// Tries to save a specific Model and logs doing so
    /// </summary>
    public static void Export(Il2CppSystem.Object data, string path) {
        try {
            FileIOUtil.SaveObject(path, data);
            ModHelper.Log("Saving " + Path.Combine(FileIOUtil.sandboxRoot, path));
        } catch (Exception) {
            ModHelper.Error("Failed to save " + Path.Combine(FileIOUtil.sandboxRoot, path));
        }
    }
}