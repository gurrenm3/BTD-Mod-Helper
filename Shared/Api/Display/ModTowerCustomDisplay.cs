using System;
using BTD_Mod_Helper.Api.Towers;
using Il2CppAssets.Scripts.Unity.Display;
namespace BTD_Mod_Helper.Api.Display;

/// <summary>
/// A ModCustomDisplay that will automatically apply to a ModTower for specific tiers
/// </summary>
public abstract class ModTowerCustomDisplay : ModTowerDisplay, ICustomDisplay
{
    /// <inheritdoc />
    public abstract string AssetBundleName { get; }

    /// <inheritdoc />
    public abstract string PrefabName { get; }

    /// <inheritdoc />
    public virtual string MaterialName => null;

    /// <inheritdoc />
    public virtual bool LoadAsync => false;

    /// <summary>
    /// On a ModCustomDisplay, this property does nothing
    /// </summary>
    public sealed override string BaseDisplay => "";

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

/// <summary>
/// A convenient generic class for applying a ModTowerCustomDisplay to a ModTower
/// </summary>
/// <typeparam name="T"></typeparam>
public abstract class ModTowerCustomDisplay<T> : ModTowerCustomDisplay where T : ModTower
{
    /// <inheritdoc />
    public override ModTower Tower => GetInstance<T>();
}