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

        if (MelonMain.SandboxQuickEditTower.JustPressed())
        {
            QuickEdit(tower);
        }

        /*if (MelonMain.SandboxExportTowerModel.JustPressed())
        {
            ExportTower(tower);
        }

        if (MelonMain.SandboxImportTowerModel.JustPressed())
        {
            ImportTower(tower);
        }*/
    }

    /*public static void ExportTower(Tower tower)
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

    public static void QuickEdit(Tower tower)
    {
        var model = tower.rootModel;

        if (Input.GetKey(KeyCode.LeftAlt))
        {
            model = tower.towerModel;
        }

        var text = ModelSerializer.SerializeModel(model);

        FileIOHelper.SaveFile(FileName, text);

        var path = Path.Combine(FileIOHelper.sandboxRoot, FileName);

        var linux = MelonUtils.IsUnderWineOrSteamProton();

        var command = linux ? "nano" : "notepad";

        if (!string.IsNullOrWhiteSpace(MelonMain.QuickEditProgram))
        {
            command = MelonMain.QuickEditProgram;
        }

        var process = Process.Start(new ProcessStartInfo
        {
            FileName = linux ? "sh" : "cmd.exe",
            Arguments = $"{(linux ? "-c" : "/C")} {command} \"{path}\"",
            CreateNoWindow = command == "nano",
            WindowStyle = command == "nano" ? ProcessWindowStyle.Normal : ProcessWindowStyle.Hidden,
            UseShellExecute = true,
        });

        if (process == null)
        {
            ModHelper.Warning("Failed to start process");
            return;
        }

        ModHelper.Msg($"Editing {model.name} at {path}. Game will resume once editor closes the file.");

        process.WaitForExit();

        var newText = FileIOHelper.LoadFile(FileName);

        File.Delete(path);

        if (newText == text)
        {
            ModHelper.Msg("No Edits Made");
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
    }
}