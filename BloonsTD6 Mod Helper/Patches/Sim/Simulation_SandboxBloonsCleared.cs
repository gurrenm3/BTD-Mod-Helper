using BTD_Mod_Helper.Api.Bloons;
using BTD_Mod_Helper.UI.Modded;
using Il2CppAssets.Scripts.Simulation;
namespace BTD_Mod_Helper.Patches.Sim;

[HarmonyPatch(typeof(Simulation), nameof(Simulation.SandboxBloonsCleared))]
internal class Simulation_SandboxBloonsCleared
{
    [HarmonyPostfix]
    internal static void Postfix()
    {
        if (ModBoss.Cache.Count > 0)
        {
            ModBossUI.Init();
        }
    }
}