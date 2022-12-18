using Il2CppAssets.Scripts.Utils;
using Il2CppSystem.Collections.Generic;
using System;

namespace BTD_Mod_Helper.Extensions;

/// <summary>
/// Extensions for generic il2cpp lists
/// </summary>
public static partial class Il2CppGenericsExt
{
    /// <summary>
    /// Return as System.List
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="il2CppList"></param>
    /// <returns></returns>
    public static System.Collections.Generic.List<T> ToList<T>(this List<T> il2CppList)
    {
        var newList = new System.Collections.Generic.List<T>();
        foreach (var item in il2CppList)
            newList.Add(item);

        return newList;
    }

    /// <summary>
    /// Return as an Array
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="il2CppList"></param>
    /// <returns></returns>
    public static T[] ToArray<T>(this List<T> il2CppList)
    {
        var newArray = new T[] { };

        foreach (var item in il2CppList)
        {
            Array.Resize(ref newArray, newArray.Length + 1);
            newArray[newArray.Length - 1] = item;
        }

        return newArray;
    }

    /// <summary>
    /// Return as Il2CppReferenceArray
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="il2CppList"></param>
    /// <returns></returns>
    public static Il2CppReferenceArray<T> ToIl2CppReferenceArray<T>(this List<T> il2CppList) where T : Il2CppSystem.Object
    {
        return new Il2CppReferenceArray<T>(il2CppList.ToArray());
    }

    /// <summary>
    /// Return as LockList
    /// </summary>
    public static LockList<T> ToLockList<T>(this List<T> il2CppList)
    {
        var lockList = new LockList<T>();
        foreach (var item in il2CppList)
            lockList.Add(item);

        return lockList;
    }

    /// <summary>
    /// Return a duplicate of this List
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="list"></param>
    /// <returns></returns>
    public static List<T> Duplicate<T>(this List<T> list)
    {
        var newList = new List<T>();
        foreach (var item in list)
            newList.Add(item);

        return newList;
    }

    /// <summary>
    /// Return a duplicate of this list as type TCast
    /// </summary>
    /// <typeparam name="TSource"></typeparam>
    /// <typeparam name="TCast"></typeparam>
    /// <param name="list"></param>
    /// <returns></returns>
    public static List<TCast> DuplicateAs<TSource, TCast>(this List<TSource> list)
        where TSource : Il2CppSystem.Object where TCast : Il2CppSystem.Object
    {
        var newList = new List<TCast>();
        foreach (var item in list)
            newList.Add(item.TryCast<TCast>());

        return newList;
    }


    /// <summary>
    /// Check if this has any items of type TCast
    /// </summary>
    /// <typeparam name="TSource"></typeparam>
    /// <typeparam name="TCast">The Type you're checking for</typeparam>
    /// <param name="list"></param>
    /// <returns></returns>
    public static bool HasItemsOfType<TSource, TCast>(this List<TSource> list) where TSource : Il2CppSystem.Object
        where TCast : Il2CppSystem.Object
    {
        return list.Any(o => o.IsType<TCast>());
    }

    /// <summary>
    /// Return the first item of type TCast
    /// </summary>
    /// <typeparam name="TSource"></typeparam>
    /// <typeparam name="TCast">The Type of the Item you want</typeparam>
    /// <param name="list"></param>
    /// <returns></returns>
    public static TCast GetItemOfType<TSource, TCast>(this List<TSource> list) where TCast : Il2CppSystem.Object
        where TSource : Il2CppSystem.Object
    {
        return list.First(o => o.IsType<TCast>()).Cast<TCast>();
    }

    /// <summary>
    /// Return all Items of type TCast
    /// </summary>
    /// <typeparam name="TSource"></typeparam>
    /// <typeparam name="TCast">The Type of the Items you want</typeparam>
    /// <param name="list"></param>
    /// <returns></returns>
    public static List<TCast> GetItemsOfType<TSource, TCast>(this List<TSource> list) where TSource : Il2CppSystem.Object
        where TCast : Il2CppSystem.Object
    {
        return list.DuplicateAs<TSource, TCast>().Where(o => o != null);
    }

    /// <summary>
    /// Return this with the first Item of type TCast removed
    /// </summary>
    /// <typeparam name="TSource"></typeparam>
    /// <typeparam name="TCast">The Type of the Item you want to remove</typeparam>
    /// <param name="list"></param>
    /// <returns></returns>
    public static List<TSource> RemoveItemOfType<TSource, TCast>(this List<TSource> list)
        where TSource : Il2CppSystem.Object
        where TCast : Il2CppSystem.Object
    {
        var item = GetItemOfType<TSource, TCast>(list);
        return RemoveItem(list, item);
    }

    /// <summary>
    /// Return this with the first Item of type TCast removed
    /// </summary>
    /// <typeparam name="TSource"></typeparam>
    /// <typeparam name="TCast">The Type of the Item you want to remove</typeparam>
    /// <param name="list"></param>
    /// <param name="itemToRemove">The specific Item to remove</param>
    /// <returns></returns>
    public static List<TSource> RemoveItem<TSource, TCast>(this List<TSource> list, TCast itemToRemove)
        where TSource : Il2CppSystem.Object where TCast : Il2CppSystem.Object
    {
        var itemOfType = itemToRemove ?? list.GetItemOfType<TSource, TCast>();
        if (itemOfType != null)
        {
            list.Remove(itemOfType.Cast<TSource>());
        }
        return list;
    }

    /// <summary>
    /// Return this with all Items of type TCast removed
    /// </summary>
    /// <typeparam name="TSource"></typeparam>
    /// <typeparam name="TCast">The Type of the Items that you want to remove</typeparam>
    /// <param name="list"></param>
    /// <returns></returns>
    public static List<TSource> RemoveItemsOfType<TSource, TCast>(this List<TSource> list)
        where TSource : Il2CppSystem.Object
        where TCast : Il2CppSystem.Object
    {
        list.RemoveAll(new Func<TSource, bool>(item => item.IsType<TCast>()));
        return list;
    }
}