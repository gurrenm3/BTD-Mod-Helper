using System;
using System.Linq;
using Assets.Scripts.Unity.Display;
using BTD_Mod_Helper.Api;
using HarmonyLib;

namespace BTD_Mod_Helper.Patches.Resources
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
            
            ModHelper.PerformHook(mod => mod.OnGameObjectsReset());
            
            ResourceHandler.Prefabs.Clear();
        }
    }
}