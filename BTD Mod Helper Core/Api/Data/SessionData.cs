using Assets.Scripts.Models.Rounds;
using System.Collections.Generic;

namespace BTD_Mod_Helper
{
    public partial class SessionData
    {
        /// <summary>
        /// Singleton instance of SessionData
        /// </summary>
        public static SessionData Instance { get; set; } = new SessionData();


        //internal BloonTracker bloonTracker = new BloonTracker();
        
        /// <summary>
        /// Keeping track of popped bloons
        /// </summary>
        public Dictionary<string, int> PoppedBloons { get; set; } = new Dictionary<string, int>();
        
        /// <summary>
        /// How much cash each bloon is worth when completely popped
        /// </summary>
        public readonly Dictionary<string, int> bloonPopValues = new Dictionary<string, int>();

        /// <summary>
        /// Resets all the values in SessionData
        /// </summary>
        public static void Reset()
        {
            Instance = new SessionData();
        }
    }
}
