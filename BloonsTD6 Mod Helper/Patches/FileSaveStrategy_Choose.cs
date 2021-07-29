using HarmonyLib;
using System.IO;
using NinjaKiwi.Players;
using NinjaKiwi.Players.Files;
using NinjaKiwi.Players.Files.SaveStrategies;

namespace BTD_Mod_Helper.Patches
{
    [HarmonyPatch(typeof(FileSaveStrategy), nameof(FileSaveStrategy.Choose))]
    internal class FileSaveStrategy_Choose
    {
        [HarmonyPrefix]
        internal static bool Prefix()
        {
            return true;
        }

        [HarmonyPostfix]
        internal static void Postfix(FileSaveStrategy __result, string path, SaveStrategy type)
        {
            if (!string.IsNullOrEmpty(SessionData.saveDirectory) || !path.ToLower().EndsWith("profile.save"))
                return;

            FileInfo fileInfo = new FileInfo(path);
            SessionData.saveDirectory = fileInfo.Directory.FullName;
            SessionData.playerSaveStrategy = __result;
        }
    }
}