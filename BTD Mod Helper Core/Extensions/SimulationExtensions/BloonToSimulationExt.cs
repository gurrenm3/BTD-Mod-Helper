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
    }
}