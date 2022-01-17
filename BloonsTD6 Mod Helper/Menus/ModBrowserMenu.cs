using System;
using Assets.Scripts.Unity.UI_New;
using Assets.Scripts.Unity.UI_New.ChallengeEditor;
using BTD_Mod_Helper.Api;
using BTD_Mod_Helper.Api.Components;
using BTD_Mod_Helper.Api.ModMenu;
using BTD_Mod_Helper.Extensions;
using Il2CppSystem.Threading.Tasks;
using UnityEngine;

namespace BTD_Mod_Helper.Menus
{
    internal class ModBrowserMenu : ModGameMenu<ExtraSettingsScreen>
    {
        private static bool modsNeedRefreshing;
        
        public override bool OnMenuOpened(ExtraSettingsScreen gameMenu, Il2CppSystem.Object data)
        {
            var panel = gameMenu.gameObject.GetComponentInChildrenByName<RectTransform>("Panel");
            for (var i = 0; i < panel.childCount; i++)
            {
                panel.GetChild(i).gameObject.Destroy();
            }

            CommonForegroundHeader.SetText("Mod Browser");
            
            
            
            if (ModHelperGithub.Mods == null)
            {
                // ReSharper disable once AsyncVoidLambda
                return false;
            }
            
            PopulateModPanels(gameMenu);
            
            return false;
        }

        public override void OnMenuUpdate(ExtraSettingsScreen gameMenu)
        {
            if (modsNeedRefreshing)
            {
                PopulateModPanels(gameMenu);
                modsNeedRefreshing = false;
            }
        }


        public static void PopulateModPanels(ExtraSettingsScreen gameMenu)
        {
            var panel = gameMenu.gameObject.GetComponentInChildrenByName<RectTransform>("Panel");
            
        }

        public static ModHelperComponent CreateModPanel(ModHelperData modHelperData)
        {
            var panel = ModHelperPanel.Create(new Info("ModPanel", 0, 0, 2500, 200));


            return panel;
        }
    }
}