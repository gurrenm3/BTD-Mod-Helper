using BTD_Mod_Helper.Api;
using Il2CppAssets.Scripts.Unity.UI_New.InGame.TowerSelectionMenu;

namespace BTD_Mod_Helper.Patches.UI;

/// <summary>
/// An extra fix for custom upgrade icons sometimes turning into white squares
/// </summary>
[HarmonyPatch(typeof(CurrentUpgrade), nameof(CurrentUpgrade.UpdateVisuals))]
internal static class CurrentUpgrade_UpdateVisuals
{
    [HarmonyPostfix]
    internal static void Postfix(CurrentUpgrade __instance)
    {
        TaskScheduler.ScheduleTask(() =>
        {
            if (__instance.icon != null && __instance.current != null && __instance.icon.sprite == null)
            {
                __instance.icon.LoadSprite(__instance.current.icon);
            }
        });
    }
}