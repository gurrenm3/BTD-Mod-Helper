using System;
using Assets.Scripts.Utils;
using BTD_Mod_Helper.Api.Enums;
using BTD_Mod_Helper.Extensions;
using MelonLoader;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace BTD_Mod_Helper.Api.Components
{
    /// <summary>
    /// ModHelperComponent for a category in the mod settings menu
    /// </summary>
    [RegisterTypeInIl2Cpp(false)]
    public class ModHelperCategory : ModHelperOption
    {
        /// <summary>
        /// The panel that holds all the mod settings
        /// </summary>
        public ModHelperPanel CategoryContent { get; private set; }

        /// <summary>
        /// Whether the category is hidden or not
        /// </summary>
        public bool Collapsed { get; private set; }

        /// <inheritdoc />
        public ModHelperCategory(IntPtr ptr) : base(ptr)
        {
        }

        /// <summary>
        /// Creates a new ModHelperCategory
        /// </summary>
        /// <param name="displayName">The name of the category</param>
        /// <param name="collapsed">Whether it's collapsed by default or not</param>
        /// <param name="icon">The icon for the category, if any</param>
        /// <returns>The created ModHelperCategory</returns>
        public static ModHelperCategory Create(string displayName, bool collapsed, SpriteReference icon = null)
        {
            var category = Create<ModHelperCategory>(displayName, "", icon);
            category.Collapsed = collapsed;
            category.FitContent(vertical: ContentSizeFitter.FitMode.PreferredSize);

            category.BottomRow.gameObject.active = false;

            category.Name.Text.fontStyle = FontStyles.Underline;

            var content = category.CategoryContent = category.AddPanel(
                new Info("CategoryContent", anchorMin: new Vector2(0, 0.5f), anchorMax: new Vector2(1, 0.5f)), null,
                RectTransform.Axis.Vertical, 150
            );
            content.FitContent(vertical: ContentSizeFitter.FitMode.PreferredSize);

            var action = new Action<bool>(collapse =>
            {
                category.Collapsed = collapse;
                content.gameObject.active = !collapse;
                var localScale = category.InfoButton.Parent.RectTransform.localScale;
                localScale.y = category.Collapsed ? -1 : 1;
                category.InfoButton.Parent.RectTransform.localScale = localScale;
            });
            action(collapsed);

            category.InfoButton.Image.SetSprite(VanillaSprites.ArrowHideBtn);
            category.InfoButton.Button.AddOnClick(() => action(!category.Collapsed));

            return category;
        }
    }
}