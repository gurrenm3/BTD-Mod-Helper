using System;
using System.Linq;
using Assets.Scripts.Unity.Display;
using BTD_Mod_Helper.Api;

namespace BTD_Mod_Helper.Patches.Resources;

[HarmonyPatch(typeof(Factory), nameof(Factory.Flush))]
internal class Factory_Flush
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