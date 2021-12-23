using System;
using System.Linq;
using Assets.Scripts.Models.Towers;
using Assets.Scripts.Unity;
using BTD_Mod_Helper.Api;
using MelonLoader;

namespace BTD_Mod_Helper
{
    public class TestTask : ModLoadTask
    {
        public override string DisplayName => "Testy testy time";

        public override void Perform()
        {
            MelonLogger.Msg("Doing the thing!");
            if (Game.instance.model?.towers != null)
            {
                foreach (var modelTower in Game.instance.model.GetTowersWithBaseId(TowerType.IceMonkey))
                {
                    modelTower.towerSet = "Magic";
                }
                MelonLogger.Msg($"Wow it actually got through it? {Game.instance.model.towers.Count}");
            }
            else
            {
                MelonLogger.Msg("model is null :(");
            }

        }
    }
}