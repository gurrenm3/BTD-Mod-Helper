using System.IO;
using MelonLoader.Utils;
namespace BTD_Mod_Helper.Extensions;

/// <summary>
/// Extensions for BloonsTD6Mods (for some reason lol)
/// </summary>
public static class BloonsTD6ModExt
{
    /// <summary>
    /// Get the name of this mod from it's dll name
    /// </summary>
    public static string GetModName(this BloonsMod bloonsMod) =>
        bloonsMod.GetAssembly()?.GetName().Name ?? bloonsMod.Info.Name;

    /// <summary>
    /// Get the personal mod directory for this specific mod. Useful for keeping this mod's files seperate from other mods.
    /// Example: "BloonsTD6/Mods/BloonsTD6 Mod Helper/settings.txt"
    /// </summary>
    /// <param name="bloonsMod"></param>
    /// <returns></returns>
    public static string GetModDirectory(this BloonsMod bloonsMod) =>
        Path.Combine(MelonEnvironment.ModsDirectory, bloonsMod.GetModName());

    /// <summary>
    /// Get the personal mod directory for this specific mod. Useful for keeping this mod's files seperate from other mods.
    /// Example: "BloonsTD6/Mods/BloonsTD6 Mod Helper/settings.txt"
    /// </summary>
    /// <param name="bloonsMod"></param>
    /// <param name="createIfNotExists">Create the mod's directory if it doesn't exist yet?</param>
    /// <returns></returns>
    public static string GetModDirectory(this BloonsMod bloonsMod, bool createIfNotExists)
    {
        var path = $"{MelonEnvironment.ModsDirectory}\\{bloonsMod.GetModName()}";
        if (createIfNotExists) Directory.CreateDirectory(path);
        return path;
    }

    /// <summary>
    /// Gets the directory where this mod's settings are or will be stored. Example: "BloonsTD6/Mods/BloonsTD6 Mod
    /// Helper/settings.txt"
    /// </summary>
    /// <param name="bloonsMod"></param>
    /// <returns></returns>
    public static string GetModSettingsDir(this BloonsMod bloonsMod) =>
        Path.Combine(bloonsMod.GetModDirectory(), "Mod Settings");

    /// <summary>
    /// Gets the directory where this mod's settings are or will be stored. Example: "BloonsTD6/Mods/BloonsTD6 Mod
    /// Helper/settings.txt"
    /// </summary>
    /// <param name="bloonsMod"></param>
    /// <param name="createIfNotExists">Create the mod's directory if it doesn't exist yet?</param>
    /// <returns></returns>
    public static string GetModSettingsDir(this BloonsMod bloonsMod, bool createIfNotExists)
    {
        var path = bloonsMod.GetModSettingsDir();
        if (createIfNotExists) Directory.CreateDirectory(path);
        return path;
    }
}