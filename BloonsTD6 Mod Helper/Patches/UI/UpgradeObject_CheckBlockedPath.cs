using BTD_Mod_Helper.Api.Towers;
using Il2CppAssets.Scripts.Unity.UI_New.InGame.TowerSelectionMenu;
namespace BTD_Mod_Helper.Patches.UI;

[HarmonyPatch(typeof(UpgradeObject), nameof(UpgradeObject.CheckBlockedPath))]
internal class UpgradeObject_CheckBlockedPath
{
    [HarmonyPostfix]
    internal static void Postfix(UpgradeObject __instance, ref int __result)
    {
        var towerModel = __instance.tts?.Def;
        if (towerModel?.GetModTower() is ModTower modTower &&
            modTower.MaxUpgradePips(__instance.tts, __instance.path, __result) is int newMax)
        {
            __result = newMax;
        }
    }
}