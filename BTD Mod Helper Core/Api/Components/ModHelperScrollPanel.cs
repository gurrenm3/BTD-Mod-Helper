using System;
using Assets.Scripts.Utils;
using BTD_Mod_Helper.Extensions;
using MelonLoader;
using UnityEngine;
using UnityEngine.UI;

namespace BTD_Mod_Helper.Api.Components
{
    /// <summary>
    /// ModHelperComponent for a background panel
    /// </summary>
    [RegisterTypeInIl2Cpp(false)]
    public class ModHelperScrollPanel : ModHelperPanel
    {
        /// <summary>
        /// The ScrollContent object. This is the object that the children are actually part of,
        /// and is what actually moves up and down when scrolling.
        /// </summary>
        public GameObject ScrollContent { get; private set; }
        
        /// <summary>
        /// The ScrollRect component which controls many aspects of scrolling
        /// </summary>
        public ScrollRect ScrollRect { get; private set; }
        
        /// <summary>
        /// The Mask component which prevents overflow of rendering outside the scroll area
        /// </summary>
        public Mask Mask { get; private set; }
        
        /// <summary>
        /// The LayoutGroup component which lines up all the scrollable content nicely
        /// </summary>
        public HorizontalOrVerticalLayoutGroup LayoutGroup { get; private set; }
        
        /// <summary>
        /// The ContentSizeFitter component which makes sure that the ScrollContent
        /// is the right size to hold all the scrollable items.
        /// </summary>
        public ContentSizeFitter ContentSizeFitter { get; private set; }

        /// <inheritdoc />
        public ModHelperScrollPanel(IntPtr ptr) : base(ptr)
        {
        }

        /// <summary>
        /// Adds a child to the ScrollContent of this panel
        /// </summary>
        public void AddScrollContent(ModHelperComponent child)
        {
            child.AddTo(ScrollContent.transform);
            child.AddLayoutElement();
        }

        /// <summary>
        /// Creates a new ModHelperScrollPanel
        /// </summary>
        /// <param name="rect">The position (offset of child center from parent center) and size</param>
        /// <param name="axis">The axis that it scrolls in, or null for both directions</param>
        /// <param name="objectName">The Unity name of the object</param>
        /// <param name="backgroundSprite">The panel's background sprite</param>
        /// <param name="spacing">If axis is not null, then the layout spacing for the items</param>
        /// <returns>The created ModHelperScrollPanel</returns>
        public static ModHelperScrollPanel Create(Rect rect, RectTransform.Axis? axis,
            string objectName = "ModHelperPanel", SpriteReference backgroundSprite = null, float spacing = 0)
        {
            var newPanel = Create<ModHelperScrollPanel>(rect, objectName, backgroundSprite);
            var scrollRect = newPanel.ScrollRect = newPanel.AddComponent<ScrollRect>();

            var scrollContent = newPanel.ScrollContent = new GameObject("ScrollContent", new[]
                {UnhollowerRuntimeLib.Il2CppType.Of<RectTransform>()});
            scrollContent.transform.parent = newPanel;

            scrollRect.content = scrollContent.transform.Cast<RectTransform>();
            scrollRect.content.pivot = new Vector2(0.5f, 1);
            scrollRect.viewport = newPanel.RectTransform;
            scrollRect.scrollSensitivity = 100;

            newPanel.Mask = newPanel.AddComponent<Mask>();

            if (axis != null)
            {
                var contentSizeFitter = newPanel.ContentSizeFitter = scrollContent.AddComponent<ContentSizeFitter>();
                contentSizeFitter.horizontalFit = ContentSizeFitter.FitMode.PreferredSize;
                contentSizeFitter.verticalFit = ContentSizeFitter.FitMode.PreferredSize;
                if (axis == RectTransform.Axis.Horizontal)
                {
                    scrollRect.vertical = false;
                    newPanel.LayoutGroup = newPanel.LayoutGroup = scrollContent.AddComponent<HorizontalLayoutGroup>();
                }
                else
                {
                    scrollRect.horizontal = false;
                    newPanel.LayoutGroup = newPanel.LayoutGroup = scrollContent.AddComponent<VerticalLayoutGroup>();
                }

                newPanel.LayoutGroup.spacing = spacing;
            }


            return newPanel;
        }

        /// <inheritdoc />
        protected override void Initialize()
        {
            base.Initialize();
            ScrollRect.normalizedPosition = Vector2.one;
        }
    }
    
}