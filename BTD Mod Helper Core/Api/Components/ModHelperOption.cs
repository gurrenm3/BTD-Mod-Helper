using System;
using Assets.Scripts.Unity.UI_New.Popups;
using Assets.Scripts.Utils;
using BTD_Mod_Helper.Api.Enums;
using BTD_Mod_Helper.Extensions;
using MelonLoader;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace BTD_Mod_Helper.Api.Components
{
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
        public static ModHelperOption Create(string displayName, string description = null,
            SpriteReference icon = null)
        {
            return Create<ModHelperOption>(displayName, description, icon);
        }

        /// <inheritdoc cref="Create"/>
        protected static T Create<T>(string displayName, string description = null,
            SpriteReference icon = null)
            where T : ModHelperOption
        {
            var modHelperOption = ModHelperComponent.Create<T>(
                new Info(displayName, width: PanelWidth, height: PanelHeight)
            );

            modHelperOption.LayoutGroup = modHelperOption.AddComponent<VerticalLayoutGroup>();
            modHelperOption.LayoutGroup.childAlignment = TextAnchor.UpperCenter;
            modHelperOption.LayoutGroup.childForceExpandHeight = false;
            modHelperOption.LayoutGroup.childForceExpandWidth = false;

            var topRow = modHelperOption.AddPanel(
                new Info("TopRow", height: RowHeight, flexWidth: 1),
                null, RectTransform.Axis.Horizontal, 100
            );
            topRow.LayoutGroup.childAlignment = TextAnchor.MiddleCenter;


            var iconPanel = topRow.AddPanel(new Info("IconPanel", size: RowHeight));
            if (icon != null)
            {
                modHelperOption.Icon = iconPanel.AddImage(new Info("Icon", size: RowHeight), icon);
            }

            var text = modHelperOption.Name = topRow.AddText(
                new Info("Name", height: TextHeight), displayName, 80f
            );
            text.FitContent(ContentSizeFitter.FitMode.PreferredSize);


            var infoPanel = topRow.AddPanel(new Info("InfoPanel", size: RowHeight));
            if (description != null)
            {
                modHelperOption.InfoButton = infoPanel.AddButton(
                    new Info("Info", size: TextHeight),
                    VanillaSprites.InfoBtn2,
                    string.IsNullOrEmpty(description)
                        ? null
                        : new Action(() => { PopupScreen.instance.ShowOkPopup(description); })
                );
            }

            var bottomRow = modHelperOption.BottomRow = modHelperOption.AddPanel(
                new Info("BottomRow", height: RowHeight, flexWidth: 1), null, RectTransform.Axis.Horizontal, 100
            );
            bottomRow.LayoutGroup.childAlignment = TextAnchor.MiddleCenter;
            bottomRow.LayoutGroup.reverseArrangement = true;

            modHelperOption.ResetButton = bottomRow.AddButton(
                new Info("Reset", size: ResetSize), VanillaSprites.RestartBtn, null
            );

            return modHelperOption;
        }
    }
}