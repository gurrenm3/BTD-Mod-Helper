using System.Collections.Generic;
using System.IO;
using System.Reflection;
using BTD_Mod_Helper.Api.Data;
using BTD_Mod_Helper.Api.Internal;
using BTD_Mod_Helper.Api.ModOptions;
namespace BTD_Mod_Helper.Extensions;

internal static class MelonBaseExt
{
    internal static ModHelperData GetModHelperData(this MelonBase mod) => ModHelperData.Cache.GetValueOrDefault(mod);

    internal static Assembly GetAssembly(this MelonBase mod) => mod.MelonAssembly.Assembly;

    internal static string GetName(this MelonBase mod) => mod.GetAssembly()?.GetName().Name ?? mod.Info.Name;

    internal static string FileName(this MelonBase mod) => Path.GetFileName(mod.MelonAssembly.Location);



    internal static string GetSettingsFilePath(this MelonBase mod)
    {
        var oldPath = Path.Combine(ModHelper.ModSettingsDirectory, $"{mod.Info.Name}.json");
        var newPath = Path.Combine(ModHelper.ModSettingsDirectory, $"{mod.GetAssembly().GetName().Name}.json");
        return File.Exists(oldPath) ? oldPath : newPath;
    }

    internal static Dictionary<string, ModSetting> GetModSettings(this MelonBase melonBase) =>
        melonBase is BloonsMod bloonsMod ? bloonsMod.ModSettings :
        melonBase.GetModHelperData().IsUpdaterPlugin() ? UpdaterPlugin.AutoUpdateSettings : null;
}