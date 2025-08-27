using UnityEngine;
namespace BTD_Mod_Helper.Extensions;

/// <summary>
/// Extensions for AssetBundles
/// </summary>
public static class AssetBundleExt
{
    /// <summary>
    /// Synchronously loads an asset from the bundle
    /// </summary>
    public static Il2CppSystem.Object LoadAssetSync(this AssetBundle assetBundle, string assetName)
    {
        return assetBundle.LoadAssetAsync(assetName).GetResult();
    }

    /// <summary>
    /// Synchronously loads an asset from the bundle
    /// </summary>
    public static T LoadAssetSync<T>(this AssetBundle assetBundle, string assetName) where T : Il2CppObjectBase
    {
        return assetBundle.LoadAssetAsync<T>(assetName).GetResult().Cast<T>();
    }
}