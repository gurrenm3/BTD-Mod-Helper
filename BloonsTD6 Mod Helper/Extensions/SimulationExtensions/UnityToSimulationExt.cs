using BTD_Mod_Helper.Patches.Sim;
using Il2CppAssets.Scripts.Unity.Bridge;
using Il2CppAssets.Scripts.Unity.UI_New.InGame;
namespace BTD_Mod_Helper.Extensions;

/// <summary>
/// Extensions for <see cref="UnityToSimulation"/>
/// </summary>
public static class UnityToSimulationExt
{
    extension(UnityToSimulation)
    {
        /// <summary>
        /// The Simulation instance currently in the process of Simulating
        /// </summary>
        public static UnityToSimulation Current => UnityToSimulation_Simulate.Current ?? InGame.instance?.bridge;
    }

}