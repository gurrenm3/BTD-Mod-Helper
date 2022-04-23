using Assets.Scripts.Models.Towers.Upgrades;
using Assets.Scripts.Unity;
using BTD_Mod_Helper.Api.Towers;

namespace BTD_Mod_Helper.Extensions;

/// <summary>
/// Extensions for UpgradeModels
/// </summary>
public static class UpgradeModelExt
{
    /// <summary>
    /// Return whether or not this upgrade has been unlocked by the player
    /// </summary>
    public static bool IsUpgradeUnlocked(this UpgradeModel upgradeModel)
    {
        return Game.instance.GetBtd6Player()!.HasUpgrade(upgradeModel.name);
    }

    /// <summary>
    /// Gets the ModUpgrade associated with this UpgradeModel
    /// <br/>
    /// If there is no associated ModUpgrade, returns null
    /// </summary>
    /// <returns></returns>
    public static ModUpgrade? GetModUpgrade(this UpgradeModel upgradeModel)
    {
        return ModUpgrade.Cache.TryGetValue(upgradeModel.name, out var modUpgrade) ? modUpgrade : null;
    }
}