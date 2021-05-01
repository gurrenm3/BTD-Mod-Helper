using Assets.Scripts.Simulation.Bloons;
using Assets.Scripts.Simulation.Display;
using Assets.Scripts.Unity.Bridge;
using Assets.Scripts.Unity.Display;
using Assets.Scripts.Unity.UI_New.InGame;
using System.Linq;

namespace BTD_Mod_Helper.Extensions
{
    public static partial class BloonToSimulationExt
    {
        /// <summary>
        /// Get the DisplayNode for this bloon
        /// </summary>
        /// <returns></returns>
        public static DisplayNode GetDisplayNode(this BloonToSimulation bloonToSim)
        {
            return bloonToSim.GetSimBloon().GetDisplayNode();
        }

        /// <summary>
        /// Get the UnityDisplayNode for this bloon. Is apart of DisplayNode. Needed to modify sprites
        /// </summary>
        /// <returns></returns>
        public static UnityDisplayNode GetUnityDisplayNode(this BloonToSimulation bloonToSim)
        {
            return bloonToSim.GetSimBloon().GetUnityDisplayNode();
        }

        /// <summary>
        /// Get the Simulation Bloon for this specific BloonToSimulation. Returns object of class Bloon
        /// </summary>
        public static Bloon GetSimBloon(this BloonToSimulation bloonToSim)
        {
            return SessionData.bloonTracker.GetBloon(bloonToSim.id);
        }
    }
}