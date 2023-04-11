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
    /// <inheritdoc cref="Regex.Replace(string,string,string)"/>
    /// </summary>
    public static string RegexReplace(this string input, string pattern, string replacement) =>
        Regex.Replace(input, pattern, replacement);

    /// <summary>
    /// <inheritdoc cref="TextInfo.ToTitleCase"/>
    /// </summary>
    public static string ToTitleCase(this string input) => new CultureInfo("en-US", false).TextInfo.ToTitleCase(input);
}