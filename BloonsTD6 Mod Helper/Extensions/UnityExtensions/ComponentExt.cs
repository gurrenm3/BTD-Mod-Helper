using System.Linq;
using UnityEngine;
namespace BTD_Mod_Helper.Extensions;

/// <summary>
/// Extensions for Component
/// </summary>
public static class ComponentExt
{
    /// <summary>
    /// Finds the component with the given path and type
    /// </summary>
    public static T GetComponent<T>(this Component component, string componentPath) =>
        component.transform.Find(componentPath).GetComponent<T>();

    /// <summary>
    /// Try to get a component in a child of this Component by it's name. Equivalent to a foreach with GetComponentsInChildren
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="component"></param>
    /// <param name="componentName"></param>
    /// <returns></returns>
    public static T GetComponentFromChildrenByName<T>(this Component component, string componentName)
        where T : Component
    {
        return component.transform.GetComponentsInChildren<T>().FirstOrDefault(comp => comp.name == componentName);
    }
    
    /// <summary>
    /// Tries to get all component in a child of this Component by it's name. Equivalent to a foreach with GetComponentsInChildren
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="component"></param>
    /// <param name="componentName"></param>
    /// <returns></returns>
    public static T[] GetComponentsFromChildrenByName<T>(this Component component, string componentName)
        where T : Component
    {
        return component.transform.GetComponentsInChildren<T>().Where(comp => comp.name == componentName).ToArray();
    }

    /// <summary>
    /// Makes the Component visible by setting the scale to the default value of 1
    /// </summary>
    /// <param name="component"></param>
    public static void Show(this Component component)
    {
        component.GetComponent<RectTransform>().localScale = new Vector3(1, 1);
    }

    /// <summary>
    /// Makes the Component hidden (not visible) by setting the scale to zero
    /// </summary>
    /// <param name="component"></param>
    public static void Hide(this Component component)
    {
        component.GetComponent<RectTransform>().localScale = new Vector3(0, 0);
    }

    /// <summary>
    /// Translates this component scaled with it's "lossyScale", making it move the same
    /// amount regardless of screen resolution
    /// </summary>
    /// <param name="component"></param>
    /// <param name="translation"></param>
    public static void TranslateScaled(this Component component, Vector3 translation)
    {
        var transform = component.transform;
        var scale = transform.lossyScale.x;
        transform.Translate(translation * scale);
    }

    /// <summary>
    /// Destroys this Component
    /// </summary>
    public static void Destroy(this Component component)
    {
        Object.Destroy(component);
    }
}