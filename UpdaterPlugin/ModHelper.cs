using System.IO;
using MelonLoader.Utils;

namespace UpdaterPlugin;

public static class ModHelper
{
    internal static string ModHelperDirectory =>
        Path.Combine(MelonEnvironment.GameRootDirectory, "Btd6ModHelper");

    internal static string DisabledModsDirectory => Path.Combine(MelonEnvironment.GameRootDirectory, "Disabled Mods");
    internal static string DataDirectory => Path.Combine(ModHelperDirectory, "Data");
    internal static string ModSettingsDirectory => Path.Combine(ModHelperDirectory, "Mod Settings");

    internal const string Name = "Updater Plugin";
    internal const string Author = "doombubbles";
    internal const string Version = "1.0.1";
    internal const string Description = "Keeps Mod Helper and other mods up to date on startup";
    internal const string RepoOwner = "gurrenm3";
    internal const string RepoName = "BTD-Mod-Helper";
    internal const string DllName = "UpdaterPlugin.dll";
    internal const string Branch = "master";
    internal const string MyGithubUsername = "";

    public static UpdaterPlugin Main => Melon<UpdaterPlugin>.Instance;

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
}