using BTD_Mod_Helper.Api.Internal;
using Il2CppNinjaKiwi.Common.ResourceUtils;
using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.ResourceManagement.AsyncOperations;

namespace BTD_Mod_Helper.Patches.Resources;

/// <summary>
/// Fixes white square issues from modded sprites failing to load
/// </summary>
[HarmonyPatch(typeof(ResourceLoader), nameof(ResourceLoader.OnSpriteLoaded))]
internal static class ResourceLoader_OnSpriteLoaded
{
    [HarmonyPrefix]
    internal static void Prefix(ResourceLoader.ISpriteRenderer image, ref AsyncOperationHandle<Sprite> handle)
    {
        if (!handle.Succeeded() || !handle.IsModded(out var name)) return;

        // If it mistakenly thinks the image loading succeeded when it actually didn't
        if (handle.Result == null && ResourceHandler.GetSprite(name) is Sprite spr)
        {
            handle = Addressables.Instance.ResourceManager.CreateCompletedOperation(spr, "");
        }

        // If it has a sprite releaser, the sprite will be eventually destroyed, so we don't want it in the cache anymore
        if (image.Valid && image.gameObject.HasComponent<SpriteReleaser>())
        {
            ResourceHandler.SpriteCache.Remove(name);
        }
    }
}