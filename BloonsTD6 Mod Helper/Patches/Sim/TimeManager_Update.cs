using BTD_Mod_Helper.Api.Helpers;
using Il2CppAssets.Scripts.Unity.UI_New.InGame;
using Il2CppAssets.Scripts.Utils;
using UnityEngine;
namespace BTD_Mod_Helper.Patches.Sim;

/// <summary>
/// Sadly the FastForwardTimeScale call seems to have been inlined for 45.0
/// </summary>
[HarmonyPatch(typeof(TimeManager), nameof(TimeManager.Update))]
internal static class TimeManager_Update
{
    [HarmonyPostfix]
    internal static void Postfix()
    {
        if (InGame.Bridge == null || InGame.instance == null) return;

        var paused = InGame.instance.IsCoop
            ? TimeManager.coopPaused
            : !InGame.instance._reviewMapMode && TimeManager.gamePaused;
        
        var baseTime = paused ? 0 : 1;
        var fastForwardScale = TimeManager.FastForwardActive && !TimeManager.inBetweenRounds
            ? TimeHelper.OverrideFastForwardTimeScale
            : 1;
        
        var time = baseTime * fastForwardScale * TimeManager.replayTimeScaleMultiplier;

        Time.timeScale = Mathf.Clamp((float) time, 0, 100);
    }
}