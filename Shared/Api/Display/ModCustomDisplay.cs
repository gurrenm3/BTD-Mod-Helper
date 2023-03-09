using System;
using Il2CppAssets.Scripts.Unity.Display;
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
    public virtual string MaterialName => null;

    /// <summary>
    /// On a ModCustomDisplay, this property does nothing
    /// </summary>
    public sealed override string BaseDisplay => "";

    /// <inheritdoc />
    public virtual bool LoadAsync => false;

    /// <summary>
    /// Performs alterations to the unity display node when it is created
    /// </summary>
    /// <param name="node"></param>
    public override void ModifyDisplayNode(UnityDisplayNode node)
    {

    }

    internal override void GetBasePrototype(Factory factory, Action<UnityDisplayNode> onComplete)
    {
        this.GetBasePrototype(mod, onComplete);
    }
}