using Assets.Scripts.Unity.UI_New.InGame;
using BTD_Mod_Helper.Api;
using HarmonyLib;

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

            TaskScheduler.ScheduleTask(() => { MelonMain.PerformHook(mod => mod.OnTowerGraphicsCreated(__instance.placementModel, __instance.placementGraphics)); }, waitCondition: () =>
            { return __instance.placementGraphics?.Count > 0; });
        }
    }
}
