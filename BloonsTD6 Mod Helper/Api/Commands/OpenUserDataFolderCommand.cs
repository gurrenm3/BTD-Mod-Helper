using System.IO;
using BTD_Mod_Helper.Api.Helpers;
using CommandLine;
using Il2CppAssets.Scripts.Unity;
namespace BTD_Mod_Helper.Api.Commands;

internal class OpenUserDataFolderCommand : ModCommand<OpenFolderCommand>
{
    public override string Command => "userdata";
    public override string Help => "Opens the root user data folder. Profile data is nested beneath this.";

    public override bool Execute(ref string resultText)
    {
        ProcessHelper.OpenFolder(Game.instance.playerService.Configuration.PlayerDataRootPath);
        return true;
    }
}