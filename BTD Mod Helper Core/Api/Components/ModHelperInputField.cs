using System;
using Assets.Scripts.Utils;
using BTD_Mod_Helper.Extensions;
using MelonLoader;
using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace BTD_Mod_Helper.Api.Components
{
    /// <summary>
    /// ModHelperComponent for a text input field
    /// </summary>
    [RegisterTypeInIl2Cpp(false)]
    public class ModHelperInputField : ModHelperComponent
    {
        /// <summary>
        /// The InputField component
        /// </summary>
        public NK_TextMeshProInputField InputField => GetComponent<NK_TextMeshProInputField>();

        /// <summary>
        /// The Text ModHelperComponent
        /// </summary>
        public ModHelperText Text => GetDescendent<ModHelperText>("Text");

        /// <summary>
        /// Gets the current value of the InputField
        /// </summary>
        public string CurrentValue => Text.Text.text;

        /// <summary>
        /// Sets the current value of this
        /// </summary>
        /// <param name="text">The new text</param>
        /// <param name="sendCallback">Whether the onValueChanged listener should fire</param>
        public void SetText(string text, bool sendCallback = true)
        {
            InputField.SetText(text, sendCallback);
        }

        /// <inheritdoc />
        public ModHelperInputField(IntPtr ptr) : base(ptr)
        {
        }

        /// <summary>
        /// Creates a new ModHelperInputField
        /// </summary>
        /// <param name="info">The name/position/size info</param>
        /// <param name="defaultValue">The default text that's in the field</param>
        /// <param name="background">The sprite for the background panel</param>
        /// <param name="onValueChanged">An action to be called when the text is changed</param>
        /// <param name="fontSize">The size of the displayed text</param>
        /// <param name="validation">The type of validation used on user input</param>
        /// <param name="align">The alignment of the text</param>
        /// <returns>The created ModHelperInputField</returns>
        public static ModHelperInputField Create(Info info, string defaultValue, SpriteReference background,
            UnityAction<string> onValueChanged = null, float fontSize = 42,
            TMP_InputField.CharacterValidation validation = TMP_InputField.CharacterValidation.None,
            TextAlignmentOptions align = TextAlignmentOptions.Midline)
        {
            var modHelperInputField = ModHelperComponent.Create<ModHelperInputField>(info);
            modHelperInputField.AddComponent<Mask>();
            
            
            var backgroundImage = modHelperInputField.AddComponent<Image>();
            backgroundImage.type = Image.Type.Sliced;
            backgroundImage.SetSprite(background);

            var textViewPort = modHelperInputField.AddPanel(new Info("TextViewport", anchorMin: Vector2.zero, anchorMax: Vector2.one));

            var text = textViewPort.AddText(
                new Info("Text", anchorMin: Vector2.zero, anchorMax: Vector2.one),
                defaultValue, fontSize, align
            );
            text.Text.overflowMode = TextOverflowModes.Masking;
            text.Text.font = Fonts.Btd6FontBody;


            var inputField = modHelperInputField.AddComponent<NK_TextMeshProInputField>();
            inputField.characterValidation = validation;
            inputField.textComponent = text.Text;
            inputField.textViewport = textViewPort;
            inputField.caretWidth = 5;

            if (onValueChanged != null)
            {
                inputField.onValueChanged.AddListener(onValueChanged);
            }

            inputField.SetText(defaultValue);

            inputField.enabled = false;
            
            return modHelperInputField;
        }


        /// <inheritdoc />
        protected override void OnUpdate()
        {
            InputField.enabled = true;
        }
    }
}