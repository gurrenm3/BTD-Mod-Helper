using System;
using System.Collections.Generic;
using System.Linq;
using BTD_Mod_Helper.Api;
using BTD_Mod_Helper.Api.Bloons;
using BTD_Mod_Helper.Api.Display;
using BTD_Mod_Helper.Api.Enums;
using Il2CppAssets.Scripts.Models.Bloons;
using Il2CppAssets.Scripts.Models.Bloons.Behaviors;
using Il2CppAssets.Scripts.Models.GenericBehaviors;
using Il2CppAssets.Scripts.Models.Rounds;
using Il2CppAssets.Scripts.Unity;
using Il2CppAssets.Scripts.Unity.Bridge;
using Il2CppAssets.Scripts.Unity.UI_New.InGame;
namespace BTD_Mod_Helper.Extensions;

/// <summary>
/// Extensions for BloonModels
/// </summary>
public static class BloonModelExt
{
    /// <summary>
    /// (Cross-Game compatable) Return how much cash this bloon would give if popped by <paramref name="layersPopped" /> number
    /// of layers
    /// </summary>
    /// <param name="bloonModel"></param>
    /// <param name="layersPopped">
    /// How many layers of bloons to pop, ignoring layer health. If less than 0, calculates for the
    /// entire bloon
    /// </param>
    public static int GetTotalCash(this BloonModel bloonModel, int layersPopped = -1)
    {
        if (layersPopped == 0 || InGame.instance == null) return 0;

        var cashValue = SessionData.Instance.bloonPopValues;
        var children = bloonModel.GetChildBloonModels(InGame.instance.GetSimulation());
        if (layersPopped >= 0 || !cashValue.TryGetValue(bloonModel.GetBaseID(), out var bloonCash))
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
    /// Return the number position of this bloon from the list of all bloons (Game.instance.model.bloons)
    /// </summary>
    public static int GetIndex(this BloonModel bloonModel)
    {
        var allBloons = Game.instance.model.bloons;
        return allBloons.FindIndex(bloon => bloon.name == bloonModel.name);
    }

    /// <summary>
    /// Spawn this BloonModel on the map right now
    /// </summary>
    public static void SpawnBloonModel(this BloonModel bloonModel)
    {
        if (InGame.instance == null)
            return;

        var spawner = InGame.instance.GetMap().spawner;

        spawner.Emit(bloonModel, InGame.instance.GetUnityToSimulation().GetCurrentRound(), 0);

    }

    /// <summary>
    /// Create a BloonEmissionModel from this BloonModel
    /// </summary>
    /// <param name="bloonModel"></param>
    /// <param name="count">Number of bloons in this emission model</param>
    /// <param name="spacing">Space between each bloon in this emission model</param>
    public static Il2CppReferenceArray<BloonEmissionModel> CreateBloonEmissionModel
    (
        this BloonModel bloonModel,
        int count, int spacing
    ) => Game.instance.model.CreateBloonEmissions(bloonModel, count, spacing);

    /// <summary>
    /// Return all BloonToSimulations with this BloonModel
    /// </summary>
    [Obsolete("use GetAllBloonToSim instead")]
    public static List<BloonToSimulation> GetBloonSims(this BloonModel bloonModel) => GetAllBloonToSim(bloonModel);

    /// <summary>
    /// Return all BloonToSimulations with this BloonModel
    /// </summary>
    public static List<BloonToSimulation> GetAllBloonToSim(this BloonModel bloonModel)
    {
        if (InGame.instance == null)
        {
            return Array.Empty<BloonToSimulation>().ToList();
        }

        var bloonSims = InGame.instance.GetUnityToSimulation()?.GetAllBloons();
        if (bloonSims is null || !bloonSims.Any())
            return new List<BloonToSimulation>();

        var results = bloonSims.ToList().Where(b => b.GetBaseModel().IsEqual(bloonModel)).ToList();
        return results;
    }

    /// <summary>
    /// Set the Display GUID for this BloonModel.
    /// </summary>
    /// <param name="bloonModel"></param>
    /// <param name="guid"></param>
    public static void SetDisplayGUID(this BloonModel bloonModel, string guid)
    {

        bloonModel.display = ModContent.CreatePrefabReference(guid);

        if (bloonModel.HasBehavior<DisplayModel>())
        {
            bloonModel.GetBehavior<DisplayModel>().display = ModContent.CreatePrefabReference(guid);
        }
        else
        {
            bloonModel.AddBehavior(new DisplayModel("DisplayModel_BloonDisplay",
                ModContent.CreatePrefabReference(guid), 0, DisplayCategory.Bloon));
        }
    }

    /// <summary>
    /// Returns the Display GUID for this BloonModel.
    /// </summary>
    /// <param name="bloonModel"></param>
    /// <returns></returns>
    public static string GetDisplayGUID(this BloonModel bloonModel) => bloonModel.display.AssetGUID;

    /// <summary>
    /// Return the Base ID of this BloonModel
    /// </summary>
    /// <param name="bloonModel"></param>
    /// <returns></returns>
    public static string GetBaseID(this BloonModel bloonModel) => bloonModel.baseId;

    /// <summary>
    /// Returns whether or not this BloonModel is a Camo bloon.
    /// </summary>
    /// <param name="bloonModel"></param>
    /// <returns></returns>
    public static bool IsCamoBloon(this BloonModel bloonModel) => bloonModel.isCamo;

    /// <summary>
    /// Set whether or not this BloonModel is a Camo bloon.
    /// </summary>
    /// <param name="bloonModel"></param>
    /// <param name="isCamo"></param>
    public static void SetCamo(this BloonModel bloonModel, bool isCamo)
    {

        bloonModel.isCamo = isCamo;
        switch (isCamo)
        {
            case true when !bloonModel.HasTag(BloonTag.Camo):
                bloonModel.AddTag(BloonTag.Camo);
                break;
            case false when bloonModel.HasTag(BloonTag.Camo):
                bloonModel.RemoveTag(BloonTag.Camo);
                break;
        }

    }

    /// <summary>
    /// Returns whether or not this BloonModel is a Regrow bloon.
    /// </summary>
    /// <param name="bloonModel"></param>
    /// <returns></returns>
    public static bool IsRegrowBloon(this BloonModel bloonModel) => bloonModel.isGrow;

    /// <summary>
    /// Set whether or not this BloonModel is a Regrow bloon.
    /// </summary>
    /// <param name="bloonModel"></param>
    /// <param name="isRegrow"></param>
    private static void SetRegrowBool(this BloonModel bloonModel, bool isRegrow)
    {

        bloonModel.isGrow = isRegrow;
        switch (isRegrow)
        {
            case true when !bloonModel.HasTag(BloonTag.Regrow):
                bloonModel.AddTag(BloonTag.Regrow);
                break;
            case false when bloonModel.HasTag(BloonTag.Regrow):
                bloonModel.RemoveTag(BloonTag.Regrow);
                break;
        }

    }

    /// <summary>
    /// Adds the Regrow behavior to this BloonModel and sets what
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
    /// Removes the Regrow behavior from this BloonModel.
    /// </summary>
    /// <param name="bloonModel"></param>
    public static void RemoveRegrow(this BloonModel bloonModel)
    {
        bloonModel.SetRegrowBool(false);
        bloonModel.RemoveBehavior<GrowModel>();
    }

    /// <summary>
    /// Returns whether or not this BloonModel is a Fortified bloon.
    /// </summary>
    /// <param name="bloonModel"></param>
    /// <returns></returns>
    public static bool IsFortifiedBloon(this BloonModel bloonModel) => bloonModel.isFortified;

    /// <summary>
    /// Set whether or not this BloonModel is a Fortified bloon.
    /// </summary>
    /// <param name="bloonModel"></param>
    /// <param name="isFortified"></param>
    public static void SetFortified(this BloonModel bloonModel, bool isFortified)
    {

        bloonModel.isFortified = isFortified;
        switch (isFortified)
        {
            case true when !bloonModel.HasTag(BloonTag.Fortified):
                bloonModel.AddTag(BloonTag.Fortified);
                break;
            case false when bloonModel.HasTag(BloonTag.Fortified):
                bloonModel.RemoveTag(BloonTag.Fortified);
                break;
        }

    }

    /// <summary>
    /// Returns whether or not this BloonModel is an MOAB-Class bloon.
    /// </summary>
    /// <param name="bloonModel"></param>
    /// <returns></returns>
    public static bool IsMoabBloon(this BloonModel bloonModel) => bloonModel.isMoab;

    /// <summary>
    /// Set whether or not this BloonModel is a Fortified bloon.
    /// </summary>
    /// <param name="bloonModel"></param>
    /// <param name="isMoabBloon"></param>
    public static void SetMoab(this BloonModel bloonModel, bool isMoabBloon)
    {

        bloonModel.isMoab = isMoabBloon;
        bloonModel.AddTag(BloonTag.Moab);

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
    /// <param name="id"></param>
    public static bool FindChangedBloonId(this BloonModel bloonModel, Action<BloonModel> change, out string id)
    {
        var bloon = bloonModel.Duplicate();

        change(bloon);

        id = Game.instance.model.bloons
            .Where(model =>
                model.GetBaseID() == bloon.GetBaseID() &&
                model.IsCamoBloon() == bloon.IsCamoBloon() &&
                model.IsRegrowBloon() == bloon.IsRegrowBloon() &&
                model.IsFortifiedBloon() == bloon.IsFortifiedBloon()
            )
            .Select(model => model.id).FirstOrDefault();

        return id != null;
    }

    private static void MakeChildrenSomething(this BloonModel bloonModel, Action<BloonModel> effect)
    {
        var spawnChildrenModel = bloonModel.GetSpawnChildrenModel();
        if (spawnChildrenModel?.children != null)
        {
            for (var i = 0; i < spawnChildrenModel.children.Count; i++)
            {
                var current = spawnChildrenModel.children[i];
                if (Game.instance.model.GetBloon(current).FindChangedBloonId(effect, out var newBloon))
                {
                    spawnChildrenModel.children[i] = newBloon;
                }
            }
        }

        var growModel = bloonModel.GetBehavior<GrowModel>();

        if (!string.IsNullOrEmpty(growModel?.growToId) &&
            Game.instance.model.GetBloon(growModel!.growToId).FindChangedBloonId(effect, out var newBloon1))
        {
            growModel.growToId = newBloon1;
        }

    }

    /// <summary>
    /// Makes all children of this Bloon Camo, if they can have it
    /// </summary>
    public static void MakeChildrenCamo(this BloonModel bloonModel)
    {
        bloonModel.MakeChildrenSomething(model => model.SetCamo(true));
    }

    /// <summary>
    /// Makes all children of this Bloon Regrow, if they can have it
    /// </summary>
    public static void MakeChildrenRegrow(this BloonModel bloonModel)
    {
        bloonModel.MakeChildrenSomething(model => model.SetRegrowBool(true));
    }

    /// <summary>
    /// Makes all children of this Bloon Fortified, if they can have it
    /// </summary>
    public static void MakeChildrenFortified(this BloonModel bloonModel)
    {
        bloonModel.MakeChildrenSomething(model => model.SetFortified(true));
    }

    /// <summary>
    /// Gets the ModBloon associated with this BloonModel
    /// <br />
    /// If there is no associated ModBloon, returns null
    /// </summary>
    public static ModBloon GetModBloon(this BloonModel bloonModel) =>
        ModBloon.Cache.TryGetValue(bloonModel.name, out var modBloon) ? modBloon : null;

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

    /// <summary>
    /// Gets the BloonModel for this group
    /// </summary>
    /// <param name="bloonGroupModel"></param>
    /// <returns></returns>
    public static BloonModel GetBloonModel(this BloonGroupModel bloonGroupModel) =>
        Game.instance.model.GetBloon(bloonGroupModel.bloon);
}