using UnityEngine;

namespace BTD_Mod_Helper.Extensions
{
    public static class ComponentExt
    {
        public static T GetComponent<T>(this Component component, string componentPath)
        {
            return component.transform.Find(componentPath).GetComponent<T>();
        }
    }
}
