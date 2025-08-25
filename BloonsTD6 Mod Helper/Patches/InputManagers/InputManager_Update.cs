using BTD_Mod_Helper.Api.Towers;
using Il2CppAssets.Scripts.Unity.Bridge;
using Il2CppAssets.Scripts.Unity.UI_New;
using Il2CppAssets.Scripts.Unity.UI_New.InGame;

namespace BTD_Mod_Helper.Patches.InputManagers;

[HarmonyPatch(typeof(InputManager), nameof(InputManager.Update))]
internal static class InputManager_Update
{
    [HarmonyPostfix]
    internal static void Postfix(InputManager __instance)
    {
        if (!__instance.inTowerMode || __instance.towerModel?.GetModTower() is not ModFakeTower fakeTower) return;

        var at = __instance.CursorPositionWorld;

        var tower = InGame.Bridge.GetSelection(at, 20).Is(out TowerToSimulation tts) ? tts.tower : null;

        string fake = null;
        var applies = fakeTower.CanPlaceAt(at, tower, ref fake);

        InGameObjects.instance.IconUpdate(InputManager.GetCursorPosition(), applies);

        if (!fakeTower.HighlightTowers)
        {
            ModFakeTower.lastHighlightTower = null;
            return;
        }

        if (ModFakeTower.lastHighlightTower != null && !(applies && tower == ModFakeTower.lastHighlightTower))
        {
            if (ModFakeTower.lastHighlightTower.IsSelectable)
            {
                ModFakeTower.lastHighlightTower.UnHighlight();
            }
        }
        if (applies && tower != null && tower != ModFakeTower.lastHighlightTower)
        {
            if (tower.IsSelectable)
            {
                tower.Hilight();
            }
        }
        ModFakeTower.lastHighlightTower = applies ? tower : null;
    }
}