using System.IO;
using System.Reflection;
using BTD_Mod_Helper.Api.Data;
namespace BTD_Mod_Helper.Extensions;

internal static class MelonBaseExt
{
    internal static ModHelperData GetModHelperData(this MelonBase mod) =>
        ModHelperData.Cache.TryGetValue(mod, out var data) ? data : null;

    internal static Assembly GetAssembly(this MelonBase mod) => mod.MelonAssembly.Assembly;

    internal static string GetName(this MelonBase mod) => mod.GetAssembly().GetName().Name;

    internal static string FileName(this MelonBase mod) => Path.GetFileName(mod.MelonAssembly.Location);
}