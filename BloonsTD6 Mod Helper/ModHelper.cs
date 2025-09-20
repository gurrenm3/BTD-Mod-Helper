using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using BTD_Mod_Helper.Api;
using BTD_Mod_Helper.Api.Data;
using BTD_Mod_Helper.Api.Helpers;
using BTD_Mod_Helper.Api.Internal;
using MelonLoader.InternalUtils;
using MelonLoader.Utils;
using Directory = System.IO.Directory;
using Path = System.IO.Path;

// ReSharper disable UnusedMember.Global

namespace BTD_Mod_Helper;

/// <summary>
/// Catch-all class for non-extension static methods and accessors, as well as the ModHelperData for this mod
/// </summary>
public static class ModHelper
{
    internal const string WorksOnVersion = "50.2";
    internal const string Name = "BloonsTD6 Mod Helper";
    internal const string Version = "3.4.12";
    internal const string RepoOwner = "gurrenm3";
    internal const string RepoName = "BTD-Mod-Helper";
    internal const string Description =
        "A powerful and easy to use API for modding BTD6. Also the mod that is allowing all of this UI to happen right now :P";
    internal const string DllName = "Btd6ModHelper.dll";
    internal const string XmlName = "Btd6ModHelper.xml";
    internal const string Author = "Gurrenm4 and Doombubbles";
    internal const string Branch = "master";
    internal const string UpdaterVersion = "1.0.3";

    private static bool fallBackToOldLoading = true;

    /// <summary>
    /// The current installed version of Mod Helper
    /// </summary>
    public static string InstalledVersion => Version;

    /// <summary>
    /// The version of Mod Helper that this mod was compiled with
    /// </summary>
    public const string CompiledVersion = Version;

    private static IEnumerable<BloonsMod> mods;

    /// <summary>
    /// Directory where Mod Helper stores most of its extra info
    /// </summary>
    public static string ModHelperDirectory => Directory.Exists(PreviousModHelperDirectory)
        ? PreviousModHelperDirectory
        : NewModHelperDirectory;

    internal static string NewModHelperDirectory =>
        Path.Combine(MelonEnvironment.GameRootDirectory, DllName.Replace(".dll", ""));

    internal static string PreviousModHelperDirectory =>
        Path.Combine(MelonEnvironment.ModsDirectory, Assembly.GetExecutingAssembly().GetName().Name!);

    /// <summary>
    /// Directory where disabled mods are stored
    /// </summary>
    public static string DisabledModsDirectory => Directory.Exists(PreviousDisabledModsDirectory)
        ? PreviousDisabledModsDirectory
        : NewDisabledModDirectory;

    internal static string PreviousDisabledModsDirectory => Path.Combine(MelonEnvironment.ModsDirectory, "Disabled");
    internal static string NewDisabledModDirectory => Path.Combine(MelonEnvironment.GameRootDirectory, "Disabled Mods");

    internal static string ZipTempDirectory => Path.Combine(ModHelperDirectory, "Zip Temp");
    internal static string OldModsDirectory => Path.Combine(ModHelperDirectory, "Old Mods");
    internal static string DataDirectory => Path.Combine(ModHelperDirectory, "Data");
    internal static string ModSettingsDirectory => Path.Combine(ModHelperDirectory, "Mod Settings");
    internal static string ReplacedFilesDirectory => Path.Combine(ModHelperDirectory, "Replaced");

    /// <summary>
    /// The directory path on the user's system that's set as their Mod Sources folder
    /// </summary>
    public static string ModSourcesDirectory => MelonMain.ModSourcesFolder;

    /// <summary>
    /// Gets whether this is running on net6 MelonLoader
    /// </summary>
    public static bool IsNet6 => Environment.Version.Major >= 6;

    /// <summary>
    /// Gets whether the game is running as the Epic Store version
    /// </summary>
    public static bool IsEpic => UnityInformationHandler.GameName == EpicCompatibility.GameName;

    internal static bool FallbackToOldLoading
    {
        set => fallBackToOldLoading = value;
        get => fallBackToOldLoading /*|| MelonMain.UseOldLoading*/;
    }

    internal static string MyGithubUsername => MelonMain.GitHubUsername;

    /// <summary>
    /// Active mods that use ModHelper functionality
    /// </summary>
    public static IEnumerable<BloonsMod> Mods =>
        mods ??= Melons.OfType<BloonsMod>().OrderBy(mod => mod.Priority);

    /// <summary>
    /// All active mods, whether they're Mod Helper or not
    /// </summary>
    public static IEnumerable<MelonMod> Melons => MelonBase.RegisteredMelons.OfType<MelonMod>();

    /// <summary>
    /// ModHelper's BloonsTD6 mod class
    /// </summary>
    public static BloonsTD6Mod Mod => Main;

    internal static MelonMain Main => ModContent.GetInstance<MelonMain>();
    internal static Assembly MainAssembly => Main.GetAssembly();


    internal static void LoadAllMods()
    {
        foreach (var mod in Mods.OrderBy(mod => mod.Priority))
        {
            try
            {
                ResourceHandler.LoadEmbeddedResources(mod);
            }
            catch (Exception e)
            {
                Error("Critical failure when loading resources for mod " + mod.Info.Name);
                Error(e);
            }
            try
            {
                ModContent.LoadModContent(mod);
            }
            catch (Exception e)
            {
                Error("Critical failure when loading content for mod " + mod.Info.Name);
                Error(e);
            }
        }
    }

