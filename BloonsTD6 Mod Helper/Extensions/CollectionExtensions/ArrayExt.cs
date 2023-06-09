using System;
using System.Linq;
using Il2CppAssets.Scripts.Utils;
using Il2CppInterop.Runtime;
using Il2CppSystem.Collections.Generic;
using Object = Il2CppSystem.Object;
namespace BTD_Mod_Helper.Extensions;

/// <summary>
/// Extensions for arrays
/// </summary>
public static class ArrayExt
{
    /// <summary>
    /// Version of TryCast without the generic restriction
    /// </summary>
    private static bool TryCast<T>(Il2CppObjectBase obj, out T t)
    {
        t = default;
        var nativeClassPtr = Il2CppClassPointerStore<T>.NativeClassPtr;
        if (nativeClassPtr == IntPtr.Zero)
        {
            ModHelper.Warning($"{typeof(T)} is not an Il2Cpp reference type");
            return false;
        }

        var num = IL2CPP.il2cpp_object_get_class(obj.Pointer);
        if (!IL2CPP.il2cpp_class_is_assignable_from(nativeClassPtr, num))
        {
            ModHelper.Warning($"{obj.GetType()} is not a {typeof(T)}");
            return false;
        }

        if (RuntimeSpecificsStore.IsInjected(num))
        {
            t = (T) ClassInjectorBase.GetMonoObjectFromIl2CppPointer(obj.Pointer);
            return true;
        }

        var type = Il2CppClassPointerStore<T>.CreatedTypeRedirect;
        if ((object) type == null)
        {
            type = typeof(T);
        }

        t = (T) Activator.CreateInstance(type, obj.Pointer);
        return true;
    }

    private static bool CheckType<T>(object obj, out T t)
    {
        switch (obj)
        {
            case Il2CppObjectBase il2CppObject:
                return TryCast(il2CppObject, out t);
            case T o:
                t = o;
                return true;
        }

        ModHelper.Warning($"{obj.GetType()} is not a {typeof(T)}");
        t = default;
        return false;
    }

    /// <summary>
    /// Checks if the parameter array has the given types
    /// </summary>
    public static bool CheckTypes<T1>(this object[] parameters, out T1 param1)
    {
        param1 = default;
        if (parameters.Length < 1)
        {
            ModHelper.Warning("Did not have at least 1 param");
            return false;
        }
        return CheckType(parameters[0], out param1);
    }

    /// <summary>
    /// Checks if the parameter array has the given types
    /// </summary>
    public static bool CheckTypes<T1, T2>(this object[] parameters, out T1 param1, out T2 param2)
    {
        param1 = default;
        param2 = default;
        if (parameters.Length < 2)
        {
            ModHelper.Warning("Did not have at least 2 params");
            return false;
        }

        return CheckType(parameters[1], out param2) &&
               CheckTypes(parameters, out param1);
    }

    /// <summary>
    /// Checks if the parameter array has the given types
    /// </summary>
    public static bool CheckTypes<T1, T2, T3>(this object[] parameters, out T1 param1, out T2 param2, out T3 param3)
    {
        param1 = default;
        param2 = default;
        param3 = default;
        if (parameters.Length < 3)
        {
            ModHelper.Warning("Did not have at least 3 params");
            return false;
        }

        return CheckType(parameters[2], out param3) &&
               CheckTypes(parameters, out param1, out param2);
    }

    /// <summary>
    /// Checks if the parameter array has the given types
    /// </summary>
    public static bool CheckTypes<T1, T2, T3, T4>(this object[] parameters, out T1 param1, out T2 param2,
        out T3 param3, out T4 param4)
    {
        param1 = default;
        param2 = default;
        param3 = default;
        param4 = default;
        if (parameters.Length < 4)
        {
            ModHelper.Warning("Did not have at least 4 params");
            return false;
        }

        return CheckType(parameters[3], out param4) &&
               CheckTypes(parameters, out param1, out param2, out param3);
    }

    /// <summary>
    /// Checks if the parameter array has the given types
    /// </summary>
    public static bool CheckTypes<T1, T2, T3, T4, T5>(this object[] parameters, out T1 param1, out T2 param2,
        out T3 param3, out T4 param4, out T5 param5)
    {
        param1 = default;
        param2 = default;
        param3 = default;
        param4 = default;
        param5 = default;
        if (parameters.Length < 5)
        {
            ModHelper.Warning("Did not have at least 5 params");
            return false;
        }

        return CheckType(parameters[4], out param5) &&
               CheckTypes(parameters, out param1, out param2, out param3, out param4);
    }

    /// <summary>
    /// Checks if the parameter array has the given types
    /// </summary>
    public static bool CheckTypes<T1, T2, T3, T4, T5, T6>(this object[] parameters, out T1 param1, out T2 param2,
        out T3 param3, out T4 param4, out T5 param5, out T6 param6)
    {
        param1 = default;
        param2 = default;
        param3 = default;
        param4 = default;
        param5 = default;
        param6 = default;
        if (parameters.Length < 6)
        {
            ModHelper.Warning("Did not have at least 6 params");
            return false;
        }

        return CheckType(parameters[5], out param6) &&
               CheckTypes(parameters, out param1, out param2, out param3, out param4, out param5);
    }
    /// <summary>
    /// Performs the specified action on each element
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="array"></param>
    /// <param name="action">Action to preform on each element</param>
    public static void ForEach<T>(this T[] array, Action<T> action)
    {
        for (var i = 0; i < array.Length; i++)
            action.Invoke(array[i]);
    }

