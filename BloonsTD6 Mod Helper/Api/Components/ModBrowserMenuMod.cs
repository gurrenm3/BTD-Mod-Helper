using System;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using BTD_Mod_Helper.Api.Enums;
using BTD_Mod_Helper.Extensions;
using BTD_Mod_Helper.Menus;
using HarmonyLib;
using MelonLoader;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using IntPtr = System.IntPtr;

namespace BTD_Mod_Helper.Api.Components
{
    [RegisterTypeInIl2Cpp(false)]
    internal class ModBrowserMenuMod : ModHelperPanel
    {
        public ModHelperPanel InfoPanel => GetDescendent<ModHelperPanel>("InfoPanel");
        public ModHelperButton Info => GetDescendent<ModHelperButton>("Info");
        public ModHelperButton Homepage => GetDescendent<ModHelperButton>("Homepage");
        public ModHelperButton Download => GetDescendent<ModHelperButton>("Download");
        public ModHelperButton Update => GetDescendent<ModHelperButton>("Update");
        public ModHelperText Description => GetDescendent<ModHelperText>("Description");
        public ModHelperPanel IconPanel => GetDescendent<ModHelperPanel>("IconPanel");
        public ModHelperImage Icon => GetDescendent<ModHelperImage>("Icon");
        public ModHelperText Name => GetDescendent<ModHelperText>("Name");
        public ModHelperText Author => GetDescendent<ModHelperText>("Author");
        public ModHelperText Version => GetDescendent<ModHelperText>("Version");
        public ModHelperImage Installed => GetDescendent<ModHelperImage>("Installed");
        public ModHelperButton Star => GetDescendent<ModHelperButton>("Star");
        public ModHelperText StarCount => GetDescendent<ModHelperText>("StarCount");

        public bool descriptionShowing;

        public Action iconAction;

        public ModBrowserMenuMod(IntPtr ptr) : base(ptr)
        {
        }

        public static ModBrowserMenuMod CreateTemplate()
        {
            var mod = Create<ModBrowserMenuMod>(
                new Info("ModTemplate", flex: 1), null, RectTransform.Axis.Vertical, 50
            );

            var mainPanel = mod.AddPanel(
                new Info("MainPanel", height: 200, flexWidth: 1,
                    pivot: new Vector2(0.5f, 1)), null, RectTransform.Axis.Horizontal, 50
            );

            var infoPanel = mod.AddPanel(new Info("InfoPanel", anchorMin: Vector2.zero, anchorMax: new Vector2(1, 0)),
                VanillaSprites.BlueInsertPanel, RectTransform.Axis.Vertical, 0, 50);
            infoPanel.FitContent(vertical: ContentSizeFitter.FitMode.PreferredSize);
            infoPanel.LayoutGroup.childForceExpandWidth = true;
            infoPanel.LayoutGroup.childAlignment = TextAnchor.UpperLeft;

            var description = infoPanel.AddText(
                new Info("Description", flex: 1), Enumerable.Repeat("Testy text", 50).Join(), 69f,
                TextAlignmentOptions.TopLeft
            );
            description.Text.font = Fonts.Btd6FontBody;
            description.Text.lineSpacing = 25;
            description.FitContent(vertical: ContentSizeFitter.FitMode.PreferredSize);

            var panel = mainPanel.AddPanel(new Info("MainPanel", flex: 1), VanillaSprites.MainBGPanelBlue,
                RectTransform.Axis.Horizontal, 0, 50);

            var iconPanel = panel.AddPanel(new Info("IconPanel", size: 200));
            iconPanel.AddImage(
                new Info("Icon", -ModsMenu.Padding, size: ModsMenu.ModIconSize), VanillaSprites.UISprite
            );

            panel.AddText(new Info("Name", height: ModsMenu.ModNameHeight, flexWidth: 3), "Name",
                ModsMenu.FontMedium, TextAlignmentOptions.MidlineLeft);

            panel.AddText(new Info("Author", height: ModsMenu.ModNameHeight, flexWidth: 3), "Author",
                ModsMenu.FontMedium);

            panel.AddText(
                new Info("Version", height: ModsMenu.ModNameHeight, flexWidth: 1), "v0.0.0", ModsMenu.FontSmall
            );

            var stars = panel.AddPanel(new Info("Stars", height: ModsMenu.ModNameHeight, flexWidth: 1), null,
                RectTransform.Axis.Horizontal, 25);
            stars.LayoutGroup.childAlignment = TextAnchor.MiddleCenter;
            stars.AddButton(new Info("Star", size: 100), VanillaSprites.Star, null);
            stars.AddText(new Info("StarCount", height: ModsMenu.ModNameHeight, flexWidth: 1), "0", ModsMenu.FontMedium,
                TextAlignmentOptions.MidlineLeft);


            panel.AddButton(new Info("Info", size: 150), VanillaSprites.InfoBtn2, null);

            mainPanel.AddButton(new Info("Homepage", size: 200), VanillaSprites.HomeBtn, null);

            mainPanel.AddButton(new Info("Download", size: 200),
                ModContent.GetSpriteReference<MelonMain>("DownloadBtn"), null);
            mainPanel.AddButton(new Info("Update", size: 200), VanillaSprites.UpgradeIcon, null);

            mainPanel.AddImage(new Info("Installed", size: 200), VanillaSprites.TickGreenIcon);


            mod.SetDescriptionShowing(false);
            mod.SetActive(false);
            return mod;
        }

