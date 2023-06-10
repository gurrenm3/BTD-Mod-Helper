using System;
using System.Collections.Generic;
using Il2CppAssets.Scripts.Simulation.Bloons;
using Il2CppNinjaKiwi.NKMulti;
namespace BTD_Mod_Helper;

/// <summary>
/// This class is used in the API to store data about the current state of the game,
/// like whether or not the player is in a Public Coop game
/// </summary>
/// <exclude />
public class SessionData
{
    /// <summary>
    /// Contains all the Bloons that were leaked during this round
    /// Used to track which bloons were popped and which leaked
    /// </summary>
    public List<Bloon> LeakedBloons { get; set; } = new();

    /// <summary>
    /// Contains all the Bloons that were destroyed during this round
    /// </summary>
    public List<Bloon> DestroyedBloons { get; set; } = new();

    /// <summary>
    /// If the player is in Coop, this value represents whether it's a
    /// Public Coop match or not
    /// </summary>
    public bool IsInPublicCoop { get; set; } = false;

    /// <summary>
    /// If the player is in a game, are they in a Odyssey game
    /// </summary>
    public bool IsInOdyssey { get; set; } = false;

    /// <summary>
    /// If the player is in a game, is it a Race game
    /// </summary>
    public bool IsInRace { get; set; } = false;

    /// <summary>
    /// The directory of the save file.
    /// </summary>
    [Obsolete]
    public string SaveDirectory { get; set; } = "";

    /// <summary>
    /// The instance of <see cref="NKMultiGameInterface" /> that is used during a
    /// multiplayer game
    /// </summary>
    public NKMultiGameInterface NkGI { get; set; }

    /// <summary>
    /// If the player is in a game, is it currently paused
    /// </summary>
    public bool IsPaused { get; set; }

    /// <summary>
    /// How much cash each bloon is worth when completely popped
    /// </summary>
    public readonly Dictionary<string, int> bloonPopValues = new();

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
    /// Resets all the values in SessionData
    /// </summary>
    public static void Reset()
    {
        Instance = new SessionData();
    }
}