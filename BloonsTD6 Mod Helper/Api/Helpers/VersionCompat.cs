#if MOD_HELPER
using UnityEngine;
#else
using System;
using System.Linq;
using System.Threading;
using MelonLoader.InternalUtils;
using MelonLoader.Utils;
using System.Text.RegularExpressions;
#endif

namespace BTD_Mod_Helper.Api.Helpers;

internal static class VersionCompat
{
#if !MOD_HELPER
    internal static bool safeToGetVersionFromUnity;

    private static readonly Lazy<Type> Application =
        new(() => AccessTools.AllTypes().FirstOrDefault(t => t.FullName == "UnityEngine.Application"),
            LazyThreadSafetyMode.ExecutionAndPublication);

    private static Lazy<Type> BuildInfo =>
        new(() => AccessTools.AllTypes().FirstOrDefault(type =>
                type.FullName != null && type.FullName.StartsWith("MelonLoader") && type.FullName.EndsWith("BuildInfo")),
            LazyThreadSafetyMode.ExecutionAndPublication);

    public static string MelonLoaderVersion =>
        BuildInfo.Value is { } type && type.GetProperty("Version") is { } version
            ? version.GetValue(null) as string
            : typeof(MelonEnvironment).Assembly.GetName().Version!.ToString();

    public static string UnityVersionWithoutType => RemoveUnityInfo(UnityVersion);

    public static string RemoveUnityInfo(string version) => Regex.Replace(version, "[a-z].*", "");
#endif

    public static string GameVersion
    {
        get
        {
#if MOD_HELPER
            return Application.version;
#else
            return
                safeToGetVersionFromUnity &&
                Application.Value is { } application &&
                (field ??= application.GetProperty("version")!.GetValue(null) as string) is { } version
                    ? version
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
            if (safeToGetVersionFromUnity && Application.Value is { } application)
            {
                return application.GetProperty("unityVersion")!.GetValue(null) as string;
            }

            var engineVersion = typeof(UnityInformationHandler).GetProperty("EngineVersion")!.GetValue(null)!;

            return engineVersion.GetType().GetMethod("ToString", [])!.Invoke(engineVersion, []) as string;
#endif
        }
    }
}