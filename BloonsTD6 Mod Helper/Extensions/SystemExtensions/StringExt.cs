using Il2CppNinjaKiwi.Common;
using System.Globalization;
using System.Text.RegularExpressions;
namespace BTD_Mod_Helper.Extensions;

/// <summary>
/// Extensions for strings
/// </summary>
public static class StringExt
{
    /// <summary>
    /// Puts spaces between capitalized words within a string
    /// </summary>
    public static string Spaced(this string s) => Regex.Replace(s, "(\\B[A-Z])", " $1");

    /// <summary>
    /// Returns null if a string is empty / whitespace, otherwise just returns back the string
    /// </summary>
    public static string NullIfEmpty(this string s) => string.IsNullOrWhiteSpace(s) ? null : s;

    /// <summary>
    /// <inheritdoc cref="Regex.Replace(string,string,string)" />
    /// </summary>
    public static string RegexReplace(this string input, string pattern, string replacement) =>
        Regex.Replace(input, pattern, replacement);

    /// <summary>
    /// <inheritdoc cref="TextInfo.ToTitleCase" />
    /// </summary>
    public static string ToTitleCase(this string input) => new CultureInfo("en-US", false).TextInfo.ToTitleCase(input);

    /// <summary>
    /// Gets the localization from the current localization text table, or the default one if it's not present in the current one. 
    /// If the id is not present in any of these, returned as spaced or not spaced depending on parameters.
    /// </summary>
    /// <param name="id">The ID of the thing you're trying to get the localization of.</param>
    /// <param name="returnAsSpacedIfNoEntry">Should this return the id with spaces if there's no localization present?</param>
    /// <returns></returns>
    public static string GetBtd6Localization(this string id, bool returnAsSpacedIfNoEntry = true)
    {
        if (LocalizationManager.Instance.textTable.ContainsKey(id))
        {
            return LocalizationManager.Instance.textTable[id];
        }
        
        if (LocalizationManager.Instance.defaultTable.ContainsKey(id))
        {
            return LocalizationManager.Instance.defaultTable[id];
        }
        
        return returnAsSpacedIfNoEntry ? id.Spaced() : id;
    }
}