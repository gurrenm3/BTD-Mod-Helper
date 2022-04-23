using Assets.Scripts.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using Assets.Scripts.Models;
using UnhollowerBaseLib;

namespace BTD_Mod_Helper.Extensions;

public static partial class Il2CppReferenceArrayExt
{
    /// <summary>
    /// Returns an empty <see cref="Il2CppReferenceArray{T}"/>
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="referenceArray"></param>
    /// <returns></returns>
    public static Il2CppReferenceArray<T> Empty<T>(this Il2CppReferenceArray<T> referenceArray)
        where T : Il2CppSystem.Object
    {
        return new Il2CppReferenceArray<T>(0);
    }

    /// <summary>
    /// Sets all elements in the <see cref="Il2CppReferenceArray{T}"/> to the default value of each element type.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="referenceArray"></param>
    public static void Clear<T>(this Il2CppReferenceArray<T> referenceArray) where T : Il2CppSystem.Object
    {
        for (var i = 0; i < referenceArray.Length; i++)
        {
            referenceArray[i] = default!;
        }
    }

    /// <summary>
    /// (Cross-Game compatible) Return as System.List
    /// </summary>
    public static List<T> ToList<T>(this Il2CppReferenceArray<T> referenceArray) where T : Il2CppSystem.Object
    {
        return new List<T>(referenceArray);
    }

    /// <summary>
    /// (Cross-Game compatible) Return as Il2CppSystem.List
    /// </summary>
    public static Il2CppSystem.Collections.Generic.List<T> ToIl2CppList<T>(
        this Il2CppReferenceArray<T> referenceArray)
        where T : Il2CppSystem.Object
    {
        var il2CppList = new Il2CppSystem.Collections.Generic.List<T>();
        foreach (var item in referenceArray)
            il2CppList.Add(item);

        return il2CppList;
    }

    /// <summary>
    /// (Cross-Game compatible) Return as a System.Array
    /// </summary>
    public static T[] ToArray<T>(this Il2CppReferenceArray<T> referenceArray) where T : Il2CppSystem.Object
    {
        return referenceArray;
    }

    /// <summary>
    /// (Cross-Game compatible) Return as LockList
    /// </summary>
    public static LockList<T> ToLockList<T>(this Il2CppReferenceArray<T> referenceArray)
        where T : Il2CppSystem.Object
    {
        var lockList = new LockList<T>();
        foreach (var item in referenceArray)
            lockList.Add(item);

        return lockList;
    }

    /// <summary>
    /// (Cross-Game compatible) Return a duplicate of this
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="list"></param>
    /// <returns></returns>
    public static Il2CppReferenceArray<T> Duplicate<T>(this Il2CppReferenceArray<T> list)
        where T : Il2CppSystem.Object
    {
        var newList = new List<T>();
        foreach (var item in list)
            newList.Add(item);

        return newList.ToIl2CppReferenceArray();
    }

    /// <summary>
    /// (Cross-Game compatible) Return a duplicate of this as type TCast
    /// </summary>
    /// <typeparam name="TSource"></typeparam>
    /// <typeparam name="TCast"></typeparam>
    /// <param name="list"></param>
    /// <returns></returns>
    public static Il2CppReferenceArray<TCast> DuplicateAs<TSource, TCast>(this Il2CppReferenceArray<TSource> list)
        where TSource : Il2CppSystem.Object where TCast : Il2CppSystem.Object
    {
        return list.CastAll<TSource, TCast>()!.ToIl2CppReferenceArray();
    }

    /// <summary>
    /// (Cross-Game compatible) Return this with an additional Item added to it
    /// </summary>
    /// <typeparam name="T">The Type of the Item to add</typeparam>
    /// <param name="referenceArray"></param>
    /// <param name="objectToAdd">Item to add</param>
    /// <returns></returns>
    public static Il2CppReferenceArray<T> AddTo<T>(this Il2CppReferenceArray<T> referenceArray, T objectToAdd)
        where T : Il2CppSystem.Object
    {
        var newRef = new Il2CppReferenceArray<T>(referenceArray.Count + 1);
        for (var i = 0; i < referenceArray.Count; i++)
            newRef[i] = referenceArray[i];

        newRef[^1] = objectToAdd;

        return newRef;
    }

