using Il2CppAssets.Scripts.Unity.Bridge;
namespace BTD_Mod_Helper.Patches.Sim;

[HarmonyPatch(typeof(UnityToSimulation), nameof(UnityToSimulation.Lose))]
internal class UnityToSimulation_Lose
{
    [HarmonyPostfix]
    internal static void Postfix()
    {
        ModHelper.PerformHook(mod => mod.OnDefeat());
    }
}