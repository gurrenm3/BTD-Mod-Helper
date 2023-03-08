using Il2CppAssets.Scripts.Models;
using Il2CppAssets.Scripts.Simulation.Bloons;
namespace BTD_Mod_Helper.Patches.Bloons;

[HarmonyPatch(typeof(Bloon), nameof(Bloon.Initialise))]
internal class Bloon_Initialize
{

    [HarmonyPrefix]
    internal static bool Prefix(Bloon __instance, Model modelToUse)
    {
        return true;
    }

    [HarmonyPostfix]
    internal static void Postfix(Bloon __instance, Model modelToUse)
    {
        // removed from update 28.0
        //SessionData.Instance.bloonTracker.TrackBloon(__instance);
        // Creating new BloonToSimulation will automatically start Tracking BloonSim via the Constructor
        //__instance.CreateBloonToSim();

        ModHelper.PerformHook(mod => mod.OnBloonCreated(__instance));
        ModHelper.PerformHook(mod => mod.OnBloonModelUpdated(__instance, modelToUse));
    }
}