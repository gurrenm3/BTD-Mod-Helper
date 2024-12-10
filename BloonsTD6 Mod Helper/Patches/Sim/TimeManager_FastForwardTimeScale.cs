using System;
using BTD_Mod_Helper.Api.Helpers;
using Il2CppAssets.Scripts;
using Il2CppAssets.Scripts.Simulation;
using Il2CppAssets.Scripts.Utils;
namespace BTD_Mod_Helper.Patches.Sim;

[HarmonyPatch(typeof(TimeManager), nameof(TimeManager.FastForwardTimeScale), MethodType.Getter)]
internal static class TimeManager_FastForwardTimeScale
{
    [HarmonyPrefix]
    internal static bool Prefix(ref double __result)
    {
        __result = TimeHelper.OverrideFastForwardTimeScale;
        return false;
    }
}