using System;
using Assets.Scripts.Utils;
using BTD_Mod_Helper.Extensions;
using Il2CppSystem.Collections.Generic;
using MelonLoader;
using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;
using Action = Il2CppSystem.Action;

namespace BTD_Mod_Helper.Api.Components
{
    /// <summary>
    /// Base for a helper component for making custom UIs in the same style as Vanilla ones
    /// </summary>
    [RegisterTypeInIl2Cpp(false)]
    public class ModHelperComponent : MonoBehaviour
    {
        /// <summary>
        /// The Info object that this was defined with, determining its initial name, position and size
        /// </summary>
        public Info Info { get; protected set; }

        /// <summary>
        /// Bool for if this should disable itself on the next frame
        /// </summary>
        public bool disableNextFrame;

        /// <summary>
        /// Bool for if this should enable itself on the next frame
        /// </summary>
        public bool enableNextFrame;

        /// <summary>
        /// The ModHelperComponent that this is a child of, if any
        /// </summary>
        public ModHelperComponent Parent { get; private set; }

        /// <summary>
        /// The RectTransform for this GameObject
        /// </summary>
        public RectTransform RectTransform => transform.Cast<RectTransform>();

        /// <summary>
        /// The LayoutElement component, if this has been assigned one
        /// </summary>
        public LayoutElement LayoutElement { get; protected set; }

        /// <summary>
        /// The LayoutGroup component, if this has been assigned one
        /// </summary>
        public HorizontalOrVerticalLayoutGroup LayoutGroup { get; protected set; }


        /// <inheritdoc />
        public ModHelperComponent(IntPtr ptr) : base(ptr)
        {
        }

        /// <summary>
        /// Sets a particular transform to be the parent of this
        /// </summary>
        public void SetParent(Transform parent)
        {
            var t = transform;
            t.parent = parent;
            Info.Apply(RectTransform);
        }

        /// <summary>
        /// Sets a particular ModHelperComponent to be the parent of this
        /// </summary>
        public void SetParent(ModHelperComponent parent)
        {
            Parent = parent;

            if (parent.LayoutGroup != null && !gameObject.HasComponent<ContentSizeFitter>())
            {
                AddLayoutElement();
            }

            SetParent(parent.transform);
        }

        /// <summary>
        /// Adds another ModHelperComponent as a child of this, returning the child
        /// </summary>
        public T Add<T>(T child) where T : ModHelperComponent
        {
            child.SetParent(this);
            return child;
        }

        /// <inheritdoc cref="GameObject.AddComponent{T}"/>
        public T AddComponent<T>() where T : Component
        {
            return gameObject.AddComponent<T>();
        }

        /// <summary>
        /// Adds and returns a LayoutElement for this, making it work as part of a LayoutGroup
        /// </summary>
        public LayoutElement AddLayoutElement()
        {
            if (LayoutElement == null)
            {
                LayoutElement = AddComponent<LayoutElement>();
            }

            LayoutElement.minWidth = LayoutElement.preferredWidth = Info.SizeDelta.x;
            LayoutElement.minHeight = LayoutElement.preferredHeight = Info.SizeDelta.y;
            LayoutElement.flexibleWidth = Info.FlexWidth;
            LayoutElement.flexibleHeight = Info.FlexHeight;

            return LayoutElement;
        }

        /// <summary>
        /// Adds and returns a ContentSizeFitter with the given properties
        /// </summary>
        public ContentSizeFitter FitContent(ContentSizeFitter.FitMode horizontal = ContentSizeFitter.FitMode.Unconstrained,
            ContentSizeFitter.FitMode vertical = ContentSizeFitter.FitMode.Unconstrained)
        {
            var contentSizeFitter = AddComponent<ContentSizeFitter>();
            contentSizeFitter.horizontalFit = horizontal;
            contentSizeFitter.verticalFit = vertical;

            if (LayoutElement != null)
            {
                LayoutElement.enabled = false;
            }

            return contentSizeFitter;
        }

        /// <inheritdoc cref="ModHelperPanel.Create"/>
        public ModHelperPanel AddPanel(Info info, SpriteReference backgroundSprite = null,
            RectTransform.Axis? layoutAxis = null, float spacing = 0, int padding = 0)
        {
            return Add(ModHelperPanel.Create(info, backgroundSprite, layoutAxis, spacing, padding));
        }

