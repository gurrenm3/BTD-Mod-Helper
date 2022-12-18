using System;
using System.Linq;
using Il2CppAssets.Scripts.Unity.Menu;
using Il2CppAssets.Scripts.Unity.UI_New.Popups;
using Il2CppAssets.Scripts.Utils;
using BTD_Mod_Helper.Api.Enums;
using BTD_Mod_Helper.UI.Menus;
using MelonLoader.InternalUtils;
using UnityEngine;
using UnityEngine.Events;

namespace BTD_Mod_Helper.Api.Components;

[RegisterTypeInIl2Cpp(false)]
internal class ModsMenuMod : ModHelperComponent
{
    public ModHelperButton MainButton => GetDescendent<ModHelperButton>("MainButton");
    public ModHelperImage Icon => GetDescendent<ModHelperImage>("Icon");
    public ModHelperText Name => GetDescendent<ModHelperText>("Name");
    public ModHelperText Version => GetDescendent<ModHelperText>("Version");
    public ModHelperButton Update => GetDescendent<ModHelperButton>("Update");
    public ModHelperButton Settings => GetDescendent<ModHelperButton>("Settings");
    public ModHelperImage Restart => GetDescendent<ModHelperImage>("Restart");
    public ModHelperButton Warning => GetDescendent<ModHelperButton>("Warning");

    public UnityAction toggleMod;

    public ModsMenuMod(IntPtr ptr) : base(ptr)
    {
    }

    public static ModsMenuMod CreateTemplate()
    {
        var mod = Create<ModsMenuMod>(new Info("ModTemplate")
        {
            Height = 200,
            FlexWidth = 1
        });

        var panel = mod.AddButton(new Info("MainButton", InfoPreset.FillParent), VanillaSprites.UISprite, null);

        panel.AddImage(new Info("Icon", ModsMenu.Padding * 2, 0, ModsMenu.ModIconSize, new Vector2(0, 0.5f)),
            VanillaSprites.UISprite);


        panel.AddImage(new Info("Restart", ModsMenu.Padding * 2, 0, ModsMenu.ModIconSize, ModsMenu.ModIconSize,
            new Vector2(0, 0.5f)), VanillaSprites.RestartIcon);

        panel.AddText(new Info("Name", ModsMenu.ModNameWidth, ModsMenu.ModNameHeight), "Name",
            ModsMenu.FontMedium);

        panel.AddText(new Info("Version", ModsMenu.Padding * -3, 0, ModsMenu.ModNameWidth / 5f, ModsMenu.ModNameHeight,
            anchor: new Vector2(1, 0.5f)), "v0.0.0", ModsMenu.FontSmall);

        panel.AddButton(new Info("Update", ModsMenu.Padding / -2f, ModsMenu.Padding / -2f, ModsMenu.ModPanelHeight / 2f,
            new Vector2(1, 1)), VanillaSprites.UpgradeBtn, null);

        panel.AddButton(new Info("Settings", ModsMenu.Padding / -2f, ModsMenu.Padding / 2f,
            ModsMenu.ModPanelHeight / 3f, new Vector2(1, 0)), VanillaSprites.SettingsIconSmall, null);

        panel.AddButton(new Info("Warning", ModsMenu.Padding / 2f, ModsMenu.Padding / -2f, ModsMenu.ModPanelHeight / 2f,
            new Vector2(0, 1)), VanillaSprites.NoticeBtn, null);

        mod.SetActive(false);

        return mod;
    }
}

internal static class ModsMenuModExt
{
    public static void SetMod(this ModsMenuMod mod, ModHelperData modHelperData, MelonMod melonMod = null)
    {
        mod.MainButton.Image.SetSprite(GetBackground(modHelperData));
        mod.MainButton.Button.SetOnClick(() =>
        {
            ModsMenu.SetSelectedMod(modHelperData);
            switch (modHelperData.Enabled)
            {
                case false when Input.GetKey(KeyCode.LeftShift) || Input.GetKey(KeyCode.RightShift):
                    ModsMenu.EnableSelectedMod();
                    break;
                case true when Input.GetKey(KeyCode.LeftAlt) || Input.GetKey(KeyCode.RightAlt):
                    ModsMenu.DisableSelectedMod();
                    break;
                default:
                    MenuManager.instance.buttonClick3Sound.Play("ClickSounds");
                    break;
            }
        });

        if (!modHelperData.HasNoIcon && modHelperData.GetIcon() is Sprite sprite)
        {
            mod.Icon.Image.SetSprite(sprite);
        }

        mod.Name.SetText(modHelperData.Name);
        mod.Version.SetText("v" + modHelperData.Version);
        // ReSharper disable once AsyncVoidLambda
        mod.Update.Button.SetOnClick(async () => await ModHelperGithub.DownloadLatest(modHelperData));
        mod.Settings.Button.SetOnClick(() => ModSettingsMenu.Open((BloonsMod) melonMod!));

        mod.Settings.SetActive(false);
        mod.Warning.SetActive(false);

        if (melonMod is BloonsMod bloonsMod)
        {
            if (bloonsMod.ModSettings.Any())
            {
                mod.Settings.SetActive(true);
            }

            if (bloonsMod.loadErrors.Any())
            {
                mod.Warning.SetActive(true);
                mod.Warning.Button.SetOnClick(() =>
                {
                    PopupScreen.instance.SafelyQueue(screen =>
                        screen.ShowOkPopup(bloonsMod.loadErrors.Join(null, "\n")));
                });
            }
        }


        mod.Refresh(modHelperData);

        mod.SetActive(true);

        mod.toggleMod = new Action(() =>
        {
            if (modHelperData.Mod is MelonMain) return;
                
            switch (modHelperData.Enabled)
            {
                case false:
                    modHelperData.MoveToEnabledModsFolder();
                    break;
                case true:
                    modHelperData.MoveToDisabledModsFolder();
                    break;
            }
            mod.Refresh(modHelperData);
            MenuManager.instance.buttonClick3Sound.Play("ClickSounds");
        });
    }

    public static void Refresh(this ModsMenuMod mod, ModHelperData modHelperData)
    {
        mod.MainButton.Image.SetSprite(GetBackground(modHelperData));
        mod.Update.SetActive(modHelperData.UpdateAvailable);
        mod.Restart.SetActive(modHelperData.RestartRequired);
        mod.Version.Text.color = modHelperData.OutOfDate
            ? Color.red
            : Color.white;

        mod.Icon.SetActive(!modHelperData.HasNoIcon);
        mod.Icon.RectTransform.sizeDelta = modHelperData.SquareIcon
            ? new Vector2(ModsMenu.ModPanelHeight - 4, ModsMenu.ModPanelHeight - 4)
            : new Vector2(ModsMenu.ModIconSize, ModsMenu.ModIconSize);
    }

    public static string GetBackground(ModHelperData data)
    {
        var background = VanillaSprites.MainBGPanelBlue;
        if (!data.Enabled)
            background = VanillaSprites.MainBGPanelGrey;
        else if (data.Mod == ModContent.GetInstance<MelonMain>())
            background = VanillaSprites.MainBGPanelYellow;
        else if (data.Mod?.Games.Any(attribute => attribute.Name == UnityInformationHandler.GameName) == false)
            background = VanillaSprites.MainBgPanelHematite;
        else if (data.Mod != null && !(data.Mod is BloonsMod)) background = VanillaSprites.MainBGPanelBlueNotches;
        return background;
    }
}