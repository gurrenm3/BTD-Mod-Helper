using Assets.Scripts.Unity.UI_New.Main;
using BTD_Mod_Helper.Api.Components;
using BTD_Mod_Helper.BTD6_UI;
using HarmonyLib;
using UnityEngine;

namespace BTD_Mod_Helper.Patches.UI
{
    [HarmonyPatch(typeof(MainMenu), nameof(MainMenu.Open))]
    internal class MainMenu_OnEnable
    {
        [HarmonyPostfix]
        internal static void Postfix()
        {
            ResetSessionData();

            var monkeysButton = MainMenuUI.GetMonkeysButton()?.gameObject;
            if (monkeysButton != null)
            {
                ModHelperButton.GlobalButtonAnimation =
                    monkeysButton.GetComponent<Animator>().runtimeAnimatorController;
            }

            ModHelper.PerformHook(mod => mod.OnMainMenu());
        }

        private static void ResetSessionData()
        {
            SessionData.Reset();
        }
    }
}