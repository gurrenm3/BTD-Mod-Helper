using BTD_Mod_Helper.Api.Helpers;
using MelonLoader.Utils;
namespace BTD_Mod_Helper.Api.Commands.Open;

internal class OpenModsFolderCommand : ModCommand<OpenFolderCommand>
{
    public override string Command => "mods";
    public override string Help => "Opens the MelonLoader mods folder";

    public override bool Execute(ref string resultText)
    {
        ProcessHelper.OpenFolder(MelonEnvironment.ModsDirectory);
        return true;
    }
}