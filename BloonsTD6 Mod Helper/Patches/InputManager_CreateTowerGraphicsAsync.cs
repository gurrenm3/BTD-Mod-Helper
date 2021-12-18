using System.Collections.Generic;
using Assets.Scripts.Unity.Display;
using Assets.Scripts.Unity.UI_New.InGame;
using BTD_Mod_Helper.Api;
using BTD_Mod_Helper.Api.Display;
using HarmonyLib;

namespace BTD_Mod_Helper.Patches
{
    [HarmonyPatch(typeof(InputManager.__c__DisplayClass118_1),
        nameof(InputManager.__c__DisplayClass118_1._CreateTowerGraphicsAsync_b__0))]
    internal class InputManager_CreateTowerGraphicsAsync
    {
        [HarmonyPrefix]
        internal static void Prefix(InputManager.__c__DisplayClass118_1 __instance, UnityDisplayNode node,
            ref ModDisplay __state)
        {
            __state = null;
            if (ModDisplay.Cache.GetValueOrDefault(__instance.display) is ModDisplay display
                && !(ResourceHandler.Prefabs.ContainsKey(__instance.display) &&
                     !ResourceHandler.Prefabs[__instance.display].isDestroyed))
            {
                __state = display;
            }
        }

        [HarmonyPostfix]
        internal static void Postfix(InputManager.__c__DisplayClass118_1 __instance, UnityDisplayNode node,
            ref ModDisplay __state)
        {
            __state?.ModifyDisplayNode(node);
        }
    }
}