using System;
using BTD_Mod_Helper.Api.Bloons;
using Il2CppAssets.Scripts.Unity.Display;
using Il2CppNinjaKiwi.Common.ResourceUtils;
namespace BTD_Mod_Helper.Api.Display;

/// <summary>
/// A ModCustomDisplay that will automatically apply to a ModBloon
/// </summary>
public abstract class ModBloonCustomDisplay : ModBloonDisplay, ICustomDisplay
{
    /// <summary>
    /// On a ModCustomDisplay, this property does nothing
    /// </summary>
    public sealed override string BaseDisplay => "";

    /// <summary>
    /// On a ModCustomDisplay, this property does nothing
    /// </summary>
    public sealed override PrefabReference BaseDisplayReference => base.BaseDisplayReference;

    /// <inheritdoc />
    public abstract string AssetBundleName { get; }

    /// <inheritdoc />
    public abstract string PrefabName { get; }

    /// <inheritdoc />
    public virtual string MaterialName => null;

    /// <inheritdoc />
    public virtual bool LoadAsync => false;

    internal override void GetBasePrototype(Factory factory, Action<UnityDisplayNode> onComplete)
    {
        this.GetBasePrototype(mod, onComplete);
    }
}

/// <inheritdoc />
public abstract class ModBloonCustomDisplay<T> : ModBloonCustomDisplay where T : ModBloon, new()
{
    /// <inheritdoc />
    public sealed override ModBloon Bloon => GetInstance<T>();
}