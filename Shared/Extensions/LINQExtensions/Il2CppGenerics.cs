using Il2CppSystem.Collections.Generic;
using System;
using Il2CppSystem.Linq;

namespace BTD_Mod_Helper.Extensions;

/// <summary>
/// Extensions for il2cpp lists 
/// </summary>
public static class Il2CppGenerics
{
    /// <summary>
    /// Return the first element that matches the predicate
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="source"></param>
    /// <param name="predicate"></param>
    /// <returns></returns>
    public static T First<T>(this List<T> source, Func<T, bool> predicate) where T : Il2CppSystem.Object
    {
        return Enumerable.First(source.Cast<IEnumerable<T>>(), predicate);
    }

    /// <summary>
    /// Return the first element that matches the predicate, or return default
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="source"></param>
    /// <param name="predicate"></param>
    /// <returns></returns>
    public static T FirstOrDefault<T>(this List<T> source, Func<T, bool> predicate) where T : Il2CppSystem.Object
    {
        return Enumerable.FirstOrDefault(source.Cast<IEnumerable<T>>(), predicate);
    }

    /// <summary>
    /// Return all elements that match the predicate
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="source"></param>
    /// <param name="predicate"></param>
    /// <returns></returns>
    public static List<T> Where<T>(this List<T> source, Func<T, bool> predicate) where T : Il2CppSystem.Object
    {
        return Enumerable.Where(source.Cast<IEnumerable<T>>(), predicate).ToIl2CppList();
    }

    /// <summary>
    /// Return the index of the element that matches the predicate
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="source"></param>
    /// <param name="predicate"></param>
    /// <returns></returns>
    public static int FindIndex<T>(this List<T> source, Func<T, bool> predicate) where T : Il2CppSystem.Object
    {
        return source.FindIndex(predicate);
    }

    /// <summary>
    /// Return whether or not there are any elements in this
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="source"></param>
    /// <returns></returns>
    public static bool Any<T>(this List<T> source) where T : Il2CppSystem.Object
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
    public static bool Any<T>(this List<T> source, Func<T, bool> predicate) where T : Il2CppSystem.Object
    {
        foreach (var _ in source.Where(predicate))
        {
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
    public static T Last<T>(this List<T> source)
    {
        return Enumerable.Last(source.Cast<IEnumerable<T>>());
    }

    /// <summary>
    /// Return the last item in the collection that meets the condition, or return default
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="source"></param>
    /// <param name="predicate"></param>
    /// <returns></returns>
    public static T LastOrDefault<T>(this List<T> source, Func<T, bool> predicate)
    {
        return Enumerable.LastOrDefault(Enumerable.Where(source.Cast<IEnumerable<T>>(), predicate));
    }

    /// <summary>
    /// Return the first element in the collection
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="source"></param>
    /// <returns></returns>
    public static T First<T>(this List<T> source)
    {
        return Enumerable.First(source.Cast<IEnumerable<T>>());
    }

    /// <summary>
    /// Return the first element in the collection, or return default if it's null
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="source"></param>
    /// <returns></returns>
    public static T FirstOrDefault<T>(this List<T> source)
    {
        return Enumerable.FirstOrDefault(source.Cast<IEnumerable<T>>());
    }
}