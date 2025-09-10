#if DEBUG
using BTD_Mod_Helper.Tests;
namespace BTD_Mod_Helper.Api.Commands.Test.Blockly;

internal class TestBlocklyAllCommand : ModCommand<TestBlocklyCommand>
{
    public override string Command => "all";

    public override string Help => "Test all blockly";

    public override bool Execute(ref string resultText)
    {
        BlocklyTests.TestAll();
        return true;
    }
}
#endif