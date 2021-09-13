using Assets.Scripts.Models.Bloons;
using Assets.Scripts.Models.Rounds;
using Assets.Scripts.Simulation.Bloons;
using Assets.Scripts.Simulation.Objects;
using Assets.Scripts.Unity;
using Assets.Scripts.Unity.Bridge;
using Assets.Scripts.Unity.UI_New.InGame;
using System.Collections.Generic;
using UnhollowerBaseLib;
using System;

namespace BTD_Mod_Helper.Extensions
{
    public static class BloonModelExt
    {
        public static readonly System.Collections.Generic.IDictionary<string, int> cash = new System.Collections.Generic.Dictionary<string, int>();
        
        /// <summary>
        /// (Cross-Game compatable) Return how much cash this bloon would give if popped by <paramref name="layersPopped"/> number of layers
        /// </summary>
        /// <param name="layersPopped">How many layers of bloons to pop, ignoring layer health. If less than 0, calculates for the entire bloon</param>
        public static int GetTotalCash(this BloonModel bloonModel, int layersPopped = -1)
        {
            if (layersPopped == 0) return 0;

            if (layersPopped >= 0 || !cash.TryGetValue(bloonModel.GetBaseID(), out int bloonCash))
            {
                bloonCash = 1;
                foreach (BloonModel child in bloonModel.GetChildBloonModels(InGame.instance?.GetSimulation()))
                {
                    bloonCash += child.GetTotalCash(layersPopped-1);
                }
                cash.Add(bloonModel.GetBaseID(), bloonCash);
            }

            return bloonCash;
        }
        
        /// <summary>
        /// (Cross-Game compatible) Return the number position of this bloon from the list of all bloons (Game.instance.model.bloons)
        /// </summary>
        public static int GetIndex(this BloonModel bloonModel)
        {
            Il2CppReferenceArray<BloonModel> allBloons = Game.instance?.model?.bloons;
            return allBloons.FindIndex(bloon => bloon.name == bloonModel.name);
        }

        /// <summary>
        /// (Cross-Game compatible) Spawn this BloonModel on the map right now
        /// </summary>
        public static void SpawnBloonModel(this BloonModel bloonModel)
        {
            Assets.Scripts.Simulation.Track.Spawner spawner = InGame.instance?.GetMap()?.spawner;
            if (spawner is null)
                return;

#if BloonsTD6
            Il2CppSystem.Collections.Generic.List<Bloon.ChargedMutator> chargedMutators = new Il2CppSystem.Collections.Generic.List<Bloon.ChargedMutator>();
            Il2CppSystem.Collections.Generic.List<BehaviorMutator> nonChargedMutators = new Il2CppSystem.Collections.Generic.List<BehaviorMutator>();
            spawner.Emit(bloonModel, InGame.instance.GetUnityToSimulation().GetCurrentRound(), 0);
#elif BloonsAT
            spawner.Emit(bloonModel);
#endif
        }

        /// <summary>
        /// (Cross-Game compatible) Create a BloonEmissionModel from this BloonModel
        /// </summary>
        /// <param name="count">Number of bloons in this emission model</param>
        /// <param name="spacing">Space between each bloon in this emission model</param>
        public static Il2CppReferenceArray<BloonEmissionModel> CreateBloonEmissionModel(this BloonModel bloonModel, int count, int spacing)
        {
            return Game.instance?.model?.CreateBloonEmissions(bloonModel, count, spacing);
        }

        /// <summary>
        /// This is Obsolete, use GetAllBloonToSim instead. (Cross-Game compatible) Return all BloonToSimulations with this BloonModel
        /// </summary>
        [Obsolete]
        public static List<BloonToSimulation> GetBloonSims(this BloonModel bloonModel)
        {
            Il2CppSystem.Collections.Generic.List<BloonToSimulation> bloonSims = InGame.instance?.GetUnityToSimulation()?.GetAllBloons();
            if (bloonSims is null || !bloonSims.Any())
                return null;

            List<BloonToSimulation> results = bloonSims.Where(b => b.GetBaseModel().IsEqual(bloonModel)).ToList();
            return results;
        }

        /// <summary>
        /// (Cross-Game compatible) Return all BloonToSimulations with this BloonModel
        /// </summary>
        public static List<BloonToSimulation> GetAllBloonToSim(this BloonModel bloonModel)
        {
            Il2CppSystem.Collections.Generic.List<BloonToSimulation> bloonSims = InGame.instance?.GetUnityToSimulation()?.GetAllBloons();
            if (bloonSims is null || !bloonSims.Any())
                return null;

            List<BloonToSimulation> results = bloonSims.Where(b => b.GetBaseModel().IsEqual(bloonModel)).ToList();
            return results;
        }

        /// <summary>
        /// (Cross-Game compatible) Return the Base ID of this BloonModel
        /// </summary>
        /// <param name="bloonModel"></param>
        /// <returns></returns>
        public static string GetBaseID(this BloonModel bloonModel)
        {
#if BloonsTD6
            return bloonModel.baseId;
#elif BloonsAT
            return bloonModel.baseType.ToString();
#endif
        }
    }
}
