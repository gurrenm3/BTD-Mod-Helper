using System;
using System.Collections.Generic;
using Il2CppAssets.Scripts.Utils;
using Object = Il2CppSystem.Object;
namespace BTD_Mod_Helper.Extensions;

/// <summary>
/// Extensions for LockedLists
/// </summary>
public static class LockedList
{
    /// <summary>
    /// Performs the specified action on each element
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="source"></param>
    /// <param name="action">Action to preform on each element</param>
    public static void ForEach<T>(this LockList<T> source, Action<T> action)
    {
        for (var i = 0; i < source.Count; i++)
            action.Invoke(source[i]);
    }

    /// <summary>
    /// Return the first element that matches the predicate
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="source"></param>
    /// <param name="predicate"></param>
    /// <returns></returns>
    public static T First<T>(this LockList<T> source, Func<T, bool> predicate) where T : Object
    {
        for (var i = 0; i < source.Count; i++)
        {
            var item = source[i];
            if (predicate(item))
                return item;
        }

        throw new ArgumentNullException(nameof(source), "No element satisfies the condition in predicate.");
    }

    /// <summary>
    /// Return the first element that matches the predicate, or return default
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="source"></param>
    /// <param name="predicate"></param>
    /// <returns></returns>
    public static T FirstOrDefault<T>(this LockList<T> source, Func<T, bool> predicate) where T : Object
    {
        for (var i = 0; i < source.Count; i++)
        {
            var item = source[i];
            if (predicate(item))
                return item;
        }
        return default;
    }

    /// <summary>
    /// Return all elements that match the predicate
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="source"></param>
    /// <param name="predicate"></param>
    /// <returns></returns>
    public static List<T> Where<T>(this LockList<T> source, Func<T, bool> predicate) where T : Object
    {
        var result = new List<T>();
        for (var i = 0; i < source.Count; i++)
        {
            var item = source[i];
            if (predicate(item))
                result.Add(item);
        }
        return result;
    }

    /// <summary>
    /// Return the index of the element that matches the predicate
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="source"></param>
    /// <param name="predicate"></param>
    /// <returns></returns>
    public static int FindIndex<T>(this LockList<T> source, Func<T, bool> predicate) where T : Object
    {
        for (var i = 0; i < source.Count; i++)
        {
            if (predicate(source[i]))
                return i;
        }

        return -1;
    }

    /// <summary>
    /// Return whether or not there are any elements in this
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="source"></param>
    /// <returns></returns>
    public static bool Any<T>(this LockList<T> source) where T : Object
    {
        return source.Count > 0;
    }

    /// <summary>
    /// Return whether or not there are any elements in this that match the predicate
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="source"></param>
    /// <param name="predicate"></param>
    /// <returns></returns>
    public static bool Any<T>(this LockList<T> source, Func<T, bool> predicate) where T : Object
    {
        for (var i = 0; i < source.Count; i++)
        {
            if (predicate(source[i]))
                return true;
        }
        return false;
    }


    /// <summary>
    /// Return the last item in the collection
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="source"></param>
    /// <returns></returns>
    public static T Last<T>(this LockList<T> source)
    {
        return source[^1];
    }

    /// <summary>
    /// Return the last item in the collection that meets the condition, or return default
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="source"></param>
    /// <param name="predicate"></param>
    /// <returns></returns>
    public static T LastOrDefault<T>(this LockList<T> source, Func<T, bool> predicate)
    {
        T last = default;
        for (var i = 0; i < source.Count; i++)
        {
            var item = source[i];
            if (predicate(item))
                last = item;
        }

        return last;
    }

    /// <summary>
    /// Return the first element in the collection
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="source"></param>
    /// <returns></returns>
    public static T First<T>(this LockList<T> source)
    {
        return source[0];
    }

    /// <summary>
    /// Return the first element in the collection, or return default if it's null
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="source"></param>
    /// <returns></returns>
    public static T FirstOrDefault<T>(this LockList<T> source)
    {
        return source[0] == null ? default : source[0];
    }
}