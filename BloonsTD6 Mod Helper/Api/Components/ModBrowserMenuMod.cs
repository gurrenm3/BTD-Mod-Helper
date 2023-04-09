using System;
using System.Linq;
using System.Threading.Tasks;
using BTD_Mod_Helper.Api.Enums;
using BTD_Mod_Helper.Api.Helpers;
using BTD_Mod_Helper.UI.BTD6;
using BTD_Mod_Helper.UI.Menus;
using Il2CppAssets.Scripts.Unity.Menu;
using Il2CppAssets.Scripts.Unity.UI_New.Popups;
using Il2CppTMPro;
using UnityEngine;
using UnityEngine.UI;
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
    public ModHelperPanel LackOfIconPanel => GetDescendent<ModHelperPanel>("LackOfIconPanel");
    public ModHelperImage Icon => GetDescendent<ModHelperImage>("Icon");
    public ModHelperText Name => GetDescendent<ModHelperText>("Name");
    public ModHelperText Author => GetDescendent<ModHelperText>("Author");
    public ModHelperText Version => GetDescendent<ModHelperText>("Version");
    public ModHelperImage Installed => GetDescendent<ModHelperImage>("Installed");
    public ModHelperButton Star => GetDescendent<ModHelperButton>("Star");
    public ModHelperText StarCount => GetDescendent<ModHelperText>("StarCount");
    public ModHelperButton Verified => GetDescendent<ModHelperButton>("Verified");
    public ModHelperImage Spinner => GetDescendent<ModHelperImage>("Spinner");

    public bool descriptionShowing;

    public Task task;
    public string modName;
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

        var name = panel.AddText(new Info("Name")
        {
            Height = ModsMenu.ModNameHeight,
            FlexWidth = 3
        }, "Name", ModsMenu.FontMedium, TextAlignmentOptions.MidlineLeft);
        name.Text.enableAutoSizing = true;

        panel.AddPanel(new Info("LackOfIconPanel", size: 200));

        var authorPanel = panel.AddPanel(new Info("AuthorPanel")
        {
            Height = ModsMenu.ModNameHeight,
            FlexWidth = 2
        });
        var authorResizingPanel = authorPanel.AddPanel(new Info("AuthorResizingPanel")
        {
            Height = ModsMenu.ModNameHeight
        }, null, RectTransform.Axis.Horizontal);

        var contentSizeFitter = authorResizingPanel.AddComponent<ContentSizeFitter>();
        contentSizeFitter.horizontalFit = ContentSizeFitter.FitMode.PreferredSize;

        var authorText = authorResizingPanel.AddText(new Info("Author")
        {
            Height = ModsMenu.ModNameHeight
        }, "Author", ModsMenu.FontMedium);
        authorText.RemoveComponent<LayoutElement>();
        var verified = authorText.AddButton(new Info("Verified", 75)
        {
            Anchor = new Vector2(1, 0.5f),
            Pivot = new Vector2(0, 0.5f),
            X = ModsMenu.Padding / 2f
        }, VanillaSprites.VerifiedIcon, null);
        verified.RemoveComponent<Animator>();

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

        var rightButton = mainPanel.AddPanel(new Info("RightButton", 200));
        rightButton.AddButton(new Info("Download", 200), ModContent.GetTextureGUID<MelonMain>("DownloadBtn"), null);
        var update = rightButton.AddButton(new Info("Update", 200), VanillaSprites.GreenBtn, null);
        update.AddImage(new Info("UpdateIcon", 133), VanillaSprites.UpgradeIcon2);
        var spinner = rightButton.AddImage(new Info("Spinner", 200), VanillaSprites.LoadingWheel);
        spinner.SetActive(false);

        rightButton.AddImage(new Info("Installed", 200), VanillaSprites.TickGreenIcon);


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

        Spinner.transform.Rotate(0, 0, -2);
        Spinner.SetActive(task is {IsCompleted: false});
    }
}

