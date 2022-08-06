using Assets.Scripts.Unity.Display;
using Assets.Scripts.Utils;
using Il2CppSystem;
using UnityEngine;
using Exception = System.Exception;

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
    public override string BaseDisplay => "";

    /// <summary>
    /// Performs alterations to the unity display node when it is created
    /// </summary>
    /// <param name="node"></param>
    public override void ModifyDisplayNode(UnityDisplayNode node)
    {
            
    }


    internal override bool Create(Factory factory, PrefabReference prefabReference, Action<UnityDisplayNode> onComplete,
        ref UnityDisplayNode prototype)
    {
        var assetBundle = GetBundle(mod, AssetBundleName);
        var gameObject = assetBundle.LoadAsset(PrefabName).Cast<GameObject>();
        var baseNode = gameObject.AddComponent<UnityDisplayNode>();
        if (!string.IsNullOrEmpty(MaterialName))
        {
            try
            {
                var material = assetBundle.LoadAsset(MaterialName).Cast<Material>();
                baseNode.genericRenderers[0].SetMaterial(material);
            }
            catch (Exception e)
            {
                ModHelper.Warning($"Failed to load custom material {MaterialName}");
                ModHelper.Warning(e);
            }
        }
        prototype = CreateNewPrototype(factory, prefabReference, baseNode);
        
        return true;
    }
}