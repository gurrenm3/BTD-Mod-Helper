﻿using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;

namespace BTD_Mod_Helper.Api.Helpers;

internal class VanillaSpriteGenerator
{
    private const string Tab = "    ";

    // Some names map to multiple Sprites. Keep them sorted by their guid so that they'll always be given the same number
    internal static readonly Dictionary<string, SortedSet<string>> SpriteReferences = new();

    /// <summary>
    /// Generate the VanillaSprites.cs file
    /// <br/>
    /// To get the necessary files, from the "...\BloonsTD6\BloonsTD6_Data\StreamingAssets\aa\StandaloneWindows64\Full\" folder, choose:
    /// <list type="">
    ///     <item>asset_references_assets_all_[...].bundle</item>
    ///     <item>asset_references_assets_all_[...].bundle</item>
    ///     <item>initial_loading_ui_scenes_all_all_[...].bundle</item>
    ///     <item>sprite_atlases_assets_all_[...].bundle</item>
    /// </list>
    /// in Asset Studio. Then, select all assets of type Sprite, and in the menu do Export -> Dump -> Selected assets
    /// </summary>
    internal static void GenerateVanillaSprites(string vanillaSpritesCs, string folder)
    {
        if (!Directory.Exists(folder))
        {
            ModHelper.Error($"No directory {folder}");
            return;
        }

        var files = Directory.GetFiles(folder);
        foreach (var file in files)
        {
            if (ParseFile(file, out var name, out var guid))
            {
                if (!SpriteReferences.ContainsKey(name))
                {
                    SpriteReferences[name] = new SortedSet<string>();
                }

                SpriteReferences[name].Add(guid);
            }
        }

        using (var vanillaSpritesFile = new StreamWriter(vanillaSpritesCs))
        {
            vanillaSpritesFile.WriteLine("using Assets.Scripts.Utils;");
            vanillaSpritesFile.WriteLine("");
            vanillaSpritesFile.WriteLine("#pragma warning disable CS1591");
            vanillaSpritesFile.WriteLine("namespace BTD_Mod_Helper.Api.Enums");
            vanillaSpritesFile.WriteLine("{");
            vanillaSpritesFile.WriteLine($"{Tab}public static class VanillaSprites");
            vanillaSpritesFile.WriteLine($"{Tab}{{");

            foreach (var (name, guids) in SpriteReferences)
            {
                var i = 1;
                foreach (var guid in guids)
                {
                    var realName = name + (i > 1 ? i.ToString() : "");
                    vanillaSpritesFile.WriteLine(
                        $"{Tab}{Tab}public static SpriteReference {realName} => ModContent.CreateSpriteReference(\"{guid}\");"
                    );
                    i++;
                }
            }

            vanillaSpritesFile.WriteLine($"{Tab}}}");
            vanillaSpritesFile.WriteLine("}");
        }

        SpriteReferences.Clear();
    }

    private static bool ParseFile(string file, out string name, out string guid)
    {
        name = "";
        guid = "";
        string? originalName = null;
        using var spriteDump = new StreamReader(file);
        while (spriteDump.ReadLine() is string line)
        {
            if (line.Contains("string m_Name"))
            {
                originalName = line.Split('"')[1];
                name = FixName(originalName);
            }

            if (line.Contains("GUID first") && !string.IsNullOrEmpty(name))
            {
                var ints = new uint[4];
                for (var i = 0; i < 4; i++)
                {
                    var intLine = spriteDump.ReadLine();
                    var intString = intLine?.Split('=')[1].Trim();
                    ints[i] = uint.Parse(intString ?? "");
                }

                for (var i = 0; i < 3; i++)
                {
                    spriteDump.ReadLine();
                }

                var atlasLine = spriteDump.ReadLine();
                if (atlasLine?.Contains('1') == true)
                {
                    spriteDump.ReadLine();
                    var atlas = spriteDump.ReadLine()?.Split('"')[1];

                    guid = $"{atlas}[{originalName}]";
                    return true;
                }

                var spriteReference = ModContent.CreateSpriteReference(ints);

                guid = spriteReference.GetGUID();

                return true;
            }
        }

        return false;
    }

    private static string FixName(string name)
    {
        if (Regex.Match(name, @"^\d\d\d-").Success)
        {
            name = string.Concat(name.Split('-').Reverse());
        }

        if (name.Contains("#"))
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
}