using System.Collections.Generic;
using Il2CppAssets.Scripts.Utils;
using Il2CppNinjaKiwi.Common;
using Il2CppSystem;
using Array = System.Array;
using Exception = System.Exception;
namespace BTD_Mod_Helper.Extensions;

/// <summary>
/// Extensions for LockLists
/// </summary>
public static partial class LockedListExt
{
    /// <summary>
    /// Return as System.List
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="lockList"></param>
    /// <returns></returns>
    public static List<T> ToList<T>(this LockList<T> lockList)
    {
        var newList = new List<T>();
        for (var i = 0; i < lockList.Count; i++)
            newList.Add(lockList.list.Get(i));

        return newList;
    }

    /// <summary>
    /// Return as Il2CppSystem.List
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="lockList"></param>
    /// <returns></returns>
    public static Il2CppSystem.Collections.Generic.List<T> ToIl2CppList<T>(this LockList<T> lockList)
    {
        var il2CppList = new Il2CppSystem.Collections.Generic.List<T>();
        for (var i = 0; i < lockList.Count; i++)
            il2CppList.Add(lockList.list.Get(i));

        return il2CppList;
    }

    /// <summary>
    /// Return as System.Array
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="lockList"></param>
    /// <returns></returns>
    public static T[] ToArray<T>(this LockList<T> lockList)
    {
        var newArray = new T[] { };
        for (var i = 0; i < lockList.Count; i++)
        {
            var item = lockList.list.Get(i);
            Array.Resize(ref newArray, newArray.Length + 1);
            newArray[newArray.Length - 1] = item;
        }

        return newArray;
    }

    /// <summary>
    /// Return as Il2CppReferenceArray
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="lockList"></param>
    /// <returns></returns>
    public static Il2CppReferenceArray<T> ToIl2CppReferenceArray<T>(this LockList<T> lockList) where T : Object
    {
        var il2cppArray = new Il2CppReferenceArray<T>(lockList.Count);

        for (var i = 0; i < lockList.Count; i++)
            il2cppArray[i] = lockList.list.Get(i);

        return il2cppArray;
    }

    /// <summary>
    /// Return a duplicate of this
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="list"></param>
    /// <returns></returns>
    public static LockList<T> Duplicate<T>(this LockList<T> list)
    {
        var newList = new LockList<T>();
        for (var i = 0; i < list.Count; i++)
            newList.Add(list.list.Get(i));

        return newList;
    }

    /// <summary>
    /// Return a duplicate of this as type TCast
    /// </summary>
    /// <typeparam name="TSource"></typeparam>
    /// <typeparam name="TCast"></typeparam>
    /// <param name="list"></param>
    /// <returns></returns>
    public static LockList<TCast> DuplicateAs<TSource, TCast>(this LockList<TSource> list)
        where TSource : Object where TCast : Object
    {
        var newList = new LockList<TCast>();
        for (var i = 0; i < list.Count; i++)
            newList.Add(list.list.Get(i).TryCast<TCast>());

        return newList;
    }


    /// <summary>
    /// Return this with an additional Item added to it
    /// </summary>
    /// <typeparam name="TSource"></typeparam>
    /// <typeparam name="TCast">The Type of the Item to add</typeparam>
    /// <param name="lockList"></param>
    /// <param name="objectToAdd">Item to add</param>
    /// <returns></returns>
    public static LockList<TSource> AddTo<TSource, TCast>(this LockList<TSource> lockList, TCast objectToAdd)
        where TSource : Object where TCast : Object
    {
        if (lockList is null)
            lockList = new LockList<TSource>();

        lockList.Add(objectToAdd.TryCast<TSource>());
        return lockList;
    }



