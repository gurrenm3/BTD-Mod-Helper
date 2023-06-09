using System;
using Il2CppAssets.Scripts.Unity.Display;
using UnityEngine;
namespace BTD_Mod_Helper.Api.Display;

internal interface ICustomDisplay
{
    /// <summary>
    /// The name of the asset bundle file that the model is in, not including the .bundle extension
    /// </summary>
    string AssetBundleName { get; }

    /// <summary>
    /// The name of the prefab that the model has within the Asset Bundle
    /// </summary>
    string PrefabName { get; }

    /// <summary>
    /// The name of the material that should be applied to the tower from the asset bundle, if any
    /// </summary>
    string MaterialName { get; }

    /// <summary>
    /// Whether to try loading the asset from the bundle asynchronously.
    /// </summary>
    bool LoadAsync { get; }
}

internal static class ICustomDisplayExt
{
    /// <summary>
    /// Gets the base prototype from an asset bundle and given prefab name
    /// </summary>
    /// <param name="display">this</param>
    /// <param name="mod">mod to look for the asset bundle in</param>
    /// <param name="onComplete">completion action</param>
    internal static void GetBasePrototype(this ICustomDisplay display, BloonsTD6Mod mod,
        Action<UnityDisplayNode> onComplete)
    {
        var assetBundle = ModContent.GetBundle(mod, display.AssetBundleName);
        if (display.LoadAsync)
        {
            assetBundle.LoadAssetAsync(display.PrefabName).add_completed(new Action<AsyncOperation>(operation =>
            {
                var request = operation.Cast<AssetBundleRequest>();
                var gameObject = request.GetResult().Cast<GameObject>();
                CompletePrototype(display, gameObject, assetBundle, onComplete);
            }));
        }
        else
        {
            var gameObject = assetBundle.LoadAsset(display.PrefabName).Cast<GameObject>();
            CompletePrototype(display, gameObject, assetBundle, onComplete);
        }
    }

    /// <summary>
    /// Finishes setting up the prototype, possible applying the material
    /// </summary>
    /// <param name="display">this</param>
    /// <param name="gameObject">the prototype game object</param>
    /// <param name="assetBundle">the assetbundle in question</param>
    /// <param name="onComplete">completion action</param>
    internal static void CompletePrototype(this ICustomDisplay display, GameObject gameObject, AssetBundle assetBundle,
        Action<UnityDisplayNode> onComplete)
    {
        gameObject.transform.position = new Vector3(Factory.kOffscreenPosition.x, 0, 0);
        gameObject.SetActive(false);
        var baseNode = gameObject.AddComponent<UnityDisplayNode>();
        if (!string.IsNullOrEmpty(display.MaterialName))
        {
            try
            {
                var material = assetBundle.LoadAsset(display.MaterialName).Cast<Material>();
                baseNode.genericRenderers[0].SetMaterial(material);
            }
            catch (Exception e)
            {
                ModHelper.Warning($"Failed to load custom material {display.MaterialName}");
                ModHelper.Warning(e);
            }
        }

        onComplete(baseNode);
    }
}