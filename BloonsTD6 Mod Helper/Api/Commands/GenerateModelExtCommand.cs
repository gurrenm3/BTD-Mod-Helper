using BTD_Mod_Helper.Api.Internal;
#if DEBUG
namespace BTD_Mod_Helper.Api.Commands;

internal class GenerateModelExtCommand : ModCommand<GenerateCommand>
{
    public override string Command => "ext";

    public override string Help => "Generates many ModelExt files";

    public override bool Execute(ref string resultText)
    {
        if (string.IsNullOrWhiteSpace(MelonMain.ModHelperSourceFolder))
        {
            resultText = "Mod Helper Source Folder has not been set";
            return false;
        }

        ModelExtGenerator.GenerateAll();

        return true;
    }
}

#endif