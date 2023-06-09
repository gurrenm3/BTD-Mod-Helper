using System;
using System.Diagnostics;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Threading.Tasks;
using BTD_Mod_Helper.Api.ModMenu;
using Il2CppAssets.Scripts.Unity.UI_New.Popups;
using Microsoft.VisualBasic.FileIO;
using SearchOption = System.IO.SearchOption;
namespace BTD_Mod_Helper.Api.Helpers;

/// <summary>
/// Handles the creation of an empty mod in the Mod Sources folder
/// </summary>
public static class TemplateMod
{
    private const string ZipURL = "https://github.com/doombubbles/btd6-template-mod/archive/refs/heads/main.zip";
    private const string ZipArchivePrefix = "btd6-template-mod-main/";
    private static readonly string[] ValidExtensions = {".cs", ".csproj", ".sln", ".md", ".yml", ".yaml"};


    /// <summary>
    /// Creates an empty mod with the given name
    /// </summary>
    public static void CreateModButtonClicked(string name)
    {
        var path = Path.Combine(MelonMain.ModSourcesFolder, name);
        var csProjPath = Path.Combine(path, $"{name}.csproj");
        if (Directory.Exists(path) &&
            Directory.EnumerateFiles(path, "*.*", SearchOption.AllDirectories).Any() &&
            !File.Exists(csProjPath))
        {
            PopupScreen.instance.SafelyQueue(screen =>
                screen.ShowOkPopup($"Did not create mod template, directory \"{path}\" already exists."));
        }
        else if (File.Exists(csProjPath))
        {
            PopupScreen.instance.SafelyQueue(screen => screen.ShowPopup(PopupScreen.Placement.menuCenter,
                "Upgrade Project",
                $"There was already a mod project found at {path}. " +
                "Would you like to upgrade its .csproj?",
                new Action(() => UpgradeProject(path, name, csProjPath)),
                "Yes", null, "No", Popup.TransitionAnim.Scale));
        }
        else
        {
            CreateProject(path, name);
        }
    }

    private static async Task CreateProject(string path, string name)
    {
        var result = await ModHelperHttp.DownloadZip(ZipURL);
        if (result == null)
        {
            FailPopup();
            return;
        }

        ModHelper.Msg($"Successfully downloaded template from {ZipURL}");

        try
        {
            var directory = result.EnumerateDirectories().First();

            if (Directory.Exists(path))
            {
                Directory.Delete(path);
            }

            try
            {
                directory.MoveTo(path);
            }
            catch (IOException e)
            {
                if (e.Message.Contains("across volumes"))
                {
                    FileSystem.CopyDirectory(directory.FullName, path, true);
                    directory.Delete(true);
                }
                else throw;
            }

            await ReplaceInAllFiles(path, name);
        }
        catch (Exception e)
        {
            ModHelper.Warning(e);
            FailPopup();
            return;
        }

        SuccessPopup(path, name, "Created");
    }

    private static async Task UpgradeProject(string path, string name, string csProjPath)
    {
        try
        {
            using var zipArchive = await ModHelperHttp.GetZip(ZipURL);

            if (zipArchive == null) throw new FileNotFoundException();

            Directory.CreateDirectory(ModHelper.ReplacedFilesDirectory);

            File.Move(csProjPath, Path.Combine(ModHelper.ReplacedFilesDirectory, $"{name}.csproj"), true);
            var csProj = zipArchive.GetEntry(ZipArchivePrefix + nameof(TemplateMod) + ".csproj")!;
            csProj.ExtractToFile(csProjPath);
            ReplaceFileText(csProjPath, name);


            var slnPath = Path.Combine(path, $"{name}.sln");
            if (File.Exists(slnPath))
            {
                File.Move(slnPath, Path.Combine(ModHelper.ReplacedFilesDirectory, $"{name}.sln"), true);
                var sln = zipArchive.GetEntry(ZipArchivePrefix + nameof(TemplateMod) + ".sln");
                sln?.ExtractToFile(slnPath);
                ReplaceFileText(slnPath, name);
            }

            var properties = Path.Combine(path, "Properties");
            if (Directory.Exists(properties))
            {
                Directory.Delete(properties, true);
            }

            var modHelperDataPath = Path.Combine(path, "ModHelperData.cs");
            if (!File.Exists(modHelperDataPath))
            {
                var modHelperData = zipArchive.GetEntry(ZipArchivePrefix + "ModHelperData.cs");
                modHelperData?.ExtractToFile(modHelperDataPath);
                ReplaceFileText(modHelperDataPath, name);
            }

            zipArchive.GetEntry(ZipArchivePrefix + ".gitignore")
                ?.ExtractToFile(Path.Combine(path, ".gitignore"), true);

            var propertiesPath = Path.Combine(path, "Properties");
            var launchSettingsPath = Path.Combine(propertiesPath, "launchSettings.json");
            if (!File.Exists(launchSettingsPath))
            {
                Directory.CreateDirectory(propertiesPath);
                var launchSettings = zipArchive.GetEntry(ZipArchivePrefix + "Properties/launchSettings.json");
                launchSettings?.ExtractToFile(launchSettingsPath);
            }

            var workflowsPath = Path.Combine(path, ".github", "workflows");
            var buildYmlPath = Path.Combine(workflowsPath, "build.yml");
            if (!Directory.Exists(propertiesPath) || !File.Exists(buildYmlPath))
            {
                Directory.CreateDirectory(workflowsPath);
                var buildYml = zipArchive.GetEntry(ZipArchivePrefix + ".github/workflows/build.yml");
                buildYml?.ExtractToFile(buildYmlPath);
                ReplaceFileText(buildYmlPath, name);
            }

            SuccessPopup(path, name, "Upgraded");
        }
        catch (Exception e)
        {
            ModHelper.Warning(e);
            FailPopup();
        }
    }

    private static void SuccessPopup(string path, string name, string verb)
    {
        PopupScreen.instance.SafelyQueue(screen => screen.ShowPopup(PopupScreen.Placement.menuCenter,
            $"{verb} {name}", $"Successfully {verb} mod at \"{path}\". Open in default IDE?",
            new Action(() => OpenProject(path, name)), "Yes", null, "No", Popup.TransitionAnim.Scale));
    }


    private static void FailPopup()
    {
        PopupScreen.instance.SafelyQueue(screen =>
            screen.ShowOkPopup("Something seems to have gone wrong. Check the console for details."));
    }

    private static void ReplaceFileText(string file, string name)
    {
        if (!File.Exists(file)) return;

        var text = File.ReadAllText(file);
        File.Delete(file);
        File.WriteAllText(
            file.Replace(nameof(TemplateMod), name),
            text.Replace(nameof(TemplateMod), name)
        );
    }

    private static async Task ReplaceInAllFiles(string path, string name)
    {
        var files = Directory.EnumerateFiles(path, "*.*", SearchOption.AllDirectories);
        await Task.WhenAll(files
            .Where(file => Enumerable.Any(ValidExtensions, file.EndsWith))
            .Select(file => Task.Run(() => ReplaceFileText(file, name)))
            .ToArray()
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