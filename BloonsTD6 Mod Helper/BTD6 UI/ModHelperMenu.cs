using Assets.Scripts.Unity.Menu;
using Assets.Scripts.Unity.UI_New.ChallengeEditor;
using BTD_Mod_Helper.Api;
using BTD_Mod_Helper.Api.ModOptions;
using BTD_Mod_Helper.Extensions;
using MelonLoader;
using UnityEngine;
using Object = Il2CppSystem.Object;

namespace BTD_Mod_Helper.BTD6_UI
{
    internal class ModHelperMenu : ModGameMenu
    {
        public override string BaseMenu => MenuName<ExtraSettingsScreen>();

        public override bool OnMenuOpened(GameMenu gameMenu, Object data)
        {
            var panel = gameMenu.gameObject.GetComponentInChildrenByName<RectTransform>("Panel");
            for (var i = 0; i < panel.childCount; i++)
            {
                panel.GetChild(i).gameObject.Destroy();
            }

            ModOptionsMenu.modsButton.modOptionsMenu = new ModOptionsMenu(panel);

            ModHelper.Msg($"The data is {data?.ToString()}");

            return false;
        }

        public override void OnMenuClosed(GameMenu gameMenu)
        {
            ModSettingsHandler.SaveModSettings(ModHelper.Main.GetModSettingsDir());
            ModHelper.Msg("Successfully saved mod settings");
        }
    }
}