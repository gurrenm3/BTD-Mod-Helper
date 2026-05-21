using Il2CppAssets.Scripts.Models;
using Il2CppAssets.Scripts.SimulationTests;
using Il2CppAssets.Scripts.Unity;

namespace BTD_Mod_Helper.Patches.Sim;

[HarmonyPatch(typeof(SimulationTestUtilities), nameof(SimulationTestUtilities.CreateGameModel))]
internal static class SimulationTestUtilities_CreateGameModel
{
    [HarmonyPrefix]
    internal static void Prefix(ref GameModel baseModel)
    {
        baseModel = Game.instance.model.Duplicate();
    }
}