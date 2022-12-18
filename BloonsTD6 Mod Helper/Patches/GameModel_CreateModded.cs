using System.Linq;
using Il2CppAssets.Scripts.Data.Knowledge;
using Il2CppAssets.Scripts.Models;
using Il2CppAssets.Scripts.Models.Bloons;
using Il2CppAssets.Scripts.Models.Towers;
using Il2CppAssets.Scripts.Models.Towers.Mods;
using Il2CppAssets.Scripts.Unity;
using Il2CppAssets.Scripts.Unity.UI_New.InGame;
using BTD_Mod_Helper.Api;
using BTD_Mod_Helper.Api.Bloons;
using BTD_Mod_Helper.Api.Scenarios;
using BTD_Mod_Helper.Api.Towers;
using BTD_Mod_Helper.UI.Modded;
using Il2CppSystem;
using Il2CppSystem.Collections.Generic;
using Il2CppInterop.Runtime;
using Exception = System.Exception;

namespace BTD_Mod_Helper.Patches;

[HarmonyPatch(typeof(GameModel), nameof(GameModel.CreateModded), typeof(GameModel), typeof(List<ModModel>),
    typeof(List<RelicKnowledgeItemBase>))]
internal class GameModel_CreateModded
{
    [HarmonyPrefix]
    internal static bool Prefix()
    {
        Game.instance.model.searchCache ??= new Dictionary<Type, Dictionary<string, Model>>
        {
            [Il2CppType.Of<TowerModel>()] = new(),
            [Il2CppType.Of<BloonModel>()] = new()
        };

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
        if (!string.IsNullOrEmpty(RoundSetChanger.RoundSetOverride))
        {
            result.bloonSet = RoundSetChanger.RoundSetOverride;
        }

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

        if (ModRoundSet.Cache.TryGetValue(result.bloonSet, out var modRoundSet))
        {
            modRoundSet.ModifyGameModel(result);
        }
        
        if (ModGameMode.Cache.TryGetValue(InGameData.CurrentGame.selectedMode, out var modGameMode))
        {
            modGameMode.ModifyGameModel(result);
        }

        ModHelper.PerformHook(mod => mod.OnNewGameModel(result, mods));
        ModHelper.PerformHook(mod => mod.OnNewGameModel(result));
    }
}