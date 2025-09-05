using BTD_Mod_Helper.UI.Menus;
namespace BTD_Mod_Helper.Api.Commands;

internal class OpenScreenBrowserCommand : ModCommand<OpenScreenCommand>
{
    public override string Command => "browser";

    public override string Help => "Opens the mod browser";

    public override bool Execute(ref string resultText)
    {
        var menu = GetInstance<ModBrowserMenu>();
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