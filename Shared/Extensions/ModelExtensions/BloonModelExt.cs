﻿using Assets.Scripts.Models.Bloons;
using Assets.Scripts.Models.Rounds;
using Assets.Scripts.Unity;
using Assets.Scripts.Unity.Bridge;
using Assets.Scripts.Unity.UI_New.InGame;
using System.Collections.Generic;
using UnhollowerBaseLib;
using System;
using System.Linq;
using Assets.Scripts.Models.Bloons.Behaviors;
using BTD_Mod_Helper.Api;
using BTD_Mod_Helper.Api.Bloons;
using BTD_Mod_Helper.Api.Display;
using BTD_Mod_Helper.Api.Enums;

#if BloonsTD6
using Assets.Scripts.Models.GenericBehaviors;
#elif BloonsAT
using Assets.Scripts.Models.Display;
#endif


namespace BTD_Mod_Helper.Extensions
{
    /// <summary>
    /// Extensions for BloonModels
    /// </summary>
    public static partial class BloonModelExt
    {
        /// <summary>
        /// (Cross-Game compatable) Return how much cash this bloon would give if popped by <paramref name="layersPopped"/> number of layers
        /// </summary>
        /// <param name="bloonModel"></param>
        /// <param name="layersPopped">How many layers of bloons to pop, ignoring layer health. If less than 0, calculates for the entire bloon</param>
        public static int GetTotalCash(this BloonModel bloonModel, int layersPopped = -1)
        {
            if (layersPopped == 0 || InGame.instance == null) return 0;

            var cashValue = SessionData.Instance.bloonPopValues;
            var children = bloonModel.GetChildBloonModels(InGame.instance.GetSimulation());
            if ((layersPopped >= 0) || !cashValue.TryGetValue(bloonModel.GetBaseID(), out var bloonCash))
            {
                bloonCash = 1;
                foreach (var child in children)
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
            var allBloons = Game.instance.model.bloons;
            return allBloons.FindIndex(bloon => bloon.name == bloonModel.name);
        }

        /// <summary>
        /// (Cross-Game compatible) Spawn this BloonModel on the map right now
        /// </summary>
        public static void SpawnBloonModel(this BloonModel bloonModel)
        {
            if (InGame.instance == null)
                return;
            var spawner = InGame.instance.GetMap()!.spawner;

#if BloonsTD6
            spawner.Emit(bloonModel, InGame.instance.GetUnityToSimulation()!.GetCurrentRound(), 0);
#elif BloonsAT
            spawner.Emit(bloonModel);
#endif
        }

        /// <summary>
        /// (Cross-Game compatible) Create a BloonEmissionModel from this BloonModel
        /// </summary>
        /// <param name="bloonModel"></param>
        /// <param name="count">Number of bloons in this emission model</param>
        /// <param name="spacing">Space between each bloon in this emission model</param>
        public static Il2CppReferenceArray<BloonEmissionModel> CreateBloonEmissionModel(this BloonModel bloonModel,
            int count, int spacing)
        {
            return Game.instance.model.CreateBloonEmissions(bloonModel, count, spacing);
        }

        /// <summary>
        /// (Cross-Game compatible) This is Obsolete, use GetAllBloonToSim instead. (Cross-Game compatible) Return all BloonToSimulations with this BloonModel
        /// </summary>
        [Obsolete]
        public static List<BloonToSimulation>? GetBloonSims(this BloonModel bloonModel)
        {
            if (InGame.instance == null)
            {
                return null;
            }

            var bloonSims = InGame.instance.GetUnityToSimulation()?.GetAllBloons();
            if (bloonSims is null || !bloonSims.Any())
                return null;

            var results = bloonSims.Where(b => b.GetBaseModel().IsEqual(bloonModel)).ToList();
            return results;
        }

        /// <summary>
        /// (Cross-Game compatible) Return all BloonToSimulations with this BloonModel
        /// </summary>
        public static List<BloonToSimulation>? GetAllBloonToSim(this BloonModel bloonModel)
        {
            if (InGame.instance == null)
            {
                return null;
            }
            var bloonSims = InGame.instance.GetUnityToSimulation()?.GetAllBloons();
            if (bloonSims is null || !bloonSims.Any())
                return null;

            var results = bloonSims.Where(b => b.GetBaseModel().IsEqual(bloonModel)).ToList();
            return results;
        }

        /// <summary>
        /// (Cross-Game compatible) Set the Display GUID for this BloonModel.
        /// </summary>
        /// <param name="bloonModel"></param>
        /// <param name="guid"></param>
        public static void SetDisplayGUID(this BloonModel bloonModel, string guid)
        {
#if BloonsTD6
            bloonModel.display = guid;
#endif
            bloonModel.GetBehavior<DisplayModel>()!.display = guid;
        }

        /// <summary>
        /// (Cross-Game compatible) Returns the Display GUID for this BloonModel.
        /// </summary>
        /// <param name="bloonModel"></param>
        /// <returns></returns>
        public static string GetDisplayGUID(this BloonModel bloonModel)
        {
#if BloonsTD6
            return bloonModel.display;
#elif BloonsAT
            return bloonModel.GetBehavior<DisplayModel>().display;
#endif
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
        /// (Cross-Game compatible) Returns whether or not this BloonModel is a Camo bloon.
        /// </summary>
        /// <param name="bloonModel"></param>
        /// <returns></returns>
        public static bool IsCamoBloon(this BloonModel bloonModel)
        {
#if BloonsTD6
            return bloonModel.isCamo;
#elif BloonsAT
            return bloonModel.IsCamo;
#endif
        }

        /// <summary>
        /// (Cross-Game compatible) Set whether or not this BloonModel is a Camo bloon.
        /// </summary>
        /// <param name="bloonModel"></param>
        /// <param name="isCamo"></param>
        public static void SetCamo(this BloonModel bloonModel, bool isCamo)
        {
#if BloonsTD6
            bloonModel.isCamo = isCamo;
            bloonModel.AddTag(BloonTag.Camo);
#elif BloonsAT
            bloonModel.IsCamo = isCamo;
#endif
        }

        /// <summary>
        /// (Cross-Game compatible) Returns whether or not this BloonModel is a Regrow bloon.
        /// </summary>
        /// <param name="bloonModel"></param>
        /// <returns></returns>
        public static bool IsRegrowBloon(this BloonModel bloonModel)
        {
#if BloonsTD6
            return bloonModel.isGrow;
#elif BloonsAT
            return bloonModel.IsRegrow;
#endif
        }

        /// <summary>
        /// (Cross-Game compatible) Set whether or not this BloonModel is a Regrow bloon.
        /// </summary>
        /// <param name="bloonModel"></param>
        /// <param name="isRegrow"></param>
        private static void SetRegrowBool(this BloonModel bloonModel, bool isRegrow)
        {
#if BloonsTD6
            bloonModel.isGrow = isRegrow;
            bloonModel.AddTag(BloonTag.Regrow);
#elif BloonsAT
            bloonModel.IsRegrow.cachedObject = isRegrow; // this is untested and may not work.
#endif
        }

        /// <summary>
        /// (Cross-Game compatible) Adds the Regrow behavior to this BloonModel and sets what 
        /// Bloon it Regrows into.
        /// </summary>
        /// <param name="bloonModel"></param>
        /// <param name="regrowsTo">The ID of the BloonModel that this should regrow into.</param>
        /// <param name="regrowRate">The rate at which this regrows.</param>
        public static void SetRegrow(this BloonModel bloonModel, string regrowsTo, float regrowRate = 3)
        {
            bloonModel.SetRegrowBool(true);

            if (!bloonModel.HasBehavior<GrowModel>(out var growModel))
            {
                growModel = BloonModelUtils.CreateGrowModel(regrowsTo, regrowRate);
                bloonModel.AddBehavior(growModel);
            }

            growModel.SetRegrowBloon(regrowsTo, regrowRate);
        }

        /// <summary>
        /// (Cross-Game compatible) Removes the Regrow behavior from this BloonModel.
        /// </summary>
        /// <param name="bloonModel"></param>
        public static void RemoveRegrow(this BloonModel bloonModel)
        {
            bloonModel.SetRegrowBool(false);
            bloonModel.RemoveBehavior<GrowModel>();
        }

        /// <summary>
        /// (Cross-Game compatible) Returns whether or not this BloonModel is a Fortified bloon.
        /// </summary>
        /// <param name="bloonModel"></param>
        /// <returns></returns>
        public static bool IsFortifiedBloon(this BloonModel bloonModel)
        {
#if BloonsTD6
            return bloonModel.isFortified;
#elif BloonsAT
            return bloonModel.IsFortified;
#endif
        }

        /// <summary>
        /// (Cross-Game compatible) Set whether or not this BloonModel is a Fortified bloon.
        /// </summary>
        /// <param name="bloonModel"></param>
        /// <param name="isFortified"></param>
        public static void SetFortified(this BloonModel bloonModel, bool isFortified)
        {
#if BloonsTD6
            bloonModel.isFortified = isFortified;
            bloonModel.AddTag(BloonTag.Fortified);
#elif BloonsAT
            bloonModel._IsFortified_k__BackingField = isFortified;
#endif
        }

        /// <summary>
        /// (Cross-Game compatible) Returns whether or not this BloonModel is an MOAB-Class bloon.
        /// </summary>
        /// <param name="bloonModel"></param>
        /// <returns></returns>
        public static bool IsMoabBloon(this BloonModel bloonModel)
        {
#if BloonsTD6
            return bloonModel.isMoab;
#elif BloonsAT
            return bloonModel.IsMoab;
#endif
        }

        /// <summary>
        /// (Cross-Game compatible) Set whether or not this BloonModel is a Fortified bloon.
        /// </summary>
        /// <param name="bloonModel"></param>
        /// <param name="isMoabBloon"></param>
        public static void SetMoab(this BloonModel bloonModel, bool isMoabBloon)
        {
#if BloonsTD6
            bloonModel.isMoab = isMoabBloon;
            bloonModel.AddTag(BloonTag.Moab);
#elif BloonsAT
            bloonModel.IsMoab.cachedObject = isMoabBloon;
#endif
        }

        /// <summary>
        /// (Cross-Game compatible) Applies a given ModDisplay to this TowerModel
        /// </summary>
        /// <typeparam name="T">The type of ModDisplay</typeparam>
        public static void ApplyDisplay<T>(this BloonModel bloonModel) where T : ModDisplay
        {
            ModContent.GetInstance<T>().Apply(bloonModel);
        }

        /// <summary>
        /// (Cross-Game compatible) Adds a child to be spawned from the Bloon
        /// </summary>
        public static void AddToChildren<T>(this BloonModel bloonModel, int amount = 1) where T : ModBloon
        {
            bloonModel.AddToChildren(ModContent.BloonID<T>(), amount);
        }

        /// <summary>
        /// (Cross-Game compatible) Gets the SpawnChildrenModel for the bloon, and optionally creates one if it doesn't exist
        /// </summary>
        public static SpawnChildrenModel GetSpawnChildrenModel(this BloonModel bloonModel, bool addIfNotExists = false)
        {
            var spawnChild = bloonModel.GetBehavior<SpawnChildrenModel>();
            if (spawnChild == null && addIfNotExists)
            {
                spawnChild = new SpawnChildrenModel("SpawnChildrenModel_", new Il2CppStringArray(0));
                bloonModel.AddBehavior(spawnChild);
            }

            return spawnChild!;
        }

        /// <summary>
        /// (Cross-Game compatible) Adds a child to be spawned from the Bloon
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
        /// (Cross-Game compatible) Removes all spawned children from this BloonModel
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
        /// (Cross-Game compatible) Removes up to amount of the given Bloon from the spawned children
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
        /// (Cross-Game compatible) Replaces all spawned child Bloons with the given id with the given ModBloon
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
        /// (Cross-Game compatible) Replaces all spawned child Bloons that have id oldId with the given ModBloon
        /// </summary>
        public static void ReplaceInChildren<T>(this BloonModel bloonModel, string oldId) where T : ModBloon
        {
            bloonModel.ReplaceInChildren(oldId, ModContent.BloonID<T>());
        }

        /// <summary>
        /// (Cross-Game compatible) Replaces all spawned child Bloons of the first ModBloon type with the second ModBloon type
        /// </summary>
        /// <param name="bloonModel"></param>
        /// <param name="id"></param>
        public static void ReplaceInChildren<TOld, TNew>(this BloonModel bloonModel, string id)
            where TOld : ModBloon where TNew : ModBloon
        {
            bloonModel.ReplaceInChildren(ModContent.BloonID<TOld>(), ModContent.BloonID<TNew>());
        }

        /// <summary>
        /// (Cross-Game compatible) Finds the id for a bloon that has the properties of this bloonModel, or null if there isn't one
        /// </summary>
        /// <param name="bloonModel"></param>
        /// <param name="change"></param>
        public static string? FindChangedBloonId(this BloonModel bloonModel, Action<BloonModel> change)
        {
            var bloon = bloonModel.Duplicate();

            change(bloon);

            return Game.instance.model.bloons
                .Where(model =>
                    model.GetBaseID() == bloon.GetBaseID() &&
                    model.IsCamoBloon() == bloon.IsCamoBloon() &&
                    model.IsRegrowBloon() == bloon.IsRegrowBloon() &&
                    model.IsFortifiedBloon() == bloon.IsFortifiedBloon())
                .Select(model => model.id).FirstOrDefault();
        }

        private static void MakeChildrenSomething(this BloonModel bloonModel, Action<BloonModel> effect)
        {
            var spawnChildrenModel = bloonModel.GetSpawnChildrenModel();
            if (spawnChildrenModel?.children != null)
            {
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

            var growModel = bloonModel.GetBehavior<GrowModel>();
#if BloonsTD6
            if (!string.IsNullOrEmpty(growModel?.growToId))
            {
                var newBloon = Game.instance.model.GetBloon(growModel.growToId).FindChangedBloonId(effect);
                if (newBloon != null)
                {
                    growModel.growToId = newBloon;
                }
            }
#elif BloonsAT
            // need to implement for BATTD.
            // Need to figure out how to check for "growModel.growToId" in BATTD
            throw new NotImplementedException(); 
#endif

        }

        /// <summary>
        /// (Cross-Game compatible) Makes all children of this Bloon Camo, if they can have it
        /// </summary>
        public static void MakeChildrenCamo(this BloonModel bloonModel)
        {
            bloonModel.MakeChildrenSomething(model => model.SetCamo(true));
        }

        /// <summary>
        /// (Cross-Game compatible) Makes all children of this Bloon Regrow, if they can have it
        /// </summary>
        public static void MakeChildrenRegrow(this BloonModel bloonModel)
        {
            bloonModel.MakeChildrenSomething(model => model.SetRegrowBool(true));
        }

        /// <summary>
        /// (Cross-Game compatible) Makes all children of this Bloon Fortified, if they can have it
        /// </summary>
        public static void MakeChildrenFortified(this BloonModel bloonModel)
        {
            bloonModel.MakeChildrenSomething(model => model.SetFortified(true));
        }

        /// <summary>
        /// (Cross-Game compatible) Gets the ModBloon associated with this BloonModel
        /// <br/>
        /// If there is no associated ModBloon, returns null
        /// </summary>
        public static ModBloon? GetModBloon(this BloonModel bloonModel)
        {
            return ModBloon.Cache.TryGetValue(bloonModel.name, out var modBloon) ? modBloon : null;
        }
    }
}