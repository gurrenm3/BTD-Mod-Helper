using Assets.Scripts.Unity.UI_New.Upgrade;
using HarmonyLib;

namespace BTD_Mod_Helper.Patches.UI
{
    [HarmonyPatch(typeof(UpgradeScreen), nameof(UpgradeScreen._Open_b__49_0))]
    internal class UpgradeScreen_Open
    {
        [HarmonyPrefix]
        internal static bool Prefix(UpgradeScreen __instance)
        {
            return false;
        }
    }
}