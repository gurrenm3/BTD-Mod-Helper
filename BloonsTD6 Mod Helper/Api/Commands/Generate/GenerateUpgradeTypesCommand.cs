#if DEBUG
using BTD_Mod_Helper.Api.Internal;
namespace BTD_Mod_Helper.Api.Commands.Generate;

internal class GenerateUpgradeTypesCommand : ModCommand<GenerateCommand>
{
    public override string Command => "upgrades";
    public override string Help => "Generates the Mod Helper UpgradeTypes.cs file";

    public override bool Execute(ref string resultText)
    {
        if (string.IsNullOrWhiteSpace(MelonMain.ModHelperSourceFolder))
        {
            resultText = "Mod Helper Source Folder has not been set";
            return false;
        }

        UpgradeTypeGenerator.GenerateVanillaUpgradeTypes();

        return true;
    }
}
#endif