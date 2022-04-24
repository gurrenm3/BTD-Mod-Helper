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
}