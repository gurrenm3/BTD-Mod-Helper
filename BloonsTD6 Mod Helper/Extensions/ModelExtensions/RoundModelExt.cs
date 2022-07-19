using System.Linq;
using Assets.Scripts.Models.Rounds;
using BTD_Mod_Helper.Api;
using BTD_Mod_Helper.Api.Bloons;
using UnhollowerBaseLib;

namespace BTD_Mod_Helper.Extensions;

public static partial class RoundModelExt
{
    /// <summary>
    /// Adds a new group of Bloons to this round
    /// </summary>
    /// <param name="roundModel">The round model</param>
    /// <param name="bloonId">The id of the Bloon</param>
    /// <param name="count">How many Bloons will be emitted</param>
    /// <param name="startTime">When this group starts emitting, in frames (seconds / 60)</param>
    /// <param name="endTime">When this group stops emitting, in frames (seconds / 60)</param>
    public static void AddBloonGroup(this RoundModel roundModel, string bloonId, int count = 1,
        float startTime = 0f, float endTime = 60f)
    {
        var groupModel = new BloonGroupModel("BloonGroupModel_", bloonId, startTime, endTime, count);

        roundModel.groups = roundModel.groups.AddTo(groupModel);
        roundModel.AddChildDependant(groupModel);

        roundModel.emissions_ = null;
    }

    /// <summary>
    /// Adds a new group of Bloons to this round
    /// </summary>
    /// <param name="roundModel">The round model</param>
    /// <param name="count">How many Bloons will be emitted</param>
    /// <param name="startTime">When this group starts emitting, in frames (seconds / 60)</param>
    /// <param name="endTime">When this group stops emitting, in frames (seconds / 60)</param>
    public static void AddBloonGroup<T>(this RoundModel roundModel, int count = 1,
        float startTime = 0f, float endTime = 60f) where T : ModBloon
    {
        var groupModel =
            new BloonGroupModel("BloonGroupModel_", ModContent.BloonID<T>(), startTime, endTime, count);

        roundModel.groups = roundModel.groups.AddTo(groupModel);
        roundModel.AddChildDependant(groupModel);

        roundModel.emissions_ = null;
    }

    /// <summary>
    /// Removes all Bloon Groups from the Round
    /// </summary>
    public static void ClearBloonGroups(this RoundModel roundModel)
    {
        foreach (var roundModelGroup in roundModel.groups)
        {
            roundModel.RemoveChildDependant(roundModelGroup);
        }
        roundModel.groups = new Il2CppReferenceArray<BloonGroupModel>(0);
        roundModel.emissions_ = null;
    }

    /// <summary>
    /// Removes all Bloon Groups where the id is as specified
    /// </summary>
    public static void RemoveBloonGroup(this RoundModel roundModel, string bloonId)
    {
        var bloonGroupModels = roundModel.groups.ToList();
        bloonGroupModels.RemoveAll(model =>
        {
            if (model.bloon == bloonId)
            {
                roundModel.RemoveChildDependant(model);
                return true;
            }

            return false;
        });
        roundModel.groups = bloonGroupModels.ToArray();
        roundModel.emissions_ = null;
    }

    /// <summary>
    /// Removes the index'th Bloon Group where the id is as specified
    /// </summary>
    public static void RemoveBloonGroup(this RoundModel roundModel, string bloonId, int index)
    {
        var bloonGroupModels = roundModel.groups.ToList();
        var toRemove = bloonGroupModels.Where(model => model.bloon == bloonId).Skip(index).FirstOrDefault();
        if (toRemove != null)
        {
            bloonGroupModels.Remove(toRemove);
            roundModel.RemoveChildDependant(toRemove);
            roundModel.groups = bloonGroupModels.ToArray();
            roundModel.emissions_ = null;
        }
    }

    /// <summary>
    /// Replaces BloonGroups of a certain bloonId with ones for a new Id
    /// </summary>
    public static void ReplaceBloonInGroups(this RoundModel roundModel, string oldBloonId, string newBloonId, bool byBaseId = false)
    {
        foreach (var roundModelGroup in roundModel.groups)
        {
            if (roundModelGroup.bloon == oldBloonId)
            {
                roundModelGroup.bloon = newBloonId;
            }
        }

        roundModel.emissions_ = null;
    }

    /// <summary>
    /// Replaces BloonGroups of a certain bloonId with ones for a new Id
    /// </summary>
    public static void ReplaceBloonInGroups<T>(this RoundModel roundModel, string oldBloonId, bool byBaseId = false) where T : ModBloon
    {
        foreach (var roundModelGroup in roundModel.groups)
        {
            if (roundModelGroup.bloon == oldBloonId)
            {
                roundModelGroup.bloon = ModContent.BloonID<T>();
            }
        }

        roundModel.emissions_ = null;
    }
}