using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using Il2CppInterop.Runtime;
using Il2CppNinjaKiwi.Common.Linq;
using Il2CppNinjaKiwi.Common.ResourceUtils;
using Il2CppSystem.Linq;
using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.U2D;

namespace BTD_Mod_Helper.Api.Internal;

internal static class VanillaAudioClipsGenerator
{
    // Some names map to multiple Sprites. Keep them sorted by their guid so that they'll always be given the same number
    internal static readonly Dictionary<string, string> AudioClipReferences = new();

    /// <summary>
    /// Generate the VanillaSprites.cs file
    /// </summary>
    internal static void GenerateVanillaAudioClips()
    {
        var csFile = Path.Combine(MelonMain.ModHelperSourceFolder, "BloonsTD6 Mod Helper", "Api", "Enums",
            "VanillaAudioClips.cs");

        PopulateFromAddressables();

        var realNames = new HashSet<string>();

        using var vanillaSpritesFile = new StreamWriter(csFile);

        vanillaSpritesFile.WriteLine(
            """
            using Il2CppAssets.Scripts.Utils;
            using System.Collections.Generic;

            #pragma warning disable CS1591
            namespace BTD_Mod_Helper.Api.Enums;
                
            public static class VanillaAudioClips
            {
            """
        );

        foreach (var (name, guid) in AudioClipReferences.OrderBy(pair => pair.Key))
        {
            var i = 1;
            var realName = FixName(name) + (i > 1 ? i.ToString() : "");
            vanillaSpritesFile.WriteLine(
                $"""
                     public const string {realName} = "{guid}";
                 """
            );
            i++;
            realNames.Add(realName);
        }

        vanillaSpritesFile.WriteLine();
        vanillaSpritesFile.WriteLine(
            """
                public static readonly Dictionary<string, string> ByName;
                static VanillaAudioClips()
                {
                    ByName = new Dictionary<string, string>
                    {
            """
        );
        foreach (var realName in realNames)
        {
            vanillaSpritesFile.WriteLine(
                $"""
                             ["{realName}"] = {realName},
                 """
            );
        }
        vanillaSpritesFile.WriteLine(
            """
                    };
                }
            }
            """
        );

        AudioClipReferences.Clear();
    }

    private static string FixName(string name)
    {
        if (Regex.Match(name, @"^\d\d\d-").Success)
        {
            name = string.Concat(name.Split('-').AsEnumerable().Reverse());
        }

        if (name.Contains('#'))
        {
            name = string.Concat(name.Split('#')[0].Trim());
        }

        if (Regex.IsMatch(name, @"^\d.+"))
        {
            name = "The" + name;
        }

        name = Regex.Replace(name, @"[^A-Za-z0-9_]", "");

        return name;
    }

    public static void PopulateFromAddressables()
    {
        var resourceMap = Addressables.ResourceLocators.First();

        var keys = resourceMap.Keys.ToArray().Select(o => o.ToString()).ToArray();

        foreach (var guid in keys)
        {
            if (!Guid.TryParse(guid, out _) || !resourceMap.Locate(guid, Il2CppType.Of<AudioClip>(), out var list)) continue;

            var spriteLocation = list.FirstOrDefault();

            if (spriteLocation != null)
            {
                var name = Path.GetFileNameWithoutExtension(spriteLocation.InternalId);

                AudioClipReferences[name] = guid;
            }
        }
    }
}