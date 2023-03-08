using System.Linq;
using Il2CppAssets.Scripts.Utils;
using Il2CppInterop.Runtime;
using Il2CppSystem;
using Il2CppSystem.Collections.Generic;
using ArgumentException = System.ArgumentException;
using ArgumentNullException = System.ArgumentNullException;
namespace BTD_Mod_Helper.Extensions;

/// <summary>
/// Extensions for the normal System IEnumerable class
/// </summary>
public static class IEnumerableExt
{
    /// <summary>
    /// Return as Il2CppSystem.List
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="enumerable"></param>
    /// <returns></returns>
    public static List<T> ToIl2CppList<T>(this System.Collections.Generic.IEnumerable<T> enumerable)
    {
        var il2CppList = new List<T>();
        foreach (var t in enumerable)
        {
            il2CppList.Add(t);
        }

        return il2CppList;
    }

    /// <summary>
    /// Return as Il2CppReferenceArray
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="enumerable"></param>
    /// <returns></returns>
    public static Il2CppReferenceArray<T> ToIl2CppReferenceArray<T>(this System.Collections.Generic.IEnumerable<T> enumerable)
        where T : Object
    {
        return enumerable as T[] ?? enumerable.ToArray();
    }

    /// <summary>
    /// Return as LockList
    /// </summary>
    public static LockList<T> ToLockList<T>(this System.Collections.Generic.IEnumerable<T> enumerable)
    {
        var lockList = new LockList<T>();
        foreach (var t in enumerable)
        {
            lockList.Add(t);
        }

        return lockList;
    }

    /// <summary>
    /// Casts a reference array to an IEnumerable of a different Il2cpptype.
    /// <br/>
    /// Objects that aren't of the specified type will end up as null in the result
    /// </summary>
    /// <param name="list"></param>
    /// <typeparam name="TSource"></typeparam>
    /// <typeparam name="TCast"></typeparam>
    /// <returns></returns>
    public static System.Collections.Generic.IEnumerable<TCast> CastAll<TSource, TCast>(this System.Collections.Generic.IEnumerable<TSource> list)
        where TSource : Object where TCast : Object
    {
        return list?.Select(m =>
        {
            if (m is null) return null;

            var tryCast = m.TryCast<TCast>();
            if (tryCast == null)
            {
                ModHelper.Warning(
                    $"Couldn't cast type {m.GetIl2CppType().Name} to {Il2CppType.Of<TCast>().Name}");
            }

            return tryCast;
        });
    }


    // Thanks to Dmitry Bychenko on StackOverflow for this
    /// <summary>
    /// Returns the argument that maximizes the given value
    /// </summary>
    public static T ArgMax<T, K>(this System.Collections.Generic.IEnumerable<T> source, System.Func<T, K> map = null, System.Collections.Generic.IComparer<K> comparer = null)
    {
        if (ReferenceEquals(null, source))
            throw new ArgumentNullException(nameof(source));

        var result = default(T);
        var maxKey = default(K);
        var first = true;

        comparer ??= System.Collections.Generic.Comparer<K>.Default;

        map ??= arg => (K) (object) arg;

        foreach (var item in source)
        {
            var key = map(item);

            if (first || comparer.Compare(key, maxKey) > 0)
            {
                first = false;
                maxKey = key;
                result = item;
            }
        }

        if (!first)
            return result;
        throw new ArgumentException(@"Can't compute ArgMax on empty sequence.", nameof(source));
    }

    /// <summary>
    /// Deconstruct IGrouping to list
    /// </summary>
    /// <param name="grouping"></param>
    /// <param name="k"></param>
    /// <param name="v"></param>
    /// <typeparam name="K"></typeparam>
    /// <typeparam name="V"></typeparam>
    public static void Deconstruct<K, V>(this IGrouping<K, V> grouping, out K k, out System.Collections.Generic.List<V> v)
    {
        k = grouping.Key;
        v = grouping.ToList();
    }
        
    /// <summary>
    /// Repeats each element in the sequence n times, keeping the same order of elements
    /// </summary>
    public static System.Collections.Generic.IEnumerable<T> Repeat<T>(this System.Collections.Generic.IEnumerable<T> enumerable, int n)
    {
        return enumerable.SelectMany(t => Enumerable.Repeat(t, n));
    }
}