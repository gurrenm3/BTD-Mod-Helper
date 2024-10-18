using BTD_Mod_Helper.Api.Internal;
namespace BTD_Mod_Helper.Api.Commands;

#if DEBUG
internal class GenerateVanillaSpritesCommand : ModCommand<GenerateCommand>
{
    public override string Command => "sprites";
    public override string Help => "Generates the Mod Helper VanillaSprites.cs file";

    public override bool Execute(ref string resultText)
    {
        if (string.IsNullOrWhiteSpace(MelonMain.ModHelperSourceFolder))
        {
            resultText = "Mod Helper Source Folder has not been set";
            return false;
        }
        
        VanillaSpriteGenerator.GenerateVanillaSprites();

        return true;
    }
}
#endif