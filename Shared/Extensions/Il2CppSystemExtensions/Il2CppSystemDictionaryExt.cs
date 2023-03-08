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
        return keyValuePairs._entries.Select(entry => entry.value).ToIl2CppList();
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