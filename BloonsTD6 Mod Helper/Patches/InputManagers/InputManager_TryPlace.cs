using BTD_Mod_Helper.Api.Towers;
using Il2CppAssets.Scripts.Unity.Bridge;
using Il2CppAssets.Scripts.Unity.UI_New.InGame;
namespace BTD_Mod_Helper.Patches.InputManagers;

[HarmonyPatch(typeof(InputManager), nameof(InputManager.TryPlace))]
internal static class InputManager_TryPlace
{
    [HarmonyPrefix]
    internal static bool Prefix(InputManager __instance)
    {
        if (!__instance.inTowerMode || __instance.towerModel?.GetModTower() is not ModFakeTower fakeTower) return true;

        var at = __instance.CursorPositionWorld;
        var tower = InGame.Bridge.GetSelection(at, 20).Is(out TowerToSimulation tts) ? tts.tower : null;

        string helpMessage = null;
        if (fakeTower.CanPlaceAt(at, tower, ref helpMessage))
        {
            fakeTower.Purchase(at, __instance.towerModel, tower);

            __instance.towerButton?.SetDirty();
            __instance.ExitPlacementMode();
            __instance.ExitTowerMode();
        }
        else if (!string.IsNullOrEmpty(helpMessage))
        {
            __instance.SetHelperMessage(helpMessage, 3);
        }

        return false;

    }
}