using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using BTD_Mod_Helper.Extensions;
using MelonLoader;

namespace BTD_Mod_Helper.Api.Helpers
{
    internal class VanillaSpriteGenerator
    {
        private const string Tab = "    ";

        internal static readonly HashSet<string> Names = new HashSet<string>();

        /// <summary>
        /// Generate the VanillaSprites.cs file
        /// <br/>
        /// To get the necessary files, open "...\BloonsTD6\BloonsTD6_Data\StreamingAssets\aa\StandaloneWindows64\Full\asset_references_assets_all_[...].bundle"
        /// in Asset Studio. Then, select all assets of type Sprite, and in the menu do Export -> Dump -> Selected assets
        /// </summary>
        internal static void GenerateVanillaSprites(string vanillaSpritesCs, string folder)
        {
            if (!Directory.Exists(folder))
            {
                MelonLogger.Error($"No directory {folder}");
                return;
            }

            var files = Directory.GetFiles(folder);

            using (var vanillaSpritesFile = new StreamWriter(vanillaSpritesCs))
            {
                vanillaSpritesFile.WriteLine("using Assets.Scripts.Utils;");
                vanillaSpritesFile.WriteLine("");
                vanillaSpritesFile.WriteLine("#pragma warning disable CS1591");
                vanillaSpritesFile.WriteLine("namespace BTD_Mod_Helper.Api.Enums");
                vanillaSpritesFile.WriteLine("{");
                vanillaSpritesFile.WriteLine($"{Tab}public static class VanillaSprites");
                vanillaSpritesFile.WriteLine($"{Tab}{{");

                foreach (var file in files)
                {
                    vanillaSpritesFile.WriteLine(GetLine(file));
                }

                vanillaSpritesFile.WriteLine($"{Tab}}}");
                vanillaSpritesFile.WriteLine("}");
            }
        }

        internal static string GetLine(string file)
        {
            string name = null;
            using (var spriteDump = new StreamReader(file))
            {
                while (spriteDump.ReadLine() is string line)
                {
                    if (line.Contains("string m_Name"))
                    {
                        name = FixName(line.Split('"')[1]);
                    }

                    if (line.Contains("GUID first"))
                    {
                        var ints = new uint[4];
                        for (var i = 0; i < 4; i++)
                        {
                            var intLine = spriteDump.ReadLine();
                            var intString = intLine.Split('=')[1].Trim();
                            ints[i] = uint.Parse(intString);
                        }

                        var spriteReference = ModContent.CreateSpriteReference(ints);

                        return
                            $"{Tab}{Tab}public static SpriteReference {name} => ModContent.CreateSpriteReference(\"{spriteReference.GetGUID()}\");";
                    }
                }
            }

            return $"{Tab}{Tab}// Failed to find GUID for {name ?? file}";
        }

        internal static string FixName(string name)
        {
            if (Regex.Match(name, @"^\d\d\d-").Success)
            {
                name = string.Concat(name.Split('-').Reverse());
            }

            if (name.Contains("#"))
            {
                name = string.Concat(name.Split('#')[0].Trim());
            }

            name = Regex.Replace(name, @"[^A-Za-z0-9_]", "");

            if (!Names.Contains(name))
            {
                Names.Add(name);
            }
            else
            {
                var i = 2;
                while (Names.Contains(name + i))
                {
                    i++;
                }

                name += i;
                Names.Add(name);
            }

            return name;
        }
    }
}