    /// <summary>
    /// (Cross-Game compatible) Return this with additional Items added to it
    /// </summary>
    /// <typeparam name="T">The Type of the Items to add</typeparam>
    /// <param name="referenceArray"></param>
    /// <param name="objectsToAdd">Items to add</param>
    /// <returns></returns>
    public static Il2CppReferenceArray<T> AddTo<T>(this Il2CppReferenceArray<T> referenceArray,
        Il2CppReferenceArray<T> objectsToAdd) where T : Il2CppSystem.Object
    {
        var size = referenceArray.Count + objectsToAdd.Count;
        var newReference = new Il2CppReferenceArray<T>(size);

        var tempList = new List<T>(referenceArray);
        tempList.AddRange(objectsToAdd);

        for (var i = 0; i < tempList.Count; i++)
        {
            var item = tempList[i];
            newReference[i] = item;
        }

        return newReference;
    }

    /// <summary>
    /// (Cross-Game compatible) Return this with additional Items added to it
    /// </summary>
    /// <typeparam name="T">The Type of the Items to add</typeparam>
    /// <param name="referenceArray"></param>
    /// <param name="objectsToAdd">Items to add</param>
    /// <returns></returns>
    public static Il2CppReferenceArray<T> AddTo<T>(this Il2CppReferenceArray<T> referenceArray,
        List<T> objectsToAdd) where T : Il2CppSystem.Object
    {
        return referenceArray.AddTo(objectsToAdd.ToIl2CppReferenceArray());
    }


    /// <summary>
    /// (Cross-Game compatible) Check if this has any items of type TCast
    /// </summary>
    /// <typeparam name="TSource"></typeparam>
    /// <typeparam name="TCast">The Type you're checking for</typeparam>
    /// <param name="referenceArray"></param>
    /// <returns></returns>
    public static bool HasItemsOfType<TSource, TCast>(this Il2CppReferenceArray<TSource> referenceArray)
        where TSource : Il2CppSystem.Object
        where TCast : Il2CppSystem.Object
    {
        try
        {
            var result = referenceArray.First(item => item.IsType<TCast>());
        }
        catch (Exception)
        {
            return false;
        }

        return true;
    }

    /// <summary>
    /// (Cross-Game compatible) Return the first item of type TCast
    /// </summary>
    /// <typeparam name="TSource"></typeparam>
    /// <typeparam name="TCast">The Type of the Item you want</typeparam>
    /// <param name="referenceArray"></param>
    /// <returns></returns>
    public static TCast? GetItemOfType<TSource, TCast>(this Il2CppReferenceArray<TSource> referenceArray)
        where TCast : Il2CppSystem.Object
        where TSource : Il2CppSystem.Object
    {
        if (!HasItemsOfType<TSource, TCast>(referenceArray))
            return null;

        var result = referenceArray.FirstOrDefault(item => item.TryCast<TCast>() != null);
        return result?.TryCast<TCast>();
    }

    /// <summary>
    /// (Cross-Game compatible) Return all Items of type TCast
    /// </summary>
    /// <typeparam name="TSource"></typeparam>
    /// <typeparam name="TCast">The Type of the Items you want</typeparam>
    /// <param name="referenceArray"></param>
    /// <returns></returns>
    public static List<TCast> GetItemsOfType<TSource, TCast>(this Il2CppReferenceArray<TSource> referenceArray)
        where TSource : Il2CppSystem.Object
        where TCast : Il2CppSystem.Object
    {
        var results = new List<TCast>();
        if (!HasItemsOfType<TSource, TCast>(referenceArray))
            return results;

        foreach (var item in referenceArray)
        {
            if (item.IsType(out TCast tryCast))
                results.Add(tryCast);
        }

        return results;
    }

    /// <summary>
    /// (Cross-Game compatible) Return this with the first Item of type TCast removed
    /// </summary>
    /// <typeparam name="TSource"></typeparam>
    /// <typeparam name="TCast">The Type of the Item you want to remove</typeparam>
    /// <param name="referenceArray"></param>
    /// <returns></returns>
    public static Il2CppReferenceArray<TSource> RemoveItemOfType<TSource, TCast>(
        this Il2CppReferenceArray<TSource> referenceArray)
        where TSource : Il2CppSystem.Object
        where TCast : Il2CppSystem.Object
    {
        var behavior = GetItemOfType<TSource, TCast>(referenceArray);
        return behavior != null ? RemoveItem(referenceArray, behavior) : referenceArray;
    }

