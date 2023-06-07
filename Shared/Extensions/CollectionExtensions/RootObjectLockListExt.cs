using System.Collections.Generic;
using Il2CppAssets.Scripts.Simulation.Objects;
using Il2CppAssets.Scripts.Utils;
using Il2CppSystem;
using Array = System.Array;
using Exception = System.Exception;
namespace BTD_Mod_Helper.Extensions;

/// <summary>
/// Extensions for RootObjectLockLists
/// </summary>
public static partial class RootObjectLockList
{
    /// <summary>
    /// Return as System.List
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="lockList"></param>
    /// <returns></returns>
    public static List<T> ToList<T>(this RootObjectLockList<T> lockList) where T : RootObject
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
    public static Il2CppSystem.Collections.Generic.List<T> ToIl2CppList<T>(this RootObjectLockList<T> lockList) where T : RootObject
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
    public static T[] ToArray<T>(this RootObjectLockList<T> lockList) where T : RootObject
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
    public static Il2CppReferenceArray<T> ToIl2CppReferenceArray<T>(this RootObjectLockList<T> lockList) where T : RootObject
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
    public static RootObjectLockList<T> Duplicate<T>(this RootObjectLockList<T> list) where T : RootObject
    {
        var newList = new RootObjectLockList<T>();
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
    public static RootObjectLockList<TCast> DuplicateAs<TSource, TCast>(this RootObjectLockList<TSource> list)
        where TSource : RootObject where TCast : RootObject
    {
        var newList = new RootObjectLockList<TCast>();
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
    public static RootObjectLockList<TSource> AddTo<TSource, TCast>(this RootObjectLockList<TSource> lockList, TCast objectToAdd)
        where TSource : RootObject where TCast : RootObject
    {
        if (lockList is null)
            lockList = new RootObjectLockList<TSource>();

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
    public static bool HasItemsOfType<TSource, TCast>(this RootObjectLockList<TSource> lockList) where TSource : RootObject
        where TCast : RootObject
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
    public static List<TCast> GetItemsOfType<TSource, TCast>(this RootObjectLockList<TSource> lockList) where TSource : RootObject
        where TCast : RootObject
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
    public static RootObjectLockList<TSource> RemoveItemOfType<TSource, TCast>(this RootObjectLockList<TSource> lockList)
        where TSource : RootObject
        where TCast : RootObject
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
    public static RootObjectLockList<TSource> RemoveItem<TSource, TCast>(this RootObjectLockList<TSource> lockList, TCast itemToRemove)
        where TSource : RootObject where TCast : RootObject
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

        return arrayList.ToRootObjectLockList();
    }

    /// <summary>
    /// Return this with all Items of type TCast removed
    /// </summary>
    /// <typeparam name="TSource"></typeparam>
    /// <typeparam name="TCast">The Type of the Items that you want to remove</typeparam>
    /// <param name="lockList"></param>
    /// <returns></returns>
    public static RootObjectLockList<TSource> RemoveItemsOfType<TSource, TCast>(this RootObjectLockList<TSource> lockList)
        where TSource : RootObject
        where TCast : RootObject
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

        return arrayList.ToRootObjectLockList();
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="lockList"></param>
    /// <typeparam name="TSource"></typeparam>
    /// <typeparam name="TCast"></typeparam>
    /// <returns></returns>
    public static TCast GetItemOfType<TSource, TCast>(this RootObjectLockList<TSource> lockList)
        where TSource : RootObject
        where TCast : RootObject
    {
        foreach (var rootObject in lockList.list)
        {
            if (rootObject.Is(out TCast cast))
            {
                return cast;
            }
        }

        return null;
    }
}