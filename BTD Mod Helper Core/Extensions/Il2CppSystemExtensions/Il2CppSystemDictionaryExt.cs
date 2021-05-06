using System;
using Il2CppSystem.Collections.Generic;
using System.Text;

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
            List<TValue> values = new List<TValue>();
            var enumerator = keyValuePairs.Values.GetEnumerator();
            while (enumerator.MoveNext())
            {
                values.Add(enumerator.Current);
            }

            return values;
        }
    }
}
