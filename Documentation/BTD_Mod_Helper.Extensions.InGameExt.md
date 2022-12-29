#### [BloonsTD6 Mod Helper](README.md 'README')
### [BTD_Mod_Helper.Extensions](README.md#BTD_Mod_Helper.Extensions 'BTD_Mod_Helper.Extensions')

## InGameExt Class

Extensions for the InGame class

```csharp
public static class InGameExt
```

Inheritance [System.Object](https://docs.microsoft.com/en-us/dotnet/api/System.Object 'System.Object') &#129106; InGameExt
### Methods

<a name='BTD_Mod_Helper.Extensions.InGameExt.AddCash(thisInGame,double)'></a>

## InGameExt.AddCash(this InGame, double) Method

Add cash to the Player's wallet

```csharp
public static void AddCash(this InGame inGame, double amount);
```
#### Parameters

<a name='BTD_Mod_Helper.Extensions.InGameExt.AddCash(thisInGame,double).inGame'></a>

`inGame` [Il2CppAssets.Scripts.Unity.UI_New.InGame.InGame](https://docs.microsoft.com/en-us/dotnet/api/Il2CppAssets.Scripts.Unity.UI_New.InGame.InGame 'Il2CppAssets.Scripts.Unity.UI_New.InGame.InGame')

InGame instance

<a name='BTD_Mod_Helper.Extensions.InGameExt.AddCash(thisInGame,double).amount'></a>

`amount` [System.Double](https://docs.microsoft.com/en-us/dotnet/api/System.Double 'System.Double')

Amount of cash to add to player wallet

<a name='BTD_Mod_Helper.Extensions.InGameExt.AddHealth(thisInGame,double)'></a>

## InGameExt.AddHealth(this InGame, double) Method

Add health to the players current health

```csharp
public static void AddHealth(this InGame inGame, double amount);
```
#### Parameters

<a name='BTD_Mod_Helper.Extensions.InGameExt.AddHealth(thisInGame,double).inGame'></a>

`inGame` [Il2CppAssets.Scripts.Unity.UI_New.InGame.InGame](https://docs.microsoft.com/en-us/dotnet/api/Il2CppAssets.Scripts.Unity.UI_New.InGame.InGame 'Il2CppAssets.Scripts.Unity.UI_New.InGame.InGame')

InGame instance

<a name='BTD_Mod_Helper.Extensions.InGameExt.AddHealth(thisInGame,double).amount'></a>

`amount` [System.Double](https://docs.microsoft.com/en-us/dotnet/api/System.Double 'System.Double')

Amount of health to add

<a name='BTD_Mod_Helper.Extensions.InGameExt.AddMaxHealth(thisInGame,double)'></a>

## InGameExt.AddMaxHealth(this InGame, double) Method

Add to the player's max health

```csharp
public static void AddMaxHealth(this InGame inGame, double amount);
```
#### Parameters

<a name='BTD_Mod_Helper.Extensions.InGameExt.AddMaxHealth(thisInGame,double).inGame'></a>

`inGame` [Il2CppAssets.Scripts.Unity.UI_New.InGame.InGame](https://docs.microsoft.com/en-us/dotnet/api/Il2CppAssets.Scripts.Unity.UI_New.InGame.InGame 'Il2CppAssets.Scripts.Unity.UI_New.InGame.InGame')

InGame instance

<a name='BTD_Mod_Helper.Extensions.InGameExt.AddMaxHealth(thisInGame,double).amount'></a>

`amount` [System.Double](https://docs.microsoft.com/en-us/dotnet/api/System.Double 'System.Double')

Amount to add to the player's max health

<a name='BTD_Mod_Helper.Extensions.InGameExt.GetAbilities(thisInGame)'></a>

## InGameExt.GetAbilities(this InGame) Method

Get's all AbilityToSimulations currently in the game

```csharp
public static System.Collections.Generic.List<AbilityToSimulation> GetAbilities(this InGame inGame);
```
#### Parameters

<a name='BTD_Mod_Helper.Extensions.InGameExt.GetAbilities(thisInGame).inGame'></a>

`inGame` [Il2CppAssets.Scripts.Unity.UI_New.InGame.InGame](https://docs.microsoft.com/en-us/dotnet/api/Il2CppAssets.Scripts.Unity.UI_New.InGame.InGame 'Il2CppAssets.Scripts.Unity.UI_New.InGame.InGame')

#### Returns
[System.Collections.Generic.List&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.List-1 'System.Collections.Generic.List`1')[Il2CppAssets.Scripts.Unity.Bridge.AbilityToSimulation](https://docs.microsoft.com/en-us/dotnet/api/Il2CppAssets.Scripts.Unity.Bridge.AbilityToSimulation 'Il2CppAssets.Scripts.Unity.Bridge.AbilityToSimulation')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.List-1 'System.Collections.Generic.List`1')

<a name='BTD_Mod_Helper.Extensions.InGameExt.GetAllBloonToSim(thisInGame)'></a>

## InGameExt.GetAllBloonToSim(this InGame) Method

Get's all existing BloonToSimulations

```csharp
public static System.Collections.Generic.List<BloonToSimulation> GetAllBloonToSim(this InGame inGame);
```
#### Parameters

<a name='BTD_Mod_Helper.Extensions.InGameExt.GetAllBloonToSim(thisInGame).inGame'></a>

`inGame` [Il2CppAssets.Scripts.Unity.UI_New.InGame.InGame](https://docs.microsoft.com/en-us/dotnet/api/Il2CppAssets.Scripts.Unity.UI_New.InGame.InGame 'Il2CppAssets.Scripts.Unity.UI_New.InGame.InGame')

#### Returns
[System.Collections.Generic.List&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.List-1 'System.Collections.Generic.List`1')[Il2CppAssets.Scripts.Unity.Bridge.BloonToSimulation](https://docs.microsoft.com/en-us/dotnet/api/Il2CppAssets.Scripts.Unity.Bridge.BloonToSimulation 'Il2CppAssets.Scripts.Unity.Bridge.BloonToSimulation')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.List-1 'System.Collections.Generic.List`1')

<a name='BTD_Mod_Helper.Extensions.InGameExt.GetAllObjectsOfType_T_(thisInGame)'></a>

## InGameExt.GetAllObjectsOfType<T>(this InGame) Method

Gets all objects of type T. Does this by returning all objects created by the Factory of type T

```csharp
public static System.Collections.Generic.List<T> GetAllObjectsOfType<T>(this InGame inGame)
    where T : RootObject, new();
```
#### Type parameters

<a name='BTD_Mod_Helper.Extensions.InGameExt.GetAllObjectsOfType_T_(thisInGame).T'></a>

`T`

The type of items you want
#### Parameters

<a name='BTD_Mod_Helper.Extensions.InGameExt.GetAllObjectsOfType_T_(thisInGame).inGame'></a>

`inGame` [Il2CppAssets.Scripts.Unity.UI_New.InGame.InGame](https://docs.microsoft.com/en-us/dotnet/api/Il2CppAssets.Scripts.Unity.UI_New.InGame.InGame 'Il2CppAssets.Scripts.Unity.UI_New.InGame.InGame')

#### Returns
[System.Collections.Generic.List&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.List-1 'System.Collections.Generic.List`1')[T](BTD_Mod_Helper.Extensions.InGameExt.md#BTD_Mod_Helper.Extensions.InGameExt.GetAllObjectsOfType_T_(thisInGame).T 'BTD_Mod_Helper.Extensions.InGameExt.GetAllObjectsOfType<T>(this InGame).T')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.List-1 'System.Collections.Generic.List`1')

<a name='BTD_Mod_Helper.Extensions.InGameExt.GetAllTowerToSim(thisInGame,string)'></a>

## InGameExt.GetAllTowerToSim(this InGame, string) Method

Get all TowerToSimulations

```csharp
public static System.Collections.Generic.List<TowerToSimulation> GetAllTowerToSim(this InGame inGame, string name=null);
```
#### Parameters

<a name='BTD_Mod_Helper.Extensions.InGameExt.GetAllTowerToSim(thisInGame,string).inGame'></a>

`inGame` [Il2CppAssets.Scripts.Unity.UI_New.InGame.InGame](https://docs.microsoft.com/en-us/dotnet/api/Il2CppAssets.Scripts.Unity.UI_New.InGame.InGame 'Il2CppAssets.Scripts.Unity.UI_New.InGame.InGame')

<a name='BTD_Mod_Helper.Extensions.InGameExt.GetAllTowerToSim(thisInGame,string).name'></a>

`name` [System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')

Optionally only get Towers whose TowerModel name is this parameter

#### Returns
[System.Collections.Generic.List&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.List-1 'System.Collections.Generic.List`1')[Il2CppAssets.Scripts.Unity.Bridge.TowerToSimulation](https://docs.microsoft.com/en-us/dotnet/api/Il2CppAssets.Scripts.Unity.Bridge.TowerToSimulation 'Il2CppAssets.Scripts.Unity.Bridge.TowerToSimulation')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.List-1 'System.Collections.Generic.List`1')

<a name='BTD_Mod_Helper.Extensions.InGameExt.GetBloons(thisInGame)'></a>

## InGameExt.GetBloons(this InGame) Method

Get's all Bloons on the map

```csharp
public static System.Collections.Generic.List<Bloon> GetBloons(this InGame inGame);
```
#### Parameters

<a name='BTD_Mod_Helper.Extensions.InGameExt.GetBloons(thisInGame).inGame'></a>

`inGame` [Il2CppAssets.Scripts.Unity.UI_New.InGame.InGame](https://docs.microsoft.com/en-us/dotnet/api/Il2CppAssets.Scripts.Unity.UI_New.InGame.InGame 'Il2CppAssets.Scripts.Unity.UI_New.InGame.InGame')

#### Returns
[System.Collections.Generic.List&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.List-1 'System.Collections.Generic.List`1')[Il2CppAssets.Scripts.Simulation.Bloons.Bloon](https://docs.microsoft.com/en-us/dotnet/api/Il2CppAssets.Scripts.Simulation.Bloons.Bloon 'Il2CppAssets.Scripts.Simulation.Bloons.Bloon')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.List-1 'System.Collections.Generic.List`1')

<a name='BTD_Mod_Helper.Extensions.InGameExt.GetCash(thisInGame)'></a>

## InGameExt.GetCash(this InGame) Method

Get the Player's current cash

```csharp
public static double GetCash(this InGame inGame);
```
#### Parameters

<a name='BTD_Mod_Helper.Extensions.InGameExt.GetCash(thisInGame).inGame'></a>

`inGame` [Il2CppAssets.Scripts.Unity.UI_New.InGame.InGame](https://docs.microsoft.com/en-us/dotnet/api/Il2CppAssets.Scripts.Unity.UI_New.InGame.InGame 'Il2CppAssets.Scripts.Unity.UI_New.InGame.InGame')

#### Returns
[System.Double](https://docs.microsoft.com/en-us/dotnet/api/System.Double 'System.Double')

<a name='BTD_Mod_Helper.Extensions.InGameExt.GetCashManager(thisInGame,int)'></a>

## InGameExt.GetCashManager(this InGame, int) Method

Get the Cash Manager for the current game

```csharp
public static CashManager GetCashManager(this InGame inGame, int index=0);
```
#### Parameters

<a name='BTD_Mod_Helper.Extensions.InGameExt.GetCashManager(thisInGame,int).inGame'></a>

`inGame` [Il2CppAssets.Scripts.Unity.UI_New.InGame.InGame](https://docs.microsoft.com/en-us/dotnet/api/Il2CppAssets.Scripts.Unity.UI_New.InGame.InGame 'Il2CppAssets.Scripts.Unity.UI_New.InGame.InGame')

InGame instance

<a name='BTD_Mod_Helper.Extensions.InGameExt.GetCashManager(thisInGame,int).index'></a>

`index` [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/System.Int32 'System.Int32')

Index of the cash manager. Default is 0

#### Returns
[Il2CppAssets.Scripts.Simulation.CashManager](https://docs.microsoft.com/en-us/dotnet/api/Il2CppAssets.Scripts.Simulation.CashManager 'Il2CppAssets.Scripts.Simulation.CashManager')

<a name='BTD_Mod_Helper.Extensions.InGameExt.GetFactory_T_(thisInGame)'></a>

## InGameExt.GetFactory<T>(this InGame) Method

Get the Factory for a specific Type. Ex: Getting the Factory that makes Towers

```csharp
public static Factory<T> GetFactory<T>(this InGame inGame)
    where T : RootObject, new();
```
#### Type parameters

<a name='BTD_Mod_Helper.Extensions.InGameExt.GetFactory_T_(thisInGame).T'></a>

`T`
#### Parameters

<a name='BTD_Mod_Helper.Extensions.InGameExt.GetFactory_T_(thisInGame).inGame'></a>

`inGame` [Il2CppAssets.Scripts.Unity.UI_New.InGame.InGame](https://docs.microsoft.com/en-us/dotnet/api/Il2CppAssets.Scripts.Unity.UI_New.InGame.InGame 'Il2CppAssets.Scripts.Unity.UI_New.InGame.InGame')

#### Returns
[Il2CppAssets.Scripts.Simulation.Factory.Factory](https://docs.microsoft.com/en-us/dotnet/api/Il2CppAssets.Scripts.Simulation.Factory.Factory 'Il2CppAssets.Scripts.Simulation.Factory.Factory')

<a name='BTD_Mod_Helper.Extensions.InGameExt.GetGameModel(thisInGame)'></a>

## InGameExt.GetGameModel(this InGame) Method

The Game.model that is being used for this InGame.instance

```csharp
public static GameModel GetGameModel(this InGame inGame);
```
#### Parameters

<a name='BTD_Mod_Helper.Extensions.InGameExt.GetGameModel(thisInGame).inGame'></a>

`inGame` [Il2CppAssets.Scripts.Unity.UI_New.InGame.InGame](https://docs.microsoft.com/en-us/dotnet/api/Il2CppAssets.Scripts.Unity.UI_New.InGame.InGame 'Il2CppAssets.Scripts.Unity.UI_New.InGame.InGame')

#### Returns
[Il2CppAssets.Scripts.Models.GameModel](https://docs.microsoft.com/en-us/dotnet/api/Il2CppAssets.Scripts.Models.GameModel 'Il2CppAssets.Scripts.Models.GameModel')

<a name='BTD_Mod_Helper.Extensions.InGameExt.GetHealth(thisInGame)'></a>

## InGameExt.GetHealth(this InGame) Method

Get the Player's current health

```csharp
public static double GetHealth(this InGame inGame);
```
#### Parameters

<a name='BTD_Mod_Helper.Extensions.InGameExt.GetHealth(thisInGame).inGame'></a>

`inGame` [Il2CppAssets.Scripts.Unity.UI_New.InGame.InGame](https://docs.microsoft.com/en-us/dotnet/api/Il2CppAssets.Scripts.Unity.UI_New.InGame.InGame 'Il2CppAssets.Scripts.Unity.UI_New.InGame.InGame')

#### Returns
[System.Double](https://docs.microsoft.com/en-us/dotnet/api/System.Double 'System.Double')

<a name='BTD_Mod_Helper.Extensions.InGameExt.GetInGameUI(thisInGame)'></a>

## InGameExt.GetInGameUI(this InGame) Method

Get the game object that owns all InGame UI elements

```csharp
public static GameObject GetInGameUI(this InGame inGame);
```
#### Parameters

<a name='BTD_Mod_Helper.Extensions.InGameExt.GetInGameUI(thisInGame).inGame'></a>

`inGame` [Il2CppAssets.Scripts.Unity.UI_New.InGame.InGame](https://docs.microsoft.com/en-us/dotnet/api/Il2CppAssets.Scripts.Unity.UI_New.InGame.InGame 'Il2CppAssets.Scripts.Unity.UI_New.InGame.InGame')

#### Returns
[UnityEngine.GameObject](https://docs.microsoft.com/en-us/dotnet/api/UnityEngine.GameObject 'UnityEngine.GameObject')

<a name='BTD_Mod_Helper.Extensions.InGameExt.GetMainFactory(thisInGame)'></a>

## InGameExt.GetMainFactory(this InGame) Method

Get the main Factory that creates and manages all other Factories

```csharp
public static FactoryFactory GetMainFactory(this InGame inGame);
```
#### Parameters

<a name='BTD_Mod_Helper.Extensions.InGameExt.GetMainFactory(thisInGame).inGame'></a>

`inGame` [Il2CppAssets.Scripts.Unity.UI_New.InGame.InGame](https://docs.microsoft.com/en-us/dotnet/api/Il2CppAssets.Scripts.Unity.UI_New.InGame.InGame 'Il2CppAssets.Scripts.Unity.UI_New.InGame.InGame')

#### Returns
[Il2CppAssets.Scripts.Simulation.Factory.FactoryFactory](https://docs.microsoft.com/en-us/dotnet/api/Il2CppAssets.Scripts.Simulation.Factory.FactoryFactory 'Il2CppAssets.Scripts.Simulation.Factory.FactoryFactory')

<a name='BTD_Mod_Helper.Extensions.InGameExt.GetMap(thisInGame)'></a>

## InGameExt.GetMap(this InGame) Method

Get the current Map

```csharp
public static Map GetMap(this InGame inGame);
```
#### Parameters

<a name='BTD_Mod_Helper.Extensions.InGameExt.GetMap(thisInGame).inGame'></a>

`inGame` [Il2CppAssets.Scripts.Unity.UI_New.InGame.InGame](https://docs.microsoft.com/en-us/dotnet/api/Il2CppAssets.Scripts.Unity.UI_New.InGame.InGame 'Il2CppAssets.Scripts.Unity.UI_New.InGame.InGame')

#### Returns
[Il2CppAssets.Scripts.Simulation.Track.Map](https://docs.microsoft.com/en-us/dotnet/api/Il2CppAssets.Scripts.Simulation.Track.Map 'Il2CppAssets.Scripts.Simulation.Track.Map')

<a name='BTD_Mod_Helper.Extensions.InGameExt.GetMaxHealth(thisInGame)'></a>

## InGameExt.GetMaxHealth(this InGame) Method

Get the player's max health

```csharp
public static double GetMaxHealth(this InGame inGame);
```
#### Parameters

<a name='BTD_Mod_Helper.Extensions.InGameExt.GetMaxHealth(thisInGame).inGame'></a>

`inGame` [Il2CppAssets.Scripts.Unity.UI_New.InGame.InGame](https://docs.microsoft.com/en-us/dotnet/api/Il2CppAssets.Scripts.Unity.UI_New.InGame.InGame 'Il2CppAssets.Scripts.Unity.UI_New.InGame.InGame')

#### Returns
[System.Double](https://docs.microsoft.com/en-us/dotnet/api/System.Double 'System.Double')

<a name='BTD_Mod_Helper.Extensions.InGameExt.GetPoppedBloons(thisInGame)'></a>

## InGameExt.GetPoppedBloons(this InGame) Method

Get collection of popped bloons in this game. Right now only works for current games. Does not store results from loaded games

```csharp
public static System.Collections.Generic.Dictionary<string,int> GetPoppedBloons(this InGame inGame);
```
#### Parameters

<a name='BTD_Mod_Helper.Extensions.InGameExt.GetPoppedBloons(thisInGame).inGame'></a>

`inGame` [Il2CppAssets.Scripts.Unity.UI_New.InGame.InGame](https://docs.microsoft.com/en-us/dotnet/api/Il2CppAssets.Scripts.Unity.UI_New.InGame.InGame 'Il2CppAssets.Scripts.Unity.UI_New.InGame.InGame')

#### Returns
[System.Collections.Generic.Dictionary&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.Dictionary-2 'System.Collections.Generic.Dictionary`2')[System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')[,](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.Dictionary-2 'System.Collections.Generic.Dictionary`2')[System.Int32](https://docs.microsoft.com/en-us/dotnet/api/System.Int32 'System.Int32')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.Dictionary-2 'System.Collections.Generic.Dictionary`2')

<a name='BTD_Mod_Helper.Extensions.InGameExt.GetProjectiles(thisInGame)'></a>

## InGameExt.GetProjectiles(this InGame) Method

Get's all existing Projectiles on the map

```csharp
public static System.Collections.Generic.List<Projectile> GetProjectiles(this InGame inGame);
```
#### Parameters

<a name='BTD_Mod_Helper.Extensions.InGameExt.GetProjectiles(thisInGame).inGame'></a>

`inGame` [Il2CppAssets.Scripts.Unity.UI_New.InGame.InGame](https://docs.microsoft.com/en-us/dotnet/api/Il2CppAssets.Scripts.Unity.UI_New.InGame.InGame 'Il2CppAssets.Scripts.Unity.UI_New.InGame.InGame')

#### Returns
[System.Collections.Generic.List&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.List-1 'System.Collections.Generic.List`1')[Il2CppAssets.Scripts.Simulation.Towers.Projectiles.Projectile](https://docs.microsoft.com/en-us/dotnet/api/Il2CppAssets.Scripts.Simulation.Towers.Projectiles.Projectile 'Il2CppAssets.Scripts.Simulation.Towers.Projectiles.Projectile')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.List-1 'System.Collections.Generic.List`1')

<a name='BTD_Mod_Helper.Extensions.InGameExt.GetSimulation(thisInGame)'></a>

## InGameExt.GetSimulation(this InGame) Method

Get the current Simulation for this InGame session

```csharp
public static Simulation GetSimulation(this InGame inGame);
```
#### Parameters

<a name='BTD_Mod_Helper.Extensions.InGameExt.GetSimulation(thisInGame).inGame'></a>

`inGame` [Il2CppAssets.Scripts.Unity.UI_New.InGame.InGame](https://docs.microsoft.com/en-us/dotnet/api/Il2CppAssets.Scripts.Unity.UI_New.InGame.InGame 'Il2CppAssets.Scripts.Unity.UI_New.InGame.InGame')

#### Returns
[Il2CppAssets.Scripts.Simulation.Simulation](https://docs.microsoft.com/en-us/dotnet/api/Il2CppAssets.Scripts.Simulation.Simulation 'Il2CppAssets.Scripts.Simulation.Simulation')

<a name='BTD_Mod_Helper.Extensions.InGameExt.GetTowerInventory(thisInGame)'></a>

## InGameExt.GetTowerInventory(this InGame) Method

Get the current instance of TowerInventory being used in this game session

```csharp
public static TowerInventory GetTowerInventory(this InGame inGame);
```
#### Parameters

<a name='BTD_Mod_Helper.Extensions.InGameExt.GetTowerInventory(thisInGame).inGame'></a>

`inGame` [Il2CppAssets.Scripts.Unity.UI_New.InGame.InGame](https://docs.microsoft.com/en-us/dotnet/api/Il2CppAssets.Scripts.Unity.UI_New.InGame.InGame 'Il2CppAssets.Scripts.Unity.UI_New.InGame.InGame')

#### Returns
[Il2CppAssets.Scripts.Simulation.Input.TowerInventory](https://docs.microsoft.com/en-us/dotnet/api/Il2CppAssets.Scripts.Simulation.Input.TowerInventory 'Il2CppAssets.Scripts.Simulation.Input.TowerInventory')

<a name='BTD_Mod_Helper.Extensions.InGameExt.GetTowerManager(thisInGame)'></a>

## InGameExt.GetTowerManager(this InGame) Method

Get the current TowerManager for this game session

```csharp
public static TowerManager GetTowerManager(this InGame inGame);
```
#### Parameters

<a name='BTD_Mod_Helper.Extensions.InGameExt.GetTowerManager(thisInGame).inGame'></a>

`inGame` [Il2CppAssets.Scripts.Unity.UI_New.InGame.InGame](https://docs.microsoft.com/en-us/dotnet/api/Il2CppAssets.Scripts.Unity.UI_New.InGame.InGame 'Il2CppAssets.Scripts.Unity.UI_New.InGame.InGame')

#### Returns
[Il2CppAssets.Scripts.Simulation.Towers.TowerManager](https://docs.microsoft.com/en-us/dotnet/api/Il2CppAssets.Scripts.Simulation.Towers.TowerManager 'Il2CppAssets.Scripts.Simulation.Towers.TowerManager')

<a name='BTD_Mod_Helper.Extensions.InGameExt.GetTowers(thisInGame,string)'></a>

## InGameExt.GetTowers(this InGame, string) Method

Get every Tower that has been created through the Tower Factory

```csharp
public static System.Collections.Generic.List<Tower> GetTowers(this InGame inGame, string name=null);
```
#### Parameters

<a name='BTD_Mod_Helper.Extensions.InGameExt.GetTowers(thisInGame,string).inGame'></a>

`inGame` [Il2CppAssets.Scripts.Unity.UI_New.InGame.InGame](https://docs.microsoft.com/en-us/dotnet/api/Il2CppAssets.Scripts.Unity.UI_New.InGame.InGame 'Il2CppAssets.Scripts.Unity.UI_New.InGame.InGame')

<a name='BTD_Mod_Helper.Extensions.InGameExt.GetTowers(thisInGame,string).name'></a>

`name` [System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')

Optionally only get Towers whose TowerModel name is this parameter

#### Returns
[System.Collections.Generic.List&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.List-1 'System.Collections.Generic.List`1')[Il2CppAssets.Scripts.Simulation.Towers.Tower](https://docs.microsoft.com/en-us/dotnet/api/Il2CppAssets.Scripts.Simulation.Towers.Tower 'Il2CppAssets.Scripts.Simulation.Towers.Tower')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.List-1 'System.Collections.Generic.List`1')

<a name='BTD_Mod_Helper.Extensions.InGameExt.GetUnityToSimulation(thisInGame)'></a>

## InGameExt.GetUnityToSimulation(this InGame) Method

Get's the UnityToSimulation for this game

```csharp
public static UnityToSimulation GetUnityToSimulation(this InGame inGame);
```
#### Parameters

<a name='BTD_Mod_Helper.Extensions.InGameExt.GetUnityToSimulation(thisInGame).inGame'></a>

`inGame` [Il2CppAssets.Scripts.Unity.UI_New.InGame.InGame](https://docs.microsoft.com/en-us/dotnet/api/Il2CppAssets.Scripts.Unity.UI_New.InGame.InGame 'Il2CppAssets.Scripts.Unity.UI_New.InGame.InGame')

#### Returns
[Il2CppAssets.Scripts.Unity.Bridge.UnityToSimulation](https://docs.microsoft.com/en-us/dotnet/api/Il2CppAssets.Scripts.Unity.Bridge.UnityToSimulation 'Il2CppAssets.Scripts.Unity.Bridge.UnityToSimulation')

<a name='BTD_Mod_Helper.Extensions.InGameExt.IsCoOpReady(thisInGame)'></a>

## InGameExt.IsCoOpReady(this InGame) Method

Returns true if the initial co-op handshake has finished and user has co-op game details.

```csharp
public static bool IsCoOpReady(this InGame inGame);
```
#### Parameters

<a name='BTD_Mod_Helper.Extensions.InGameExt.IsCoOpReady(thisInGame).inGame'></a>

`inGame` [Il2CppAssets.Scripts.Unity.UI_New.InGame.InGame](https://docs.microsoft.com/en-us/dotnet/api/Il2CppAssets.Scripts.Unity.UI_New.InGame.InGame 'Il2CppAssets.Scripts.Unity.UI_New.InGame.InGame')

The game.

#### Returns
[System.Boolean](https://docs.microsoft.com/en-us/dotnet/api/System.Boolean 'System.Boolean')

<a name='BTD_Mod_Helper.Extensions.InGameExt.IsInGame(thisInGame)'></a>

## InGameExt.IsInGame(this InGame) Method

Returns whether or not the player is currently in a game.

```csharp
public static bool IsInGame(this InGame inGame);
```
#### Parameters

<a name='BTD_Mod_Helper.Extensions.InGameExt.IsInGame(thisInGame).inGame'></a>

`inGame` [Il2CppAssets.Scripts.Unity.UI_New.InGame.InGame](https://docs.microsoft.com/en-us/dotnet/api/Il2CppAssets.Scripts.Unity.UI_New.InGame.InGame 'Il2CppAssets.Scripts.Unity.UI_New.InGame.InGame')

#### Returns
[System.Boolean](https://docs.microsoft.com/en-us/dotnet/api/System.Boolean 'System.Boolean')

<a name='BTD_Mod_Helper.Extensions.InGameExt.SellTower(thisInGame,Tower)'></a>

## InGameExt.SellTower(this InGame, Tower) Method

Sells a tower

```csharp
public static void SellTower(this InGame inGame, Tower tower);
```
#### Parameters

<a name='BTD_Mod_Helper.Extensions.InGameExt.SellTower(thisInGame,Tower).inGame'></a>

`inGame` [Il2CppAssets.Scripts.Unity.UI_New.InGame.InGame](https://docs.microsoft.com/en-us/dotnet/api/Il2CppAssets.Scripts.Unity.UI_New.InGame.InGame 'Il2CppAssets.Scripts.Unity.UI_New.InGame.InGame')

<a name='BTD_Mod_Helper.Extensions.InGameExt.SellTower(thisInGame,Tower).tower'></a>

`tower` [Il2CppAssets.Scripts.Simulation.Towers.Tower](https://docs.microsoft.com/en-us/dotnet/api/Il2CppAssets.Scripts.Simulation.Towers.Tower 'Il2CppAssets.Scripts.Simulation.Towers.Tower')

<a name='BTD_Mod_Helper.Extensions.InGameExt.SellTowers(thisInGame,System.Collections.Generic.List_Tower_)'></a>

## InGameExt.SellTowers(this InGame, List<Tower>) Method

Sells multiple towers

```csharp
public static void SellTowers(this InGame inGame, System.Collections.Generic.List<Tower> towers);
```
#### Parameters

<a name='BTD_Mod_Helper.Extensions.InGameExt.SellTowers(thisInGame,System.Collections.Generic.List_Tower_).inGame'></a>

`inGame` [Il2CppAssets.Scripts.Unity.UI_New.InGame.InGame](https://docs.microsoft.com/en-us/dotnet/api/Il2CppAssets.Scripts.Unity.UI_New.InGame.InGame 'Il2CppAssets.Scripts.Unity.UI_New.InGame.InGame')

<a name='BTD_Mod_Helper.Extensions.InGameExt.SellTowers(thisInGame,System.Collections.Generic.List_Tower_).towers'></a>

`towers` [System.Collections.Generic.List&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.List-1 'System.Collections.Generic.List`1')[Il2CppAssets.Scripts.Simulation.Towers.Tower](https://docs.microsoft.com/en-us/dotnet/api/Il2CppAssets.Scripts.Simulation.Towers.Tower 'Il2CppAssets.Scripts.Simulation.Towers.Tower')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.List-1 'System.Collections.Generic.List`1')

<a name='BTD_Mod_Helper.Extensions.InGameExt.SetCash(thisInGame,double)'></a>

## InGameExt.SetCash(this InGame, double) Method

Set the Player's cash to a specific amount

```csharp
public static void SetCash(this InGame inGame, double amount);
```
#### Parameters

<a name='BTD_Mod_Helper.Extensions.InGameExt.SetCash(thisInGame,double).inGame'></a>

`inGame` [Il2CppAssets.Scripts.Unity.UI_New.InGame.InGame](https://docs.microsoft.com/en-us/dotnet/api/Il2CppAssets.Scripts.Unity.UI_New.InGame.InGame 'Il2CppAssets.Scripts.Unity.UI_New.InGame.InGame')

InGame instance

<a name='BTD_Mod_Helper.Extensions.InGameExt.SetCash(thisInGame,double).amount'></a>

`amount` [System.Double](https://docs.microsoft.com/en-us/dotnet/api/System.Double 'System.Double')

Value to set cash to

<a name='BTD_Mod_Helper.Extensions.InGameExt.SetHealth(thisInGame,double)'></a>

## InGameExt.SetHealth(this InGame, double) Method

Set player's health to specific amount

```csharp
public static void SetHealth(this InGame inGame, double amount);
```
#### Parameters

<a name='BTD_Mod_Helper.Extensions.InGameExt.SetHealth(thisInGame,double).inGame'></a>

`inGame` [Il2CppAssets.Scripts.Unity.UI_New.InGame.InGame](https://docs.microsoft.com/en-us/dotnet/api/Il2CppAssets.Scripts.Unity.UI_New.InGame.InGame 'Il2CppAssets.Scripts.Unity.UI_New.InGame.InGame')

InGame instance

<a name='BTD_Mod_Helper.Extensions.InGameExt.SetHealth(thisInGame,double).amount'></a>

`amount` [System.Double](https://docs.microsoft.com/en-us/dotnet/api/System.Double 'System.Double')

Value to set health to

<a name='BTD_Mod_Helper.Extensions.InGameExt.SetMaxHealth(thisInGame,double)'></a>

## InGameExt.SetMaxHealth(this InGame, double) Method

Set the player's maximum health to a new value

```csharp
public static void SetMaxHealth(this InGame inGame, double amount);
```
#### Parameters

<a name='BTD_Mod_Helper.Extensions.InGameExt.SetMaxHealth(thisInGame,double).inGame'></a>

`inGame` [Il2CppAssets.Scripts.Unity.UI_New.InGame.InGame](https://docs.microsoft.com/en-us/dotnet/api/Il2CppAssets.Scripts.Unity.UI_New.InGame.InGame 'Il2CppAssets.Scripts.Unity.UI_New.InGame.InGame')

InGame instance

<a name='BTD_Mod_Helper.Extensions.InGameExt.SetMaxHealth(thisInGame,double).amount'></a>

`amount` [System.Double](https://docs.microsoft.com/en-us/dotnet/api/System.Double 'System.Double')

Value to set max health to

<a name='BTD_Mod_Helper.Extensions.InGameExt.SetRound(thisInGame,int)'></a>

## InGameExt.SetRound(this InGame, int) Method

Set the current round

```csharp
public static void SetRound(this InGame inGame, int round);
```
#### Parameters

<a name='BTD_Mod_Helper.Extensions.InGameExt.SetRound(thisInGame,int).inGame'></a>

`inGame` [Il2CppAssets.Scripts.Unity.UI_New.InGame.InGame](https://docs.microsoft.com/en-us/dotnet/api/Il2CppAssets.Scripts.Unity.UI_New.InGame.InGame 'Il2CppAssets.Scripts.Unity.UI_New.InGame.InGame')

<a name='BTD_Mod_Helper.Extensions.InGameExt.SetRound(thisInGame,int).round'></a>

`round` [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/System.Int32 'System.Int32')

<a name='BTD_Mod_Helper.Extensions.InGameExt.SetRoundSet(thisInGame,RoundSetModel)'></a>

## InGameExt.SetRoundSet(this InGame, RoundSetModel) Method

Custom API method that changes the game's round set to a custom RoundSetModel.

```csharp
public static void SetRoundSet(this InGame inGame, RoundSetModel roundSet);
```
#### Parameters

<a name='BTD_Mod_Helper.Extensions.InGameExt.SetRoundSet(thisInGame,RoundSetModel).inGame'></a>

`inGame` [Il2CppAssets.Scripts.Unity.UI_New.InGame.InGame](https://docs.microsoft.com/en-us/dotnet/api/Il2CppAssets.Scripts.Unity.UI_New.InGame.InGame 'Il2CppAssets.Scripts.Unity.UI_New.InGame.InGame')

<a name='BTD_Mod_Helper.Extensions.InGameExt.SetRoundSet(thisInGame,RoundSetModel).roundSet'></a>

`roundSet` [Il2CppAssets.Scripts.Models.Rounds.RoundSetModel](https://docs.microsoft.com/en-us/dotnet/api/Il2CppAssets.Scripts.Models.Rounds.RoundSetModel 'Il2CppAssets.Scripts.Models.Rounds.RoundSetModel')

New Round Set Model to use

<a name='BTD_Mod_Helper.Extensions.InGameExt.SpawnBloons(thisInGame,Il2CppReferenceArray_BloonEmissionModel_)'></a>

## InGameExt.SpawnBloons(this InGame, Il2CppReferenceArray<BloonEmissionModel>) Method

Spawn bloons in game

```csharp
public static void SpawnBloons(this InGame inGame, Il2CppReferenceArray<BloonEmissionModel> bloonEmissionModels);
```
#### Parameters

<a name='BTD_Mod_Helper.Extensions.InGameExt.SpawnBloons(thisInGame,Il2CppReferenceArray_BloonEmissionModel_).inGame'></a>

`inGame` [Il2CppAssets.Scripts.Unity.UI_New.InGame.InGame](https://docs.microsoft.com/en-us/dotnet/api/Il2CppAssets.Scripts.Unity.UI_New.InGame.InGame 'Il2CppAssets.Scripts.Unity.UI_New.InGame.InGame')

<a name='BTD_Mod_Helper.Extensions.InGameExt.SpawnBloons(thisInGame,Il2CppReferenceArray_BloonEmissionModel_).bloonEmissionModels'></a>

`bloonEmissionModels` [Il2CppInterop.Runtime.InteropTypes.Arrays.Il2CppReferenceArray](https://docs.microsoft.com/en-us/dotnet/api/Il2CppInterop.Runtime.InteropTypes.Arrays.Il2CppReferenceArray 'Il2CppInterop.Runtime.InteropTypes.Arrays.Il2CppReferenceArray')

<a name='BTD_Mod_Helper.Extensions.InGameExt.SpawnBloons(thisInGame,int)'></a>

## InGameExt.SpawnBloons(this InGame, int) Method

Spawn bloons in game

```csharp
public static void SpawnBloons(this InGame inGame, int round);
```
#### Parameters

<a name='BTD_Mod_Helper.Extensions.InGameExt.SpawnBloons(thisInGame,int).inGame'></a>

`inGame` [Il2CppAssets.Scripts.Unity.UI_New.InGame.InGame](https://docs.microsoft.com/en-us/dotnet/api/Il2CppAssets.Scripts.Unity.UI_New.InGame.InGame 'Il2CppAssets.Scripts.Unity.UI_New.InGame.InGame')

<a name='BTD_Mod_Helper.Extensions.InGameExt.SpawnBloons(thisInGame,int).round'></a>

`round` [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/System.Int32 'System.Int32')

<a name='BTD_Mod_Helper.Extensions.InGameExt.SpawnBloons(thisInGame,List_BloonEmissionModel_)'></a>

## InGameExt.SpawnBloons(this InGame, List<BloonEmissionModel>) Method

Spawn bloons in game

```csharp
public static void SpawnBloons(this InGame inGame, List<BloonEmissionModel> bloonEmissionModels);
```
#### Parameters

<a name='BTD_Mod_Helper.Extensions.InGameExt.SpawnBloons(thisInGame,List_BloonEmissionModel_).inGame'></a>

`inGame` [Il2CppAssets.Scripts.Unity.UI_New.InGame.InGame](https://docs.microsoft.com/en-us/dotnet/api/Il2CppAssets.Scripts.Unity.UI_New.InGame.InGame 'Il2CppAssets.Scripts.Unity.UI_New.InGame.InGame')

<a name='BTD_Mod_Helper.Extensions.InGameExt.SpawnBloons(thisInGame,List_BloonEmissionModel_).bloonEmissionModels'></a>

`bloonEmissionModels` [Il2CppSystem.Collections.Generic.List](https://docs.microsoft.com/en-us/dotnet/api/Il2CppSystem.Collections.Generic.List 'Il2CppSystem.Collections.Generic.List')

<a name='BTD_Mod_Helper.Extensions.InGameExt.SpawnBloons(thisInGame,string,int,float)'></a>

## InGameExt.SpawnBloons(this InGame, string, int, float) Method

Spawn bloons in game

```csharp
public static void SpawnBloons(this InGame inGame, string bloonName, int number, float spacing);
```
#### Parameters

<a name='BTD_Mod_Helper.Extensions.InGameExt.SpawnBloons(thisInGame,string,int,float).inGame'></a>

`inGame` [Il2CppAssets.Scripts.Unity.UI_New.InGame.InGame](https://docs.microsoft.com/en-us/dotnet/api/Il2CppAssets.Scripts.Unity.UI_New.InGame.InGame 'Il2CppAssets.Scripts.Unity.UI_New.InGame.InGame')

<a name='BTD_Mod_Helper.Extensions.InGameExt.SpawnBloons(thisInGame,string,int,float).bloonName'></a>

`bloonName` [System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')

<a name='BTD_Mod_Helper.Extensions.InGameExt.SpawnBloons(thisInGame,string,int,float).number'></a>

`number` [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/System.Int32 'System.Int32')

<a name='BTD_Mod_Helper.Extensions.InGameExt.SpawnBloons(thisInGame,string,int,float).spacing'></a>

`spacing` [System.Single](https://docs.microsoft.com/en-us/dotnet/api/System.Single 'System.Single')

<a name='BTD_Mod_Helper.Extensions.InGameExt.SpawnBloons(thisInGame,System.Collections.Generic.List_BloonEmissionModel_)'></a>

## InGameExt.SpawnBloons(this InGame, List<BloonEmissionModel>) Method

Spawn bloons in game

```csharp
public static void SpawnBloons(this InGame inGame, System.Collections.Generic.List<BloonEmissionModel> bloonEmissionModels);
```
#### Parameters

<a name='BTD_Mod_Helper.Extensions.InGameExt.SpawnBloons(thisInGame,System.Collections.Generic.List_BloonEmissionModel_).inGame'></a>

`inGame` [Il2CppAssets.Scripts.Unity.UI_New.InGame.InGame](https://docs.microsoft.com/en-us/dotnet/api/Il2CppAssets.Scripts.Unity.UI_New.InGame.InGame 'Il2CppAssets.Scripts.Unity.UI_New.InGame.InGame')

<a name='BTD_Mod_Helper.Extensions.InGameExt.SpawnBloons(thisInGame,System.Collections.Generic.List_BloonEmissionModel_).bloonEmissionModels'></a>

`bloonEmissionModels` [System.Collections.Generic.List&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.List-1 'System.Collections.Generic.List`1')[Il2CppAssets.Scripts.Models.Rounds.BloonEmissionModel](https://docs.microsoft.com/en-us/dotnet/api/Il2CppAssets.Scripts.Models.Rounds.BloonEmissionModel 'Il2CppAssets.Scripts.Models.Rounds.BloonEmissionModel')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.List-1 'System.Collections.Generic.List`1')