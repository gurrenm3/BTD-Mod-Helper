using System.Collections.Generic;
using BTD_Mod_Helper.Api.Helpers;
using Il2CppNinjaKiwi.Common;
using Il2CppTMPro;
using UnityEngine;
#pragma warning disable CS1591

namespace BTD_Mod_Helper.Api;

/// <summary>
/// Class to statically store TMP_FontAsset for different fonts
/// </summary>
public static class Fonts
{
    private static readonly Dictionary<string, TMP_FontAsset> FontsByName = new();

    public static TMP_FontAsset Btd6FontBody => Get("Btd6FontBodySDF");
    public static TMP_FontAsset Btd6FontTitle => Get("Btd6FontTitleSDF");
    public static TMP_FontAsset CurrencyExtras => Get("CurrencyExtrasSDF");
    public static TMP_FontAsset LiberationSans => Get("LiberationSans");

    private static TMP_FontAsset inconsolata;
    public static TMP_FontAsset Inconsolata
    {
        get
        {
            if (inconsolata != null) return inconsolata;
            
            var unityAssets = ModContent.GetBundle<MelonMain>("unity_assets");

            inconsolata = unityAssets.LoadAsset("Inconsolata").Cast<TMP_FontAsset>();
            inconsolata.material = unityAssets.LoadAsset("Inconsolata Material").Cast<Material>();
            inconsolata.material.mainTexture = inconsolata.atlas = unityAssets.LoadAsset("Inconsolata Atlas").Cast<Texture2D>();

            return inconsolata;
        }
    }

    internal static void Load()
    {
        if (FontsByName.Count == 0)
        {
            var fontAssets = Resources.FindObjectsOfTypeAll<TMP_FontAsset>();

            foreach (var fontAsset in fontAssets)
            {
                FontsByName[fontAsset.name] = fontAsset;
            }
        }
    }

    /// <summary>
    /// Gets an AnimationController by its name, or null if there isn't one with that name
    /// </summary>
    public static TMP_FontAsset Get(string name) => FontsByName.GetValueOrDefault(name);
}