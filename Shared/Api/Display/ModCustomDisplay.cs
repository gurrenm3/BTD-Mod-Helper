using System;
using Assets.Scripts.Unity.Display;
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
    /// Whether to try loading the asset from the bundle asynchronously. Not yet thoroughly tested
    /// </summary>
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
        var assetBundle = GetBundle(mod, AssetBundleName);
        if (LoadAsync)
        {
            assetBundle.LoadAssetAsync(PrefabName).add_completed(new Action<AsyncOperation>(operation =>
            {
                var request = operation.Cast<AssetBundleRequest>();
                var gameObject = request.GetResult().Cast<GameObject>();
                CompletePrototype(gameObject, assetBundle, onComplete);
            }));
        }
        else
        {
            var gameObject = assetBundle.LoadAsset(PrefabName).Cast<GameObject>();
            CompletePrototype(gameObject, assetBundle, onComplete);
        }
    }

    private void CompletePrototype(GameObject gameObject, AssetBundle assetBundle, Action<UnityDisplayNode> onComplete)
    {
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

        onComplete(baseNode);
    }
}