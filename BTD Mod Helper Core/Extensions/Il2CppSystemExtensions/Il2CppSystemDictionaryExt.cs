using Il2CppSystem.Collections.Generic;

namespace BTD_Mod_Helper.Extensions
{
    public static class Il2CppSystemDictionaryExt
    {
        /// <summary>
        /// (Cross-Game compatible) Get all of the values from this Dictionary as a list
        /// </summary>
        /// <typeparam name="TKey"></typeparam>
        /// <typeparam name="TValue"></typeparam>
        /// <param name="keyValuePairs"></param>
        /// <returns></returns>
        public static List<TValue> GetValues<TKey, TValue>(this Dictionary<TKey, TValue> keyValuePairs)
        {
            var values = new List<TValue>();
            var enumerator = keyValuePairs.values.GetEnumerator();
            while (enumerator.MoveNext())
            {
                values.Add(enumerator.currentValue);
            }

            return values;
        }

        /// <summary>
        /// Deconstruct method of normal KeyValuePairs. TODO why do some files need this?
        /// </summary>
        /// <param name="kvp"></param>
        /// <param name="k"></param>
        /// <param name="v"></param>
        /// <typeparam name="K"></typeparam>
        /// <typeparam name="V"></typeparam>
        public static void Deconstruct<K, V>(this System.Collections.Generic.KeyValuePair<K, V> kvp, out K k, out V v)
        {
            k = kvp.Key;
            v = kvp.Value;
        }

        /// <summary>
        /// Deconstruct method of IL2CPP KeyValuePairs
        /// </summary>
        /// <param name="kvp"></param>
        /// <param name="k"></param>
        /// <param name="v"></param>
        /// <typeparam name="K"></typeparam>
        /// <typeparam name="V"></typeparam>
        public static void Deconstruct<K, V>(this KeyValuePair<K, V> kvp, out K k, out V v)
        {
            k = kvp.key;
            v = kvp.value;
        }
    }
}
