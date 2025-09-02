#if DEBUG
using BTD_Mod_Helper.Api.Internal;
namespace BTD_Mod_Helper.Api.Commands.Generate;

internal class GenerateVanillaSpritesCommand : ModCommand<GenerateCommand>
{
    public override string Command => "sprites";
    public override string Help => "Generates the Mod Helper sprites list files";

    public override bool Execute(ref string resultText)
    {
        if (string.IsNullOrWhiteSpace(MelonMain.ModHelperSourceFolder))
        {
            resultText = "Mod Helper Source Folder has not been set";
            return false;
        }

        VanillaSpriteGenerator.GenerateVanillaSprites();
        ModHelperSpriteGenerator.GenerateModHelperSprites();

        return true;
    }
}
#endif