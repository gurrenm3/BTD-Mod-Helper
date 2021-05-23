using Assets.Scripts.Simulation.Bloons;
using Assets.Scripts.Simulation.Display;
using Assets.Scripts.Unity.Bridge;
using Assets.Scripts.Unity.Display;
using Assets.Scripts.Unity.UI_New.InGame;
using Assets.Scripts.Simulation.Track;
using Assets.Scripts.Simulation.Factory;
using UnityEngine;

namespace BTD_Mod_Helper.Extensions
{
    public static partial class BloonExt
    {
        /// <summary>
        /// (Cross-Game compatible) Return the DisplayNode for this bloon
        /// </summary>
        /// <returns></returns>
        public static DisplayNode GetDisplayNode(this Bloon bloon)
        {
            return bloon.Node;
        }

        /// <summary>
        /// (Cross-Game compatible) Return the UnityDisplayNode for this bloon. Is apart of DisplayNode. Needed to modify sprites
        /// </summary>
        /// <param name="bloon"></param>
        /// <returns></returns>
        public static UnityDisplayNode GetUnityDisplayNode(this Bloon bloon)
        {
            return bloon.GetDisplayNode()?.graphic;
        }



        /// <summary>
        /// (Cross-Game compatible) Return the existing BloonToSimulation for this specific Bloon. If it doesn't exist one will be created and stored
        /// </summary>
        public static BloonToSimulation GetBloonToSim(this Bloon bloon)
        {
            // This method doesn't need to be this long but it doesn't hurt to have extra checks

            var bloonSim = SessionData.bloonTracker.GetBloonToSim(bloon.GetId());
            if (bloonSim is null && bloon.bloonModel is null) // if bloon.bloonModel is null then the bloon hasn't been initialized yet so continuing is pointless
                return null;

            var currentPos = bloon.Position?.ToUnity();
            if (currentPos is null) currentPos = new UnityEngine.Vector3();

            if (bloonSim is null)
            {
                return bloon.CreateBloonToSim();
            }

            bloonSim.position = currentPos.Value; // Updating position isn't necessary but it helps with accuracy
            return bloonSim;
        }

        /// <summary>
        /// (Cross-Game compatible) Creates a new BloonToSimulation based off of this Bloon and stores it for possible later use. It will automatically destroyed when this Bloon is destroyed
        /// </summary>
        /// <param name="bloon"></param>
        /// <returns></returns>
        public static BloonToSimulation CreateBloonToSim(this Bloon bloon)
        {
            Vector3 currentPos = new Vector3();
            if(bloon.Position?.ToUnity() != null)
            {
                currentPos = bloon.Position.ToUnity();
            }

            var sim = InGame.instance.GetUnityToSimulation();
#if BloonsTD6
            return new BloonToSimulation(sim, bloon.GetId(), currentPos, bloon.bloonModel);
#elif BloonsAT
            try
            {
                return new BloonToSimulation(sim, bloon.Id, currentPos, bloon.distanceTraveled, bloon.DistanceToEndOfPath, bloon.bloonModel);
            }
            catch (System.Exception) 
            {
                return new BloonToSimulation(sim, bloon.Id, currentPos, 0, 0, bloon.bloonModel);
            }
#endif
        }

        /// <summary>
        /// (Cross-Game compatible) Return the Id of this Bloon
        /// </summary>
        /// <param name="bloon"></param>
        /// <returns></returns>
        public static int GetId(this Bloon bloon)
        {
#if BloonsTD6
            return bloon.Id;
#elif BloonsAT
            return (int)bloon.Id;
#endif
        }

        /// <summary>
        /// (Cross-Game compatible) Return the Factory that creates Bloons
        /// </summary>
        /// <param name="bloon"></param>
        /// <returns></returns>
        public static Factory<Bloon> GetFactory(this Bloon bloon)
        {
            return InGame.instance.GetFactory<Bloon>();
        }
    }
}