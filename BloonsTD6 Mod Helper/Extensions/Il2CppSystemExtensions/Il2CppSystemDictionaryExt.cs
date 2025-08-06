using System.Collections;
using System.Linq;
using Il2CppSystem.Collections.Generic;
namespace BTD_Mod_Helper.Extensions;

/// <summary>
/// Extensions for il2cpp dictionaries
/// </summary>
public static class Il2CppSystemDictionaryExt
{
    /// <summary>
    /// Get all of the values from this Dictionary as a list
    /// </summary>
    public static List<TValue> GetValues<TKey, TValue>(this Dictionary<TKey, TValue> keyValuePairs) =>
        keyValuePairs.Values().ToIl2CppList();

    /// <summary>
    /// Get all of the values from this Dictionary
    /// </summary>
    public static System.Collections.Generic.IEnumerable<TValue> Values<TKey, TValue>(
        this Dictionary<TKey, TValue> keyValuePairs)
    {
        foreach (var (_, v) in keyValuePairs)
        {
            yield return v;
        }
    }

    /// <summary>
    /// Get all of the keys from this Dictionary as a list
    /// </summary>
    public static List<TKey> GetKeys<TKey, TValue>(this Dictionary<TKey, TValue> keyValuePairs) =>
        keyValuePairs.Keys().ToIl2CppList();

    /// <summary>
    /// Get all of the keys from this Dictionary
    /// </summary>
    public static System.Collections.Generic.IEnumerable<TKey> Keys<TKey, TValue>(
        this Dictionary<TKey, TValue> keyValuePairs)
    {
        foreach (var (k, _) in keyValuePairs)
        {
            yield return k;
        }
    }

    /// <summary>
    /// Get all of the entries from this Dictionary
    /// </summary>
    public static System.Collections.Generic.IEnumerable<(TKey key, TValue value)> Entries<TKey, TValue>(
        this Dictionary<TKey, TValue> keyValuePairs)
    {
        foreach (var (k, v) in keyValuePairs)
        {
            yield return (k, v);
        }
    }


    /// <summary>
    /// Deconstruct method of IL2CPP KeyValuePairs
    /// </summary>
    public static void Deconstruct<K, V>(this KeyValuePair<K, V> kvp, out K k, out V v)
    {
        k = kvp.key;
        v = kvp.value;
    }
}