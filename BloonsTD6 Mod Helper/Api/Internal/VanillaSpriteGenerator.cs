using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using BTD_Mod_Helper.Api.Components;
using CommandLine;
using Il2CppInterop.Runtime;
using Il2CppNinjaKiwi.Common.ResourceUtils;
using Il2CppSystem.Linq;
using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.AddressableAssets.ResourceLocators;
using UnityEngine.ResourceManagement.ResourceLocations;
using UnityEngine.U2D;
namespace BTD_Mod_Helper.Api.Internal;

internal static class VanillaSpriteGenerator
{
    // Some names map to multiple Sprites. Keep them sorted by their guid so that they'll always be given the same number
    internal static readonly Dictionary<string, SortedSet<string>> SpriteReferences = new();

    /// <summary>
    /// Generate the VanillaSprites.cs file
    /// <br />
    /// To get the necessary files, from the "...\BloonsTD6\BloonsTD6_Data\StreamingAssets\aa\StandaloneWindows64\Full\"
    /// folder, choose:
    /// <list type="">
    ///     <item>asset_references_assets_all_[...].bundle</item>
    ///     <item>initial_loading_ui_scenes_all_all_[...].bundle</item>
    ///     <item>sprite_atlases_assets_all_[...].bundle</item>
    ///     <item>ui_scenes_all_[...].bundle</item>
    /// </list>
    /// in Asset Studio. Then, select all assets of type Sprite, and in the menu do Export -> Dump -> Selected assets
    /// </summary>
    internal static void GenerateVanillaSprites()
    {
        var vanillaSpritesCs = Path.Combine(MelonMain.ModHelperSourceFolder, "BloonsTD6 Mod Helper", "Api", "Enums",
            "VanillaSprites.cs");

        PopulateFromAddressables();

        var realNames = new HashSet<string>();

        using var vanillaSpritesFile = new StreamWriter(vanillaSpritesCs);

        vanillaSpritesFile.WriteLine(
            """
            using Il2CppAssets.Scripts.Utils;
            using System.Collections.Generic;

            #pragma warning disable CS1591
            namespace BTD_Mod_Helper.Api.Enums;
                
            public static class VanillaSprites
            {
            """
        );

        foreach (var (name, guids) in SpriteReferences.OrderBy(pair => pair.Key))
        {
            var i = 1;
            foreach (var guid in guids)
            {
                var realName = FixName(name) + (i > 1 ? i.ToString() : "");
                vanillaSpritesFile.WriteLine(
                    $"""
                         public const string {realName} = "{guid}";
                     """
                );
                i++;
                realNames.Add(realName);
            }
        }

        vanillaSpritesFile.WriteLine();
        vanillaSpritesFile.WriteLine(
            """
                public static readonly Dictionary<string, string> ByName;
                static VanillaSprites()
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

        SpriteReferences.Clear();
    }

    private static string FixName(string name)
    {
        if (Regex.Match(name, @"^\d\d\d-").Success)
        {
            name = string.Concat(name.Split('-').Reverse());
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
        var resourceMap = Addressables.ResourceLocators.First().Cast<ResourceLocationMap>();

        foreach (var (key, list) in resourceMap.Locations)
        {
            var guid = key.ToString();
            if (!Guid.TryParse(guid, out _)) continue;

            var spriteLocation = list.Cast<Il2CppReferenceArray<IResourceLocation>>()
                .FirstOrDefault(location => location.ResourceType == Il2CppType.Of<Sprite>());

            if (spriteLocation != null)
            {
                var name = Path.GetFileNameWithoutExtension(spriteLocation.InternalId);

                SpriteReferences.TryAdd(name, []);
                SpriteReferences[name].Add(guid);
            }
        }

        var spriteAtlases = resourceMap.Locations.Values()
            .SelectMany(list => list.Cast<Il2CppReferenceArray<IResourceLocation>>())
            .Where(location => location.ResourceType == Il2CppType.Of<SpriteAtlas>())
            .Select(location => location.PrimaryKey)
            .Distinct();

        foreach (var atlasName in spriteAtlases)
        {
            if (atlasName == "AssetLibraryAtlas") continue;

            var atlas = ResourceLoader.LoadAtlas(atlasName).WaitForCompletion();

            var dummyArray = new Il2CppReferenceArray<Sprite>(atlas.spriteCount);
            atlas.GetSprites(dummyArray);

            foreach (var sprite in dummyArray)
            {
                var name = sprite.name.Replace("(Clone)", "");
                var guid = $"{atlasName}[{name}]";

                SpriteReferences.TryAdd(name, []);
                SpriteReferences[name].Add(guid);
            }
        }

    }
}