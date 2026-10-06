using System.Collections;
using BTD_Mod_Helper.Api.Helpers;
using CommandLine;
namespace BTD_Mod_Helper.Api.Commands.Export;

internal class ExportGameDataCommand : ModCommand<ExportCommand>
{
    public override string Command => "gamedata";
    public override string Help => "Exports most static game data to the sandbox root folder";

    [Option("clean", Default = false, HelpText = "remove any existing data from the folders")]
    public bool Clean { get; set; } = false;

    [Option("consistent", HelpText = "changes the output slightly so that it will be consistent if reserialized"
#if DEBUG
        , Default = true
#endif
    )]
    public bool Consistent { get; set; }

    public override IEnumerator Execute(Output output)
    {
        GameModelExporter.clean = Clean;
        GameModelExporter.consistent = Consistent;
        yield return GameModelExporter.ExportAll();
        output.success = !GameModelExporter.HadErrors;
        if (!output.success) output.resultText = "Game data export failed; see the logged file errors.";
    }
}
