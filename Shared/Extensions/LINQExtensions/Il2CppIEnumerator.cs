using System.Collections.Generic;
using Il2CppSystem;
using Il2CppSystem.Collections;
using Exception = System.Exception;
using NullReferenceException = System.NullReferenceException;
namespace BTD_Mod_Helper.Extensions;

/// <summary>
/// Extensions for il2cpp ienumerators
/// </summary>
public static class Il2CppIEnumerator
{
    /// <summary>
    /// Performs the specified action on each element
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="source"></param>
    /// <param name="action">Action to preform on each element</param>
    public static void ForEach<T>(this IEnumerator source, System.Action<T> action) where T : Object
    {
        while (source.MoveNext())
            action.Invoke(source.Current.Cast<T>());
    }

    /// <summary>
    /// Return the first element that matches the predicate
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="source"></param>
    /// <param name="predicate"></param>
    /// <returns></returns>
    public static T First<T>(this IEnumerator source, System.Func<T, bool> predicate) where T : Object
    {
        while (source.MoveNext())
        {
            var item = source.Current.Cast<T>();
            if (predicate(item))
                return item;
        }
        throw new NullReferenceException();
    }

    /// <summary>
    /// Return the first element that matches the predicate, or return default
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="source"></param>
    /// <param name="predicate"></param>
    /// <returns></returns>
    public static T FirstOrDefault<T>(this IEnumerator source, System.Func<T, bool> predicate) where T : Object
    {
        while (source.MoveNext())
        {
            var item = source.Current.Cast<T>();
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
    public static List<T> Where<T>(this IEnumerator source, System.Func<T, bool> predicate) where T : Object
    {
        var result = new List<T>();
        while (source.MoveNext())
        {
            var item = source.Current.Cast<T>();
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
    public static int FindIndex<T>(this IEnumerator source, System.Func<T, bool> predicate) where T : Object
    {
        var i = 0;
        while (source.MoveNext())
        {
            if (predicate(source.Current.Cast<T>()))
                return i;
            i++;
        }

        return -1;
    }

    /// <summary>
    /// Return whether or not there are any elements in this that match the predicate
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="source"></param>
    /// <param name="predicate"></param>
    /// <returns></returns>
    public static bool Any<T>(this IEnumerator source, System.Func<T, bool> predicate) where T : Object
    {
        while (source.MoveNext())
        {
            if (predicate(source.Current.Cast<T>()))
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
    public static T Last<T>(this IEnumerator source) where T : Object
    {
        T last = default;
        while (source.MoveNext())
        {
            last = source.Current.Cast<T>();
        }
        return last;
    }

    /// <summary>
    /// Return the last item in the collection that meets the condition, or return default
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="source"></param>
    /// <param name="predicate"></param>
    /// <returns></returns>
    public static T LastOrDefault<T>(this IEnumerator source, System.Func<T, bool> predicate) where T : Object
    {
        T last = default;

        while (source.MoveNext())
        {
            var item = source.Current.Cast<T>();
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
    public static T First<T>(this IEnumerator source) where T : Object
    {
        while (source.MoveNext())
        {
            return source.Current.Cast<T>();
        }

        throw new Exception();
    }

    /// <summary>
    /// Return the first element in the collection, or return default if it's null
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="source"></param>
    /// <returns></returns>
    public static T FirstOrDefault<T>(this IEnumerator source) where T : Object
    {
        while (source.MoveNext())
        {
            return source.Current.Cast<T>();
        }

        return default;
    }
}