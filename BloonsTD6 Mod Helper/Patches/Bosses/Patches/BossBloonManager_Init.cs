using System;
using System.Collections.Generic;
using System.Linq;
using BTD_Mod_Helper.Api.Bloons.Bosses;
using Il2CppAssets.Scripts.Data;
using Il2CppAssets.Scripts.Data.Boss;
using Il2CppAssets.Scripts.Data.Music;
using Il2CppAssets.Scripts.Simulation.Track;
using Il2CppAssets.Scripts.Unity.UI_New.InGame;
using Il2CppAssets.Scripts.Utils;
using UnityEngine;
namespace BTD_Mod_Helper.Patches.Bosses.Patches;

[HarmonyPatch(typeof(BossBloonManager), nameof(BossBloonManager.Init))]
internal class BossBloonManager_Init
{
    [HarmonyPostfix]
    private static void Postfix(BossBloonManager __instance)
    {
        if (ModBoss.Cache.TryGetValue((int) InGameData.CurrentGame.bossData.bossBloon, out var boss))
        {
            Il2CppAssets.Scripts.Data.Boss.Bosses bosses =
                UnityEngine.Resources.FindObjectsOfTypeAll<Il2CppAssets.Scripts.Data.Boss.Bosses>()[0];
            List<BossData> bossList = bosses.BossList.items.ToList();

            if (!bossList.Exists(x => x.id == boss.BossType))
            {
                bossList.Add(
                    new BossData
                    {
                        id = boss.BossType,
                        normalBtn = boss.IconReference,
                        ambientMapFXPrefab = boss.AmbientMapFXReference,
                        musicTrack = boss.BossMusic != null ? GetBossMusicItem(boss) : bossList[0].musicTrack,
                        normalDefeatPortrait = boss.DefeatedPortraitReference,
                        normalPortrait = boss.AlivePortraitReference,
                        normalHudIcon = boss.HudIconReference,
                        trackFXPrefab = boss.TrackFXReference,
                    });
                bosses.BossList.items = bossList.ToArray();
            }

            if (__instance.bossTimes.Length < boss.highestTier)
            {
                __instance.bossTimes = Enumerable.Repeat(new KonFuze(), boss.highestTier).ToArray();
            }
        }
    }

    private static MusicItem GetBossMusicItem(ModBoss boss)
    {
        var existingMusicItem = GameData.Instance.audioJukeBox.musicTrackData.Find(new Func<MusicItem, bool>(x => x.id == boss.BossMusic.GetName()));
        if (existingMusicItem is null && !existingMusicItem)
        {
            var musicItem = ScriptableObject.CreateInstance<MusicItem>();

            musicItem.name = boss.BossMusic.GetName();
            musicItem.freeTrack = true;
            musicItem.Clip = boss.BossMusic;
            musicItem.hideFlags = 0;
            musicItem.id = boss.BossMusic.GetName();
            musicItem.locKey = boss.BossMusic.GetName();
            musicItem._Clip_k__BackingField = boss.BossMusic;
            musicItem.unavailableInJukeBox = true;

            GameData.Instance.audioJukeBox.musicTrackData.Add(musicItem);

            return musicItem;
        }
        return existingMusicItem;
    }
}
