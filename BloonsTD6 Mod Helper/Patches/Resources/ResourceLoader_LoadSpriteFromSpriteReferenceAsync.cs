using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using Assets.Scripts.Unity.Tasks;
using Assets.Scripts.Utils;
using BTD_Mod_Helper.Api;
using BTD_Mod_Helper.Extensions;
using HarmonyLib;
using Il2CppSystem.Collections;
using MelonLoader;
using UnhollowerBaseLib;
using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.ResourceManagement;
using UnityEngine.ResourceManagement.AsyncOperations;
using UnityEngine.ResourceManagement.ResourceLocations;
using UnityEngine.U2D;
using UnityEngine.UI;

namespace BTD_Mod_Helper.Patches.Resources
{
    [HarmonyPatch(typeof(ResourceLoader), nameof(ResourceLoader.LoadSpriteFromSpriteReferenceAsync))]
    internal class ResourceLoader_LoadSpriteFromSpriteReferenceAsync
    {
        /*
        [HarmonyPrefix]
        internal static bool Prefix(SpriteReference reference, Image image)
        {
            if (reference is null || image is null || reference.GUID is null)
                return true;

            var guid = reference.GUID;

            if (ResourceHandler.GetSprite(guid) is Sprite spr)
            {
                spr.texture.mipMapBias = -1;
                image.SetSprite(spr);
                return false;
            }

            return true;
        }
        */
    }
}