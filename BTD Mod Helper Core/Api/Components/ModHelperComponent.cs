using System;
using Assets.Scripts.Utils;
using MelonLoader;
using UnityEngine;

namespace BTD_Mod_Helper.Api.Components
{
    /// <summary>
    /// Base component for a 
    /// </summary>
    [RegisterTypeInIl2Cpp(false)]
    public class ModHelperComponent : MonoBehaviour
    {
        /// <summary>
        /// The RrectTransform for this Game Object
        /// </summary>
        public RectTransform RectTransform => transform.Cast<RectTransform>();

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
        /// Creates a new ModHelperPanel and adds it to this ModHelperComponent
        /// </summary>
        /// <param name="rect">The position and size</param>
        /// <param name="objectName">The Unity name of the object</param>
        /// <param name="backgroundSprite">The panel's background sprite</param>
        /// <returns>The created ModHelperPanel</returns>
        public ModHelperPanel AddPanel(Rect rect, string objectName = "ModHelperPanel",
            SpriteReference backgroundSprite = null)
        {
            return Add(ModHelperPanel.Create(rect, objectName, backgroundSprite));
        }
        
        /// <summary>
        /// Creates a new ModHelperScrollPanel and adds it to this ModHelperComponent
        /// </summary>
        /// <param name="rect">The position and size</param>
        /// <param name="axis">The axis that it scrolls in, or null for both directions</param>
        /// <param name="objectName">The Unity name of the object</param>
        /// <param name="backgroundSprite">The panel's background sprite</param>
        /// <param name="spacing">If axis is not null, then the layout spacing for the items</param>
        /// <returns>The created ModHelperScrollPanel</returns>
        public ModHelperScrollPanel AddScrollPanel(Rect rect, RectTransform.Axis? axis,
            string objectName = "ModHelperPanel", SpriteReference backgroundSprite = null, float spacing = 0)
        {
            return Add(ModHelperScrollPanel.Create(rect, axis, objectName, backgroundSprite, spacing));
        }

        internal static T Create<T>(Rect rect, string objectName = "ModHelperComponent") where T : ModHelperComponent
        {
            var newGameObject = new GameObject(objectName, new[] {UnhollowerRuntimeLib.Il2CppType.Of<RectTransform>()});
            var rectTransform = newGameObject.transform.Cast<RectTransform>();
            rectTransform.sizeDelta = new Vector2(rect.width, rect.height); // TODO scale this?
            rectTransform.localPosition = new Vector3(rect.x, rect.y);
            rectTransform.localScale = Vector3.one;

            return newGameObject.AddComponent<T>();
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