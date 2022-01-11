using System;
using Assets.Scripts.Utils;
using MelonLoader;
using UnityEngine;
using UnityEngine.UI;

namespace BTD_Mod_Helper.Api.Components
{
    /// <summary>
    /// ModHelperComponent for a background panel
    /// </summary>
    [RegisterTypeInIl2Cpp(false)]
    public class ModHelperText : ModHelperComponent
    {
        public NK_TextMeshProUGUI Text { get; private set; }


        /// <summary>
        /// The ContentSizeFitter component which makes this fit size to its parent if fitToParent is true
        /// </summary>
        public ContentSizeFitter ContentSizeFitter { get; private set; }

        /// <inheritdoc />
        public ModHelperText(IntPtr ptr) : base(ptr)
        {
        }

        public static ModHelperText Create(Rect rect, string text, string objectName = "ModHelperText",
            bool fitToParent = false)
        {
            var modHelperText = ModHelperComponent.Create<ModHelperText>(rect, objectName);

            var textMesh = modHelperText.Text = modHelperText.AddComponent<NK_TextMeshProUGUI>();

            textMesh.SetText(text);

            if (fitToParent)
            {
                var fitter = modHelperText.ContentSizeFitter = modHelperText.AddComponent<ContentSizeFitter>();
            }

            return modHelperText;
        }
    }
}