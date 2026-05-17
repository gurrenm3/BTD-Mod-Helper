using BTD_Mod_Helper.Api.Towers;
using Il2CppAssets.Scripts.Unity.Bridge;
using Il2CppAssets.Scripts.Unity.UI_New.InGame;
namespace BTD_Mod_Helper.Patches;

[HarmonyPatch(typeof(InGame), nameof(InGame.GetCustomInput), typeof(InputManager), typeof(TowerToSimulation), typeof(string),
    typeof(string))]
internal static class InGame_GetCustomInput
{
    [HarmonyPrefix]
    internal static bool Prefix(InputManager inputManager, TowerToSimulation tower, string customInputId,
        string buttonId, ref CustomInput __result)
    {
        if (!ModCustomInput.CustomInputById.TryGetValue(customInputId ?? "", out var customInput)) return true;

        __result = customInput.Activate(inputManager, tower, buttonId);
        return false;
    }
}