using System.IO;
using Il2CppAssets.Scripts.Utils;
using Il2CppSystem;
using Il2CppSystem.Collections.Generic;
using Newtonsoft.Json;
using Exception = System.Exception;
namespace BTD_Mod_Helper.Extensions;

public static partial class ListExt
{
    /// <summary>
    /// Return as Il2CppSystem.List
    /// </summary>
    public static List<T> ToIl2CppList<T>(this System.Collections.Generic.List<T> list)
    {
        var il2CppList = new List<T>();
        foreach (var item in list)
            il2CppList.Add(item);

        return il2CppList;
    }

    /// <summary>
    /// Return as Il2CppReferenceArray
    /// </summary>
    public static Il2CppReferenceArray<T> ToIl2CppReferenceArray<T>(this System.Collections.Generic.List<T> list) where T : Object
    {
        var il2cppArray = new Il2CppReferenceArray<T>(list.Count);

        for (var i = 0; i < list.Count; i++)
            il2cppArray[i] = list[i];

        return il2cppArray;
    }

    /// <summary>
    /// Return as LockList
    /// </summary>
    public static LockList<T> ToLockList<T>(this System.Collections.Generic.List<T> list)
    {
        var lockList = new LockList<T>();
        foreach (var item in list)
            lockList.Add(item);

        return lockList;
    }

    /// <summary>
    /// Return a duplicate of this
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="list"></param>
    /// <returns></returns>
    public static System.Collections.Generic.List<T> Duplicate<T>(this System.Collections.Generic.List<T> list)
    {
        var newList = new System.Collections.Generic.List<T>();
        foreach (var item in list)
            newList.Add(item);

        return newList;
    }

    /// <summary>
    /// Return a duplicate of this as type TCast
    /// </summary>
    /// <typeparam name="TSource"></typeparam>
    /// <typeparam name="TCast"></typeparam>
    /// <param name="list"></param>
    /// <returns></returns>
    public static System.Collections.Generic.List<TCast> DuplicateAs<TSource, TCast>(this System.Collections.Generic.List<TSource> list)
        where TSource : Object where TCast : Object
    {
        var newList = new System.Collections.Generic.List<TCast>();
        foreach (var item in list)
            newList.Add(item.TryCast<TCast>());

        return newList;
    }

    /// <summary>
    /// Save a list to file
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="list">The list you want to save</param>
    /// <param name="filePath">The FilePath you want to save it to</param>
    /// <returns>True if successful, false if it fails</returns>
    public static bool SaveToFile<T>(this System.Collections.Generic.List<T> list, string filePath)
    {
        try
        {
            var json = JsonConvert.SerializeObject(list);
            File.WriteAllText(filePath, json);
            return true;
        }
        catch (Exception)
        {
            return false;
        }
    }

    /// <summary>
    /// Load a List from a FilePath
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="list"></param>
    /// <param name="filePath">FilePath of the saved List</param>
    /// <returns>The loaded List if successful, otherwise default value</returns>
    public static T LoadFromFile<T>(this System.Collections.Generic.List<T> list, string filePath)
    {
        return list.LoadFromFile(filePath, out _);
    }

    /// <summary>
    /// Load a List from a FilePath
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="list"></param>
    /// <param name="filePath">FilePath of the saved List</param>
    /// <param name="success">Will be true if the List was successfully loaded, otherwise will be false</param>
    /// <returns>The loaded List if successful, otherwise default value</returns>
    public static T LoadFromFile<T>(this System.Collections.Generic.List<T> list, string filePath, out bool success)
    {
        success = false;
        var json = File.ReadAllText(filePath);
        if (string.IsNullOrEmpty(json)) return default;

        try
        {
            var loadedObject = (T) JsonConvert.DeserializeObject(json);
            success = true;
            return loadedObject;
        }
        catch (Exception)
        {
            return default;
        }
    }


