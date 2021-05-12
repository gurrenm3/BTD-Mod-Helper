using UnityEngine;
using System.Linq;

namespace BTD_Mod_Helper.Extensions
{
    public static class ComponentExt
    {
        public static T GetComponent<T>(this Component component, string componentPath)
        {
            return component.transform.Find(componentPath).GetComponent<T>();
        }

        /// <summary>
        /// (Cross-Game compatible) Try to get a component in a child of this Component by it's name. Equivelant to a foreach with GetComponentsInChildren
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="component"></param>
        /// <param name="componentName"></param>
        /// <returns></returns>
        public static T GetComponentFromChildrenByName<T>(this Component component, string componentName) where T : Component
        {
            return component.transform.GetComponentsInChildren<T>().FirstOrDefault(comp => comp.name == componentName);
        }

        /// <summary>
        /// (Cross-Game compatible) Makes the Component visible by setting the scale to the default value of 1
        /// </summary>
        /// <param name="component"></param>
        public static void Show(this Component component)
        {
            component.GetComponent<RectTransform>().localScale = new Vector3(1, 1);
        }

        /// <summary>
        /// (Cross-Game compatible) Makes the Component hidden (not visible) by setting the scale to zero
        /// </summary>
        /// <param name="component"></param>
        public static void Hide(this Component component)
        {
            component.GetComponent<RectTransform>().localScale = new Vector3(0, 0);
        }
    }
}
