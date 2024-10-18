using BTD_Mod_Helper.Api.Helpers;
using Il2CppAssets.Scripts.Utils;
namespace BTD_Mod_Helper.Patches.Sim;

/*[HarmonyPatch(typeof(TimeManager), nameof(TimeManager.MaxSimulationStepsPerUpdate), MethodType.Getter)]
internal static class TimeManager_MaxSimulationStepsPerUpdate
{
    [HarmonyPrefix]
    internal static bool Prefix(ref double __result)
    {
        __result = TimeHelper.OverrideMaxSimulationStepsPerUpdate;
        return false;
    }
}*/