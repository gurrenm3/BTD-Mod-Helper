using Il2CppAssets.Scripts.Unity.UI_New.Popups;
using Il2CppSystem.Threading.Tasks;
namespace BTD_Mod_Helper.Patches.Popups;

/*[HarmonyPatch(typeof(PopupScreen), nameof(PopupScreen.ShowModderPopup))]
internal class PopupScreen_ShowModderPopup
{
    [HarmonyPrefix]
    private static bool Prefix(PopupScreen __instance, ref Task<ModdingPopupChoice> __result)
    {
        __result = Task.FromResult(ModdingPopupChoice.Continue);
        return false;
    }
}*/