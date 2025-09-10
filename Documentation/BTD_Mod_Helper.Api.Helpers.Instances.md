#### [BloonsTD6 Mod Helper](README.md 'README')
### [BTD_Mod_Helper.Api.Helpers](README.md#BTD_Mod_Helper.Api.Helpers 'BTD_Mod_Helper.Api.Helpers')

## Instances Class

Provides quick access to many major BTD6 singleton classes

```csharp
public class Instances
```

Inheritance [UnityEngine.MonoBehaviour](https://docs.microsoft.com/en-us/dotnet/api/UnityEngine.MonoBehaviour 'UnityEngine.MonoBehaviour') &#129106; Instances
### Properties

<a name='BTD_Mod_Helper.Api.Helpers.Instances.BaseGameModel'></a>

## Instances.BaseGameModel Property

The base GameModel class

```csharp
public static GameModel BaseGameModel { get; }
```

#### Property Value
[Il2CppAssets.Scripts.Models.GameModel](https://docs.microsoft.com/en-us/dotnet/api/Il2CppAssets.Scripts.Models.GameModel 'Il2CppAssets.Scripts.Models.GameModel')

<a name='BTD_Mod_Helper.Api.Helpers.Instances.Bridge'></a>

## Instances.Bridge Property

The current UnityToSimulation bridge. Will be null if not in a game, or if the game isn't fully loaded in

```csharp
public static UnityToSimulation Bridge { get; }
```

#### Property Value
[Il2CppAssets.Scripts.Unity.Bridge.UnityToSimulation](https://docs.microsoft.com/en-us/dotnet/api/Il2CppAssets.Scripts.Unity.Bridge.UnityToSimulation 'Il2CppAssets.Scripts.Unity.Bridge.UnityToSimulation')

<a name='BTD_Mod_Helper.Api.Helpers.Instances.Btd6CoopGame'></a>

## Instances.Btd6CoopGame Property

The instance of the Btd6CoopGameNetworked class. Will be null if not in a coop game

```csharp
public static Btd6CoopGameNetworked Btd6CoopGame { get; }
```

#### Property Value
[Il2CppAssets.Scripts.Unity.Network.Btd6CoopGameNetworked](https://docs.microsoft.com/en-us/dotnet/api/Il2CppAssets.Scripts.Unity.Network.Btd6CoopGameNetworked 'Il2CppAssets.Scripts.Unity.Network.Btd6CoopGameNetworked')

<a name='BTD_Mod_Helper.Api.Helpers.Instances.Btd6Player'></a>

## Instances.Btd6Player Property

The current Btd6Player

```csharp
public static Btd6Player Btd6Player { get; }
```

#### Property Value
[Il2CppAssets.Scripts.Unity.Player.Btd6Player](https://docs.microsoft.com/en-us/dotnet/api/Il2CppAssets.Scripts.Unity.Player.Btd6Player 'Il2CppAssets.Scripts.Unity.Player.Btd6Player')

<a name='BTD_Mod_Helper.Api.Helpers.Instances.CashManager'></a>

## Instances.CashManager Property

The CashManager for the current player.

```csharp
public static CashManager CashManager { get; }
```

#### Property Value
[Il2CppAssets.Scripts.Simulation.CashManager](https://docs.microsoft.com/en-us/dotnet/api/Il2CppAssets.Scripts.Simulation.CashManager 'Il2CppAssets.Scripts.Simulation.CashManager')

<a name='BTD_Mod_Helper.Api.Helpers.Instances.CoOpBridge'></a>

## Instances.CoOpBridge Property

The current NetworkedUnityToSimulation bridge. Will be null if not in a coop game, or if the game isn't fully loaded in

```csharp
public static UnityToSimulation CoOpBridge { get; }
```

#### Property Value
[Il2CppAssets.Scripts.Unity.Bridge.UnityToSimulation](https://docs.microsoft.com/en-us/dotnet/api/Il2CppAssets.Scripts.Unity.Bridge.UnityToSimulation 'Il2CppAssets.Scripts.Unity.Bridge.UnityToSimulation')

<a name='BTD_Mod_Helper.Api.Helpers.Instances.CoOpUnityToSimulation'></a>

## Instances.CoOpUnityToSimulation Property

The current NetworkedUnityToSimulation bridge. Will be null if not in a coop game, or if the game isn't fully loaded in

```csharp
public static NetworkedUnityToSimulation CoOpUnityToSimulation { get; }
```

#### Property Value
[Il2CppAssets.Scripts.Unity.Bridge.NetworkedUnityToSimulation](https://docs.microsoft.com/en-us/dotnet/api/Il2CppAssets.Scripts.Unity.Bridge.NetworkedUnityToSimulation 'Il2CppAssets.Scripts.Unity.Bridge.NetworkedUnityToSimulation')

<a name='BTD_Mod_Helper.Api.Helpers.Instances.CurrentGameModel'></a>

## Instances.CurrentGameModel Property

The modified GameModel that's being used for the current game. Will be null if not in a game, or if the game isn't fully loaded yet

```csharp
public static GameModel CurrentGameModel { get; }
```

#### Property Value
[Il2CppAssets.Scripts.Models.GameModel](https://docs.microsoft.com/en-us/dotnet/api/Il2CppAssets.Scripts.Models.GameModel 'Il2CppAssets.Scripts.Models.GameModel')

<a name='BTD_Mod_Helper.Api.Helpers.Instances.CurrentInGameData'></a>

## Instances.CurrentInGameData Property

The instance of the InGameData class for the current match

```csharp
public static ReadonlyInGameData CurrentInGameData { get; }
```

#### Property Value
[Il2CppAssets.Scripts.Unity.UI_New.InGame.ReadonlyInGameData](https://docs.microsoft.com/en-us/dotnet/api/Il2CppAssets.Scripts.Unity.UI_New.InGame.ReadonlyInGameData 'Il2CppAssets.Scripts.Unity.UI_New.InGame.ReadonlyInGameData')

<a name='BTD_Mod_Helper.Api.Helpers.Instances.DisplayFactory'></a>

## Instances.DisplayFactory Property

The current Display Factory

```csharp
public static Factory DisplayFactory { get; }
```

#### Property Value
[Il2CppAssets.Scripts.Unity.Display.Factory](https://docs.microsoft.com/en-us/dotnet/api/Il2CppAssets.Scripts.Unity.Display.Factory 'Il2CppAssets.Scripts.Unity.Display.Factory')

<a name='BTD_Mod_Helper.Api.Helpers.Instances.FactoryFactory'></a>

## Instances.FactoryFactory Property

The current FactoryFactory (factory for in game factories), or null if not in game

```csharp
public static FactoryFactory FactoryFactory { get; }
```

#### Property Value
[Il2CppAssets.Scripts.Simulation.Factory.FactoryFactory](https://docs.microsoft.com/en-us/dotnet/api/Il2CppAssets.Scripts.Simulation.Factory.FactoryFactory 'Il2CppAssets.Scripts.Simulation.Factory.FactoryFactory')

<a name='BTD_Mod_Helper.Api.Helpers.Instances.Game'></a>

## Instances.Game Property

The instance of the Game class

```csharp
public static Game Game { get; }
```

#### Property Value
[Il2CppAssets.Scripts.Unity.Game](https://docs.microsoft.com/en-us/dotnet/api/Il2CppAssets.Scripts.Unity.Game 'Il2CppAssets.Scripts.Unity.Game')

<a name='BTD_Mod_Helper.Api.Helpers.Instances.GameConnection'></a>

## Instances.GameConnection Property

The instance of the GameConnection class. Will be null if not in a coop game

```csharp
public static GameConnection GameConnection { get; }
```

#### Property Value
[Il2CppNinjaKiwi.LiNK.Lobbies.GameConnection](https://docs.microsoft.com/en-us/dotnet/api/Il2CppNinjaKiwi.LiNK.Lobbies.GameConnection 'Il2CppNinjaKiwi.LiNK.Lobbies.GameConnection')

<a name='BTD_Mod_Helper.Api.Helpers.Instances.GameData'></a>

## Instances.GameData Property

The instance of the GameData class

```csharp
public static GameData GameData { get; }
```

#### Property Value
[Il2CppAssets.Scripts.Data.GameData](https://docs.microsoft.com/en-us/dotnet/api/Il2CppAssets.Scripts.Data.GameData 'Il2CppAssets.Scripts.Data.GameData')

<a name='BTD_Mod_Helper.Api.Helpers.Instances.InGame'></a>

## Instances.InGame Property

The current instance of the InGame class. Will be null if not in a match.

```csharp
public static InGame InGame { get; }
```

#### Property Value
[Il2CppAssets.Scripts.Unity.UI_New.InGame.InGame](https://docs.microsoft.com/en-us/dotnet/api/Il2CppAssets.Scripts.Unity.UI_New.InGame.InGame 'Il2CppAssets.Scripts.Unity.UI_New.InGame.InGame')

<a name='BTD_Mod_Helper.Api.Helpers.Instances.InputManager'></a>

## Instances.InputManager Property

The InputManager for the current player.

```csharp
public static InputManager InputManager { get; }
```

#### Property Value
[Il2CppAssets.Scripts.Simulation.Input.InputManager](https://docs.microsoft.com/en-us/dotnet/api/Il2CppAssets.Scripts.Simulation.Input.InputManager 'Il2CppAssets.Scripts.Simulation.Input.InputManager')

<a name='BTD_Mod_Helper.Api.Helpers.Instances.Map'></a>

## Instances.Map Property

The current Map in simulation, or null if not in game

```csharp
public static Map Map { get; }
```

#### Property Value
[Il2CppAssets.Scripts.Simulation.Track.Map](https://docs.microsoft.com/en-us/dotnet/api/Il2CppAssets.Scripts.Simulation.Track.Map 'Il2CppAssets.Scripts.Simulation.Track.Map')

<a name='BTD_Mod_Helper.Api.Helpers.Instances.MenuManager'></a>

## Instances.MenuManager Property

The current instance of the MenuManager component, may be null

```csharp
public static MenuManager MenuManager { get; }
```

#### Property Value
[Il2CppAssets.Scripts.Unity.Menu.MenuManager](https://docs.microsoft.com/en-us/dotnet/api/Il2CppAssets.Scripts.Unity.Menu.MenuManager 'Il2CppAssets.Scripts.Unity.Menu.MenuManager')

<a name='BTD_Mod_Helper.Api.Helpers.Instances.NextInGameData'></a>

## Instances.NextInGameData Property

The instance of the InGameData class that will be used for the next match

```csharp
public static InGameData NextInGameData { get; }
```

#### Property Value
[Il2CppAssets.Scripts.Unity.UI_New.InGame.InGameData](https://docs.microsoft.com/en-us/dotnet/api/Il2CppAssets.Scripts.Unity.UI_New.InGame.InGameData 'Il2CppAssets.Scripts.Unity.UI_New.InGame.InGameData')

<a name='BTD_Mod_Helper.Api.Helpers.Instances.NKGI'></a>

## Instances.NKGI Property

The instance of the NKMultiGameInterface class. Will be null if not in a coop game

```csharp
public static NKMultiGameInterface NKGI { get; }
```

#### Property Value
[Il2CppNinjaKiwi.NKMulti.NKMultiGameInterface](https://docs.microsoft.com/en-us/dotnet/api/Il2CppNinjaKiwi.NKMulti.NKMultiGameInterface 'Il2CppNinjaKiwi.NKMulti.NKMultiGameInterface')

<a name='BTD_Mod_Helper.Api.Helpers.Instances.NKMultiConnection'></a>

## Instances.NKMultiConnection Property

The instance of the NKMultiConnection class. Will be null if not in a coop game

```csharp
public static NKMultiConnection NKMultiConnection { get; }
```

#### Property Value
[Il2CppNinjaKiwi.LiNK.Lobbies.NKMultiConnection](https://docs.microsoft.com/en-us/dotnet/api/Il2CppNinjaKiwi.LiNK.Lobbies.NKMultiConnection 'Il2CppNinjaKiwi.LiNK.Lobbies.NKMultiConnection')

<a name='BTD_Mod_Helper.Api.Helpers.Instances.PopupScreen'></a>

## Instances.PopupScreen Property

The current instance of the PopupScreen component

```csharp
public static PopupScreen PopupScreen { get; }
```

#### Property Value
[Il2CppAssets.Scripts.Unity.UI_New.Popups.PopupScreen](https://docs.microsoft.com/en-us/dotnet/api/Il2CppAssets.Scripts.Unity.UI_New.Popups.PopupScreen 'Il2CppAssets.Scripts.Unity.UI_New.Popups.PopupScreen')

<a name='BTD_Mod_Helper.Api.Helpers.Instances.Profile'></a>

## Instances.Profile Property

The current player's profile

```csharp
public static ProfileModel Profile { get; }
```

#### Property Value
[Il2CppAssets.Scripts.Models.Profile.ProfileModel](https://docs.microsoft.com/en-us/dotnet/api/Il2CppAssets.Scripts.Models.Profile.ProfileModel 'Il2CppAssets.Scripts.Models.Profile.ProfileModel')

<a name='BTD_Mod_Helper.Api.Helpers.Instances.ShopMenu'></a>

## Instances.ShopMenu Property

The current instance of the ShopMenu component, may be null

```csharp
public static ShopMenu ShopMenu { get; }
```

#### Property Value
[Il2CppAssets.Scripts.Unity.UI_New.InGame.RightMenu.ShopMenu](https://docs.microsoft.com/en-us/dotnet/api/Il2CppAssets.Scripts.Unity.UI_New.InGame.RightMenu.ShopMenu 'Il2CppAssets.Scripts.Unity.UI_New.InGame.RightMenu.ShopMenu')

<a name='BTD_Mod_Helper.Api.Helpers.Instances.Simulation'></a>

## Instances.Simulation Property

The current game Simulation. Will be null if not in a game, or if the game isn't fully loaded in.

```csharp
public static Simulation Simulation { get; }
```

#### Property Value
[Il2CppAssets.Scripts.Simulation.Simulation](https://docs.microsoft.com/en-us/dotnet/api/Il2CppAssets.Scripts.Simulation.Simulation 'Il2CppAssets.Scripts.Simulation.Simulation')

<a name='BTD_Mod_Helper.Api.Helpers.Instances.TowerManager'></a>

## Instances.TowerManager Property

The TowerManger for the current game. Will be null if not in a game, or if the game isn't fully loaded yet

```csharp
public static TowerManager TowerManager { get; }
```

#### Property Value
[Il2CppAssets.Scripts.Simulation.Towers.TowerManager](https://docs.microsoft.com/en-us/dotnet/api/Il2CppAssets.Scripts.Simulation.Towers.TowerManager 'Il2CppAssets.Scripts.Simulation.Towers.TowerManager')

<a name='BTD_Mod_Helper.Api.Helpers.Instances.TowerSelectionMenu'></a>

## Instances.TowerSelectionMenu Property

The current instance of the TowerSelectionMenu component, may be null

```csharp
public static TowerSelectionMenu TowerSelectionMenu { get; }
```

#### Property Value
[Il2CppAssets.Scripts.Unity.UI_New.InGame.TowerSelectionMenu.TowerSelectionMenu](https://docs.microsoft.com/en-us/dotnet/api/Il2CppAssets.Scripts.Unity.UI_New.InGame.TowerSelectionMenu.TowerSelectionMenu 'Il2CppAssets.Scripts.Unity.UI_New.InGame.TowerSelectionMenu.TowerSelectionMenu')

<a name='BTD_Mod_Helper.Api.Helpers.Instances.UnityToSimulation'></a>

## Instances.UnityToSimulation Property

The current UnityToSimulation bridge. Will be null if not in a game, or if the game isn't fully loaded in

```csharp
public static UnityToSimulation UnityToSimulation { get; }
```

#### Property Value
[Il2CppAssets.Scripts.Unity.Bridge.UnityToSimulation](https://docs.microsoft.com/en-us/dotnet/api/Il2CppAssets.Scripts.Unity.Bridge.UnityToSimulation 'Il2CppAssets.Scripts.Unity.Bridge.UnityToSimulation')