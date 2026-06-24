using System;
using BTD_Mod_Helper.Api.Enums;
using Il2CppAssets.Scripts.Unity.Menu;
using Il2CppTMPro;
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
    /// Whether the category is hidden or not
    /// </summary>
    public bool collapsed;

    /// <inheritdoc />
    public ModHelperCategory(IntPtr ptr) : base(ptr)
    {
    }

    /// <summary>
    /// The panel that holds all the mod settings
    /// </summary>
    public ModHelperPanel CategoryContent => GetDescendent<ModHelperPanel>("CategoryContent");

    /// <summary>
    /// Creates a new ModHelperCategory
    /// </summary>
    /// <param name="displayName">The name of the category</param>
    /// <param name="collapsed">Whether it's collapsed by default or not</param>
    /// <param name="icon">The icon for the category, if any</param>
    /// <returns>The created ModHelperCategory</returns>
    public static ModHelperCategory Create(string displayName, bool collapsed, string icon = null) =>
        ModHelperComponent.Create<ModHelperCategory>(new Info(displayName, PanelWidth, PanelHeight))
            .Init(displayName, collapsed, icon);

    /// <summary>
    /// Initializes this ModHelperCategory
    /// </summary>
    /// <param name="displayName">The name of the category</param>
    /// <param name="collapsed">Whether it's collapsed by default or not</param>
    /// <param name="icon">The icon for the category, if any</param>
    /// <returns>this ModHelperCategory</returns>
    public ModHelperCategory Init(string displayName, bool collapsed, string icon = null)
    {
        base.Init(displayName, "", icon);

        this.collapsed = collapsed;
        FitContent(vertical: ContentSizeFitter.FitMode.PreferredSize);

        BottomRow.gameObject.active = false;


        Name.Text.fontStyle = FontStyles.Underline;

        var content = AddPanel(new Info("CategoryContent")
        {
            AnchorMinX = 0, AnchorMaxX = 0
        }, null, RectTransform.Axis.Vertical, 150);
        content.FitContent(vertical: ContentSizeFitter.FitMode.PreferredSize);

        var action = new Action<bool>(collapse =>
        {
            this.collapsed = collapse;
            content.gameObject.active = !collapse;
            var localScale = InfoButton.parent.RectTransform.localScale;
            localScale.y = this.collapsed ? -1 : 1;
            InfoButton.parent.RectTransform.localScale = localScale;
        });
        action(collapsed);


        InfoButton.Image.SetSprite(VanillaSprites.ArrowHideBtn);

        InfoButton.Button.AddOnClick(() =>
        {
            action(!this.collapsed);
            MenuManager.instance.buttonClick2Sound.Play("ClickSounds");
        });

        return this;
    }
}