using System;
using System.Linq;
using Assets.Scripts.Utils;
using BTD_Mod_Helper.Api.Enums;
using BTD_Mod_Helper.Extensions;
using Il2CppSystem.Collections.Generic;
using MelonLoader;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace BTD_Mod_Helper.Api.Components
{
    /// <summary>
    /// ModHelperComponent for a 
    /// </summary>
    [RegisterTypeInIl2Cpp(false)]
    public class ModHelperDropdown : ModHelperComponent
    {
        /// <summary>
        /// The Image being displayed
        /// </summary>
        public Image Background { get; private set; }

        /// <summary>
        /// The Text which shows the currently selected value
        /// </summary>
        public ModHelperText Text { get; private set; }

        /// <summary>
        /// The component which handles the dropdown
        /// </summary>
        public TMP_Dropdown Dropdown { get; private set; }

        /// <summary>
        /// The Arrow image
        /// </summary>
        public ModHelperImage Arrow { get; private set; }

        /// <summary>
        /// The template object for the window of the dropdown
        /// </summary>
        public ModHelperScrollPanel TemplatePanel { get; private set; }

        /// <summary>
        /// The default item in the template
        /// </summary>
        public ModHelperPanel TemplateItem { get; private set; }

        /// <inheritdoc />
        public ModHelperDropdown(IntPtr ptr) : base(ptr)
        {
        }


        /// <summary>
        /// Creates a new ModHelperDropdown
        /// </summary>
        /// <param name="rect">The position and size</param>
        /// <param name="options">The list of options</param>
        /// <param name="objectName">The Unity name of the object</param>
        /// <param name="background">The background image</param>
        /// <param name="labelFontSize">Text size of label</param>
        /// <returns>The created ModHelperDropdown</returns>
        public static ModHelperDropdown Create(Rect rect, List<TMP_Dropdown.OptionData> options, float windowHeight,
            string objectName = "ModHelperDropdown", SpriteReference background = null, float labelFontSize = 42f)
        {
            var (x, y, width, height) = rect;

            var contentHeight = options.Count * height;
            var realHeight = Math.Min(windowHeight, contentHeight);

            var modHelperDropdown = ModHelperComponent.Create<ModHelperDropdown>(rect, objectName);

            var text = modHelperDropdown.Text = modHelperDropdown.AddText(rect, "", labelFontSize);

            var dropdown = modHelperDropdown.Dropdown = modHelperDropdown.AddComponent<TMP_Dropdown>();
            dropdown.captionText = text.Text;
            dropdown.options = options;

            if (background != null)
            {
                var image = dropdown.image = modHelperDropdown.Background = modHelperDropdown.AddComponent<Image>();
                image.SetSprite(background);
                image.type = Image.Type.Sliced;
            }

            modHelperDropdown.Arrow = modHelperDropdown.AddImage(
                new Rect(rect.width / 2 - 64, 0, 64, 40), VanillaSprites.MonkeyKnowledgeArrow, "Arrow");


            var template = modHelperDropdown.TemplatePanel =
                modHelperDropdown.AddScrollPanel(new Rect(0, height / -2 - realHeight / 2, width, realHeight),
                    RectTransform.Axis.Vertical, "Template", VanillaSprites.UISprite);
            template.Background.color = new Color(0.262f, 0.435f, 0.658f);
            dropdown.template = template;
            template.shouldDisable = true;

            var item = modHelperDropdown.TemplateItem = ModHelperPanel.Create(new Rect(0, 0, width, height), "Item");
            var toggle = item.AddComponent<Toggle>();
            toggle.transition = (Selectable.Transition) Toggle.ToggleTransition.Fade;

            var itemBackground = item.AddPanel(new Rect(0, 0, width, height), "ItemBackground");
            var backgroundImage = itemBackground.AddComponent<Image>();
            backgroundImage.color = new Color(0.219f, 0.364f, 0.552f);

            var itemSelected = item.AddPanel(new Rect(0, 0, width, height), "ItemSelected");
            var selectedImage = toggle.graphic = itemSelected.AddComponent<Image>();
            selectedImage.color = new Color(0.591f, 1, 0);

            var itemLabel = item.AddText(new Rect(0, 0, width, height), "", labelFontSize, TextAlignmentOptions.Center,
                "ItemLabel");

            dropdown.itemText = itemLabel.Text;

            template.AddScrollContent(item);

            return modHelperDropdown;
        }
    }
}