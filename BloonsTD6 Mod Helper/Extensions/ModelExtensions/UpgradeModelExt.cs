using Assets.Scripts.Models.Towers.Upgrades;
using Assets.Scripts.Unity;

namespace BTD_Mod_Helper.Extensions
{
    public static class UpgradeModelExt
    {
        /// <summary>
        /// Return whether or not this upgrade has been unlocked by the player
        /// </summary>
        public static bool IsUpgradeUnlocked(this UpgradeModel upgradeModel)
        {
            return Game.instance.GetBtd6Player().HasUpgrade(upgradeModel.name);
        }
    }
}