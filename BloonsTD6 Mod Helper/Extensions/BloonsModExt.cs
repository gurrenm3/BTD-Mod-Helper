using System.IO;
using System.Reflection;
using BTD_Mod_Helper.Api;
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
    public static string GetModName(this BloonsTD6Mod BloonsTD6Mod)
    {
        return BloonsTD6Mod.GetAssembly()?.GetName().Name ?? BloonsTD6Mod.Info.Name;
    }

    /// <summary>
    /// Get the personal mod directory for this specific mod. Useful for keeping this mod's files seperate from other mods.
    /// Example: "BloonsTD6/Mods/BloonsTD6 Mod Helper/settings.txt"
    /// </summary>
    /// <param name="BloonsTD6Mod"></param>
    /// <returns></returns>
    public static string GetModDirectory(this BloonsTD6Mod BloonsTD6Mod)
    {
        return Path.Combine(MelonEnvironment.ModsDirectory, BloonsTD6Mod.GetModName());
    }

    /// <summary>
    /// Get the personal mod directory for this specific mod. Useful for keeping this mod's files seperate from other mods.
    /// Example: "BloonsTD6/Mods/BloonsTD6 Mod Helper/settings.txt"
    /// </summary>
    /// <param name="BloonsTD6Mod"></param>
    /// <param name="createIfNotExists">Create the mod's directory if it doesn't exist yet?</param>
    /// <returns></returns>
    public static string GetModDirectory(this BloonsTD6Mod BloonsTD6Mod, bool createIfNotExists)
    {
        var path = $"{MelonEnvironment.ModsDirectory}\\{BloonsTD6Mod.GetModName()}";
        if (createIfNotExists) Directory.CreateDirectory(path);
        return path;
    }

    /// <summary>
    /// Gets the directory where this mod's settings are or will be stored. Example: "BloonsTD6/Mods/BloonsTD6 Mod
    /// Helper/settings.txt"
    /// </summary>
    /// <param name="BloonsTD6Mod"></param>
    /// <returns></returns>
    public static string GetModSettingsDir(this BloonsTD6Mod BloonsTD6Mod)
    {
        return Path.Combine(BloonsTD6Mod.GetModDirectory(), "Mod Settings");
    }

    /// <summary>
    /// Gets the directory where this mod's settings are or will be stored. Example: "BloonsTD6/Mods/BloonsTD6 Mod
    /// Helper/settings.txt"
    /// </summary>
    /// <param name="BloonsTD6Mod"></param>
    /// <param name="createIfNotExists">Create the mod's directory if it doesn't exist yet?</param>
    /// <returns></returns>
    public static string GetModSettingsDir(this BloonsTD6Mod BloonsTD6Mod, bool createIfNotExists)
    {
        var path = BloonsTD6Mod.GetModSettingsDir();
        if (createIfNotExists) Directory.CreateDirectory(path);
        return path;
    }

    internal static ModHelperData GetModHelperData(this MelonMod mod)
    {
        return ModHelperData.Cache.TryGetValue(mod, out var data) ? data : null;
    }

    internal static Assembly GetAssembly(this MelonMod mod)
    {
        return mod.MelonAssembly.Assembly;
    }
}