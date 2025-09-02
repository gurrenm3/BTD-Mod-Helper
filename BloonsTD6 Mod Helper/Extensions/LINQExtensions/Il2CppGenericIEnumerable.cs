using Il2CppSystem;
using Il2CppSystem.Collections.Generic;
using Il2CppSystem.Linq;

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
        using var enumerator = source.GetIl2CppEnumerator();

        while (enumerator.MoveNext())
            action.Invoke(enumerator.Current);
    }

    /// <summary>
    /// Return whether or not there are any elements in this
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="source"></param>
    /// <returns></returns>
    public static bool Any<T>(this IEnumerable<T> source) where T : Object => Enumerable.Any(source);

    /// <summary>
    /// Return whether or not there are any elements in this that match the predicate
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="source"></param>
    /// <param name="predicate"></param>
    /// <returns></returns>
    public static bool Any<T>(this IEnumerable<T> source, System.Func<T, bool> predicate) where T : Object =>
        Enumerable.Any(source, predicate);

    /// <summary>
    /// Return the last item in the collection
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="source"></param>
    /// <returns></returns>
    public static T Last<T>(this IEnumerable<T> source) where T : Object => Enumerable.Last(source);

    /// <summary>
    /// Return the last item in the collection that meets the condition, or return default
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="source"></param>
    /// <param name="predicate"></param>
    /// <returns></returns>
    public static T LastOrDefault<T>(this IEnumerable<T> source, System.Func<T, bool> predicate) where T : Object =>
        Enumerable.LastOrDefault(source, predicate);

    /// <summary>
    /// Return the first element in the collection
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="source"></param>
    /// <returns></returns>
    public static T First<T>(this IEnumerable<T> source) where T : Object => Enumerable.First(source);

    /// <summary>
    /// Return the first element in the collection, or return default if it's null
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="source"></param>
    /// <returns></returns>
    public static T FirstOrDefault<T>(this IEnumerable<T> source) where T : Object => Enumerable.FirstOrDefault(source);

    /// <summary>
    /// Return the first element that matches the predicate, or return default
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="source"></param>
    /// <param name="predicate"></param>
    /// <returns></returns>
    public static T FirstOrDefault<T>(this IEnumerable<T> source, System.Func<T, bool> predicate) where T : Object =>
        Enumerable.FirstOrDefault(source, predicate);

    /// <summary>
    /// Converts this Il2cpp IEnumerable to a non il2cpp IEnumerable
    /// </summary>
    public static System.Collections.Generic.IEnumerable<T> AsIEnumerable<T>(this IEnumerable<T> source)
    {
        using var enumerator = source.GetIl2CppEnumerator();
        while (enumerator.MoveNext())
            yield return enumerator.Current;
    }

    /// <summary>
    /// Converts this Il2cpp ICollection to a non il2cpp IEnumerable
    /// </summary>
    public static System.Collections.Generic.IEnumerable<T> AsIEnumerable<T>(this ICollection<T> source)
    {
        return source.Cast<IEnumerable<T>>().AsIEnumerable();
    }

    /// <summary>
    /// Converts this Il2cpp IList to a non il2cpp IEnumerable
    /// </summary>
    public static System.Collections.Generic.IEnumerable<T> AsIEnumerable<T>(this IList<T> source)
    {
        return source.Cast<IEnumerable<T>>().AsIEnumerable();
    }
}