    /// <summary>
    /// (Cross-Game compatible) Return this with the first Item of type TCast removed
    /// </summary>
    /// <typeparam name="TSource"></typeparam>
    /// <typeparam name="TCast">The Type of the Item you want to remove</typeparam>
    /// <param name="referenceArray"></param>
    /// <param name="removeChildFrom">Model to remove the child dependents from</param>
    /// <returns></returns>
    public static Il2CppReferenceArray<TSource> RemoveItemOfType<TSource, TCast>(
        this Il2CppReferenceArray<TSource> referenceArray, Model removeChildFrom)
        where TSource : Il2CppSystem.Object
        where TCast : Model
    {
        var behavior = GetItemOfType<TSource, TCast>(referenceArray);
        if (behavior != null)
        {
            removeChildFrom.RemoveChildDependant(behavior);
            return RemoveItem(referenceArray, behavior);
        }

        return referenceArray;
    }

    /// <summary>
    /// (Cross-Game compatible) Return this with the first Item of type TCast removed
    /// </summary>
    /// <typeparam name="TSource"></typeparam>
    /// <typeparam name="TCast">The Type of the Item you want to remove</typeparam>
    /// <param name="referenceArray"></param>
    /// <param name="itemToRemove">The specific Item to remove</param>
    /// <returns></returns>
    public static Il2CppReferenceArray<TSource> RemoveItem<TSource, TCast>(
        this Il2CppReferenceArray<TSource> referenceArray, TCast itemToRemove)
        where TSource : Il2CppSystem.Object where TCast : Il2CppSystem.Object
    {
        if (!HasItemsOfType<TSource, TCast>(referenceArray))
            return referenceArray;

        var arrayList = referenceArray.ToList();

        for (var i = 0; i < referenceArray.Count; i++)
        {
            var item = referenceArray[i];
            if (item is null || !item.Equals(itemToRemove.TryCast<TCast>()))
                continue;

            arrayList.RemoveAt(i);
            break;
        }

        return arrayList.ToIl2CppReferenceArray();
    }

    /// <summary>
    /// (Cross-Game compatible) Return this with all Items of type TCast removed
    /// </summary>
    /// <typeparam name="TSource"></typeparam>
    /// <typeparam name="TCast">The Type of the Items that you want to remove</typeparam>
    /// <param name="referenceArray"></param>
    /// <returns></returns>
    public static Il2CppReferenceArray<TSource> RemoveItemsOfType<TSource, TCast>(
        this Il2CppReferenceArray<TSource> referenceArray)
        where TSource : Il2CppSystem.Object
        where TCast : Il2CppSystem.Object
    {
        if (!HasItemsOfType<TSource, TCast>(referenceArray))
            return referenceArray;

        var numRemoved = 0;
        var arrayList = referenceArray.ToList();
        for (var i = 0; i < referenceArray.Count; i++)
        {
            var item = referenceArray[i];
            if (item is null || !item.IsType<TCast>())
                continue;

            arrayList.RemoveAt(i - numRemoved);
            numRemoved++;
        }

        return arrayList.ToIl2CppReferenceArray();
    }

    /// <summary>
    /// (Cross-Game compatible) Return this with all Items of type TCast removed
    /// </summary>
    /// <typeparam name="TSource"></typeparam>
    /// <typeparam name="TCast">The Type of the Items that you want to remove</typeparam>
    /// <param name="referenceArray"></param>
    /// <param name="removeChildFrom">Model to remove the child dependents from</param>
    /// <returns></returns>
    public static Il2CppReferenceArray<TSource> RemoveItemsOfType<TSource, TCast>(
        this Il2CppReferenceArray<TSource> referenceArray, Model removeChildFrom)
        where TSource : Il2CppSystem.Object
        where TCast : Model
    {
        if (!HasItemsOfType<TSource, TCast>(referenceArray))
            return referenceArray;

        var numRemoved = 0;
        var arrayList = referenceArray.ToList();
        for (var i = 0; i < referenceArray.Count; i++)
        {
            var item = referenceArray[i];
            if (item is null || !item.IsType<TCast>(out var model))
                continue;

            arrayList.RemoveAt(i - numRemoved);
            numRemoved++;
            removeChildFrom.RemoveChildDependant(model);
        }

        return arrayList.ToIl2CppReferenceArray();
    }
}