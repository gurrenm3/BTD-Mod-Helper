using BTD_Mod_Helper.Api.Components;
using BTD_Mod_Helper.UI.Modded;
using Il2CppAssets.Scripts.Unity.UI_New.InGame;

namespace BTD_Mod_Helper.Patches;

[HarmonyPatch(typeof(InGame), nameof(InGame.StartMatch))]
internal class InGame_StartMatch
{
    [HarmonyPostfix]
    internal static void Postfix(InGame __instance)
    {
        __instance.sceneCamera.gameObject.tag = "MainCamera";
        ModHelper.PerformHook(mod => mod.OnMatchStart());
        NotificationMgr.Initialise();
        ModHelperDock.Setup();
    }
}