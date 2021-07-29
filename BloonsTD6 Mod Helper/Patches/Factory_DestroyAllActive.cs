using System;
using System.Linq;
using Assets.Scripts.Unity.Display;
using BTD_Mod_Helper.Api;
using HarmonyLib;
using MelonLoader;

namespace BTD_Mod_Helper.Patches
{
    [HarmonyPatch(typeof(Factory), nameof(Factory.DestroyAllActive))]
    internal class Factory_DestroyAllActive
    {
        [HarmonyPostfix]
        internal static void Postfix(Factory __instance)
        {
            foreach (var unityDisplayNode in ResourceHandler.Prefabs.Values
                .Where(unityDisplayNode => unityDisplayNode != null && !unityDisplayNode.isDestroyed))
            {
                try
                {
                    unityDisplayNode.Destroy();
                }
                catch (Exception)
                {
                    // ignored
                }
            }
            ResourceHandler.Prefabs.Clear();
        }
    }
}