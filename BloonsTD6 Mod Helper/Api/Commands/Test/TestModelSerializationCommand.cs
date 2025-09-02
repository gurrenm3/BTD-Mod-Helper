using BTD_Mod_Helper.Tests;
using Il2CppAssets.Scripts.Unity;
namespace BTD_Mod_Helper.Api.Commands.Test;

#if DEBUG
internal class TestModelSerializationCommand : ModCommand<TestCommand>
{
    public override string Command => "serialization";
    public override string Help => "Tests the ModelSerializer";

    public override bool Execute(ref string resultText)
    {
        ModelSerializationTests.TestTowerSerialization(Game.instance.model);
        return true;
    }
}
#endif