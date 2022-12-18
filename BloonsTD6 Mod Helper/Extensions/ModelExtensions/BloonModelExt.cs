using Il2CppAssets.Scripts.Models.Bloons;
using Il2CppAssets.Scripts.Models.Rounds;
using Il2CppAssets.Scripts.Unity;
using System.Collections.Generic;
using System.Linq;

namespace BTD_Mod_Helper.Extensions;

public static partial class BloonModelExt
{
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
    public static BloonModel GetBloonModel(this BloonGroupModel bloonGroupModel)
    {
        return Game.instance.model.GetBloon(bloonGroupModel.bloon);
    }
}