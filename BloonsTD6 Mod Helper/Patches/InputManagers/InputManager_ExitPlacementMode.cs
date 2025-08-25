using BTD_Mod_Helper.Api.Towers;
using Il2CppAssets.Scripts.Unity.UI_New;
using Il2CppAssets.Scripts.Unity.UI_New.InGame;
namespace BTD_Mod_Helper.Patches.InputManagers;

[HarmonyPatch(typeof(InputManager), nameof(InputManager.ExitPlacementMode))]
internal class InputManager_ExitPlacementMode
{
    [HarmonyPostfix]
    internal static void Postfix()
    {
        if (ModFakeTower.lastHighlightTower != null)
        {
            ModFakeTower.lastHighlightTower.UnHighlight();
            ModFakeTower.lastHighlightTower = null;
        }

        if (InGameObjects.instance.powerIcon != null)
        {
            InGameObjects.instance.IconEnd();
        }
    }
}