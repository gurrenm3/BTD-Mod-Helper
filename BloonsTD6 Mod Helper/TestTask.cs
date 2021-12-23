using System;
using System.Collections;
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


        public override IEnumerator Coroutine()
        {
            MelonLogger.Msg("Hey it's a thing woah");
            foreach (var modelTower in Game.instance.model.GetTowersWithBaseId(TowerType.IceMonkey))
            {
                modelTower.towerSet = "Magic";
                yield return null;
            }
            
            MelonLogger.Msg($"Wow it actually got through it? {Game.instance.model.towers.Count}");
        }
    }
}