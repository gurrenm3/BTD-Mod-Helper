#if BLOCKLY
using System.IO;
using BTD_Mod_Helper.Api.Internal;
using Il2CppAssets.Scripts.Unity.UI_New.InGame;

namespace BTD_Mod_Helper.Api.Commands.Generate;

internal class GenerateBlocklyCommand : ModCommand<GenerateCommand>
{
    public override string Command => "blockly";

    public override string Help => "Generates the Blockly editor blocks. " +
                                   "NOTE: Run this after having already gone into a game with Monkey Knowledge on!";

    public override bool IsAvailable => InGame.instance != null && InGameData.CurrentGame.dcModel?.disableMK != true;

    public override bool Execute(ref string resultText)
    {
        var folder = Path.Combine(MelonMain.ModHelperSourceFolder, "Website", "src", "data");
        BlocklyGenerator.Generate(folder);

        return true;
    }
}
#endif