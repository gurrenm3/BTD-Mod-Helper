using Assets.Scripts.Models.Towers;
using Assets.Scripts.Unity.Display;
using Assets.Scripts.Unity.UI_New.InGame;
using Assets.Scripts.Unity.UI_New.InGame.StoreMenu;
using BTD_Mod_Helper.Api;
using HarmonyLib;
using System.Collections.Generic;

namespace BTD_Mod_Helper.Patches
{
    [HarmonyPatch(typeof(InputManager), nameof(InputManager.PrimeTower))]
    internal class InputManager_PrimeTower
    {
        [HarmonyPostfix]
        internal static void Postfix(InputManager __instance)
        {
            if (InGame.instance == null)
                return;

            TaskScheduler.ScheduleTask(() => { MelonMain.DoPatchMethods(mod => mod.OnTowerGraphicsCreated(__instance.placementModel, __instance.placementGraphics)); }, waitCondition: () =>
            { return __instance.placementGraphics?.Count > 0; });
        }
    }
}
