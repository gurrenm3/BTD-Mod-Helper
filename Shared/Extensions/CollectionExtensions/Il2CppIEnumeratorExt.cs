﻿using Assets.Scripts.Utils;
using Il2CppSystem.Collections;
using System.Collections.Generic;
using UnhollowerBaseLib;


namespace BTD_Mod_Helper.Extensions;

/// <summary>
/// Extensions for Il2cpp Ienumerators
/// </summary>
public static class Il2CppIEnumeratorExt
{
    /// <summary>
    /// (Cross-Game compatible) Get the total number of elements
    /// </summary>
    /// <param name="enumerator"></param>
    /// <returns></returns>
    public static int Count(this IEnumerator enumerator)
    {
        var length = 0;

        while (enumerator.MoveNext())
            length++;

        return length;
    }

    /// <summary>
    /// (Cross-Game compatible) Return the Item at a specific index
    /// </summary>
    /// <param name="enumerator"></param>
    /// <param name="index"></param>
    /// <returns></returns>
    public static Il2CppSystem.Object? GetItem(this IEnumerator enumerator, int index)
    {
        var i = 0;
        while (enumerator.MoveNext())
        {
            if (i == index)
                return enumerator.Current;
            i++;
        }

        return null;
    }

    /// <summary>
    /// (Cross-Game compatible) Return as System.List
    /// </summary>
    /// <param name="enumerator"></param>
    /// <returns></returns>
    public static List<Il2CppSystem.Object> ToList(this IEnumerator enumerator)
    {
        var newList = new List<Il2CppSystem.Object>();
        while (enumerator.MoveNext())
            newList.Add(enumerator.Current);

        return newList;
    }

    /// <summary>
    /// (Cross-Game compatible) Return as Il2CppSystem.List
    /// </summary>
    public static Il2CppSystem.Collections.Generic.List<Il2CppSystem.Object> ToIl2CppList(this IEnumerator enumerator)
    {
        var il2CppList = 
            new Il2CppSystem.Collections.Generic.List<Il2CppSystem.Object>();

        while (enumerator.MoveNext())
            il2CppList.Add(enumerator.Current);

        return il2CppList;
    }

    /// <summary>
    /// (Cross-Game compatible) Return as Il2CppReferenceArray
    /// </summary>
    public static Il2CppReferenceArray<Il2CppSystem.Object> ToIl2CppReferenceArray(this IEnumerator enumerator)
    {
        var il2cppArray = 
            new Il2CppReferenceArray<Il2CppSystem.Object>(enumerator.Count());

        var i = 0;
        while (enumerator.MoveNext())
        {
            il2cppArray[i] = enumerator.Current;
            i++;
        }


        return il2cppArray;
    }

    /// <summary>
    /// (Cross-Game compatible) Return as LockList
    /// </summary>
    public static LockList<Il2CppSystem.Object> ToLockList(this IEnumerator enumerator)
    {
        var lockList = new LockList<Il2CppSystem.Object>();
        while (enumerator.MoveNext())
            lockList.Add(enumerator.Current);

        return lockList;
    }
}