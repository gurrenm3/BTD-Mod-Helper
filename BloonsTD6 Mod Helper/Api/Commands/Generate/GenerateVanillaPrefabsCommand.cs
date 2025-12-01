#if DEBUG
using BTD_Mod_Helper.Api.Internal;
namespace BTD_Mod_Helper.Api.Commands.Generate;

internal class GenerateVanillaPrefabsCommand : ModCommand<GenerateCommand>
{
    public override string Command => "prefabs";
    public override string Help => "Generates the Mod Helper vanilla prefabs list files";

    public override bool Execute(ref string resultText)
    {
        if (string.IsNullOrWhiteSpace(MelonMain.ModHelperSourceFolder))
        {
            resultText = "Mod Helper Source Folder has not been set";
            return false;
        }

        VanillaPrefabsGenerator.GenereateVanillaPrefabs();

        return true;
    }
}
#endif