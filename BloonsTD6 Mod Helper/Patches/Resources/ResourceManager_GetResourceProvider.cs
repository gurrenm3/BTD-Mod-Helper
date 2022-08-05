using System;
using UnhollowerRuntimeLib;
using UnityEngine;
using UnityEngine.AddressableAssets.ResourceLocators;
using UnityEngine.ResourceManagement;
using UnityEngine.ResourceManagement.ResourceLocations;
using UnityEngine.ResourceManagement.ResourceProviders;
using Type = Il2CppSystem.Type;

namespace BTD_Mod_Helper.Patches.Resources;

[HarmonyPatch(typeof(ResourceManager), nameof(ResourceManager.GetResourceProvider))]
internal static class ResourceManager_GetResourceProvider
{
    /*[HarmonyPostfix]
    private static void Postfix(ResourceManager __instance, Type t, IResourceLocation location, ref IResourceProvider __result)
    {
        if (t == Il2CppType.Of<Sprite>())
        {
            PrintInfo(location);
        }
    }

    private static void PrintInfo(IResourceLocation location)
    {
        if (location.Is(out ContentCatalogData.CompactLocation compactLocation))
        {
            MelonLogger.Msg("A CompactLocation: ");
            MelonLogger.Msg(compactLocation.m_Locator?.LocatorId);
            MelonLogger.Msg(compactLocation.m_InternalId);
            MelonLogger.Msg(compactLocation.m_ProviderId);
            MelonLogger.Msg(compactLocation.m_Dependency?.ToString() ?? "null");
            MelonLogger.Msg(compactLocation.m_Data?.ToString() ?? "null");
            MelonLogger.Msg(compactLocation.m_PrimaryKey);
            MelonLogger.Msg(compactLocation.m_Type.Name);
            MelonLogger.Msg("");
        } else if (location.Is(out ResourceLocationBase resourceLocationBase))
        {
            MelonLogger.Msg("A ResourceLocationBase: ");
            MelonLogger.Msg(resourceLocationBase.m_Name);
            MelonLogger.Msg(resourceLocationBase.m_Id);
            MelonLogger.Msg(resourceLocationBase.m_Type.Name);
            if (resourceLocationBase.m_Dependencies != null)
            {
                MelonLogger.Msg("Dependencies: ");
                foreach (var dependency in resourceLocationBase.m_Dependencies)
                {
                    PrintInfo(dependency);
                }
            }
            MelonLogger.Msg("");
        } else MelonLogger.Msg(location.TypeName());
    }*/
}