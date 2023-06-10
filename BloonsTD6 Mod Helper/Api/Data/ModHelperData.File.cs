using System;
using System.IO;
using System.Linq;
using Il2CppAssets.Scripts.Unity.UI_New.Popups;
using MelonLoader.Utils;
using UnityEngine;
namespace BTD_Mod_Helper.Api;

internal partial class ModHelperData
{
    /// <summary>
    /// The place that the .dll file for this mod is on the local machine, if any
    /// </summary>
    internal string FilePath { get; private set; }

    public void SetFilePath(string filePath)
    {
        FilePath = filePath;
        DllName = Path.GetFileName(filePath);
    }

    private bool MoveToFolder(string folderPath)
    {
        if (DllName != null && FilePath != null)
        {
            try
            {
                if (!Directory.Exists(folderPath)) Directory.CreateDirectory(folderPath);
                var newFilePath = Path.Combine(folderPath, DllName);
                if (File.Exists(newFilePath)) File.Delete(newFilePath);
                File.Move(FilePath, newFilePath);
                FilePath = newFilePath;
                return true;
            }
            catch (Exception e)
            {
                ModHelper.Warning($"Failed to move {FilePath} to {Path.GetDirectoryName(folderPath)} folder");
                ModHelper.Warning(e);
            }
        }

        return false;
    }

    public bool MoveToDisabledModsFolder(bool quick = false)
    {
        if (!MoveToFolder(ModHelper.DisabledModsDirectory)) return false;

        try
        {
            SaveToJson(ModHelper.DataDirectory);
            if (!quick && GetIcon() is Sprite sprite)
            {
                sprite.texture.TrySaveToPNG(Path.Combine(ModHelper.DataDirectory, DllName.Replace(".dll", ".png")));
            }

            return true;
        }
        catch (Exception e)
        {
            ModHelper.Warning($"Failed to move {FilePath} to disabled mods folder");
            ModHelper.Warning(e);
        }

        return false;
    }

    public bool MoveToEnabledModsFolder() => MoveToFolder(MelonEnvironment.ModsDirectory);

    public bool Delete()
    {
        if (Mod is not null || Enabled || FilePath == null || DllName == null)
        {
            ModHelper.Warning("Can't delete mod that isn't fully disabled and inactive");
            return false;
        }

        try
        {
            File.Delete(FilePath);

            var json = Path.Combine(ModHelper.DataDirectory, DllName.Replace(".dll", ".json"));
            if (File.Exists(json)) File.Delete(json);
            var png = Path.Combine(ModHelper.DataDirectory, DllName.Replace(".dll", ".png"));
            if (File.Exists(png)) File.Delete(png);

            Inactive.Remove(this);
            return true;
        }
        catch (Exception e)
        {
            ModHelper.Warning($"Failed to delete mod at {FilePath}");
            ModHelper.Warning(e);
        }

        return false;
    }

    public void WarningsFromDisabling(Action reEnable)
    {
        if (Mod is MelonMain)
        {
            PopupScreen.instance.SafelyQueue(screen => screen.ShowPopup(PopupScreen.Placement.menuCenter, "Warning",
                "Disabling Mod Helper will mean you will no longer see this mods menu. " +
                "You would have to manually re-enable this / any other mods by dragging their .dll files " +
                "out of the Disabled folder within your mods directory.", null, "Ok",
                reEnable, "Re-enable", Popup.TransitionAnim.Scale));
        }
        else
        {
            var dependents = FindDependents();

            if (dependents.Any())
            {
                PopupScreen.instance.SafelyQueue(screen => screen.ShowPopup(PopupScreen.Placement.menuCenter, "Warning",
                    $"The following enabled mods list this mod as a dependency, and may not function without it: {dependents.Select(data => data.DisplayName).Join()}",
                    null, "Ok",
                    reEnable,
                    "Re-enable", Popup.TransitionAnim.Scale));
            }
        }
    }
}