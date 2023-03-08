using System.IO;
using Il2CppNinjaKiwi.Players;
using Il2CppNinjaKiwi.Players.Files;
namespace BTD_Mod_Helper.Patches.Resources;

[HarmonyPatch(typeof(FileSaveStrategy), nameof(FileSaveStrategy.Choose))]
internal class FileSaveStrategy_Choose
{
    [HarmonyPostfix]
    internal static void Postfix(FileSaveStrategy __result, string path, SaveStrategy type)
    {
        if (!string.IsNullOrEmpty(SessionData.Instance.SaveDirectory) || !path.ToLower().EndsWith("profile.save"))
            return;

        var fileInfo = new FileInfo(path);
        if (fileInfo.Directory != null)
        {
            SessionData.Instance.SaveDirectory = fileInfo.Directory.FullName;
            SessionData.Instance.PlayerSaveStrategy = __result;
        }
    }
}