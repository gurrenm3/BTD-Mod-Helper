using System;
using BTD_Mod_Helper.Api;
using BTD_Mod_Helper.Api.Bloons.Bosses;
using BTD_Mod_Helper.Api.Display;
using Il2CppAssets.Scripts.Unity;
using Il2CppAssets.Scripts.Unity.Bridge;
using Il2CppAssets.Scripts.Unity.UI_New.InGame;
using UnityEngine;
using Object = UnityEngine.Object;
namespace BTD_Mod_Helper.Patches.Resources;

[HarmonyPatch(typeof(InGame), nameof(InGame.CheckGameType))]
internal static class InGame_CheckGameType
{
    [HarmonyPrefix]
    private static void Prefix(InGame __instance)
    {
        if (__instance.GameType == GameType.BossBloon && ModBoss.Cache.TryGetValue((int) InGameData.CurrentGame.bossData.bossBloon, out var boss))
        {
            if (AmbientMapFXDisplay.Cache.TryGetValue(boss.AmbientMapFXReference.guidRef ?? "", out var ambientMapFXDisplay))
            {
                var assetBundle = ModContent.GetBundle(ambientMapFXDisplay.mod, ambientMapFXDisplay.AssetBundleName);
                if (ambientMapFXDisplay.LoadAsync)
                {
                    assetBundle.LoadAssetAsync(ambientMapFXDisplay.PrefabName).add_completed(new Action<AsyncOperation>(
                        operation =>
                        {
                            var request = operation.Cast<AssetBundleRequest>();
                            var gameObject = Object.Instantiate(request.GetResult().Cast<GameObject>(), Game.instance.GetMapLoader().currentMap.transform, false);
                            gameObject.transform.SetPositionAndRotation(Vector3.zero,
                                Quaternion.identity);
                        }));
                }
                else
                {
                    var gameObject = Object.Instantiate(assetBundle.LoadAsset(ambientMapFXDisplay.PrefabName).Cast<GameObject>(),
                        Game.instance.GetMapLoader().GetCurrentMap().transform, false);
                    gameObject.transform.SetPositionAndRotation(__instance.bridge.GetBossSpawnLocation(),
                        Quaternion.identity);
                }
            }
            if (TrackFXDisplay.Cache.TryGetValue(boss.TrackFXReference.guidRef ?? "", out var trackFXDisplay))
            {
                ModHelper.Msg("trackFXDisplay: " + trackFXDisplay.PrefabName);
                var assetBundle = ModContent.GetBundle(trackFXDisplay.mod, trackFXDisplay.AssetBundleName);
                if (trackFXDisplay.LoadAsync)
                {
                    assetBundle.LoadAssetAsync(trackFXDisplay.PrefabName).add_completed(new Action<AsyncOperation>(
                        operation =>
                        {
                            var request = operation.Cast<AssetBundleRequest>();
                            var gameObject = Object.Instantiate(request.GetResult().Cast<GameObject>(), Game.instance.GetMapLoader().currentMap.transform, false);
                            gameObject.transform.SetPositionAndRotation(InGame.instance.bridge.GetBossSpawnLocation(),
                                Quaternion.identity);
                        }));
                }
                else
                {
                    var gameObject = Object.Instantiate(assetBundle.LoadAsset(trackFXDisplay.PrefabName).Cast<GameObject>(), Game.instance.GetMapLoader().GetCurrentMap().transform, false);
                    gameObject.transform.SetPositionAndRotation(__instance.bridge.GetBossSpawnLocation(),
                        Quaternion.identity);
                }
            }
        }

    }
}