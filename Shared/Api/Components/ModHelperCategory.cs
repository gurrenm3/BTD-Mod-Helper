using System;
using Assets.Scripts.Utils;
using BTD_Mod_Helper.Api.Enums;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace BTD_Mod_Helper.Api.Components;

/// <summary>
/// ModHelperComponent for a category in the mod settings menu
/// </summary>
[RegisterTypeInIl2Cpp(false)]
public class ModHelperCategory : ModHelperOption
{
    /// <summary>
    /// The panel that holds all the mod settings
    /// </summary>
    public ModHelperPanel CategoryContent => GetDescendent<ModHelperPanel>("CategoryContent");

    /// <summary>
    /// Whether the category is hidden or not
    /// </summary>
    public bool collapsed;

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
    public static ModHelperCategory Create(string? displayName, bool collapsed, SpriteReference? icon = null)
    {
        var category = Create<ModHelperCategory>(displayName, "", icon);
        category.collapsed = collapsed;
        category.FitContent(vertical: ContentSizeFitter.FitMode.PreferredSize);

        category.BottomRow.gameObject.active = false;

#if BloonsTD6
        category.Name.Text.fontStyle = FontStyles.Underline;
#elif BloonsAT
            throw new NotImplementedException(); // need to get "category.Name" working for BloonsAT
#endif

        var content = category.AddPanel(
            new Info("CategoryContent", anchorMin: new Vector2(0, 0.5f), anchorMax: new Vector2(1, 0.5f)), null,
            RectTransform.Axis.Vertical, 150
        );
        content.FitContent(vertical: ContentSizeFitter.FitMode.PreferredSize);

        var action = new Action<bool>(collapse =>
        {
            category.collapsed = collapse;
            content.gameObject.active = !collapse;
            var localScale = category.InfoButton.parent!.RectTransform.localScale;
            localScale.y = category.collapsed ? -1 : 1;
            category.InfoButton.parent.RectTransform.localScale = localScale;
        });
        action(collapsed);

#if BloonsTD6
        category.InfoButton.Image.SetSprite(VanillaSprites.ArrowHideBtn);
#elif BloonsAT
            //category.InfoButton.Image.SetSprite(VanillaSprites.ArrowHideBtn); this won't work
            throw new NotImplementedException(); // figure out how to get VanillaSprites for BloonsAT
#endif
        category.InfoButton.Button.AddOnClick(() => action(!category.collapsed));

        return category;
    }
}