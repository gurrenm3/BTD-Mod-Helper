using Assets.Scripts.Unity.Display;

namespace BTD_Mod_Helper.Api.Display;

/// <summary>
/// The custom version of a ModDisplay that loads in a model from a unity assetbundle
/// </summary>
public abstract class ModCustomDisplay : ModDisplay, ICustomDisplay
{
    /// <inheritdoc />
    public abstract string AssetBundleName { get; }

    /// <inheritdoc />
    public abstract string PrefabName { get; }

    /// <inheritdoc />
    public abstract string MaterialName { get; }

    /// <summary>
    /// On a ModCustomDisplay, this property does nothing
    /// </summary>
    public override string BaseDisplay => "";

    /// <summary>
    /// Performs alterations to the unity display node when it is created
    /// </summary>
    /// <param name="node"></param>
    public override void ModifyDisplayNode(UnityDisplayNode node)
    {
            
    }

}