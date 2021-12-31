using System.Linq;
using Assets.Scripts.Models;
using Assets.Scripts.Models.Bloons;
using Assets.Scripts.Models.Towers;
using Assets.Scripts.Models.Towers.Mods;
using Assets.Scripts.Unity;
using BTD_Mod_Helper.Api;
using BTD_Mod_Helper.Api.Bloons;
using BTD_Mod_Helper.Api.Towers;
using HarmonyLib;
using Il2CppSystem;
using Il2CppSystem.Collections.Generic;
using MelonLoader;
using UnhollowerRuntimeLib;
using Exception = System.Exception;

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
                    [Il2CppType.Of<TowerModel>()] = new Dictionary<string, Model>(),
                    [Il2CppType.Of<BloonModel>()] = new Dictionary<string, Model>()
                };
            }

            var towerCache = Game.instance.model.searchCache[Il2CppType.Of<TowerModel>()];
            foreach (var (key, value) in ModTowerHelper.TowerCache)
            {
                if (!towerCache.ContainsKey(key))
                {
                    towerCache[key] = value;
                }
            }
            
            var bloonCache = Game.instance.model.searchCache[Il2CppType.Of<BloonModel>()];
            foreach (var (key, value) in ModBloon.BloonModelCache)
            {
                if (!bloonCache.ContainsKey(key))
                {
                    bloonCache[key] = value;
                }
            }


            return true;
        }


        [HarmonyPostfix]
        internal static void Postfix(GameModel result, List<ModModel> mods)
        {
            ModHelper.PerformHook(mod => mod.OnNewGameModel(result, mods));
            ModHelper.PerformHook(mod => mod.OnNewGameModel(result));

            foreach (var modVanillaContent in ModContent.GetContent<ModVanillaContent>()
                         .Where(content => !content.AffectBaseGameModel && content.ShouldApply))
            {
                foreach (var affectedTower in modVanillaContent.GetAffectedModels(result))
                {
                    try
                    {
                        modVanillaContent.Apply(affectedTower);
                        modVanillaContent.Apply(affectedTower, result);
                    }
                    catch (Exception e)
                    {
                        ModHelper.Error($"Failed to apply {modVanillaContent.Name}");
                        ModHelper.Error(e);
                    }
                }
            }
        }
    }
}