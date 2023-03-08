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

#if BloonsTD6
    /// <summary>
    /// The displayed name for this setting
    /// </summary>
    public ModHelperText Name { get; private set; }
#endif

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

    /// <inheritdoc />
    public ModHelperOption(IntPtr ptr) : base(ptr)
    {
    }

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

    /// <inheritdoc cref="Create"/>
    protected static T Create<T>(string displayName, string description = null, string icon = null)
        where T : ModHelperOption
    {
        var modHelperOption = Create<T>(
            new Info(displayName, width: PanelWidth, height: PanelHeight)
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


        var iconPanel = topRow.AddPanel(new Info("IconPanel", size: RowHeight));
        if (icon != null)
        {
            modHelperOption.Icon = iconPanel.AddImage(new Info("Icon", size: RowHeight), icon);
            modHelperOption.Icon.Image.color = Color.white;
        }

        var restart = modHelperOption.RestartIcon =
            iconPanel.AddImage(new Info("Restart", size: RowHeight), VanillaSprites.RestartIcon);
        restart.SetActive(false);

#if BloonsTD6
        var text = modHelperOption.Name = topRow.AddText(new Info("Name")
        {
            Height = TextHeight
        }, displayName, 80f);
        text.FitContent(ContentSizeFitter.FitMode.PreferredSize);
#elif BloonsAT
            throw new NotImplementedException(); // need to figure out how to get ModHelperText class working for BloonsAT
#endif
        var infoPanel = topRow.AddPanel(new Info("InfoPanel", size: RowHeight));
        if (description != null)
        {
#if BloonsTD6
            modHelperOption.InfoButton = infoPanel.AddButton(
                new Info("Info", size: TextHeight + 25),
                VanillaSprites.InfoBtn2,
                string.IsNullOrEmpty(description)
                    ? null
                    : new Action(() => PopupScreen.instance.SafelyQueue(screen => screen.ShowOkPopup(description)))
            );
#elif BloonsAT
                // need to figure out how to get the VanillaSprites mentioned above to work with BloonsAT
                throw new NotImplementedException();
#endif
        }

        var bottomRow = modHelperOption.BottomRow = modHelperOption.AddPanel(new Info("BottomRow")
        {
            Height = RowHeight,
            FlexWidth = 1
        }, null, RectTransform.Axis.Horizontal, 100);
        bottomRow.LayoutGroup.childAlignment = TextAnchor.MiddleCenter;
#if BloonsTD6
        bottomRow.LayoutGroup.reverseArrangement = true;

        // Below is what needs to be ported to BloonsAT
        modHelperOption.ResetButton = bottomRow.AddButton(
            new Info("Reset", size: ResetSize), VanillaSprites.RestartBtn, null
        );
#elif BloonsAT
            throw new NotImplementedException(); // need to get VanillaSprite mentioned above for BloonsAT
#endif


        return modHelperOption;
    }
}