using Assets.Scripts.Simulation.Bloons;
using Assets.Scripts.Simulation.Display;
using Assets.Scripts.Unity.Bridge;
using Assets.Scripts.Unity.Display;
using Assets.Scripts.Unity.UI_New.InGame;
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
        /// (Cross-Game compatible) Creates a new BloonToSimulation based off of this Bloon and stores it for possible later use. It will automatically destroyed when this Bloon is destroyed
        /// </summary>
        /// <param name="bloon"></param>
        /// <returns></returns>
        public static BloonToSimulation CreateBloonToSim(this Bloon bloon)
        {
            var currentPos = new Vector3();
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