using System.Collections.Generic;
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

    /// <inheritdoc cref="Regex.Replace(string,string,string)" />
    public static string RegexReplace(this string input, string pattern, string replacement) =>
        Regex.Replace(input, pattern, replacement);

    /// <summary>
    /// <inheritdoc cref="TextInfo.ToTitleCase" />
    /// </summary>
    public static string ToTitleCase(this string input) => CultureInfo.InvariantCulture.TextInfo.ToTitleCase(input);

    /// <summary>
    /// Gets the localization from the current localization text table, or the default one if it's not present in the current one. 
    /// If the id is not present in any of these, returned as spaced or not spaced depending on parameters.
    /// </summary>
    /// <param name="id">The ID of the thing you're trying to get the localization of.</param>
    /// <param name="returnAsSpacedIfNoEntry">Should this return the id with spaces if there's no localization present?</param>
    /// <returns></returns>
    public static string GetBtd6Localization(this string id, bool returnAsSpacedIfNoEntry = true)
    {
        if (!LocalizationManager.Instance.textTable.ContainsKey(id) &&
            !LocalizationManager.Instance.defaultTable.ContainsKey(id))
        {
            return returnAsSpacedIfNoEntry ? id.Spaced() : id;
        }

        return LocalizationManager.Instance.GetText(id);
    }

    /// <inheritdoc cref="GetBtd6Localization"/>
    public static string Localize(this string id) => GetBtd6Localization(id);

    /// <summary>
    /// Splits the string on spaces, but preserves strings of words with spaces if surround by quotes
    /// </summary>
    /// <param name="input"></param>
    /// <returns></returns>
    public static string[] SplitRespectingQuotes(this string input)
    {
        const string pattern = @"(?<=\s|^)([""'])(.+?)\1|[^""'\s]+";

        var matches = Regex.Matches(input, pattern);

        var result = new List<string>();

        foreach (Match match in matches)
        {
            var value = match.Value.Trim();
            // If the section is quoted, remove the quotes
            if (value.StartsWith("\"") && value.EndsWith("\"") || value.StartsWith("'") && value.EndsWith("'"))
            {
                value = value.Substring(1, value.Length - 2);
            }
            result.Add(value);
        }

        return result.ToArray();
    }
}