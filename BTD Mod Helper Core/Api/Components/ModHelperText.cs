using System;
using MelonLoader;
using TMPro;
using UnityEngine;

namespace BTD_Mod_Helper.Api.Components
{
    /// <summary>
    /// ModHelperComponent for a background panel
    /// </summary>
    [RegisterTypeInIl2Cpp(false)]
    public class ModHelperText : ModHelperComponent
    {
        /// <summary>
        /// Default BTD6 font
        /// </summary>
        public static TMP_FontAsset luckiestGuy;

        /// <summary>
        /// The component that handles the Text rendering
        /// </summary>
        public NK_TextMeshProUGUI Text { get; private set; }


        /// <inheritdoc />
        public ModHelperText(IntPtr ptr) : base(ptr)
        {
        }

        /// <summary>
        /// Sets the text of this text to the given text
        /// </summary>
        public void SetText(string text)
        {
            Text.SetText(text);
        }

        /// <summary>
        /// Creates a new ModHelperText
        /// </summary>
        /// <param name="info">The name/position/size info</param>
        /// <param name="text">The text to display</param>
        /// <param name="fontSize">Size of font</param>
        /// <param name="align">Alignment of text</param>
        /// <returns>The created ModHelperText</returns>
        public static ModHelperText Create(Info info, string text, float fontSize = 42,
            TextAlignmentOptions align = TextAlignmentOptions.Midline)
        {
            var modHelperText = ModHelperComponent.Create<ModHelperText>(info);

            var textMesh = modHelperText.Text = modHelperText.AddComponent<NK_TextMeshProUGUI>();

            textMesh.SetText(text);
            textMesh.alignment = align;
            textMesh.fontSize = fontSize;
            textMesh.font = luckiestGuy;
            textMesh.overflowMode = TextOverflowModes.Ellipsis;
            textMesh.lineSpacing = fontSize / 2;

            return modHelperText;
        }
    }
}