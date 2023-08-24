using System;
using System.Linq;
using BTD_Mod_Helper.Api.Bloons;
using BTD_Mod_Helper.Api.Bloons.Bosses;
using Il2CppAssets.Scripts.Data.Boss;
using Il2CppAssets.Scripts.Simulation.Track;
using Il2CppAssets.Scripts.Unity.UI_New.GameOver;
using Il2CppAssets.Scripts.Unity.UI_New.InGame;
using Il2CppNinjaKiwi.Common;
using Object = Il2CppSystem.Object;

namespace BTD_Mod_Helper.Patches.Spawners;

//todo: once everything is done separate this into multiple files

[HarmonyPatch(typeof(Bosses), nameof(Bosses.GetBossData), typeof(BossType))]
internal static class Bosses_GetBossData
{
    [HarmonyPrefix]
    private static void Postfix(Bosses __instance, BossType bossType)
    {
        //todo: do this somewhere else, preferably in BossBloonManager.Init
        if (__instance.BossList.items.All(x => x.id != bossType))
        {
            var boss = ModBoss.BossesByInt[(int) bossType];
            __instance.BossList.items = __instance.BossList.items.AddTo(new BossData()
            {
                id = bossType,
                normalBtn = boss.IconReference,
                ambientMapFXPrefab = __instance.BossList.items[0].ambientMapFXPrefab,
                musicTrack = __instance.BossList.items[0].musicTrack,
                normalDefeatPortrait = boss.DefeatedPortraitReference,
                normalPortrait = boss.AlivePortraitReference,
                normalHudIcon = boss.HudIconReference,
                trackFXPrefab = __instance.BossList.items[0].trackFXPrefab,
            });
        }
    }
}

//todo: get this working
[HarmonyPatch(typeof(InGameMusicFactory), nameof(InGameMusicFactory.ChangeMusicOnBossPresent))]
internal static class InGameMusicFactory_ChangeMusicOnBossPresent
{
    [HarmonyPostfix]
    private static void Prefix(InGameMusicFactory __instance)
    {
        if(InGameData.CurrentGame.gameEventId == ModBoss.EventId && ModBoss.BossesByInt.TryGetValue((int) InGameData.CurrentGame.bossData.bossBloon, out var boss))
        {
            //__instance.AddTrackToTrackList(boss.BossMusic.GetName());
            __instance.FadeCurrentTrack();
            __instance.audioFactory.FadeMusic();
            __instance.audioFactory.PlayMusic(boss.BossMusic);
            //return true;
        }
        //return true;
    }
}


[HarmonyPatch(typeof(Enum), nameof(Enum.ToString), typeof(string))]
[HarmonyPatch(typeof(Enum), nameof(Enum.ToString), new Type[] { })]
internal static class Enum_ToString
{
    [HarmonyPrefix]
    private static bool Prefix(Enum __instance, ref string __result)
    {
        if (__instance is BossType bossType && ModBoss.BossesByInt.TryGetValue((int) bossType, out var boss))
        {
            __result = boss.DisplayName;
            return false;
        }
        return true;
    }
}

[HarmonyPatch(typeof(LocalizationManager), nameof(LocalizationManager.Format), typeof(string), typeof(Il2CppReferenceArray<Object>))]
internal static class LocalizationManager_Format
{
    [HarmonyPrefix]
    private static void Prefix(Il2CppReferenceArray<Object> args)
    {
        if(args is null || args.Length == 0)
            return;
        if(int.TryParse(args[0].ToString(), out var num) && ModBoss.BossesByInt.TryGetValue(num, out var boss))
        {
            args[0] = boss.DisplayName;
        }
    }
}

[HarmonyPatch(typeof(LocalizationManager), nameof(LocalizationManager.Format), typeof(string),
    typeof(Object[]))]
internal static class LocalizationManager_Format2
{
    [HarmonyPrefix]
    private static void Prefix(Object[] args)
    {
        if (args is null || args.Length == 0)
            return;
        if (int.TryParse(args[0].ToString(), out var num) && ModBoss.BossesByInt.TryGetValue(num, out var boss))
        {
            args[0] = boss.DisplayName;
        }
    }
}

[HarmonyPatch(typeof(BossData), nameof(BossData.LocsKey), MethodType.Getter)]
internal static class BossData_LocsKey_Getter
{
    [HarmonyPrefix]
    static bool Prefix(BossData __instance, ref string __result)
    {
        if (ModBoss.BossesByInt.TryGetValue((int) __instance.id, out var boss))
        {
            __result = boss.DisplayName;
            return false;
        }
        return true;
    }
}

[HarmonyPatch(typeof(BossBloonManager), nameof(BossBloonManager.SpawnBoss))]
internal static class BossBloonManager_SpawnBoss
{
    [HarmonyPostfix]
    private static void Postfix(BossBloonManager __instance)
    {
        if (ModBossTier.Cache.TryGetValue(__instance.currentBoss.bloonModel.name, out var modBossTier))
        {
            var boss = modBossTier.Boss;
            boss.CurrentTier = boss.tiers.First(x => x.Round == InGame.Bridge.GetCurrentRound() + 1);
            boss.OnSpawn(__instance.currentBoss);
        }
    }
}

[HarmonyPatch(typeof(BossVictoryScreen), nameof(BossVictoryScreen.PlayAgainClicked))]
internal static class BossBloonManager_SpawnBos
{
    [HarmonyPrefix]
    private static bool Prefix(BossVictoryScreen __instance)
    {
        if (InGameData.CurrentGame.gameEventId == ModBoss.EventId)
        {
            InGame.instance.bridge.Restart();
            return false;
        }
        return true;
    }
}