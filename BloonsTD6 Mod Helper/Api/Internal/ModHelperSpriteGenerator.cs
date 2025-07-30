using System.IO;

namespace BTD_Mod_Helper.Api.Internal;

internal class ModHelperSpriteGenerator
{
    internal static void GenerateModHelperSprites()
    {
        var modHelper = Path.Combine(MelonMain.ModHelperSourceFolder, "BloonsTD6 Mod Helper");
        var spritesCs = Path.Combine(modHelper, "Api", "Enums", "ModHelperSprites.cs");
        var resources = Path.Combine(modHelper, "Resources");

        using var file = new StreamWriter(spritesCs);

        file.WriteLine(
            """
            namespace BTD_Mod_Helper.Api.Enums;

            /// <summary>
            /// Texture GUIDs for the couple sprites added by ModHelper
            /// </summary>
            public static class ModHelperSprites
            {
            """
        );

        foreach (var image in Directory.GetFiles(resources, "*.png", SearchOption.AllDirectories))
        {
            var name = Path.GetFileNameWithoutExtension(image);
            var fileName = Path.GetFileName(image);
            var path = Path.GetRelativePath(resources, image).Replace("\\", "/");

            file.WriteLine(
                $"""

                     /// <summary>
                     /// GUID for image <see href="https://github.com/{ModHelper.RepoOwner}/{ModHelper.RepoName}/blob/{ModHelper.Branch}/BloonsTD6%20Mod%20Helper/Resources/{path}?raw=true">{fileName}</see>
                     /// </summary>
                     public const string {name} = "{ModContent.GetTextureGUID<MelonMain>(name)}";
                 """
            );
        }

        file.WriteLine(
            """

            }
            """
        );


    }
}