using Il2CppAssets.Scripts.Unity.UI_New.InGame;
namespace BTD_Mod_Helper.Api.Commands;

internal class MouseCommand : ModCommand
{
    public override string Command => "mouse";

    public override string Help => "Print mouse pos";

    public override bool Execute(ref string resultText)
    {
        var inputManager = InGame.instance.InputManager;

        var height = inputManager.Bridge.Simulation.Map.GetTerrainHeight(new(inputManager.CursorPositionWorld));

        resultText = $"{inputManager.CursorPositionWorld} height {height}";

        ModHelper.Msg(resultText);

        return true;
    }
}