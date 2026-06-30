using System;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Threading.Tasks;
using BTD_Mod_Helper.Api.Helpers;
using Il2CppAssets.Scripts.Unity.UI_New.Popups;
using SearchOption = System.IO.SearchOption;
#if !RELEASELITE
using BTD_Mod_Helper.Api.ModMenu;
#endif

#pragma warning disable CS4014
namespace BTD_Mod_Helper.Api.Internal;

/// <summary>
/// Handles the creation of an empty mod in the Mod Sources folder
/// </summary>
internal static class TemplateMod
{
    private const string ZipArchiveName = "btd6-template-mod-main";
    private const string ZipArchivePrefix = ZipArchiveName + "/";
    private static readonly string[] ValidExtensions = [".cs", ".csproj", ".sln", ".md", ".yml", ".yaml", ".toml"];

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

    private static Task<ZipArchive> GetTemplateZip()
    {
#if RELEASELITE
        const string zipFileName = ZipArchiveName + ".zip";
        var stream = ModHelper.MainAssembly.GetEmbeddedResource(zipFileName);
        return stream == null
            ? throw new FileNotFoundException("Could not find embedded template zip resource.", zipFileName)
            : Task.FromResult(new ZipArchive(stream));
#else
        const string zipURL = "https://github.com/doombubbles/btd6-template-mod/archive/refs/heads/main.zip";
        return ModHelperHttp.GetZip(zipURL);
#endif
    }

    private static async Task CreateProject(string path, string name)
    {
        try
        {
            using var zipArchive = await GetTemplateZip();

            if (zipArchive == null) throw new FileNotFoundException();

            if (Directory.Exists(path))
            {
                Directory.Delete(path);
            }

            Directory.CreateDirectory(path);
            var destinationRoot = Path.GetFullPath(path + Path.DirectorySeparatorChar);

            foreach (var entry in zipArchive.Entries)
            {
                if (!entry.FullName.StartsWith(ZipArchivePrefix) || string.IsNullOrEmpty(entry.Name))
                {
                    continue;
                }

                var relativePath = entry.FullName[ZipArchivePrefix.Length..];
                var destination = Path.GetFullPath(Path.Combine(path, relativePath));
                if (!destination.StartsWith(destinationRoot, StringComparison.OrdinalIgnoreCase))
                {
                    throw new IOException($"Zip entry would extract outside the target directory: {entry.FullName}");
                }

                Directory.CreateDirectory(Path.GetDirectoryName(destination)!);
                entry.ExtractToFile(destination, true);
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
            using var zipArchive = await GetTemplateZip();

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
        var newFile = file.Replace(nameof(TemplateMod), name);
        var newText = text.Replace(nameof(TemplateMod), name);

        if (file != newFile || text != newText)
        {
            File.Delete(file);
            File.WriteAllText(newFile, newText);
        }
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

    private static void OpenProject(string path, string name)
    {
        var slnPath = Path.Combine(path, $"{name}.sln");
        if (File.Exists(slnPath))
        {
            ProcessHelper.OpenFile(slnPath);
        }
        else
        {
            ProcessHelper.OpenFolder(path);
        }
    }
}