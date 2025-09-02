using BTD_Mod_Helper.Api.Helpers;
using CommandLine;
namespace BTD_Mod_Helper.Api.Commands.Export;

internal class ExportGameModelCommand : ModCommand<ExportCommand>
{
    public override string Command => "gamedata";
    public override string Help => "Exports most static game data to the sandbox root folder";

    [Option('c', "clean", Default = false, HelpText = "remove any existing data from the folders")]
    public bool Clean { get; set; } = false;

    public override bool Execute(ref string resultText)
    {
        GameModelExporter.ExportAll(Clean);

        return true;
    }
}