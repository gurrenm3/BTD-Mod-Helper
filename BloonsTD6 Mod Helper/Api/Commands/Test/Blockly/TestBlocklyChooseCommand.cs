using BTD_Mod_Helper.Tests;
namespace BTD_Mod_Helper.Api.Commands.Test.Blockly;

internal class TestBlocklyChooseCommand : ModCommand<TestBlocklyCommand>
{
    public override string Command => "choose";

    public override string Help => "Test blockly choose";

    public override bool Execute(ref string resultText)
    {
        BlocklyTests.TestChoose();
        return true;
    }
}