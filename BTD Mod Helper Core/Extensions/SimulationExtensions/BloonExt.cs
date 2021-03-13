using Assets.Scripts.Simulation.Bloons;
using Assets.Scripts.Unity.Bridge;
using Assets.Scripts.Unity.UI_New.InGame;

namespace BTD_Mod_Helper.Extensions
{
    public static partial class BloonExt
    {
        /// <summary>
        /// Get the BloonToSimulation for this specific Bloon
        /// </summary>
        public static BloonToSimulation GetBloonToSim(this Bloon bloon)
        {
            return InGame.instance.GetUnityToSimulation().GetAllBloons().FirstOrDefault(b => b.id == bloon.Id);
        }
    }
}
