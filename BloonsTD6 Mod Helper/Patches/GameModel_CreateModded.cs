using System.Linq;
using BTD_Mod_Helper.Api;
using BTD_Mod_Helper.Api.Bloons;
using BTD_Mod_Helper.Api.Scenarios;
using BTD_Mod_Helper.Api.Towers;
using BTD_Mod_Helper.UI.Modded;
using Il2CppAssets.Scripts.Data;
using Il2CppAssets.Scripts.Data.Knowledge;
using Il2CppAssets.Scripts.Models;
using Il2CppAssets.Scripts.Models.Bloons;
using Il2CppAssets.Scripts.Models.Map;
using Il2CppAssets.Scripts.Models.Rounds;
using Il2CppAssets.Scripts.Models.Towers;
using Il2CppAssets.Scripts.Models.Towers.Upgrades;
using Il2CppAssets.Scripts.Unity;
using Il2CppAssets.Scripts.Unity.UI_New.InGame;
using Il2CppInterop.Runtime;
using Il2CppSystem;
using Il2CppSystem.Collections.Generic;
using Exception = System.Exception;
namespace BTD_Mod_Helper.Patches;

[HarmonyPatch(typeof(GameModel), nameof(GameModel.CreateModded), typeof(List<string>), typeof(ModModel),
    typeof(ActiveRelicKnowledge), typeof(MapModel), typeof(RoundSetModel))]
internal static class GameModel_CreateModded2
{
    [HarmonyPostfix]
    internal static void Postfix(MapModel map, GameModel __result)
    {
        ModHelper.PerformHook(mod => mod.OnNewGameModel(__result, map));
    }
}

[HarmonyPatch(typeof(GameModel), nameof(GameModel.CreateModded), typeof(GameModel), typeof(List<ModModel>),
    typeof(List<RelicKnowledgeItemBase>))]
internal static class GameModel_CreateModded
{
    [HarmonyPrefix]
    internal static bool Prefix()
    {
        Game.instance.model.searchCache ??= new Dictionary<Type, Dictionary<string, Model>>
        {
            [Il2CppType.Of<TowerModel>()] = new(),
            [Il2CppType.Of<BloonModel>()] = new(),
            [Il2CppType.Of<UpgradeModel>()] = new()
        };

        var towerCache = Game.instance.model.searchCache[Il2CppType.Of<TowerModel>()];
        foreach (var (key, value) in ModTowerHelper.TowerCache)
        {
            if (!towerCache.ContainsKey(key))
            {
                towerCache[key] = value;
            }
        }

        var upgradeCache = Game.instance.model.searchCache[Il2CppType.Of<BloonModel>()];
        foreach (var (key, value) in ModUpgrade.UpgradeModelCache)
        {
            if (!upgradeCache.ContainsKey(key))
            {
                upgradeCache[key] = value;
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
            result.SetRoundSet(GameData.Instance.RoundSetByName(RoundSetChanger.RoundSetOverride));
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

        if (ModRoundSet.Cache.TryGetValue(result.roundSet.name, out var modRoundSet))
        {
            modRoundSet.ModifyGameModel(result);
        }

        if (ModGameMode.Cache.TryGetValue(InGameData.CurrentGame.selectedMode, out var modGameMode))
        {
            modGameMode.ModifyGameModel(result);
        }

        var gameModes = mods.ToList().AsReadOnly();
        foreach (var towerModel in result.towers)
        {
            if (!ModTowerHelper.ModTowerCache.TryGetValue(towerModel.name, out var modTower)) continue;

            modTower.ModifyTowerModelForMatch(towerModel, gameModes);

            var modUpgrades = modTower.GetUpgradesForTiers(towerModel.tiers);

            foreach (var modUpgrade in modUpgrades)
            {
                modUpgrade.ApplyUpgradeForMatch(towerModel, gameModes);
            }
        }

        foreach (var bloonModel in result.bloons)
        {
            if (!ModBloon.Cache.TryGetValue(bloonModel.name, out var modBloon)) continue;

            modBloon.ModifyBloonModelForMatch(bloonModel, gameModes);
        }

        ModHelper.PerformHook(mod => mod.OnNewGameModel(result, gameModes));
#pragma warning disable CS0618
        ModHelper.PerformHook(mod => mod.OnNewGameModel(result, mods));
#pragma warning restore CS0618
        ModHelper.PerformHook(mod => mod.OnNewGameModel(result));
    }
}