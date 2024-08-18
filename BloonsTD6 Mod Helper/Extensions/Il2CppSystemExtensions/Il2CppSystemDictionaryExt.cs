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
    public static List<TValue> GetValues<TKey, TValue>(this Dictionary<TKey, TValue> keyValuePairs)
    {
        return keyValuePairs._entries.Select(entry => entry.value).Take(keyValuePairs.Count).ToIl2CppList();
    }

    /// <summary>
    /// Get all of the values from this Dictionary
    /// </summary>
    public static System.Collections.Generic.IReadOnlyCollection<TValue> Values<TKey, TValue>(
        this Dictionary<TKey, TValue> keyValuePairs)
    {
        return keyValuePairs._entries.Select(entry => entry.value).Take(keyValuePairs.Count).ToList();
    }

    /// <summary>
    /// Get all of the keys from this Dictionary as a list
    /// </summary>
    public static List<TKey> GetKeys<TKey, TValue>(this Dictionary<TKey, TValue> keyValuePairs)
    {
        return keyValuePairs._entries.Select(entry => entry.key).Take(keyValuePairs.Count).ToIl2CppList();
    }

    /// <summary>
    /// Get all of the keys from this Dictionary
    /// </summary>
    public static System.Collections.Generic.IReadOnlyCollection<TKey> Keys<TKey, TValue>(
        this Dictionary<TKey, TValue> keyValuePairs)
    {
        return keyValuePairs._entries.Select(entry => entry.key).Take(keyValuePairs.Count).ToList();
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