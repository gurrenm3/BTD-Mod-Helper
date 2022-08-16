using System.Collections.Generic;

using TMPro;

using UnityEngine;
#pragma warning disable CS1591

namespace BTD_Mod_Helper.Api;

/// <summary>
/// Class to statically store TMP_FontAsset for different fonts
/// </summary>
public static class Fonts {
    private static readonly Dictionary<string, TMP_FontAsset> FontsByName = new();

    internal static void Load() {
        if (FontsByName.Count == 0) {
#if BloonsTD6
            var fontAssets = Resources.FindObjectsOfTypeAll<TMP_FontAsset>();
#elif BloonsAT
                var fontAssets = Resources.FindObjectsOfTypeAll(Il2CppType.Of<TMP_FontAsset>());
#endif
            foreach (var fontAsset in fontAssets) {
                FontsByName[fontAsset.name] = fontAsset;
                // ModHelper.Msg("Font: " + fontAsset.name);
            }
        }
    }

    /// <summary>
    /// Gets an AnimationController by its name, or null if there isn't one with that name
    /// </summary>
    public static TMP_FontAsset Get(string name) {
        return FontsByName.TryGetValue(name, out var anim) ? anim : null;
    }

    public static TMP_FontAsset Btd6FontBody => Get("Btd6FontBodySDF");
    public static TMP_FontAsset Btd6FontTitle => Get("Btd6FontTitleSDF");
    public static TMP_FontAsset CurrencyExtras => Get("CurrencyExtrasSDF");
    public static TMP_FontAsset LiberationSans => Get("CurrencyExtrasSDF");
}