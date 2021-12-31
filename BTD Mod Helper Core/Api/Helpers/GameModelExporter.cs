using System;
using Assets.Scripts.Models;
using Assets.Scripts.Unity;
using Assets.Scripts.Utils;

namespace BTD_Mod_Helper.Api.Helpers
{
    /// <summary>
    /// Class for handily exporting elements of the GameModel to json files
    /// </summary>
    public static class GameModelExporter
    {
        /// <summary>
        /// Exports every bit of GameModel and GameData info of note to the local folder
        /// </summary>
        public static void ExportAll()
        {
            ModHelper.Log("Exporting Towers to local files");
            foreach (var tower in Game.instance.model.towers)
            {
                Export(tower, $"Towers/{tower.baseId}/{tower.name}.json");
            }

            ModHelper.Log("Exporting Upgrades to local files");
            foreach (var upgrade in Game.instance.model.upgrades)
            {
                Export(upgrade, $"Upgrades/{upgrade.name.Replace("/", "")}.json");
            }

            ModHelper.Log("Exporting Bloons to local files");
            foreach (var bloon in Game.instance.model.bloons)
            {
                Export(bloon, $"Bloons/{bloon.baseId}/{bloon.name}.json");
            }


            ModHelper.Log("Exporting Monkey Knowledge to local files");
            foreach (var knowledgeSet in Game.instance.model.knowledgeSets)
            {
                foreach (var knowledgeTierModel in knowledgeSet.tiers)
                {
                    foreach (var knowledgeLevelModel in knowledgeTierModel.levels)
                    {
                        foreach (var knowledgeModel in knowledgeLevelModel.items)
                        {
                            Export(knowledgeModel,
                                $"Knowledge/{knowledgeSet.name}/{knowledgeLevelModel.name}/{knowledgeModel.name}.json");
                        }
                    }
                }
            }


            ModHelper.Log("Exporting Powers to local files");
            foreach (var model in Game.instance.model.powers)
            {
                Export(model, $"Powers/{model.name}.json");
            }

            ModHelper.Log("Exporting Mods to local files");
            foreach (var model in Game.instance.model.mods)
            {
                Export(model, $"Mods/{model.name}.json");
            }

            ModHelper.Log("Exporting Skins to local files");
            foreach (var model in Game.instance.model.skins)
            {
                Export(model, $"Skins/{model.towerBaseId}/{model.name}.json");
            }

            ModHelper.Log("Exporting Rounds to local files");
            foreach (var roundSet in Game.instance.model.roundSets)
            {
                for (var i = 0; i < roundSet.rounds.Count; i++)
                {
                    Export(roundSet.rounds[i], $"Rounds/{roundSet.name}/{i + 1}.json");
                }
            }
        }

        /// <summary>
        /// Tries to save a specific Model and logs doing so
        /// </summary>
        public static void Export(Model model, string path)
        {
            try
            {
                FileIOUtil.SaveObject(path, model);
                ModHelper.Log("Saving " + FileIOUtil.sandboxRoot + path);
            }
            catch (Exception)
            {
                ModHelper.Error("Failed to save " + FileIOUtil.sandboxRoot + path);
            }
        }

    }
}