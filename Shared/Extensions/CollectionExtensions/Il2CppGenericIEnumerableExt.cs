using Il2CppAssets.Scripts.Utils;
using Il2CppSystem;
using Il2CppSystem.Collections;
using Il2CppSystem.Collections.Generic;
namespace BTD_Mod_Helper.Extensions;

/// <summary>
/// Extensions for il2cpp ienumerables 
/// </summary>
public static class Il2CppGenericIEnumerableExt
{
    /// <summary>
    /// Get the IEnumerator as type Il2CppSystem.Collections.IEnumerator. Needed for IEnumerator.MoveNext(). Not the same as IEnumerable.GetEnumerator()
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="enumerable"></param>
    /// <returns></returns>
    public static IEnumerator GetEnumeratorCollections<T>(this IEnumerable<T> enumerable)
    {
        return enumerable.GetEnumerator().Cast<IEnumerator>();
    }

    /// <summary>
    /// Get the total number of elements
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="enumerable"></param>
    /// <returns></returns>
    public static int Count<T>(this IEnumerable<T> enumerable)
    {
        var length = 0;
        var enumerator = enumerable.GetEnumeratorCollections();
        while (enumerator.MoveNext())
            length++;

        return length;
    }

    /// <summary>
    /// Return the Item at a specific index
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="enumerable"></param>
    /// <param name="index"></param>
    /// <returns></returns>
    public static Object GetItem<T>(this IEnumerable<T> enumerable, int index)
    {
        var i = 0;
        var enumerator = enumerable.GetEnumeratorCollections();
        while (enumerator.MoveNext())
        {
            if (i == index)
                return enumerator.Current;
            i++;
        }

        return null;
    }

    /// <summary>
    /// Return as Il2CppSystem.List
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="enumerable"></param>
    /// <returns></returns>
    public static List<T> ToIl2CppList<T>(this IEnumerable<T> enumerable) where T : Object
    {
        var il2CppList = new List<T>();

        var enumerator = enumerable.GetEnumeratorCollections();
        while (enumerator.MoveNext())
            il2CppList.Add(enumerator.Current.Cast<T>());

        return il2CppList;
    }

    /// <summary>
    /// Return as System.List
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="enumerable"></param>
    /// <returns></returns>
    public static System.Collections.Generic.List<T> ToList<T>(this IEnumerable<T> enumerable) where T : Object
    {
        var list = new System.Collections.Generic.List<T>();

        var enumerator = enumerable.GetEnumeratorCollections();
        while (enumerator.MoveNext())
            list.Add(enumerator.Current.Cast<T>());

        return list;
    }

    /// <summary>
    /// Return as Il2CppReferenceArray
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="enumerable"></param>
    /// <returns></returns>
    public static Il2CppReferenceArray<T> ToIl2CppReferenceArray<T>(this IEnumerable<T> enumerable) where T : Object
    {
        var il2cppArray = new Il2CppReferenceArray<T>(enumerable.Count());

        var i = 0;
        var enumerator = enumerable.GetEnumeratorCollections();
        while (enumerator.MoveNext())
        {
            il2cppArray[i] = enumerator.Current.Cast<T>();
            i++;
        }

        return il2cppArray;
    }

    /// <summary>
    /// Return as LockList
    /// </summary>
    public static LockList<T> ToLockList<T>(this IEnumerable<T> enumerable) where T : Object
    {
        var lockList = new LockList<T>();
        var enumerator = enumerable.GetEnumeratorCollections();
        while (enumerator.MoveNext())
            lockList.Add(enumerator.Current.Cast<T>());

        return lockList;
    }
}