using Il2CppAssets.Scripts.Models.GenericBehaviors;
using Il2CppAssets.Scripts.Models.Towers;
using Il2CppAssets.Scripts.Simulation.SMath;
using Il2CppAssets.Scripts.Unity.Display;
namespace BTD_Mod_Helper.Api.Display;

/// <summary>
/// Mod Display specifically set up to be a 2d image 
/// </summary>
public abstract class ModDisplay2D : ModDisplay
{
    /// <inheritdoc />
    public sealed override string BaseDisplay => Generic2dDisplay;

    /// <summary>
    /// The file name (no .png) from your mod that you want to use as the 2d texture
    /// </summary>
    protected abstract string TextureName { get; }

    /// <inheritdoc />
    public override void Apply(TowerModel towerModel)
    {
        base.Apply(towerModel);
        towerModel.GetBehavior<DisplayModel>().positionOffset = new Vector3(0, 0, 2f);
    }

    /// <inheritdoc />
    public override void ModifyDisplayNode(UnityDisplayNode node)
    {
        Set2DTexture(node, TextureName);
        node.towerPlacementPreCalcOffset = new UnityEngine.Vector3(0, 2f, 0);
    }
}