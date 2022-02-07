using Assets.Scripts.Unity.UI_New.ChallengeEditor;
using BTD_Mod_Helper.Api;
using BTD_Mod_Helper.Api.ModOptions;
using BTD_Mod_Helper.Extensions;
using UnityEngine;
using Object = Il2CppSystem.Object;

namespace BTD_Mod_Helper.Menus
{
    internal class OldModSettingsMenu : ModGameMenu<ExtraSettingsScreen>
    {
        public override bool OnMenuOpened(ExtraSettingsScreen gameMenu, Object data)
        {
            var panel = gameMenu.gameObject.GetComponentInChildrenByName<RectTransform>("Panel");
            for (var i = 0; i < panel.childCount; i++)
            {
                panel.GetChild(i).gameObject.Destroy();
            }

            return false;
        }


        public override void OnMenuClosed(ExtraSettingsScreen gameMenu)
        {
            ModSettingsHandler.SaveModSettings();
            ModHelper.Msg("Successfully saved mod settings");
        }
    }
}