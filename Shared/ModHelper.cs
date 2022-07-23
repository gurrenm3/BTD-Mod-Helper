using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using Assets.Scripts.Unity;
using BTD_Mod_Helper.Api;
using Exception = System.Exception;

namespace BTD_Mod_Helper;

/// <summary>
/// Catch-all class for non-extension static methods
/// </summary>
public static class ModHelper
{
    #region ModHelperData for the Mod Helper

    internal const string Name = "BloonsTD6 Mod Helper";
    internal const string Version = "3.0.0-alpha1";
    internal const string RepoOwner = "doombubbles";
    internal const string RepoName = "BTD-Mod-Helper";
    internal const string Description = "The mod that is allowing all this to happen right now :P";
    internal const string DllName = "Btd6ModHelper.dll";
    internal const string Author = "Gurrenm4 and Doombubbles";

    #endregion

    /// <summary>
    /// Directory where the Mod Helper stores most of its extra info
    /// </summary>
    public static string ModHelperDirectory =>
        Path.Combine(MelonHandler.ModsDirectory, Assembly.GetExecutingAssembly().GetName().Name!);

    /// <summary>
    /// Directory for where disabled mods are stored
    /// </summary>
    public static string DisabledModsDirectory => Path.Combine(MelonHandler.ModsDirectory, "Disabled");

    internal static string ZipTempDirectory => Path.Combine(ModHelperDirectory, "Zip Temp");
    internal static string OldModsDirectory => Path.Combine(ModHelperDirectory, "Old Mods");
    internal static string DataDirectory => Path.Combine(ModHelperDirectory, "Data");
    internal static string ModSettingsDirectory => Path.Combine(ModHelperDirectory, "Mod Settings");
    internal static string ReplacedFilesDirectory => Path.Combine(ModHelperDirectory, "Replaced");

    /// <summary>
    /// The directory path on the user's system that's set as their Mod Sources folder
    /// </summary>
    public static string ModSourcesDirectory => MelonMain.ModSourcesFolder;
    
    private static bool fallBackToOldLoading;
    
    internal static bool FallbackToOldLoading
    {
        set => fallBackToOldLoading = value;
        get => fallBackToOldLoading || MelonMain.UseOldLoading;
    }

    private static IEnumerable<BloonsMod> mods;
    
    /// <summary>
    /// Active mods that use ModHelper functionality
    /// </summary>
    public static IEnumerable<BloonsMod> Mods =>
        mods ??= Melons.OfType<BloonsMod>().OrderByDescending(mod => mod.Priority);

    /// <summary>
    /// All active mods, whether they're Mod Helper or not
    /// </summary>
    public static IEnumerable<MelonMod> Melons => MelonBase.RegisteredMelons.OfType<MelonMod>();


    internal static void LoadAllMods()
    {
        foreach (var mod in Mods.OrderByDescending(mod => mod.Priority))
        {
            try
            {
                ResourceHandler.LoadEmbeddedTextures(mod);
                ResourceHandler.LoadEmbeddedBundles(mod);
                ModContent.LoadModContent(mod);
            }
            catch (Exception e)
            {
                Error("Critical failure when loading resources for mod " + mod.Info.Name);
                Error(e);
            }
        }

        ModHelperData.LoadAll();
    }

    #region Console Messages

    /// <summary>
    /// Logs a message from the specified Mod's LoggerInstance
    /// </summary>
    public static void Log<T>(object obj) where T : BloonsMod
    {
        ModContent.GetInstance<T>().LoggerInstance.Msg(obj);
    }

    /// <summary>
    /// Logs a message from the specified Mod's LoggerInstance
    /// </summary>
    public static void Msg<T>(object obj) where T : BloonsMod
    {
        ModContent.GetInstance<T>().LoggerInstance.Msg(obj);
    }


    /// <summary>
    /// Logs an error from the specified Mod's LoggerInstance
    /// </summary>
    public static void Error<T>(object obj) where T : BloonsMod
    {
        ModContent.GetInstance<T>().LoggerInstance.Error(obj);
    }

    /// <summary>
    /// Logs a warning from the specified Mod's LoggerInstance
    /// </summary>
    public static void Warning<T>(object obj) where T : BloonsMod
    {
        ModContent.GetInstance<T>().LoggerInstance.Warning(obj);
    }

    /// <summary>
    /// Logs a message from the Mod Helper's LoggerInstance
    /// </summary>
    internal static void Log(object obj)
    {
        Main.LoggerInstance.Msg(obj);
    }

    /// <summary>
    /// Logs a message from the Mod Helper's LoggerInstance
    /// </summary>
    internal static void Msg(object obj)
    {
        Main.LoggerInstance.Msg(obj);
    }

    /// <summary>
    /// Logs an error from the Mod Helper's LoggerInstance
    /// </summary>
    internal static void Error(object obj)
    {
        Main.LoggerInstance.Error(obj);
    }

    /// <summary>
    /// Logs a warning from the Mod Helper's LoggerInstance
    /// </summary>
    internal static void Warning(object obj)
    {
        Main.LoggerInstance.Warning(obj);
    }

    #endregion

    internal static MelonMain Main => ModContent.GetInstance<MelonMain>();
    internal static Assembly MainAssembly => Main.MelonAssembly.Assembly;

    private static void PerformHook<T>(Action<T> action) where T : BloonsMod
    {
        foreach (var mod in Mods.OfType<T>().OrderByDescending(mod => mod.Priority))
        {
#if BloonsTD6
            var canPerformHook = !mod.CheatMod || !Game.instance.CanGetFlagged();
#elif BloonsAT
                var canPerformHook = !mod.CheatMod;
#endif
            if (canPerformHook)
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
    }

#if BloonsTD6
    internal static void PerformHook(Action<BloonsTD6Mod> action)
    {
        PerformHook<BloonsTD6Mod>(action);
    }
#elif BloonsAT
    internal static void PerformHook(System.Action<BloonsATMod> action)
    {
        PerformHook<BloonsATMod>(action);
    }
#endif
}