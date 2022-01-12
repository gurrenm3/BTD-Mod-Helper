using Assets.Scripts.Unity.UI_New.Main;
using BTD_Mod_Helper.Api.Components;
using BTD_Mod_Helper.BTD6_UI;
using HarmonyLib;
using UnityEngine;

namespace BTD_Mod_Helper.Patches.UI
{
    [HarmonyPatch(typeof(MainMenu), nameof(MainMenu.Open))]
    internal class MainMenu_Open
    {
        [HarmonyPostfix]
        internal static void Postfix()
        {
            ResetSessionData();

            var monkeysButton = MainMenuUI.GetMonkeysButton()?.gameObject;
            if (monkeysButton != null)
            {
                ModHelperText.luckiestGuy = monkeysButton.GetComponentInChildren<NK_TextMeshProUGUI>().font;
            }

            var exitButton = MainMenuUI.GetExitButton()?.gameObject;
            if (exitButton != null)
            {
                ModHelperButton.globalButtonAnimation =
                    exitButton.GetComponent<Animator>().runtimeAnimatorController;
            }

            ModHelper.PerformHook(mod => mod.OnMainMenu());
        }

        private static void ResetSessionData()
        {
            SessionData.Reset();
        }
    }
}