using System;
using BTD_Mod_Helper.Api.Enums;
using Il2CppAssets.Scripts.Unity.UI_New.Popups;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;
namespace BTD_Mod_Helper.Api.Components;

/// <summary>
/// ModHelperComponent that's the base panel for the visual representation of a ModSetting
/// </summary>
[RegisterTypeInIl2Cpp(false)]
public class ModHelperOption : ModHelperComponent
{
    internal const int PanelWidth = 2500;
    internal const int PanelHeight = 400;
    internal const int RowHeight = 200;
    internal const int TextHeight = 100;
    internal const int IconSize = 250;
    internal const int ResetSize = 150;

    /// <inheritdoc />
    public ModHelperOption(IntPtr ptr) : base(ptr)
    {
    }


    /// <summary>
    /// The displayed name for this setting
    /// </summary>
    public ModHelperText Name { get; private set; }

    /// <summary>
    /// The button that resets this setting
    /// </summary>
    public ModHelperButton ResetButton { get; private set; }

    /// <summary>
    /// The Icon for this setting. Will be null if no Icon provided
    /// </summary>
    public ModHelperImage Icon { get; private set; }

    /// <summary>
    /// The button that popups the description when pressed
    /// </summary>
    public ModHelperButton InfoButton { get; private set; }

    /// <summary>
    /// The top row of elements containing icon, name, info button
    /// </summary>
    public ModHelperPanel TopRow { get; private set; }

    /// <summary>
    /// The bottom row of elements containing the reset button and whatever input is added
    /// </summary>
    public ModHelperPanel BottomRow { get; private set; }

    /// <summary>
    /// The image shown when this setting requires a restart
    /// </summary>
    public ModHelperImage RestartIcon { get; private set; }

    /// <summary>
    /// Adds an action to the reset button
    /// </summary>
    public void SetResetAction(UnityAction action)
    {
        ResetButton.Button.onClick.AddListener(action);
    }


    /// <summary>
    /// Creates a new MoodHelperOption
    /// </summary>
    /// <param name="displayName">The displayed name of the mod setting</param>
    /// <param name="description">The description of the mod setting, if any</param>
    /// <param name="icon">The icon of the mod setting, if any</param>
    /// <returns>The created ModHelperOption</returns>
    public static ModHelperOption Create(string displayName, string description = null, string icon = null)
    {
        return Create<ModHelperOption>(displayName, description, icon);
    }

    /// <inheritdoc cref="Create" />
    protected static T Create<T>(string displayName, string description = null, string icon = null)
        where T : ModHelperOption
    {
        var modHelperOption = Create<T>(
            new Info(displayName, PanelWidth, PanelHeight)
        );

        modHelperOption.AddComponent<VerticalLayoutGroup>();
        modHelperOption.LayoutGroup.childAlignment = TextAnchor.UpperCenter;
        modHelperOption.LayoutGroup.childForceExpandHeight = false;
        modHelperOption.LayoutGroup.childForceExpandWidth = false;

        var topRow = modHelperOption.TopRow = modHelperOption.AddPanel(new Info("TopRow")
        {
            Height = RowHeight, FlexWidth = 1
        }, null, RectTransform.Axis.Horizontal, 100);
        topRow.LayoutGroup.childAlignment = TextAnchor.MiddleCenter;


        var iconPanel = topRow.AddPanel(new Info("IconPanel", RowHeight));
        if (icon != null)
        {
            modHelperOption.Icon = iconPanel.AddImage(new Info("Icon", RowHeight), icon);
            modHelperOption.Icon.Image.color = Color.white;
        }

        var restart = modHelperOption.RestartIcon =
            iconPanel.AddImage(new Info("Restart", RowHeight), VanillaSprites.RestartIcon);
        restart.SetActive(false);


        var text = modHelperOption.Name = topRow.AddText(new Info("Name")
        {
            Height = TextHeight
        }, displayName, 80f);
        text.FitContent(ContentSizeFitter.FitMode.PreferredSize);

        var infoPanel = topRow.AddPanel(new Info("InfoPanel", RowHeight));
        if (description != null)
        {

            modHelperOption.InfoButton = infoPanel.AddButton(
                new Info("Info", TextHeight + 25),
                VanillaSprites.InfoBtn2,
                string.IsNullOrEmpty(description)
                    ? null
                    : new Action(() => PopupScreen.instance.SafelyQueue(screen => screen.ShowOkPopup(description)))
            );
        }

        var bottomRow = modHelperOption.BottomRow = modHelperOption.AddPanel(new Info("BottomRow")
        {
            Height = RowHeight,
            FlexWidth = 1
        }, null, RectTransform.Axis.Horizontal, 100);
        bottomRow.LayoutGroup.childAlignment = TextAnchor.MiddleCenter;

        bottomRow.LayoutGroup.reverseArrangement = true;

        // Below is what needs to be ported to BloonsAT
        modHelperOption.ResetButton = bottomRow.AddButton(
            new Info("Reset", ResetSize), VanillaSprites.RestartBtn, null
        );


        return modHelperOption;
    }
}