        /// <inheritdoc cref="ModHelperScrollPanel.Create(BTD_Mod_Helper.Api.Components.Info,System.Nullable{UnityEngine.RectTransform.Axis},Assets.Scripts.Utils.SpriteReference,float,int)"/>
        public ModHelperScrollPanel AddScrollPanel(Info info, RectTransform.Axis? axis,
            SpriteReference backgroundSprite = null, float spacing = 0, int padding = 0)
        {
            return Add(ModHelperScrollPanel.Create(info, axis, backgroundSprite, spacing, padding));
        }

        /// <inheritdoc cref="ModHelperText.Create"/>
        public ModHelperText AddText(Info info, string text, float fontSize = 42,
            TextAlignmentOptions align = TextAlignmentOptions.Midline)
        {
            return Add(ModHelperText.Create(info, text, fontSize, align));
        }

        /// <inheritdoc cref="ModHelperButton.Create"/>
        public ModHelperButton AddButton(Info info, SpriteReference sprite, Action onClick)
        {
            return Add(ModHelperButton.Create(info, sprite, onClick));
        }

        /// <inheritdoc cref="ModHelperImage.Create(BTD_Mod_Helper.Api.Components.Info,Assets.Scripts.Utils.SpriteReference)"/>
        public ModHelperImage AddImage(Info info, SpriteReference sprite)
        {
            return Add(ModHelperImage.Create(info, sprite));
        }

        /// <inheritdoc cref="ModHelperImage.Create(BTD_Mod_Helper.Api.Components.Info,Assets.Scripts.Utils.SpriteReference)"/>
        public ModHelperImage AddImage(Info info, Sprite sprite)
        {
            return Add(ModHelperImage.Create(info, sprite));
        }

        /// <inheritdoc cref="ModHelperDropdown.Create"/>
        public ModHelperDropdown AddDropdown(Info info, List<string> options, float windowHeight,
            UnityAction<int> onValueChanged,
            SpriteReference background = null, float labelFontSize = 42f)
        {
            return Add(ModHelperDropdown.Create(info, options, windowHeight, onValueChanged, background,
                labelFontSize));
        }

        /// <inheritdoc cref="ModHelperSlider.Create"/>
        public ModHelperSlider AddSlider(Info info, float defaultValue, float minValue, float maxValue,
            float stepSize, Vector2 handleSize, UnityAction<float> onValueChanged = null, float fontSize = 42f,
            string labelSuffix = "")
        {
            return Add(ModHelperSlider.Create(info, defaultValue, minValue, maxValue, stepSize, handleSize,
                onValueChanged, fontSize, labelSuffix));
        }

        /// <inheritdoc cref="ModHelperCheckbox.Create"/>
        public ModHelperCheckbox AddCheckbox(Info info, bool defaultValue, SpriteReference background,
            UnityAction<bool> onValueChanged = null, SpriteReference checkImage = null, int padding = 20)
        {
            return Add(ModHelperCheckbox.Create(info, defaultValue, background, onValueChanged, checkImage, padding));
        }

        /// <inheritdoc cref="ModHelperInputField.Create"/>
        public ModHelperInputField AddInputField(Info info, string defaultValue, SpriteReference background,
            UnityAction<string> onValueChanged = null, float fontSize = 42,
            TMP_InputField.CharacterValidation validation = TMP_InputField.CharacterValidation.None,
            TextAlignmentOptions align = TextAlignmentOptions.Midline, int padding = 20)
        {
            return Add(ModHelperInputField.Create(info, defaultValue, background, onValueChanged, fontSize, validation,
                align,
                padding));
        }

        internal static T Create<T>(Info info) where T : ModHelperComponent
        {
            var newGameObject = new GameObject(info.Name, new[] {UnhollowerRuntimeLib.Il2CppType.Of<RectTransform>()});
            var modHelperComponent = newGameObject.AddComponent<T>();
            modHelperComponent.Info = info;
            info.Apply(modHelperComponent);

            return modHelperComponent;
        }

        private void Update()
        {
            if (disableNextFrame)
            {
                disableNextFrame = false;
                gameObject.SetActive(false);
            }

            OnUpdate();
        }

        /// <summary>
        /// Unity Component Update
        /// </summary>
        protected virtual void OnUpdate()
        {
        }

        /// <summary>
        /// Implicitly get the gameObject
        /// </summary>
        public static implicit operator GameObject(ModHelperComponent component)
        {
            return component.gameObject;
        }

        /// <summary>
        /// Implicitly get the RectTransform
        /// </summary>
        public static implicit operator RectTransform(ModHelperComponent component)
        {
            return component.RectTransform;
        }
    }
}