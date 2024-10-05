using System;
using System.Diagnostics;
using System.IO;
using BTD_Mod_Helper.Api.Helpers;
using Il2CppAssets.Scripts.Models.Towers;
using Il2CppAssets.Scripts.Simulation.Towers;
using Il2CppAssets.Scripts.Unity;
using Il2CppAssets.Scripts.Unity.UI_New.InGame;
using Il2CppAssets.Scripts.Unity.UI_New.InGame.TowerSelectionMenu;
using UnityEngine;


namespace BTD_Mod_Helper.Api.Internal;

internal static class TowerEditing
{
    private const string FileName = "quick_edit_tower.json";

    public static void OnUpdate()
    {
        if (TowerSelectionMenu.instance == null ||
            TowerSelectionMenu.instance.selectedTower == null ||
            InGame.Bridge?.IsSandboxMode() != true) return;

        var tower = TowerSelectionMenu.instance.selectedTower.tower;

        if (MelonMain.QuickEditTowerModel.JustPressed())
        {
            QuickEdit(tower);
        }
        
        if (MelonMain.QuickEditMutatedModel.JustPressed())
        {
            QuickEdit(tower, true);
        }

        /*if (MelonMain.SandboxExportTowerModel.JustPressed())
        {
            ExportCommand(tower);
        }

        if (MelonMain.SandboxImportTowerModel.JustPressed())
        {
            ImportTower(tower);
        }*/
    }

    /*public static void ExportCommand(Tower tower)
    {
        var model = tower.rootModel;

        var text = ModelSerializer.SerializeModel(model);

        ClipboardService.SetText(text);

        Game.instance.ShowMessage($"Copied model of {tower.towerModel.name} to clipboard");
    }

    public static void ImportTower(Tower tower)
    {
        var text = ClipboardService.GetText();

        try
        {
            var newModel = ModelSerializer.DeserializeModel<TowerModel>(text);

            tower.UpdateRootModel(newModel.Duplicate());

            Game.instance.ShowMessage($"Pasted model of {tower.towerModel.name}");
        }
        catch (Exception e)
        {
            ModHelper.Error(e);
        }
    }*/

    public static bool QuickEdit(Tower tower, bool editMutated = false)
    {
        var model = tower.rootModel;

        if (editMutated)
        {
            model = tower.towerModel;
        }

        var text = ModelSerializer.SerializeModel(model);

        var newText = Helpers.QuickEdit.EditText(text, FileName);

        if (newText == text)
        {
            ModHelper.Msg("No Edits Made");
            return false;
        }

        var newModel = ModelSerializer.DeserializeModel<TowerModel>(newText);
        if (newModel == null)
        {
            ModHelper.Error("JSON was not valid");
        }
        else
        {
            tower.UpdateRootModel(newModel.Duplicate());
        }

        return true;
    }
}