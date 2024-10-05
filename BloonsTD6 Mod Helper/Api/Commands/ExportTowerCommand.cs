using System.IO;
using BTD_Mod_Helper.Api.Helpers;
using CommandLine;
using Il2CppAssets.Scripts.Models.Towers;
using Il2CppAssets.Scripts.Unity.UI_New.InGame;
using Il2CppAssets.Scripts.Unity.UI_New.InGame.TowerSelectionMenu;
using Il2CppNewtonsoft.Json;

namespace BTD_Mod_Helper.Api.Commands;

internal class ExportTowerCommand : ModCommand<ExportCommand>
{
    private const string Default = "selected_tower.json";

    public override string Command => "tower";

    public override string Help => "Exports the selected tower's model to a file";

    [Option('r', "root", Default = false, HelpText = "Exports the root tower model instead of the mutated one")]
    public bool Root { get; set; }

    [Value(0, Required = false, MetaName = "file/path", Default = Default, HelpText = "Name of exported file")]
    public string FilePath { get; set; }

    public override bool IsAvailable => InGame.instance != null;

    public override bool Execute(ref string resultText)
    {
        var tower = TowerSelectionMenu.instance.Exists()?.selectedTower?.tower;

        if (tower == null)
        {
            resultText = "No tower selected";
            return false;
        }

        var model = Root ? tower.rootModel.Cast<TowerModel>() : tower.towerModel;

        var path = Path.IsPathRooted(FilePath) ? FilePath : Path.Combine(FileIOHelper.sandboxRoot, FilePath ?? Default);
        if (!Path.HasExtension(path))
        {
            path = Path.ChangeExtension(path, ".json");
        }

        var text = JsonConvert.SerializeObject(model, FileIOHelper.Settings);

        File.WriteAllText(path, text);

        return true;
    }
}