using System.Collections.Generic;
using Il2CppNinjaKiwi.Common;
using Il2CppSystem;
using Il2CppSystem.Linq;

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
    public static List<T> ToList<T>(this Il2CppSystem.Collections.Generic.List<T> il2CppList) => [..il2CppList];

    /// <summary>
    /// Return as an Array
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="il2CppList"></param>
    /// <returns></returns>
    public static T[] ToArray<T>(this Il2CppSystem.Collections.Generic.List<T> il2CppList) => [..il2CppList];

    /// <summary>
    /// Return as Il2CppReferenceArray
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="il2CppList"></param>
    /// <returns></returns>
    public static Il2CppReferenceArray<T> ToIl2CppReferenceArray<T>(this Il2CppSystem.Collections.Generic.List<T> il2CppList)
        where T : Object => new(ToArray(il2CppList));

    /// <summary>
    /// Return as LockList
    /// </summary>
    public static LockList<T> ToLockList<T>(this Il2CppSystem.Collections.Generic.List<T> il2CppList)
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
    public static Il2CppSystem.Collections.Generic.List<T> Duplicate<T>(this Il2CppSystem.Collections.Generic.List<T> list)
        => new(list.Cast<Il2CppSystem.Collections.Generic.IEnumerable<T>>());

    /// <summary>
    /// Return a duplicate of this list as type TCast
    /// </summary>
    /// <typeparam name="TSource"></typeparam>
    /// <typeparam name="TCast"></typeparam>
    /// <param name="list"></param>
    /// <returns></returns>
    public static Il2CppSystem.Collections.Generic.List<TCast> DuplicateAs<TSource, TCast>(
        this Il2CppSystem.Collections.Generic.List<TSource> list)
        where TSource : Object where TCast : Object
    {
        var newList = new Il2CppSystem.Collections.Generic.List<TCast>();
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
    public static bool HasItemsOfType<TSource, TCast>(this Il2CppSystem.Collections.Generic.List<TSource> list)
        where TSource : Object where TCast : Object
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
    public static TCast GetItemOfType<TSource, TCast>(this Il2CppSystem.Collections.Generic.List<TSource> list)
        where TCast : Object where TSource : Object
    {
        return list.FirstOrDefault(o => o.IsType<TCast>())?.Cast<TCast>();
    }

    /// <summary>
    /// Return all Items of type TCast
    /// </summary>
    /// <typeparam name="TSource"></typeparam>
    /// <typeparam name="TCast">The Type of the Items you want</typeparam>
    /// <param name="list"></param>
    /// <returns></returns>
    public static Il2CppSystem.Collections.Generic.List<TCast> GetItemsOfType<TSource, TCast>(
        this Il2CppSystem.Collections.Generic.List<TSource> list) where TSource : Object
        where TCast : Object
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
    public static Il2CppSystem.Collections.Generic.List<TSource> RemoveItemOfType<TSource, TCast>(
        this Il2CppSystem.Collections.Generic.List<TSource> list)
        where TSource : Object where TCast : Object
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
    public static Il2CppSystem.Collections.Generic.List<TSource> RemoveItem<TSource, TCast>(
        this Il2CppSystem.Collections.Generic.List<TSource> list, TCast itemToRemove)
        where TSource : Object where TCast : Object
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
    public static Il2CppSystem.Collections.Generic.List<TSource> RemoveItemsOfType<TSource, TCast>(
        this Il2CppSystem.Collections.Generic.List<TSource> list)
        where TSource : Object
        where TCast : Object
    {
        list.RemoveAll(new System.Func<TSource, bool>(item => item.IsType<TCast>()));
        return list;
    }

    /// <summary>
    /// Gets the item at the specified index. Circumvents "ambiguous indexer" warnings
    /// </summary>
    /// <param name="list"></param>
    /// <param name="index"></param>
    /// <typeparam name="T"></typeparam>
    /// <returns></returns>
    public static T Get<T>(this Il2CppSystem.Collections.Generic.List<T> list, int index) => list._items[index];
}