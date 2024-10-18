using BTD_Mod_Helper.Api.Helpers;
namespace BTD_Mod_Helper.Api.Commands;

internal class OpenLocalFolderCommand : ModCommand<OpenFolderCommand>
{
    public override string Command => "local";
    public override string Help => "Opens the local folder / \"Sandbox Root\" where most things get exported";

    public override bool Execute(ref string resultText)
    {
        ProcessHelper.OpenFolder(FileIOHelper.sandboxRoot);
        return true;
    }
}