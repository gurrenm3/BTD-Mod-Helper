using System;
using Assets.Scripts.Models;
using Assets.Scripts.Unity;
using Assets.Scripts.Utils;
using MelonLoader;

namespace BTD_Mod_Helper.Api.Helpers
{
    /// <summary>
    /// Class for handily exporting elements of the GameModel to json files
    /// </summary>
    public static class GameModelExporter
    {
        public static void ExportAll()
        {
            MelonLogger.Msg("Exporting Towers to local files");
            foreach (var tower in Game.instance.model.towers)
            {
                Export(tower, $"Towers/{tower.baseId}/{tower.name}.json");
            }

            MelonLogger.Msg("Exporting Upgrades to local files");
            foreach (var upgrade in Game.instance.model.upgrades)
            {
                Export(upgrade, $"Upgrades/{upgrade.name.Replace("/", "")}.json");
            }

            MelonLogger.Msg("Exporting Bloons to local files");
            foreach (var bloon in Game.instance.model.bloons)
            {
                Export(bloon, $"Bloons/{bloon.baseId}/{bloon.name}.json");
            }


            MelonLogger.Msg("Exporting Monkey Knowledge to local files");
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


            MelonLogger.Msg("Exporting Powers to local files");
            foreach (var model in Game.instance.model.powers)
            {
                Export(model, $"Powers/{model.name}.json");
            }

            MelonLogger.Msg("Exporting Mods to local files");
            foreach (var model in Game.instance.model.mods)
            {
                Export(model, $"Mods/{model.name}.json");
            }

            MelonLogger.Msg("Exporting Skins to local files");
            foreach (var model in Game.instance.model.skins)
            {
                Export(model, $"Skins/{model.towerBaseId}/{model.name}.json");
            }

            MelonLogger.Msg("Exporting Rounds to local files");
            foreach (var roundSet in Game.instance.model.roundSets)
            {
                for (var i = 0; i < roundSet.rounds.Count; i++)
                {
                    Export(roundSet.rounds[i], $"Rounds/{roundSet.name}/{i + 1}.json");
                }
            }
        }


        public static void Export(Model model, string path)
        {
            try
            {
                FileIOUtil.SaveObject(path, model);
                MelonLogger.Msg("Saving " + FileIOUtil.sandboxRoot + path);
            }
            catch (Exception)
            {
                MelonLogger.Error("Failed to save " + FileIOUtil.sandboxRoot + path);
            }
        }

    }
}