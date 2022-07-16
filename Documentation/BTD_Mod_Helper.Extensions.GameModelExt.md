#### [BloonsTD6 Mod Helper](index.md 'index')
### [BTD_Mod_Helper.Extensions](index.md#BTD_Mod_Helper.Extensions 'BTD_Mod_Helper.Extensions')

## GameModelExt Class

Extensions for the GameModel

```csharp
public static class GameModelExt
```

Inheritance [System.Object](https://docs.microsoft.com/en-us/dotnet/api/System.Object 'System.Object') &#129106; GameModelExt
### Methods

<a name='BTD_Mod_Helper.Extensions.GameModelExt.AddHeroDetails(thisAssets.Scripts.Models.GameModel,Assets.Scripts.Models.TowerSets.HeroDetailsModel,int)'></a>

## GameModelExt.AddHeroDetails(this GameModel, HeroDetailsModel, int) Method

Adds a HeroDetailsModel to the GameModel's HeroSet at a particular index

```csharp
public static void AddHeroDetails(this Assets.Scripts.Models.GameModel model, Assets.Scripts.Models.TowerSets.HeroDetailsModel heroDetailsModel, int index);
```
#### Parameters

<a name='BTD_Mod_Helper.Extensions.GameModelExt.AddHeroDetails(thisAssets.Scripts.Models.GameModel,Assets.Scripts.Models.TowerSets.HeroDetailsModel,int).model'></a>

`model` [Assets.Scripts.Models.GameModel](https://docs.microsoft.com/en-us/dotnet/api/Assets.Scripts.Models.GameModel 'Assets.Scripts.Models.GameModel')

<a name='BTD_Mod_Helper.Extensions.GameModelExt.AddHeroDetails(thisAssets.Scripts.Models.GameModel,Assets.Scripts.Models.TowerSets.HeroDetailsModel,int).heroDetailsModel'></a>

`heroDetailsModel` [Assets.Scripts.Models.TowerSets.HeroDetailsModel](https://docs.microsoft.com/en-us/dotnet/api/Assets.Scripts.Models.TowerSets.HeroDetailsModel 'Assets.Scripts.Models.TowerSets.HeroDetailsModel')

<a name='BTD_Mod_Helper.Extensions.GameModelExt.AddHeroDetails(thisAssets.Scripts.Models.GameModel,Assets.Scripts.Models.TowerSets.HeroDetailsModel,int).index'></a>

`index` [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/System.Int32 'System.Int32')

<a name='BTD_Mod_Helper.Extensions.GameModelExt.AddTowerDetails(thisAssets.Scripts.Models.GameModel,Assets.Scripts.Models.TowerSets.TowerDetailsModel)'></a>

## GameModelExt.AddTowerDetails(this GameModel, TowerDetailsModel) Method

Adds a tower

```csharp
public static void AddTowerDetails(this Assets.Scripts.Models.GameModel model, Assets.Scripts.Models.TowerSets.TowerDetailsModel towerDetailsModel);
```
#### Parameters

<a name='BTD_Mod_Helper.Extensions.GameModelExt.AddTowerDetails(thisAssets.Scripts.Models.GameModel,Assets.Scripts.Models.TowerSets.TowerDetailsModel).model'></a>

`model` [Assets.Scripts.Models.GameModel](https://docs.microsoft.com/en-us/dotnet/api/Assets.Scripts.Models.GameModel 'Assets.Scripts.Models.GameModel')

<a name='BTD_Mod_Helper.Extensions.GameModelExt.AddTowerDetails(thisAssets.Scripts.Models.GameModel,Assets.Scripts.Models.TowerSets.TowerDetailsModel).towerDetailsModel'></a>

`towerDetailsModel` [Assets.Scripts.Models.TowerSets.TowerDetailsModel](https://docs.microsoft.com/en-us/dotnet/api/Assets.Scripts.Models.TowerSets.TowerDetailsModel 'Assets.Scripts.Models.TowerSets.TowerDetailsModel')

<a name='BTD_Mod_Helper.Extensions.GameModelExt.AddTowerDetails(thisAssets.Scripts.Models.GameModel,Assets.Scripts.Models.TowerSets.TowerDetailsModel,int)'></a>

## GameModelExt.AddTowerDetails(this GameModel, TowerDetailsModel, int) Method

Adds a TowerDetailsModel to the GameModel's TowerSet at a particular index

```csharp
public static void AddTowerDetails(this Assets.Scripts.Models.GameModel model, Assets.Scripts.Models.TowerSets.TowerDetailsModel towerDetailsModel, int index);
```
#### Parameters

<a name='BTD_Mod_Helper.Extensions.GameModelExt.AddTowerDetails(thisAssets.Scripts.Models.GameModel,Assets.Scripts.Models.TowerSets.TowerDetailsModel,int).model'></a>

`model` [Assets.Scripts.Models.GameModel](https://docs.microsoft.com/en-us/dotnet/api/Assets.Scripts.Models.GameModel 'Assets.Scripts.Models.GameModel')

<a name='BTD_Mod_Helper.Extensions.GameModelExt.AddTowerDetails(thisAssets.Scripts.Models.GameModel,Assets.Scripts.Models.TowerSets.TowerDetailsModel,int).towerDetailsModel'></a>

`towerDetailsModel` [Assets.Scripts.Models.TowerSets.TowerDetailsModel](https://docs.microsoft.com/en-us/dotnet/api/Assets.Scripts.Models.TowerSets.TowerDetailsModel 'Assets.Scripts.Models.TowerSets.TowerDetailsModel')

<a name='BTD_Mod_Helper.Extensions.GameModelExt.AddTowerDetails(thisAssets.Scripts.Models.GameModel,Assets.Scripts.Models.TowerSets.TowerDetailsModel,int).index'></a>

`index` [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/System.Int32 'System.Int32')

<a name='BTD_Mod_Helper.Extensions.GameModelExt.AddTowerDetails(thisAssets.Scripts.Models.GameModel,Assets.Scripts.Models.TowerSets.TowerDetailsModel,string)'></a>

## GameModelExt.AddTowerDetails(this GameModel, TowerDetailsModel, string) Method

Adds a TowerDetailsModel to the GameModel's TowerSet, taking into account what set of towers it's a part of  
<br/>  
For example, a new custom Primary tower would be added right at the end of the primary towers,  
and right before the start of the military towers

```csharp
public static void AddTowerDetails(this Assets.Scripts.Models.GameModel model, Assets.Scripts.Models.TowerSets.TowerDetailsModel towerDetailsModel, string set);
```
#### Parameters

<a name='BTD_Mod_Helper.Extensions.GameModelExt.AddTowerDetails(thisAssets.Scripts.Models.GameModel,Assets.Scripts.Models.TowerSets.TowerDetailsModel,string).model'></a>

`model` [Assets.Scripts.Models.GameModel](https://docs.microsoft.com/en-us/dotnet/api/Assets.Scripts.Models.GameModel 'Assets.Scripts.Models.GameModel')

The GameModel

<a name='BTD_Mod_Helper.Extensions.GameModelExt.AddTowerDetails(thisAssets.Scripts.Models.GameModel,Assets.Scripts.Models.TowerSets.TowerDetailsModel,string).towerDetailsModel'></a>

`towerDetailsModel` [Assets.Scripts.Models.TowerSets.TowerDetailsModel](https://docs.microsoft.com/en-us/dotnet/api/Assets.Scripts.Models.TowerSets.TowerDetailsModel 'Assets.Scripts.Models.TowerSets.TowerDetailsModel')

The TowerDetailsModel to be added

<a name='BTD_Mod_Helper.Extensions.GameModelExt.AddTowerDetails(thisAssets.Scripts.Models.GameModel,Assets.Scripts.Models.TowerSets.TowerDetailsModel,string).set'></a>

`set` [System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')

The TowerSet of the tower to be added

<a name='BTD_Mod_Helper.Extensions.GameModelExt.AddTowersToGame(thisAssets.Scripts.Models.GameModel,System.Collections.Generic.IEnumerable_Assets.Scripts.Models.Towers.TowerModel_)'></a>

## GameModelExt.AddTowersToGame(this GameModel, IEnumerable<TowerModel>) Method

Add multiple TowerModels to the game more efficiently than calling the single method repeatedly.

```csharp
public static void AddTowersToGame(this Assets.Scripts.Models.GameModel model, System.Collections.Generic.IEnumerable<Assets.Scripts.Models.Towers.TowerModel> towerModels);
```
#### Parameters

<a name='BTD_Mod_Helper.Extensions.GameModelExt.AddTowersToGame(thisAssets.Scripts.Models.GameModel,System.Collections.Generic.IEnumerable_Assets.Scripts.Models.Towers.TowerModel_).model'></a>

`model` [Assets.Scripts.Models.GameModel](https://docs.microsoft.com/en-us/dotnet/api/Assets.Scripts.Models.GameModel 'Assets.Scripts.Models.GameModel')

<a name='BTD_Mod_Helper.Extensions.GameModelExt.AddTowersToGame(thisAssets.Scripts.Models.GameModel,System.Collections.Generic.IEnumerable_Assets.Scripts.Models.Towers.TowerModel_).towerModels'></a>

`towerModels` [System.Collections.Generic.IEnumerable&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.IEnumerable-1 'System.Collections.Generic.IEnumerable`1')[Assets.Scripts.Models.Towers.TowerModel](https://docs.microsoft.com/en-us/dotnet/api/Assets.Scripts.Models.Towers.TowerModel 'Assets.Scripts.Models.Towers.TowerModel')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.IEnumerable-1 'System.Collections.Generic.IEnumerable`1')

<a name='BTD_Mod_Helper.Extensions.GameModelExt.AddTowerToGame(thisAssets.Scripts.Models.GameModel,Assets.Scripts.Models.Towers.TowerModel,Assets.Scripts.Models.TowerSets.TowerDetailsModel)'></a>

## GameModelExt.AddTowerToGame(this GameModel, TowerModel, TowerDetailsModel) Method

Add a TowerModel to the game.  
<br/>  
Using this method is preferable than modifying the GameModel's towers list manually, as this does more things  
to more fully integrate the tower within the game

```csharp
public static void AddTowerToGame(this Assets.Scripts.Models.GameModel model, Assets.Scripts.Models.Towers.TowerModel towerModel, Assets.Scripts.Models.TowerSets.TowerDetailsModel towerDetailsModel=null);
```
#### Parameters

<a name='BTD_Mod_Helper.Extensions.GameModelExt.AddTowerToGame(thisAssets.Scripts.Models.GameModel,Assets.Scripts.Models.Towers.TowerModel,Assets.Scripts.Models.TowerSets.TowerDetailsModel).model'></a>

`model` [Assets.Scripts.Models.GameModel](https://docs.microsoft.com/en-us/dotnet/api/Assets.Scripts.Models.GameModel 'Assets.Scripts.Models.GameModel')

the GameModel instance

<a name='BTD_Mod_Helper.Extensions.GameModelExt.AddTowerToGame(thisAssets.Scripts.Models.GameModel,Assets.Scripts.Models.Towers.TowerModel,Assets.Scripts.Models.TowerSets.TowerDetailsModel).towerModel'></a>

`towerModel` [Assets.Scripts.Models.Towers.TowerModel](https://docs.microsoft.com/en-us/dotnet/api/Assets.Scripts.Models.Towers.TowerModel 'Assets.Scripts.Models.Towers.TowerModel')

TowerModel to add

<a name='BTD_Mod_Helper.Extensions.GameModelExt.AddTowerToGame(thisAssets.Scripts.Models.GameModel,Assets.Scripts.Models.Towers.TowerModel,Assets.Scripts.Models.TowerSets.TowerDetailsModel).towerDetailsModel'></a>

`towerDetailsModel` [Assets.Scripts.Models.TowerSets.TowerDetailsModel](https://docs.microsoft.com/en-us/dotnet/api/Assets.Scripts.Models.TowerSets.TowerDetailsModel 'Assets.Scripts.Models.TowerSets.TowerDetailsModel')

Optionally add a TowerDetailsModel for your towerModel

<a name='BTD_Mod_Helper.Extensions.GameModelExt.AddUpgrade(thisAssets.Scripts.Models.GameModel,Assets.Scripts.Models.Towers.Upgrades.UpgradeModel)'></a>

## GameModelExt.AddUpgrade(this GameModel, UpgradeModel) Method

Fully adds an UpgradeModel to the GameModel

```csharp
public static void AddUpgrade(this Assets.Scripts.Models.GameModel model, Assets.Scripts.Models.Towers.Upgrades.UpgradeModel upgradeModel);
```
#### Parameters

<a name='BTD_Mod_Helper.Extensions.GameModelExt.AddUpgrade(thisAssets.Scripts.Models.GameModel,Assets.Scripts.Models.Towers.Upgrades.UpgradeModel).model'></a>

`model` [Assets.Scripts.Models.GameModel](https://docs.microsoft.com/en-us/dotnet/api/Assets.Scripts.Models.GameModel 'Assets.Scripts.Models.GameModel')

<a name='BTD_Mod_Helper.Extensions.GameModelExt.AddUpgrade(thisAssets.Scripts.Models.GameModel,Assets.Scripts.Models.Towers.Upgrades.UpgradeModel).upgradeModel'></a>

`upgradeModel` [Assets.Scripts.Models.Towers.Upgrades.UpgradeModel](https://docs.microsoft.com/en-us/dotnet/api/Assets.Scripts.Models.Towers.Upgrades.UpgradeModel 'Assets.Scripts.Models.Towers.Upgrades.UpgradeModel')

<a name='BTD_Mod_Helper.Extensions.GameModelExt.AddUpgrades(thisAssets.Scripts.Models.GameModel,Assets.Scripts.Models.Towers.Upgrades.UpgradeModel[])'></a>

## GameModelExt.AddUpgrades(this GameModel, UpgradeModel[]) Method

Fully adds multiple UpgradeModels to the GameModel

```csharp
public static void AddUpgrades(this Assets.Scripts.Models.GameModel model, Assets.Scripts.Models.Towers.Upgrades.UpgradeModel[] upgradeModels);
```
#### Parameters

<a name='BTD_Mod_Helper.Extensions.GameModelExt.AddUpgrades(thisAssets.Scripts.Models.GameModel,Assets.Scripts.Models.Towers.Upgrades.UpgradeModel[]).model'></a>

`model` [Assets.Scripts.Models.GameModel](https://docs.microsoft.com/en-us/dotnet/api/Assets.Scripts.Models.GameModel 'Assets.Scripts.Models.GameModel')

<a name='BTD_Mod_Helper.Extensions.GameModelExt.AddUpgrades(thisAssets.Scripts.Models.GameModel,Assets.Scripts.Models.Towers.Upgrades.UpgradeModel[]).upgradeModels'></a>

`upgradeModels` [Assets.Scripts.Models.Towers.Upgrades.UpgradeModel](https://docs.microsoft.com/en-us/dotnet/api/Assets.Scripts.Models.Towers.Upgrades.UpgradeModel 'Assets.Scripts.Models.Towers.Upgrades.UpgradeModel')[[]](https://docs.microsoft.com/en-us/dotnet/api/System.Array 'System.Array')

<a name='BTD_Mod_Helper.Extensions.GameModelExt.AddUpgrades(thisAssets.Scripts.Models.GameModel,System.Collections.Generic.List_Assets.Scripts.Models.Towers.Upgrades.UpgradeModel_)'></a>

## GameModelExt.AddUpgrades(this GameModel, List<UpgradeModel>) Method

Fully adds multiple UpgradeModels to the GameModel

```csharp
public static void AddUpgrades(this Assets.Scripts.Models.GameModel model, System.Collections.Generic.List<Assets.Scripts.Models.Towers.Upgrades.UpgradeModel> upgradeModels);
```
#### Parameters

<a name='BTD_Mod_Helper.Extensions.GameModelExt.AddUpgrades(thisAssets.Scripts.Models.GameModel,System.Collections.Generic.List_Assets.Scripts.Models.Towers.Upgrades.UpgradeModel_).model'></a>

`model` [Assets.Scripts.Models.GameModel](https://docs.microsoft.com/en-us/dotnet/api/Assets.Scripts.Models.GameModel 'Assets.Scripts.Models.GameModel')

<a name='BTD_Mod_Helper.Extensions.GameModelExt.AddUpgrades(thisAssets.Scripts.Models.GameModel,System.Collections.Generic.List_Assets.Scripts.Models.Towers.Upgrades.UpgradeModel_).upgradeModels'></a>

`upgradeModels` [System.Collections.Generic.List&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.List-1 'System.Collections.Generic.List`1')[Assets.Scripts.Models.Towers.Upgrades.UpgradeModel](https://docs.microsoft.com/en-us/dotnet/api/Assets.Scripts.Models.Towers.Upgrades.UpgradeModel 'Assets.Scripts.Models.Towers.Upgrades.UpgradeModel')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.List-1 'System.Collections.Generic.List`1')

<a name='BTD_Mod_Helper.Extensions.GameModelExt.CreateBloonEmission(thisAssets.Scripts.Models.GameModel,string,float)'></a>

## GameModelExt.CreateBloonEmission(this GameModel, string, float) Method

Create a single BloonEmission

```csharp
public static Assets.Scripts.Models.Rounds.BloonEmissionModel CreateBloonEmission(this Assets.Scripts.Models.GameModel model, string bloonName, float time);
```
#### Parameters

<a name='BTD_Mod_Helper.Extensions.GameModelExt.CreateBloonEmission(thisAssets.Scripts.Models.GameModel,string,float).model'></a>

`model` [Assets.Scripts.Models.GameModel](https://docs.microsoft.com/en-us/dotnet/api/Assets.Scripts.Models.GameModel 'Assets.Scripts.Models.GameModel')

the GameModel instance

<a name='BTD_Mod_Helper.Extensions.GameModelExt.CreateBloonEmission(thisAssets.Scripts.Models.GameModel,string,float).bloonName'></a>

`bloonName` [System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')

Name of this bloon. Example: "Red"

<a name='BTD_Mod_Helper.Extensions.GameModelExt.CreateBloonEmission(thisAssets.Scripts.Models.GameModel,string,float).time'></a>

`time` [System.Single](https://docs.microsoft.com/en-us/dotnet/api/System.Single 'System.Single')

Time the bloon should be spawned

#### Returns
[Assets.Scripts.Models.Rounds.BloonEmissionModel](https://docs.microsoft.com/en-us/dotnet/api/Assets.Scripts.Models.Rounds.BloonEmissionModel 'Assets.Scripts.Models.Rounds.BloonEmissionModel')

<a name='BTD_Mod_Helper.Extensions.GameModelExt.CreateBloonEmissions(thisAssets.Scripts.Models.GameModel,Assets.Scripts.Models.Bloons.BloonModel,int,float)'></a>

## GameModelExt.CreateBloonEmissions(this GameModel, BloonModel, int, float) Method

Create a BloonEmissionModel from a bloonModel

```csharp
public static UnhollowerBaseLib.Il2CppReferenceArray<Assets.Scripts.Models.Rounds.BloonEmissionModel> CreateBloonEmissions(this Assets.Scripts.Models.GameModel model, Assets.Scripts.Models.Bloons.BloonModel bloonModel, int number, float spacing);
```
#### Parameters

<a name='BTD_Mod_Helper.Extensions.GameModelExt.CreateBloonEmissions(thisAssets.Scripts.Models.GameModel,Assets.Scripts.Models.Bloons.BloonModel,int,float).model'></a>

`model` [Assets.Scripts.Models.GameModel](https://docs.microsoft.com/en-us/dotnet/api/Assets.Scripts.Models.GameModel 'Assets.Scripts.Models.GameModel')

the GameModel instance

<a name='BTD_Mod_Helper.Extensions.GameModelExt.CreateBloonEmissions(thisAssets.Scripts.Models.GameModel,Assets.Scripts.Models.Bloons.BloonModel,int,float).bloonModel'></a>

`bloonModel` [Assets.Scripts.Models.Bloons.BloonModel](https://docs.microsoft.com/en-us/dotnet/api/Assets.Scripts.Models.Bloons.BloonModel 'Assets.Scripts.Models.Bloons.BloonModel')

The bloon model that these bloons should be

<a name='BTD_Mod_Helper.Extensions.GameModelExt.CreateBloonEmissions(thisAssets.Scripts.Models.GameModel,Assets.Scripts.Models.Bloons.BloonModel,int,float).number'></a>

`number` [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/System.Int32 'System.Int32')

Number of Bloons in this emission

<a name='BTD_Mod_Helper.Extensions.GameModelExt.CreateBloonEmissions(thisAssets.Scripts.Models.GameModel,Assets.Scripts.Models.Bloons.BloonModel,int,float).spacing'></a>

`spacing` [System.Single](https://docs.microsoft.com/en-us/dotnet/api/System.Single 'System.Single')

Space between each bloon in this emission

#### Returns
[UnhollowerBaseLib.Il2CppReferenceArray&lt;](https://docs.microsoft.com/en-us/dotnet/api/UnhollowerBaseLib.Il2CppReferenceArray-1 'UnhollowerBaseLib.Il2CppReferenceArray`1')[Assets.Scripts.Models.Rounds.BloonEmissionModel](https://docs.microsoft.com/en-us/dotnet/api/Assets.Scripts.Models.Rounds.BloonEmissionModel 'Assets.Scripts.Models.Rounds.BloonEmissionModel')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/UnhollowerBaseLib.Il2CppReferenceArray-1 'UnhollowerBaseLib.Il2CppReferenceArray`1')

<a name='BTD_Mod_Helper.Extensions.GameModelExt.CreateBloonEmissions(thisAssets.Scripts.Models.GameModel,string,int,float)'></a>

## GameModelExt.CreateBloonEmissions(this GameModel, string, int, float) Method

Create a BloonEmissionModel from a bloon's name

```csharp
public static UnhollowerBaseLib.Il2CppReferenceArray<Assets.Scripts.Models.Rounds.BloonEmissionModel> CreateBloonEmissions(this Assets.Scripts.Models.GameModel model, string bloonName, int number, float spacing);
```
#### Parameters

<a name='BTD_Mod_Helper.Extensions.GameModelExt.CreateBloonEmissions(thisAssets.Scripts.Models.GameModel,string,int,float).model'></a>

`model` [Assets.Scripts.Models.GameModel](https://docs.microsoft.com/en-us/dotnet/api/Assets.Scripts.Models.GameModel 'Assets.Scripts.Models.GameModel')

the GameModel instance

<a name='BTD_Mod_Helper.Extensions.GameModelExt.CreateBloonEmissions(thisAssets.Scripts.Models.GameModel,string,int,float).bloonName'></a>

`bloonName` [System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')

Name of bloon. Example: "Red"

<a name='BTD_Mod_Helper.Extensions.GameModelExt.CreateBloonEmissions(thisAssets.Scripts.Models.GameModel,string,int,float).number'></a>

`number` [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/System.Int32 'System.Int32')

Number of Bloons in this emission

<a name='BTD_Mod_Helper.Extensions.GameModelExt.CreateBloonEmissions(thisAssets.Scripts.Models.GameModel,string,int,float).spacing'></a>

`spacing` [System.Single](https://docs.microsoft.com/en-us/dotnet/api/System.Single 'System.Single')

Space between each bloon in this emission

#### Returns
[UnhollowerBaseLib.Il2CppReferenceArray&lt;](https://docs.microsoft.com/en-us/dotnet/api/UnhollowerBaseLib.Il2CppReferenceArray-1 'UnhollowerBaseLib.Il2CppReferenceArray`1')[Assets.Scripts.Models.Rounds.BloonEmissionModel](https://docs.microsoft.com/en-us/dotnet/api/Assets.Scripts.Models.Rounds.BloonEmissionModel 'Assets.Scripts.Models.Rounds.BloonEmissionModel')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/UnhollowerBaseLib.Il2CppReferenceArray-1 'UnhollowerBaseLib.Il2CppReferenceArray`1')

<a name='BTD_Mod_Helper.Extensions.GameModelExt.CreateBloonGroup(thisAssets.Scripts.Models.GameModel,string,float,float,int)'></a>

## GameModelExt.CreateBloonGroup(this GameModel, string, float, float, int) Method

Creates a BloonGroup

```csharp
public static Assets.Scripts.Models.Rounds.BloonGroupModel CreateBloonGroup(this Assets.Scripts.Models.GameModel model, string bloonName, float startTime, float spacing, int count);
```
#### Parameters

<a name='BTD_Mod_Helper.Extensions.GameModelExt.CreateBloonGroup(thisAssets.Scripts.Models.GameModel,string,float,float,int).model'></a>

`model` [Assets.Scripts.Models.GameModel](https://docs.microsoft.com/en-us/dotnet/api/Assets.Scripts.Models.GameModel 'Assets.Scripts.Models.GameModel')

<a name='BTD_Mod_Helper.Extensions.GameModelExt.CreateBloonGroup(thisAssets.Scripts.Models.GameModel,string,float,float,int).bloonName'></a>

`bloonName` [System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')

<a name='BTD_Mod_Helper.Extensions.GameModelExt.CreateBloonGroup(thisAssets.Scripts.Models.GameModel,string,float,float,int).startTime'></a>

`startTime` [System.Single](https://docs.microsoft.com/en-us/dotnet/api/System.Single 'System.Single')

<a name='BTD_Mod_Helper.Extensions.GameModelExt.CreateBloonGroup(thisAssets.Scripts.Models.GameModel,string,float,float,int).spacing'></a>

`spacing` [System.Single](https://docs.microsoft.com/en-us/dotnet/api/System.Single 'System.Single')

<a name='BTD_Mod_Helper.Extensions.GameModelExt.CreateBloonGroup(thisAssets.Scripts.Models.GameModel,string,float,float,int).count'></a>

`count` [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/System.Int32 'System.Int32')

#### Returns
[Assets.Scripts.Models.Rounds.BloonGroupModel](https://docs.microsoft.com/en-us/dotnet/api/Assets.Scripts.Models.Rounds.BloonGroupModel 'Assets.Scripts.Models.Rounds.BloonGroupModel')

<a name='BTD_Mod_Helper.Extensions.GameModelExt.DoesBloonExist(thisAssets.Scripts.Models.GameModel,string)'></a>

## GameModelExt.DoesBloonExist(this GameModel, string) Method

Returns whether or not a bloon exists with this name

```csharp
public static bool DoesBloonExist(this Assets.Scripts.Models.GameModel gameModel, string bloonName);
```
#### Parameters

<a name='BTD_Mod_Helper.Extensions.GameModelExt.DoesBloonExist(thisAssets.Scripts.Models.GameModel,string).gameModel'></a>

`gameModel` [Assets.Scripts.Models.GameModel](https://docs.microsoft.com/en-us/dotnet/api/Assets.Scripts.Models.GameModel 'Assets.Scripts.Models.GameModel')

<a name='BTD_Mod_Helper.Extensions.GameModelExt.DoesBloonExist(thisAssets.Scripts.Models.GameModel,string).bloonName'></a>

`bloonName` [System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')

#### Returns
[System.Boolean](https://docs.microsoft.com/en-us/dotnet/api/System.Boolean 'System.Boolean')

<a name='BTD_Mod_Helper.Extensions.GameModelExt.DoesTowerDetailsExist(thisAssets.Scripts.Models.GameModel,string)'></a>

## GameModelExt.DoesTowerDetailsExist(this GameModel, string) Method

Returns whether or not any TowerDetailsModels in [Assets.Scripts.Models.GameModel.towerSet](https://docs.microsoft.com/en-us/dotnet/api/Assets.Scripts.Models.GameModel.towerSet 'Assets.Scripts.Models.GameModel.towerSet') have [towerId](BTD_Mod_Helper.Extensions.GameModelExt.md#BTD_Mod_Helper.Extensions.GameModelExt.DoesTowerDetailsExist(thisAssets.Scripts.Models.GameModel,string).towerId 'BTD_Mod_Helper.Extensions.GameModelExt.DoesTowerDetailsExist(this Assets.Scripts.Models.GameModel, string).towerId')  
in it's name

```csharp
public static bool DoesTowerDetailsExist(this Assets.Scripts.Models.GameModel model, string towerId);
```
#### Parameters

<a name='BTD_Mod_Helper.Extensions.GameModelExt.DoesTowerDetailsExist(thisAssets.Scripts.Models.GameModel,string).model'></a>

`model` [Assets.Scripts.Models.GameModel](https://docs.microsoft.com/en-us/dotnet/api/Assets.Scripts.Models.GameModel 'Assets.Scripts.Models.GameModel')

<a name='BTD_Mod_Helper.Extensions.GameModelExt.DoesTowerDetailsExist(thisAssets.Scripts.Models.GameModel,string).towerId'></a>

`towerId` [System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')

#### Returns
[System.Boolean](https://docs.microsoft.com/en-us/dotnet/api/System.Boolean 'System.Boolean')

<a name='BTD_Mod_Helper.Extensions.GameModelExt.DoesTowerModelExist(thisAssets.Scripts.Models.GameModel,string)'></a>

## GameModelExt.DoesTowerModelExist(this GameModel, string) Method

Returns whether or not any TowerModels in [Assets.Scripts.Models.GameModel.towers](https://docs.microsoft.com/en-us/dotnet/api/Assets.Scripts.Models.GameModel.towers 'Assets.Scripts.Models.GameModel.towers') have [towerId](BTD_Mod_Helper.Extensions.GameModelExt.md#BTD_Mod_Helper.Extensions.GameModelExt.DoesTowerModelExist(thisAssets.Scripts.Models.GameModel,string).towerId 'BTD_Mod_Helper.Extensions.GameModelExt.DoesTowerModelExist(this Assets.Scripts.Models.GameModel, string).towerId')  
in it's name

```csharp
public static bool DoesTowerModelExist(this Assets.Scripts.Models.GameModel model, string towerId);
```
#### Parameters

<a name='BTD_Mod_Helper.Extensions.GameModelExt.DoesTowerModelExist(thisAssets.Scripts.Models.GameModel,string).model'></a>

`model` [Assets.Scripts.Models.GameModel](https://docs.microsoft.com/en-us/dotnet/api/Assets.Scripts.Models.GameModel 'Assets.Scripts.Models.GameModel')

<a name='BTD_Mod_Helper.Extensions.GameModelExt.DoesTowerModelExist(thisAssets.Scripts.Models.GameModel,string).towerId'></a>

`towerId` [System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')

#### Returns
[System.Boolean](https://docs.microsoft.com/en-us/dotnet/api/System.Boolean 'System.Boolean')

<a name='BTD_Mod_Helper.Extensions.GameModelExt.GetAllAbilityModels(thisAssets.Scripts.Models.GameModel)'></a>

## GameModelExt.GetAllAbilityModels(this GameModel) Method

Return all AbilityModels from every TowerModel in the game

```csharp
public static System.Collections.Generic.List<Assets.Scripts.Models.Towers.Behaviors.Abilities.AbilityModel> GetAllAbilityModels(this Assets.Scripts.Models.GameModel model);
```
#### Parameters

<a name='BTD_Mod_Helper.Extensions.GameModelExt.GetAllAbilityModels(thisAssets.Scripts.Models.GameModel).model'></a>

`model` [Assets.Scripts.Models.GameModel](https://docs.microsoft.com/en-us/dotnet/api/Assets.Scripts.Models.GameModel 'Assets.Scripts.Models.GameModel')

#### Returns
[System.Collections.Generic.List&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.List-1 'System.Collections.Generic.List`1')[Assets.Scripts.Models.Towers.Behaviors.Abilities.AbilityModel](https://docs.microsoft.com/en-us/dotnet/api/Assets.Scripts.Models.Towers.Behaviors.Abilities.AbilityModel 'Assets.Scripts.Models.Towers.Behaviors.Abilities.AbilityModel')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.List-1 'System.Collections.Generic.List`1')

<a name='BTD_Mod_Helper.Extensions.GameModelExt.GetAllAttackModels(thisAssets.Scripts.Models.GameModel)'></a>

## GameModelExt.GetAllAttackModels(this GameModel) Method

Return all AttackModels from every TowerModel in the game

```csharp
public static System.Collections.Generic.List<Assets.Scripts.Models.Towers.Behaviors.Attack.AttackModel> GetAllAttackModels(this Assets.Scripts.Models.GameModel model);
```
#### Parameters

<a name='BTD_Mod_Helper.Extensions.GameModelExt.GetAllAttackModels(thisAssets.Scripts.Models.GameModel).model'></a>

`model` [Assets.Scripts.Models.GameModel](https://docs.microsoft.com/en-us/dotnet/api/Assets.Scripts.Models.GameModel 'Assets.Scripts.Models.GameModel')

#### Returns
[System.Collections.Generic.List&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.List-1 'System.Collections.Generic.List`1')[Assets.Scripts.Models.Towers.Behaviors.Attack.AttackModel](https://docs.microsoft.com/en-us/dotnet/api/Assets.Scripts.Models.Towers.Behaviors.Attack.AttackModel 'Assets.Scripts.Models.Towers.Behaviors.Attack.AttackModel')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.List-1 'System.Collections.Generic.List`1')

<a name='BTD_Mod_Helper.Extensions.GameModelExt.GetAllProjectileModels(thisAssets.Scripts.Models.GameModel)'></a>

## GameModelExt.GetAllProjectileModels(this GameModel) Method

Return all ProjectileModels from every TowerModel in the game

```csharp
public static System.Collections.Generic.List<Assets.Scripts.Models.Towers.Projectiles.ProjectileModel> GetAllProjectileModels(this Assets.Scripts.Models.GameModel model);
```
#### Parameters

<a name='BTD_Mod_Helper.Extensions.GameModelExt.GetAllProjectileModels(thisAssets.Scripts.Models.GameModel).model'></a>

`model` [Assets.Scripts.Models.GameModel](https://docs.microsoft.com/en-us/dotnet/api/Assets.Scripts.Models.GameModel 'Assets.Scripts.Models.GameModel')

#### Returns
[System.Collections.Generic.List&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.List-1 'System.Collections.Generic.List`1')[Assets.Scripts.Models.Towers.Projectiles.ProjectileModel](https://docs.microsoft.com/en-us/dotnet/api/Assets.Scripts.Models.Towers.Projectiles.ProjectileModel 'Assets.Scripts.Models.Towers.Projectiles.ProjectileModel')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.List-1 'System.Collections.Generic.List`1')

<a name='BTD_Mod_Helper.Extensions.GameModelExt.GetAllShopTowerDetails(thisAssets.Scripts.Models.GameModel)'></a>

## GameModelExt.GetAllShopTowerDetails(this GameModel) Method

Return all ShopTowerDetailModels

```csharp
public static Il2CppSystem.Collections.Generic.List<Assets.Scripts.Models.TowerSets.ShopTowerDetailsModel> GetAllShopTowerDetails(this Assets.Scripts.Models.GameModel model);
```
#### Parameters

<a name='BTD_Mod_Helper.Extensions.GameModelExt.GetAllShopTowerDetails(thisAssets.Scripts.Models.GameModel).model'></a>

`model` [Assets.Scripts.Models.GameModel](https://docs.microsoft.com/en-us/dotnet/api/Assets.Scripts.Models.GameModel 'Assets.Scripts.Models.GameModel')

#### Returns
[Il2CppSystem.Collections.Generic.List&lt;](https://docs.microsoft.com/en-us/dotnet/api/Il2CppSystem.Collections.Generic.List-1 'Il2CppSystem.Collections.Generic.List`1')[Assets.Scripts.Models.TowerSets.ShopTowerDetailsModel](https://docs.microsoft.com/en-us/dotnet/api/Assets.Scripts.Models.TowerSets.ShopTowerDetailsModel 'Assets.Scripts.Models.TowerSets.ShopTowerDetailsModel')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/Il2CppSystem.Collections.Generic.List-1 'Il2CppSystem.Collections.Generic.List`1')

<a name='BTD_Mod_Helper.Extensions.GameModelExt.GetAllTowerDetails(thisAssets.Scripts.Models.GameModel)'></a>

## GameModelExt.GetAllTowerDetails(this GameModel) Method

Return all TowerDetailModels

```csharp
public static Il2CppSystem.Collections.Generic.List<Assets.Scripts.Models.TowerSets.TowerDetailsModel> GetAllTowerDetails(this Assets.Scripts.Models.GameModel model);
```
#### Parameters

<a name='BTD_Mod_Helper.Extensions.GameModelExt.GetAllTowerDetails(thisAssets.Scripts.Models.GameModel).model'></a>

`model` [Assets.Scripts.Models.GameModel](https://docs.microsoft.com/en-us/dotnet/api/Assets.Scripts.Models.GameModel 'Assets.Scripts.Models.GameModel')

#### Returns
[Il2CppSystem.Collections.Generic.List&lt;](https://docs.microsoft.com/en-us/dotnet/api/Il2CppSystem.Collections.Generic.List-1 'Il2CppSystem.Collections.Generic.List`1')[Assets.Scripts.Models.TowerSets.TowerDetailsModel](https://docs.microsoft.com/en-us/dotnet/api/Assets.Scripts.Models.TowerSets.TowerDetailsModel 'Assets.Scripts.Models.TowerSets.TowerDetailsModel')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/Il2CppSystem.Collections.Generic.List-1 'Il2CppSystem.Collections.Generic.List`1')

<a name='BTD_Mod_Helper.Extensions.GameModelExt.GetAllWeaponModels(thisAssets.Scripts.Models.GameModel)'></a>

## GameModelExt.GetAllWeaponModels(this GameModel) Method

Return all WeaponModels from every AttackModel in the game

```csharp
public static System.Collections.Generic.List<Assets.Scripts.Models.Towers.Weapons.WeaponModel> GetAllWeaponModels(this Assets.Scripts.Models.GameModel model);
```
#### Parameters

<a name='BTD_Mod_Helper.Extensions.GameModelExt.GetAllWeaponModels(thisAssets.Scripts.Models.GameModel).model'></a>

`model` [Assets.Scripts.Models.GameModel](https://docs.microsoft.com/en-us/dotnet/api/Assets.Scripts.Models.GameModel 'Assets.Scripts.Models.GameModel')

#### Returns
[System.Collections.Generic.List&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.List-1 'System.Collections.Generic.List`1')[Assets.Scripts.Models.Towers.Weapons.WeaponModel](https://docs.microsoft.com/en-us/dotnet/api/Assets.Scripts.Models.Towers.Weapons.WeaponModel 'Assets.Scripts.Models.Towers.Weapons.WeaponModel')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.List-1 'System.Collections.Generic.List`1')

<a name='BTD_Mod_Helper.Extensions.GameModelExt.GetTowerDetails(thisAssets.Scripts.Models.GameModel,string)'></a>

## GameModelExt.GetTowerDetails(this GameModel, string) Method

Returns the first TowerDetailsModel in [Assets.Scripts.Models.GameModel.towerSet](https://docs.microsoft.com/en-us/dotnet/api/Assets.Scripts.Models.GameModel.towerSet 'Assets.Scripts.Models.GameModel.towerSet') that has a towerId of  
[towerDetailsName](BTD_Mod_Helper.Extensions.GameModelExt.md#BTD_Mod_Helper.Extensions.GameModelExt.GetTowerDetails(thisAssets.Scripts.Models.GameModel,string).towerDetailsName 'BTD_Mod_Helper.Extensions.GameModelExt.GetTowerDetails(this Assets.Scripts.Models.GameModel, string).towerDetailsName')

```csharp
public static Assets.Scripts.Models.TowerSets.TowerDetailsModel GetTowerDetails(this Assets.Scripts.Models.GameModel model, string towerDetailsName);
```
#### Parameters

<a name='BTD_Mod_Helper.Extensions.GameModelExt.GetTowerDetails(thisAssets.Scripts.Models.GameModel,string).model'></a>

`model` [Assets.Scripts.Models.GameModel](https://docs.microsoft.com/en-us/dotnet/api/Assets.Scripts.Models.GameModel 'Assets.Scripts.Models.GameModel')

<a name='BTD_Mod_Helper.Extensions.GameModelExt.GetTowerDetails(thisAssets.Scripts.Models.GameModel,string).towerDetailsName'></a>

`towerDetailsName` [System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')

The [Assets.Scripts.Models.TowerSets.TowerDetailsModel.towerId](https://docs.microsoft.com/en-us/dotnet/api/Assets.Scripts.Models.TowerSets.TowerDetailsModel.towerId 'Assets.Scripts.Models.TowerSets.TowerDetailsModel.towerId') you are searching for

#### Returns
[Assets.Scripts.Models.TowerSets.TowerDetailsModel](https://docs.microsoft.com/en-us/dotnet/api/Assets.Scripts.Models.TowerSets.TowerDetailsModel 'Assets.Scripts.Models.TowerSets.TowerDetailsModel')  
The first TowerDetailsModel found, otherwise returns null

<a name='BTD_Mod_Helper.Extensions.GameModelExt.GetTowerModel(thisAssets.Scripts.Models.GameModel,string,int,int,int)'></a>

## GameModelExt.GetTowerModel(this GameModel, string, int, int, int) Method

Get a TowerModel from model.towers.  
NOTE: model.GetTower cannot get custom towers so use this method instead

```csharp
public static Assets.Scripts.Models.Towers.TowerModel GetTowerModel(this Assets.Scripts.Models.GameModel model, string towerId, int path1=0, int path2=0, int path3=0);
```
#### Parameters

<a name='BTD_Mod_Helper.Extensions.GameModelExt.GetTowerModel(thisAssets.Scripts.Models.GameModel,string,int,int,int).model'></a>

`model` [Assets.Scripts.Models.GameModel](https://docs.microsoft.com/en-us/dotnet/api/Assets.Scripts.Models.GameModel 'Assets.Scripts.Models.GameModel')

<a name='BTD_Mod_Helper.Extensions.GameModelExt.GetTowerModel(thisAssets.Scripts.Models.GameModel,string,int,int,int).towerId'></a>

`towerId` [System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')

<a name='BTD_Mod_Helper.Extensions.GameModelExt.GetTowerModel(thisAssets.Scripts.Models.GameModel,string,int,int,int).path1'></a>

`path1` [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/System.Int32 'System.Int32')

<a name='BTD_Mod_Helper.Extensions.GameModelExt.GetTowerModel(thisAssets.Scripts.Models.GameModel,string,int,int,int).path2'></a>

`path2` [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/System.Int32 'System.Int32')

<a name='BTD_Mod_Helper.Extensions.GameModelExt.GetTowerModel(thisAssets.Scripts.Models.GameModel,string,int,int,int).path3'></a>

`path3` [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/System.Int32 'System.Int32')

#### Returns
[Assets.Scripts.Models.Towers.TowerModel](https://docs.microsoft.com/en-us/dotnet/api/Assets.Scripts.Models.Towers.TowerModel 'Assets.Scripts.Models.Towers.TowerModel')

<a name='BTD_Mod_Helper.Extensions.GameModelExt.GetTowerModels(thisAssets.Scripts.Models.GameModel,string)'></a>

## GameModelExt.GetTowerModels(this GameModel, string) Method

Return all TowerModels with a specific base id

```csharp
public static System.Collections.Generic.List<Assets.Scripts.Models.Towers.TowerModel> GetTowerModels(this Assets.Scripts.Models.GameModel model, string towerBaseId);
```
#### Parameters

<a name='BTD_Mod_Helper.Extensions.GameModelExt.GetTowerModels(thisAssets.Scripts.Models.GameModel,string).model'></a>

`model` [Assets.Scripts.Models.GameModel](https://docs.microsoft.com/en-us/dotnet/api/Assets.Scripts.Models.GameModel 'Assets.Scripts.Models.GameModel')

the GameModel instance

<a name='BTD_Mod_Helper.Extensions.GameModelExt.GetTowerModels(thisAssets.Scripts.Models.GameModel,string).towerBaseId'></a>

`towerBaseId` [System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')

The base id all towers should share. Example: "DartMonkey"

#### Returns
[System.Collections.Generic.List&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.List-1 'System.Collections.Generic.List`1')[Assets.Scripts.Models.Towers.TowerModel](https://docs.microsoft.com/en-us/dotnet/api/Assets.Scripts.Models.Towers.TowerModel 'Assets.Scripts.Models.Towers.TowerModel')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.List-1 'System.Collections.Generic.List`1')

<a name='BTD_Mod_Helper.Extensions.GameModelExt.GetTowerModelsWithAbilities(thisAssets.Scripts.Models.GameModel)'></a>

## GameModelExt.GetTowerModelsWithAbilities(this GameModel) Method

Return all TowerModels that have at least one AbilityModel

```csharp
public static System.Collections.Generic.List<Assets.Scripts.Models.Towers.TowerModel> GetTowerModelsWithAbilities(this Assets.Scripts.Models.GameModel model);
```
#### Parameters

<a name='BTD_Mod_Helper.Extensions.GameModelExt.GetTowerModelsWithAbilities(thisAssets.Scripts.Models.GameModel).model'></a>

`model` [Assets.Scripts.Models.GameModel](https://docs.microsoft.com/en-us/dotnet/api/Assets.Scripts.Models.GameModel 'Assets.Scripts.Models.GameModel')

#### Returns
[System.Collections.Generic.List&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.List-1 'System.Collections.Generic.List`1')[Assets.Scripts.Models.Towers.TowerModel](https://docs.microsoft.com/en-us/dotnet/api/Assets.Scripts.Models.Towers.TowerModel 'Assets.Scripts.Models.Towers.TowerModel')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.List-1 'System.Collections.Generic.List`1')