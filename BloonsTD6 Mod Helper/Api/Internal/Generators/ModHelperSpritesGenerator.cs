using System.IO;
using System.Text;
namespace BTD_Mod_Helper.Api.Internal.Generators;

internal sealed class ModHelperSpritesGenerator : ModSourceFileGenerator
{
    public override string[] OutputPath => ["Api", "Enums"];

    public override void Generate(StringBuilder sb)
    {
        var resources = Path.Combine(RootFolder, "Resources");

        sb.AppendLine(
            $$"""
              namespace {{Namespace}};

              /// <summary>
              /// Texture GUIDs for the couple sprites added by ModHelper
              /// </summary>
              public static class {{FileName}}
              {
              """);

        foreach (var image in Directory.GetFiles(resources, "*.png", SearchOption.AllDirectories))
        {
            var name = Path.GetFileNameWithoutExtension(image);
            var fileName = Path.GetFileName(image);
            var relative = Path.GetRelativePath(resources, image).Replace("\\", "/");

            sb.AppendLine();
            sb.AppendLine(
                $"""
                     /// <summary>
                     /// GUID for image <see href="https://github.com/{ModHelper.RepoOwner}/{ModHelper.RepoName}/blob/{ModHelper.Branch}/BloonsTD6%20Mod%20Helper/Resources/{relative}?raw=true">{fileName}</see>
                     /// </summary>
                     public const string {name} = "{GetTextureGUID<MelonMain>(name)}";
                 """);
        }

        sb.AppendLine();
        sb.Append('}');
    }
}