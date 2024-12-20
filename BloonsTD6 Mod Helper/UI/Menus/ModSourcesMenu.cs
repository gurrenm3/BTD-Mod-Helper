using BTD_Mod_Helper.Api;
using BTD_Mod_Helper.Api.Components;
using BTD_Mod_Helper.Api.Enums;
using BTD_Mod_Helper.Api.Helpers;
using Il2CppAssets.Scripts.Unity.UI_New.Popups;
using Il2CppAssets.Scripts.Unity.UI_New.Settings;
using Il2CppNinjaKiwi.Common;
using System;
using System.Collections;
using System.IO;
using System.Linq;
using Il2CppAssets.Scripts.Unity.Menu;
using UnityEngine;

namespace BTD_Mod_Helper.UI.Menus
{
    internal class ModSourcesMenu : ModGameMenu<SettingsScreen>
    {
        internal static bool ModSourcesPresent => Directory.GetFiles(MelonMain.ModSourcesFolder).Length > 0;

        private static ModHelperScrollPanel sourcesScroll;

        private static readonly string FoundModSources = ModHelper.Localize(nameof(FoundModSources), "Found Mod Sources");

        private static bool currentlyLoadingSources = false;
        
        bool IsModSource(string path)
        {
            foreach (var file in Directory.GetFiles(path))
            {
                if (Path.GetExtension(file) == ".sln")
                {
                    return true;
                }
            }

            return false;
        }

        public override bool OnMenuOpened(Il2CppSystem.Object data)
        {
            GameMenu.gameObject.DestroyAllChildren();
            CommonForegroundHeader.SetText("Mod Sources");

            var panel = GameMenu.gameObject.AddModHelperPanel(new("Panel", 0, -150, 3300, 1900), VanillaSprites.MainBGPanelBlue);

            panel.AddText(new("TitleText", 0, 850, 2000, 125), FoundModSources).EnableAutoSizing(150);

            sourcesScroll = panel.AddScrollPanel(new("ScrollPanel", 0, -150, 3000, 1500), RectTransform.Axis.Vertical, VanillaSprites.BlueInsertPanelRound, 100, 100);

            MelonCoroutines.Start(GenerateScrollContent());

            CreateExtraElements(panel);

            return true;
        }

        public IEnumerator GenerateScrollContent(string search = "")
        {
            if(currentlyLoadingSources)
            {
                PopupScreen.instance.SafelyQueue(screen => screen.ShowOkPopup("Wait until the mod sources have finished loading!"));

                yield break;
            }

            currentlyLoadingSources = true;

            sourcesScroll.ScrollContent.RectTransform.DestroyAllChildren();

            int i = 0;

            foreach (var folder in Directory.GetDirectories(MelonMain.ModSourcesFolder).OrderBy(path => path))
            {
                Sprite icon = null;
                string name = "";

                foreach(var file in Directory.GetFiles(folder))
                {
                    if(Path.GetFileName(file) == "Icon.png")
                    {
                        Texture2D iconTexture = new(2, 2);
                        iconTexture.LoadFromFile(file);

                        icon = Sprite.Create(new Rect(0, 0, iconTexture.width, iconTexture.height), new Vector2(), 10, iconTexture);
                    }

                    if(Path.GetExtension(file) == ".sln" && name == "")
                    {
                        name = Path.GetFileNameWithoutExtension(file);
                        
                    }

                    if (Closing) { currentlyLoadingSources = false; yield break; }
                }

                if (Closing) { currentlyLoadingSources = false; yield break; }

                if (name != "" && name.ToLower().Contains(search)) sourcesScroll.AddScrollContent(CreateSourcePanel(name, folder, icon));

                yield return null;
            }

            currentlyLoadingSources = false;
        }

        internal void CreateExtraElements(ModHelperPanel panel)
        {
            string searchText = "";

            var searchBtn = panel.AddButton(new("SearchBtn", -1500, 700, 175), VanillaSprites.BlueBtn, new Action(() =>
            {
                if (!string.IsNullOrEmpty(searchText) && !string.IsNullOrWhiteSpace(searchText))
                {
                    MelonCoroutines.Start(GenerateScrollContent(searchText));
                }

                MenuManager.instance.buttonClickSound.Play("ClickSounds");
            }));
            searchBtn.AddImage(new("Image", 125), VanillaSprites.SearchIcon);

            var searchBar = panel.AddInputField(new("SearchBar", -650, 700, 1500, 125), searchText, VanillaSprites.BlueInsertPanel, new Action<string>(input =>
            {
                if(input != null)
                {
                    searchText = input.ToLower();
                }
            }), 75, Il2CppTMPro.TMP_InputField.CharacterValidation.Alphanumeric, Il2CppTMPro.TextAlignmentOptions.Left, "", 20);

            var refreshButton = panel.AddButton(new("RefreshBtn", 1400, 750, 250), VanillaSprites.RestartBtn, new Action(() =>
            {
                MelonCoroutines.Start(GenerateScrollContent());
                MenuManager.instance.buttonClickSound.Play("ClickSounds");
            }));
        }

        private ModHelperPanel CreateSourcePanel(string name, string path, Sprite iconSprite)
        {
            var panel = ModHelperPanel.Create(new("SourcePanel_" + name, 2500, 600), VanillaSprites.MainBGPanelBlue);

            var nameText = panel.AddText(new("Name", 100, 100, 1500, 200), name.Localize());
            nameText.EnableAutoSizing(200);

            var pathText = panel.AddText(new("Path", 100, -100, 1500, 150), path);
            pathText.EnableAutoSizing(150);
            var openFolder = panel.AddButton(new("OpenFolderButton", 1050, 150, 250), VanillaSprites.BlueBtn, new Action(() =>
            {
                ProcessHelper.OpenFolder(path);
                MenuManager.instance.buttonClick2Sound.Play("ClickSounds");
                
            }));
            openFolder.AddImage(new("Icon", 150), GetSprite("OpenFolderIcon"));

            var openProject = panel.AddButton(new("OpenProjectBtn", 1050, -150, 250), VanillaSprites.EditBtn, new Action(
                () =>
                {
                    ProcessHelper.OpenFile(Path.Combine(path, name + ".sln"));
                    MenuManager.instance.buttonClick2Sound.Play("ClickSounds");
                }));


            // -- DOESN'T WORK-- (idk why)
            /*if (iconSprite != null)
            {
                panel.AddImage(new("Icon", -1900, 0, 500), iconSprite); 
            }*/
            
            return panel;
        }
    }
}
