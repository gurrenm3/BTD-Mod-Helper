using Il2CppAssets.Scripts.Unity.UI_New.InGame;
using UnityEngine.EventSystems;
namespace BTD_Mod_Helper.Patches.InputManagers;

//overly complicated way to get the tower you clicked on behind boss waiting ui
//yell at grahamkracker if you know a better way
[HarmonyPatch(typeof(InputManager), nameof(InputManager.CursorUp))]
internal class InputManager_CursorUp
{
    [HarmonyPrefix]
    internal static bool Prefix()
    {
        var name = "WaitPanelScroll";

        foreach (var raycastResult in InGame.instance.raycastResults) //cant use linq because "System.ArgumentException: Delegate has parameter of type UnityEngine.EventSystems.RaycastResult (non-blittable struct) which is not supported"
        {
            if (raycastResult.gameObject.name.Equals(name))
            {
                var inputManager = InGame.instance.InputManager;
                var tower = InGame.Bridge.GetSelection(inputManager.cursorPositionWorld, 20f);
                if (tower != null &&
                    !inputManager.inPlacementMode &&
                    !inputManager.IsInPlacementMode &&
                    !inputManager.inCustomMode &&
                    !inputManager.inInstaMode &&
                    !inputManager.inPowerMode &&
                    !inputManager.inTowerMode &&
                    !inputManager.inGeraldoShopItemMode &&
                    !inputManager.inMapEditorItemPlacementMode &&
                    !inputManager.inMapEditorStampPlacementMode)
                {
                    inputManager.SetSelected(tower);
                    return false;
                }
            }
        }
        return true;
    }
}