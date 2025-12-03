using BTD_Mod_Helper.Api.Internal;
namespace BTD_Mod_Helper.Api.Commands.Generate;

internal class GenerateModelCreatesCommand : ModCommand<GenerateCommand>
{
    public override string Command => "creates";

    public override string Help => "Generates the model create extensions";

    public override bool Execute(ref string resultText)
    {
        CreateModelExtGenerator.Generate();
        return true;
    }
}