    /// <summary>
    /// Check if this has any items of type TCast
    /// </summary>
    /// <typeparam name="TSource"></typeparam>
    /// <typeparam name="TCast">The Type you're checking for</typeparam>
    /// <param name="lockList"></param>
    /// <returns></returns>
    public static bool HasItemsOfType<TSource, TCast>(this LockList<TSource> lockList) where TSource : Object
        where TCast : Object
    {
        for (var i = 0; i < lockList.Count; i++)
        {
            var item = lockList.list.Get(i);
            try
            {
                if (item.IsType<TCast>())
                    return true;
            }
            catch (Exception)
            {
                // ignored
            }
        }

        return false;
    }

    /// <summary>
    /// Return all Items of type TCast
    /// </summary>
    /// <typeparam name="TSource"></typeparam>
    /// <typeparam name="TCast">The Type of the Items you want</typeparam>
    /// <param name="lockList"></param>
    /// <returns></returns>
    public static List<TCast> GetItemsOfType<TSource, TCast>(this LockList<TSource> lockList) where TSource : Object
        where TCast : Object
    {
        var result = new List<TCast>();
        lockList.ForEach(item =>
        {
            if (item.IsType(out TCast cast))
                result.Add(cast);
        });
        return result;

        // Switching to new Linq extension
        /*if (!HasItemsOfType<TSource, TCast>(lockList))
            return null;

        List<TCast> results = new List<TCast>();
        for (int i = 0; i < lockList.Count; i++)
        {
            TSource item = lockList.list.Get(i);
            try
            {
                if (item.IsType(out TCast tryCast))
                    results.Add(tryCast);
            }
            catch (Exception) { }
        }

        return results;*/
    }

    /// <summary>
    /// Return this with the first Item of type TCast removed
    /// </summary>
    /// <typeparam name="TSource"></typeparam>
    /// <typeparam name="TCast">The Type of the Item you want to remove</typeparam>
    /// <param name="lockList"></param>
    /// <returns></returns>
    public static LockList<TSource> RemoveItemOfType<TSource, TCast>(this LockList<TSource> lockList)
        where TSource : Object
        where TCast : Object
    {
        var behavior = lockList.First(o => o.IsType<TCast>()).Cast<TCast>();
        return RemoveItem(lockList, behavior);
    }

    /// <summary>
    /// Return this with the first Item of type TCast removed
    /// </summary>
    /// <typeparam name="TSource"></typeparam>
    /// <typeparam name="TCast">The Type of the Item you want to remove</typeparam>
    /// <param name="lockList"></param>
    /// <param name="itemToRemove">The specific Item to remove</param>
    /// <returns></returns>
    public static LockList<TSource> RemoveItem<TSource, TCast>(this LockList<TSource> lockList, TCast itemToRemove)
        where TSource : Object where TCast : Object
    {
        if (!HasItemsOfType<TSource, TCast>(lockList))
            return lockList;

        var arrayList = lockList.ToList();

        for (var i = 0; i < lockList.Count; i++)
        {
            var item = lockList.list.Get(i);
            if (item is null || !item.Equals(itemToRemove.TryCast<TCast>()))
                continue;

            arrayList.RemoveAt(i);
            break;
        }

        return arrayList.ToLockList();
    }

    /// <summary>
    /// Return this with all Items of type TCast removed
    /// </summary>
    /// <typeparam name="TSource"></typeparam>
    /// <typeparam name="TCast">The Type of the Items that you want to remove</typeparam>
    /// <param name="lockList"></param>
    /// <returns></returns>
    public static LockList<TSource> RemoveItemsOfType<TSource, TCast>(this LockList<TSource> lockList)
        where TSource : Object
        where TCast : Object
    {
        if (!HasItemsOfType<TSource, TCast>(lockList))
            return lockList;

        var numRemoved = 0;
        var arrayList = lockList.ToList();
        for (var i = 0; i < lockList.Count; i++)
        {
            var item = lockList.list.Get(i);
            if (item is null || !item.IsType<TCast>())
                continue;

            arrayList.RemoveAt(i - numRemoved);
            numRemoved++;
        }

        return arrayList.ToLockList();
    }
}