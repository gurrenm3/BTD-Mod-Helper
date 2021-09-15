using Assets.Scripts.Simulation.Bloons;
using Assets.Scripts.Simulation.Display;
using Assets.Scripts.Unity.Bridge;
using Assets.Scripts.Unity.Display;
using Assets.Scripts.Unity.UI_New.InGame;
using System.Linq;
using System;

namespace BTD_Mod_Helper.Extensions
{
    public static partial class BloonToSimulationExt
    {
        /// <summary>
        /// (Cross-Game compatible) Return the DisplayNode for this bloon
        /// </summary>
        /// <returns></returns>
        public static DisplayNode GetDisplayNode(this BloonToSimulation bloonToSim)
        {
            return bloonToSim.GetBloon().GetDisplayNode();
        }

        /// <summary>
        /// (Cross-Game compatible) Return the UnityDisplayNode for this bloon. Is apart of DisplayNode. Needed to modify sprites
        /// </summary>
        /// <returns></returns>
        public static UnityDisplayNode GetUnityDisplayNode(this BloonToSimulation bloonToSim)
        {
            return bloonToSim.GetBloon().GetUnityDisplayNode();
        }

        /// <summary>
        /// This is Obsolete, use GetBloon instead. (Cross-Game compatible) Return the Simulation Bloon for this specific BloonToSimulation. Returns object of class Bloon
        /// </summary>
        [Obsolete]
        public static Bloon GetSimBloon(this BloonToSimulation bloonToSim)
        {
            return SessionData.Instance.bloonTracker.GetBloon(bloonToSim.GetId());
        }

        /// <summary>
        /// (Cross-Game compatible) Return the Simulation Bloon for this specific BloonToSimulation. Returns object of class Bloon
        /// </summary>
        public static Bloon GetBloon(this BloonToSimulation bloonToSim)
        {
            return SessionData.Instance.bloonTracker.GetBloon(bloonToSim.GetId());
        }

        /// <summary>
        /// (Cross-Game compatible) Return the Id of this BloonToSimulation
        /// </summary>
        /// <param name="bloonToSim"></param>
        /// <returns></returns>
        public static int GetId(this BloonToSimulation bloonToSim)
        {
#if BloonsTD6
            return bloonToSim.id;
#elif BloonsAT
            return (int)bloonToSim.id;
#endif
        }

        /// <summary>
        /// (Cross-Game compatible) Return the total distance this BloonToSim has travelled
        /// </summary>
        /// <param name="bloonToSim"></param>
        /// <returns></returns>
        public static float GetDistanceTravelled(this BloonToSimulation bloonToSim)
        {
            var distance = bloonToSim.GetBloon().distanceTraveled;
#if BloonsAT
            bloonToSim.distanceTravelled = distance;
#endif
            return distance;
        }
    }
}