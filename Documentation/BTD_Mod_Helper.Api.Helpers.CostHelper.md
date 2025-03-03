#### [BloonsTD6 Mod Helper](README.md 'README')
### [BTD_Mod_Helper.Api.Helpers](README.md#BTD_Mod_Helper.Api.Helpers 'BTD_Mod_Helper.Api.Helpers')

## CostHelper Class

Helper for scaling costs to difficulties

```csharp
public static class CostHelper
```

Inheritance [System.Object](https://docs.microsoft.com/en-us/dotnet/api/System.Object 'System.Object') &#129106; CostHelper
### Methods

<a name='BTD_Mod_Helper.Api.Helpers.CostHelper.CostForDifficulty(int,float)'></a>

## CostHelper.CostForDifficulty(int, float) Method

Applies a multiplier to a cost and rounds it

```csharp
public static int CostForDifficulty(int cost, float multiplier);
```
#### Parameters

<a name='BTD_Mod_Helper.Api.Helpers.CostHelper.CostForDifficulty(int,float).cost'></a>

`cost` [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/System.Int32 'System.Int32')

<a name='BTD_Mod_Helper.Api.Helpers.CostHelper.CostForDifficulty(int,float).multiplier'></a>

`multiplier` [System.Single](https://docs.microsoft.com/en-us/dotnet/api/System.Single 'System.Single')

#### Returns
[System.Int32](https://docs.microsoft.com/en-us/dotnet/api/System.Int32 'System.Int32')

<a name='BTD_Mod_Helper.Api.Helpers.CostHelper.CostForDifficulty(int,GameModel)'></a>

## CostHelper.CostForDifficulty(int, GameModel) Method

Gets a modified cost for a given GameModel's difficulty

```csharp
public static int CostForDifficulty(int cost, GameModel gameModel);
```
#### Parameters

<a name='BTD_Mod_Helper.Api.Helpers.CostHelper.CostForDifficulty(int,GameModel).cost'></a>

`cost` [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/System.Int32 'System.Int32')

The default cost

<a name='BTD_Mod_Helper.Api.Helpers.CostHelper.CostForDifficulty(int,GameModel).gameModel'></a>

`gameModel` [Il2CppAssets.Scripts.Models.GameModel](https://docs.microsoft.com/en-us/dotnet/api/Il2CppAssets.Scripts.Models.GameModel 'Il2CppAssets.Scripts.Models.GameModel')

The current GameModel

#### Returns
[System.Int32](https://docs.microsoft.com/en-us/dotnet/api/System.Int32 'System.Int32')  
The modified cost

<a name='BTD_Mod_Helper.Api.Helpers.CostHelper.CostForDifficulty(int,InGame)'></a>

## CostHelper.CostForDifficulty(int, InGame) Method

Gets a modified cost for a given instance of InGame

```csharp
public static int CostForDifficulty(int cost, InGame inGame);
```
#### Parameters

<a name='BTD_Mod_Helper.Api.Helpers.CostHelper.CostForDifficulty(int,InGame).cost'></a>

`cost` [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/System.Int32 'System.Int32')

The default cost

<a name='BTD_Mod_Helper.Api.Helpers.CostHelper.CostForDifficulty(int,InGame).inGame'></a>

`inGame` [Il2CppAssets.Scripts.Unity.UI_New.InGame.InGame](https://docs.microsoft.com/en-us/dotnet/api/Il2CppAssets.Scripts.Unity.UI_New.InGame.InGame 'Il2CppAssets.Scripts.Unity.UI_New.InGame.InGame')

Current instance of InGame

#### Returns
[System.Int32](https://docs.microsoft.com/en-us/dotnet/api/System.Int32 'System.Int32')  
The modified cost

<a name='BTD_Mod_Helper.Api.Helpers.CostHelper.CostForDifficulty(int,List_ModModel_)'></a>

## CostHelper.CostForDifficulty(int, List<ModModel>) Method

Gets a modified cost for a given set of ModModels that are used to setup a match  
Somewhere deep within those mods is likely to be a Cost modifier, and this will find and apply that

```csharp
public static int CostForDifficulty(int cost, List<ModModel> mods);
```
#### Parameters

<a name='BTD_Mod_Helper.Api.Helpers.CostHelper.CostForDifficulty(int,List_ModModel_).cost'></a>

`cost` [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/System.Int32 'System.Int32')

The default cost

<a name='BTD_Mod_Helper.Api.Helpers.CostHelper.CostForDifficulty(int,List_ModModel_).mods'></a>

`mods` [Il2CppSystem.Collections.Generic.List](https://docs.microsoft.com/en-us/dotnet/api/Il2CppSystem.Collections.Generic.List 'Il2CppSystem.Collections.Generic.List')

The mods that the match is using

#### Returns
[System.Int32](https://docs.microsoft.com/en-us/dotnet/api/System.Int32 'System.Int32')  
The modified cost

<a name='BTD_Mod_Helper.Api.Helpers.CostHelper.CostForDifficulty(int,string)'></a>

## CostHelper.CostForDifficulty(int, string) Method

Scales a base (medium) cost to the given difficulty

```csharp
public static int CostForDifficulty(int cost, string difficulty);
```
#### Parameters

<a name='BTD_Mod_Helper.Api.Helpers.CostHelper.CostForDifficulty(int,string).cost'></a>

`cost` [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/System.Int32 'System.Int32')

<a name='BTD_Mod_Helper.Api.Helpers.CostHelper.CostForDifficulty(int,string).difficulty'></a>

`difficulty` [System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')

#### Returns
[System.Int32](https://docs.microsoft.com/en-us/dotnet/api/System.Int32 'System.Int32')