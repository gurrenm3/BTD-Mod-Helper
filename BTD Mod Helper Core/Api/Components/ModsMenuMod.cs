using System;
using System.Linq;
using Assets.Scripts.Unity.Menu;
using Assets.Scripts.Utils;
using BTD_Mod_Helper.Api.Enums;
using BTD_Mod_Helper.Api.Updater;
using BTD_Mod_Helper.Extensions;
using BTD_Mod_Helper.Menus;
using MelonLoader;
using UnityEngine;

namespace BTD_Mod_Helper.Api.Components
{
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

        public ModsMenuMod(IntPtr ptr) : base(ptr)
        {
        }

        public static ModsMenuMod CreateTemplate()
        {
            var mod = Create<ModsMenuMod>(
                new Info("ModTemplate", height: 200, flexWidth: 1)
            );

            var panel = mod.AddButton(
                new Info("MainButton", anchorMin: Vector2.zero, anchorMax: Vector2.one), VanillaSprites.UISprite, null
            );

            panel.AddImage(
                new Info("Icon", ModsMenu.Padding * 2, 0, size: ModsMenu.ModIconSize, anchor: new Vector2(0, 0.5f)),
                VanillaSprites.UISprite
            );


            panel.AddImage(
                new Info("Restart", ModsMenu.Padding * 2, 0, ModsMenu.ModIconSize, ModsMenu.ModIconSize,
                    anchor: new Vector2(0, 0.5f)), VanillaSprites.RestartIcon
            );

            panel.AddText(new Info("Name", 0, 0, ModsMenu.ModNameWidth, ModsMenu.ModNameHeight), "Name",
                ModsMenu.FontMedium);

            panel.AddText(
                new Info("Version", ModsMenu.Padding * -3, 0, ModsMenu.ModNameWidth / 5f, ModsMenu.ModNameHeight,
                    anchor: new Vector2(1, 0.5f)), "v0.0.0", ModsMenu.FontSmall
            );

            panel.AddButton(
                new Info("Update", ModsMenu.Padding / -2f, ModsMenu.Padding / -2f, ModsMenu.ModPanelHeight / 2f,
                    ModsMenu.ModPanelHeight / 2f, anchor: new Vector2(1, 1)), VanillaSprites.UpgradeBtn, null
            );

            panel.AddButton(
                new Info("Settings", ModsMenu.Padding / -2f, ModsMenu.Padding / 2f, ModsMenu.ModPanelHeight / 3f,
                    ModsMenu.ModPanelHeight / 3f, anchor: new Vector2(1, 0)), VanillaSprites.SettingsIconSmall, null
            );

            mod.SetActive(false);

            return mod;
        }
    }

    internal static class ModsMenuModExt
    {
        public static void SetMod(this ModsMenuMod mod, ModHelperData modHelperData,
            MelonMod melonMod = null)
        {
            mod.MainButton.Image.SetSprite(GetBackground(modHelperData));
            mod.MainButton.Button.SetOnClick(() =>
            {
                ModsMenu.SetSelectedMod(modHelperData);
                MenuManager.instance.buttonClick3Sound.Play("ClickSounds");
            });

            if (!modHelperData.HasNoIcon && modHelperData.GetIcon() is Sprite sprite)
            {
                mod.Icon.Image.SetSprite(sprite);
            }

            mod.Name.SetText(modHelperData.Name);
            mod.Version.SetText("v" + modHelperData.Version);
            // ReSharper disable once AsyncVoidLambda
            mod.Update.Button.SetOnClick(async () => await ModHelperGithub.DownloadLatest(modHelperData));
            mod.Settings.Button.SetOnClick(() => ModSettingsMenu.Open((BloonsMod) melonMod));

            if (!(melonMod is BloonsMod bloonsMod && bloonsMod.ModSettings.Any()))
            {
                mod.Settings.SetActive(false);
            }

            mod.Refresh(modHelperData);

            mod.SetActive(true);
        }

        public static void Refresh(this ModsMenuMod mod, ModHelperData modHelperData)
        {
            mod.MainButton.Image.SetSprite(GetBackground(modHelperData));
            mod.Update.SetActive(modHelperData.UpdateAvailable);
            mod.Restart.SetActive(modHelperData.RestartRequired);
            mod.Version.Text.color = UpdaterHttp.IsUpdate(modHelperData.Version, modHelperData.RepoVersion)
                ? Color.red
                : Color.white;

            mod.Icon.SetActive(!modHelperData.HasNoIcon);
        }

        public static SpriteReference GetBackground(ModHelperData data)
        {
            var background = VanillaSprites.MainBGPanelBlue;
            if (!data.Enabled)
                background = VanillaSprites.MainBGPanelGrey;
            else if (data.Mod == ModContent.GetInstance<MelonMain>())
                background = VanillaSprites.MainBGPanelYellow;
            else if (data.Mod?.Games.Any(attribute => attribute.Universal) == true)
                background = VanillaSprites.MainBgPanelHematite;
            else if (data.Mod != null && !(data.Mod is BloonsMod)) background = VanillaSprites.MainBGPanelBlueNotches;
            return background;
        }
    }
}