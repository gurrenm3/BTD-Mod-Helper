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
}