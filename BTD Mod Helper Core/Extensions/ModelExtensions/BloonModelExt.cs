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
using System.Linq;
using Assets.Scripts.Models.Bloons.Behaviors;
using Assets.Scripts.Unity.Bloons.Behaviors;
using BTD_Mod_Helper.Api;
using BTD_Mod_Helper.Api.Bloons;
using BTD_Mod_Helper.Api.Display;

namespace BTD_Mod_Helper.Extensions
{
    public static class BloonModelExt
    {
        /// <summary>
        /// (Cross-Game compatable) Return how much cash this bloon would give if popped by <paramref name="layersPopped"/> number of layers
        /// </summary>
        /// <param name="layersPopped">How many layers of bloons to pop, ignoring layer health. If less than 0, calculates for the entire bloon</param>
        public static int GetTotalCash(this BloonModel bloonModel, int layersPopped = -1)
        {
            if (layersPopped == 0) return 0;

            var cashValue = SessionData.Instance.bloonPopValues;
            var children = bloonModel.GetChildBloonModels(InGame.instance?.GetSimulation());
            if ((layersPopped >= 0) || !cashValue.TryGetValue(bloonModel.GetBaseID(), out int bloonCash))
            {
                bloonCash = 1;
                foreach (BloonModel child in children)
                {
                    bloonCash += child.GetTotalCash(layersPopped - 1);
                }

                if (layersPopped < 0)
                {
                    cashValue.Add(bloonModel.GetBaseID(), bloonCash);
                }
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
            Il2CppSystem.Collections.Generic.List<Bloon.ChargedMutator> chargedMutators =
                new Il2CppSystem.Collections.Generic.List<Bloon.ChargedMutator>();
            Il2CppSystem.Collections.Generic.List<BehaviorMutator> nonChargedMutators =
                new Il2CppSystem.Collections.Generic.List<BehaviorMutator>();
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
        public static Il2CppReferenceArray<BloonEmissionModel> CreateBloonEmissionModel(this BloonModel bloonModel,
            int count, int spacing)
        {
            return Game.instance?.model?.CreateBloonEmissions(bloonModel, count, spacing);
        }

        /// <summary>
        /// This is Obsolete, use GetAllBloonToSim instead. (Cross-Game compatible) Return all BloonToSimulations with this BloonModel
        /// </summary>
        [Obsolete]
        public static List<BloonToSimulation> GetBloonSims(this BloonModel bloonModel)
        {
            Il2CppSystem.Collections.Generic.List<BloonToSimulation> bloonSims =
                InGame.instance?.GetUnityToSimulation()?.GetAllBloons();
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
            Il2CppSystem.Collections.Generic.List<BloonToSimulation> bloonSims =
                InGame.instance?.GetUnityToSimulation()?.GetAllBloons();
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

        /// <summary>
        /// Applies a given ModDisplay to this TowerModel
        /// </summary>
        /// <typeparam name="T">The type of ModDisplay</typeparam>
        public static void ApplyDisplay<T>(this BloonModel bloonModel) where T : ModDisplay
        {
            ModContent.GetInstance<T>().Apply(bloonModel);
        }

        /// <summary>
        /// Adds a child to be spawned from the Bloon
        /// </summary>
        public static void AddToChildren<T>(this BloonModel bloonModel, int amount = 1) where T : ModBloon
        {
            bloonModel.AddToChildren(ModContent.BloonID<T>(), amount);
        }

        /// <summary>
        /// Gets the SpawnChildrenModel for the bloon, and optionally creates one if it doesn't exist
        /// </summary>
        public static SpawnChildrenModel GetSpawnChildrenModel(this BloonModel bloonModel, bool addIfNotExists = false)
        {
            var spawnChild = bloonModel.GetBehavior<SpawnChildrenModel>();
            if (spawnChild == null && addIfNotExists)
            {
                spawnChild = new SpawnChildrenModel("SpawnChildrenModel_", new Il2CppStringArray(0));
                bloonModel.AddBehavior(spawnChild);
            }

            return spawnChild;
        }

        /// <summary>
        /// Adds a child to be spawned from the Bloon
        /// </summary>
        public static void AddToChildren(this BloonModel bloonModel, string id, int amount = 1)
        {
            var spawnChild = bloonModel.GetSpawnChildrenModel(true);
            var children = spawnChild.children.ToList();
            for (var i = 0; i < amount; i++)
            {
                children.Add(id);
            }

            spawnChild.children = children.ToArray();
        }

        /// <summary>
        /// Removes all spawned children from this BloonModel
        /// </summary>
        public static void RemoveAllChildren(this BloonModel bloonModel)
        {
            var spawnChild = bloonModel.GetSpawnChildrenModel();
            if (spawnChild != null)
            {
                spawnChild.children = new Il2CppStringArray(0);
            }
        }

        /// <summary>
        /// Removes up to amount of the given Bloon from the spawned children
        /// </summary>
        public static void RemoveFromChildren(this BloonModel bloonModel, string id, int amount = 1)
        {
            var spawnChild = bloonModel.GetSpawnChildrenModel();
            if (spawnChild != null)
            {
                var children = spawnChild.children.ToList();
                for (var i = 0; i < amount; i++)
                {
                    if (children.Contains(id))
                    {
                        children.Remove(id);
                    }
                }

                spawnChild.children = children.ToArray();
            }
        }

        /// <summary>
        /// Replaces all spawned child Bloons with the given id with the given ModBloon
        /// </summary>
        public static void ReplaceInChildren(this BloonModel bloonModel, string oldId, string newId)
        {
            var spawnChild = bloonModel.GetSpawnChildrenModel();
            if (spawnChild != null)
            {
                var children = spawnChild.children;
                for (var i = 0; i < children.Count; i++)
                {
                    if (children[i] == oldId)
                    {
                        children[i] = newId;
                    }
                }
            }
        }

        /// <summary>
        /// Replaces all spawned child Bloons that have id oldId with the given ModBloon
        /// </summary>
        public static void ReplaceInChildren<T>(this BloonModel bloonModel, string oldId) where T : ModBloon
        {
            bloonModel.ReplaceInChildren(oldId, ModContent.BloonID<T>());
        }

        /// <summary>
        /// Replaces all spawned child Bloons of the first ModBloon type with the second ModBloon type
        /// </summary>
        /// <param name="bloonModel"></param>
        /// <param name="id"></param>
        public static void ReplaceInChildren<TOld, TNew>(this BloonModel bloonModel, string id)
            where TOld : ModBloon where TNew : ModBloon
        {
            bloonModel.ReplaceInChildren(ModContent.BloonID<TOld>(), ModContent.BloonID<TNew>());
        }
        
        /// <summary>
        /// Finds the id for a bloon that has the properties of this bloonModel, or null if there isn't one
        /// </summary>
        /// <param name="bloonModel"></param>
        /// <param name="change"></param>
        public static string FindChangedBloonId(this BloonModel bloonModel, Action<BloonModel> change)
        {
            var bloon = bloonModel.Duplicate();

            change(bloon);

            return Game.instance.model.bloons
                .Where(model =>
                    model.baseId == bloon.baseId &&
                    model.isCamo == bloon.isCamo &&
                    model.isGrow == bloon.isGrow &&
                    model.isFortified == bloon.isFortified)
                .Select(model => model.id).FirstOrDefault();
        }

        private static void MakeChildrenSomething(this BloonModel bloonModel, Action<BloonModel> effect)
        {
            var spawnChildrenModel = bloonModel.GetSpawnChildrenModel();
            for (var i = 0; i < spawnChildrenModel.children.Count; i++)
            {
                var current = spawnChildrenModel.children[i];
                var newBloon = Game.instance.model.GetBloon(current).FindChangedBloonId(effect);
                if (newBloon != null)
                {
                    spawnChildrenModel.children[i] = newBloon;
                }
            }
        }

        /// <summary>
        /// Makes all children of this Bloon Camo, if they can have it
        /// </summary>
        public static void MakeChildrenCamo(this BloonModel bloonModel)
        {
            bloonModel.MakeChildrenSomething(model => model.isCamo = true);
        }
        
        /// <summary>
        /// Makes all children of this Bloon Regrow, if they can have it
        /// </summary>
        public static void MakeChildrenRegrow(this BloonModel bloonModel)
        {
            bloonModel.MakeChildrenSomething(model => model.isGrow = true);
        }
        
        /// <summary>
        /// Makes all children of this Bloon Fortified, if they can have it
        /// </summary>
        public static void MakeChildrenFortified(this BloonModel bloonModel)
        {
            bloonModel.MakeChildrenSomething(model => model.isFortified = true);
        }

        /// <summary>
        /// Adds a tag to the BloonModel, if it doesn't already exist
        /// </summary>
        public static void AddTag(this BloonModel bloonModel, string tag)
        {
            var tags = bloonModel.tags?.ToList() ?? new List<string>();
            if (!tags.Contains(tag))
            {
                tags.Add(tag);
                bloonModel.tags = tags.ToArray();
            }
        }

        /// <summary>
        /// Removes a tag from the BloonModel, if it exists
        /// </summary>
        public static void RemoveTag(this BloonModel bloonModel, string tag)
        {
            if (bloonModel.tags != null)
            {
                var tags = bloonModel.tags.ToList();
                if (tags.Contains(tag))
                {
                    tags.Remove(tag);
                    bloonModel.tags = tags.ToArray();
                }
            }
        }
    }
}