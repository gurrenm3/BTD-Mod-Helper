using Assets.Scripts.Simulation.Bloons;
using Assets.Scripts.Simulation.Display;
using Assets.Scripts.Unity.Bridge;
using Assets.Scripts.Unity.Display;
using Assets.Scripts.Unity.UI_New.InGame;

namespace BTD_Mod_Helper.Extensions
{
    public static partial class BloonExt
    {
        /// <summary>
        /// Get the DisplayNode for this bloon
        /// </summary>
        /// <returns></returns>
        public static DisplayNode GetDisplayNode(this Bloon bloon)
        {
            return bloon.Node;
        }

        /// <summary>
        /// Get the UnityDisplayNode for this bloon. Is apart of DisplayNode. Needed to modify sprites
        /// </summary>
        /// <param name="bloon"></param>
        /// <returns></returns>
        public static UnityDisplayNode GetUnityDisplayNode(this Bloon bloon)
        {
            return bloon.GetDisplayNode()?.graphic;
        }



        /// <summary>
        /// Get the BloonToSimulation for this specific Bloon
        /// </summary>
        public static BloonToSimulation GetBloonToSim(this Bloon bloon)
        {
            return InGame.instance.GetUnityToSimulation().GetAllBloons().FirstOrDefault(b => b.id == bloon.Id);
        }
    }
}
