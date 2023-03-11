using Il2CppAssets.Scripts.Simulation;
namespace BTD_Mod_Helper.Patches.Sim;

[HarmonyPatch(typeof(Simulation), nameof(Simulation.RoundEnd))]
internal class Simulation_RoundEnd
{
    [HarmonyPostfix]
    internal static void Postfix()
    {
        ModHelper.PerformHook(mod => mod.OnRoundEnd());
        SessionData.Instance.LeakedBloons.Clear();
        SessionData.Instance.DestroyedBloons.Clear();
    }
}