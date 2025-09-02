using System;
using System.IO;
using MelonLoader.Utils;

namespace UpdaterPlugin;

public static class ModHelper
{
    internal static string ModHelperDirectory =>
        Path.Combine(MelonEnvironment.GameRootDirectory, DllName.Replace(".dll", ""));

    internal static string DataDirectory => Path.Combine(ModHelperDirectory, "Data");

    internal const string DllName = "Btd6ModHelper.dll";
    internal const string Branch = "master";

    internal static string DllLocation => Path.Combine(MelonEnvironment.ModsDirectory, DllName);

    internal static string GetContentURL(string name) =>
        $"https://raw.githubusercontent.com/{ModHelperData.RepoOwner}/{ModHelperData.RepoName}/{Branch}/{Uri.EscapeDataString(name)}";

    internal static string DownloadUrl =>
        $"https://github.com/{ModHelperData.RepoOwner}/{ModHelperData.RepoName}/releases/latest/download/{DllName}";
}