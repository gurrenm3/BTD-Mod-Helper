#if BloonsTD6
using System.Text.RegularExpressions;
using Assets.Scripts.Models.Towers;
using Assets.Scripts.Models.Towers.Upgrades;
using Assets.Scripts.Utils;

namespace BTD_Mod_Helper.Api.Towers
{
    /// <summary>
    /// A class used to create an Upgrade for a Tower
    /// </summary>
    public abstract class ModUpgrade : ModContent
    {
        private UpgradeModel upgradeModel;

        private static SpriteReference DefaultIcon => CreateSpriteReference("aa0cb2e090ae15a478243899824ad4b1");
        
        /// <summary>
        /// Path ID for the Top path
        /// </summary>
        protected const int TOP = 0;
        /// <summary>
        /// Path ID for the Middle path
        /// </summary>
        protected const int MIDDLE = 1;
        /// <summary>
        /// Path ID for the Bottom path
        /// </summary>
        protected const int BOTTOM = 2;
        
        /// <summary>
        /// The actual name that should be displayed for the tower
        /// </summary>
        public virtual string DisplayName => Regex.Replace(Name, "(\\B[A-Z])", " $1");
        
        /// <summary>
        /// The file name without extension for the Portrait for this upgrade
        ///
        /// By default is the same file name as the tower followed by -Portrait
        /// </summary>
        public virtual string Portrait => Name + "-Portrait";
        
        /// <summary>
        /// The file name without extension for the Icon for this upgrade
        ///
        /// The Tower follows the default Bloons method of picking a Portrait: choose the highest tier upgrade, and if
        /// there's a tie, choose Mid > Top > Bot (for whatever reason)
        ///
        /// By default is the same file name as the tower followed by -Icon
        /// </summary>
        public virtual string Icon => Name + "-Icon";
        
        /// <summary>
        /// Custom priority to make this upgrade applied sooner (increased priority) or later (decreased priority)
        /// when the TowerModel is being constructed
        /// </summary>
        public virtual int Priority => 0;

        /// <summary>
        /// The upgrade path
        /// Use <see cref="TOP"/>, <see cref="MIDDLE"/>, <see cref="BOTTOM"/>
        /// </summary>
        public abstract int Path { get; }
        
        /// <summary>
        /// The upgrade tier, 1 for Tier 1 Upgrades, 2 for Tier 2, etc...
        /// </summary>
        public abstract int Tier { get; }
        
        /// <summary>
        /// How much the upgrade costs on Medium difficulty
        /// </summary>
        public abstract int Cost { get; }
        
        /// <summary>
        /// The tower that this is an upgrade for
        /// </summary>
        public abstract ModTower Tower { get; }
        
        /// <summary>
        /// The description of this upgrade
        /// </summary>
        public abstract string Description { get; }

        /// <summary>
        /// Apply the effects that this upgrade has onto a TowerModel
        /// 
        /// The TowerModel's tier(s), applied upgrades and other info will already be correct, so this is mostly about
        /// changing the TowerModel's behavior
        ///
        /// The default ordering of upgrade application is to do the Top path upgrades in ascending order, then the
        /// middle path and finally the bottom path. This can be changed using <see cref="Priority"/>.
        /// </summary>
        /// <param name="towerModel"></param>
        public abstract void ApplyUpgrade(TowerModel towerModel);



        /// <summary>
        /// If you really need to override the way that the ModUpgrade makes its UpgradeModel, go ahead
        /// </summary>
        /// <returns></returns>
        public virtual UpgradeModel GetUpgradeModel()
        {
            if (upgradeModel == null)
            {
                upgradeModel = new UpgradeModel(Id, Cost, 0, GetSpriteReference(mod, Icon) ?? DefaultIcon, 
                    Path, Tier - 1, 0, "", "");
                
                FileIOUtil.SaveObject($"Upgrades\\{upgradeModel.name}.json", upgradeModel);
            }

            return upgradeModel;
        }
        
    }


    /// <summary>
    /// A convenient generic class for specifying the ModTower that this ModUpgrade is for
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public abstract class ModUpgrade<T> : ModUpgrade where T : ModTower
    {
        /// <inheritdoc />
        public override ModTower Tower => GetInstance<T>();
    }
}
#endif