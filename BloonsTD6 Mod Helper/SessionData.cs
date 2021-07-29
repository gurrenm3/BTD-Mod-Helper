using Assets.Scripts.Unity.Bridge;
using NinjaKiwi.NKMulti;
using NinjaKiwi.Players.Files;

namespace BTD_Mod_Helper
{
    public static partial class SessionData
    {
        public static FileSaveStrategy playerSaveStrategy;
        public static string saveDirectory;
        public static NKMultiGameInterface nkGI;
    }
}
