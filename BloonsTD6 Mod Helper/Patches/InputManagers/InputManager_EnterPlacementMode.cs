using Il2CppAssets.Scripts;
using Il2CppAssets.Scripts.Models.Towers;
using Il2CppAssets.Scripts.Unity.UI_New.InGame;
namespace BTD_Mod_Helper.Patches.InputManagers;

[HarmonyPatch(typeof(InputManager), nameof(InputManager.EnterPlacementMode), typeof(TowerModel),
    typeof(InputManager.PositionDelegate), typeof(ObjectId), typeof(bool))]
internal static class InputManager_EnterPlacementMode
{
    [HarmonyPrefix]
    private static bool Prefix(ref TowerModel forTowerModel)
    {
        var result = true;
        var unref_forTowerModel = forTowerModel;
        ModHelper.PerformAdvancedModHook(mod => result &= mod.PreEnterPlacementMode(ref unref_forTowerModel));
        forTowerModel = unref_forTowerModel;
        return result;
    }

    [HarmonyPostfix]
    private static void Postfix(TowerModel forTowerModel)
    {
        ModHelper.PerformAdvancedModHook(mod => mod.PostEnterPlacementMode(forTowerModel));
    }
}