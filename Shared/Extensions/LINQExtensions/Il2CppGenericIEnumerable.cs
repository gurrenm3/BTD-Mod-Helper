using Il2CppSystem;
using Il2CppSystem.Collections.Generic;
using Exception = System.Exception;
namespace BTD_Mod_Helper.Extensions;

/// <summary>
/// Extensions for Il2cpp Ienumerables
/// </summary>
public static class Il2CppGenericIEnumerable
{
    /// <summary>
    /// Performs the specified action on each element
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="source"></param>
    /// <param name="action">Action to preform on each element</param>
    public static void ForEach<T>(this IEnumerable<T> source, System.Action<T> action) where T : Object
    {
        var enumerator = source.GetEnumeratorCollections();
        while (enumerator.MoveNext())
            action.Invoke(enumerator.Current.Cast<T>());
    }

    /// <summary>
    /// Return whether or not there are any elements in this
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="source"></param>
    /// <returns></returns>
    public static bool Any<T>(this IEnumerable<T> source) where T : Object
    {
        while (source.GetEnumeratorCollections().MoveNext())
            return true;

        return false;
    }

    /// <summary>
    /// Return whether or not there are any elements in this that match the predicate
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="source"></param>
    /// <param name="predicate"></param>
    /// <returns></returns>
    public static bool Any<T>(this IEnumerable<T> source, System.Func<T, bool> predicate) where T : Object
    {
        var enumerator = source.GetEnumeratorCollections();
        while (enumerator.MoveNext())
        {
            if (predicate(enumerator.Current.Cast<T>()))
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
    public static T Last<T>(this IEnumerable<T> source) where T : Object
    {
        var enumerator = source.GetEnumeratorCollections();
        T last = default;

        while (enumerator.MoveNext())
        {
            last = enumerator.Current.Cast<T>();
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
    public static T LastOrDefault<T>(this IEnumerable<T> source, System.Func<T, bool> predicate) where T : Object
    {
        var enumerator = source.GetEnumeratorCollections();
        T last = default;

        while (enumerator.MoveNext())
        {
            var item = enumerator.Current.Cast<T>();
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
    public static T First<T>(this IEnumerable<T> source) where T : Object 
    {
        var enumerator = source.GetEnumeratorCollections();

        while (enumerator.MoveNext())
        {
            return enumerator.Current.Cast<T>();
        }

        throw new Exception();
    }

    /// <summary>
    /// Return the first element in the collection, or return default if it's null
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="source"></param>
    /// <returns></returns>
    public static T FirstOrDefault<T>(this IEnumerable<T> source) where T : Object
    {
        var enumerator = source.GetEnumeratorCollections();
        if (enumerator is null)
            return default;

        while (enumerator.MoveNext())
        {
            return enumerator.Current.Cast<T>();
        }

        return default;
    }

    /// <summary>
    /// Return the first element that matches the predicate, or return default
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="source"></param>
    /// <param name="predicate"></param>
    /// <returns></returns>
    public static T FirstOrDefault<T>(this IEnumerable<T> source, System.Func<T, bool> predicate) where T : Object
    {
        var enumerator = source.GetEnumeratorCollections();
        while (enumerator.MoveNext())
        {
            var item = enumerator.Current.Cast<T>();
            if (predicate(item))
                return item;
        }

        return default;
    }
}