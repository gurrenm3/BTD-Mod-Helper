using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using Il2CppInterop.Runtime;
using Il2CppNinjaKiwi.Common.Linq;
using Il2CppSystem.Linq;
using UnityEngine;
using UnityEngine.AddressableAssets;

namespace BTD_Mod_Helper.Api.Internal;

internal static class VanillaPrefabsGenerator
{
    // Some names map to multiple Sprites. Keep them sorted by their guid so that they'll always be given the same number
    internal static readonly Dictionary<string, string> PrefabReferences = new();
    internal static readonly Dictionary<string, string> PrefabReferences2 = new();

    /// <summary>
    /// Generate the VanillaSprites.cs file
    /// </summary>
    internal static void GenereateVanillaPrefabs()
    {
        var csFile = Path.Combine(MelonMain.ModHelperSourceFolder, "BloonsTD6 Mod Helper", "Api", "Enums",
            "VanillaPrefabs.cs");

        PopulateFromAddressables();

        var realNames = new HashSet<string>();

        using var vanillaSpritesFile = new StreamWriter(csFile);

        vanillaSpritesFile.WriteLine(
            """
            using Il2CppAssets.Scripts.Utils;
            using System.Collections.Generic;

            #pragma warning disable CS1591
            namespace BTD_Mod_Helper.Api.Enums;
                
            public static class VanillaPrefabs
            {
            """
        );

        foreach (var (name, guid) in PrefabReferences.OrderBy(pair => pair.Key))
        {
            var i = 1;
            var realName = FixName(name) + (i > 1 ? i.ToString() : "");
            if (string.IsNullOrEmpty(realName)) continue;
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
                static VanillaPrefabs()
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

        PrefabReferences.Clear();
    }

    private static string FixName(string name)
    {
        return name
            .RegexReplace(@"(\d\d\d)-([^\.]+)\.", "$2$1.")
            .Replace("Generated/", "")
            .Replace("Graphics/", "")
            .Replace("Assets/", "")
            .Replace("Combinations/", "")
            .Replace("path01/", "")
            .Replace("path02/", "")
            .Replace("path03/", "")
            .Replace("Prefabs/", "")
            .Replace("AssetBundleMaps/", "")
            .Replace("/", "_")
            .Replace("-", "")
            .Replace(" ", "")
            .Replace("#", "")
            .Replace(".prefab", "");
    }

    public static void PopulateFromAddressables()
    {
        var resourceMap = Addressables.ResourceLocators.First();

        var keys = resourceMap.Keys.ToArray().Select(o => o.ToString()).ToArray();

        foreach (var guid in keys)
        {
            if (!Guid.TryParse(guid, out _) ||
                !resourceMap.Locate(guid, Il2CppType.Of<GameObject>(), out var list)) continue;

            var location = list.FirstOrDefault();

            if (location != null &&
                Path.GetExtension(location.InternalId) == ".prefab" &&
                !(location.InternalId.Contains("/UI")))
            {
                // var name = Path.GetFileNameWithoutExtension(location.InternalId);
                if (!PrefabReferences.TryAdd(location.InternalId, guid))
                {
                }
            }
        }
    }
}