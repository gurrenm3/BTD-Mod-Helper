using System;
using System.IO;
namespace BTD_Mod_Helper.Extensions;

/// <summary>
/// Extensions for DirectoryInfo
/// </summary>
public static class DirectoryInfoExt
{
    /// <summary>
    /// Returns all Files in this directory that reference MelonLoader.dll or MelonLoader.ModHandler.dll
    /// </summary>
    /// <param name="directoryInfo"></param>
    /// <returns></returns>
    public static FileInfo[] GetAllMelonMods(this DirectoryInfo directoryInfo)
    {
        var files = directoryInfo.GetFiles();
        return !files.Any() ? Array.Empty<FileInfo>() : Array.FindAll(files, file => file.IsMelonMod());
    }
}