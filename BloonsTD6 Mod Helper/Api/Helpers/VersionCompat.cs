using System.Text.RegularExpressions;

#if MOD_HELPER
using UnityEngine;
#else
using System;
using System.Linq;
using MelonLoader.InternalUtils;
using MelonLoader.Utils;
#endif

namespace BTD_Mod_Helper.Api.Helpers;

internal static class VersionCompat
{
#if !MOD_HELPER
    internal static bool safeToGetVersionFromUnity;

    private static Type Application =>
        AccessTools.AllTypes().FirstOrDefault(type => type.FullName == "UnityEngine.Application");

    private static Type BuildInfo => AccessTools.AllTypes().FirstOrDefault(type =>
        type.FullName != null && type.FullName.StartsWith("MelonLoader") && type.FullName.EndsWith("BuildInfo"));

    public static string MelonLoaderVersion =>
        BuildInfo is { } type && type.GetProperty("Version") is { } version
            ? version.GetValue(null) as string
            : typeof(MelonEnvironment).Assembly.GetName().Version!.ToString();
#endif

    public static string GameVersion
    {
        get
        {
#if MOD_HELPER
            return Application.version;
#else
            return safeToGetVersionFromUnity && Application is { } application
                ? application.GetProperty("version")!.GetValue(null) as string
                : UnityInformationHandler.GameVersion;
#endif
        }
    }

    public static string UnityVersion
    {
        get
        {
#if MOD_HELPER
            return Application.unityVersion;
#else
            if (safeToGetVersionFromUnity && Application is { } application)
            {
                return application.GetProperty("unityVersion")!.GetValue(null) as string;
            }

            var engineVersion = typeof(UnityInformationHandler).GetProperty("EngineVersion")!.GetValue(null)!;

            return engineVersion.GetType().GetMethod("ToString")!.Invoke(engineVersion, []) as string;
#endif
        }
    }

    public static string UnityVersionWithoutType => RemoveUnityInfo(UnityVersion);

    public static string RemoveUnityInfo(string version) => Regex.Replace(version, "[a-z].*", "");
}