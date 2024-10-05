using BTD_Mod_Helper.Tests;
using Il2CppAssets.Scripts.Unity;
namespace BTD_Mod_Helper.Api.Commands;

#if DEBUG
internal class TestModelSerialization : ModCommand<TestCommand>
{
    public override string Command => "serialization";
    public override string Help => "Tests the ModelSerializer";

    public override bool Execute(ref string resultText)
    {
        return ModelSerializationTests.TestSerialization(Game.instance.model);
    }
}
#endif