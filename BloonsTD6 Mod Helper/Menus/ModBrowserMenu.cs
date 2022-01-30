using System;
using Assets.Scripts.Unity.Menu;
using Assets.Scripts.Unity.UI_New;
using Assets.Scripts.Unity.UI_New.ChallengeEditor;
using Assets.Scripts.Unity.UI_New.Coop;
using BTD_Mod_Helper.Api;
using BTD_Mod_Helper.Api.Components;
using BTD_Mod_Helper.Api.ModMenu;
using BTD_Mod_Helper.Extensions;
using Il2CppSystem.Threading.Tasks;
using UnityEngine;
using UnityEngine.UI;

namespace BTD_Mod_Helper.Menus
{
    internal class ModBrowserMenu : ModGameMenu<ContentBrowser>
    {
        private static bool modsNeedRefreshing;

        private static ModBrowserMenuMod template;

        public override bool OnMenuOpened(ContentBrowser gameMenu, Il2CppSystem.Object data)
        {
            gameMenu.GetComponentFromChildrenByName<NK_TextMeshProUGUI>("Title").SetText("Mod Browser");
            gameMenu.GetComponentFromChildrenByName<NK_TextMeshProUGUI>("SearchPlaceholder")
                .SetText("Search");

            gameMenu.GetComponentFromChildrenByName<RectTransform>("Tabs").gameObject.active = false;
            gameMenu.GetComponentFromChildrenByName<RectTransform>("CreateBtn").gameObject.active = false;

            var verticalLayoutGroup = gameMenu.scrollRect.content.GetComponent<VerticalLayoutGroup>();
            verticalLayoutGroup.SetPadding(50);
            verticalLayoutGroup.spacing = 50;
            verticalLayoutGroup.childControlWidth = true;
            verticalLayoutGroup.childControlHeight = true;

            template = gameMenu.scrollRect.content.gameObject.AddModHelperComponent(ModBrowserMenuMod.CreateTemplate());
            //template.AddLayoutElement();

            gameMenu.searchingImg.gameObject.SetActive(true);
            
            if (ModHelperGithub.Mods == null)
            {
                // ReSharper disable once AsyncVoidLambda
                modsNeedRefreshing = true;
                return false;
            }

            PopulateModPanels(gameMenu);

            return false;
        }

        public override void OnMenuUpdate(ContentBrowser gameMenu)
        {
            if (modsNeedRefreshing && ModHelperGithub.Mods != null)
            {
                PopulateModPanels(gameMenu);
                modsNeedRefreshing = false;
            }
        }

        public static void PopulateModPanels(ContentBrowser gameMenu)
        {
            foreach (var modHelperData in ModHelperGithub.Mods)
            {
                var newMod = template.Duplicate(modHelperData.Name);
                newMod.SetMod(modHelperData);
                newMod.AddTo(gameMenu.scrollRect.content);
            }
            gameMenu.searchingImg.gameObject.SetActive(false);
            gameMenu.requiresInternetObj.SetActive(false);
        }

        public static ModHelperComponent CreateModPanel(ModHelperData modHelperData)
        {
            var panel = ModHelperPanel.Create(new Info("ModPanel", 0, 0, 2500, 200));


            return panel;
        }
    }
}