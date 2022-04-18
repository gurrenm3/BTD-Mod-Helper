using Assets.Scripts.Models.Towers;

namespace BTD_Mod_Helper.Api.Towers
{
    /// <summary>
    /// ModContent class for modifying all TowerModels that have a given upgrade applied to them
    /// </summary>
    public abstract partial class ModVanillaUpgrade : ModVanillaContent<TowerModel>
    {
        /// <summary>
        /// Changes the base cost
        /// </summary>
        public virtual int Cost => -1;
        
        /// <summary>
        /// The id of the Upgrade that this should modify all TowerModels that use
        /// <br/>
        /// Use UpgradeType.[upgrade]
        /// </summary>
        public abstract string UpgradeId { get; }
    }
}