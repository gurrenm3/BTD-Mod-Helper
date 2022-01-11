using System;
using System.Linq;
using Assets.Scripts.Unity.UI_New;
using Assets.Scripts.Unity.UI_New.ChallengeEditor;
using BTD_Mod_Helper.Api;
using BTD_Mod_Helper.Api.Components;
using BTD_Mod_Helper.Api.Enums;
using BTD_Mod_Helper.Extensions;
using MelonLoader;
using NinjaKiwi.Common;
using UnityEngine;
using Random = UnityEngine.Random;

namespace BTD_Mod_Helper.BTD6_UI
{
    public class ModsMenu : ModGameMenu<ExtraSettingsScreen>
    {
        private const int MenuWidth = 4000;
        private const int MenuHeight = 2000;

        private const int ModsListWidth = 1500;
        private const int ModsListHeight = 2000;

        private const int ModsScrollWidth = 1400;
        private const int ModsScrollHeight = 1700;
        private const int ModsScrollOffset = -100;
        private const int ModsScrollSpacing = 100;

        private const int ModPanelHeight = 200;
        private const int ModIconSize = 250;
        private const int ModNameWidth = 1000;
        private const int ModNameHeight = 150;
        private const int ModNameSize = 69;
        private const int UpdateOffset = 75;

        public override bool OnMenuOpened(ExtraSettingsScreen gameMenu)
        {
            CommonForegroundScreen.instance.heading.GetComponentInChildren<NK_TextMeshProUGUI>().SetText("Mods");

            var panelTransform = gameMenu.gameObject.GetComponentInChildrenByName<RectTransform>("Panel");
            TransformExtensions.DestroyAllChildren(panelTransform);
            var panel = panelTransform.gameObject;

            var modsMenu = panel.AddModHelperPanel(new Rect(0, 0, MenuWidth, MenuHeight), "ModsMenu");

            var modsList = modsMenu.AddPanel(new Rect(-MenuWidth / 4f, 0, ModsListWidth, ModsListHeight),
                "ModsList", VanillaSprites.MainBGPanelBlue);

            var scrollPanel = modsList.AddScrollPanel(new Rect(0, ModsScrollOffset, ModsScrollWidth, ModsScrollHeight),
                RectTransform.Axis.Vertical, "ModListScroll", VanillaSprites.BlueInsertPanel, ModsScrollSpacing);

            scrollPanel.LayoutGroup.padding = new RectOffset
            {
                top = ModsScrollSpacing / 2, bottom = ModsScrollSpacing / 2,
                left = ModsScrollSpacing / 2, right = ModsScrollSpacing / 2
            };

            foreach (var melonMod in MelonHandler.Mods)
            {
                scrollPanel.AddScrollContent(CreateModPanel(melonMod));
            }

            return false;
        }


        public static ModHelperComponent CreateModPanel(MelonMod mod)
        {
            var background = VanillaSprites.MainBGPanelBlue;

            if (mod == null)
                background = VanillaSprites.MainBGPanelGrey;
            else if (mod == GetInstance<MelonMain>())
                background = VanillaSprites.MainBGPanelYellow;
            else if (mod.Games.Any(attribute => attribute.Universal))
                background = VanillaSprites.MainBgPanelHematite;
            else if (!(mod is BloonsMod)) background = VanillaSprites.MainBGPanelBlueNotches;

            var panel = ModHelperButton.Create(new Rect(0, 0, ModsScrollWidth - ModsScrollSpacing, ModPanelHeight),
                background, null, mod.Info.Name);

            const float offset = (ModsScrollWidth - ModsScrollSpacing) / 2f - ModsScrollSpacing;

            if (mod.GetModHelperData()?.IconBytes is byte[] bytes)
            {
                var texture = new Texture2D(2, 2) {filterMode = FilterMode.Bilinear, mipMapBias = -1};
                ImageConversion.LoadImage(texture, bytes);
                var sprite = Sprite.Create(texture, new Rect(0, 0, texture.width, texture.height),
                    new Vector2(0.5f, 0.5f), 10f);

                panel.AddImage(new Rect(-offset, 0,
                    ModIconSize, ModIconSize), sprite, "Icon");
            }

            panel.AddText(new Rect(0, 0, ModNameWidth, ModNameHeight), mod.Info.Name, ModNameSize);

            var needsUpdate = Random.Range(0f, 1f) < .1f;

            var versionText = panel.AddText(new Rect(offset, 0, ModNameWidth / 5f, ModNameHeight),
                "v" + mod.Info.Version);
            if (needsUpdate)
            {
                versionText.Text.color = Color.red;

                panel.AddButton(new Rect(offset + UpdateOffset, UpdateOffset, ModPanelHeight / 2f,
                    ModPanelHeight / 2f), VanillaSprites.UpgradeBtn, null, "UpgradeIcon");
            }


            return panel;
        }
    }
}