    /// <summary>
    /// Gets a BloonsTD6Mod by its name, or returns null if none are loaded with that name
    /// <br />
    /// In this case a mod's name is its Assembly Name, which is almost always the same as the file name, but for the
    /// Mod Helper due to compatibility reasons it is "BloonsTD6 Mod Helper" rather than "Btd6ModHelper"
    /// </summary>
    public static BloonsMod GetMod(string name) => Mods.FirstOrDefault(bloonsMod => bloonsMod.GetModName() == name);

    /// <summary>
    /// Gets the instance of a specific BloonsTD6Mod by its type
    /// </summary>
    public static T GetMod<T>() where T : BloonsMod => Melon<T>.Instance;

    /// <summary>
    /// Returns whether a mod with the given name is installed
    /// </summary>
    public static bool HasMod(string name) => GetMod(name) != null;

    /// <summary>
    /// Returns whether a mod with the given name is installed, and pass it to the out param if it is
    /// </summary>
    public static bool HasMod(string name, out BloonsMod bloonsMod) => (bloonsMod = GetMod(name)) != null;

    private static BloonsTD6Mod[] hookMods;

    internal static void PerformHook(Action<BloonsTD6Mod> action)
    {
        hookMods ??= Mods.OfType<BloonsTD6Mod>().OrderBy(mod => mod.Priority).ToArray();
        foreach (var mod in hookMods)
        {
            try
            {
                action.Invoke(mod);
            }
            catch (Exception e)
            {
                mod.LoggerInstance.Error(e);
            }
        }
    }

    /// <inheritdoc cref="ModContent.Localize(string,string)"/>
    internal static string Localize(string key, string text) => ModContent.Localize(Main, key, text);

    /// <inheritdoc cref="ModContent.Localize(string,string)"/>
    internal static string Localize(string keyAndText) => ModContent.Localize(Main, keyAndText);

    #region Console Messages

    /// <summary>
    /// Logs a message from the specified Mod's LoggerInstance
    /// </summary>
    public static void Log<T>(object obj) where T : BloonsMod
    {
        GetMod<T>().LoggerInstance.Msg(obj ?? "null");
    }

    /// <summary>
    /// Logs a message from the specified Mod's LoggerInstance
    /// </summary>
    public static void Msg<T>(object obj) where T : BloonsMod
    {
        GetMod<T>().LoggerInstance.Msg(obj ?? "null");
    }


    /// <summary>
    /// Logs an error from the specified Mod's LoggerInstance
    /// </summary>
    public static void Error<T>(object obj) where T : BloonsMod
    {
        GetMod<T>().LoggerInstance.Error(obj ?? "null");
    }

    /// <summary>
    /// Logs a warning from the specified Mod's LoggerInstance
    /// </summary>
    public static void Warning<T>(object obj) where T : BloonsMod
    {
        GetMod<T>().LoggerInstance.Warning(obj ?? "null");
    }

    /// <summary>
    /// Logs a message from the Mod Helper's LoggerInstance
    /// </summary>
    internal static void Log(object obj)
    {
        lock (Main.LoggerInstance)
        {
            Main.LoggerInstance.Msg(obj ?? "null");
        }
    }

    /// <summary>
    /// Logs a message from the Mod Helper's LoggerInstance
    /// </summary>
    internal static void Msg(object obj)
    {
        lock (Main.LoggerInstance)
        {
            Main.LoggerInstance.Msg(obj ?? "null");
        }
    }

    /// <summary>
    /// Logs an error from the Mod Helper's LoggerInstance
    /// </summary>
    internal static void Error(object obj)
    {
        lock (Main.LoggerInstance)
        {
            Main.LoggerInstance.Error(obj ?? "null");
        }
    }

    /// <summary>
    /// Logs a warning from the Mod Helper's LoggerInstance
    /// </summary>
    internal static void Warning(object obj)
    {
        lock (Main.LoggerInstance)
        {
            Main.LoggerInstance.Warning(obj ?? "null");
        }
    }

    #endregion

    internal static void MigrateFolders()
    {
        if (ModHelperDirectory == PreviousModHelperDirectory)
        {
            MigrateFolder(PreviousModHelperDirectory, NewModHelperDirectory);
            if (ModHelperDirectory == PreviousModHelperDirectory)
            {
                Main.LoadError("Failed to migrate Mod Helper directory, see console for details");
            }
            else
            {
                Msg("Successfully migrated Mod Helper directory");
            }
        }

        if (DisabledModsDirectory == PreviousDisabledModsDirectory)
        {
            MigrateFolder(PreviousDisabledModsDirectory, NewDisabledModDirectory);
            if (DisabledModsDirectory == PreviousDisabledModsDirectory)
            {
                Main.LoadError("Failed to migrate disabled mods directory, see console for details");
            }
            else
            {
                Msg("Successfully migrated disabled mods directory");
            }
        }
    }

    private static void MigrateFolder(string oldDir, string newDir)
    {
        try
        {
            FileIOHelper.CopyDirectory(oldDir, newDir);
            try
            {
                Directory.Delete(oldDir, true);
            }
            catch (Exception e)
            {
                Warning($"Failed to delete outdated dir {oldDir}");
                Warning(e);
            }
        }
        catch (Exception e)
        {
            Warning($"Failed to copy outdated dir {oldDir} to new destination {newDir}");
            Warning(e);
        }
    }
}