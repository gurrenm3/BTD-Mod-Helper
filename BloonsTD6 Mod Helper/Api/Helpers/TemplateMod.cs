using System;
using System.Diagnostics;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Threading.Tasks;
using Assets.Scripts.Unity.UI_New.Popups;

namespace BTD_Mod_Helper.Api.Helpers
{
    /// <summary>
    /// Handles the creation of an empty mod in the Mod Sources folder from the TemplateMod.zip embedded resource
    /// </summary>
    public static class TemplateMod
    {
        private static readonly string[] ValidExtensions = {".cs", ".csproj", ".sln", ".md"};

        /// <summary>
        /// Creates an empty mod with the given name
        /// </summary>
        public static void CreateModButtonClicked(string name)
        {
            var path = Path.Combine(MelonMain.ModSourcesFolder, name);
            var csProjPath = Path.Combine(path, $"{name}.csproj");
            if (Directory.Exists(path) && !File.Exists(csProjPath))
            {
                PopupScreen.instance.ShowOkPopup(
                    $"Did not create mod template, directory \"{path}\" already exists.");
            }
            else if (File.Exists(csProjPath))
            {
                PopupScreen.instance.ShowPopup(PopupScreen.Placement.menuCenter, "Upgrade Project",
                    $"There was already a mod project found at {path}. " +
                    "Would you like to upgrade its .csproj to net6?",
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
            using var stream = ModHelper.MainAssembly.GetEmbeddedResource($"{nameof(TemplateMod)}.zip");
            using var zipArchive = new ZipArchive(stream);
            zipArchive.ExtractToDirectory(path);
            await ReplaceInAllFiles(path, name);

            SuccessPopup(path, name, "Created");
        }

        private static void UpgradeProject(string path, string name, string csProjPath)
        {
            using var stream = ModHelper.MainAssembly.GetEmbeddedResource("TemplateMod.zip");
            using var zipArchive = new ZipArchive(stream);
            
            FileMoveOverwrite(csProjPath, csProjPath.Replace(".csproj", "_OLD.csproj"));
            var csProj = zipArchive.GetEntry($"{nameof(TemplateMod)}.csproj");
            csProj.ExtractToFile(csProjPath);
            ReplaceFileText(csProjPath, name);


            var slnPath = Path.Combine(path, $"{name}.sln");
            if (File.Exists(slnPath))
            {
                FileMoveOverwrite(slnPath, slnPath.Replace(".sln", "_OLD.sln"));
                var sln = zipArchive.GetEntry($"{nameof(TemplateMod)}.sln");
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
                var modHelperData = zipArchive.GetEntry("ModHelperData.cs")!;
                modHelperData.ExtractToFile(modHelperDataPath);
                ReplaceFileText(modHelperDataPath, name);
            }

            var gitIgnorePath = Path.Combine(path, ".gitignore");
            if (!File.Exists(gitIgnorePath))
            {
                zipArchive.GetEntry(".gitignore").ExtractToFile(gitIgnorePath);
            }

            SuccessPopup(path, name, "Upgraded");
        }

        private static void SuccessPopup(string path, string name, string verb) =>
            TaskScheduler.ScheduleTask(() => PopupScreen.instance.ShowPopup(PopupScreen.Placement.menuCenter,
                $"{verb} {name}", $"Successfully {verb} mod at \"{path}\". Open in default IDE?",
                new Action(() => OpenProject(path, name)), "Yes", null, "No", Popup.TransitionAnim.Scale));

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
            var files = Directory.EnumerateFiles(path);
            await Task.WhenAll(files
                .Where(file => Enumerable.Any(ValidExtensions, file.EndsWith))
                .Select(file => Task.Run( () => ReplaceFileText(file, name)))
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