        public void SetDescriptionShowing(bool showing)
        {
            InfoPanel.SetActive(showing);
            descriptionShowing = showing;
        }

        protected override void OnUpdate()
        {
            // Needs to run on the main thread and not in a task
            if (iconAction != null)
            {
                iconAction.Invoke();
                iconAction = null;
            }
        }
    }

    internal static class ModBrowserMenuModExt
    {
        public static void SetMod(this ModBrowserMenuMod mod, ModHelperData modHelperData)
        {
            mod.Homepage.Button.SetOnClick(() =>
                Process.Start($"https://github.com/{modHelperData.RepoOwner}/{modHelperData.RepoName}#readme"));
            mod.Description.SetText(modHelperData.Description);
            mod.Info.Button.SetOnClick(() => mod.SetDescriptionShowing(!mod.descriptionShowing));
            mod.IconPanel.SetActive(false);
            mod.Name.SetText(modHelperData.Name);
            mod.Version.SetText("v" + modHelperData.Version);
            mod.Author.SetText(modHelperData.Author ?? modHelperData.RepoOwner);
            mod.Author.Text.color = BlatantFavoritism.GetColor(modHelperData.RepoOwner);

            Task.Run(async () =>
            {
                var success = await modHelperData.LoadIconFromRepoAsync();
                if (success)
                {
                    mod.iconAction = () =>
                    {
                        mod.IconPanel.SetActive(true);
                        mod.Icon.Image.SetSprite(modHelperData.GetIcon());
                    };
                }
            });

            var installed = modHelperData.ModInstalledLocally(out var current);
            mod.Download.Button.SetOnClick(() =>
            {
                Task.Run(async () =>
                {
                    await ModHelperGithub.DownloadLatest(modHelperData, false, filePath =>
                    {
                        modHelperData.SetFilePath(filePath);
                        ModHelperData.Inactive.Add(modHelperData);
                        mod.Download.SetActive(false);
                        mod.Installed.SetActive(true);
                    });
                });
            });
            mod.Update.Button.SetOnClick(() =>
            {
                Task.Run(async () =>
                {
                    await ModHelperGithub.DownloadLatest(current, false, filePath =>
                    {
                        mod.Update.SetActive(false);
                        mod.Installed.SetActive(true);
                    });
                });
            });
            mod.Download.SetActive(!installed);
            mod.Update.SetActive(installed && current.UpdateAvailable);
            mod.Installed.SetActive(installed && !current.UpdateAvailable);

            mod.StarCount.SetText($"{modHelperData.Repository.StargazersCount}");
            mod.Star.Button.SetOnClick(() =>
                Process.Start($"https://www.github.com/{modHelperData.RepoOwner}/{modHelperData.RepoName}/stargazers"));

            mod.SetActive(true);
        }
    }
}