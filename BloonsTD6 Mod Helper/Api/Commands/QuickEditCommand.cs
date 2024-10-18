using System;
using BTD_Mod_Helper.Api.Internal;
using CommandLine;
using Il2CppAssets.Scripts.Unity.UI_New.InGame;
using Il2CppAssets.Scripts.Unity.UI_New.InGame.TowerSelectionMenu;
namespace BTD_Mod_Helper.Api.Commands;

internal class QuickEditCommand : ModCommand
{
    public override string Command => "quickedit";

    public override string Help => "Edits the selected tower (must be in sandbox mode)";

    [Option('m', "mutated", Required = false, Default = false,
        HelpText = "Edits the mutated tower rather than the root tower")]
    public bool Mutated { get; set; }
    
    public override bool IsAvailable => InGame.instance != null && InGame.Bridge.IsSandboxMode();
    
    public override bool Execute(ref string resultText)
    {
        var tower = TowerSelectionMenu.instance.Exists()?.selectedTower?.tower;

        if (tower == null)
        {
            resultText = "No tower selected";
            return false;
        }

        try
        {
            var anyChanges = TowerEditing.QuickEdit(tower, Mutated);
            resultText = anyChanges ? "Successfully edited tower." : "No changes made.";
        }
        catch (Exception e)
        {
            ModHelper.Error(e);
            resultText = e.Message;
            return false;
        }

        return true;
    }
}