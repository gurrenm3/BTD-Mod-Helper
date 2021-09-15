using Assets.Scripts.Models.Rounds;
using BTD_Mod_Helper.Api;
using System.Collections.Generic;

namespace BTD_Mod_Helper
{
    public partial class SessionData
    {
        public static SessionData Instance { get; set; } = new SessionData();


        internal BloonTracker bloonTracker = new BloonTracker();
        public RoundSetModel RoundSet { get; set; }
        public Dictionary<string, int> PoppedBloons { get; set; } = new Dictionary<string, int>();
        
        /// <summary>
        /// How much cash each bloon is worth when completely popped
        /// </summary>
        public readonly Dictionary<string, int> bloonPopValue = new Dictionary<string, int>();

        /// <summary>
        /// Resets all the values in SessionData
        /// </summary>
        public static void Reset()
        {
            Instance = new SessionData();
        }
    }
}
