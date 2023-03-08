using System.Collections.Generic;
using System.Linq;
namespace BTD_Mod_Helper.Extensions;

/// <summary>
/// Extensions for normal System Dictionaries
/// </summary>
public static class DictionaryExt
{
    /// <summary>
    /// Get all of the values from this Dictionary as a list
    /// </summary>
    public static List<TValue> GetValues<TKey, TValue>(this Dictionary<TKey, TValue> keyValuePairs) where TKey : notnull
    {
        return keyValuePairs.Values.ToList();
    }
}