using BTD_Mod_Helper.Api.Helpers;
using CommandLine;
namespace BTD_Mod_Helper.Api.Commands.Export;

internal class ExportGameModelCommand : ModCommand<ExportCommand>
{
    public override string Command => "gamedata";
    public override string Help => "Exports most static game data to the sandbox root folder";

    [Option("clean", Default = false, HelpText = "remove any existing data from the folders")]
    public bool Clean { get; set; } = false;

    [Option("consistent", Default = false,
        HelpText = "changes the output slightly so that it will be consistent if reserialized")]
    public bool Consistent { get; set; } = false;

    public override bool Execute(ref string resultText)
    {
        GameModelExporter.clean = Clean;
        GameModelExporter.consistent = Consistent;
        GameModelExporter.ExportAll();

        return true;
    }
}