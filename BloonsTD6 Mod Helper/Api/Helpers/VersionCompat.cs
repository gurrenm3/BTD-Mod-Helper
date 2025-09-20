using System.Text.RegularExpressions;
using BuildInfo = MelonLoader.Properties.BuildInfo;

#if MOD_HELPER
using UnityEngine;
#else
using System;
using System.Linq;
using MelonLoader.InternalUtils;
#endif

namespace BTD_Mod_Helper.Api.Helpers;

internal static class VersionCompat
{
#if !MOD_HELPER
    internal static bool safeToGetVersionFromUnity;

    private static Type Application =>
        AccessTools.AllTypes().FirstOrDefault(type => type.FullName == "UnityEngine.Application");

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

    public static string MelonLoaderVersion => BuildInfo.Version;

}