using System;
using UnityEngine;
namespace BTD_Mod_Helper.Extensions;

/// <summary>
/// Extension methods for keycodes
/// </summary>
public static class KeyCodeExt
{
    /// <summary>
    /// Gets the path string for the given key code
    /// </summary>
    /// <param name="keyCode"></param>
    /// <returns></returns>
    public static string GetPath(this KeyCode keyCode)
    {
        var key = keyCode.ToString();
        if (key.Length == 1)
        {
            key = key.ToLower();
        }

        return $"<Keyboard>/{key}";
    }

    /// <summary>
    /// Gets the Key code for a given path string
    /// </summary>
    /// <param name="path"></param>
    /// <returns></returns>
    public static KeyCode GetKeyCode(this string path)
    {
        if (string.IsNullOrWhiteSpace(path)) return KeyCode.None;

        var key = path.Split('/')[^1];
        if (int.TryParse(key, out _))
        {
            key = "Alpha" + key;
        }
        if (key == "enter")
        {
            key = "return";
        }
        return Enum.TryParse(key, true, out KeyCode keyCode) ? keyCode : default;
    }
}