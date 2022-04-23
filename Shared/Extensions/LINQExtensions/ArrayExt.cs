using System;

namespace BTD_Mod_Helper.Extensions;

/// <summary>
/// Extensions for Arrays
/// </summary>
public static partial class ArrayExt
{
    /// <summary>
    /// (Cross-Game compatible) Performs the specified action on each element
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="array"></param>
    /// <param name="action">Action to preform on each element</param>
    public static void ForEach<T>(this T[] array, Action<T> action)
    {
        for (var i = 0; i < array.Length; i++)
            action.Invoke(array[i]);
    }

    /// <summary>
    /// (Cross-Game compatible) Retrieves all the elements that match the conditions defined by the specified predicate.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="array"></param>
    /// <param name="match"> The Predicate delegate that defines the conditions of the elements to search for.</param>
    /// <returns></returns>
    public static T[] FindAll<T>(this T[] array, Predicate<T> match)
    {
        return Array.FindAll(array, match);
    }

    /// <summary>
    /// (Cross-Game compatible) Return whether or not there are any elements in this
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="array"></param>
    /// <returns></returns>
    public static bool Any<T>(this T[] array)
    {
        return array.Length > 0;
    }

    /// <summary>
    /// (Cross-Game compatible) Return whether or not there are any elements in this that match the predicate
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="array"></param>
    /// <param name="predicate"></param>
    /// <returns></returns>
    public static bool Any<T>(this T[] array, Func<T, bool> predicate)
    {
        foreach (var item in array)
        {
            if (predicate(item))
                return true;
        }
        return false;
    }
}