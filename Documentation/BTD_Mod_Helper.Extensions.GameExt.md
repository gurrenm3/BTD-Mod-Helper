#### [BloonsTD6 Mod Helper](README.md 'README')
### [BTD_Mod_Helper.Extensions](README.md#BTD_Mod_Helper.Extensions 'BTD_Mod_Helper.Extensions')

## GameExt Class

Extensions for Game

```csharp
public static class GameExt
```

Inheritance [System.Object](https://docs.microsoft.com/en-us/dotnet/api/System.Object 'System.Object') &#129106; GameExt
### Methods

<a name='BTD_Mod_Helper.Extensions.GameExt.AddMonkeyMoney(thisAssets.Scripts.Unity.Game,double)'></a>

## GameExt.AddMonkeyMoney(this Game, double) Method

Add Monkey Money to player's total Monkey Money

```csharp
public static void AddMonkeyMoney(this Assets.Scripts.Unity.Game game, double amount);
```
#### Parameters

<a name='BTD_Mod_Helper.Extensions.GameExt.AddMonkeyMoney(thisAssets.Scripts.Unity.Game,double).game'></a>

`game` [Assets.Scripts.Unity.Game](https://docs.microsoft.com/en-us/dotnet/api/Assets.Scripts.Unity.Game 'Assets.Scripts.Unity.Game')

the Game instance

<a name='BTD_Mod_Helper.Extensions.GameExt.AddMonkeyMoney(thisAssets.Scripts.Unity.Game,double).amount'></a>

`amount` [System.Double](https://docs.microsoft.com/en-us/dotnet/api/System.Double 'System.Double')

Amount to add

<a name='BTD_Mod_Helper.Extensions.GameExt.CanGetFlagged(thisAssets.Scripts.Unity.Game)'></a>

## GameExt.CanGetFlagged(this Game) Method

Checks if Player is in a game mode that would get them flagged if using mods

```csharp
public static bool CanGetFlagged(this Assets.Scripts.Unity.Game game);
```
#### Parameters

<a name='BTD_Mod_Helper.Extensions.GameExt.CanGetFlagged(thisAssets.Scripts.Unity.Game).game'></a>

`game` [Assets.Scripts.Unity.Game](https://docs.microsoft.com/en-us/dotnet/api/Assets.Scripts.Unity.Game 'Assets.Scripts.Unity.Game')

#### Returns
[System.Boolean](https://docs.microsoft.com/en-us/dotnet/api/System.Boolean 'System.Boolean')

<a name='BTD_Mod_Helper.Extensions.GameExt.CreateSpriteReference(thisAssets.Scripts.Unity.Game,string)'></a>

## GameExt.CreateSpriteReference(this Game, string) Method

Returns a new SpriteReference that uses the given guid

```csharp
public static Assets.Scripts.Utils.SpriteReference CreateSpriteReference(this Assets.Scripts.Unity.Game game, string guid);
```
#### Parameters

<a name='BTD_Mod_Helper.Extensions.GameExt.CreateSpriteReference(thisAssets.Scripts.Unity.Game,string).game'></a>

`game` [Assets.Scripts.Unity.Game](https://docs.microsoft.com/en-us/dotnet/api/Assets.Scripts.Unity.Game 'Assets.Scripts.Unity.Game')

<a name='BTD_Mod_Helper.Extensions.GameExt.CreateSpriteReference(thisAssets.Scripts.Unity.Game,string).guid'></a>

`guid` [System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')

#### Returns
[Assets.Scripts.Utils.SpriteReference](https://docs.microsoft.com/en-us/dotnet/api/Assets.Scripts.Utils.SpriteReference 'Assets.Scripts.Utils.SpriteReference')

<a name='BTD_Mod_Helper.Extensions.GameExt.GetBtd6Player(thisAssets.Scripts.Unity.Game)'></a>

## GameExt.GetBtd6Player(this Game) Method

Get the Btd6Player data for the player. Contains different info than PlayerProfile

```csharp
public static Assets.Scripts.Unity.Player.Btd6Player GetBtd6Player(this Assets.Scripts.Unity.Game game);
```
#### Parameters

<a name='BTD_Mod_Helper.Extensions.GameExt.GetBtd6Player(thisAssets.Scripts.Unity.Game).game'></a>

`game` [Assets.Scripts.Unity.Game](https://docs.microsoft.com/en-us/dotnet/api/Assets.Scripts.Unity.Game 'Assets.Scripts.Unity.Game')

#### Returns
[Assets.Scripts.Unity.Player.Btd6Player](https://docs.microsoft.com/en-us/dotnet/api/Assets.Scripts.Unity.Player.Btd6Player 'Assets.Scripts.Unity.Player.Btd6Player')

<a name='BTD_Mod_Helper.Extensions.GameExt.GetCommonBackgroundScreen(thisAssets.Scripts.Unity.Game)'></a>

## GameExt.GetCommonBackgroundScreen(this Game) Method

Get the instance of CommonBackgroundScreen

```csharp
public static Assets.Scripts.Unity.UI_New.CommonBackgroundScreen GetCommonBackgroundScreen(this Assets.Scripts.Unity.Game game);
```
#### Parameters

<a name='BTD_Mod_Helper.Extensions.GameExt.GetCommonBackgroundScreen(thisAssets.Scripts.Unity.Game).game'></a>

`game` [Assets.Scripts.Unity.Game](https://docs.microsoft.com/en-us/dotnet/api/Assets.Scripts.Unity.Game 'Assets.Scripts.Unity.Game')

#### Returns
[Assets.Scripts.Unity.UI_New.CommonBackgroundScreen](https://docs.microsoft.com/en-us/dotnet/api/Assets.Scripts.Unity.UI_New.CommonBackgroundScreen 'Assets.Scripts.Unity.UI_New.CommonBackgroundScreen')

<a name='BTD_Mod_Helper.Extensions.GameExt.GetCommonForegroundScreen(thisAssets.Scripts.Unity.Game)'></a>

## GameExt.GetCommonForegroundScreen(this Game) Method

Get the instance of CommonForegroundScreen

```csharp
public static Assets.Scripts.Unity.UI_New.CommonForegroundScreen GetCommonForegroundScreen(this Assets.Scripts.Unity.Game game);
```
#### Parameters

<a name='BTD_Mod_Helper.Extensions.GameExt.GetCommonForegroundScreen(thisAssets.Scripts.Unity.Game).game'></a>

`game` [Assets.Scripts.Unity.Game](https://docs.microsoft.com/en-us/dotnet/api/Assets.Scripts.Unity.Game 'Assets.Scripts.Unity.Game')

#### Returns
[Assets.Scripts.Unity.UI_New.CommonForegroundScreen](https://docs.microsoft.com/en-us/dotnet/api/Assets.Scripts.Unity.UI_New.CommonForegroundScreen 'Assets.Scripts.Unity.UI_New.CommonForegroundScreen')

<a name='BTD_Mod_Helper.Extensions.GameExt.GetCoopLobbyConnection(thisAssets.Scripts.Unity.Game)'></a>

## GameExt.GetCoopLobbyConnection(this Game) Method

Returns the current lobby connection.

```csharp
public static NinjaKiwi.LiNK.Lobbies.LobbyConnection GetCoopLobbyConnection(this Assets.Scripts.Unity.Game game);
```
#### Parameters

<a name='BTD_Mod_Helper.Extensions.GameExt.GetCoopLobbyConnection(thisAssets.Scripts.Unity.Game).game'></a>

`game` [Assets.Scripts.Unity.Game](https://docs.microsoft.com/en-us/dotnet/api/Assets.Scripts.Unity.Game 'Assets.Scripts.Unity.Game')

#### Returns
[NinjaKiwi.LiNK.Lobbies.LobbyConnection](https://docs.microsoft.com/en-us/dotnet/api/NinjaKiwi.LiNK.Lobbies.LobbyConnection 'NinjaKiwi.LiNK.Lobbies.LobbyConnection')

<a name='BTD_Mod_Helper.Extensions.GameExt.GetCoopLobbyScreen(thisAssets.Scripts.Unity.Game)'></a>

## GameExt.GetCoopLobbyScreen(this Game) Method

Returns the current lobby screen.

```csharp
public static Assets.Scripts.Unity.UI_New.Coop.CoopLobbyScreen GetCoopLobbyScreen(this Assets.Scripts.Unity.Game game);
```
#### Parameters

<a name='BTD_Mod_Helper.Extensions.GameExt.GetCoopLobbyScreen(thisAssets.Scripts.Unity.Game).game'></a>

`game` [Assets.Scripts.Unity.Game](https://docs.microsoft.com/en-us/dotnet/api/Assets.Scripts.Unity.Game 'Assets.Scripts.Unity.Game')

#### Returns
[Assets.Scripts.Unity.UI_New.Coop.CoopLobbyScreen](https://docs.microsoft.com/en-us/dotnet/api/Assets.Scripts.Unity.UI_New.Coop.CoopLobbyScreen 'Assets.Scripts.Unity.UI_New.Coop.CoopLobbyScreen')

<a name='BTD_Mod_Helper.Extensions.GameExt.GetDisplayFactory(thisAssets.Scripts.Unity.Game)'></a>

## GameExt.GetDisplayFactory(this Game) Method

Get the Unity Display Factory that manages on screen sprites. This Factory is different from other Factories in the game

```csharp
public static Assets.Scripts.Unity.Display.Factory GetDisplayFactory(this Assets.Scripts.Unity.Game game);
```
#### Parameters

<a name='BTD_Mod_Helper.Extensions.GameExt.GetDisplayFactory(thisAssets.Scripts.Unity.Game).game'></a>

`game` [Assets.Scripts.Unity.Game](https://docs.microsoft.com/en-us/dotnet/api/Assets.Scripts.Unity.Game 'Assets.Scripts.Unity.Game')

#### Returns
[Assets.Scripts.Unity.Display.Factory](https://docs.microsoft.com/en-us/dotnet/api/Assets.Scripts.Unity.Display.Factory 'Assets.Scripts.Unity.Display.Factory')

<a name='BTD_Mod_Helper.Extensions.GameExt.GetHeroDetailModels(thisAssets.Scripts.Unity.Game)'></a>

## GameExt.GetHeroDetailModels(this Game) Method

Get all HeroDetailModels

```csharp
public static UnhollowerBaseLib.Il2CppReferenceArray<Assets.Scripts.Models.TowerSets.TowerDetailsModel> GetHeroDetailModels(this Assets.Scripts.Unity.Game game);
```
#### Parameters

<a name='BTD_Mod_Helper.Extensions.GameExt.GetHeroDetailModels(thisAssets.Scripts.Unity.Game).game'></a>

`game` [Assets.Scripts.Unity.Game](https://docs.microsoft.com/en-us/dotnet/api/Assets.Scripts.Unity.Game 'Assets.Scripts.Unity.Game')

#### Returns
[UnhollowerBaseLib.Il2CppReferenceArray&lt;](https://docs.microsoft.com/en-us/dotnet/api/UnhollowerBaseLib.Il2CppReferenceArray-1 'UnhollowerBaseLib.Il2CppReferenceArray`1')[Assets.Scripts.Models.TowerSets.TowerDetailsModel](https://docs.microsoft.com/en-us/dotnet/api/Assets.Scripts.Models.TowerSets.TowerDetailsModel 'Assets.Scripts.Models.TowerSets.TowerDetailsModel')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/UnhollowerBaseLib.Il2CppReferenceArray-1 'UnhollowerBaseLib.Il2CppReferenceArray`1')

<a name='BTD_Mod_Helper.Extensions.GameExt.GetJsonSerializer(thisAssets.Scripts.Unity.Game)'></a>

## GameExt.GetJsonSerializer(this Game) Method

Gets a Json Serializer. Not necessary but can be useful

```csharp
public static BTD_Mod_Helper.Api.JsonSerializer GetJsonSerializer(this Assets.Scripts.Unity.Game game);
```
#### Parameters

<a name='BTD_Mod_Helper.Extensions.GameExt.GetJsonSerializer(thisAssets.Scripts.Unity.Game).game'></a>

`game` [Assets.Scripts.Unity.Game](https://docs.microsoft.com/en-us/dotnet/api/Assets.Scripts.Unity.Game 'Assets.Scripts.Unity.Game')

#### Returns
[JsonSerializer](BTD_Mod_Helper.Api.JsonSerializer.md 'BTD_Mod_Helper.Api.JsonSerializer')

<a name='BTD_Mod_Helper.Extensions.GameExt.GetLocalizationManager(thisAssets.Scripts.Unity.Game)'></a>

## GameExt.GetLocalizationManager(this Game) Method

Get the instance of LocalizationManager

```csharp
public static NinjaKiwi.Common.LocalizationManager GetLocalizationManager(this Assets.Scripts.Unity.Game game);
```
#### Parameters

<a name='BTD_Mod_Helper.Extensions.GameExt.GetLocalizationManager(thisAssets.Scripts.Unity.Game).game'></a>

`game` [Assets.Scripts.Unity.Game](https://docs.microsoft.com/en-us/dotnet/api/Assets.Scripts.Unity.Game 'Assets.Scripts.Unity.Game')

#### Returns
[NinjaKiwi.Common.LocalizationManager](https://docs.microsoft.com/en-us/dotnet/api/NinjaKiwi.Common.LocalizationManager 'NinjaKiwi.Common.LocalizationManager')

<a name='BTD_Mod_Helper.Extensions.GameExt.GetMapLoader(thisAssets.Scripts.Unity.Game)'></a>

## GameExt.GetMapLoader(this Game) Method

Returns the instance of the Map Loader.

```csharp
public static Assets.Scripts.Unity.Map.MapLoader GetMapLoader(this Assets.Scripts.Unity.Game game);
```
#### Parameters

<a name='BTD_Mod_Helper.Extensions.GameExt.GetMapLoader(thisAssets.Scripts.Unity.Game).game'></a>

`game` [Assets.Scripts.Unity.Game](https://docs.microsoft.com/en-us/dotnet/api/Assets.Scripts.Unity.Game 'Assets.Scripts.Unity.Game')

#### Returns
[Assets.Scripts.Unity.Map.MapLoader](https://docs.microsoft.com/en-us/dotnet/api/Assets.Scripts.Unity.Map.MapLoader 'Assets.Scripts.Unity.Map.MapLoader')

<a name='BTD_Mod_Helper.Extensions.GameExt.GetMenuManager(thisAssets.Scripts.Unity.Game)'></a>

## GameExt.GetMenuManager(this Game) Method

Get the instance of MenuManager

```csharp
public static Assets.Scripts.Unity.Menu.MenuManager GetMenuManager(this Assets.Scripts.Unity.Game game);
```
#### Parameters

<a name='BTD_Mod_Helper.Extensions.GameExt.GetMenuManager(thisAssets.Scripts.Unity.Game).game'></a>

`game` [Assets.Scripts.Unity.Game](https://docs.microsoft.com/en-us/dotnet/api/Assets.Scripts.Unity.Game 'Assets.Scripts.Unity.Game')

#### Returns
[Assets.Scripts.Unity.Menu.MenuManager](https://docs.microsoft.com/en-us/dotnet/api/Assets.Scripts.Unity.Menu.MenuManager 'Assets.Scripts.Unity.Menu.MenuManager')

<a name='BTD_Mod_Helper.Extensions.GameExt.GetModel(thisAssets.Scripts.Unity.Game)'></a>

## GameExt.GetModel(this Game) Method

Get GameModel. Same as using Game.instance.model

```csharp
public static Assets.Scripts.Models.GameModel GetModel(this Assets.Scripts.Unity.Game game);
```
#### Parameters

<a name='BTD_Mod_Helper.Extensions.GameExt.GetModel(thisAssets.Scripts.Unity.Game).game'></a>

`game` [Assets.Scripts.Unity.Game](https://docs.microsoft.com/en-us/dotnet/api/Assets.Scripts.Unity.Game 'Assets.Scripts.Unity.Game')

#### Returns
[Assets.Scripts.Models.GameModel](https://docs.microsoft.com/en-us/dotnet/api/Assets.Scripts.Models.GameModel 'Assets.Scripts.Models.GameModel')

<a name='BTD_Mod_Helper.Extensions.GameExt.GetMonkeyMoney(thisAssets.Scripts.Unity.Game)'></a>

## GameExt.GetMonkeyMoney(this Game) Method

Get player's current Monkey Money amount

```csharp
public static double GetMonkeyMoney(this Assets.Scripts.Unity.Game game);
```
#### Parameters

<a name='BTD_Mod_Helper.Extensions.GameExt.GetMonkeyMoney(thisAssets.Scripts.Unity.Game).game'></a>

`game` [Assets.Scripts.Unity.Game](https://docs.microsoft.com/en-us/dotnet/api/Assets.Scripts.Unity.Game 'Assets.Scripts.Unity.Game')

#### Returns
[System.Double](https://docs.microsoft.com/en-us/dotnet/api/System.Double 'System.Double')

<a name='BTD_Mod_Helper.Extensions.GameExt.GetNkGI(thisAssets.Scripts.Unity.Game)'></a>

## GameExt.GetNkGI(this Game) Method

Get nkGI for the current session. Will be null if not in multiplayer game or lobby

```csharp
public static NinjaKiwi.NKMulti.NKMultiGameInterface GetNkGI(this Assets.Scripts.Unity.Game game);
```
#### Parameters

<a name='BTD_Mod_Helper.Extensions.GameExt.GetNkGI(thisAssets.Scripts.Unity.Game).game'></a>

`game` [Assets.Scripts.Unity.Game](https://docs.microsoft.com/en-us/dotnet/api/Assets.Scripts.Unity.Game 'Assets.Scripts.Unity.Game')

#### Returns
[NinjaKiwi.NKMulti.NKMultiGameInterface](https://docs.microsoft.com/en-us/dotnet/api/NinjaKiwi.NKMulti.NKMultiGameInterface 'NinjaKiwi.NKMulti.NKMultiGameInterface')

<a name='BTD_Mod_Helper.Extensions.GameExt.GetPlayerLiNKAccount(thisAssets.Scripts.Unity.Game)'></a>

## GameExt.GetPlayerLiNKAccount(this Game) Method

Get Player LinkAccount. Contains limited info about player's NinjaKiwi account

```csharp
public static NinjaKiwi.LiNK.LiNKAccount GetPlayerLiNKAccount(this Assets.Scripts.Unity.Game game);
```
#### Parameters

<a name='BTD_Mod_Helper.Extensions.GameExt.GetPlayerLiNKAccount(thisAssets.Scripts.Unity.Game).game'></a>

`game` [Assets.Scripts.Unity.Game](https://docs.microsoft.com/en-us/dotnet/api/Assets.Scripts.Unity.Game 'Assets.Scripts.Unity.Game')

#### Returns
[NinjaKiwi.LiNK.LiNKAccount](https://docs.microsoft.com/en-us/dotnet/api/NinjaKiwi.LiNK.LiNKAccount 'NinjaKiwi.LiNK.LiNKAccount')

<a name='BTD_Mod_Helper.Extensions.GameExt.GetPlayerProfile(thisAssets.Scripts.Unity.Game)'></a>

## GameExt.GetPlayerProfile(this Game) Method

Get the ProfileModel for the Player

```csharp
public static Assets.Scripts.Models.Profile.ProfileModel GetPlayerProfile(this Assets.Scripts.Unity.Game game);
```
#### Parameters

<a name='BTD_Mod_Helper.Extensions.GameExt.GetPlayerProfile(thisAssets.Scripts.Unity.Game).game'></a>

`game` [Assets.Scripts.Unity.Game](https://docs.microsoft.com/en-us/dotnet/api/Assets.Scripts.Unity.Game 'Assets.Scripts.Unity.Game')

#### Returns
[Assets.Scripts.Models.Profile.ProfileModel](https://docs.microsoft.com/en-us/dotnet/api/Assets.Scripts.Models.Profile.ProfileModel 'Assets.Scripts.Models.Profile.ProfileModel')

<a name='BTD_Mod_Helper.Extensions.GameExt.GetPlayerService(thisAssets.Scripts.Unity.Game)'></a>

## GameExt.GetPlayerService(this Game) Method

Get the PlayerService for the player

```csharp
public static Assets.Scripts.Unity.Player.PlayerService GetPlayerService(this Assets.Scripts.Unity.Game game);
```
#### Parameters

<a name='BTD_Mod_Helper.Extensions.GameExt.GetPlayerService(thisAssets.Scripts.Unity.Game).game'></a>

`game` [Assets.Scripts.Unity.Game](https://docs.microsoft.com/en-us/dotnet/api/Assets.Scripts.Unity.Game 'Assets.Scripts.Unity.Game')

#### Returns
[Assets.Scripts.Unity.Player.PlayerService](https://docs.microsoft.com/en-us/dotnet/api/Assets.Scripts.Unity.Player.PlayerService 'Assets.Scripts.Unity.Player.PlayerService')

<a name='BTD_Mod_Helper.Extensions.GameExt.GetPopupScreen(thisAssets.Scripts.Unity.Game)'></a>

## GameExt.GetPopupScreen(this Game) Method

Get the instance of PopupScreen

```csharp
public static Assets.Scripts.Unity.UI_New.Popups.PopupScreen GetPopupScreen(this Assets.Scripts.Unity.Game game);
```
#### Parameters

<a name='BTD_Mod_Helper.Extensions.GameExt.GetPopupScreen(thisAssets.Scripts.Unity.Game).game'></a>

`game` [Assets.Scripts.Unity.Game](https://docs.microsoft.com/en-us/dotnet/api/Assets.Scripts.Unity.Game 'Assets.Scripts.Unity.Game')

#### Returns
[Assets.Scripts.Unity.UI_New.Popups.PopupScreen](https://docs.microsoft.com/en-us/dotnet/api/Assets.Scripts.Unity.UI_New.Popups.PopupScreen 'Assets.Scripts.Unity.UI_New.Popups.PopupScreen')

<a name='BTD_Mod_Helper.Extensions.GameExt.GetPowerDetailModels(thisAssets.Scripts.Unity.Game)'></a>

## GameExt.GetPowerDetailModels(this Game) Method

Get all PowerDetailModels

```csharp
public static UnhollowerBaseLib.Il2CppReferenceArray<Assets.Scripts.Models.PowerSets.PowerDetailsModel> GetPowerDetailModels(this Assets.Scripts.Unity.Game game);
```
#### Parameters

<a name='BTD_Mod_Helper.Extensions.GameExt.GetPowerDetailModels(thisAssets.Scripts.Unity.Game).game'></a>

`game` [Assets.Scripts.Unity.Game](https://docs.microsoft.com/en-us/dotnet/api/Assets.Scripts.Unity.Game 'Assets.Scripts.Unity.Game')

#### Returns
[UnhollowerBaseLib.Il2CppReferenceArray&lt;](https://docs.microsoft.com/en-us/dotnet/api/UnhollowerBaseLib.Il2CppReferenceArray-1 'UnhollowerBaseLib.Il2CppReferenceArray`1')[Assets.Scripts.Models.PowerSets.PowerDetailsModel](https://docs.microsoft.com/en-us/dotnet/api/Assets.Scripts.Models.PowerSets.PowerDetailsModel 'Assets.Scripts.Models.PowerSets.PowerDetailsModel')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/UnhollowerBaseLib.Il2CppReferenceArray-1 'UnhollowerBaseLib.Il2CppReferenceArray`1')

<a name='BTD_Mod_Helper.Extensions.GameExt.GetSaveDirectory(thisAssets.Scripts.Unity.Game)'></a>

## GameExt.GetSaveDirectory(this Game) Method

Returns the directory where the Player's Profile.save file is located.  
Not set until after reaching the Main Menu for the first time

```csharp
public static string GetSaveDirectory(this Assets.Scripts.Unity.Game game);
```
#### Parameters

<a name='BTD_Mod_Helper.Extensions.GameExt.GetSaveDirectory(thisAssets.Scripts.Unity.Game).game'></a>

`game` [Assets.Scripts.Unity.Game](https://docs.microsoft.com/en-us/dotnet/api/Assets.Scripts.Unity.Game 'Assets.Scripts.Unity.Game')

#### Returns
[System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')

<a name='BTD_Mod_Helper.Extensions.GameExt.GetShopMenu(thisAssets.Scripts.Unity.Game)'></a>

## GameExt.GetShopMenu(this Game) Method

Get the instance of ShopMenu

```csharp
public static Assets.Scripts.Unity.UI_New.InGame.RightMenu.ShopMenu GetShopMenu(this Assets.Scripts.Unity.Game game);
```
#### Parameters

<a name='BTD_Mod_Helper.Extensions.GameExt.GetShopMenu(thisAssets.Scripts.Unity.Game).game'></a>

`game` [Assets.Scripts.Unity.Game](https://docs.microsoft.com/en-us/dotnet/api/Assets.Scripts.Unity.Game 'Assets.Scripts.Unity.Game')

#### Returns
[Assets.Scripts.Unity.UI_New.InGame.RightMenu.ShopMenu](https://docs.microsoft.com/en-us/dotnet/api/Assets.Scripts.Unity.UI_New.InGame.RightMenu.ShopMenu 'Assets.Scripts.Unity.UI_New.InGame.RightMenu.ShopMenu')

<a name='BTD_Mod_Helper.Extensions.GameExt.GetTowerDetailModels(thisAssets.Scripts.Unity.Game)'></a>

## GameExt.GetTowerDetailModels(this Game) Method

Get all TowerDetailModels

```csharp
public static UnhollowerBaseLib.Il2CppReferenceArray<Assets.Scripts.Models.TowerSets.TowerDetailsModel> GetTowerDetailModels(this Assets.Scripts.Unity.Game game);
```
#### Parameters

<a name='BTD_Mod_Helper.Extensions.GameExt.GetTowerDetailModels(thisAssets.Scripts.Unity.Game).game'></a>

`game` [Assets.Scripts.Unity.Game](https://docs.microsoft.com/en-us/dotnet/api/Assets.Scripts.Unity.Game 'Assets.Scripts.Unity.Game')

#### Returns
[UnhollowerBaseLib.Il2CppReferenceArray&lt;](https://docs.microsoft.com/en-us/dotnet/api/UnhollowerBaseLib.Il2CppReferenceArray-1 'UnhollowerBaseLib.Il2CppReferenceArray`1')[Assets.Scripts.Models.TowerSets.TowerDetailsModel](https://docs.microsoft.com/en-us/dotnet/api/Assets.Scripts.Models.TowerSets.TowerDetailsModel 'Assets.Scripts.Models.TowerSets.TowerDetailsModel')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/UnhollowerBaseLib.Il2CppReferenceArray-1 'UnhollowerBaseLib.Il2CppReferenceArray`1')

<a name='BTD_Mod_Helper.Extensions.GameExt.GetTowerListForTowerType(thisAssets.Scripts.Unity.Game,string)'></a>

## GameExt.GetTowerListForTowerType(this Game, string) Method

Not tested

```csharp
public static System.Collections.Generic.List<Assets.Scripts.Models.Towers.TowerModel> GetTowerListForTowerType(this Assets.Scripts.Unity.Game game, string towerSet);
```
#### Parameters

<a name='BTD_Mod_Helper.Extensions.GameExt.GetTowerListForTowerType(thisAssets.Scripts.Unity.Game,string).game'></a>

`game` [Assets.Scripts.Unity.Game](https://docs.microsoft.com/en-us/dotnet/api/Assets.Scripts.Unity.Game 'Assets.Scripts.Unity.Game')

<a name='BTD_Mod_Helper.Extensions.GameExt.GetTowerListForTowerType(thisAssets.Scripts.Unity.Game,string).towerSet'></a>

`towerSet` [System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')

#### Returns
[System.Collections.Generic.List&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.List-1 'System.Collections.Generic.List`1')[Assets.Scripts.Models.Towers.TowerModel](https://docs.microsoft.com/en-us/dotnet/api/Assets.Scripts.Models.Towers.TowerModel 'Assets.Scripts.Models.Towers.TowerModel')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.List-1 'System.Collections.Generic.List`1')

<a name='BTD_Mod_Helper.Extensions.GameExt.GetUI(thisAssets.Scripts.Unity.Game)'></a>

## GameExt.GetUI(this Game) Method

Get the instance of UI

```csharp
public static Assets.Scripts.Unity.UI_New.UI GetUI(this Assets.Scripts.Unity.Game game);
```
#### Parameters

<a name='BTD_Mod_Helper.Extensions.GameExt.GetUI(thisAssets.Scripts.Unity.Game).game'></a>

`game` [Assets.Scripts.Unity.Game](https://docs.microsoft.com/en-us/dotnet/api/Assets.Scripts.Unity.Game 'Assets.Scripts.Unity.Game')

#### Returns
[Assets.Scripts.Unity.UI_New.UI](https://docs.microsoft.com/en-us/dotnet/api/Assets.Scripts.Unity.UI_New.UI 'Assets.Scripts.Unity.UI_New.UI')

<a name='BTD_Mod_Helper.Extensions.GameExt.IsAccountFlagged(thisAssets.Scripts.Unity.Game)'></a>

## GameExt.IsAccountFlagged(this Game) Method

Returns whether or not the player's account is currently flagged/hackerpooled

```csharp
public static bool IsAccountFlagged(this Assets.Scripts.Unity.Game game);
```
#### Parameters

<a name='BTD_Mod_Helper.Extensions.GameExt.IsAccountFlagged(thisAssets.Scripts.Unity.Game).game'></a>

`game` [Assets.Scripts.Unity.Game](https://docs.microsoft.com/en-us/dotnet/api/Assets.Scripts.Unity.Game 'Assets.Scripts.Unity.Game')

#### Returns
[System.Boolean](https://docs.microsoft.com/en-us/dotnet/api/System.Boolean 'System.Boolean')

<a name='BTD_Mod_Helper.Extensions.GameExt.IsInOdyssey(thisAssets.Scripts.Unity.Game)'></a>

## GameExt.IsInOdyssey(this Game) Method

Returns if Player is in a Odyssey game

```csharp
public static bool IsInOdyssey(this Assets.Scripts.Unity.Game game);
```
#### Parameters

<a name='BTD_Mod_Helper.Extensions.GameExt.IsInOdyssey(thisAssets.Scripts.Unity.Game).game'></a>

`game` [Assets.Scripts.Unity.Game](https://docs.microsoft.com/en-us/dotnet/api/Assets.Scripts.Unity.Game 'Assets.Scripts.Unity.Game')

#### Returns
[System.Boolean](https://docs.microsoft.com/en-us/dotnet/api/System.Boolean 'System.Boolean')

<a name='BTD_Mod_Helper.Extensions.GameExt.IsInPublicCoop(thisAssets.Scripts.Unity.Game)'></a>

## GameExt.IsInPublicCoop(this Game) Method

Returns if Player is in a public co-op match

```csharp
public static bool IsInPublicCoop(this Assets.Scripts.Unity.Game game);
```
#### Parameters

<a name='BTD_Mod_Helper.Extensions.GameExt.IsInPublicCoop(thisAssets.Scripts.Unity.Game).game'></a>

`game` [Assets.Scripts.Unity.Game](https://docs.microsoft.com/en-us/dotnet/api/Assets.Scripts.Unity.Game 'Assets.Scripts.Unity.Game')

#### Returns
[System.Boolean](https://docs.microsoft.com/en-us/dotnet/api/System.Boolean 'System.Boolean')

<a name='BTD_Mod_Helper.Extensions.GameExt.IsInRace(thisAssets.Scripts.Unity.Game)'></a>

## GameExt.IsInRace(this Game) Method

Returns if Player is in a race

```csharp
public static bool IsInRace(this Assets.Scripts.Unity.Game game);
```
#### Parameters

<a name='BTD_Mod_Helper.Extensions.GameExt.IsInRace(thisAssets.Scripts.Unity.Game).game'></a>

`game` [Assets.Scripts.Unity.Game](https://docs.microsoft.com/en-us/dotnet/api/Assets.Scripts.Unity.Game 'Assets.Scripts.Unity.Game')

#### Returns
[System.Boolean](https://docs.microsoft.com/en-us/dotnet/api/System.Boolean 'System.Boolean')

<a name='BTD_Mod_Helper.Extensions.GameExt.SavePlayerData(thisAssets.Scripts.Unity.Game,string)'></a>

## GameExt.SavePlayerData(this Game, string) Method

Makes a save of Player.Save at the specified path

```csharp
public static void SavePlayerData(this Assets.Scripts.Unity.Game game, string savePath);
```
#### Parameters

<a name='BTD_Mod_Helper.Extensions.GameExt.SavePlayerData(thisAssets.Scripts.Unity.Game,string).game'></a>

`game` [Assets.Scripts.Unity.Game](https://docs.microsoft.com/en-us/dotnet/api/Assets.Scripts.Unity.Game 'Assets.Scripts.Unity.Game')

<a name='BTD_Mod_Helper.Extensions.GameExt.SavePlayerData(thisAssets.Scripts.Unity.Game,string).savePath'></a>

`savePath` [System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')

Path to save to

<a name='BTD_Mod_Helper.Extensions.GameExt.ScheduleTask(thisAssets.Scripts.Unity.Game,System.Action,BTD_Mod_Helper.Api.Enums.ScheduleType,int,System.Func_bool_)'></a>

## GameExt.ScheduleTask(this Game, Action, ScheduleType, int, Func<bool>) Method

Schedule a task to execute later on as a Coroutine

```csharp
public static void ScheduleTask(this Assets.Scripts.Unity.Game game, System.Action action, BTD_Mod_Helper.Api.Enums.ScheduleType scheduleType, int amountToWait, System.Func<bool> waitCondition=null);
```
#### Parameters

<a name='BTD_Mod_Helper.Extensions.GameExt.ScheduleTask(thisAssets.Scripts.Unity.Game,System.Action,BTD_Mod_Helper.Api.Enums.ScheduleType,int,System.Func_bool_).game'></a>

`game` [Assets.Scripts.Unity.Game](https://docs.microsoft.com/en-us/dotnet/api/Assets.Scripts.Unity.Game 'Assets.Scripts.Unity.Game')

<a name='BTD_Mod_Helper.Extensions.GameExt.ScheduleTask(thisAssets.Scripts.Unity.Game,System.Action,BTD_Mod_Helper.Api.Enums.ScheduleType,int,System.Func_bool_).action'></a>

`action` [System.Action](https://docs.microsoft.com/en-us/dotnet/api/System.Action 'System.Action')

The action you want to execute once it's time to run your task

<a name='BTD_Mod_Helper.Extensions.GameExt.ScheduleTask(thisAssets.Scripts.Unity.Game,System.Action,BTD_Mod_Helper.Api.Enums.ScheduleType,int,System.Func_bool_).scheduleType'></a>

`scheduleType` [ScheduleType](BTD_Mod_Helper.Api.Enums.ScheduleType.md 'BTD_Mod_Helper.Api.Enums.ScheduleType')

How you want to wait for your task

<a name='BTD_Mod_Helper.Extensions.GameExt.ScheduleTask(thisAssets.Scripts.Unity.Game,System.Action,BTD_Mod_Helper.Api.Enums.ScheduleType,int,System.Func_bool_).amountToWait'></a>

`amountToWait` [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/System.Int32 'System.Int32')

The amount you want to wait

<a name='BTD_Mod_Helper.Extensions.GameExt.ScheduleTask(thisAssets.Scripts.Unity.Game,System.Action,BTD_Mod_Helper.Api.Enums.ScheduleType,int,System.Func_bool_).waitCondition'></a>

`waitCondition` [System.Func&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Func-1 'System.Func`1')[System.Boolean](https://docs.microsoft.com/en-us/dotnet/api/System.Boolean 'System.Boolean')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Func-1 'System.Func`1')

Wait for this to be true before executing task

<a name='BTD_Mod_Helper.Extensions.GameExt.ScheduleTask(thisAssets.Scripts.Unity.Game,System.Action,System.Func_bool_)'></a>

## GameExt.ScheduleTask(this Game, Action, Func<bool>) Method

Schedule a task to execute later on as a Coroutine. By default will wait until the end of this current frame

```csharp
public static void ScheduleTask(this Assets.Scripts.Unity.Game game, System.Action action, System.Func<bool> waitCondition=null);
```
#### Parameters

<a name='BTD_Mod_Helper.Extensions.GameExt.ScheduleTask(thisAssets.Scripts.Unity.Game,System.Action,System.Func_bool_).game'></a>

`game` [Assets.Scripts.Unity.Game](https://docs.microsoft.com/en-us/dotnet/api/Assets.Scripts.Unity.Game 'Assets.Scripts.Unity.Game')

<a name='BTD_Mod_Helper.Extensions.GameExt.ScheduleTask(thisAssets.Scripts.Unity.Game,System.Action,System.Func_bool_).action'></a>

`action` [System.Action](https://docs.microsoft.com/en-us/dotnet/api/System.Action 'System.Action')

The action you want to execute once it's time to run your task

<a name='BTD_Mod_Helper.Extensions.GameExt.ScheduleTask(thisAssets.Scripts.Unity.Game,System.Action,System.Func_bool_).waitCondition'></a>

`waitCondition` [System.Func&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Func-1 'System.Func`1')[System.Boolean](https://docs.microsoft.com/en-us/dotnet/api/System.Boolean 'System.Boolean')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Func-1 'System.Func`1')

Wait for this to be true before executing task

<a name='BTD_Mod_Helper.Extensions.GameExt.ScheduleTask(thisAssets.Scripts.Unity.Game,System.Collections.IEnumerator)'></a>

## GameExt.ScheduleTask(this Game, IEnumerator) Method

Schedule a task to execute right now as a Coroutine

```csharp
public static void ScheduleTask(this Assets.Scripts.Unity.Game game, System.Collections.IEnumerator iEnumerator);
```
#### Parameters

<a name='BTD_Mod_Helper.Extensions.GameExt.ScheduleTask(thisAssets.Scripts.Unity.Game,System.Collections.IEnumerator).game'></a>

`game` [Assets.Scripts.Unity.Game](https://docs.microsoft.com/en-us/dotnet/api/Assets.Scripts.Unity.Game 'Assets.Scripts.Unity.Game')

<a name='BTD_Mod_Helper.Extensions.GameExt.ScheduleTask(thisAssets.Scripts.Unity.Game,System.Collections.IEnumerator).iEnumerator'></a>

`iEnumerator` [System.Collections.IEnumerator](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.IEnumerator 'System.Collections.IEnumerator')

<a name='BTD_Mod_Helper.Extensions.GameExt.SetMonkeyMoney(thisAssets.Scripts.Unity.Game,double)'></a>

## GameExt.SetMonkeyMoney(this Game, double) Method

Set player's Monkey Money amount

```csharp
public static void SetMonkeyMoney(this Assets.Scripts.Unity.Game game, double amount);
```
#### Parameters

<a name='BTD_Mod_Helper.Extensions.GameExt.SetMonkeyMoney(thisAssets.Scripts.Unity.Game,double).game'></a>

`game` [Assets.Scripts.Unity.Game](https://docs.microsoft.com/en-us/dotnet/api/Assets.Scripts.Unity.Game 'Assets.Scripts.Unity.Game')

the Game instance

<a name='BTD_Mod_Helper.Extensions.GameExt.SetMonkeyMoney(thisAssets.Scripts.Unity.Game,double).amount'></a>

`amount` [System.Double](https://docs.microsoft.com/en-us/dotnet/api/System.Double 'System.Double')

Value to set Monkey Money to

<a name='BTD_Mod_Helper.Extensions.GameExt.ShowMessage(thisAssets.Scripts.Unity.Game,string,float,string)'></a>

## GameExt.ShowMessage(this Game, string, float, string) Method

Uses custom message popup to show a message in game. Currently only works in active game sessions and not on Main Menu

```csharp
public static void ShowMessage(this Assets.Scripts.Unity.Game game, string message, float displayTime, string title);
```
#### Parameters

<a name='BTD_Mod_Helper.Extensions.GameExt.ShowMessage(thisAssets.Scripts.Unity.Game,string,float,string).game'></a>

`game` [Assets.Scripts.Unity.Game](https://docs.microsoft.com/en-us/dotnet/api/Assets.Scripts.Unity.Game 'Assets.Scripts.Unity.Game')

the Game instance

<a name='BTD_Mod_Helper.Extensions.GameExt.ShowMessage(thisAssets.Scripts.Unity.Game,string,float,string).message'></a>

`message` [System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')

Message body

<a name='BTD_Mod_Helper.Extensions.GameExt.ShowMessage(thisAssets.Scripts.Unity.Game,string,float,string).displayTime'></a>

`displayTime` [System.Single](https://docs.microsoft.com/en-us/dotnet/api/System.Single 'System.Single')

Time to show message on screen

<a name='BTD_Mod_Helper.Extensions.GameExt.ShowMessage(thisAssets.Scripts.Unity.Game,string,float,string).title'></a>

`title` [System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')

Message title. Will be mod name by default

<a name='BTD_Mod_Helper.Extensions.GameExt.ShowMessage(thisAssets.Scripts.Unity.Game,string,string)'></a>

## GameExt.ShowMessage(this Game, string, string) Method

Uses custom message popup to show a message in game. Currently only works in active game sessions and not on Main Menu

```csharp
public static void ShowMessage(this Assets.Scripts.Unity.Game game, string message, string title);
```
#### Parameters

<a name='BTD_Mod_Helper.Extensions.GameExt.ShowMessage(thisAssets.Scripts.Unity.Game,string,string).game'></a>

`game` [Assets.Scripts.Unity.Game](https://docs.microsoft.com/en-us/dotnet/api/Assets.Scripts.Unity.Game 'Assets.Scripts.Unity.Game')

the Game instance

<a name='BTD_Mod_Helper.Extensions.GameExt.ShowMessage(thisAssets.Scripts.Unity.Game,string,string).message'></a>

`message` [System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')

Message body

<a name='BTD_Mod_Helper.Extensions.GameExt.ShowMessage(thisAssets.Scripts.Unity.Game,string,string).title'></a>

`title` [System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')

Message title. Will be mod name by default