using BTD_Mod_Helper.Api.Bloons.Bosses;
using BTD_Mod_Helper.Api.Data;
using Il2CppAssets.Scripts.Simulation;
using Il2CppAssets.Scripts.Unity.UI_New.InGame;
namespace BTD_Mod_Helper.Patches.Sim;

[HarmonyPatch(typeof(Simulation), nameof(Simulation.RoundEnd))]
internal static class Simulation_RoundEnd
{
    [HarmonyPostfix]
    private static void Postfix()
    {
        ModHelper.PerformHook(mod => mod.OnRoundEnd());
        SessionData.Instance.LeakedBloons.Clear();
        SessionData.Instance.DestroyedBloons.Clear();
    }
}