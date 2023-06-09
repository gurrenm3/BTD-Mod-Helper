using Il2CppSystem;
namespace BTD_Mod_Helper.Extensions;

/// <summary>
/// Extensions for il2cpp reference arrays
/// </summary>
public static class Il2CppReferenceArray
{
    /// <summary>
    /// Performs the specified action on each element
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="source"></param>
    /// <param name="action">Action to preform on each element</param>
    public static void ForEach<T>(this Il2CppReferenceArray<T> source, System.Action<T> action) where T : Object
    {
        for (var i = 0; i < source.Count; i++)
            action.Invoke(source[i]);
    }

    /// <summary>
    /// Return the index of the element that matches the predicate
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="source"></param>
    /// <param name="predicate"></param>
    /// <returns></returns>
    public static int FindIndex<T>(this Il2CppReferenceArray<T> source, System.Func<T, bool> predicate) where T : Object
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
    public static bool Any<T>(this Il2CppReferenceArray<T> source) where T : Object
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
    public static bool Any<T>(this Il2CppReferenceArray<T> source, System.Func<T, bool> predicate) where T : Object
    {
        for (var i = 0; i < source.Count; i++)
        {
            if (predicate(source[i]))
                return true;
        }
        return false;
    }
}