    /// <summary>
    /// Check if this has any items of type TCast
    /// </summary>
    /// <typeparam name="TSource"></typeparam>
    /// <typeparam name="TCast">The Type you're checking for</typeparam>
    /// <param name="list"></param>
    /// <returns></returns>
    public static bool HasItemsOfType<TSource, TCast>(this System.Collections.Generic.List<TSource> list) where TSource : Object
        where TCast : Object
    {
        foreach (var item in list)
        {
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
    /// Return the first item of type TCast
    /// </summary>
    /// <typeparam name="TSource"></typeparam>
    /// <typeparam name="TCast">The Type of the Item you want</typeparam>
    /// <param name="list"></param>
    /// <returns></returns>
    public static TCast GetItemOfType<TSource, TCast>(this System.Collections.Generic.List<TSource> list) where TCast : Object
        where TSource : Object
    {
        if (!HasItemsOfType<TSource, TCast>(list))
            return null;

        foreach (var item in list)
        {
            try
            {
                if (item.IsType(out TCast tryCast))
                    return tryCast;
            }
            catch (Exception)
            {
                // ignored
            }
        }

        return null;
    }

    /// <summary>
    /// Return all Items of type TCast
    /// </summary>
    /// <typeparam name="TSource"></typeparam>
    /// <typeparam name="TCast">The Type of the Items you want</typeparam>
    /// <param name="list"></param>
    /// <returns></returns>
    public static System.Collections.Generic.List<TCast> GetItemsOfType<TSource, TCast>(this System.Collections.Generic.List<TSource> list)
        where TSource : Object
        where TCast : Object
    {
        var results = new System.Collections.Generic.List<TCast>();
        foreach (var item in list)
        {
            try
            {
                if (item.IsType(out TCast tryCast))
                    results.Add(tryCast);
            }
            catch (Exception)
            {
                // ignored
            }
        }

        return results;
    }

    /// <summary>
    /// Return this with the first Item of type TCast removed
    /// </summary>
    /// <typeparam name="TSource"></typeparam>
    /// <typeparam name="TCast">The Type of the Item you want to remove</typeparam>
    /// <param name="list"></param>
    /// <returns></returns>
    public static System.Collections.Generic.List<TSource> RemoveItemOfType<TSource, TCast>(this System.Collections.Generic.List<TSource> list)
        where TSource : Object
        where TCast : Object
    {
        var item = GetItemOfType<TSource, TCast>(list);
        return item != null ? RemoveItem(list, item) : list;
    }

    /// <summary>
    /// Return this with the first Item of type TCast removed
    /// </summary>
    /// <typeparam name="TSource"></typeparam>
    /// <typeparam name="TCast">The Type of the Item you want to remove</typeparam>
    /// <param name="list"></param>
    /// <param name="itemToRemove">The specific Item to remove</param>
    /// <returns></returns>
    public static System.Collections.Generic.List<TSource> RemoveItem<TSource, TCast>(this System.Collections.Generic.List<TSource> list, TCast itemToRemove)
        where TSource : Object where TCast : Object
    {
        if (!HasItemsOfType<TSource, TCast>(list))
            return list;

        var newList = list;
        for (var i = 0; i < list.Count; i++)
        {
            var item = list[i];
            if (item is null || !item.Equals(itemToRemove.TryCast<TCast>()))
                continue;

            newList.RemoveAt(i);
            break;
        }

        return newList;
    }

    /// <summary>
    /// Return this with all Items of type TCast removed
    /// </summary>
    /// <typeparam name="TSource"></typeparam>
    /// <typeparam name="TCast">The Type of the Items that you want to remove</typeparam>
    /// <param name="list"></param>
    /// <returns></returns>
    public static System.Collections.Generic.List<TSource> RemoveItemsOfType<TSource, TCast>(this System.Collections.Generic.List<TSource> list)
        where TSource : Object
        where TCast : Object
    {
        if (!HasItemsOfType<TSource, TCast>(list))
            return list;

        var newList = list;
        var numRemoved = 0;
        for (var i = 0; i < list.Count; i++)
        {
            var item = list[i];
            if (item is null || !item.IsType<TCast>())
                continue;

            newList.RemoveAt(i - numRemoved);
            numRemoved++;
        }

        return newList;
    }
}