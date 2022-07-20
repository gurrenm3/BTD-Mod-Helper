using System;
using System.Linq;
using System.Threading.Tasks;
using Assets.Scripts.Unity.Menu;
using BTD_Mod_Helper.Api.Enums;
using BTD_Mod_Helper.Api.Helpers;
using BTD_Mod_Helper.UI.Menus;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using IntPtr = System.IntPtr;

namespace BTD_Mod_Helper.Api.Components;

[RegisterTypeInIl2Cpp(false)]
internal class ModBrowserMenuMod : ModHelperPanel
{
    public ModHelperPanel InfoPanel => GetDescendent<ModHelperPanel>("InfoPanel");
    public ModHelperButton InfoButton => GetDescendent<ModHelperButton>("Info");
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
        var mod = Create<ModBrowserMenuMod>(new Info("ModTemplate", InfoPreset.Flex), null,
            RectTransform.Axis.Vertical, 50);

        var mainPanel = mod.AddPanel(new Info("MainPanel")
        {
            Height = 200,
            FlexWidth = 1,
            Pivot = new Vector2(0.5f, 1)
        }, null, RectTransform.Axis.Horizontal, 50);

        var infoPanel = mod.AddPanel(new Info("InfoPanel")
        {
            AnchorMin = Vector2.zero,
            AnchorMax = Vector2.one
        }, VanillaSprites.BlueInsertPanel, RectTransform.Axis.Vertical, 0, 50);
        infoPanel.FitContent(vertical: ContentSizeFitter.FitMode.PreferredSize);
        infoPanel.LayoutGroup.childForceExpandWidth = true;
        infoPanel.LayoutGroup.childAlignment = TextAnchor.UpperLeft;

        var description = infoPanel.AddText(new Info("Description", InfoPreset.Flex),
            Enumerable.Repeat("Testy text", 50).Join(), 69f, TextAlignmentOptions.TopLeft);
        description.Text.font = Fonts.Btd6FontBody;
        description.Text.lineSpacing = 25;
        description.FitContent(vertical: ContentSizeFitter.FitMode.PreferredSize);

        var panel = mainPanel.AddPanel(new Info("MainPanel", InfoPreset.Flex), VanillaSprites.MainBGPanelBlue,
            RectTransform.Axis.Horizontal, 0, 50);

        var iconPanel = panel.AddPanel(new Info("IconPanel", size: 200));
        iconPanel.AddImage(new Info("Icon")
        {
            X = -ModsMenu.Padding,
            Size = ModsMenu.ModIconSize
        }, VanillaSprites.UISprite);

        panel.AddText(new Info("Name")
        {
            Height = ModsMenu.ModNameHeight,
            FlexWidth = 3
        }, "Name", ModsMenu.FontMedium, TextAlignmentOptions.CaplineLeft);

        panel.AddText(new Info("Author")
        {
            Height = ModsMenu.ModNameHeight,
            FlexWidth = 3
        }, "Author", ModsMenu.FontMedium);

        panel.AddText(new Info("Version")
        {
            Height = ModsMenu.ModNameHeight,
            FlexWidth = 1
        }, "v0.0.0", ModsMenu.FontSmall);

        var stars = panel.AddPanel(new Info("Stars")
        {
            Height = ModsMenu.ModNameHeight,
            FlexWidth = 1
        }, null, RectTransform.Axis.Horizontal, 25);
        stars.LayoutGroup.childAlignment = TextAnchor.MiddleCenter;
        stars.AddButton(new Info("Star", size: 100), VanillaSprites.Star, null);
        stars.AddText(new Info("StarCount")
        {
            Height = ModsMenu.ModNameHeight,
            FlexWidth = 1
        }, "0", ModsMenu.FontMedium, TextAlignmentOptions.CaplineLeft);


        panel.AddButton(new Info("Info", 150), VanillaSprites.InfoBtn2, null);

        mainPanel.AddButton(new Info("Homepage", 200), VanillaSprites.HomeBtn, null);

        mainPanel.AddButton(new Info("Download", 200),
            ModContent.GetSpriteReference<MelonMain>("DownloadBtn"), null);
        var update = mainPanel.AddButton(new Info("Update", size: 200), VanillaSprites.UpgradeIcon, null);
        update.AddImage(new Info("UpdateIcon", 133), VanillaSprites.UpgradeIcon2);

        mainPanel.AddImage(new Info("Installed", 200), VanillaSprites.TickGreenIcon);


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
        mod.Homepage.Button.SetOnClick(() => ProcessHelper.OpenURL(modHelperData.ReadmeUrl!));
        mod.Description.Text.SetText(modHelperData.DisplayDescription.Replace("\\n", "\n"));
        mod.InfoButton.Button.SetOnClick(() =>
        {
            mod.SetDescriptionShowing(!mod.descriptionShowing);
            MenuManager.instance.buttonClick3Sound.Play("ClickSounds");
        });
        mod.IconPanel.SetActive(false);
        mod.Name.SetText(modHelperData.DisplayName);
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
                    mod.Icon.Image.SetSprite(modHelperData.GetIcon()!);
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
                await ModHelperGithub.DownloadLatest(current, false, _ =>
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
        mod.Star.Button.SetOnClick(() => ProcessHelper.OpenURL(modHelperData.StarsUrl));

        mod.SetDescriptionShowing(false);

        mod.SetActive(true);
    }
}