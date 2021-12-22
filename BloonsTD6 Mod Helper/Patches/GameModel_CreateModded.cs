using System.Linq;
using Assets.Scripts.Models;
using Assets.Scripts.Models.Towers;
using Assets.Scripts.Models.Towers.Mods;
using Assets.Scripts.Unity;
using BTD_Mod_Helper.Api;
using BTD_Mod_Helper.Api.Towers;
using HarmonyLib;
using Il2CppSystem;
using Il2CppSystem.Collections.Generic;
using UnhollowerRuntimeLib;

namespace BTD_Mod_Helper.Patches
{
    [HarmonyPatch(typeof(GameModel), nameof(GameModel.CreateModded), typeof(GameModel), typeof(List<ModModel>))]
    internal class GameModel_CreateModded
    {
        [HarmonyPrefix]
        internal static bool Prefix()
        {
            if (Game.instance.model.searchCache == null)
            {
                Game.instance.model.searchCache = new Dictionary<Type, Dictionary<string, Model>>
                {
                    [Il2CppType.Of<TowerModel>()] = new Dictionary<string, Model>()
                };
            }

            var dictionary = Game.instance.model.searchCache[Il2CppType.Of<TowerModel>()];
            foreach (var (key, value) in ModTowerHelper.TowerCache)
            {
                if (!dictionary.ContainsKey(key))
                {
                    dictionary[key] = value;
                }
            }


            return true;
        }


        [HarmonyPostfix]
        internal static void Postfix(GameModel result, List<ModModel> mods)
        {
            MelonMain.PerformHook(mod => mod.OnNewGameModel(result, mods));
            MelonMain.PerformHook(mod => mod.OnNewGameModel(result));

            foreach (var modVanillaContent in ModContent.GetContent<ModVanillaContent>()
                         .Where(content => !content.AffectBaseGameModel))
            {
                foreach (var affectedTower in modVanillaContent.GetAffectedTowers(result))
                {
                    modVanillaContent.Apply(affectedTower);
                }
            }
        }
    }
}