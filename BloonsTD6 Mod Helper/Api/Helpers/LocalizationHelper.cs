using System;
using System.IO;
using System.Linq;
using Il2CppNinjaKiwi.Common;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using static System.IO.WatcherChangeTypes;
namespace BTD_Mod_Helper.Api.Helpers;

/// <summary>
/// Helps mods more easily support additional localization for their mod texts
/// </summary>
public class LocalizationHelper
{
    /// <summary>
    /// Where Mod Helper imports localizations from
    /// </summary>
    public static string LocalizationDirectory => Path.Combine(ModHelper.ModHelperDirectory, "Localization");

    internal static FileSystemWatcher watcher;

    internal static readonly string RestartRequired = ModHelper.Localize(nameof(RestartRequired), "Restart Required");

    private static Language? LastImportedLanguage;
    
    internal static void Initialize()
    {
        Directory.CreateDirectory(LocalizationDirectory);

        var supportedLanguages = LocalizationManager.Instance.SupportedLanguages;

        foreach (var language in Enum.GetValues<Language>())
        {
            if (supportedLanguages.Contains(language))
            {
                Directory.CreateDirectory(Path.Combine(LocalizationDirectory, language.ToString()));
            }
        }

        LocalizationManager.Instance.add_OnLanguageChanged(new Action(() =>
        {
            if (supportedLanguages.Contains(LocalizationManager.Instance.ActiveLanguage))
            {
                ModHelper.Msg($"Updating modded localization for {LocalizationManager.Instance.ActiveLanguage}");
                ImportLocalization(LocalizationManager.Instance.ActiveLanguage);
            }
        }));

        ImportLocalization(LocalizationManager.Instance.ActiveLanguage);

        watcher = new FileSystemWatcher(LocalizationDirectory, "*.json");
        watcher.IncludeSubdirectories = true;
        watcher.NotifyFilter = NotifyFilters.LastWrite;
        watcher.Changed += (_, args) =>
        {
            if (args.ChangeType.HasFlag(Changed))
            {
                TaskScheduler.ScheduleTask(() => ImportLocalization(new FileInfo(args.FullPath), true));
            }
        };
        watcher.EnableRaisingEvents = true;

    }

    internal static void ImportLocalization(Language language)
    {
        if (language == LastImportedLanguage) return;
        LastImportedLanguage = null;
        
        // Import from embeds
        foreach (var mod in ModHelper.Mods)
        {
            if (mod is MelonMain && !MelonMain.EnableModHelperLocalization) continue;
            
            var assembly = mod.GetAssembly();
            foreach (var resourceName in assembly.GetManifestResourceNames())
            {
                if (!resourceName.Contains($"Localization.{language.ToString()}") ||
                    !resourceName.EndsWith(".json")) continue;

                try
                {
                    using var stream = assembly.GetManifestResourceStream(resourceName)!;
                    using var reader = new StreamReader(stream);
                    var total = ImportLocalization(reader.ReadToEnd());
                    ModHelper.Msg($"Imported {total} {language.ToString()} localizations from {mod.GetModName()}");
                }
                catch (Exception e)
                {
                    ModHelper.Warning($"Failed to process embedded localization {resourceName}");
                    ModHelper.Warning(e);
                }
            }
        }

        // Import from files
        var folder = Path.Combine(LocalizationDirectory, language.ToString());
        foreach (var file in new DirectoryInfo(folder).EnumerateFiles("*.json", SearchOption.AllDirectories))
        {
            var total = ImportLocalization(file);
            var fileName = Path.GetRelativePath(LocalizationDirectory, file.FullName);
            ModHelper.Msg($"Imported {total} {language.ToString()} localizations from {fileName}");
        }

        LastImportedLanguage = language;
        LocalizationManager.Instance.UpdateAllTextObjectsForLanguageAsync(language);
    }

    internal static int ImportLocalization(FileInfo file, bool refresh = false)
    {
        if (!Enum.TryParse(file.Directory!.Name, out Language language) ||
            LocalizationManager.Instance.ActiveLanguage != language) return 0;

        try
        {
            var text = File.ReadAllText(file.FullName);
            var fileName = Path.GetRelativePath(LocalizationDirectory, file.FullName);
            var result = ImportLocalization(text);

            if (refresh)
            {
                ModHelper.Msg($"Updated localization from {fileName}");
                TaskScheduler.ScheduleTask(() =>
                    LocalizationManager.Instance.UpdateAllTextObjectsForLanguageAsync(language));
            }

            return result;
        }
        catch (Exception e)
        {
            ModHelper.Warning($"Failed to process localization {file.FullName}");
            ModHelper.Warning(e);
            return 0;
        }
    }

    internal static int ImportLocalization(string text)
    {
        var table = LocalizationManager.Instance.GetTextTable();
        var total = 0;
        var jToken = JToken.Parse(text);

        if (jToken is not JObject jobject)
        {
            ModHelper.Warning("Not a JSON Object!");
            return 0;
        }
        
        foreach (var (key, value) in jobject)
        {
            if (value is {Type: JTokenType.String})
            {
                table[key] = value.ToString();
                total++;
            }
        }

        return total;
    }

    internal static string ExportCurrentLocalization(BloonsMod mod)
    {
        var currentLanguage = LocalizationManager.Instance.ActiveLanguage.ToString();

        var resultFile = Path.Combine(LocalizationDirectory, currentLanguage, mod.GetModName() + ".json");

        var jObject = new JObject();

        foreach (var key in LocalizationManager.Instance.defaultTable.Keys()
                     .Concat(LocalizationManager.Instance.textTable.Keys())
                     .Where(key => key.StartsWith(mod.GetModName()))
                     .Distinct()
                     .OrderBy(key => !key.Contains(mod.IDPrefix + mod.GetModName())))
        {
            jObject[key] = LocalizationManager.Instance.GetText(key);
        }

        try
        {
            File.WriteAllText(resultFile, jObject.ToString(Formatting.Indented));
        }
        catch (Exception e)
        {
            ModHelper.Error(e);
        }

        return resultFile;
    }


    #region Common Vanilla Vocalizations

    /// <summary>
    /// "Yes"
    /// </summary>
    public const string Yes = "DataConsentYes";

    /// <summary>
    /// "No"
    /// </summary>
    public const string No = "DataConsentNo";

    /// <summary>
    /// "OK"
    /// </summary>
    public const string Ok = "OK";

    /// <summary>
    /// "Cancel"
    /// </summary>
    public const string Cancel = "Cancel";

    /// <summary>
    /// "Search..."
    /// </summary>
    public const string SearchText = "SearchText";

    /// <summary>
    /// "Warning"
    /// </summary>
    public const string Warning = "Warning";

    /// <summary>
    /// "Success!"
    /// </summary>
    public const string Success = "Back up Successful!";

    #endregion

}