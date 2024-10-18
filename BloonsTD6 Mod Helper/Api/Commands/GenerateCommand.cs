namespace BTD_Mod_Helper.Api.Commands;

#if DEBUG
internal class GenerateCommand : ModCommand
{
    public override string Command => "generate";

    public override string Help => "Generates files for Mod Helper development";

    public override bool Execute(ref string resultText) => ExplainSubcommands(out resultText);
}
#endif