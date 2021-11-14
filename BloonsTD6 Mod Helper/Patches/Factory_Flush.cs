using System;
using System.Linq;
using Assets.Scripts.Unity;
using Assets.Scripts.Unity.Display;
using Assets.Scripts.Unity.UI_New.InGame;
using BTD_Mod_Helper.Api;
using BTD_Mod_Helper.Extensions;
using HarmonyLib;
using MelonLoader;

namespace BTD_Mod_Helper.Patches
{
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
            
            MelonMain.PerformHook(mod => mod.OnGameObjectsReset());

            ResourceHandler.Prefabs.Clear();
        }
    }

}