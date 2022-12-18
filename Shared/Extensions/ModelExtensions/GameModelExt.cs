using Il2CppAssets.Scripts.Models;

namespace BTD_Mod_Helper.Extensions;

/// <summary>
/// Extensions for the GameModel
/// </summary>
public static partial class GameModelExt
{
    /// <summary>
    /// Returns whether or not a bloon exists with this name
    /// </summary>
    public static bool DoesBloonExist(this GameModel gameModel, string bloonName)
    {
        return gameModel.bloons.Any(bloon => bloon.name == bloonName);
    }
}