    /// <summary>
    /// Retrieves all the elements that match the conditions defined by the specified predicate.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="array"></param>
    /// <param name="match"> The Predicate delegate that defines the conditions of the elements to search for.</param>
    /// <returns></returns>
    public static T[] FindAll<T>(this T[] array, Predicate<T> match)
    {
        return Array.FindAll(array, match);
    }

    /// <summary>
    /// Return whether or not there are any elements in this
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="array"></param>
    /// <returns></returns>
    public static bool Any<T>(this T[] array)
    {
        return array.Length > 0;
    }

    /// <summary>
    /// Return whether or not there are any elements in this that match the predicate
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="array"></param>
    /// <param name="predicate"></param>
    /// <returns></returns>
    public static bool Any<T>(this T[] array, Func<T, bool> predicate)
    {
        return Enumerable.Any(array, predicate);
    }
    /// <summary>
    /// Return as Il2CppSystem.List
    /// </summary>
    public static List<T> ToIl2CppList<T>(this T[] array)
        where T : Object
    {
        var il2CppList = new List<T>();
        foreach (var item in array)
            il2CppList.Add(item);

        return il2CppList;
    }

    /// <summary>
    /// Return as Il2CppReferenceArray
    /// </summary>
    public static Il2CppReferenceArray<T> ToIl2CppReferenceArray<T>(this T[] array) where T : Object
    {
        var il2cppArray = new Il2CppReferenceArray<T>(array.Length);

        for (var i = 0; i < array.Length; i++)
            il2cppArray[i] = array[i];

        return il2cppArray;
    }

    /// <summary>
    /// Return as LockList
    /// </summary>
    public static LockList<T> ToLockList<T>(this T[] array)
    {
        var lockList = new LockList<T>();
        foreach (var item in array)
            lockList.Add(item);

        return lockList;
    }

    /// <summary>
    /// Return a duplicate of this Array
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="array"></param>
    /// <returns></returns>
    public static T[] Duplicate<T>(this T[] array)
    {
        var newArray = new T[] { };
        foreach (var item in array)
        {
            Array.Resize(ref newArray, newArray.Length + 1);
            newArray[newArray.Length - 1] = item;
        }

        return newArray;
    }

    /// <summary>
    /// Return a duplicate of this array as type TCast
    /// </summary>
    /// <typeparam name="TSource">The original Array Type</typeparam>
    /// <typeparam name="TCast">The Cast type</typeparam>
    /// <param name="array"></param>
    /// <returns></returns>
    public static TCast[] DuplicateAs<TSource, TCast>(this TSource[] array)
        where TSource : Object where TCast : Object
    {
        var newArray = new TCast[] { };
        foreach (var item in array)
        {
            Array.Resize(ref newArray, newArray.Length + 1);
            newArray[newArray.Length - 1] = item.TryCast<TCast>();
        }

        return newArray;
    }

    /// <summary>
    /// Return this with an Item added to it
    /// </summary>
    /// <typeparam name="T">The Type of the Item you want to add</typeparam>
    /// <param name="array"></param>
    /// <param name="objectToAdd">Item to add to this</param>
    /// <returns></returns>
    public static T[] AddTo<T>(this T[] array, T objectToAdd) where T : Object
    {
        if (array is null)
            array = new T[0];

        var list = array.ToList();
        list.Add(objectToAdd);
        return list.ToArray();
    }

    /// <summary>
    /// Return this with Items added to it
    /// </summary>
    /// <typeparam name="T">The Type of the Items you want to add</typeparam>
    /// <param name="array"></param>
    /// <param name="objectsToAdd">Items you want to add</param>
    /// <returns></returns>
    public static T[] AddTo<T>(this T[] array, T[] objectsToAdd) where T : Object
    {
        if (array is null)
            array = new T[0];

        var size = array.Length + objectsToAdd.Length;
        var newReference = new T[size];

        var tempList = new System.Collections.Generic.List<T>(array);
        tempList.AddRange(objectsToAdd);

        for (var i = 0; i < tempList.Count; i++)
        {
            var item = tempList[i];
            newReference[i] = item;
        }

        return newReference;
    }

    /// <summary>
    /// Return this with Items added to it
    /// </summary>
    /// <typeparam name="T">The Type of the Items you want to add</typeparam>
    /// <param name="array"></param>
    /// <param name="objectsToAdd">Items you want to add</param>
    /// <returns></returns>
    public static T[] AddTo<T>(this T[] array, System.Collections.Generic.List<T> objectsToAdd) where T : Object
    {
        return array.AddTo(objectsToAdd.ToArray());
    }


