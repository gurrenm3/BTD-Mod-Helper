using System.Collections.Generic;
using Assets.Scripts.Models.Towers;
using Assets.Scripts.Models.Towers.Behaviors;
using Assets.Scripts.Models.Towers.Upgrades;
using Assets.Scripts.Unity;
using BTD_Mod_Helper.Extensions;

namespace BTD_Mod_Helper.Api.Towers
{
    /// <summary>
    /// Defines the Paragon Upgrade for a ModTower. Remember to set the <see cref="ModTower.ParagonMode"/> property.
    /// </summary>
    public abstract class ModParagonUpgrade : ModUpgrade
    {
        /// <summary>
        /// Specifically use the paragon upgrade naming scheme
        /// </summary>
        public override string Name => $"{Tower.Name} Paragon";

        /// <summary>
        /// Override the ID to not have the prefix. It's necessary to work, and there's not a good way for
        /// different paragon mods to coexist anyway
        /// </summary>
        protected internal override string ID => Tower is ModVanillaParagon ? Name : base.ID;

        /// <summary>
        /// No changing of ModParagonUpgrade path
        /// </summary>
        public sealed override int Path => -1;

        /// <summary>
        /// No changing of ModParagonUpgrade tier
        /// </summary>
        public sealed override int Tier => 6;

        /// <summary>
        /// No loading of multiple ModParagonUpgrades
        /// </summary>
        public sealed override IEnumerable<ModContent> Load()
        {
            return base.Load();
        }

        /// <summary>
        /// The ParagonTowerModel that this will use as a base. You don't need to worry about displayDegreePaths
        /// </summary>
        public virtual ParagonTowerModel ParagonTowerModel => Game.instance.model
            .GetTowerWithName($"{TowerType.BoomerangMonkey}-Paragon").GetBehavior<ParagonTowerModel>();

        /// <summary>
        /// By default, remove any abilities from the Paragon tower
        /// </summary>
        public virtual bool RemoveAbilities => true;


        /// <inheritdoc />
        public override UpgradeModel GetUpgradeModel()
        {
            var model = base.GetUpgradeModel();
            model.confirmation = "Paragon";
            return model;
        }
    }

    /// <summary>
    /// A convenient generic class for specifying the ModTower that this ModParagonUpgrade is for
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public abstract class ModParagonUpgrade<T> : ModParagonUpgrade where T : ModTower
    {
        /// <inheritdoc />
        public override ModTower Tower => GetInstance<T>();
    }
}