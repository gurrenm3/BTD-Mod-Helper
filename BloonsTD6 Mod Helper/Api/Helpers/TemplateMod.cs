using System;
using System.Diagnostics;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Threading.Tasks;
using Assets.Scripts.Unity.UI_New.Popups;

namespace BTD_Mod_Helper.Api.Helpers;

/// <summary>
/// Handles the creation of an empty mod in the Mod Sources folder from the TemplateMod.zip embedded resource
/// </summary>
public static class TemplateMod
{
    private static readonly string[] ValidExtensions = {".cs", ".csproj", ".sln", ".md"};

    /// <summary>
    /// Creates an empty mod with the given name
    /// </summary>
    public static async void CreateEmptyMod(string name)
    {
        var path = Path.Combine(MelonMain.ModSourcesFolder, name);
        if (Directory.Exists(path))
        {
            PopupScreen.instance.ShowOkPopup(
                $"Did not create mod template, directory \"{path}\" already exists.");
            return;
        }

        await using var stream = ModHelper.Main.Assembly.GetEmbeddedResource("TemplateMod.zip")!;
        using var zipArchive = new ZipArchive(stream);
        zipArchive.ExtractToDirectory(path);
        await ReplaceInAllFiles(path, name);

        PopupScreen.instance.ShowPopup(PopupScreen.Placement.menuCenter, $"Created {name}",
            $"Successfully created empty mod at \"{path}\". Open in default IDE?",
            new Action(() => OpenProject(path, name)), "Yes", null, "No", Popup.TransitionAnim.Scale);
    }

    private static async Task ReplaceInAllFiles(string path, string name)
    {
        var files = Directory.EnumerateFiles(path);
        await Task.WhenAll(files
            .Where(file => ValidExtensions.Any(file.EndsWith))
            .Select(file =>
                Task.Run(async () =>
                {
                    var text = await File.ReadAllTextAsync(file);
                    File.Delete(file);
                    await File.WriteAllTextAsync(
                        file.Replace(nameof(TemplateMod), name),
                        text.Replace(nameof(TemplateMod), name)
                    );
                })
            ).ToArray()
        );
    }

    // TODO LINUX VERSION OF THIS
    private static void OpenProject(string path, string name)
    {
        using var fileOpener = new Process();
        fileOpener.StartInfo.FileName = "explorer";
        fileOpener.StartInfo.Arguments = $"{Path.Combine(path, $"{name}.sln")}";
        fileOpener.Start();
    }
}