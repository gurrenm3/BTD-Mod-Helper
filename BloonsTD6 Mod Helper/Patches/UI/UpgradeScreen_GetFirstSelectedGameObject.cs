using Il2CppAssets.Scripts.Unity.UI_New.Upgrade;
namespace BTD_Mod_Helper.Patches.UI;

/// <summary>
/// Stop the first object in the top upgrade row from being automatically selected, since it may not exist for modded
/// towers
/// </summary>
[HarmonyPatch(typeof(UpgradeScreen), nameof(UpgradeScreen.GetFirstSelectedGameObject))]
internal class UpgradeScreen_GetFirstSelectedGameObject
{
    [HarmonyPrefix]
    internal static bool Prefix(UpgradeScreen __instance) => false;
}
