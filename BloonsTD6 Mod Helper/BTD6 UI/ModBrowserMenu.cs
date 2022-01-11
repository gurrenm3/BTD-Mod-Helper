using System;
using Assets.Scripts.Unity.UI_New;
using Assets.Scripts.Unity.UI_New.ChallengeEditor;
using BTD_Mod_Helper.Api;
using BTD_Mod_Helper.Api.ModMenu;
using BTD_Mod_Helper.Extensions;
using Il2CppSystem.Threading.Tasks;
using MelonLoader;
using UnityEngine;
using Object = UnityEngine.Object;

namespace BTD_Mod_Helper.BTD6_UI
{
    internal class ModBrowserMenu : ModGameMenu<ExtraSettingsScreen>
    {
        private static bool repopulated;
        
        public override bool OnMenuOpened(ExtraSettingsScreen gameMenu)
        {
            var panel = gameMenu.gameObject.GetComponentInChildrenByName<RectTransform>("Panel");
            for (var i = 0; i < panel.childCount; i++)
            {
                panel.GetChild(i).gameObject.SetActive(false);
            }

            var heading = CommonForegroundScreen.instance.heading.GetComponentInChildren<NK_TextMeshProUGUI>();
            heading.SetText("Mod Browser");
            
            
            if (ModBrowser.Mods == null)
            {
                // ReSharper disable once AsyncVoidLambda
                Task.Run(new Action(async () =>
                {
                    await ModBrowser.PopulateMods();
                    repopulated = true;
                }));
                return false;
            }
            
            DoThings(gameMenu);
            
            return false;
        }

        public override void OnMenuUpdate(ExtraSettingsScreen gameMenu)
        {
            if (repopulated)
            {
                DoThings(gameMenu);
                repopulated = false;
            }
        }


        public static void DoThings(ExtraSettingsScreen gameMenu)
        {
            var panel = gameMenu.gameObject.GetComponentInChildrenByName<RectTransform>("Panel");
            var copyFrom = panel.GetChild(0).gameObject;

            foreach (var modBrowserMod in ModBrowser.Mods)
            {
                var newThing = Object.Instantiate(copyFrom, panel);

                newThing.GetComponentInChildren<NK_TextMeshProUGUI>().localizeKey = modBrowserMod.Name;
                
                newThing.SetActive(true);
            }
        }
    }
}