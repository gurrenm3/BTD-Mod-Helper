using Assets.Scripts.Simulation.Bloons;
using NinjaKiwi.NKMulti;
using NinjaKiwi.Players.Files;
using System.Collections.Generic;

namespace BTD_Mod_Helper;

/// <summary>
/// This class is used in the API to store data about the current state of the game,
/// like whether or not the player is in a Public Coop game
/// </summary>
public partial class SessionData
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
    /// Gets set when <see cref="FileSaveStrategy.Choose(string, NinjaKiwi.Players.SaveStrategy)"/>
    /// tries to load the Player Save
    /// </summary>
    public string SaveDirectory { get; set; } = "";

    /// <summary>
    /// The instance of <see cref="FileSaveStrategy"/> that is used to load the Player save.
    /// </summary>
    public FileSaveStrategy? PlayerSaveStrategy { get; set; }

    /// <summary>
    /// The instance of <see cref="NKMultiGameInterface"/> that is used during a 
    /// multiplayer game
    /// </summary>
    public NKMultiGameInterface? NkGI { get; set; }
}