using System;
using BTD_Mod_Helper.Api;
using BTD_Mod_Helper.Api.Internal;
using Il2CppNinjaKiwi.Common.ResourceUtils;
using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.ResourceManagement.AsyncOperations;

namespace BTD_Mod_Helper.Patches.Resources;

/// <summary>
/// Fixes a weird bug that cropped up with v45 where custom sprites wouldn't always finish loading
/// <br/>
/// TODO investigate this further, fix initial flash of white square?
/// </summary>
[HarmonyPatch(typeof(ResourceLoader), nameof(ResourceLoader.OnSpriteLoaded))]
internal static class ResourceLoader_OnSpriteLoaded
{
    [HarmonyPrefix]
    internal static void Prefix(ref AsyncOperationHandle<Sprite> handle)
    {
        if (handle.Succeeded() &&
            handle.Result == null &&
            handle.LocationName.Contains(ModContent.HijackSpriteAtlas + ".spriteatlasv2"))
        {
            var name = handle.LocationName
                [(handle.LocationName.IndexOf("[", StringComparison.Ordinal) + 1)..^1];
            if (ResourceHandler.GetSprite(name) is Sprite spr)
            {
                handle = Addressables.Instance.ResourceManager.CreateCompletedOperation(spr, "");
            }
        }

    }
}