internal static class ModBrowserMenuModExt
{
    public static void SetMod(this ModBrowserMenuMod mod, ModHelperData modHelperData)
    {
        mod.modName = modHelperData.Name;
        mod.Homepage.Button.SetOnClick(() => EmbeddedBrowser.OpenURL(modHelperData.ReadmeUrl!));
        mod.Description.Text.SetText(modHelperData.DisplayDescription);
        mod.InfoButton.Button.SetOnClick(() =>
        {
            mod.SetDescriptionShowing(!mod.descriptionShowing);
            MenuManager.instance.buttonClick3Sound.Play("ClickSounds");
        });
        mod.IconPanel.SetActive(false);
        mod.LackOfIconPanel.SetActive(true);
        mod.Name.SetText(modHelperData.DisplayName);
        mod.Version.SetText("v" + modHelperData.Version);
        mod.Author.SetText(modHelperData.DisplayAuthor);
        mod.Author.Text.color = BlatantFavoritism.GetColor(modHelperData.RepoOwner);

        mod.Icon.RectTransform.sizeDelta = modHelperData.SquareIcon
            ? new Vector2(ModsMenu.ModPanelHeight - 4, ModsMenu.ModPanelHeight - 4)
            : new Vector2(ModsMenu.ModIconSize, ModsMenu.ModIconSize);
        Task.Run(async () =>
        {
            var success = await modHelperData.LoadIconFromRepoAsync();
            if (success && mod.modName == modHelperData.Name) // make sure the mod panel hasn't been repurposed
            {
                mod.iconAction = () =>
                {
                    mod.IconPanel.SetActive(true);
                    mod.LackOfIconPanel.SetActive(false);
                    mod.Icon.Image.SetSprite(modHelperData.GetIcon()!);
                };
            }
        });

        var installed = modHelperData.ModInstalledLocally(out var current);
        mod.Download.Button.SetOnClick(() =>
        {
            Task.Run(() =>
            {
                var downloadTask = ModHelperGithub.DownloadLatest(modHelperData, false, filePath =>
                {
                    modHelperData.SetFilePath(filePath);
                    ModHelperData.Inactive.Add(modHelperData);
                    if (mod != null && mod.gameObject.active && mod.modName == modHelperData.Name)
                    {
                        mod.Download.SetActive(false);
                        mod.Installed.SetActive(true);
                    }
                }, task => mod.task = task);

                if (!downloadTask.IsCompleted)
                {
                    mod.task = downloadTask;
                }
            });
        });
        mod.Update.Button.SetOnClick(() =>
        {
            Task.Run(() =>
            {
                var downloadTask = ModHelperGithub.DownloadLatest(current, false, _ =>
                {
                    if (mod != null && mod.gameObject.active && mod.modName == modHelperData.Name)
                    {
                        mod.Update.SetActive(false);
                        mod.Installed.SetActive(true);
                    }
                }, task => mod.task = task);

                if (!downloadTask.IsCompleted)
                {
                    mod.task = downloadTask;
                }
            });
        });
        mod.Download.SetActive(!installed);
        mod.Update.SetActive(installed && current.UpdateAvailable);
        mod.Installed.SetActive(installed && !current.UpdateAvailable);

        mod.StarCount.SetText($"{modHelperData.Stars}{(string.IsNullOrEmpty(modHelperData.SubPath) ? "" : "+")}");
        mod.Star.Button.SetOnClick(() => ProcessHelper.OpenURL(modHelperData.StarsUrl));

        mod.Verified.SetActive(ModHelperGithub.VerifiedModders.Contains(modHelperData.RepoOwner));
        var coolKidsClub = BlatantFavoritism.GetColor(modHelperData.RepoOwner) != Color.white;
        mod.Verified.Button.SetOnClick(() => PopupScreen.instance.SafelyQueue(screen => screen.ShowOkPopup(
            "This modder has been manually verified with the maintainers of BTD Mod Helper. " +
            "Their work is trusted to not be unsafe, exploitative, obscene, or malicious. " +
            (coolKidsClub
                ? " Additionally, the special color indicates they are a significant Mod Helper contributor."
                : ""))
        ));
        mod.Verified.Image.color = BlatantFavoritism.GetColor(modHelperData.RepoOwner);
        mod.SetDescriptionShowing(false);

        mod.SetActive(true);
    }
}
