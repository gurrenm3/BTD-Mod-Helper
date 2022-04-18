using System.Linq;
using Il2CppSystem.Collections.Generic;

namespace BTD_Mod_Helper.Extensions
{
    /// <summary>
    /// Extensions for il2cpp dictionaries
    /// </summary>
    public static class Il2CppSystemDictionaryExt
    {
        /// <summary>
        /// (Cross-Game compatible) Get all of the values from this Dictionary as a list
        /// </summary>
        public static Il2CppSystem.Collections.Generic.List<TValue> GetValues<TKey, TValue>(this Il2CppSystem.Collections.Generic.Dictionary<TKey, TValue> keyValuePairs)
        {
            return keyValuePairs.entries.Select(entry => entry.value).ToIl2CppList();
        }


        /// <summary>
        /// Deconstruct method of IL2CPP KeyValuePairs
        /// </summary>
        public static void Deconstruct<K, V>(this Il2CppSystem.Collections.Generic.KeyValuePair<K, V> kvp, out K k, out V v)
        {
            k = kvp.key;
            v = kvp.value;
        }
    }
}