    /// <summary>
    /// Check if this has any items of type TCast
    /// </summary>
    /// <typeparam name="TSource"></typeparam>
    /// <typeparam name="TCast">The Type you're checking for</typeparam>
    /// <param name="array"></param>
    /// <returns></returns>
    public static bool HasItemsOfType<TSource, TCast>(this TSource[] array) where TSource : Object
        where TCast : Object
    {
        // Doing this the ugly way to guarantee no errors. Had a couple of bizarre errors in testing when using LINQ
        foreach (var item in array)
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
    /// Return the first Item of type TCast
    /// </summary>
    /// <typeparam name="TSource"></typeparam>
    /// <typeparam name="TCast">The Type of the Item you want</typeparam>
    /// <param name="array"></param>
    /// <returns></returns>
    public static TCast GetItemOfType<TSource, TCast>(this TSource[] array) where TCast : Object
        where TSource : Object
    {
        if (!HasItemsOfType<TSource, TCast>(array))
            return null;

        var result = Array.Find(array,item => item.IsType<TCast>());
        return result?.TryCast<TCast>();
    }

    /// <summary>
    /// Return all Items of type TCast
    /// </summary>
    /// <typeparam name="TSource"></typeparam>
    /// <typeparam name="TCast">The Type of the Items you want</typeparam>
    /// <param name="array"></param>
    /// <returns></returns>
    public static System.Collections.Generic.IEnumerable<TCast> GetItemsOfType<TSource, TCast>(this TSource[] array)
        where TSource : Object where TCast : Object
    {
        return array.Select(o => o.TryCast<TCast>()).Where(o => o != null);
    }

    /// <summary>
    /// Return this with the first Item of type TCast removed
    /// </summary>
    /// <typeparam name="TSource"></typeparam>
    /// <typeparam name="TCast">The Type of the Item you want to remove</typeparam>
    /// <param name="array"></param>
    /// <returns></returns>
    public static TSource[] RemoveItemOfType<TSource, TCast>(this TSource[] array)
        where TSource : Object
        where TCast : Object
    {
        var behavior = GetItemOfType<TSource, TCast>(array);
        return behavior != null ? RemoveItem(array, behavior) : array;
    }

    /// <summary>
    /// Return this with the first Item of type TCast removed
    /// </summary>
    /// <typeparam name="TSource"></typeparam>
    /// <typeparam name="TCast">The Type of the Item you want to remove</typeparam>
    /// <param name="array"></param>
    /// <param name="itemToRemove">The specific Item to remove</param>
    /// <returns></returns>
    public static TSource[] RemoveItem<TSource, TCast>(this TSource[] array, TCast itemToRemove)
        where TSource : Object where TCast : Object
    {
        if (!HasItemsOfType<TSource, TCast>(array))
            return array;

        var arrayList = array.ToList();

        for (var i = 0; i < array.Length; i++)
        {
            var item = array[i];
            if (item is null || !item.Equals(itemToRemove.TryCast<TCast>()))
                continue;

            arrayList.RemoveAt(i);
            break;
        }

        return arrayList.ToArray();
    }

    /// <summary>
    /// Return this with all Items of type TCast removed
    /// </summary>
    /// <typeparam name="TSource"></typeparam>
    /// <typeparam name="TCast">The Type of the Items that you want to remove</typeparam>
    /// <param name="array"></param>
    /// <returns></returns>
    public static TSource[] RemoveItemsOfType<TSource, TCast>(this TSource[] array)
        where TSource : Object
        where TCast : Object
    {
        if (!HasItemsOfType<TSource, TCast>(array))
            return array;

        var numRemoved = 0;
        var arrayList = array.ToList();
        for (var i = 0; i < array.Length; i++)
        {
            var item = array[i];
            if (item is null || !item.IsType<TCast>())
                continue;

            arrayList.RemoveAt(i - numRemoved);
            numRemoved++;
        }

        return arrayList.ToArray();
    }

    /// <summary>
    /// A string with all array elements printed together with no spaces
    /// <br />
    /// Useful for the suffix for Tower IDS like DartMonkey-230
    /// </summary>
    /// <param name="arr">The array</param>
    /// <returns></returns>
    public static string Printed(this int[] arr)
    {
        return arr.Aggregate("", (current, i) => current + i);
    }

    /// <summary>
    /// Returns the index of the highest tier, then the middle, then the lowest
    /// <br />
    /// Breaks ties by Middle Path >> Top Path >> Bottom Path
    /// </summary>
    /// <param name="arr"></param>
    /// <returns></returns>
    public static int[] Order(this int[] arr)
    {
        var order = new[] {0, 1, 2};
        return order.OrderByDescending(i => arr[i]).ThenByDescending(i => i % 2).ThenBy(i => i).ToArray();
    }

    /// <summary>
    /// Returns whether an int array is a valid set of tiers for a Tower
    /// </summary>
    /// <param name="tiers"></param>
    /// <returns></returns>
    public static bool IsValid(this int[] tiers)
    {
        return tiers.Length == 3 && tiers.Max() <= 5 && tiers.Min() == 0 && tiers.OrderBy(i => i).ToArray()[1] <= 2;
    }
}