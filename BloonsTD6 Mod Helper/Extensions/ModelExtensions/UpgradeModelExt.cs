using BTD_Mod_Helper.Api.Towers;
using Il2CppAssets.Scripts.Models.Towers.Upgrades;
using Il2CppAssets.Scripts.Unity;
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
        return Game.instance.GetBtd6Player().HasUpgrade(upgradeModel.name);
    }

    /// <summary>
    /// Gets the ModUpgrade associated with this UpgradeModel
    /// <br/>
    /// If there is no associated ModUpgrade, returns null
    /// </summary>
    /// <returns></returns>
    public static ModUpgrade GetModUpgrade(this UpgradeModel upgradeModel) =>
        ModUpgrade.Cache.TryGetValue(upgradeModel.name, out var modUpgrade) ? modUpgrade : null;

    /// <summary>
    /// Gets the UpgradeModel that this UpgradePathModel uses
    /// </summary>
    public static UpgradeModel GetUpgrade(this UpgradePathModel upgradePathModel) =>
        Game.instance.model.GetUpgrade(upgradePathModel.upgrade);

    /// <summary>
    /// Gets the ModUpgrade that this UpgradePathModel is for, or null if it's vanilla
    /// </summary>
    public static ModUpgrade GetModUpgrade(this UpgradePathModel upgradePathModel) =>
        ModUpgrade.Cache.TryGetValue(upgradePathModel.upgrade, out var modUpgrade) ? modUpgrade : null;
}