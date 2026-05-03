using System;
using BTD_Mod_Helper.Api;
using BTD_Mod_Helper.Api.Internal;
using UnityEngine;
using UnityEngine.ResourceManagement.AsyncOperations;
namespace BTD_Mod_Helper.Extensions;

/// <summary>
/// Extensions for AsyncOperationHandles
/// </summary>
public static class AsyncOperationHandleExt
{
    /// <summary>
    /// Gets whether the AsyncOperationHandle is for a modded sprite
    /// </summary>
    /// <param name="handle">this</param>
    /// <param name="name">resource name of modded sprite</param>
    /// <returns>whether it's for a modded sprite or not</returns>
    public static bool IsModded(this AsyncOperationHandle<Sprite> handle, out string name)
    {
        name = null;
        if (handle?.LocationName == null ||
            !handle.LocationName.Contains(ModContent.HijackSpriteAtlas + ".spriteatlasv2")) return false;

        name = handle.LocationName[(handle.LocationName.IndexOf("[", StringComparison.Ordinal) + 1)..^1];

        return ResourceHandler.GetSprite(name) != null;
    }
}