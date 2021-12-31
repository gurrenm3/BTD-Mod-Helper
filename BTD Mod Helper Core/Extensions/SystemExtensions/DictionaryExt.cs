using System.Collections.Generic;

namespace BTD_Mod_Helper.Extensions
{
    public static class DictionaryExt
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
            var enumerator = keyValuePairs.Values.GetEnumerator();
            while (enumerator.MoveNext())
            {
                values.Add(enumerator.Current);
            }

            return values;
        }
    }
}
