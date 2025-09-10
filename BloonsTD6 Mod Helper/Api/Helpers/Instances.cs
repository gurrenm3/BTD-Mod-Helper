using System;
using Il2CppAssets.Scripts.Data;
using Il2CppAssets.Scripts.Models;
using Il2CppAssets.Scripts.Models.Profile;
using Il2CppAssets.Scripts.Simulation;
using Il2CppAssets.Scripts.Simulation.Factory;
using Il2CppAssets.Scripts.Simulation.Towers;
using Il2CppAssets.Scripts.Simulation.Track;
using Il2CppAssets.Scripts.Unity;
using Il2CppAssets.Scripts.Unity.Bridge;
using Il2CppAssets.Scripts.Unity.Display;
using Il2CppAssets.Scripts.Unity.Menu;
using Il2CppAssets.Scripts.Unity.Network;
using Il2CppAssets.Scripts.Unity.Player;
using Il2CppAssets.Scripts.Unity.UI_New.InGame;
using Il2CppAssets.Scripts.Unity.UI_New.InGame.RightMenu;
using Il2CppAssets.Scripts.Unity.UI_New.InGame.TowerSelectionMenu;
using Il2CppAssets.Scripts.Unity.UI_New.Popups;
using Il2CppNinjaKiwi.LiNK.Lobbies;
using Il2CppNinjaKiwi.NKMulti;
using UnityEngine;
using InputManager = Il2CppAssets.Scripts.Simulation.Input.InputManager;
using NKMultiConnection = Il2CppNinjaKiwi.LiNK.Lobbies.NKMultiConnection;

// ReSharper disable Unity.NoNullPropagation
namespace BTD_Mod_Helper.Api.Helpers;

/// <summary>
/// Provides quick access to many major BTD6 singleton classes
/// </summary>
[RegisterTypeInIl2Cpp(false)]
public class Instances : MonoBehaviour
{
    /// <inheritdoc />
    public Instances(IntPtr pointer) : base(pointer)
    {
    }

    /// <summary>
    /// The instance of the Game class
    /// </summary>
    public static Game Game => Game.instance;

    /// <summary>
    /// The instance of the GameData class
    /// </summary>
    public static GameData GameData => GameData.Instance;

    /// <summary>
    /// The base GameModel class
    /// </summary>
    public static GameModel BaseGameModel => Game.instance.model;

    /// <summary>
    /// The current instance of the InGame class. Will be null if not in a match.
    /// </summary>
    public static InGame InGame => InGame.instance;

    /// <summary>
    /// The instance of the InGameData class that will be used for the next match
    /// </summary>
    public static InGameData NextInGameData => InGameData.Editable;

    /// <summary>
    /// The instance of the InGameData class for the current match
    /// </summary>
    public static ReadonlyInGameData CurrentInGameData => InGameData.CurrentGame;

    /// <summary>
    /// The current UnityToSimulation bridge. Will be null if not in a game, or if the game isn't fully loaded in
    /// </summary>
    public static UnityToSimulation UnityToSimulation => InGame?.bridge;

    /// <summary>
    /// The current UnityToSimulation bridge. Will be null if not in a game, or if the game isn't fully loaded in
    /// </summary>
    public static UnityToSimulation Bridge => InGame?.bridge;

    /// <summary>
    /// The current game Simulation. Will be null if not in a game, or if the game isn't fully loaded in.
    /// </summary>
    public static Simulation Simulation => InGame?.bridge?.simulation;

    /// <summary>
    /// The modified GameModel that's being used for the current game. Will be null if not in a game, or if the game isn't fully loaded yet
    /// </summary>
    public static GameModel CurrentGameModel => UnityToSimulation?.Model;

    /// <summary>
    /// The TowerManger for the current game. Will be null if not in a game, or if the game isn't fully loaded yet
    /// </summary>
    public static TowerManager TowerManager => Simulation?.towerManager;

    /// <summary>
    /// The InputManager for the current player. 
    /// </summary>
    public static InputManager InputManager => Simulation?.GetInputManager(Bridge.MyPlayerNumber);

    /// <summary>
    /// The CashManager for the current player. 
    /// </summary>
    public static Simulation.CashManager CashManager => Simulation?.GetCashManager(Bridge.MyPlayerNumber);

    /// <summary>
    /// The current Btd6Player
    /// </summary>
    public static Btd6Player Btd6Player => Game.Player;

    /// <summary>
    /// The current player's profile
    /// </summary>
    public static ProfileModel Profile => Btd6Player?.Data;

    /// <summary>
    /// The current Display Factory
    /// </summary>
    public static Factory DisplayFactory => Game.scene?.factory;

    /// <summary>
    /// The current FactoryFactory (factory for in game factories), or null if not in game
    /// </summary>
    public static FactoryFactory FactoryFactory => Simulation?.factory;

    /// <summary>
    /// The current Map in simulation, or null if not in game
    /// </summary>
    public static Map Map => Simulation?.Map;
    
    #region UI

    /// <summary>
    /// The current instance of the TowerSelectionMenu component, may be null
    /// </summary>
    public static TowerSelectionMenu TowerSelectionMenu => TowerSelectionMenu.instance;

    /// <summary>
    /// The current instance of the PopupScreen component
    /// </summary>
    public static PopupScreen PopupScreen => PopupScreen.instance;

    /// <summary>
    /// The current instance of the ShopMenu component, may be null
    /// </summary>
    public static ShopMenu ShopMenu => ShopMenu.instance;

    /// <summary>
    /// The current instance of the MenuManager component, may be null
    /// </summary>
    public static MenuManager MenuManager => MenuManager.instance;

    // There's a bunch of other `.instance`s for other menus, but that's getting a bit niche to list them all

    #endregion

    #region Co-Op

    /// <summary>
    /// The current NetworkedUnityToSimulation bridge. Will be null if not in a coop game, or if the game isn't fully loaded in
    /// </summary>
    public static NetworkedUnityToSimulation CoOpUnityToSimulation => InGame?.bridge?.TryCast<NetworkedUnityToSimulation>();

    /// <summary>
    /// The current NetworkedUnityToSimulation bridge. Will be null if not in a coop game, or if the game isn't fully loaded in
    /// </summary>
    public static UnityToSimulation CoOpBridge => InGame?.bridge?.TryCast<NetworkedUnityToSimulation>();

    /// <summary>
    /// The instance of the Btd6CoopGameNetworked class. Will be null if not in a coop game
    /// </summary>
    public static Btd6CoopGameNetworked Btd6CoopGame => InGame?.coopGame?.TryCast<Btd6CoopGameNetworked>();

    /// <summary>
    /// The instance of the GameConnection class. Will be null if not in a coop game
    /// </summary>
    public static GameConnection GameConnection => Btd6CoopGame?.Connection;

    /// <summary>
    /// The instance of the NKMultiConnection class. Will be null if not in a coop game
    /// </summary>
    public static NKMultiConnection NKMultiConnection => GameConnection?.Connection;

    /// <summary>
    /// The instance of the NKMultiGameInterface class. Will be null if not in a coop game
    /// </summary>
    public static NKMultiGameInterface NKGI => NKMultiConnection?.NKGI;

    #endregion
}