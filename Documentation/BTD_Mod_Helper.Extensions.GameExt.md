#### [BloonsTD6 Mod Helper](README.md 'README')
### [BTD_Mod_Helper.Extensions](README.md#BTD_Mod_Helper.Extensions 'BTD_Mod_Helper.Extensions')

## GameExt Class

Extensions for Game

```csharp
public static class GameExt
```

Inheritance [System.Object](https://docs.microsoft.com/en-us/dotnet/api/System.Object 'System.Object') &#129106; GameExt
### Methods

<a name='BTD_Mod_Helper.Extensions.GameExt.AddMonkeyMoney(thisGame,double)'></a>

## GameExt.AddMonkeyMoney(this Game, double) Method

Add Monkey Money to player's total Monkey Money

```csharp
public static void AddMonkeyMoney(this Game game, double amount);
```
#### Parameters

<a name='BTD_Mod_Helper.Extensions.GameExt.AddMonkeyMoney(thisGame,double).game'></a>

`game` [Il2CppAssets.Scripts.Unity.Game](https://docs.microsoft.com/en-us/dotnet/api/Il2CppAssets.Scripts.Unity.Game 'Il2CppAssets.Scripts.Unity.Game')

the Game instance

<a name='BTD_Mod_Helper.Extensions.GameExt.AddMonkeyMoney(thisGame,double).amount'></a>

`amount` [System.Double](https://docs.microsoft.com/en-us/dotnet/api/System.Double 'System.Double')

Amount to add

<a name='BTD_Mod_Helper.Extensions.GameExt.CanGetFlagged(thisGame)'></a>

## GameExt.CanGetFlagged(this Game) Method

Checks if Player is in a game mode that would get them flagged if using mods

```csharp
public static bool CanGetFlagged(this Game game);
```
#### Parameters

<a name='BTD_Mod_Helper.Extensions.GameExt.CanGetFlagged(thisGame).game'></a>

`game` [Il2CppAssets.Scripts.Unity.Game](https://docs.microsoft.com/en-us/dotnet/api/Il2CppAssets.Scripts.Unity.Game 'Il2CppAssets.Scripts.Unity.Game')

#### Returns
[System.Boolean](https://docs.microsoft.com/en-us/dotnet/api/System.Boolean 'System.Boolean')

<a name='BTD_Mod_Helper.Extensions.GameExt.CreateSpriteReference(thisGame,string)'></a>

## GameExt.CreateSpriteReference(this Game, string) Method

Returns a new SpriteReference that uses the given guid

```csharp
public static SpriteReference CreateSpriteReference(this Game game, string guid);
```
#### Parameters

<a name='BTD_Mod_Helper.Extensions.GameExt.CreateSpriteReference(thisGame,string).game'></a>

`game` [Il2CppAssets.Scripts.Unity.Game](https://docs.microsoft.com/en-us/dotnet/api/Il2CppAssets.Scripts.Unity.Game 'Il2CppAssets.Scripts.Unity.Game')

<a name='BTD_Mod_Helper.Extensions.GameExt.CreateSpriteReference(thisGame,string).guid'></a>

`guid` [System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')

#### Returns
[Il2CppAssets.Scripts.Utils.SpriteReference](https://docs.microsoft.com/en-us/dotnet/api/Il2CppAssets.Scripts.Utils.SpriteReference 'Il2CppAssets.Scripts.Utils.SpriteReference')

<a name='BTD_Mod_Helper.Extensions.GameExt.GetBtd6Player(thisGame)'></a>

## GameExt.GetBtd6Player(this Game) Method

Get the Btd6Player data for the player. Contains different info than PlayerProfile

```csharp
public static Btd6Player GetBtd6Player(this Game game);
```
#### Parameters

<a name='BTD_Mod_Helper.Extensions.GameExt.GetBtd6Player(thisGame).game'></a>

`game` [Il2CppAssets.Scripts.Unity.Game](https://docs.microsoft.com/en-us/dotnet/api/Il2CppAssets.Scripts.Unity.Game 'Il2CppAssets.Scripts.Unity.Game')

#### Returns
[Il2CppAssets.Scripts.Unity.Player.Btd6Player](https://docs.microsoft.com/en-us/dotnet/api/Il2CppAssets.Scripts.Unity.Player.Btd6Player 'Il2CppAssets.Scripts.Unity.Player.Btd6Player')

<a name='BTD_Mod_Helper.Extensions.GameExt.GetCommonBackgroundScreen(thisGame)'></a>

## GameExt.GetCommonBackgroundScreen(this Game) Method

Get the instance of CommonBackgroundScreen

```csharp
public static CommonBackgroundScreen GetCommonBackgroundScreen(this Game game);
```
#### Parameters

<a name='BTD_Mod_Helper.Extensions.GameExt.GetCommonBackgroundScreen(thisGame).game'></a>

`game` [Il2CppAssets.Scripts.Unity.Game](https://docs.microsoft.com/en-us/dotnet/api/Il2CppAssets.Scripts.Unity.Game 'Il2CppAssets.Scripts.Unity.Game')

#### Returns
[Il2CppAssets.Scripts.Unity.UI_New.CommonBackgroundScreen](https://docs.microsoft.com/en-us/dotnet/api/Il2CppAssets.Scripts.Unity.UI_New.CommonBackgroundScreen 'Il2CppAssets.Scripts.Unity.UI_New.CommonBackgroundScreen')

<a name='BTD_Mod_Helper.Extensions.GameExt.GetCommonForegroundScreen(thisGame)'></a>

## GameExt.GetCommonForegroundScreen(this Game) Method

Get the instance of CommonForegroundScreen

```csharp
public static CommonForegroundScreen GetCommonForegroundScreen(this Game game);
```
#### Parameters

<a name='BTD_Mod_Helper.Extensions.GameExt.GetCommonForegroundScreen(thisGame).game'></a>

`game` [Il2CppAssets.Scripts.Unity.Game](https://docs.microsoft.com/en-us/dotnet/api/Il2CppAssets.Scripts.Unity.Game 'Il2CppAssets.Scripts.Unity.Game')

#### Returns
[Il2CppAssets.Scripts.Unity.UI_New.CommonForegroundScreen](https://docs.microsoft.com/en-us/dotnet/api/Il2CppAssets.Scripts.Unity.UI_New.CommonForegroundScreen 'Il2CppAssets.Scripts.Unity.UI_New.CommonForegroundScreen')

<a name='BTD_Mod_Helper.Extensions.GameExt.GetCoopLobbyConnection(thisGame)'></a>

## GameExt.GetCoopLobbyConnection(this Game) Method

Returns the current lobby connection.

```csharp
public static LobbyConnection GetCoopLobbyConnection(this Game game);
```
#### Parameters

<a name='BTD_Mod_Helper.Extensions.GameExt.GetCoopLobbyConnection(thisGame).game'></a>

`game` [Il2CppAssets.Scripts.Unity.Game](https://docs.microsoft.com/en-us/dotnet/api/Il2CppAssets.Scripts.Unity.Game 'Il2CppAssets.Scripts.Unity.Game')

#### Returns
[Il2CppNinjaKiwi.LiNK.Lobbies.LobbyConnection](https://docs.microsoft.com/en-us/dotnet/api/Il2CppNinjaKiwi.LiNK.Lobbies.LobbyConnection 'Il2CppNinjaKiwi.LiNK.Lobbies.LobbyConnection')

<a name='BTD_Mod_Helper.Extensions.GameExt.GetCoopLobbyScreen(thisGame)'></a>

## GameExt.GetCoopLobbyScreen(this Game) Method

Returns the current lobby screen.

```csharp
public static CoopLobbyScreen GetCoopLobbyScreen(this Game game);
```
#### Parameters

<a name='BTD_Mod_Helper.Extensions.GameExt.GetCoopLobbyScreen(thisGame).game'></a>

`game` [Il2CppAssets.Scripts.Unity.Game](https://docs.microsoft.com/en-us/dotnet/api/Il2CppAssets.Scripts.Unity.Game 'Il2CppAssets.Scripts.Unity.Game')

#### Returns
[Il2CppAssets.Scripts.Unity.UI_New.Coop.CoopLobbyScreen](https://docs.microsoft.com/en-us/dotnet/api/Il2CppAssets.Scripts.Unity.UI_New.Coop.CoopLobbyScreen 'Il2CppAssets.Scripts.Unity.UI_New.Coop.CoopLobbyScreen')

<a name='BTD_Mod_Helper.Extensions.GameExt.GetDisplayFactory(thisGame)'></a>

## GameExt.GetDisplayFactory(this Game) Method

Get the Unity Display Factory that manages on screen sprites. This Factory is different from other Factories in the  
game

```csharp
public static Factory GetDisplayFactory(this Game game);
```
#### Parameters

<a name='BTD_Mod_Helper.Extensions.GameExt.GetDisplayFactory(thisGame).game'></a>

`game` [Il2CppAssets.Scripts.Unity.Game](https://docs.microsoft.com/en-us/dotnet/api/Il2CppAssets.Scripts.Unity.Game 'Il2CppAssets.Scripts.Unity.Game')

#### Returns
[Il2CppAssets.Scripts.Unity.Display.Factory](https://docs.microsoft.com/en-us/dotnet/api/Il2CppAssets.Scripts.Unity.Display.Factory 'Il2CppAssets.Scripts.Unity.Display.Factory')

<a name='BTD_Mod_Helper.Extensions.GameExt.GetHeroDetailModels(thisGame)'></a>

## GameExt.GetHeroDetailModels(this Game) Method

Get all HeroDetailModels

```csharp
public static Il2CppReferenceArray<TowerDetailsModel> GetHeroDetailModels(this Game game);
```
#### Parameters

<a name='BTD_Mod_Helper.Extensions.GameExt.GetHeroDetailModels(thisGame).game'></a>

`game` [Il2CppAssets.Scripts.Unity.Game](https://docs.microsoft.com/en-us/dotnet/api/Il2CppAssets.Scripts.Unity.Game 'Il2CppAssets.Scripts.Unity.Game')

#### Returns
[Il2CppInterop.Runtime.InteropTypes.Arrays.Il2CppReferenceArray](https://docs.microsoft.com/en-us/dotnet/api/Il2CppInterop.Runtime.InteropTypes.Arrays.Il2CppReferenceArray 'Il2CppInterop.Runtime.InteropTypes.Arrays.Il2CppReferenceArray')

<a name='BTD_Mod_Helper.Extensions.GameExt.GetLocalizationManager(thisGame)'></a>

## GameExt.GetLocalizationManager(this Game) Method

Get the instance of LocalizationManager

```csharp
public static LocalizationManager GetLocalizationManager(this Game game);
```
#### Parameters

<a name='BTD_Mod_Helper.Extensions.GameExt.GetLocalizationManager(thisGame).game'></a>

`game` [Il2CppAssets.Scripts.Unity.Game](https://docs.microsoft.com/en-us/dotnet/api/Il2CppAssets.Scripts.Unity.Game 'Il2CppAssets.Scripts.Unity.Game')

#### Returns
[Il2CppNinjaKiwi.Common.LocalizationManager](https://docs.microsoft.com/en-us/dotnet/api/Il2CppNinjaKiwi.Common.LocalizationManager 'Il2CppNinjaKiwi.Common.LocalizationManager')

<a name='BTD_Mod_Helper.Extensions.GameExt.GetMapLoader(thisGame)'></a>

## GameExt.GetMapLoader(this Game) Method

Returns the instance of the Map Loader.

```csharp
public static MapLoader GetMapLoader(this Game game);
```
#### Parameters

<a name='BTD_Mod_Helper.Extensions.GameExt.GetMapLoader(thisGame).game'></a>

`game` [Il2CppAssets.Scripts.Unity.Game](https://docs.microsoft.com/en-us/dotnet/api/Il2CppAssets.Scripts.Unity.Game 'Il2CppAssets.Scripts.Unity.Game')

#### Returns
[Il2CppAssets.Scripts.Unity.Map.MapLoader](https://docs.microsoft.com/en-us/dotnet/api/Il2CppAssets.Scripts.Unity.Map.MapLoader 'Il2CppAssets.Scripts.Unity.Map.MapLoader')

<a name='BTD_Mod_Helper.Extensions.GameExt.GetMenuManager(thisGame)'></a>

## GameExt.GetMenuManager(this Game) Method

Get the instance of MenuManager

```csharp
public static MenuManager GetMenuManager(this Game game);
```
#### Parameters

<a name='BTD_Mod_Helper.Extensions.GameExt.GetMenuManager(thisGame).game'></a>

`game` [Il2CppAssets.Scripts.Unity.Game](https://docs.microsoft.com/en-us/dotnet/api/Il2CppAssets.Scripts.Unity.Game 'Il2CppAssets.Scripts.Unity.Game')

#### Returns
[Il2CppAssets.Scripts.Unity.Menu.MenuManager](https://docs.microsoft.com/en-us/dotnet/api/Il2CppAssets.Scripts.Unity.Menu.MenuManager 'Il2CppAssets.Scripts.Unity.Menu.MenuManager')

<a name='BTD_Mod_Helper.Extensions.GameExt.GetModel(thisGame)'></a>

## GameExt.GetModel(this Game) Method

Get GameModel. Same as using Game.instance.model

```csharp
public static GameModel GetModel(this Game game);
```
#### Parameters

<a name='BTD_Mod_Helper.Extensions.GameExt.GetModel(thisGame).game'></a>

`game` [Il2CppAssets.Scripts.Unity.Game](https://docs.microsoft.com/en-us/dotnet/api/Il2CppAssets.Scripts.Unity.Game 'Il2CppAssets.Scripts.Unity.Game')

#### Returns
[Il2CppAssets.Scripts.Models.GameModel](https://docs.microsoft.com/en-us/dotnet/api/Il2CppAssets.Scripts.Models.GameModel 'Il2CppAssets.Scripts.Models.GameModel')

<a name='BTD_Mod_Helper.Extensions.GameExt.GetMonkeyMoney(thisGame)'></a>

## GameExt.GetMonkeyMoney(this Game) Method

Get player's current Monkey Money amount

```csharp
public static double GetMonkeyMoney(this Game game);
```
#### Parameters

<a name='BTD_Mod_Helper.Extensions.GameExt.GetMonkeyMoney(thisGame).game'></a>

`game` [Il2CppAssets.Scripts.Unity.Game](https://docs.microsoft.com/en-us/dotnet/api/Il2CppAssets.Scripts.Unity.Game 'Il2CppAssets.Scripts.Unity.Game')

#### Returns
[System.Double](https://docs.microsoft.com/en-us/dotnet/api/System.Double 'System.Double')

<a name='BTD_Mod_Helper.Extensions.GameExt.GetNkGI(thisGame)'></a>

## GameExt.GetNkGI(this Game) Method

Get nkGI for the current session. Will be null if not in multiplayer game or lobby

```csharp
public static NKMultiGameInterface GetNkGI(this Game game);
```
#### Parameters

<a name='BTD_Mod_Helper.Extensions.GameExt.GetNkGI(thisGame).game'></a>

`game` [Il2CppAssets.Scripts.Unity.Game](https://docs.microsoft.com/en-us/dotnet/api/Il2CppAssets.Scripts.Unity.Game 'Il2CppAssets.Scripts.Unity.Game')

#### Returns
[Il2CppNinjaKiwi.NKMulti.NKMultiGameInterface](https://docs.microsoft.com/en-us/dotnet/api/Il2CppNinjaKiwi.NKMulti.NKMultiGameInterface 'Il2CppNinjaKiwi.NKMulti.NKMultiGameInterface')

<a name='BTD_Mod_Helper.Extensions.GameExt.GetPlayerLiNKAccount(thisGame)'></a>

## GameExt.GetPlayerLiNKAccount(this Game) Method

Get Player LinkAccount. Contains limited info about player's NinjaKiwi account

```csharp
public static LiNKAccount GetPlayerLiNKAccount(this Game game);
```
#### Parameters

<a name='BTD_Mod_Helper.Extensions.GameExt.GetPlayerLiNKAccount(thisGame).game'></a>

`game` [Il2CppAssets.Scripts.Unity.Game](https://docs.microsoft.com/en-us/dotnet/api/Il2CppAssets.Scripts.Unity.Game 'Il2CppAssets.Scripts.Unity.Game')

#### Returns
[Il2CppNinjaKiwi.LiNK.LiNKAccount](https://docs.microsoft.com/en-us/dotnet/api/Il2CppNinjaKiwi.LiNK.LiNKAccount 'Il2CppNinjaKiwi.LiNK.LiNKAccount')

<a name='BTD_Mod_Helper.Extensions.GameExt.GetPlayerProfile(thisGame)'></a>

## GameExt.GetPlayerProfile(this Game) Method

Get the ProfileModel for the Player

```csharp
public static ProfileModel GetPlayerProfile(this Game game);
```
#### Parameters

<a name='BTD_Mod_Helper.Extensions.GameExt.GetPlayerProfile(thisGame).game'></a>

`game` [Il2CppAssets.Scripts.Unity.Game](https://docs.microsoft.com/en-us/dotnet/api/Il2CppAssets.Scripts.Unity.Game 'Il2CppAssets.Scripts.Unity.Game')

#### Returns
[Il2CppAssets.Scripts.Models.Profile.ProfileModel](https://docs.microsoft.com/en-us/dotnet/api/Il2CppAssets.Scripts.Models.Profile.ProfileModel 'Il2CppAssets.Scripts.Models.Profile.ProfileModel')

<a name='BTD_Mod_Helper.Extensions.GameExt.GetPlayerService(thisGame)'></a>

## GameExt.GetPlayerService(this Game) Method

Get the PlayerService for the player

```csharp
public static PlayerService GetPlayerService(this Game game);
```
#### Parameters

<a name='BTD_Mod_Helper.Extensions.GameExt.GetPlayerService(thisGame).game'></a>

`game` [Il2CppAssets.Scripts.Unity.Game](https://docs.microsoft.com/en-us/dotnet/api/Il2CppAssets.Scripts.Unity.Game 'Il2CppAssets.Scripts.Unity.Game')

#### Returns
[Il2CppAssets.Scripts.Unity.Player.PlayerService](https://docs.microsoft.com/en-us/dotnet/api/Il2CppAssets.Scripts.Unity.Player.PlayerService 'Il2CppAssets.Scripts.Unity.Player.PlayerService')

<a name='BTD_Mod_Helper.Extensions.GameExt.GetPopupScreen(thisGame)'></a>

## GameExt.GetPopupScreen(this Game) Method

Get the instance of PopupScreen

```csharp
public static PopupScreen GetPopupScreen(this Game game);
```
#### Parameters

<a name='BTD_Mod_Helper.Extensions.GameExt.GetPopupScreen(thisGame).game'></a>

`game` [Il2CppAssets.Scripts.Unity.Game](https://docs.microsoft.com/en-us/dotnet/api/Il2CppAssets.Scripts.Unity.Game 'Il2CppAssets.Scripts.Unity.Game')

#### Returns
[Il2CppAssets.Scripts.Unity.UI_New.Popups.PopupScreen](https://docs.microsoft.com/en-us/dotnet/api/Il2CppAssets.Scripts.Unity.UI_New.Popups.PopupScreen 'Il2CppAssets.Scripts.Unity.UI_New.Popups.PopupScreen')

<a name='BTD_Mod_Helper.Extensions.GameExt.GetPowerDetailModels(thisGame)'></a>

## GameExt.GetPowerDetailModels(this Game) Method

Get all PowerDetailModels

```csharp
public static Il2CppReferenceArray<PowerDetailsModel> GetPowerDetailModels(this Game game);
```
#### Parameters

<a name='BTD_Mod_Helper.Extensions.GameExt.GetPowerDetailModels(thisGame).game'></a>

`game` [Il2CppAssets.Scripts.Unity.Game](https://docs.microsoft.com/en-us/dotnet/api/Il2CppAssets.Scripts.Unity.Game 'Il2CppAssets.Scripts.Unity.Game')

#### Returns
[Il2CppInterop.Runtime.InteropTypes.Arrays.Il2CppReferenceArray](https://docs.microsoft.com/en-us/dotnet/api/Il2CppInterop.Runtime.InteropTypes.Arrays.Il2CppReferenceArray 'Il2CppInterop.Runtime.InteropTypes.Arrays.Il2CppReferenceArray')

<a name='BTD_Mod_Helper.Extensions.GameExt.GetSaveDirectory(thisGame)'></a>

## GameExt.GetSaveDirectory(this Game) Method

Returns the directory where the Player's Profile.save file is located.  
Not set until after reaching the Main Menu for the first time

```csharp
public static string GetSaveDirectory(this Game game);
```
#### Parameters

<a name='BTD_Mod_Helper.Extensions.GameExt.GetSaveDirectory(thisGame).game'></a>

`game` [Il2CppAssets.Scripts.Unity.Game](https://docs.microsoft.com/en-us/dotnet/api/Il2CppAssets.Scripts.Unity.Game 'Il2CppAssets.Scripts.Unity.Game')

#### Returns
[System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')

<a name='BTD_Mod_Helper.Extensions.GameExt.GetShopMenu(thisGame)'></a>

## GameExt.GetShopMenu(this Game) Method

Get the instance of ShopMenu

```csharp
public static ShopMenu GetShopMenu(this Game game);
```
#### Parameters

<a name='BTD_Mod_Helper.Extensions.GameExt.GetShopMenu(thisGame).game'></a>

`game` [Il2CppAssets.Scripts.Unity.Game](https://docs.microsoft.com/en-us/dotnet/api/Il2CppAssets.Scripts.Unity.Game 'Il2CppAssets.Scripts.Unity.Game')

#### Returns
[Il2CppAssets.Scripts.Unity.UI_New.InGame.RightMenu.ShopMenu](https://docs.microsoft.com/en-us/dotnet/api/Il2CppAssets.Scripts.Unity.UI_New.InGame.RightMenu.ShopMenu 'Il2CppAssets.Scripts.Unity.UI_New.InGame.RightMenu.ShopMenu')

<a name='BTD_Mod_Helper.Extensions.GameExt.GetTowerDetailModels(thisGame)'></a>

## GameExt.GetTowerDetailModels(this Game) Method

Get all TowerDetailModels

```csharp
public static Il2CppReferenceArray<TowerDetailsModel> GetTowerDetailModels(this Game game);
```
#### Parameters

<a name='BTD_Mod_Helper.Extensions.GameExt.GetTowerDetailModels(thisGame).game'></a>

`game` [Il2CppAssets.Scripts.Unity.Game](https://docs.microsoft.com/en-us/dotnet/api/Il2CppAssets.Scripts.Unity.Game 'Il2CppAssets.Scripts.Unity.Game')

#### Returns
[Il2CppInterop.Runtime.InteropTypes.Arrays.Il2CppReferenceArray](https://docs.microsoft.com/en-us/dotnet/api/Il2CppInterop.Runtime.InteropTypes.Arrays.Il2CppReferenceArray 'Il2CppInterop.Runtime.InteropTypes.Arrays.Il2CppReferenceArray')

<a name='BTD_Mod_Helper.Extensions.GameExt.GetTowerListForTowerType(thisGame,TowerSet)'></a>

## GameExt.GetTowerListForTowerType(this Game, TowerSet) Method

Not tested

```csharp
public static System.Collections.Generic.List<TowerModel> GetTowerListForTowerType(this Game game, TowerSet towerSet);
```
#### Parameters

<a name='BTD_Mod_Helper.Extensions.GameExt.GetTowerListForTowerType(thisGame,TowerSet).game'></a>

`game` [Il2CppAssets.Scripts.Unity.Game](https://docs.microsoft.com/en-us/dotnet/api/Il2CppAssets.Scripts.Unity.Game 'Il2CppAssets.Scripts.Unity.Game')

<a name='BTD_Mod_Helper.Extensions.GameExt.GetTowerListForTowerType(thisGame,TowerSet).towerSet'></a>

`towerSet` [Il2CppAssets.Scripts.Models.TowerSets.TowerSet](https://docs.microsoft.com/en-us/dotnet/api/Il2CppAssets.Scripts.Models.TowerSets.TowerSet 'Il2CppAssets.Scripts.Models.TowerSets.TowerSet')

#### Returns
[System.Collections.Generic.List&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.List-1 'System.Collections.Generic.List`1')[Il2CppAssets.Scripts.Models.Towers.TowerModel](https://docs.microsoft.com/en-us/dotnet/api/Il2CppAssets.Scripts.Models.Towers.TowerModel 'Il2CppAssets.Scripts.Models.Towers.TowerModel')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.List-1 'System.Collections.Generic.List`1')

<a name='BTD_Mod_Helper.Extensions.GameExt.GetUI(thisGame)'></a>

## GameExt.GetUI(this Game) Method

Get the instance of UI

```csharp
public static UI GetUI(this Game game);
```
#### Parameters

<a name='BTD_Mod_Helper.Extensions.GameExt.GetUI(thisGame).game'></a>

`game` [Il2CppAssets.Scripts.Unity.Game](https://docs.microsoft.com/en-us/dotnet/api/Il2CppAssets.Scripts.Unity.Game 'Il2CppAssets.Scripts.Unity.Game')

#### Returns
[Il2CppAssets.Scripts.Unity.UI_New.UI](https://docs.microsoft.com/en-us/dotnet/api/Il2CppAssets.Scripts.Unity.UI_New.UI 'Il2CppAssets.Scripts.Unity.UI_New.UI')

<a name='BTD_Mod_Helper.Extensions.GameExt.IsAccountFlagged(thisGame)'></a>

## GameExt.IsAccountFlagged(this Game) Method

Returns whether or not the player's account is currently flagged/hackerpooled

```csharp
public static bool IsAccountFlagged(this Game game);
```
#### Parameters

<a name='BTD_Mod_Helper.Extensions.GameExt.IsAccountFlagged(thisGame).game'></a>

`game` [Il2CppAssets.Scripts.Unity.Game](https://docs.microsoft.com/en-us/dotnet/api/Il2CppAssets.Scripts.Unity.Game 'Il2CppAssets.Scripts.Unity.Game')

#### Returns
[System.Boolean](https://docs.microsoft.com/en-us/dotnet/api/System.Boolean 'System.Boolean')

<a name='BTD_Mod_Helper.Extensions.GameExt.IsInOdyssey(thisGame)'></a>

## GameExt.IsInOdyssey(this Game) Method

Returns if Player is in a Odyssey game

```csharp
public static bool IsInOdyssey(this Game game);
```
#### Parameters

<a name='BTD_Mod_Helper.Extensions.GameExt.IsInOdyssey(thisGame).game'></a>

`game` [Il2CppAssets.Scripts.Unity.Game](https://docs.microsoft.com/en-us/dotnet/api/Il2CppAssets.Scripts.Unity.Game 'Il2CppAssets.Scripts.Unity.Game')

#### Returns
[System.Boolean](https://docs.microsoft.com/en-us/dotnet/api/System.Boolean 'System.Boolean')

<a name='BTD_Mod_Helper.Extensions.GameExt.IsInPublicCoop(thisGame)'></a>

## GameExt.IsInPublicCoop(this Game) Method

Returns if Player is in a public co-op match

```csharp
public static bool IsInPublicCoop(this Game game);
```
#### Parameters

<a name='BTD_Mod_Helper.Extensions.GameExt.IsInPublicCoop(thisGame).game'></a>

`game` [Il2CppAssets.Scripts.Unity.Game](https://docs.microsoft.com/en-us/dotnet/api/Il2CppAssets.Scripts.Unity.Game 'Il2CppAssets.Scripts.Unity.Game')

#### Returns
[System.Boolean](https://docs.microsoft.com/en-us/dotnet/api/System.Boolean 'System.Boolean')

<a name='BTD_Mod_Helper.Extensions.GameExt.IsInRace(thisGame)'></a>

## GameExt.IsInRace(this Game) Method

Returns if Player is in a race

```csharp
public static bool IsInRace(this Game game);
```
#### Parameters

<a name='BTD_Mod_Helper.Extensions.GameExt.IsInRace(thisGame).game'></a>

`game` [Il2CppAssets.Scripts.Unity.Game](https://docs.microsoft.com/en-us/dotnet/api/Il2CppAssets.Scripts.Unity.Game 'Il2CppAssets.Scripts.Unity.Game')

#### Returns
[System.Boolean](https://docs.microsoft.com/en-us/dotnet/api/System.Boolean 'System.Boolean')

<a name='BTD_Mod_Helper.Extensions.GameExt.SavePlayerData(thisGame,string)'></a>

## GameExt.SavePlayerData(this Game, string) Method

Makes a save of Player.Save at the specified path

```csharp
public static void SavePlayerData(this Game game, string savePath);
```
#### Parameters

<a name='BTD_Mod_Helper.Extensions.GameExt.SavePlayerData(thisGame,string).game'></a>

`game` [Il2CppAssets.Scripts.Unity.Game](https://docs.microsoft.com/en-us/dotnet/api/Il2CppAssets.Scripts.Unity.Game 'Il2CppAssets.Scripts.Unity.Game')

<a name='BTD_Mod_Helper.Extensions.GameExt.SavePlayerData(thisGame,string).savePath'></a>

`savePath` [System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')

Path to save to

<a name='BTD_Mod_Helper.Extensions.GameExt.ScheduleTask(thisGame,System.Action,BTD_Mod_Helper.Api.Enums.ScheduleType,int,System.Func_bool_)'></a>

## GameExt.ScheduleTask(this Game, Action, ScheduleType, int, Func<bool>) Method

Schedule a task to execute later on as a Coroutine

```csharp
public static void ScheduleTask(this Game game, System.Action action, BTD_Mod_Helper.Api.Enums.ScheduleType scheduleType, int amountToWait, System.Func<bool> waitCondition=null);
```
#### Parameters

<a name='BTD_Mod_Helper.Extensions.GameExt.ScheduleTask(thisGame,System.Action,BTD_Mod_Helper.Api.Enums.ScheduleType,int,System.Func_bool_).game'></a>

`game` [Il2CppAssets.Scripts.Unity.Game](https://docs.microsoft.com/en-us/dotnet/api/Il2CppAssets.Scripts.Unity.Game 'Il2CppAssets.Scripts.Unity.Game')

<a name='BTD_Mod_Helper.Extensions.GameExt.ScheduleTask(thisGame,System.Action,BTD_Mod_Helper.Api.Enums.ScheduleType,int,System.Func_bool_).action'></a>

`action` [System.Action](https://docs.microsoft.com/en-us/dotnet/api/System.Action 'System.Action')

The action you want to execute once it's time to run your task

<a name='BTD_Mod_Helper.Extensions.GameExt.ScheduleTask(thisGame,System.Action,BTD_Mod_Helper.Api.Enums.ScheduleType,int,System.Func_bool_).scheduleType'></a>

`scheduleType` [ScheduleType](BTD_Mod_Helper.Api.Enums.ScheduleType.md 'BTD_Mod_Helper.Api.Enums.ScheduleType')

How you want to wait for your task

<a name='BTD_Mod_Helper.Extensions.GameExt.ScheduleTask(thisGame,System.Action,BTD_Mod_Helper.Api.Enums.ScheduleType,int,System.Func_bool_).amountToWait'></a>

`amountToWait` [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/System.Int32 'System.Int32')

The amount you want to wait

<a name='BTD_Mod_Helper.Extensions.GameExt.ScheduleTask(thisGame,System.Action,BTD_Mod_Helper.Api.Enums.ScheduleType,int,System.Func_bool_).waitCondition'></a>

`waitCondition` [System.Func&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Func-1 'System.Func`1')[System.Boolean](https://docs.microsoft.com/en-us/dotnet/api/System.Boolean 'System.Boolean')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Func-1 'System.Func`1')

Wait for this to be true before executing task

<a name='BTD_Mod_Helper.Extensions.GameExt.ScheduleTask(thisGame,System.Action,System.Func_bool_)'></a>

## GameExt.ScheduleTask(this Game, Action, Func<bool>) Method

Schedule a task to execute later on as a Coroutine. By default will wait until the end of this current frame

```csharp
public static void ScheduleTask(this Game game, System.Action action, System.Func<bool> waitCondition=null);
```
#### Parameters

<a name='BTD_Mod_Helper.Extensions.GameExt.ScheduleTask(thisGame,System.Action,System.Func_bool_).game'></a>

`game` [Il2CppAssets.Scripts.Unity.Game](https://docs.microsoft.com/en-us/dotnet/api/Il2CppAssets.Scripts.Unity.Game 'Il2CppAssets.Scripts.Unity.Game')

<a name='BTD_Mod_Helper.Extensions.GameExt.ScheduleTask(thisGame,System.Action,System.Func_bool_).action'></a>

`action` [System.Action](https://docs.microsoft.com/en-us/dotnet/api/System.Action 'System.Action')

The action you want to execute once it's time to run your task

<a name='BTD_Mod_Helper.Extensions.GameExt.ScheduleTask(thisGame,System.Action,System.Func_bool_).waitCondition'></a>

`waitCondition` [System.Func&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Func-1 'System.Func`1')[System.Boolean](https://docs.microsoft.com/en-us/dotnet/api/System.Boolean 'System.Boolean')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Func-1 'System.Func`1')

Wait for this to be true before executing task

<a name='BTD_Mod_Helper.Extensions.GameExt.ScheduleTask(thisGame,System.Collections.IEnumerator)'></a>

## GameExt.ScheduleTask(this Game, IEnumerator) Method

Schedule a task to execute right now as a Coroutine

```csharp
public static void ScheduleTask(this Game game, System.Collections.IEnumerator iEnumerator);
```
#### Parameters

<a name='BTD_Mod_Helper.Extensions.GameExt.ScheduleTask(thisGame,System.Collections.IEnumerator).game'></a>

`game` [Il2CppAssets.Scripts.Unity.Game](https://docs.microsoft.com/en-us/dotnet/api/Il2CppAssets.Scripts.Unity.Game 'Il2CppAssets.Scripts.Unity.Game')

<a name='BTD_Mod_Helper.Extensions.GameExt.ScheduleTask(thisGame,System.Collections.IEnumerator).iEnumerator'></a>

`iEnumerator` [System.Collections.IEnumerator](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.IEnumerator 'System.Collections.IEnumerator')

<a name='BTD_Mod_Helper.Extensions.GameExt.SetMonkeyMoney(thisGame,double)'></a>

## GameExt.SetMonkeyMoney(this Game, double) Method

Set player's Monkey Money amount

```csharp
public static void SetMonkeyMoney(this Game game, double amount);
```
#### Parameters

<a name='BTD_Mod_Helper.Extensions.GameExt.SetMonkeyMoney(thisGame,double).game'></a>

`game` [Il2CppAssets.Scripts.Unity.Game](https://docs.microsoft.com/en-us/dotnet/api/Il2CppAssets.Scripts.Unity.Game 'Il2CppAssets.Scripts.Unity.Game')

the Game instance

<a name='BTD_Mod_Helper.Extensions.GameExt.SetMonkeyMoney(thisGame,double).amount'></a>

`amount` [System.Double](https://docs.microsoft.com/en-us/dotnet/api/System.Double 'System.Double')

Value to set Monkey Money to

<a name='BTD_Mod_Helper.Extensions.GameExt.ShowMessage(thisGame,string,float,string)'></a>

## GameExt.ShowMessage(this Game, string, float, string) Method

Uses custom message popup to show a message in game. Currently only works in active game sessions and not on Main Menu

```csharp
public static void ShowMessage(this Game game, string message, float displayTime, string title);
```
#### Parameters

<a name='BTD_Mod_Helper.Extensions.GameExt.ShowMessage(thisGame,string,float,string).game'></a>

`game` [Il2CppAssets.Scripts.Unity.Game](https://docs.microsoft.com/en-us/dotnet/api/Il2CppAssets.Scripts.Unity.Game 'Il2CppAssets.Scripts.Unity.Game')

the Game instance

<a name='BTD_Mod_Helper.Extensions.GameExt.ShowMessage(thisGame,string,float,string).message'></a>

`message` [System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')

Message body

<a name='BTD_Mod_Helper.Extensions.GameExt.ShowMessage(thisGame,string,float,string).displayTime'></a>

`displayTime` [System.Single](https://docs.microsoft.com/en-us/dotnet/api/System.Single 'System.Single')

Time to show message on screen

<a name='BTD_Mod_Helper.Extensions.GameExt.ShowMessage(thisGame,string,float,string).title'></a>

`title` [System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')

Message title. Will be mod name by default

<a name='BTD_Mod_Helper.Extensions.GameExt.ShowMessage(thisGame,string,string)'></a>

## GameExt.ShowMessage(this Game, string, string) Method

Uses custom message popup to show a message in game. Currently only works in active game sessions and not on Main Menu

```csharp
public static void ShowMessage(this Game game, string message, string title);
```
#### Parameters

<a name='BTD_Mod_Helper.Extensions.GameExt.ShowMessage(thisGame,string,string).game'></a>

`game` [Il2CppAssets.Scripts.Unity.Game](https://docs.microsoft.com/en-us/dotnet/api/Il2CppAssets.Scripts.Unity.Game 'Il2CppAssets.Scripts.Unity.Game')

the Game instance

<a name='BTD_Mod_Helper.Extensions.GameExt.ShowMessage(thisGame,string,string).message'></a>

`message` [System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')

Message body

<a name='BTD_Mod_Helper.Extensions.GameExt.ShowMessage(thisGame,string,string).title'></a>

`title` [System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')

Message title. Will be mod name by default