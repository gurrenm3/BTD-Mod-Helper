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
            // It seems like this method creates a BloonToSimulation for all bloons everytime it's called, so it might not be necessary
            //return InGame.instance?.GetUnityToSimulation()?.GetAllBloons()?.FirstOrDefault(b => b.id == bloon.Id);

            //
            // This method doesn't need to be this long but it doesn't hurt to have extra checks
            //

            var bloonSim = SessionData.bloonTracker.GetBloonToSim(bloon.Id);
            if (bloonSim is null && bloon.bloonModel is null) // if bloon.bloonModel is null then the bloon hasn't been initialized yet so continuing is pointless
                return null;

            var currentPos = bloon.Position?.ToUnity();
            if (currentPos is null) currentPos = new UnityEngine.Vector3();

            if (bloonSim is null)
                return new BloonToSimulation(InGame.instance.GetUnityToSimulation(), bloon.Id, currentPos.Value, bloon.bloonModel);

            bloonSim.position = currentPos.Value; // Updating position isn't necessary but it helps with accuracy
            return bloonSim;
        }
    }
}