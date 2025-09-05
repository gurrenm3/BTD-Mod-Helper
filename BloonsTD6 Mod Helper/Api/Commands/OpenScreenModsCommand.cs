using BTD_Mod_Helper.UI.Menus;
namespace BTD_Mod_Helper.Api.Commands;

internal class OpenScreenModsCommand : ModCommand<OpenScreenCommand>
{
    public override string Command => "mods";

    public override string Help => "Opens the mods menu";

    public override bool Execute(ref string resultText)
    {
        var menu = GetInstance<ModsMenu>();
        if (menu.IsOpen)
        {
            resultText = "Screen already open";
            return false;
        }

        menu.Open();
        CloseConsole();
        return true;
    }
}