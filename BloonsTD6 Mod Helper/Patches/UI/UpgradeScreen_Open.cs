using Il2CppAssets.Scripts.Unity.UI_New.Upgrade;

namespace BTD_Mod_Helper.Patches.UI;

/// <summary>
/// TODO document the necessity of this
/// </summary>
[HarmonyPatch(typeof(UpgradeScreen), nameof(UpgradeScreen._Open_b__49_0))]
internal class UpgradeScreen_Open
{
    [HarmonyPrefix]
    internal static bool Prefix(UpgradeScreen __instance)
    {
        return false;
    }
}