using Assets.Scripts.Simulation.Bloons;
using Assets.Scripts.Unity.Bridge;
using Assets.Scripts.Unity.UI_New.InGame;
using System.Linq;

namespace BTD_Mod_Helper.Extensions
{
    public static partial class BloonToSimulationExt
    {
        /// <summary>
        /// Get the Simulation Bloon for this specific BloonToSimulation. Returns object of class Bloon
        /// </summary>
        public static Bloon GetSimBloon(this BloonToSimulation bloonToSim)
        {
            return InGame.instance.GetAllObjectsOfType<Bloon>().ToList().FirstOrDefault(b => b.Id == bloonToSim.id);
        }
    }
}