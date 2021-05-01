using Assets.Scripts.Models.Rounds;
using BTD_Mod_Helper.Api;
using System.Collections.Generic;

namespace BTD_Mod_Helper
{
    public static partial class SessionData
    {
        public static bool IsInPublicCoop { get; set; } = false;
        public static bool IsInOdyssey { get; set; } = false;
        public static bool IsInRace { get; set; } = false;

        internal static BloonTracker bloonTracker = new BloonTracker();
        public static RoundSetModel RoundSet { get; set; }
        public static Dictionary<string, int> PoppedBloons { get; set; } = new Dictionary<string, int>();
    }
}
