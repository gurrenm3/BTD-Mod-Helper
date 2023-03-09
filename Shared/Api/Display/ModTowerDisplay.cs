using BTD_Mod_Helper.Api.Towers;
using Il2CppAssets.Scripts.Models.Towers;
using Il2CppAssets.Scripts.Unity.Display;
namespace BTD_Mod_Helper.Api.Display;

/// <summary>
/// A ModDisplay that will automatically apply to a ModTower for specific tiers
/// </summary>
public abstract partial class ModTowerDisplay : ModDisplay
{
    /// <inheritdoc />
    public override void Register()
    {
        base.Register();
        try
        {
            Tower.displays.Add(this);
        }
        finally
        {
            rollbackActions.Push(() =>
            {
                Tower?.displays.Remove(this);
            });
        }
    }

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
    /// Applies this ModTowerDisplay to the towerModel. Override to change how this applies, i.e. making it
    /// apply to an AttackModel instead
    /// </summary>
    /// <param name="towerModel"></param>
    public virtual void ApplyToTower(TowerModel towerModel)
    {
        Apply(towerModel);
    }


    /// <summary>
    /// A number between 0 and 4 (inclusive) representing which set of paragon degrees this display applies to
    /// <br/>
    /// 0: Degree 1 - 20
    /// <br/>
    /// 1: Degree 21 - 40
    /// <br/>
    /// 2: Degree 41 - 60
    /// <br/>
    /// 3: Degree 61 - 80
    /// <br/>
    /// 4: Degree 81 - 100
    /// <br/>
    /// If you don't have one for every index, then the next highest one will be used
    /// </summary>
    public virtual int ParagonDisplayIndex => -1;

    /// <summary>
    /// Alters the UnityDisplayNode that was copied from the one used by <see cref="ModDisplay.BaseDisplay"/>
    /// <br/>
    /// By default, this will change the main texture of the first SkinnedMeshRenderer of the node to that of a
    /// png with the same name as the class
    /// </summary>
    /// <param name="node">The UnityDisplayNode</param>
    public override void ModifyDisplayNode(UnityDisplayNode node)
    {
        SetMeshTexture(node, Name);
    }

    /// <summary>
    /// If the tower tiers make it count as a Paragon
    /// </summary>
    /// <param name="tiers"></param>
    /// <returns></returns>
    protected bool IsParagon(int[] tiers)
    {
        return tiers[0] == 6;
    }

    /// <summary>
    /// Number of different Paragon displays that are used by default
    /// </summary>
    protected const int TotalParagonDisplays = 5;
}

/// <summary>
/// A convenient generic class for applying a ModTowerDisplay to a ModTower
/// </summary>
public abstract class ModTowerDisplay<T> : ModTowerDisplay where T : ModTower
{
    /// <inheritdoc />
    public override ModTower Tower => GetInstance<T>();
}