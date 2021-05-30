using Assets.Scripts.Models.GenericBehaviors;
using Assets.Scripts.Models.Towers;
using BTD_Mod_Helper.Api.Towers;
using BTD_Mod_Helper.Extensions;

namespace BTD_Mod_Helper.Api.Display
{
    /// <summary>
    /// A ModDisplay that will specifically be used as the main display for a ModTower
    /// </summary>
    public abstract class ModTowerDisplay : ModDisplay
    {
        /// <summary>
        /// The ModTower that this ModDisplay is used for
        /// </summary>
        public abstract ModTower Tower { get; }

        /// <summary>
        /// Returns true if this display should be used by its Tower for the given tiers
        /// </summary>
        /// <param name="tiers">The potential tiers of the tower</param>
        /// <returns>If the Tower should have this display</returns>
        public abstract bool UseForTower(int[] tiers);

        /// <summary>
        /// Applies this ModTowerDisplay to a given TowerModel
        /// </summary>
        /// <param name="towerModel"></param>
        public void Apply(TowerModel towerModel)
        {
            towerModel.display = Id;
            Apply(towerModel.GetBehavior<DisplayModel>());
        }
    }
    
    /// <summary>
    /// A convenient generic class for 
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public abstract class ModTowerDisplay<T> : ModTowerDisplay where T : ModTower
    {
        /// <inheritdoc />
        public override ModTower Tower => GetInstance<T>();
    }
}