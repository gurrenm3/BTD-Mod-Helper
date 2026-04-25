using BTD_Mod_Helper.Api;
using Il2CppAssets.Scripts.Simulation;
namespace BTD_Mod_Helper.Patches.Sim;

[HarmonyPatch(typeof(Simulation), nameof(Simulation.Simulate))]
internal class Simulation_Simulate
{
    public static Simulation Current { get; private set; }

    public static void Prefix(Simulation __instance)
    {
        Current = __instance;
    }

    public static void Postfix(Simulation __instance)
    {
        ModContent.TickAll(__instance);
        Current = null;
    }
}