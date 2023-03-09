using System.Collections.Generic;
namespace BTD_Mod_Helper;

/// <summary>
/// This class stores info about the current session of the game. It's used to track data from
/// when the game starts to when it's closed.
/// </summary>
public partial class SessionData
{
    /// <summary>
    /// Singleton instance of SessionData
    /// </summary>
    public static SessionData Instance { get; set; } = new();


    //internal BloonTracker bloonTracker = new BloonTracker();
        
    /// <summary>
    /// Keeping track of popped bloons
    /// </summary>
    public Dictionary<string, int> PoppedBloons { get; set; } = new();
        
    /// <summary>
    /// How much cash each bloon is worth when completely popped
    /// </summary>
    public readonly Dictionary<string, int> bloonPopValues = new();

    /// <summary>
    /// Resets all the values in SessionData
    /// </summary>
    public static void Reset()
    {
        Instance = new SessionData();
    }
}