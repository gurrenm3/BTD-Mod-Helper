using Il2CppAssets.Scripts.Models.Profile;
using Il2CppAssets.Scripts.Unity;
namespace BTD_Mod_Helper.Extensions;

/// <summary>
/// Extensions for ProfileModels
/// </summary>
public static class ProfileModelExt
{
    /// <summary>
    /// Add a tower to the list of UnlockedTowers
    /// </summary>
    /// <param name="profileModel"></param>
    /// <param name="towerId">The ID of the tower you want to unlock</param>
    public static void UnlockTower(this ProfileModel profileModel, string towerId)
    {
        profileModel.unlockedTowers.Add(towerId);
    }

    /// <summary>
    /// Add a tower to the list of UnlockedTowers only if the TowerModel is in Game.instance.model.towers
    /// </summary>
    /// <param name="profileModel"></param>
    /// <param name="towerId">The ID of the tower you want to unlock</param>
    /// <param name="unlockIfTowerModelExists">If set to true the TowerModel will only be unlocked if it has been registered in the game</param>
    /// <returns>Returns whether or not the tower was unlocked</returns>
    public static bool UnlockTower(this ProfileModel profileModel, string towerId, bool unlockIfTowerModelExists)
    {
        if (unlockIfTowerModelExists && !Game.instance.model.DoesTowerModelExist(towerId))
            return false;

        profileModel.unlockedTowers.Add(towerId);
        return true;
    }
}