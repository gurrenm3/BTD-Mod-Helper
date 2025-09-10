#if DEBUG
using System.Linq;
namespace BTD_Mod_Helper.Api.Commands;

internal class GenerateAllCommand : ModCommand<GenerateCommand>
{
    public override string Command => "all";

    public override string Help => "Runs all generate commands added by Mod Helper";

    public override bool Execute(ref string resultText)
    {
        foreach (var command in GetContent<ModCommand>()
                     .Where(command => command.ParentCommand is GenerateCommand && command != this && command.mod == mod))
        {
            command.Execute(ref resultText);
        }

        return true;
    }
}
#endif