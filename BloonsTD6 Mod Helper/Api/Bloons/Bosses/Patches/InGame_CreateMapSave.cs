using System.Linq;
using Il2CppAssets.Scripts.Models.Bloons;
using Il2CppAssets.Scripts.Models.Profile;
using Il2CppAssets.Scripts.Models.ServerEvents;
using Il2CppAssets.Scripts.Unity;
using Il2CppAssets.Scripts.Unity.Bridge;
using Il2CppAssets.Scripts.Unity.Player;
using Il2CppAssets.Scripts.Unity.UI_New.InGame;
using Il2CppInterop.Runtime;
using Il2CppNinjaKiwi.Players.Files;
using Il2CppSystem;
namespace BTD_Mod_Helper.Api.Bloons.Bosses.Patches;

[HarmonyPatch(typeof(InGame), nameof(InGame.CreateMapSave))]
internal static class InGame_CreateMapSave
{
    internal static bool patch = false;
    [HarmonyPrefix]
    private static void Prefix() => patch = true;

    [HarmonyPostfix]
    private static void Postfix() => patch = false;
}

[HarmonyPatch(typeof(UnityToSimulation), nameof(UnityToSimulation.GetBossBloonTier))]
internal static class UnityToSimulation_GetBossBloonTier
{
    [HarmonyPrefix]
    private static void Prefix(ref Nullable<int> __result)
    {
        if(InGame_CreateMapSave.patch)
        {
            __result = new Nullable<int>(5);
        }
    }
}

[HarmonyPatch(typeof(Il2CppAssets.Scripts.Unity.UI_New.UI), nameof(Il2CppAssets.Scripts.Unity.UI_New.UI.LoadGame))]
internal static class UI_LoadGame
{
    [HarmonyPostfix]
    private static void Postfix(MapSaveDataModel mapSaveData)
    {
        if (InGameData.CurrentGame?.gameEventId != ModBoss.EventId || mapSaveData is null)
        {
            return;
        }

        if (ModBoss.Cache.TryGetValue((int)InGameData.CurrentGame.bossData.bossBloon, out var boss))
        {
            var bloon = mapSaveData.bloons.FirstOrDefault(bloonSaveDataModel => boss.tiers.Exists(modBossTier => modBossTier.bloonModel.id == bloonSaveDataModel.modelId));
            if (bloon is null)
            {
                return;
            }
            boss.CurrentTier = boss.tiers.First(modBossTier => modBossTier.bloonModel.id == bloon.modelId);
        }
    }
}