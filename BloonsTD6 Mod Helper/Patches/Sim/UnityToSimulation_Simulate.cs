using Il2CppAssets.Scripts.Unity.Bridge;
namespace BTD_Mod_Helper.Patches.Sim;

[HarmonyPatch(typeof(UnityToSimulation), nameof(UnityToSimulation.Simulate))]
internal class UnityToSimulation_Simulate
{
    public static UnityToSimulation Current { get; private set; }

    [HarmonyPrefix]
    internal static void Prefix(UnityToSimulation __instance)
    {
        Current = __instance;
    }

    [HarmonyPostfix]
    internal static void Postfix(UnityToSimulation __instance)
    {
        Current = __instance;
    }
}