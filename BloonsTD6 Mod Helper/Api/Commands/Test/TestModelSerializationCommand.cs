using BTD_Mod_Helper.Tests;
using CommandLine;
using Il2CppAssets.Scripts.Unity;
using Il2CppAssets.Scripts.Unity.UI_New.InGame;
namespace BTD_Mod_Helper.Api.Commands.Test;

#if DEBUG
internal class TestModelSerializationCommand : ModCommand<TestCommand>
{
    public override string Command => "serialization";
    public override string Help => "Tests the ModelSerializer";

    [Value(0, Required = false, Default = null, HelpText = "Tower")]
    public static string Tower { get; set; } = null;

    public override bool Execute(ref string resultText)
    {
        var gameModel = InGame.instance == null ? Game.instance.model : InGame.Bridge.Model;
        if (Tower == null)
        {
            return ModelSerializationTests.TestTowerSerialization(gameModel);
        }

        var tower = gameModel.GetTowerFromId(Tower);
        return ModelSerializationTests.TestSerialization(tower);
    }
}
#endif