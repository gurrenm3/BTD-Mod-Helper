using Assets.Scripts.Models.Towers;

namespace BTD_Mod_Helper.Api.Towers;

/// <summary>
/// ModContent class for modifying all TowerModels for a given Tower
/// </summary>
public abstract partial class ModVanillaTower : ModVanillaContent<TowerModel>
{
    /// <summary>
    /// The base id of the Tower that this should modify all TowerModels of
    /// <br/>
    /// Use TowerType.[tower]
    /// </summary>
    public abstract string TowerId { get; }

    /// <summary>
    /// Change the name of it when it's plural
    /// </summary>
    public virtual string? DisplayNamePlural => null;

    /// <summary>
    /// Change the TowerSet that this tower is part of. Also handles moving its place within the shop.
    /// </summary>
    public virtual string? TowerSet => null;
        
    /// <summary>
    /// Changes the base cost
    /// </summary>
    public virtual int Cost => -1;

}