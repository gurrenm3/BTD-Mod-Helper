using System;
using System.Linq;
using UnityEngine;
namespace BTD_Mod_Helper.Extensions;

/// <summary>
/// Extension methods for keycodes
/// </summary>
internal static class KeyCodeExt
{
    internal static string GetPath(this KeyCode keyCode)
    {
        var key = keyCode.ToString();
        if (key.Length == 1)
        {
            key = key.ToLower();
        }

        return $"<Keyboard>/{key}";
    }

    internal static KeyCode GetKeyCode(this string path)
    {
        var key = path.Split('/').Last();
        if (int.TryParse(key, out _))
        {
            key = "Alpha" + key;
        }
        return Enum.TryParse(key, true, out KeyCode keyCode) ? keyCode : default;
    }
}