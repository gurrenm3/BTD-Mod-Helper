using System.IO;
using BTD_Mod_Helper.Api.Helpers;
using Il2CppAssets.Scripts.Unity;

namespace BTD_Mod_Helper.Api.Commands;

internal class OpenProfileFolderCommand : ModCommand<OpenFolderCommand>
{
    public override string Command => "profile";
    public override string Help => "Opens the folder where profile data is stored";
    
    public override bool Execute(ref string resultText)
    {
        if(Game.Player.dataFile.file.TryGetLocalFilePath(out var path))
        ProcessHelper.OpenFolder(Path.GetDirectoryName(path));
        return true;
    }
}