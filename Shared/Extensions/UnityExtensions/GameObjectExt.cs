using System.Linq;
using BTD_Mod_Helper.Api.Components;
using Il2CppNinjaKiwi.Common;
using UnityEngine;
namespace BTD_Mod_Helper.Extensions;

/// <summary>
/// Extensions for GameObjects
/// </summary>
public static class GameObjectExt
{
    /// <summary>
    /// Finds a component with the given path and type
    /// </summary>
    public static T GetComponent<T>(this GameObject gameObject, string componentPath)
    {
        return gameObject.transform.Find(componentPath).GetComponent<T>();
    }

    /// <summary>
    /// Try to get a component in a child of this GameObject by it's name. Equivelant to a foreach with GetComponentsInChildren
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="gameObject"></param>
    /// <param name="componentName"></param>
    /// <returns></returns>
    public static T GetComponentInChildrenByName<T>(this GameObject gameObject, string componentName)
        where T : Component
    {
        return gameObject.transform.GetComponentsInChildren<T>(true)
            .FirstOrDefault(component => component.name == componentName);
    }

    /// <summary>
    /// Makes the Game Object visible by setting the scale to the default value of 1
    /// </summary>
    /// <param name="gameObject"></param>
    public static void Show(this GameObject gameObject)
    {
        gameObject.GetComponent<RectTransform>().localScale = new Vector3(1, 1);
    }

    /// <summary>
    /// Makes the Game Object hidden (not visible) by setting the scale to zero
    /// </summary>
    /// <param name="gameObject"></param>
    public static void Hide(this GameObject gameObject)
    {
        gameObject.GetComponent<RectTransform>().localScale = new Vector3(0, 0);
    }

    /// <summary>
    /// Destroys this GameObject
    /// </summary>
    /// <param name="gameObject"></param>
    public static void Destroy(this GameObject gameObject)
    {
        if (gameObject == null)
        {
            ModHelper.Warning("Tried to destroy null game object");
            return;
        }

        Object.Destroy(gameObject);
    }

    /// <summary>
    /// Logs a GameObject's hierarchy recursively
    /// </summary>
    public static void RecursivelyLog(this GameObject gameObject, int depth = 0)
    {
        var str = gameObject.name;
        for (var i = 0; i < depth; i++)
        {
            str = "|  " + str;
        }

        str += " (";
        str = gameObject.GetComponents<Component>().Aggregate(str, (current, component) => current + (" " + component.GetIl2CppType().Name));

        str += ")";
        ModHelper.Log(str);
        for (var i = 0; i < gameObject.transform.childCount; i++)
        {
            RecursivelyLog(gameObject.transform.GetChild(i).gameObject, depth + 1);
        }
    }

    /// <summary>
    /// Translates this GameObject scaled with it's "lossyScale", making it move the same
    /// amount regardless of screen resolution
    /// </summary>
    /// <param name="gameObject"></param>
    /// <param name="translation"></param>
    public static void TranslateScaled(this GameObject gameObject, Vector3 translation)
    {
        var transform = gameObject.transform;
        transform.TranslateScaled(translation);
    }

    /// <summary>
    /// Removes a Component from a GameObject by destroying it
    /// </summary>
    public static void RemoveComponent<T>(this GameObject gameObject) where T : Component
    {
        gameObject.GetComponent<T>()?.Destroy();
    }

    /// <summary>
    /// Returns whether a component of the given type exists on a game object
    /// </summary>
    public static bool HasComponent<T>(this GameObject gameObject) where T : Component
    {
        return gameObject.GetComponent<T>() != null;
    }

    /// <summary>
    /// Returns whether a component of the given type exists on a game object, and puts it in the out param
    /// </summary>
    public static bool HasComponent<T>(this GameObject gameObject, out T component) where T : Component
    {
        component = gameObject.GetComponent<T>();
        return component != null;
    }

    /// <summary>
    /// Instantiate a clone of the GameObject keeping the same parent
    /// </summary>
    public static T Duplicate<T>(this T gameObject) where T : Object
    {
        if (gameObject == null)
        {
            ModHelper.Warning("Tried to duplicate a null Unity Object");
            return null;
        }

        return Object.Instantiate(gameObject);
    }

    /// <summary>
    /// Instantiate a clone of the GameObject with the new transform as parent 
    /// </summary>
    public static T Duplicate<T>(this T gameObject, Transform parent) where T : Object
    {
        if (gameObject == null)
        {
            ModHelper.Warning("Tried to duplicate a null Unity Object");
            return null;
        }

        return Object.Instantiate(gameObject, parent);
    }

    /// <summary>
    /// Adds the ModHelperComponent to a parent GameObject, returning the ModHelperComponent
    /// <br/>
    /// (This is an extension method just so that we can return the type generically)
    /// </summary>
    public static T AddModHelperComponent<T>(this GameObject gameObject, T modHelperComponent)
        where T : ModHelperComponent
    {
        modHelperComponent.SetParent(gameObject.transform);
        return modHelperComponent;
    }

    /// <inheritdoc cref="ModHelperComponent.AddPanel(BTD_Mod_Helper.Api.Components.Info)"/>
    public static ModHelperPanel AddModHelperPanel(this GameObject gameObject, Info info,
        string backgroundSprite = null, RectTransform.Axis? layoutAxis = null, float spacing = 50,
        int padding = 0)
    {
        return gameObject.AddModHelperComponent(ModHelperPanel.Create(info, backgroundSprite, layoutAxis, spacing,
            padding));
    }

    /// <inheritdoc cref="ModHelperComponent.AddScrollPanel(BTD_Mod_Helper.Api.Components.Info)"/>
    public static ModHelperScrollPanel AddModHelperScrollPanel(this GameObject gameObject, Info info,
        RectTransform.Axis? axis, string backgroundSprite = null, float spacing = 0, int padding = 0)
    {
        return gameObject.AddModHelperComponent(ModHelperScrollPanel.Create(info, axis, backgroundSprite, spacing,
            padding));
    }

    /// <summary>
    /// Destroys all children of a game object
    /// </summary>
    public static void DestroyAllChildren(this GameObject gameObject)
    {
        // ReSharper disable once InvokeAsExtensionMethod
        TransformExtensions.DestroyAllChildren(gameObject.transform);
    }

    /// <summary>
    /// Used to null check unity objects without bypassing the lifecycle
    /// </summary>
    public static T Exists<T>(this T obj) where T : Object
    {
        return obj == null ? null : obj;
    }
        
    /// <summary>
    /// Used to null check unity objects without bypassing the lifecycle
    /// </summary>
    public static bool Exists<T>(this T obj, out T result) where T : Object
    {
        result = obj;
        return obj != null;
    }
}