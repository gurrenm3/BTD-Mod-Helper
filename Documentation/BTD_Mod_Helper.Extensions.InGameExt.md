#### [BloonsTD6 Mod Helper](README.md 'README')
### [BTD_Mod_Helper.Extensions](README.md#BTD_Mod_Helper.Extensions 'BTD_Mod_Helper.Extensions')

## InGameExt Class

Extensions for the InGame class

```csharp
public static class InGameExt
```

Inheritance [System.Object](https://docs.microsoft.com/en-us/dotnet/api/System.Object 'System.Object') &#129106; InGameExt
### Methods

<a name='BTD_Mod_Helper.Extensions.InGameExt.AddCash(thisAssets.Scripts.Unity.UI_New.InGame.InGame,double)'></a>

## InGameExt.AddCash(this InGame, double) Method

Add cash to the Player's wallet

```csharp
public static void AddCash(this Assets.Scripts.Unity.UI_New.InGame.InGame inGame, double amount);
```
#### Parameters

<a name='BTD_Mod_Helper.Extensions.InGameExt.AddCash(thisAssets.Scripts.Unity.UI_New.InGame.InGame,double).inGame'></a>

`inGame` [Assets.Scripts.Unity.UI_New.InGame.InGame](https://docs.microsoft.com/en-us/dotnet/api/Assets.Scripts.Unity.UI_New.InGame.InGame 'Assets.Scripts.Unity.UI_New.InGame.InGame')

InGame instance

<a name='BTD_Mod_Helper.Extensions.InGameExt.AddCash(thisAssets.Scripts.Unity.UI_New.InGame.InGame,double).amount'></a>

`amount` [System.Double](https://docs.microsoft.com/en-us/dotnet/api/System.Double 'System.Double')

Amount of cash to add to player wallet

<a name='BTD_Mod_Helper.Extensions.InGameExt.AddHealth(thisAssets.Scripts.Unity.UI_New.InGame.InGame,double)'></a>

## InGameExt.AddHealth(this InGame, double) Method

Add health to the players current health

```csharp
public static void AddHealth(this Assets.Scripts.Unity.UI_New.InGame.InGame inGame, double amount);
```
#### Parameters

<a name='BTD_Mod_Helper.Extensions.InGameExt.AddHealth(thisAssets.Scripts.Unity.UI_New.InGame.InGame,double).inGame'></a>

`inGame` [Assets.Scripts.Unity.UI_New.InGame.InGame](https://docs.microsoft.com/en-us/dotnet/api/Assets.Scripts.Unity.UI_New.InGame.InGame 'Assets.Scripts.Unity.UI_New.InGame.InGame')

InGame instance

<a name='BTD_Mod_Helper.Extensions.InGameExt.AddHealth(thisAssets.Scripts.Unity.UI_New.InGame.InGame,double).amount'></a>

`amount` [System.Double](https://docs.microsoft.com/en-us/dotnet/api/System.Double 'System.Double')

Amount of health to add

<a name='BTD_Mod_Helper.Extensions.InGameExt.AddMaxHealth(thisAssets.Scripts.Unity.UI_New.InGame.InGame,double)'></a>

## InGameExt.AddMaxHealth(this InGame, double) Method

Add to the player's max health

```csharp
public static void AddMaxHealth(this Assets.Scripts.Unity.UI_New.InGame.InGame inGame, double amount);
```
#### Parameters

<a name='BTD_Mod_Helper.Extensions.InGameExt.AddMaxHealth(thisAssets.Scripts.Unity.UI_New.InGame.InGame,double).inGame'></a>

`inGame` [Assets.Scripts.Unity.UI_New.InGame.InGame](https://docs.microsoft.com/en-us/dotnet/api/Assets.Scripts.Unity.UI_New.InGame.InGame 'Assets.Scripts.Unity.UI_New.InGame.InGame')

InGame instance

<a name='BTD_Mod_Helper.Extensions.InGameExt.AddMaxHealth(thisAssets.Scripts.Unity.UI_New.InGame.InGame,double).amount'></a>

`amount` [System.Double](https://docs.microsoft.com/en-us/dotnet/api/System.Double 'System.Double')

Amount to add to the player's max health

<a name='BTD_Mod_Helper.Extensions.InGameExt.GetAbilities(thisAssets.Scripts.Unity.UI_New.InGame.InGame)'></a>

## InGameExt.GetAbilities(this InGame) Method

Get's all AbilityToSimulations currently in the game

```csharp
public static System.Collections.Generic.List<Assets.Scripts.Unity.Bridge.AbilityToSimulation> GetAbilities(this Assets.Scripts.Unity.UI_New.InGame.InGame inGame);
```
#### Parameters

<a name='BTD_Mod_Helper.Extensions.InGameExt.GetAbilities(thisAssets.Scripts.Unity.UI_New.InGame.InGame).inGame'></a>

`inGame` [Assets.Scripts.Unity.UI_New.InGame.InGame](https://docs.microsoft.com/en-us/dotnet/api/Assets.Scripts.Unity.UI_New.InGame.InGame 'Assets.Scripts.Unity.UI_New.InGame.InGame')

#### Returns
[System.Collections.Generic.List&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.List-1 'System.Collections.Generic.List`1')[Assets.Scripts.Unity.Bridge.AbilityToSimulation](https://docs.microsoft.com/en-us/dotnet/api/Assets.Scripts.Unity.Bridge.AbilityToSimulation 'Assets.Scripts.Unity.Bridge.AbilityToSimulation')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.List-1 'System.Collections.Generic.List`1')

<a name='BTD_Mod_Helper.Extensions.InGameExt.GetAllBloonToSim(thisAssets.Scripts.Unity.UI_New.InGame.InGame)'></a>

## InGameExt.GetAllBloonToSim(this InGame) Method

Get's all existing BloonToSimulations

```csharp
public static System.Collections.Generic.List<Assets.Scripts.Unity.Bridge.BloonToSimulation> GetAllBloonToSim(this Assets.Scripts.Unity.UI_New.InGame.InGame inGame);
```
#### Parameters

<a name='BTD_Mod_Helper.Extensions.InGameExt.GetAllBloonToSim(thisAssets.Scripts.Unity.UI_New.InGame.InGame).inGame'></a>

`inGame` [Assets.Scripts.Unity.UI_New.InGame.InGame](https://docs.microsoft.com/en-us/dotnet/api/Assets.Scripts.Unity.UI_New.InGame.InGame 'Assets.Scripts.Unity.UI_New.InGame.InGame')

#### Returns
[System.Collections.Generic.List&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.List-1 'System.Collections.Generic.List`1')[Assets.Scripts.Unity.Bridge.BloonToSimulation](https://docs.microsoft.com/en-us/dotnet/api/Assets.Scripts.Unity.Bridge.BloonToSimulation 'Assets.Scripts.Unity.Bridge.BloonToSimulation')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.List-1 'System.Collections.Generic.List`1')

<a name='BTD_Mod_Helper.Extensions.InGameExt.GetAllObjectsOfType_T_(thisAssets.Scripts.Unity.UI_New.InGame.InGame)'></a>

## InGameExt.GetAllObjectsOfType<T>(this InGame) Method

Gets all objects of type T. Does this by returning all objects created by the Factory of type T

```csharp
public static System.Collections.Generic.List<T> GetAllObjectsOfType<T>(this Assets.Scripts.Unity.UI_New.InGame.InGame inGame)
    where T : Assets.Scripts.Simulation.Objects.RootObject, new();
```
#### Type parameters

<a name='BTD_Mod_Helper.Extensions.InGameExt.GetAllObjectsOfType_T_(thisAssets.Scripts.Unity.UI_New.InGame.InGame).T'></a>

`T`

The type of items you want
#### Parameters

<a name='BTD_Mod_Helper.Extensions.InGameExt.GetAllObjectsOfType_T_(thisAssets.Scripts.Unity.UI_New.InGame.InGame).inGame'></a>

`inGame` [Assets.Scripts.Unity.UI_New.InGame.InGame](https://docs.microsoft.com/en-us/dotnet/api/Assets.Scripts.Unity.UI_New.InGame.InGame 'Assets.Scripts.Unity.UI_New.InGame.InGame')

#### Returns
[System.Collections.Generic.List&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.List-1 'System.Collections.Generic.List`1')[T](BTD_Mod_Helper.Extensions.InGameExt.md#BTD_Mod_Helper.Extensions.InGameExt.GetAllObjectsOfType_T_(thisAssets.Scripts.Unity.UI_New.InGame.InGame).T 'BTD_Mod_Helper.Extensions.InGameExt.GetAllObjectsOfType<T>(this Assets.Scripts.Unity.UI_New.InGame.InGame).T')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.List-1 'System.Collections.Generic.List`1')

<a name='BTD_Mod_Helper.Extensions.InGameExt.GetAllTowerToSim(thisAssets.Scripts.Unity.UI_New.InGame.InGame,string)'></a>

## InGameExt.GetAllTowerToSim(this InGame, string) Method

Get all TowerToSimulations

```csharp
public static System.Collections.Generic.List<Assets.Scripts.Unity.Bridge.TowerToSimulation> GetAllTowerToSim(this Assets.Scripts.Unity.UI_New.InGame.InGame inGame, string name=null);
```
#### Parameters

<a name='BTD_Mod_Helper.Extensions.InGameExt.GetAllTowerToSim(thisAssets.Scripts.Unity.UI_New.InGame.InGame,string).inGame'></a>

`inGame` [Assets.Scripts.Unity.UI_New.InGame.InGame](https://docs.microsoft.com/en-us/dotnet/api/Assets.Scripts.Unity.UI_New.InGame.InGame 'Assets.Scripts.Unity.UI_New.InGame.InGame')

<a name='BTD_Mod_Helper.Extensions.InGameExt.GetAllTowerToSim(thisAssets.Scripts.Unity.UI_New.InGame.InGame,string).name'></a>

`name` [System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')

Optionally only get Towers whose TowerModel name is this parameter

#### Returns
[System.Collections.Generic.List&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.List-1 'System.Collections.Generic.List`1')[Assets.Scripts.Unity.Bridge.TowerToSimulation](https://docs.microsoft.com/en-us/dotnet/api/Assets.Scripts.Unity.Bridge.TowerToSimulation 'Assets.Scripts.Unity.Bridge.TowerToSimulation')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.List-1 'System.Collections.Generic.List`1')

<a name='BTD_Mod_Helper.Extensions.InGameExt.GetBloons(thisAssets.Scripts.Unity.UI_New.InGame.InGame)'></a>

## InGameExt.GetBloons(this InGame) Method

Get's all Bloons on the map

```csharp
public static System.Collections.Generic.List<Assets.Scripts.Simulation.Bloons.Bloon> GetBloons(this Assets.Scripts.Unity.UI_New.InGame.InGame inGame);
```
#### Parameters

<a name='BTD_Mod_Helper.Extensions.InGameExt.GetBloons(thisAssets.Scripts.Unity.UI_New.InGame.InGame).inGame'></a>

`inGame` [Assets.Scripts.Unity.UI_New.InGame.InGame](https://docs.microsoft.com/en-us/dotnet/api/Assets.Scripts.Unity.UI_New.InGame.InGame 'Assets.Scripts.Unity.UI_New.InGame.InGame')

#### Returns
[System.Collections.Generic.List&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.List-1 'System.Collections.Generic.List`1')[Assets.Scripts.Simulation.Bloons.Bloon](https://docs.microsoft.com/en-us/dotnet/api/Assets.Scripts.Simulation.Bloons.Bloon 'Assets.Scripts.Simulation.Bloons.Bloon')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.List-1 'System.Collections.Generic.List`1')

<a name='BTD_Mod_Helper.Extensions.InGameExt.GetCash(thisAssets.Scripts.Unity.UI_New.InGame.InGame)'></a>

## InGameExt.GetCash(this InGame) Method

Get the Player's current cash

```csharp
public static double GetCash(this Assets.Scripts.Unity.UI_New.InGame.InGame inGame);
```
#### Parameters

<a name='BTD_Mod_Helper.Extensions.InGameExt.GetCash(thisAssets.Scripts.Unity.UI_New.InGame.InGame).inGame'></a>

`inGame` [Assets.Scripts.Unity.UI_New.InGame.InGame](https://docs.microsoft.com/en-us/dotnet/api/Assets.Scripts.Unity.UI_New.InGame.InGame 'Assets.Scripts.Unity.UI_New.InGame.InGame')

#### Returns
[System.Double](https://docs.microsoft.com/en-us/dotnet/api/System.Double 'System.Double')

<a name='BTD_Mod_Helper.Extensions.InGameExt.GetCashManager(thisAssets.Scripts.Unity.UI_New.InGame.InGame,int)'></a>

## InGameExt.GetCashManager(this InGame, int) Method

Get the Cash Manager for the current game

```csharp
public static Assets.Scripts.Simulation.Simulation.CashManager GetCashManager(this Assets.Scripts.Unity.UI_New.InGame.InGame inGame, int index=0);
```
#### Parameters

<a name='BTD_Mod_Helper.Extensions.InGameExt.GetCashManager(thisAssets.Scripts.Unity.UI_New.InGame.InGame,int).inGame'></a>

`inGame` [Assets.Scripts.Unity.UI_New.InGame.InGame](https://docs.microsoft.com/en-us/dotnet/api/Assets.Scripts.Unity.UI_New.InGame.InGame 'Assets.Scripts.Unity.UI_New.InGame.InGame')

InGame instance

<a name='BTD_Mod_Helper.Extensions.InGameExt.GetCashManager(thisAssets.Scripts.Unity.UI_New.InGame.InGame,int).index'></a>

`index` [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/System.Int32 'System.Int32')

Index of the cash manager. Default is 0

#### Returns
[Assets.Scripts.Simulation.Simulation.CashManager](https://docs.microsoft.com/en-us/dotnet/api/Assets.Scripts.Simulation.Simulation.CashManager 'Assets.Scripts.Simulation.Simulation.CashManager')

<a name='BTD_Mod_Helper.Extensions.InGameExt.GetFactory_T_(thisAssets.Scripts.Unity.UI_New.InGame.InGame)'></a>

## InGameExt.GetFactory<T>(this InGame) Method

Get the Factory for a specific Type. Ex: Getting the Factory that makes Towers

```csharp
public static Assets.Scripts.Simulation.Factory.Factory<T> GetFactory<T>(this Assets.Scripts.Unity.UI_New.InGame.InGame inGame)
    where T : Assets.Scripts.Simulation.Objects.RootObject, new();
```
#### Type parameters

<a name='BTD_Mod_Helper.Extensions.InGameExt.GetFactory_T_(thisAssets.Scripts.Unity.UI_New.InGame.InGame).T'></a>

`T`
#### Parameters

<a name='BTD_Mod_Helper.Extensions.InGameExt.GetFactory_T_(thisAssets.Scripts.Unity.UI_New.InGame.InGame).inGame'></a>

`inGame` [Assets.Scripts.Unity.UI_New.InGame.InGame](https://docs.microsoft.com/en-us/dotnet/api/Assets.Scripts.Unity.UI_New.InGame.InGame 'Assets.Scripts.Unity.UI_New.InGame.InGame')

#### Returns
[Assets.Scripts.Simulation.Factory.Factory&lt;](https://docs.microsoft.com/en-us/dotnet/api/Assets.Scripts.Simulation.Factory.Factory-1 'Assets.Scripts.Simulation.Factory.Factory`1')[T](BTD_Mod_Helper.Extensions.InGameExt.md#BTD_Mod_Helper.Extensions.InGameExt.GetFactory_T_(thisAssets.Scripts.Unity.UI_New.InGame.InGame).T 'BTD_Mod_Helper.Extensions.InGameExt.GetFactory<T>(this Assets.Scripts.Unity.UI_New.InGame.InGame).T')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/Assets.Scripts.Simulation.Factory.Factory-1 'Assets.Scripts.Simulation.Factory.Factory`1')

<a name='BTD_Mod_Helper.Extensions.InGameExt.GetGameModel(thisAssets.Scripts.Unity.UI_New.InGame.InGame)'></a>

## InGameExt.GetGameModel(this InGame) Method

The Game.model that is being used for this InGame.instance

```csharp
public static Assets.Scripts.Models.GameModel GetGameModel(this Assets.Scripts.Unity.UI_New.InGame.InGame inGame);
```
#### Parameters

<a name='BTD_Mod_Helper.Extensions.InGameExt.GetGameModel(thisAssets.Scripts.Unity.UI_New.InGame.InGame).inGame'></a>

`inGame` [Assets.Scripts.Unity.UI_New.InGame.InGame](https://docs.microsoft.com/en-us/dotnet/api/Assets.Scripts.Unity.UI_New.InGame.InGame 'Assets.Scripts.Unity.UI_New.InGame.InGame')

#### Returns
[Assets.Scripts.Models.GameModel](https://docs.microsoft.com/en-us/dotnet/api/Assets.Scripts.Models.GameModel 'Assets.Scripts.Models.GameModel')

<a name='BTD_Mod_Helper.Extensions.InGameExt.GetHealth(thisAssets.Scripts.Unity.UI_New.InGame.InGame)'></a>

## InGameExt.GetHealth(this InGame) Method

Get the Player's current health

```csharp
public static double GetHealth(this Assets.Scripts.Unity.UI_New.InGame.InGame inGame);
```
#### Parameters

<a name='BTD_Mod_Helper.Extensions.InGameExt.GetHealth(thisAssets.Scripts.Unity.UI_New.InGame.InGame).inGame'></a>

`inGame` [Assets.Scripts.Unity.UI_New.InGame.InGame](https://docs.microsoft.com/en-us/dotnet/api/Assets.Scripts.Unity.UI_New.InGame.InGame 'Assets.Scripts.Unity.UI_New.InGame.InGame')

#### Returns
[System.Double](https://docs.microsoft.com/en-us/dotnet/api/System.Double 'System.Double')

<a name='BTD_Mod_Helper.Extensions.InGameExt.GetInGameUI(thisAssets.Scripts.Unity.UI_New.InGame.InGame)'></a>

## InGameExt.GetInGameUI(this InGame) Method

Get the game object that owns all InGame UI elements

```csharp
public static UnityEngine.GameObject GetInGameUI(this Assets.Scripts.Unity.UI_New.InGame.InGame inGame);
```
#### Parameters

<a name='BTD_Mod_Helper.Extensions.InGameExt.GetInGameUI(thisAssets.Scripts.Unity.UI_New.InGame.InGame).inGame'></a>

`inGame` [Assets.Scripts.Unity.UI_New.InGame.InGame](https://docs.microsoft.com/en-us/dotnet/api/Assets.Scripts.Unity.UI_New.InGame.InGame 'Assets.Scripts.Unity.UI_New.InGame.InGame')

#### Returns
[UnityEngine.GameObject](https://docs.microsoft.com/en-us/dotnet/api/UnityEngine.GameObject 'UnityEngine.GameObject')

<a name='BTD_Mod_Helper.Extensions.InGameExt.GetMainFactory(thisAssets.Scripts.Unity.UI_New.InGame.InGame)'></a>

## InGameExt.GetMainFactory(this InGame) Method

Get the main Factory that creates and manages all other Factories

```csharp
public static Assets.Scripts.Simulation.Factory.FactoryFactory GetMainFactory(this Assets.Scripts.Unity.UI_New.InGame.InGame inGame);
```
#### Parameters

<a name='BTD_Mod_Helper.Extensions.InGameExt.GetMainFactory(thisAssets.Scripts.Unity.UI_New.InGame.InGame).inGame'></a>

`inGame` [Assets.Scripts.Unity.UI_New.InGame.InGame](https://docs.microsoft.com/en-us/dotnet/api/Assets.Scripts.Unity.UI_New.InGame.InGame 'Assets.Scripts.Unity.UI_New.InGame.InGame')

#### Returns
[Assets.Scripts.Simulation.Factory.FactoryFactory](https://docs.microsoft.com/en-us/dotnet/api/Assets.Scripts.Simulation.Factory.FactoryFactory 'Assets.Scripts.Simulation.Factory.FactoryFactory')

<a name='BTD_Mod_Helper.Extensions.InGameExt.GetMap(thisAssets.Scripts.Unity.UI_New.InGame.InGame)'></a>

## InGameExt.GetMap(this InGame) Method

Get the current Map

```csharp
public static Assets.Scripts.Simulation.Track.Map GetMap(this Assets.Scripts.Unity.UI_New.InGame.InGame inGame);
```
#### Parameters

<a name='BTD_Mod_Helper.Extensions.InGameExt.GetMap(thisAssets.Scripts.Unity.UI_New.InGame.InGame).inGame'></a>

`inGame` [Assets.Scripts.Unity.UI_New.InGame.InGame](https://docs.microsoft.com/en-us/dotnet/api/Assets.Scripts.Unity.UI_New.InGame.InGame 'Assets.Scripts.Unity.UI_New.InGame.InGame')

#### Returns
[Assets.Scripts.Simulation.Track.Map](https://docs.microsoft.com/en-us/dotnet/api/Assets.Scripts.Simulation.Track.Map 'Assets.Scripts.Simulation.Track.Map')

<a name='BTD_Mod_Helper.Extensions.InGameExt.GetMaxHealth(thisAssets.Scripts.Unity.UI_New.InGame.InGame)'></a>

## InGameExt.GetMaxHealth(this InGame) Method

Get the player's max health

```csharp
public static double GetMaxHealth(this Assets.Scripts.Unity.UI_New.InGame.InGame inGame);
```
#### Parameters

<a name='BTD_Mod_Helper.Extensions.InGameExt.GetMaxHealth(thisAssets.Scripts.Unity.UI_New.InGame.InGame).inGame'></a>

`inGame` [Assets.Scripts.Unity.UI_New.InGame.InGame](https://docs.microsoft.com/en-us/dotnet/api/Assets.Scripts.Unity.UI_New.InGame.InGame 'Assets.Scripts.Unity.UI_New.InGame.InGame')

#### Returns
[System.Double](https://docs.microsoft.com/en-us/dotnet/api/System.Double 'System.Double')

<a name='BTD_Mod_Helper.Extensions.InGameExt.GetPoppedBloons(thisAssets.Scripts.Unity.UI_New.InGame.InGame)'></a>

## InGameExt.GetPoppedBloons(this InGame) Method

Get collection of popped bloons in this game. Right now only works for current games. Does not store results from loaded games

```csharp
public static System.Collections.Generic.Dictionary<string,int> GetPoppedBloons(this Assets.Scripts.Unity.UI_New.InGame.InGame inGame);
```
#### Parameters

<a name='BTD_Mod_Helper.Extensions.InGameExt.GetPoppedBloons(thisAssets.Scripts.Unity.UI_New.InGame.InGame).inGame'></a>

`inGame` [Assets.Scripts.Unity.UI_New.InGame.InGame](https://docs.microsoft.com/en-us/dotnet/api/Assets.Scripts.Unity.UI_New.InGame.InGame 'Assets.Scripts.Unity.UI_New.InGame.InGame')

#### Returns
[System.Collections.Generic.Dictionary&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.Dictionary-2 'System.Collections.Generic.Dictionary`2')[System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')[,](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.Dictionary-2 'System.Collections.Generic.Dictionary`2')[System.Int32](https://docs.microsoft.com/en-us/dotnet/api/System.Int32 'System.Int32')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.Dictionary-2 'System.Collections.Generic.Dictionary`2')

<a name='BTD_Mod_Helper.Extensions.InGameExt.GetProjectiles(thisAssets.Scripts.Unity.UI_New.InGame.InGame)'></a>

## InGameExt.GetProjectiles(this InGame) Method

Get's all existing Projectiles on the map

```csharp
public static System.Collections.Generic.List<Assets.Scripts.Simulation.Towers.Projectiles.Projectile> GetProjectiles(this Assets.Scripts.Unity.UI_New.InGame.InGame inGame);
```
#### Parameters

<a name='BTD_Mod_Helper.Extensions.InGameExt.GetProjectiles(thisAssets.Scripts.Unity.UI_New.InGame.InGame).inGame'></a>

`inGame` [Assets.Scripts.Unity.UI_New.InGame.InGame](https://docs.microsoft.com/en-us/dotnet/api/Assets.Scripts.Unity.UI_New.InGame.InGame 'Assets.Scripts.Unity.UI_New.InGame.InGame')

#### Returns
[System.Collections.Generic.List&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.List-1 'System.Collections.Generic.List`1')[Assets.Scripts.Simulation.Towers.Projectiles.Projectile](https://docs.microsoft.com/en-us/dotnet/api/Assets.Scripts.Simulation.Towers.Projectiles.Projectile 'Assets.Scripts.Simulation.Towers.Projectiles.Projectile')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.List-1 'System.Collections.Generic.List`1')

<a name='BTD_Mod_Helper.Extensions.InGameExt.GetSimulation(thisAssets.Scripts.Unity.UI_New.InGame.InGame)'></a>

## InGameExt.GetSimulation(this InGame) Method

Get the current Simulation for this InGame session

```csharp
public static Assets.Scripts.Simulation.Simulation GetSimulation(this Assets.Scripts.Unity.UI_New.InGame.InGame inGame);
```
#### Parameters

<a name='BTD_Mod_Helper.Extensions.InGameExt.GetSimulation(thisAssets.Scripts.Unity.UI_New.InGame.InGame).inGame'></a>

`inGame` [Assets.Scripts.Unity.UI_New.InGame.InGame](https://docs.microsoft.com/en-us/dotnet/api/Assets.Scripts.Unity.UI_New.InGame.InGame 'Assets.Scripts.Unity.UI_New.InGame.InGame')

#### Returns
[Assets.Scripts.Simulation.Simulation](https://docs.microsoft.com/en-us/dotnet/api/Assets.Scripts.Simulation.Simulation 'Assets.Scripts.Simulation.Simulation')

<a name='BTD_Mod_Helper.Extensions.InGameExt.GetTowerInventory(thisAssets.Scripts.Unity.UI_New.InGame.InGame)'></a>

## InGameExt.GetTowerInventory(this InGame) Method

Get the current instance of TowerInventory being used in this game session

```csharp
public static Assets.Scripts.Simulation.Input.TowerInventory GetTowerInventory(this Assets.Scripts.Unity.UI_New.InGame.InGame inGame);
```
#### Parameters

<a name='BTD_Mod_Helper.Extensions.InGameExt.GetTowerInventory(thisAssets.Scripts.Unity.UI_New.InGame.InGame).inGame'></a>

`inGame` [Assets.Scripts.Unity.UI_New.InGame.InGame](https://docs.microsoft.com/en-us/dotnet/api/Assets.Scripts.Unity.UI_New.InGame.InGame 'Assets.Scripts.Unity.UI_New.InGame.InGame')

#### Returns
[Assets.Scripts.Simulation.Input.TowerInventory](https://docs.microsoft.com/en-us/dotnet/api/Assets.Scripts.Simulation.Input.TowerInventory 'Assets.Scripts.Simulation.Input.TowerInventory')

<a name='BTD_Mod_Helper.Extensions.InGameExt.GetTowerManager(thisAssets.Scripts.Unity.UI_New.InGame.InGame)'></a>

## InGameExt.GetTowerManager(this InGame) Method

Get the current TowerManager for this game session

```csharp
public static Assets.Scripts.Simulation.Towers.TowerManager GetTowerManager(this Assets.Scripts.Unity.UI_New.InGame.InGame inGame);
```
#### Parameters

<a name='BTD_Mod_Helper.Extensions.InGameExt.GetTowerManager(thisAssets.Scripts.Unity.UI_New.InGame.InGame).inGame'></a>

`inGame` [Assets.Scripts.Unity.UI_New.InGame.InGame](https://docs.microsoft.com/en-us/dotnet/api/Assets.Scripts.Unity.UI_New.InGame.InGame 'Assets.Scripts.Unity.UI_New.InGame.InGame')

#### Returns
[Assets.Scripts.Simulation.Towers.TowerManager](https://docs.microsoft.com/en-us/dotnet/api/Assets.Scripts.Simulation.Towers.TowerManager 'Assets.Scripts.Simulation.Towers.TowerManager')

<a name='BTD_Mod_Helper.Extensions.InGameExt.GetTowers(thisAssets.Scripts.Unity.UI_New.InGame.InGame,string)'></a>

## InGameExt.GetTowers(this InGame, string) Method

Get every Tower that has been created through the Tower Factory

```csharp
public static System.Collections.Generic.List<Assets.Scripts.Simulation.Towers.Tower> GetTowers(this Assets.Scripts.Unity.UI_New.InGame.InGame inGame, string name=null);
```
#### Parameters

<a name='BTD_Mod_Helper.Extensions.InGameExt.GetTowers(thisAssets.Scripts.Unity.UI_New.InGame.InGame,string).inGame'></a>

`inGame` [Assets.Scripts.Unity.UI_New.InGame.InGame](https://docs.microsoft.com/en-us/dotnet/api/Assets.Scripts.Unity.UI_New.InGame.InGame 'Assets.Scripts.Unity.UI_New.InGame.InGame')

<a name='BTD_Mod_Helper.Extensions.InGameExt.GetTowers(thisAssets.Scripts.Unity.UI_New.InGame.InGame,string).name'></a>

`name` [System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')

Optionally only get Towers whose TowerModel name is this parameter

#### Returns
[System.Collections.Generic.List&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.List-1 'System.Collections.Generic.List`1')[Assets.Scripts.Simulation.Towers.Tower](https://docs.microsoft.com/en-us/dotnet/api/Assets.Scripts.Simulation.Towers.Tower 'Assets.Scripts.Simulation.Towers.Tower')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.List-1 'System.Collections.Generic.List`1')

<a name='BTD_Mod_Helper.Extensions.InGameExt.GetUnityToSimulation(thisAssets.Scripts.Unity.UI_New.InGame.InGame)'></a>

## InGameExt.GetUnityToSimulation(this InGame) Method

Get's the UnityToSimulation for this game

```csharp
public static Assets.Scripts.Unity.Bridge.UnityToSimulation GetUnityToSimulation(this Assets.Scripts.Unity.UI_New.InGame.InGame inGame);
```
#### Parameters

<a name='BTD_Mod_Helper.Extensions.InGameExt.GetUnityToSimulation(thisAssets.Scripts.Unity.UI_New.InGame.InGame).inGame'></a>

`inGame` [Assets.Scripts.Unity.UI_New.InGame.InGame](https://docs.microsoft.com/en-us/dotnet/api/Assets.Scripts.Unity.UI_New.InGame.InGame 'Assets.Scripts.Unity.UI_New.InGame.InGame')

#### Returns
[Assets.Scripts.Unity.Bridge.UnityToSimulation](https://docs.microsoft.com/en-us/dotnet/api/Assets.Scripts.Unity.Bridge.UnityToSimulation 'Assets.Scripts.Unity.Bridge.UnityToSimulation')

<a name='BTD_Mod_Helper.Extensions.InGameExt.IsCoOpReady(thisAssets.Scripts.Unity.UI_New.InGame.InGame)'></a>

## InGameExt.IsCoOpReady(this InGame) Method

Returns true if the initial co-op handshake has finished and user has co-op game details.

```csharp
public static bool IsCoOpReady(this Assets.Scripts.Unity.UI_New.InGame.InGame inGame);
```
#### Parameters

<a name='BTD_Mod_Helper.Extensions.InGameExt.IsCoOpReady(thisAssets.Scripts.Unity.UI_New.InGame.InGame).inGame'></a>

`inGame` [Assets.Scripts.Unity.UI_New.InGame.InGame](https://docs.microsoft.com/en-us/dotnet/api/Assets.Scripts.Unity.UI_New.InGame.InGame 'Assets.Scripts.Unity.UI_New.InGame.InGame')

The game.

#### Returns
[System.Boolean](https://docs.microsoft.com/en-us/dotnet/api/System.Boolean 'System.Boolean')

<a name='BTD_Mod_Helper.Extensions.InGameExt.IsInGame(thisAssets.Scripts.Unity.UI_New.InGame.InGame)'></a>

## InGameExt.IsInGame(this InGame) Method

Returns whether or not the player is currently in a game.

```csharp
public static bool IsInGame(this Assets.Scripts.Unity.UI_New.InGame.InGame inGame);
```
#### Parameters

<a name='BTD_Mod_Helper.Extensions.InGameExt.IsInGame(thisAssets.Scripts.Unity.UI_New.InGame.InGame).inGame'></a>

`inGame` [Assets.Scripts.Unity.UI_New.InGame.InGame](https://docs.microsoft.com/en-us/dotnet/api/Assets.Scripts.Unity.UI_New.InGame.InGame 'Assets.Scripts.Unity.UI_New.InGame.InGame')

#### Returns
[System.Boolean](https://docs.microsoft.com/en-us/dotnet/api/System.Boolean 'System.Boolean')

<a name='BTD_Mod_Helper.Extensions.InGameExt.SellTower(thisAssets.Scripts.Unity.UI_New.InGame.InGame,Assets.Scripts.Simulation.Towers.Tower)'></a>

## InGameExt.SellTower(this InGame, Tower) Method

Sells a tower

```csharp
public static void SellTower(this Assets.Scripts.Unity.UI_New.InGame.InGame inGame, Assets.Scripts.Simulation.Towers.Tower tower);
```
#### Parameters

<a name='BTD_Mod_Helper.Extensions.InGameExt.SellTower(thisAssets.Scripts.Unity.UI_New.InGame.InGame,Assets.Scripts.Simulation.Towers.Tower).inGame'></a>

`inGame` [Assets.Scripts.Unity.UI_New.InGame.InGame](https://docs.microsoft.com/en-us/dotnet/api/Assets.Scripts.Unity.UI_New.InGame.InGame 'Assets.Scripts.Unity.UI_New.InGame.InGame')

<a name='BTD_Mod_Helper.Extensions.InGameExt.SellTower(thisAssets.Scripts.Unity.UI_New.InGame.InGame,Assets.Scripts.Simulation.Towers.Tower).tower'></a>

`tower` [Assets.Scripts.Simulation.Towers.Tower](https://docs.microsoft.com/en-us/dotnet/api/Assets.Scripts.Simulation.Towers.Tower 'Assets.Scripts.Simulation.Towers.Tower')

<a name='BTD_Mod_Helper.Extensions.InGameExt.SellTowers(thisAssets.Scripts.Unity.UI_New.InGame.InGame,System.Collections.Generic.List_Assets.Scripts.Simulation.Towers.Tower_)'></a>

## InGameExt.SellTowers(this InGame, List<Tower>) Method

Sells multiple towers

```csharp
public static void SellTowers(this Assets.Scripts.Unity.UI_New.InGame.InGame inGame, System.Collections.Generic.List<Assets.Scripts.Simulation.Towers.Tower> towers);
```
#### Parameters

<a name='BTD_Mod_Helper.Extensions.InGameExt.SellTowers(thisAssets.Scripts.Unity.UI_New.InGame.InGame,System.Collections.Generic.List_Assets.Scripts.Simulation.Towers.Tower_).inGame'></a>

`inGame` [Assets.Scripts.Unity.UI_New.InGame.InGame](https://docs.microsoft.com/en-us/dotnet/api/Assets.Scripts.Unity.UI_New.InGame.InGame 'Assets.Scripts.Unity.UI_New.InGame.InGame')

<a name='BTD_Mod_Helper.Extensions.InGameExt.SellTowers(thisAssets.Scripts.Unity.UI_New.InGame.InGame,System.Collections.Generic.List_Assets.Scripts.Simulation.Towers.Tower_).towers'></a>

`towers` [System.Collections.Generic.List&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.List-1 'System.Collections.Generic.List`1')[Assets.Scripts.Simulation.Towers.Tower](https://docs.microsoft.com/en-us/dotnet/api/Assets.Scripts.Simulation.Towers.Tower 'Assets.Scripts.Simulation.Towers.Tower')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.List-1 'System.Collections.Generic.List`1')

<a name='BTD_Mod_Helper.Extensions.InGameExt.SetCash(thisAssets.Scripts.Unity.UI_New.InGame.InGame,double)'></a>

## InGameExt.SetCash(this InGame, double) Method

Set the Player's cash to a specific amount

```csharp
public static void SetCash(this Assets.Scripts.Unity.UI_New.InGame.InGame inGame, double amount);
```
#### Parameters

<a name='BTD_Mod_Helper.Extensions.InGameExt.SetCash(thisAssets.Scripts.Unity.UI_New.InGame.InGame,double).inGame'></a>

`inGame` [Assets.Scripts.Unity.UI_New.InGame.InGame](https://docs.microsoft.com/en-us/dotnet/api/Assets.Scripts.Unity.UI_New.InGame.InGame 'Assets.Scripts.Unity.UI_New.InGame.InGame')

InGame instance

<a name='BTD_Mod_Helper.Extensions.InGameExt.SetCash(thisAssets.Scripts.Unity.UI_New.InGame.InGame,double).amount'></a>

`amount` [System.Double](https://docs.microsoft.com/en-us/dotnet/api/System.Double 'System.Double')

Value to set cash to

<a name='BTD_Mod_Helper.Extensions.InGameExt.SetHealth(thisAssets.Scripts.Unity.UI_New.InGame.InGame,double)'></a>

## InGameExt.SetHealth(this InGame, double) Method

Set player's health to specific amount

```csharp
public static void SetHealth(this Assets.Scripts.Unity.UI_New.InGame.InGame inGame, double amount);
```
#### Parameters

<a name='BTD_Mod_Helper.Extensions.InGameExt.SetHealth(thisAssets.Scripts.Unity.UI_New.InGame.InGame,double).inGame'></a>

`inGame` [Assets.Scripts.Unity.UI_New.InGame.InGame](https://docs.microsoft.com/en-us/dotnet/api/Assets.Scripts.Unity.UI_New.InGame.InGame 'Assets.Scripts.Unity.UI_New.InGame.InGame')

InGame instance

<a name='BTD_Mod_Helper.Extensions.InGameExt.SetHealth(thisAssets.Scripts.Unity.UI_New.InGame.InGame,double).amount'></a>

`amount` [System.Double](https://docs.microsoft.com/en-us/dotnet/api/System.Double 'System.Double')

Value to set health to

<a name='BTD_Mod_Helper.Extensions.InGameExt.SetMaxHealth(thisAssets.Scripts.Unity.UI_New.InGame.InGame,double)'></a>

## InGameExt.SetMaxHealth(this InGame, double) Method

Set the player's maximum health to a new value

```csharp
public static void SetMaxHealth(this Assets.Scripts.Unity.UI_New.InGame.InGame inGame, double amount);
```
#### Parameters

<a name='BTD_Mod_Helper.Extensions.InGameExt.SetMaxHealth(thisAssets.Scripts.Unity.UI_New.InGame.InGame,double).inGame'></a>

`inGame` [Assets.Scripts.Unity.UI_New.InGame.InGame](https://docs.microsoft.com/en-us/dotnet/api/Assets.Scripts.Unity.UI_New.InGame.InGame 'Assets.Scripts.Unity.UI_New.InGame.InGame')

InGame instance

<a name='BTD_Mod_Helper.Extensions.InGameExt.SetMaxHealth(thisAssets.Scripts.Unity.UI_New.InGame.InGame,double).amount'></a>

`amount` [System.Double](https://docs.microsoft.com/en-us/dotnet/api/System.Double 'System.Double')

Value to set max health to

<a name='BTD_Mod_Helper.Extensions.InGameExt.SetRound(thisAssets.Scripts.Unity.UI_New.InGame.InGame,int)'></a>

## InGameExt.SetRound(this InGame, int) Method

Set the current round

```csharp
public static void SetRound(this Assets.Scripts.Unity.UI_New.InGame.InGame inGame, int round);
```
#### Parameters

<a name='BTD_Mod_Helper.Extensions.InGameExt.SetRound(thisAssets.Scripts.Unity.UI_New.InGame.InGame,int).inGame'></a>

`inGame` [Assets.Scripts.Unity.UI_New.InGame.InGame](https://docs.microsoft.com/en-us/dotnet/api/Assets.Scripts.Unity.UI_New.InGame.InGame 'Assets.Scripts.Unity.UI_New.InGame.InGame')

<a name='BTD_Mod_Helper.Extensions.InGameExt.SetRound(thisAssets.Scripts.Unity.UI_New.InGame.InGame,int).round'></a>

`round` [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/System.Int32 'System.Int32')

<a name='BTD_Mod_Helper.Extensions.InGameExt.SetRoundSet(thisAssets.Scripts.Unity.UI_New.InGame.InGame,Assets.Scripts.Models.Rounds.RoundSetModel)'></a>

## InGameExt.SetRoundSet(this InGame, RoundSetModel) Method

Custom API method that changes the game's round set to a custom RoundSetModel.

```csharp
public static void SetRoundSet(this Assets.Scripts.Unity.UI_New.InGame.InGame inGame, Assets.Scripts.Models.Rounds.RoundSetModel roundSet);
```
#### Parameters

<a name='BTD_Mod_Helper.Extensions.InGameExt.SetRoundSet(thisAssets.Scripts.Unity.UI_New.InGame.InGame,Assets.Scripts.Models.Rounds.RoundSetModel).inGame'></a>

`inGame` [Assets.Scripts.Unity.UI_New.InGame.InGame](https://docs.microsoft.com/en-us/dotnet/api/Assets.Scripts.Unity.UI_New.InGame.InGame 'Assets.Scripts.Unity.UI_New.InGame.InGame')

<a name='BTD_Mod_Helper.Extensions.InGameExt.SetRoundSet(thisAssets.Scripts.Unity.UI_New.InGame.InGame,Assets.Scripts.Models.Rounds.RoundSetModel).roundSet'></a>

`roundSet` [Assets.Scripts.Models.Rounds.RoundSetModel](https://docs.microsoft.com/en-us/dotnet/api/Assets.Scripts.Models.Rounds.RoundSetModel 'Assets.Scripts.Models.Rounds.RoundSetModel')

New Round Set Model to use

<a name='BTD_Mod_Helper.Extensions.InGameExt.SpawnBloons(thisAssets.Scripts.Unity.UI_New.InGame.InGame,Il2CppSystem.Collections.Generic.List_Assets.Scripts.Models.Rounds.BloonEmissionModel_)'></a>

## InGameExt.SpawnBloons(this InGame, List<BloonEmissionModel>) Method

Spawn bloons in game

```csharp
public static void SpawnBloons(this Assets.Scripts.Unity.UI_New.InGame.InGame inGame, Il2CppSystem.Collections.Generic.List<Assets.Scripts.Models.Rounds.BloonEmissionModel> bloonEmissionModels);
```
#### Parameters

<a name='BTD_Mod_Helper.Extensions.InGameExt.SpawnBloons(thisAssets.Scripts.Unity.UI_New.InGame.InGame,Il2CppSystem.Collections.Generic.List_Assets.Scripts.Models.Rounds.BloonEmissionModel_).inGame'></a>

`inGame` [Assets.Scripts.Unity.UI_New.InGame.InGame](https://docs.microsoft.com/en-us/dotnet/api/Assets.Scripts.Unity.UI_New.InGame.InGame 'Assets.Scripts.Unity.UI_New.InGame.InGame')

<a name='BTD_Mod_Helper.Extensions.InGameExt.SpawnBloons(thisAssets.Scripts.Unity.UI_New.InGame.InGame,Il2CppSystem.Collections.Generic.List_Assets.Scripts.Models.Rounds.BloonEmissionModel_).bloonEmissionModels'></a>

`bloonEmissionModels` [Il2CppSystem.Collections.Generic.List&lt;](https://docs.microsoft.com/en-us/dotnet/api/Il2CppSystem.Collections.Generic.List-1 'Il2CppSystem.Collections.Generic.List`1')[Assets.Scripts.Models.Rounds.BloonEmissionModel](https://docs.microsoft.com/en-us/dotnet/api/Assets.Scripts.Models.Rounds.BloonEmissionModel 'Assets.Scripts.Models.Rounds.BloonEmissionModel')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/Il2CppSystem.Collections.Generic.List-1 'Il2CppSystem.Collections.Generic.List`1')

<a name='BTD_Mod_Helper.Extensions.InGameExt.SpawnBloons(thisAssets.Scripts.Unity.UI_New.InGame.InGame,int)'></a>

## InGameExt.SpawnBloons(this InGame, int) Method

Spawn bloons in game

```csharp
public static void SpawnBloons(this Assets.Scripts.Unity.UI_New.InGame.InGame inGame, int round);
```
#### Parameters

<a name='BTD_Mod_Helper.Extensions.InGameExt.SpawnBloons(thisAssets.Scripts.Unity.UI_New.InGame.InGame,int).inGame'></a>

`inGame` [Assets.Scripts.Unity.UI_New.InGame.InGame](https://docs.microsoft.com/en-us/dotnet/api/Assets.Scripts.Unity.UI_New.InGame.InGame 'Assets.Scripts.Unity.UI_New.InGame.InGame')

<a name='BTD_Mod_Helper.Extensions.InGameExt.SpawnBloons(thisAssets.Scripts.Unity.UI_New.InGame.InGame,int).round'></a>

`round` [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/System.Int32 'System.Int32')

<a name='BTD_Mod_Helper.Extensions.InGameExt.SpawnBloons(thisAssets.Scripts.Unity.UI_New.InGame.InGame,string,int,float)'></a>

## InGameExt.SpawnBloons(this InGame, string, int, float) Method

Spawn bloons in game

```csharp
public static void SpawnBloons(this Assets.Scripts.Unity.UI_New.InGame.InGame inGame, string bloonName, int number, float spacing);
```
#### Parameters

<a name='BTD_Mod_Helper.Extensions.InGameExt.SpawnBloons(thisAssets.Scripts.Unity.UI_New.InGame.InGame,string,int,float).inGame'></a>

`inGame` [Assets.Scripts.Unity.UI_New.InGame.InGame](https://docs.microsoft.com/en-us/dotnet/api/Assets.Scripts.Unity.UI_New.InGame.InGame 'Assets.Scripts.Unity.UI_New.InGame.InGame')

<a name='BTD_Mod_Helper.Extensions.InGameExt.SpawnBloons(thisAssets.Scripts.Unity.UI_New.InGame.InGame,string,int,float).bloonName'></a>

`bloonName` [System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')

<a name='BTD_Mod_Helper.Extensions.InGameExt.SpawnBloons(thisAssets.Scripts.Unity.UI_New.InGame.InGame,string,int,float).number'></a>

`number` [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/System.Int32 'System.Int32')

<a name='BTD_Mod_Helper.Extensions.InGameExt.SpawnBloons(thisAssets.Scripts.Unity.UI_New.InGame.InGame,string,int,float).spacing'></a>

`spacing` [System.Single](https://docs.microsoft.com/en-us/dotnet/api/System.Single 'System.Single')

<a name='BTD_Mod_Helper.Extensions.InGameExt.SpawnBloons(thisAssets.Scripts.Unity.UI_New.InGame.InGame,System.Collections.Generic.List_Assets.Scripts.Models.Rounds.BloonEmissionModel_)'></a>

## InGameExt.SpawnBloons(this InGame, List<BloonEmissionModel>) Method

Spawn bloons in game

```csharp
public static void SpawnBloons(this Assets.Scripts.Unity.UI_New.InGame.InGame inGame, System.Collections.Generic.List<Assets.Scripts.Models.Rounds.BloonEmissionModel> bloonEmissionModels);
```
#### Parameters

<a name='BTD_Mod_Helper.Extensions.InGameExt.SpawnBloons(thisAssets.Scripts.Unity.UI_New.InGame.InGame,System.Collections.Generic.List_Assets.Scripts.Models.Rounds.BloonEmissionModel_).inGame'></a>

`inGame` [Assets.Scripts.Unity.UI_New.InGame.InGame](https://docs.microsoft.com/en-us/dotnet/api/Assets.Scripts.Unity.UI_New.InGame.InGame 'Assets.Scripts.Unity.UI_New.InGame.InGame')

<a name='BTD_Mod_Helper.Extensions.InGameExt.SpawnBloons(thisAssets.Scripts.Unity.UI_New.InGame.InGame,System.Collections.Generic.List_Assets.Scripts.Models.Rounds.BloonEmissionModel_).bloonEmissionModels'></a>

`bloonEmissionModels` [System.Collections.Generic.List&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.List-1 'System.Collections.Generic.List`1')[Assets.Scripts.Models.Rounds.BloonEmissionModel](https://docs.microsoft.com/en-us/dotnet/api/Assets.Scripts.Models.Rounds.BloonEmissionModel 'Assets.Scripts.Models.Rounds.BloonEmissionModel')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.List-1 'System.Collections.Generic.List`1')

<a name='BTD_Mod_Helper.Extensions.InGameExt.SpawnBloons(thisAssets.Scripts.Unity.UI_New.InGame.InGame,UnhollowerBaseLib.Il2CppReferenceArray_Assets.Scripts.Models.Rounds.BloonEmissionModel_)'></a>

## InGameExt.SpawnBloons(this InGame, Il2CppReferenceArray<BloonEmissionModel>) Method

Spawn bloons in game

```csharp
public static void SpawnBloons(this Assets.Scripts.Unity.UI_New.InGame.InGame inGame, UnhollowerBaseLib.Il2CppReferenceArray<Assets.Scripts.Models.Rounds.BloonEmissionModel> bloonEmissionModels);
```
#### Parameters

<a name='BTD_Mod_Helper.Extensions.InGameExt.SpawnBloons(thisAssets.Scripts.Unity.UI_New.InGame.InGame,UnhollowerBaseLib.Il2CppReferenceArray_Assets.Scripts.Models.Rounds.BloonEmissionModel_).inGame'></a>

`inGame` [Assets.Scripts.Unity.UI_New.InGame.InGame](https://docs.microsoft.com/en-us/dotnet/api/Assets.Scripts.Unity.UI_New.InGame.InGame 'Assets.Scripts.Unity.UI_New.InGame.InGame')

<a name='BTD_Mod_Helper.Extensions.InGameExt.SpawnBloons(thisAssets.Scripts.Unity.UI_New.InGame.InGame,UnhollowerBaseLib.Il2CppReferenceArray_Assets.Scripts.Models.Rounds.BloonEmissionModel_).bloonEmissionModels'></a>

`bloonEmissionModels` [UnhollowerBaseLib.Il2CppReferenceArray&lt;](https://docs.microsoft.com/en-us/dotnet/api/UnhollowerBaseLib.Il2CppReferenceArray-1 'UnhollowerBaseLib.Il2CppReferenceArray`1')[Assets.Scripts.Models.Rounds.BloonEmissionModel](https://docs.microsoft.com/en-us/dotnet/api/Assets.Scripts.Models.Rounds.BloonEmissionModel 'Assets.Scripts.Models.Rounds.BloonEmissionModel')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/UnhollowerBaseLib.Il2CppReferenceArray-1 'UnhollowerBaseLib.Il2CppReferenceArray`1')