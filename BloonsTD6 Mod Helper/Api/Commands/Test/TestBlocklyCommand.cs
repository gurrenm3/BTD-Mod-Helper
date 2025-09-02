namespace BTD_Mod_Helper.Api.Commands.Test;

#if DEBUG
internal class TestBlocklyCommand : ModCommand<TestCommand>
{
    public override string Command => "blockly";
    public override string Help => "Tests related to blockly";

    public override bool Execute(ref string resultText) => ExplainSubcommands(out resultText);
}
#endif