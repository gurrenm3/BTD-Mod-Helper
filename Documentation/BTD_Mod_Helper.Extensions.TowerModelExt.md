#### [BloonsTD6 Mod Helper](README.md 'README')
### [BTD_Mod_Helper.Extensions](README.md#BTD_Mod_Helper.Extensions 'BTD_Mod_Helper.Extensions')

## TowerModelExt Class

Extensions for TowerModels

```csharp
public static class TowerModelExt
```

Inheritance [System.Object](https://docs.microsoft.com/en-us/dotnet/api/System.Object 'System.Object') &#129106; TowerModelExt
### Methods

<a name='BTD_Mod_Helper.Extensions.TowerModelExt.AddTiersToName(thisAssets.Scripts.Models.Towers.TowerModel)'></a>

## TowerModelExt.AddTiersToName(this TowerModel) Method

Format's the tower's name with its tiers

```csharp
public static void AddTiersToName(this Assets.Scripts.Models.Towers.TowerModel towerModel);
```
#### Parameters

<a name='BTD_Mod_Helper.Extensions.TowerModelExt.AddTiersToName(thisAssets.Scripts.Models.Towers.TowerModel).towerModel'></a>

`towerModel` [Assets.Scripts.Models.Towers.TowerModel](https://docs.microsoft.com/en-us/dotnet/api/Assets.Scripts.Models.Towers.TowerModel 'Assets.Scripts.Models.Towers.TowerModel')

<a name='BTD_Mod_Helper.Extensions.TowerModelExt.AddTiersToName(thisAssets.Scripts.Models.Towers.TowerModel,int,int,int)'></a>

## TowerModelExt.AddTiersToName(this TowerModel, int, int, int) Method

Format's the tower's name with its tiers

```csharp
public static void AddTiersToName(this Assets.Scripts.Models.Towers.TowerModel towerModel, int tier1, int tier2, int tier3);
```
#### Parameters

<a name='BTD_Mod_Helper.Extensions.TowerModelExt.AddTiersToName(thisAssets.Scripts.Models.Towers.TowerModel,int,int,int).towerModel'></a>

`towerModel` [Assets.Scripts.Models.Towers.TowerModel](https://docs.microsoft.com/en-us/dotnet/api/Assets.Scripts.Models.Towers.TowerModel 'Assets.Scripts.Models.Towers.TowerModel')

<a name='BTD_Mod_Helper.Extensions.TowerModelExt.AddTiersToName(thisAssets.Scripts.Models.Towers.TowerModel,int,int,int).tier1'></a>

`tier1` [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/System.Int32 'System.Int32')

<a name='BTD_Mod_Helper.Extensions.TowerModelExt.AddTiersToName(thisAssets.Scripts.Models.Towers.TowerModel,int,int,int).tier2'></a>

`tier2` [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/System.Int32 'System.Int32')

<a name='BTD_Mod_Helper.Extensions.TowerModelExt.AddTiersToName(thisAssets.Scripts.Models.Towers.TowerModel,int,int,int).tier3'></a>

`tier3` [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/System.Int32 'System.Int32')

<a name='BTD_Mod_Helper.Extensions.TowerModelExt.ApplyDisplay_T_(thisAssets.Scripts.Models.Towers.TowerModel)'></a>

## TowerModelExt.ApplyDisplay<T>(this TowerModel) Method

Applies a given ModDisplay to this TowerModel

```csharp
public static void ApplyDisplay<T>(this Assets.Scripts.Models.Towers.TowerModel towerModel)
    where T : BTD_Mod_Helper.Api.Display.ModDisplay;
```
#### Type parameters

<a name='BTD_Mod_Helper.Extensions.TowerModelExt.ApplyDisplay_T_(thisAssets.Scripts.Models.Towers.TowerModel).T'></a>

`T`

The type of ModDisplay
#### Parameters

<a name='BTD_Mod_Helper.Extensions.TowerModelExt.ApplyDisplay_T_(thisAssets.Scripts.Models.Towers.TowerModel).towerModel'></a>

`towerModel` [Assets.Scripts.Models.Towers.TowerModel](https://docs.microsoft.com/en-us/dotnet/api/Assets.Scripts.Models.Towers.TowerModel 'Assets.Scripts.Models.Towers.TowerModel')

<a name='BTD_Mod_Helper.Extensions.TowerModelExt.GetAbilities(thisAssets.Scripts.Models.Towers.TowerModel)'></a>

## TowerModelExt.GetAbilities(this TowerModel) Method

Return all AbilityModel behaviors from this tower, if it has any

```csharp
public static System.Collections.Generic.List<Assets.Scripts.Models.Towers.Behaviors.Abilities.AbilityModel> GetAbilities(this Assets.Scripts.Models.Towers.TowerModel towerModel);
```
#### Parameters

<a name='BTD_Mod_Helper.Extensions.TowerModelExt.GetAbilities(thisAssets.Scripts.Models.Towers.TowerModel).towerModel'></a>

`towerModel` [Assets.Scripts.Models.Towers.TowerModel](https://docs.microsoft.com/en-us/dotnet/api/Assets.Scripts.Models.Towers.TowerModel 'Assets.Scripts.Models.Towers.TowerModel')

#### Returns
[System.Collections.Generic.List&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.List-1 'System.Collections.Generic.List`1')[Assets.Scripts.Models.Towers.Behaviors.Abilities.AbilityModel](https://docs.microsoft.com/en-us/dotnet/api/Assets.Scripts.Models.Towers.Behaviors.Abilities.AbilityModel 'Assets.Scripts.Models.Towers.Behaviors.Abilities.AbilityModel')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.List-1 'System.Collections.Generic.List`1')

<a name='BTD_Mod_Helper.Extensions.TowerModelExt.GetAbility(thisAssets.Scripts.Models.Towers.TowerModel)'></a>

## TowerModelExt.GetAbility(this TowerModel) Method

Return the first ability on the tower

```csharp
public static Assets.Scripts.Models.Towers.Behaviors.Abilities.AbilityModel GetAbility(this Assets.Scripts.Models.Towers.TowerModel towerModel);
```
#### Parameters

<a name='BTD_Mod_Helper.Extensions.TowerModelExt.GetAbility(thisAssets.Scripts.Models.Towers.TowerModel).towerModel'></a>

`towerModel` [Assets.Scripts.Models.Towers.TowerModel](https://docs.microsoft.com/en-us/dotnet/api/Assets.Scripts.Models.Towers.TowerModel 'Assets.Scripts.Models.Towers.TowerModel')

#### Returns
[Assets.Scripts.Models.Towers.Behaviors.Abilities.AbilityModel](https://docs.microsoft.com/en-us/dotnet/api/Assets.Scripts.Models.Towers.Behaviors.Abilities.AbilityModel 'Assets.Scripts.Models.Towers.Behaviors.Abilities.AbilityModel')

<a name='BTD_Mod_Helper.Extensions.TowerModelExt.GetAbility(thisAssets.Scripts.Models.Towers.TowerModel,int)'></a>

## TowerModelExt.GetAbility(this TowerModel, int) Method

Return a specific Ability of the tower.

```csharp
public static Assets.Scripts.Models.Towers.Behaviors.Abilities.AbilityModel GetAbility(this Assets.Scripts.Models.Towers.TowerModel towerModel, int index);
```
#### Parameters

<a name='BTD_Mod_Helper.Extensions.TowerModelExt.GetAbility(thisAssets.Scripts.Models.Towers.TowerModel,int).towerModel'></a>

`towerModel` [Assets.Scripts.Models.Towers.TowerModel](https://docs.microsoft.com/en-us/dotnet/api/Assets.Scripts.Models.Towers.TowerModel 'Assets.Scripts.Models.Towers.TowerModel')

the TowerModel

<a name='BTD_Mod_Helper.Extensions.TowerModelExt.GetAbility(thisAssets.Scripts.Models.Towers.TowerModel,int).index'></a>

`index` [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/System.Int32 'System.Int32')

Index of the ability you want.

#### Returns
[Assets.Scripts.Models.Towers.Behaviors.Abilities.AbilityModel](https://docs.microsoft.com/en-us/dotnet/api/Assets.Scripts.Models.Towers.Behaviors.Abilities.AbilityModel 'Assets.Scripts.Models.Towers.Behaviors.Abilities.AbilityModel')

<a name='BTD_Mod_Helper.Extensions.TowerModelExt.GetAllTowerToSim(thisAssets.Scripts.Models.Towers.TowerModel)'></a>

## TowerModelExt.GetAllTowerToSim(this TowerModel) Method

Return all TowerToSimulations with this TowerModel

```csharp
public static System.Collections.Generic.List<Assets.Scripts.Unity.Bridge.TowerToSimulation> GetAllTowerToSim(this Assets.Scripts.Models.Towers.TowerModel towerModel);
```
#### Parameters

<a name='BTD_Mod_Helper.Extensions.TowerModelExt.GetAllTowerToSim(thisAssets.Scripts.Models.Towers.TowerModel).towerModel'></a>

`towerModel` [Assets.Scripts.Models.Towers.TowerModel](https://docs.microsoft.com/en-us/dotnet/api/Assets.Scripts.Models.Towers.TowerModel 'Assets.Scripts.Models.Towers.TowerModel')

#### Returns
[System.Collections.Generic.List&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.List-1 'System.Collections.Generic.List`1')[Assets.Scripts.Unity.Bridge.TowerToSimulation](https://docs.microsoft.com/en-us/dotnet/api/Assets.Scripts.Unity.Bridge.TowerToSimulation 'Assets.Scripts.Unity.Bridge.TowerToSimulation')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.List-1 'System.Collections.Generic.List`1')

<a name='BTD_Mod_Helper.Extensions.TowerModelExt.GetAppliedUpgrades(thisAssets.Scripts.Models.Towers.TowerModel)'></a>

## TowerModelExt.GetAppliedUpgrades(this TowerModel) Method

Return all UpgradeModels that are currently applied to this TowerModel

```csharp
public static System.Collections.Generic.List<Assets.Scripts.Models.Towers.Upgrades.UpgradeModel> GetAppliedUpgrades(this Assets.Scripts.Models.Towers.TowerModel towerModel);
```
#### Parameters

<a name='BTD_Mod_Helper.Extensions.TowerModelExt.GetAppliedUpgrades(thisAssets.Scripts.Models.Towers.TowerModel).towerModel'></a>

`towerModel` [Assets.Scripts.Models.Towers.TowerModel](https://docs.microsoft.com/en-us/dotnet/api/Assets.Scripts.Models.Towers.TowerModel 'Assets.Scripts.Models.Towers.TowerModel')

#### Returns
[System.Collections.Generic.List&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.List-1 'System.Collections.Generic.List`1')[Assets.Scripts.Models.Towers.Upgrades.UpgradeModel](https://docs.microsoft.com/en-us/dotnet/api/Assets.Scripts.Models.Towers.Upgrades.UpgradeModel 'Assets.Scripts.Models.Towers.Upgrades.UpgradeModel')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.List-1 'System.Collections.Generic.List`1')

<a name='BTD_Mod_Helper.Extensions.TowerModelExt.GetAttackModel(thisAssets.Scripts.Models.Towers.TowerModel)'></a>

## TowerModelExt.GetAttackModel(this TowerModel) Method

Return the first AttackModel from this TowerModel, if it has one

```csharp
public static Assets.Scripts.Models.Towers.Behaviors.Attack.AttackModel GetAttackModel(this Assets.Scripts.Models.Towers.TowerModel towerModel);
```
#### Parameters

<a name='BTD_Mod_Helper.Extensions.TowerModelExt.GetAttackModel(thisAssets.Scripts.Models.Towers.TowerModel).towerModel'></a>

`towerModel` [Assets.Scripts.Models.Towers.TowerModel](https://docs.microsoft.com/en-us/dotnet/api/Assets.Scripts.Models.Towers.TowerModel 'Assets.Scripts.Models.Towers.TowerModel')

#### Returns
[Assets.Scripts.Models.Towers.Behaviors.Attack.AttackModel](https://docs.microsoft.com/en-us/dotnet/api/Assets.Scripts.Models.Towers.Behaviors.Attack.AttackModel 'Assets.Scripts.Models.Towers.Behaviors.Attack.AttackModel')

<a name='BTD_Mod_Helper.Extensions.TowerModelExt.GetAttackModel(thisAssets.Scripts.Models.Towers.TowerModel,int)'></a>

## TowerModelExt.GetAttackModel(this TowerModel, int) Method

Return one of the AttackModels from this TowerModel. By default will give the first AttackModel

```csharp
public static Assets.Scripts.Models.Towers.Behaviors.Attack.AttackModel GetAttackModel(this Assets.Scripts.Models.Towers.TowerModel towerModel, int index);
```
#### Parameters

<a name='BTD_Mod_Helper.Extensions.TowerModelExt.GetAttackModel(thisAssets.Scripts.Models.Towers.TowerModel,int).towerModel'></a>

`towerModel` [Assets.Scripts.Models.Towers.TowerModel](https://docs.microsoft.com/en-us/dotnet/api/Assets.Scripts.Models.Towers.TowerModel 'Assets.Scripts.Models.Towers.TowerModel')

The TowerModel

<a name='BTD_Mod_Helper.Extensions.TowerModelExt.GetAttackModel(thisAssets.Scripts.Models.Towers.TowerModel,int).index'></a>

`index` [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/System.Int32 'System.Int32')

Index of the AttackModel you want

#### Returns
[Assets.Scripts.Models.Towers.Behaviors.Attack.AttackModel](https://docs.microsoft.com/en-us/dotnet/api/Assets.Scripts.Models.Towers.Behaviors.Attack.AttackModel 'Assets.Scripts.Models.Towers.Behaviors.Attack.AttackModel')

<a name='BTD_Mod_Helper.Extensions.TowerModelExt.GetAttackModel(thisAssets.Scripts.Models.Towers.TowerModel,string)'></a>

## TowerModelExt.GetAttackModel(this TowerModel, string) Method

Return the first AttackModel whose name contains the given string

```csharp
public static Assets.Scripts.Models.Towers.Behaviors.Attack.AttackModel GetAttackModel(this Assets.Scripts.Models.Towers.TowerModel towerModel, string nameContains);
```
#### Parameters

<a name='BTD_Mod_Helper.Extensions.TowerModelExt.GetAttackModel(thisAssets.Scripts.Models.Towers.TowerModel,string).towerModel'></a>

`towerModel` [Assets.Scripts.Models.Towers.TowerModel](https://docs.microsoft.com/en-us/dotnet/api/Assets.Scripts.Models.Towers.TowerModel 'Assets.Scripts.Models.Towers.TowerModel')

<a name='BTD_Mod_Helper.Extensions.TowerModelExt.GetAttackModel(thisAssets.Scripts.Models.Towers.TowerModel,string).nameContains'></a>

`nameContains` [System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')

#### Returns
[Assets.Scripts.Models.Towers.Behaviors.Attack.AttackModel](https://docs.microsoft.com/en-us/dotnet/api/Assets.Scripts.Models.Towers.Behaviors.Attack.AttackModel 'Assets.Scripts.Models.Towers.Behaviors.Attack.AttackModel')

<a name='BTD_Mod_Helper.Extensions.TowerModelExt.GetAttackModels(thisAssets.Scripts.Models.Towers.TowerModel)'></a>

## TowerModelExt.GetAttackModels(this TowerModel) Method

Return all AttackModel behaviors for this TowerModel

```csharp
public static System.Collections.Generic.List<Assets.Scripts.Models.Towers.Behaviors.Attack.AttackModel> GetAttackModels(this Assets.Scripts.Models.Towers.TowerModel towerModel);
```
#### Parameters

<a name='BTD_Mod_Helper.Extensions.TowerModelExt.GetAttackModels(thisAssets.Scripts.Models.Towers.TowerModel).towerModel'></a>

`towerModel` [Assets.Scripts.Models.Towers.TowerModel](https://docs.microsoft.com/en-us/dotnet/api/Assets.Scripts.Models.Towers.TowerModel 'Assets.Scripts.Models.Towers.TowerModel')

#### Returns
[System.Collections.Generic.List&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.List-1 'System.Collections.Generic.List`1')[Assets.Scripts.Models.Towers.Behaviors.Attack.AttackModel](https://docs.microsoft.com/en-us/dotnet/api/Assets.Scripts.Models.Towers.Behaviors.Attack.AttackModel 'Assets.Scripts.Models.Towers.Behaviors.Attack.AttackModel')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.List-1 'System.Collections.Generic.List`1')

<a name='BTD_Mod_Helper.Extensions.TowerModelExt.GetBaseId(thisAssets.Scripts.Models.Towers.TowerModel)'></a>

## TowerModelExt.GetBaseId(this TowerModel) Method

Get the name of the BaseTower. Will be different from this TowerModel's name if this TowerModel isn't a BaseTower

```csharp
public static string GetBaseId(this Assets.Scripts.Models.Towers.TowerModel towerModel);
```
#### Parameters

<a name='BTD_Mod_Helper.Extensions.TowerModelExt.GetBaseId(thisAssets.Scripts.Models.Towers.TowerModel).towerModel'></a>

`towerModel` [Assets.Scripts.Models.Towers.TowerModel](https://docs.microsoft.com/en-us/dotnet/api/Assets.Scripts.Models.Towers.TowerModel 'Assets.Scripts.Models.Towers.TowerModel')

#### Returns
[System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')

<a name='BTD_Mod_Helper.Extensions.TowerModelExt.GetHeroModel(thisAssets.Scripts.Models.Towers.TowerModel)'></a>

## TowerModelExt.GetHeroModel(this TowerModel) Method

If this TowerModel is a Hero, return the HeroModel behavior

```csharp
public static Assets.Scripts.Models.Towers.Behaviors.HeroModel GetHeroModel(this Assets.Scripts.Models.Towers.TowerModel towerModel);
```
#### Parameters

<a name='BTD_Mod_Helper.Extensions.TowerModelExt.GetHeroModel(thisAssets.Scripts.Models.Towers.TowerModel).towerModel'></a>

`towerModel` [Assets.Scripts.Models.Towers.TowerModel](https://docs.microsoft.com/en-us/dotnet/api/Assets.Scripts.Models.Towers.TowerModel 'Assets.Scripts.Models.Towers.TowerModel')

#### Returns
[Assets.Scripts.Models.Towers.Behaviors.HeroModel](https://docs.microsoft.com/en-us/dotnet/api/Assets.Scripts.Models.Towers.Behaviors.HeroModel 'Assets.Scripts.Models.Towers.Behaviors.HeroModel')

<a name='BTD_Mod_Helper.Extensions.TowerModelExt.GetIndex(thisAssets.Scripts.Models.Towers.TowerModel)'></a>

## TowerModelExt.GetIndex(this TowerModel) Method

Return the number position of this TowerModel in the list of all tower models

```csharp
public static int GetIndex(this Assets.Scripts.Models.Towers.TowerModel towerModel);
```
#### Parameters

<a name='BTD_Mod_Helper.Extensions.TowerModelExt.GetIndex(thisAssets.Scripts.Models.Towers.TowerModel).towerModel'></a>

`towerModel` [Assets.Scripts.Models.Towers.TowerModel](https://docs.microsoft.com/en-us/dotnet/api/Assets.Scripts.Models.Towers.TowerModel 'Assets.Scripts.Models.Towers.TowerModel')

#### Returns
[System.Int32](https://docs.microsoft.com/en-us/dotnet/api/System.Int32 'System.Int32')

<a name='BTD_Mod_Helper.Extensions.TowerModelExt.GetModTower(thisAssets.Scripts.Models.Towers.TowerModel)'></a>

## TowerModelExt.GetModTower(this TowerModel) Method

Gets the ModTower associated with this TowerModel  
<br/>  
If there is no associated ModTower, returns null

```csharp
public static BTD_Mod_Helper.Api.Towers.ModTower GetModTower(this Assets.Scripts.Models.Towers.TowerModel towerModel);
```
#### Parameters

<a name='BTD_Mod_Helper.Extensions.TowerModelExt.GetModTower(thisAssets.Scripts.Models.Towers.TowerModel).towerModel'></a>

`towerModel` [Assets.Scripts.Models.Towers.TowerModel](https://docs.microsoft.com/en-us/dotnet/api/Assets.Scripts.Models.Towers.TowerModel 'Assets.Scripts.Models.Towers.TowerModel')

#### Returns
[ModTower](BTD_Mod_Helper.Api.Towers.ModTower.md 'BTD_Mod_Helper.Api.Towers.ModTower')

<a name='BTD_Mod_Helper.Extensions.TowerModelExt.GetModTower_T_(thisAssets.Scripts.Models.Towers.TowerModel)'></a>

## TowerModelExt.GetModTower<T>(this TowerModel) Method

Gets the specific ModTower associated with this TowerModel  
<br/>  
If there is no associated ModTower, returns null

```csharp
public static T GetModTower<T>(this Assets.Scripts.Models.Towers.TowerModel towerModel)
    where T : BTD_Mod_Helper.Api.Towers.ModTower;
```
#### Type parameters

<a name='BTD_Mod_Helper.Extensions.TowerModelExt.GetModTower_T_(thisAssets.Scripts.Models.Towers.TowerModel).T'></a>

`T`
#### Parameters

<a name='BTD_Mod_Helper.Extensions.TowerModelExt.GetModTower_T_(thisAssets.Scripts.Models.Towers.TowerModel).towerModel'></a>

`towerModel` [Assets.Scripts.Models.Towers.TowerModel](https://docs.microsoft.com/en-us/dotnet/api/Assets.Scripts.Models.Towers.TowerModel 'Assets.Scripts.Models.Towers.TowerModel')

#### Returns
[T](BTD_Mod_Helper.Extensions.TowerModelExt.md#BTD_Mod_Helper.Extensions.TowerModelExt.GetModTower_T_(thisAssets.Scripts.Models.Towers.TowerModel).T 'BTD_Mod_Helper.Extensions.TowerModelExt.GetModTower<T>(this Assets.Scripts.Models.Towers.TowerModel).T')

<a name='BTD_Mod_Helper.Extensions.TowerModelExt.GetTowerDetailsModel(thisAssets.Scripts.Models.Towers.TowerModel)'></a>

## TowerModelExt.GetTowerDetailsModel(this TowerModel) Method

Return all TowerDetailModels that share a base id with this towerModel

```csharp
public static Assets.Scripts.Models.TowerSets.TowerDetailsModel GetTowerDetailsModel(this Assets.Scripts.Models.Towers.TowerModel towerModel);
```
#### Parameters

<a name='BTD_Mod_Helper.Extensions.TowerModelExt.GetTowerDetailsModel(thisAssets.Scripts.Models.Towers.TowerModel).towerModel'></a>

`towerModel` [Assets.Scripts.Models.Towers.TowerModel](https://docs.microsoft.com/en-us/dotnet/api/Assets.Scripts.Models.Towers.TowerModel 'Assets.Scripts.Models.Towers.TowerModel')

#### Returns
[Assets.Scripts.Models.TowerSets.TowerDetailsModel](https://docs.microsoft.com/en-us/dotnet/api/Assets.Scripts.Models.TowerSets.TowerDetailsModel 'Assets.Scripts.Models.TowerSets.TowerDetailsModel')

<a name='BTD_Mod_Helper.Extensions.TowerModelExt.GetTowerId(thisAssets.Scripts.Models.Towers.TowerModel)'></a>

## TowerModelExt.GetTowerId(this TowerModel) Method

Get the TowerId of this TowerModel. Equivalent to towerModel.name

```csharp
public static string GetTowerId(this Assets.Scripts.Models.Towers.TowerModel towerModel);
```
#### Parameters

<a name='BTD_Mod_Helper.Extensions.TowerModelExt.GetTowerId(thisAssets.Scripts.Models.Towers.TowerModel).towerModel'></a>

`towerModel` [Assets.Scripts.Models.Towers.TowerModel](https://docs.microsoft.com/en-us/dotnet/api/Assets.Scripts.Models.Towers.TowerModel 'Assets.Scripts.Models.Towers.TowerModel')

#### Returns
[System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')

<a name='BTD_Mod_Helper.Extensions.TowerModelExt.GetTowerPurchaseButton(thisAssets.Scripts.Models.Towers.TowerModel)'></a>

## TowerModelExt.GetTowerPurchaseButton(this TowerModel) Method

Return the TowerPurchaseButton for this TowerModel.

```csharp
public static Assets.Scripts.Unity.UI_New.InGame.StoreMenu.TowerPurchaseButton GetTowerPurchaseButton(this Assets.Scripts.Models.Towers.TowerModel towerModel);
```
#### Parameters

<a name='BTD_Mod_Helper.Extensions.TowerModelExt.GetTowerPurchaseButton(thisAssets.Scripts.Models.Towers.TowerModel).towerModel'></a>

`towerModel` [Assets.Scripts.Models.Towers.TowerModel](https://docs.microsoft.com/en-us/dotnet/api/Assets.Scripts.Models.Towers.TowerModel 'Assets.Scripts.Models.Towers.TowerModel')

#### Returns
[Assets.Scripts.Unity.UI_New.InGame.StoreMenu.TowerPurchaseButton](https://docs.microsoft.com/en-us/dotnet/api/Assets.Scripts.Unity.UI_New.InGame.StoreMenu.TowerPurchaseButton 'Assets.Scripts.Unity.UI_New.InGame.StoreMenu.TowerPurchaseButton')

<a name='BTD_Mod_Helper.Extensions.TowerModelExt.GetUpgrade(thisAssets.Scripts.Models.Towers.TowerModel,int,int)'></a>

## TowerModelExt.GetUpgrade(this TowerModel, int, int) Method

Return the UpgradeModel for a specific upgrade path/tier

```csharp
public static Assets.Scripts.Models.Towers.Upgrades.UpgradeModel GetUpgrade(this Assets.Scripts.Models.Towers.TowerModel towerModel, int path, int tier);
```
#### Parameters

<a name='BTD_Mod_Helper.Extensions.TowerModelExt.GetUpgrade(thisAssets.Scripts.Models.Towers.TowerModel,int,int).towerModel'></a>

`towerModel` [Assets.Scripts.Models.Towers.TowerModel](https://docs.microsoft.com/en-us/dotnet/api/Assets.Scripts.Models.Towers.TowerModel 'Assets.Scripts.Models.Towers.TowerModel')

<a name='BTD_Mod_Helper.Extensions.TowerModelExt.GetUpgrade(thisAssets.Scripts.Models.Towers.TowerModel,int,int).path'></a>

`path` [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/System.Int32 'System.Int32')

<a name='BTD_Mod_Helper.Extensions.TowerModelExt.GetUpgrade(thisAssets.Scripts.Models.Towers.TowerModel,int,int).tier'></a>

`tier` [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/System.Int32 'System.Int32')

#### Returns
[Assets.Scripts.Models.Towers.Upgrades.UpgradeModel](https://docs.microsoft.com/en-us/dotnet/api/Assets.Scripts.Models.Towers.Upgrades.UpgradeModel 'Assets.Scripts.Models.Towers.Upgrades.UpgradeModel')

<a name='BTD_Mod_Helper.Extensions.TowerModelExt.GetUpgradeLevel(thisAssets.Scripts.Models.Towers.TowerModel,int)'></a>

## TowerModelExt.GetUpgradeLevel(this TowerModel, int) Method

Return the current upgrade level of a specific path

```csharp
public static int GetUpgradeLevel(this Assets.Scripts.Models.Towers.TowerModel towerModel, int path);
```
#### Parameters

<a name='BTD_Mod_Helper.Extensions.TowerModelExt.GetUpgradeLevel(thisAssets.Scripts.Models.Towers.TowerModel,int).towerModel'></a>

`towerModel` [Assets.Scripts.Models.Towers.TowerModel](https://docs.microsoft.com/en-us/dotnet/api/Assets.Scripts.Models.Towers.TowerModel 'Assets.Scripts.Models.Towers.TowerModel')

the TowerModel

<a name='BTD_Mod_Helper.Extensions.TowerModelExt.GetUpgradeLevel(thisAssets.Scripts.Models.Towers.TowerModel,int).path'></a>

`path` [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/System.Int32 'System.Int32')

What tier of upgrade is currently applied to tower

#### Returns
[System.Int32](https://docs.microsoft.com/en-us/dotnet/api/System.Int32 'System.Int32')

<a name='BTD_Mod_Helper.Extensions.TowerModelExt.GetWeapon(thisAssets.Scripts.Models.Towers.TowerModel)'></a>

## TowerModelExt.GetWeapon(this TowerModel) Method

Return the first WeaponModel this TowerModel has, if it has one.

```csharp
public static Assets.Scripts.Models.Towers.Weapons.WeaponModel GetWeapon(this Assets.Scripts.Models.Towers.TowerModel towerModel);
```
#### Parameters

<a name='BTD_Mod_Helper.Extensions.TowerModelExt.GetWeapon(thisAssets.Scripts.Models.Towers.TowerModel).towerModel'></a>

`towerModel` [Assets.Scripts.Models.Towers.TowerModel](https://docs.microsoft.com/en-us/dotnet/api/Assets.Scripts.Models.Towers.TowerModel 'Assets.Scripts.Models.Towers.TowerModel')

#### Returns
[Assets.Scripts.Models.Towers.Weapons.WeaponModel](https://docs.microsoft.com/en-us/dotnet/api/Assets.Scripts.Models.Towers.Weapons.WeaponModel 'Assets.Scripts.Models.Towers.Weapons.WeaponModel')

<a name='BTD_Mod_Helper.Extensions.TowerModelExt.GetWeapon(thisAssets.Scripts.Models.Towers.TowerModel,int)'></a>

## TowerModelExt.GetWeapon(this TowerModel, int) Method

Return one of the WeaponModels this TowerModel has. By default will return the first one

```csharp
public static Assets.Scripts.Models.Towers.Weapons.WeaponModel GetWeapon(this Assets.Scripts.Models.Towers.TowerModel towerModel, int index);
```
#### Parameters

<a name='BTD_Mod_Helper.Extensions.TowerModelExt.GetWeapon(thisAssets.Scripts.Models.Towers.TowerModel,int).towerModel'></a>

`towerModel` [Assets.Scripts.Models.Towers.TowerModel](https://docs.microsoft.com/en-us/dotnet/api/Assets.Scripts.Models.Towers.TowerModel 'Assets.Scripts.Models.Towers.TowerModel')

The TowerModel

<a name='BTD_Mod_Helper.Extensions.TowerModelExt.GetWeapon(thisAssets.Scripts.Models.Towers.TowerModel,int).index'></a>

`index` [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/System.Int32 'System.Int32')

Index of WeaponModel that you want

#### Returns
[Assets.Scripts.Models.Towers.Weapons.WeaponModel](https://docs.microsoft.com/en-us/dotnet/api/Assets.Scripts.Models.Towers.Weapons.WeaponModel 'Assets.Scripts.Models.Towers.Weapons.WeaponModel')

<a name='BTD_Mod_Helper.Extensions.TowerModelExt.GetWeapons(thisAssets.Scripts.Models.Towers.TowerModel)'></a>

## TowerModelExt.GetWeapons(this TowerModel) Method

Recursively get every WeaponModels this TowerModel has

```csharp
public static System.Collections.Generic.List<Assets.Scripts.Models.Towers.Weapons.WeaponModel> GetWeapons(this Assets.Scripts.Models.Towers.TowerModel towerModel);
```
#### Parameters

<a name='BTD_Mod_Helper.Extensions.TowerModelExt.GetWeapons(thisAssets.Scripts.Models.Towers.TowerModel).towerModel'></a>

`towerModel` [Assets.Scripts.Models.Towers.TowerModel](https://docs.microsoft.com/en-us/dotnet/api/Assets.Scripts.Models.Towers.TowerModel 'Assets.Scripts.Models.Towers.TowerModel')

#### Returns
[System.Collections.Generic.List&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.List-1 'System.Collections.Generic.List`1')[Assets.Scripts.Models.Towers.Weapons.WeaponModel](https://docs.microsoft.com/en-us/dotnet/api/Assets.Scripts.Models.Towers.Weapons.WeaponModel 'Assets.Scripts.Models.Towers.Weapons.WeaponModel')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.List-1 'System.Collections.Generic.List`1')

<a name='BTD_Mod_Helper.Extensions.TowerModelExt.HasTiers(thisAssets.Scripts.Models.Towers.TowerModel,int,int,int)'></a>

## TowerModelExt.HasTiers(this TowerModel, int, int, int) Method

Check if this tower has speficif upgrade tiers

```csharp
public static bool HasTiers(this Assets.Scripts.Models.Towers.TowerModel towerModel, int tier1=0, int tier2=0, int tier3=0);
```
#### Parameters

<a name='BTD_Mod_Helper.Extensions.TowerModelExt.HasTiers(thisAssets.Scripts.Models.Towers.TowerModel,int,int,int).towerModel'></a>

`towerModel` [Assets.Scripts.Models.Towers.TowerModel](https://docs.microsoft.com/en-us/dotnet/api/Assets.Scripts.Models.Towers.TowerModel 'Assets.Scripts.Models.Towers.TowerModel')

<a name='BTD_Mod_Helper.Extensions.TowerModelExt.HasTiers(thisAssets.Scripts.Models.Towers.TowerModel,int,int,int).tier1'></a>

`tier1` [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/System.Int32 'System.Int32')

<a name='BTD_Mod_Helper.Extensions.TowerModelExt.HasTiers(thisAssets.Scripts.Models.Towers.TowerModel,int,int,int).tier2'></a>

`tier2` [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/System.Int32 'System.Int32')

<a name='BTD_Mod_Helper.Extensions.TowerModelExt.HasTiers(thisAssets.Scripts.Models.Towers.TowerModel,int,int,int).tier3'></a>

`tier3` [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/System.Int32 'System.Int32')

#### Returns
[System.Boolean](https://docs.microsoft.com/en-us/dotnet/api/System.Boolean 'System.Boolean')

<a name='BTD_Mod_Helper.Extensions.TowerModelExt.HasUpgrade(thisAssets.Scripts.Models.Towers.TowerModel,Assets.Scripts.Models.Towers.Upgrades.UpgradeModel)'></a>

## TowerModelExt.HasUpgrade(this TowerModel, UpgradeModel) Method

Check if an upgrade has been applied

```csharp
public static bool HasUpgrade(this Assets.Scripts.Models.Towers.TowerModel towerModel, Assets.Scripts.Models.Towers.Upgrades.UpgradeModel upgradeModel);
```
#### Parameters

<a name='BTD_Mod_Helper.Extensions.TowerModelExt.HasUpgrade(thisAssets.Scripts.Models.Towers.TowerModel,Assets.Scripts.Models.Towers.Upgrades.UpgradeModel).towerModel'></a>

`towerModel` [Assets.Scripts.Models.Towers.TowerModel](https://docs.microsoft.com/en-us/dotnet/api/Assets.Scripts.Models.Towers.TowerModel 'Assets.Scripts.Models.Towers.TowerModel')

<a name='BTD_Mod_Helper.Extensions.TowerModelExt.HasUpgrade(thisAssets.Scripts.Models.Towers.TowerModel,Assets.Scripts.Models.Towers.Upgrades.UpgradeModel).upgradeModel'></a>

`upgradeModel` [Assets.Scripts.Models.Towers.Upgrades.UpgradeModel](https://docs.microsoft.com/en-us/dotnet/api/Assets.Scripts.Models.Towers.Upgrades.UpgradeModel 'Assets.Scripts.Models.Towers.Upgrades.UpgradeModel')

#### Returns
[System.Boolean](https://docs.microsoft.com/en-us/dotnet/api/System.Boolean 'System.Boolean')

<a name='BTD_Mod_Helper.Extensions.TowerModelExt.HasUpgrade(thisAssets.Scripts.Models.Towers.TowerModel,int,int)'></a>

## TowerModelExt.HasUpgrade(this TowerModel, int, int) Method

Check if an upgrade has been applied

```csharp
public static bool HasUpgrade(this Assets.Scripts.Models.Towers.TowerModel towerModel, int path, int tier);
```
#### Parameters

<a name='BTD_Mod_Helper.Extensions.TowerModelExt.HasUpgrade(thisAssets.Scripts.Models.Towers.TowerModel,int,int).towerModel'></a>

`towerModel` [Assets.Scripts.Models.Towers.TowerModel](https://docs.microsoft.com/en-us/dotnet/api/Assets.Scripts.Models.Towers.TowerModel 'Assets.Scripts.Models.Towers.TowerModel')

<a name='BTD_Mod_Helper.Extensions.TowerModelExt.HasUpgrade(thisAssets.Scripts.Models.Towers.TowerModel,int,int).path'></a>

`path` [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/System.Int32 'System.Int32')

<a name='BTD_Mod_Helper.Extensions.TowerModelExt.HasUpgrade(thisAssets.Scripts.Models.Towers.TowerModel,int,int).tier'></a>

`tier` [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/System.Int32 'System.Int32')

#### Returns
[System.Boolean](https://docs.microsoft.com/en-us/dotnet/api/System.Boolean 'System.Boolean')

<a name='BTD_Mod_Helper.Extensions.TowerModelExt.IncreaseRange(thisAssets.Scripts.Models.Towers.TowerModel,float)'></a>

## TowerModelExt.IncreaseRange(this TowerModel, float) Method

Increase the range of a tower and all its attacks by the given amount

```csharp
public static void IncreaseRange(this Assets.Scripts.Models.Towers.TowerModel towerModel, float rangeIncrease);
```
#### Parameters

<a name='BTD_Mod_Helper.Extensions.TowerModelExt.IncreaseRange(thisAssets.Scripts.Models.Towers.TowerModel,float).towerModel'></a>

`towerModel` [Assets.Scripts.Models.Towers.TowerModel](https://docs.microsoft.com/en-us/dotnet/api/Assets.Scripts.Models.Towers.TowerModel 'Assets.Scripts.Models.Towers.TowerModel')

<a name='BTD_Mod_Helper.Extensions.TowerModelExt.IncreaseRange(thisAssets.Scripts.Models.Towers.TowerModel,float).rangeIncrease'></a>

`rangeIncrease` [System.Single](https://docs.microsoft.com/en-us/dotnet/api/System.Single 'System.Single')

<a name='BTD_Mod_Helper.Extensions.TowerModelExt.IsHeroUnlocked(thisAssets.Scripts.Models.Towers.TowerModel)'></a>

## TowerModelExt.IsHeroUnlocked(this TowerModel) Method

If this TowerModel is for a Hero, is this Hero unlocked?

```csharp
public static System.Nullable<bool> IsHeroUnlocked(this Assets.Scripts.Models.Towers.TowerModel towerModel);
```
#### Parameters

<a name='BTD_Mod_Helper.Extensions.TowerModelExt.IsHeroUnlocked(thisAssets.Scripts.Models.Towers.TowerModel).towerModel'></a>

`towerModel` [Assets.Scripts.Models.Towers.TowerModel](https://docs.microsoft.com/en-us/dotnet/api/Assets.Scripts.Models.Towers.TowerModel 'Assets.Scripts.Models.Towers.TowerModel')

#### Returns
[System.Nullable&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Nullable-1 'System.Nullable`1')[System.Boolean](https://docs.microsoft.com/en-us/dotnet/api/System.Boolean 'System.Boolean')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Nullable-1 'System.Nullable`1')

<a name='BTD_Mod_Helper.Extensions.TowerModelExt.IsTowerUnlocked(thisAssets.Scripts.Models.Towers.TowerModel)'></a>

## TowerModelExt.IsTowerUnlocked(this TowerModel) Method

Has player already unlocked this TowerModel

```csharp
public static System.Nullable<bool> IsTowerUnlocked(this Assets.Scripts.Models.Towers.TowerModel towerModel);
```
#### Parameters

<a name='BTD_Mod_Helper.Extensions.TowerModelExt.IsTowerUnlocked(thisAssets.Scripts.Models.Towers.TowerModel).towerModel'></a>

`towerModel` [Assets.Scripts.Models.Towers.TowerModel](https://docs.microsoft.com/en-us/dotnet/api/Assets.Scripts.Models.Towers.TowerModel 'Assets.Scripts.Models.Towers.TowerModel')

#### Returns
[System.Nullable&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Nullable-1 'System.Nullable`1')[System.Boolean](https://docs.microsoft.com/en-us/dotnet/api/System.Boolean 'System.Boolean')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Nullable-1 'System.Nullable`1')

<a name='BTD_Mod_Helper.Extensions.TowerModelExt.IsUpgradePathUsed(thisAssets.Scripts.Models.Towers.TowerModel,int)'></a>

## TowerModelExt.IsUpgradePathUsed(this TowerModel, int) Method

Check if a specific upgrade path is being used/ has any upgrades applied to it

```csharp
public static bool IsUpgradePathUsed(this Assets.Scripts.Models.Towers.TowerModel towerModel, int path);
```
#### Parameters

<a name='BTD_Mod_Helper.Extensions.TowerModelExt.IsUpgradePathUsed(thisAssets.Scripts.Models.Towers.TowerModel,int).towerModel'></a>

`towerModel` [Assets.Scripts.Models.Towers.TowerModel](https://docs.microsoft.com/en-us/dotnet/api/Assets.Scripts.Models.Towers.TowerModel 'Assets.Scripts.Models.Towers.TowerModel')

the TowerModel

<a name='BTD_Mod_Helper.Extensions.TowerModelExt.IsUpgradePathUsed(thisAssets.Scripts.Models.Towers.TowerModel,int).path'></a>

`path` [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/System.Int32 'System.Int32')

Upgrade path to check

#### Returns
[System.Boolean](https://docs.microsoft.com/en-us/dotnet/api/System.Boolean 'System.Boolean')

<a name='BTD_Mod_Helper.Extensions.TowerModelExt.IsUpgradeUnlocked(thisAssets.Scripts.Models.Towers.TowerModel,int,int)'></a>

## TowerModelExt.IsUpgradeUnlocked(this TowerModel, int, int) Method

Has a specific upgrade for this TowerModel been unlocked already?

```csharp
public static System.Nullable<bool> IsUpgradeUnlocked(this Assets.Scripts.Models.Towers.TowerModel towerModel, int path, int tier);
```
#### Parameters

<a name='BTD_Mod_Helper.Extensions.TowerModelExt.IsUpgradeUnlocked(thisAssets.Scripts.Models.Towers.TowerModel,int,int).towerModel'></a>

`towerModel` [Assets.Scripts.Models.Towers.TowerModel](https://docs.microsoft.com/en-us/dotnet/api/Assets.Scripts.Models.Towers.TowerModel 'Assets.Scripts.Models.Towers.TowerModel')

the TowerModel

<a name='BTD_Mod_Helper.Extensions.TowerModelExt.IsUpgradeUnlocked(thisAssets.Scripts.Models.Towers.TowerModel,int,int).path'></a>

`path` [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/System.Int32 'System.Int32')

Upgrade path

<a name='BTD_Mod_Helper.Extensions.TowerModelExt.IsUpgradeUnlocked(thisAssets.Scripts.Models.Towers.TowerModel,int,int).tier'></a>

`tier` [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/System.Int32 'System.Int32')

Tier of upgrade

#### Returns
[System.Nullable&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Nullable-1 'System.Nullable`1')[System.Boolean](https://docs.microsoft.com/en-us/dotnet/api/System.Boolean 'System.Boolean')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Nullable-1 'System.Nullable`1')

<a name='BTD_Mod_Helper.Extensions.TowerModelExt.MakeCopy(thisAssets.Scripts.Models.Towers.TowerModel,string,bool,string)'></a>

## TowerModelExt.MakeCopy(this TowerModel, string, bool, string) Method

Duplicate this TowerModel with a unique name. Very useful for making custom TowerModels

```csharp
public static Assets.Scripts.Models.Towers.TowerModel MakeCopy(this Assets.Scripts.Models.Towers.TowerModel towerModel, string newTowerId, bool addToGame=false, string newBaseId=null);
```
#### Parameters

<a name='BTD_Mod_Helper.Extensions.TowerModelExt.MakeCopy(thisAssets.Scripts.Models.Towers.TowerModel,string,bool,string).towerModel'></a>

`towerModel` [Assets.Scripts.Models.Towers.TowerModel](https://docs.microsoft.com/en-us/dotnet/api/Assets.Scripts.Models.Towers.TowerModel 'Assets.Scripts.Models.Towers.TowerModel')

<a name='BTD_Mod_Helper.Extensions.TowerModelExt.MakeCopy(thisAssets.Scripts.Models.Towers.TowerModel,string,bool,string).newTowerId'></a>

`newTowerId` [System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')

Set's the new towerId of this copy. By default the baseId will be set to this as well

<a name='BTD_Mod_Helper.Extensions.TowerModelExt.MakeCopy(thisAssets.Scripts.Models.Towers.TowerModel,string,bool,string).addToGame'></a>

`addToGame` [System.Boolean](https://docs.microsoft.com/en-us/dotnet/api/System.Boolean 'System.Boolean')

<a name='BTD_Mod_Helper.Extensions.TowerModelExt.MakeCopy(thisAssets.Scripts.Models.Towers.TowerModel,string,bool,string).newBaseId'></a>

`newBaseId` [System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')

Specify a new baseId. Set this if you want a baseId other than the newTowerId

#### Returns
[Assets.Scripts.Models.Towers.TowerModel](https://docs.microsoft.com/en-us/dotnet/api/Assets.Scripts.Models.Towers.TowerModel 'Assets.Scripts.Models.Towers.TowerModel')

<a name='BTD_Mod_Helper.Extensions.TowerModelExt.SellAll(thisAssets.Scripts.Models.Towers.TowerModel)'></a>

## TowerModelExt.SellAll(this TowerModel) Method

Sell every tower that uses this TowerModel

```csharp
public static void SellAll(this Assets.Scripts.Models.Towers.TowerModel towerModel);
```
#### Parameters

<a name='BTD_Mod_Helper.Extensions.TowerModelExt.SellAll(thisAssets.Scripts.Models.Towers.TowerModel).towerModel'></a>

`towerModel` [Assets.Scripts.Models.Towers.TowerModel](https://docs.microsoft.com/en-us/dotnet/api/Assets.Scripts.Models.Towers.TowerModel 'Assets.Scripts.Models.Towers.TowerModel')

<a name='BTD_Mod_Helper.Extensions.TowerModelExt.SetMaxAmount(thisAssets.Scripts.Models.Towers.TowerModel,int)'></a>

## TowerModelExt.SetMaxAmount(this TowerModel, int) Method

Not Tested. Use to set the maximum allowed number of this tower

```csharp
public static void SetMaxAmount(this Assets.Scripts.Models.Towers.TowerModel towerModel, int max);
```
#### Parameters

<a name='BTD_Mod_Helper.Extensions.TowerModelExt.SetMaxAmount(thisAssets.Scripts.Models.Towers.TowerModel,int).towerModel'></a>

`towerModel` [Assets.Scripts.Models.Towers.TowerModel](https://docs.microsoft.com/en-us/dotnet/api/Assets.Scripts.Models.Towers.TowerModel 'Assets.Scripts.Models.Towers.TowerModel')

<a name='BTD_Mod_Helper.Extensions.TowerModelExt.SetMaxAmount(thisAssets.Scripts.Models.Towers.TowerModel,int).max'></a>

`max` [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/System.Int32 'System.Int32')

<a name='BTD_Mod_Helper.Extensions.TowerModelExt.SetTiers(thisAssets.Scripts.Models.Towers.TowerModel,int,int,int,bool)'></a>

## TowerModelExt.SetTiers(this TowerModel, int, int, int, bool) Method

Sets a TowerModel's tiers

```csharp
public static void SetTiers(this Assets.Scripts.Models.Towers.TowerModel towerModel, int tier1=0, int tier2=0, int tier3=0, bool addToTowerName=false);
```
#### Parameters

<a name='BTD_Mod_Helper.Extensions.TowerModelExt.SetTiers(thisAssets.Scripts.Models.Towers.TowerModel,int,int,int,bool).towerModel'></a>

`towerModel` [Assets.Scripts.Models.Towers.TowerModel](https://docs.microsoft.com/en-us/dotnet/api/Assets.Scripts.Models.Towers.TowerModel 'Assets.Scripts.Models.Towers.TowerModel')

<a name='BTD_Mod_Helper.Extensions.TowerModelExt.SetTiers(thisAssets.Scripts.Models.Towers.TowerModel,int,int,int,bool).tier1'></a>

`tier1` [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/System.Int32 'System.Int32')

<a name='BTD_Mod_Helper.Extensions.TowerModelExt.SetTiers(thisAssets.Scripts.Models.Towers.TowerModel,int,int,int,bool).tier2'></a>

`tier2` [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/System.Int32 'System.Int32')

<a name='BTD_Mod_Helper.Extensions.TowerModelExt.SetTiers(thisAssets.Scripts.Models.Towers.TowerModel,int,int,int,bool).tier3'></a>

`tier3` [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/System.Int32 'System.Int32')

<a name='BTD_Mod_Helper.Extensions.TowerModelExt.SetTiers(thisAssets.Scripts.Models.Towers.TowerModel,int,int,int,bool).addToTowerName'></a>

`addToTowerName` [System.Boolean](https://docs.microsoft.com/en-us/dotnet/api/System.Boolean 'System.Boolean')