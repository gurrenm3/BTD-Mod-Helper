using System;
using System.Diagnostics;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Threading.Tasks;
using Assets.Scripts.Unity.UI_New.Popups;
using BTD_Mod_Helper.Api.ModMenu;

namespace BTD_Mod_Helper.Api.Helpers
{
    /// <summary>
    /// Handles the creation of an empty mod in the Mod Sources folder
    /// </summary>
    public static class TemplateMod
    {
        private const string ZipURL = "https://github.com/doombubbles/btd6-template-mod/archive/refs/heads/main.zip";
        private static readonly string[] ValidExtensions = {".cs", ".csproj", ".sln", ".md", ".yml", ".yaml"};
        private const string ZipArchivePrefix = "btd6-template-mod-main/";


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
                PopupScreen.instance.ShowOkPopup(
                    $"Did not create mod template, directory \"{path}\" already exists.");
            }
            else if (File.Exists(csProjPath))
            {
                PopupScreen.instance.ShowPopup(PopupScreen.Placement.menuCenter, "Upgrade Project",
                    $"There was already a mod project found at {path}. " +
                    "Would you like to upgrade its .csproj?",
                    new Action(() => UpgradeProject(path, name, csProjPath)),
                    "Yes", null, "No", Popup.TransitionAnim.Scale);
            }
            else
            {
                CreateProject(path, name);
            }
        }

        private static async void CreateProject(string path, string name)
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

                directory.MoveTo(path);

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

        private static async void UpgradeProject(string path, string name, string csProjPath)
        {
            try
            {
                using var zipArchive = await ModHelperHttp.GetZip(ZipURL);

                if (zipArchive == null) throw new FileNotFoundException();

                FileMoveOverwrite(csProjPath, Path.Combine(ModHelper.ModHelperDirectory, $"{name}.csproj"));
                var csProj = zipArchive.GetEntry(ZipArchivePrefix + nameof(TemplateMod) + ".csproj");
                csProj.ExtractToFile(csProjPath);
                ReplaceFileText(csProjPath, name);


                var slnPath = Path.Combine(path, $"{name}.sln");
                if (File.Exists(slnPath))
                {
                    FileMoveOverwrite(slnPath, Path.Combine(ModHelper.ModHelperDirectory, $"{name}.sln"));
                    var sln = zipArchive.GetEntry(ZipArchivePrefix + nameof(TemplateMod) + ".sln");
                    sln.ExtractToFile(slnPath);
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
                    var modHelperData = zipArchive.GetEntry(ZipArchivePrefix + "ModHelperData.cs")!;
                    modHelperData.ExtractToFile(modHelperDataPath);
                    ReplaceFileText(modHelperDataPath, name);
                }

                zipArchive.GetEntry(ZipArchivePrefix + ".gitignore").ExtractToFile(Path.Combine(path, ".gitignore"), true);

                var propertiesPath = Path.Combine(path, "Properties");
                var launchSettingsPath = Path.Combine(propertiesPath, "launchSettings.json");
                if (!File.Exists(launchSettingsPath))
                {
                    Directory.CreateDirectory(propertiesPath);
                    var launchSettings = zipArchive.GetEntry(ZipArchivePrefix + "Properties/launchSettings.json");
                    launchSettings.ExtractToFile(launchSettingsPath);
                }

                var workflowsPath = Path.Combine(path, ".github", "workflows");
                var buildYmlPath = Path.Combine(workflowsPath, "build.yml");
                if (!Directory.Exists(propertiesPath) || !File.Exists(buildYmlPath))
                {
                    Directory.CreateDirectory(workflowsPath);
                    var buildYml = zipArchive.GetEntry(ZipArchivePrefix + ".github/workflows/build.yml");
                    buildYml.ExtractToFile(buildYmlPath);
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

        private static void SuccessPopup(string path, string name, string verb) =>
            TaskScheduler.ScheduleTask(() => PopupScreen.instance.ShowPopup(PopupScreen.Placement.menuCenter,
                $"{verb} {name}", $"Successfully {verb} mod at \"{path}\". Open in default IDE?",
                new Action(() => OpenProject(path, name)), "Yes", null, "No", Popup.TransitionAnim.Scale));


        private static void FailPopup() =>
            TaskScheduler.ScheduleTask(() =>
                PopupScreen.instance.ShowOkPopup("Something seems to have gone wrong. Check the console for details."));

        private static void ReplaceFileText(string file, string name)
        {
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

        private static void FileMoveOverwrite(string sourceFileName, string destFileName)
        {
            if (File.Exists(destFileName))
            {
                File.Delete(destFileName);
            }

            File.Move(sourceFileName, destFileName);
        }
    }
}