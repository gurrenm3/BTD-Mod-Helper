using System;
using Assets.Scripts.Utils;
using MelonLoader;
using TMPro;
using UnityEngine;
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
        private Vector3 initialPosition;
        private Vector2 initialSize;

        /// <summary>
        /// Whether <see cref="Initialize"/> has been called yet
        /// </summary>
        public bool Initialized { get; private set; }

        /// <summary>
        /// The RrectTransform for this Game Object
        /// </summary>
        public RectTransform RectTransform => transform.Cast<RectTransform>();

        public LayoutElement LayoutElement { get; private set; }

        /// <inheritdoc />
        public ModHelperComponent(IntPtr ptr) : base(ptr)
        {
        }

        /// <summary>
        /// Adds another ModHelperComponent as a child of this, returning the child
        /// </summary>
        public T Add<T>(T child) where T : ModHelperComponent
        {
            child.transform.parent = transform;
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
            LayoutElement = AddComponent<LayoutElement>();
            LayoutElement.minHeight = LayoutElement.preferredHeight = initialSize.y;
            LayoutElement.minWidth = LayoutElement.preferredWidth = initialSize.x;

            return LayoutElement;
        }

        /// <inheritdoc cref="ModHelperPanel.Create"/>
        public ModHelperPanel AddPanel(Rect rect, string objectName = "ModHelperPanel",
            SpriteReference backgroundSprite = null)
        {
            return Add(ModHelperPanel.Create(rect, objectName, backgroundSprite));
        }

        /// <inheritdoc cref="ModHelperScrollPanel.Create(UnityEngine.Rect,System.Nullable{UnityEngine.RectTransform.Axis},string,Assets.Scripts.Utils.SpriteReference,float)"/>
        public ModHelperScrollPanel AddScrollPanel(Rect rect, RectTransform.Axis? axis,
            string objectName = "ModHelperPanel", SpriteReference backgroundSprite = null, float spacing = 0)
        {
            return Add(ModHelperScrollPanel.Create(rect, axis, objectName, backgroundSprite, spacing));
        }

        /// <inheritdoc cref="ModHelperText.Create"/>
        public ModHelperText AddText(Rect rect, string text, float fontSize = 42,
            TextAlignmentOptions align = TextAlignmentOptions.Center, string objectName = "ModHelperText")
        {
            return Add(ModHelperText.Create(rect, text, fontSize, align, objectName));
        }

        /// <inheritdoc cref="ModHelperButton.Create"/>
        public ModHelperButton AddButton(Rect rect, SpriteReference sprite, Action onClick,
            string objectName = "ModHelperButton")
        {
            return Add(ModHelperButton.Create(rect, sprite, onClick, objectName));
        }

        /// <inheritdoc cref="ModHelperImage.Create(UnityEngine.Rect,Assets.Scripts.Utils.SpriteReference,string)"/>
        public ModHelperImage AddImage(Rect rect, SpriteReference sprite, string objectName = "ModHelperImage")
        {
            return Add(ModHelperImage.Create(rect, sprite, objectName));
        }
        
        /// <inheritdoc cref="ModHelperImage.Create(UnityEngine.Rect,Assets.Scripts.Utils.SpriteReference,string)"/>
        public ModHelperImage AddImage(Rect rect, Sprite sprite, string objectName = "ModHelperImage")
        {
            return Add(ModHelperImage.Create(rect, sprite, objectName));
        }

        internal static T Create<T>(Rect rect, string objectName = "ModHelperComponent") where T : ModHelperComponent
        {
            var newGameObject = new GameObject(objectName, new[] {UnhollowerRuntimeLib.Il2CppType.Of<RectTransform>()});
            var modHelperComponent = newGameObject.AddComponent<T>();
            var rectTransform = newGameObject.transform.Cast<RectTransform>();
            rectTransform.anchorMax = rectTransform.anchorMin = new Vector2(0.5f, 0.5f);
            rectTransform.localScale = Vector3.one;

            modHelperComponent.initialSize = rectTransform.sizeDelta = new Vector2(rect.width, rect.height);
            modHelperComponent.initialPosition = rectTransform.localPosition = new Vector3(rect.x, rect.y);

            return modHelperComponent;
        }

        private void Update()
        {
            if (!Initialized)
            {
                Initialize();
            }

            Initialized = true;
        }

        /// <summary>
        /// Performs one-time tasks on the first frame after this is created
        /// </summary>
        protected virtual void Initialize()
        {
            var t = transform;
            t.localScale = Vector3.one;
            t.localPosition = initialPosition;
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