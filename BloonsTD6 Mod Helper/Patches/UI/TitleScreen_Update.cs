using Il2CppAssets.Scripts.Unity.Scenes;
using UnityEngine;
namespace BTD_Mod_Helper.Patches.UI;

[HarmonyPatch(typeof(TitleScreen), nameof(TitleScreen.Update))]
internal static class TitleScreen_Update
{
    private static int keyHeldCount;
    
    [HarmonyPostfix]
    internal static void Postfix(TitleScreen __instance)
    {
        keyHeldCount = Input.GetKey(KeyCode.Space) ? keyHeldCount + 1 : 0;

        if (!(Input.GetKeyDown(KeyCode.Space) || keyHeldCount > 30)) return;
        
        if (__instance.OpenAnimationFinished || __instance.SkipAnimations)
        {
            if (!__instance.playButtonClicked)
            {
                __instance.OnPlayButtonClicked();
            }
        }
        else
        {
            __instance.SkipTitleAnimClicked();
            __instance.SkipAnimations = true;
        }
    }
}