#### [BloonsTD6 Mod Helper](README.md 'README')
### [BTD_Mod_Helper.Extensions](README.md#BTD_Mod_Helper.Extensions 'BTD_Mod_Helper.Extensions')

## GameModelExt Class

Extensions for the GameModel

```csharp
public static class GameModelExt
```

Inheritance [System.Object](https://docs.microsoft.com/en-us/dotnet/api/System.Object 'System.Object') &#129106; GameModelExt
### Methods

<a name='BTD_Mod_Helper.Extensions.GameModelExt.AddHeroDetails(thisGameModel,HeroDetailsModel,int)'></a>

## GameModelExt.AddHeroDetails(this GameModel, HeroDetailsModel, int) Method

Adds a HeroDetailsModel to the GameModel's HeroSet at a particular index

```csharp
public static void AddHeroDetails(this GameModel model, HeroDetailsModel heroDetailsModel, int index);
```
#### Parameters

<a name='BTD_Mod_Helper.Extensions.GameModelExt.AddHeroDetails(thisGameModel,HeroDetailsModel,int).model'></a>

`model` [Il2CppAssets.Scripts.Models.GameModel](https://docs.microsoft.com/en-us/dotnet/api/Il2CppAssets.Scripts.Models.GameModel 'Il2CppAssets.Scripts.Models.GameModel')

<a name='BTD_Mod_Helper.Extensions.GameModelExt.AddHeroDetails(thisGameModel,HeroDetailsModel,int).heroDetailsModel'></a>

`heroDetailsModel` [Il2CppAssets.Scripts.Models.TowerSets.HeroDetailsModel](https://docs.microsoft.com/en-us/dotnet/api/Il2CppAssets.Scripts.Models.TowerSets.HeroDetailsModel 'Il2CppAssets.Scripts.Models.TowerSets.HeroDetailsModel')

<a name='BTD_Mod_Helper.Extensions.GameModelExt.AddHeroDetails(thisGameModel,HeroDetailsModel,int).index'></a>

`index` [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/System.Int32 'System.Int32')

<a name='BTD_Mod_Helper.Extensions.GameModelExt.AddTowerDetails(thisGameModel,TowerDetailsModel,int)'></a>

## GameModelExt.AddTowerDetails(this GameModel, TowerDetailsModel, int) Method

Adds a TowerDetailsModel to the GameModel's TowerSet at a particular index

```csharp
public static void AddTowerDetails(this GameModel model, TowerDetailsModel towerDetailsModel, int index);
```
#### Parameters

<a name='BTD_Mod_Helper.Extensions.GameModelExt.AddTowerDetails(thisGameModel,TowerDetailsModel,int).model'></a>

`model` [Il2CppAssets.Scripts.Models.GameModel](https://docs.microsoft.com/en-us/dotnet/api/Il2CppAssets.Scripts.Models.GameModel 'Il2CppAssets.Scripts.Models.GameModel')

<a name='BTD_Mod_Helper.Extensions.GameModelExt.AddTowerDetails(thisGameModel,TowerDetailsModel,int).towerDetailsModel'></a>

`towerDetailsModel` [Il2CppAssets.Scripts.Models.TowerSets.TowerDetailsModel](https://docs.microsoft.com/en-us/dotnet/api/Il2CppAssets.Scripts.Models.TowerSets.TowerDetailsModel 'Il2CppAssets.Scripts.Models.TowerSets.TowerDetailsModel')

<a name='BTD_Mod_Helper.Extensions.GameModelExt.AddTowerDetails(thisGameModel,TowerDetailsModel,int).index'></a>

`index` [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/System.Int32 'System.Int32')

<a name='BTD_Mod_Helper.Extensions.GameModelExt.AddTowerDetails(thisGameModel,TowerDetailsModel,TowerSet)'></a>

## GameModelExt.AddTowerDetails(this GameModel, TowerDetailsModel, TowerSet) Method

Adds a TowerDetailsModel to the GameModel's TowerSet, taking into account what set of towers it's a part of  
<br/>  
For example, a new custom Primary tower would be added right at the end of the primary towers,  
and right before the start of the military towers

```csharp
public static void AddTowerDetails(this GameModel model, TowerDetailsModel towerDetailsModel, TowerSet set);
```
#### Parameters

<a name='BTD_Mod_Helper.Extensions.GameModelExt.AddTowerDetails(thisGameModel,TowerDetailsModel,TowerSet).model'></a>

`model` [Il2CppAssets.Scripts.Models.GameModel](https://docs.microsoft.com/en-us/dotnet/api/Il2CppAssets.Scripts.Models.GameModel 'Il2CppAssets.Scripts.Models.GameModel')

The GameModel

<a name='BTD_Mod_Helper.Extensions.GameModelExt.AddTowerDetails(thisGameModel,TowerDetailsModel,TowerSet).towerDetailsModel'></a>

`towerDetailsModel` [Il2CppAssets.Scripts.Models.TowerSets.TowerDetailsModel](https://docs.microsoft.com/en-us/dotnet/api/Il2CppAssets.Scripts.Models.TowerSets.TowerDetailsModel 'Il2CppAssets.Scripts.Models.TowerSets.TowerDetailsModel')

The TowerDetailsModel to be added

<a name='BTD_Mod_Helper.Extensions.GameModelExt.AddTowerDetails(thisGameModel,TowerDetailsModel,TowerSet).set'></a>

`set` [Il2CppAssets.Scripts.Models.TowerSets.TowerSet](https://docs.microsoft.com/en-us/dotnet/api/Il2CppAssets.Scripts.Models.TowerSets.TowerSet 'Il2CppAssets.Scripts.Models.TowerSets.TowerSet')

The TowerSet of the tower to be added

<a name='BTD_Mod_Helper.Extensions.GameModelExt.AddTowerDetails(thisGameModel,TowerDetailsModel)'></a>

## GameModelExt.AddTowerDetails(this GameModel, TowerDetailsModel) Method

Adds a tower

```csharp
public static void AddTowerDetails(this GameModel model, TowerDetailsModel towerDetailsModel);
```
#### Parameters

<a name='BTD_Mod_Helper.Extensions.GameModelExt.AddTowerDetails(thisGameModel,TowerDetailsModel).model'></a>

`model` [Il2CppAssets.Scripts.Models.GameModel](https://docs.microsoft.com/en-us/dotnet/api/Il2CppAssets.Scripts.Models.GameModel 'Il2CppAssets.Scripts.Models.GameModel')

<a name='BTD_Mod_Helper.Extensions.GameModelExt.AddTowerDetails(thisGameModel,TowerDetailsModel).towerDetailsModel'></a>

`towerDetailsModel` [Il2CppAssets.Scripts.Models.TowerSets.TowerDetailsModel](https://docs.microsoft.com/en-us/dotnet/api/Il2CppAssets.Scripts.Models.TowerSets.TowerDetailsModel 'Il2CppAssets.Scripts.Models.TowerSets.TowerDetailsModel')

<a name='BTD_Mod_Helper.Extensions.GameModelExt.AddTowersToGame(thisGameModel,System.Collections.Generic.IEnumerable_TowerModel_)'></a>

## GameModelExt.AddTowersToGame(this GameModel, IEnumerable<TowerModel>) Method

Add multiple TowerModels to the game more efficiently than calling the single method repeatedly.

```csharp
public static void AddTowersToGame(this GameModel model, System.Collections.Generic.IEnumerable<TowerModel> towerModels);
```
#### Parameters

<a name='BTD_Mod_Helper.Extensions.GameModelExt.AddTowersToGame(thisGameModel,System.Collections.Generic.IEnumerable_TowerModel_).model'></a>

`model` [Il2CppAssets.Scripts.Models.GameModel](https://docs.microsoft.com/en-us/dotnet/api/Il2CppAssets.Scripts.Models.GameModel 'Il2CppAssets.Scripts.Models.GameModel')

<a name='BTD_Mod_Helper.Extensions.GameModelExt.AddTowersToGame(thisGameModel,System.Collections.Generic.IEnumerable_TowerModel_).towerModels'></a>

`towerModels` [System.Collections.Generic.IEnumerable&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.IEnumerable-1 'System.Collections.Generic.IEnumerable`1')[Il2CppAssets.Scripts.Models.Towers.TowerModel](https://docs.microsoft.com/en-us/dotnet/api/Il2CppAssets.Scripts.Models.Towers.TowerModel 'Il2CppAssets.Scripts.Models.Towers.TowerModel')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.IEnumerable-1 'System.Collections.Generic.IEnumerable`1')

<a name='BTD_Mod_Helper.Extensions.GameModelExt.AddTowerToGame(thisGameModel,TowerModel,TowerDetailsModel)'></a>

## GameModelExt.AddTowerToGame(this GameModel, TowerModel, TowerDetailsModel) Method

Add a TowerModel to the game.  
<br/>  
Using this method is preferable than modifying the GameModel's towers list manually, as this does more things  
to more fully integrate the tower within the game

```csharp
public static void AddTowerToGame(this GameModel model, TowerModel towerModel, TowerDetailsModel towerDetailsModel=null);
```
#### Parameters

<a name='BTD_Mod_Helper.Extensions.GameModelExt.AddTowerToGame(thisGameModel,TowerModel,TowerDetailsModel).model'></a>

`model` [Il2CppAssets.Scripts.Models.GameModel](https://docs.microsoft.com/en-us/dotnet/api/Il2CppAssets.Scripts.Models.GameModel 'Il2CppAssets.Scripts.Models.GameModel')

the GameModel instance

<a name='BTD_Mod_Helper.Extensions.GameModelExt.AddTowerToGame(thisGameModel,TowerModel,TowerDetailsModel).towerModel'></a>

`towerModel` [Il2CppAssets.Scripts.Models.Towers.TowerModel](https://docs.microsoft.com/en-us/dotnet/api/Il2CppAssets.Scripts.Models.Towers.TowerModel 'Il2CppAssets.Scripts.Models.Towers.TowerModel')

TowerModel to add

<a name='BTD_Mod_Helper.Extensions.GameModelExt.AddTowerToGame(thisGameModel,TowerModel,TowerDetailsModel).towerDetailsModel'></a>

`towerDetailsModel` [Il2CppAssets.Scripts.Models.TowerSets.TowerDetailsModel](https://docs.microsoft.com/en-us/dotnet/api/Il2CppAssets.Scripts.Models.TowerSets.TowerDetailsModel 'Il2CppAssets.Scripts.Models.TowerSets.TowerDetailsModel')

Optionally add a TowerDetailsModel for your towerModel

<a name='BTD_Mod_Helper.Extensions.GameModelExt.AddUpgrade(thisGameModel,UpgradeModel)'></a>

## GameModelExt.AddUpgrade(this GameModel, UpgradeModel) Method

Fully adds an UpgradeModel to the GameModel

```csharp
public static void AddUpgrade(this GameModel model, UpgradeModel upgradeModel);
```
#### Parameters

<a name='BTD_Mod_Helper.Extensions.GameModelExt.AddUpgrade(thisGameModel,UpgradeModel).model'></a>

`model` [Il2CppAssets.Scripts.Models.GameModel](https://docs.microsoft.com/en-us/dotnet/api/Il2CppAssets.Scripts.Models.GameModel 'Il2CppAssets.Scripts.Models.GameModel')

<a name='BTD_Mod_Helper.Extensions.GameModelExt.AddUpgrade(thisGameModel,UpgradeModel).upgradeModel'></a>

`upgradeModel` [Il2CppAssets.Scripts.Models.Towers.Upgrades.UpgradeModel](https://docs.microsoft.com/en-us/dotnet/api/Il2CppAssets.Scripts.Models.Towers.Upgrades.UpgradeModel 'Il2CppAssets.Scripts.Models.Towers.Upgrades.UpgradeModel')

<a name='BTD_Mod_Helper.Extensions.GameModelExt.AddUpgrades(thisGameModel,System.Collections.Generic.List_UpgradeModel_)'></a>

## GameModelExt.AddUpgrades(this GameModel, List<UpgradeModel>) Method

Fully adds multiple UpgradeModels to the GameModel

```csharp
public static void AddUpgrades(this GameModel model, System.Collections.Generic.List<UpgradeModel> upgradeModels);
```
#### Parameters

<a name='BTD_Mod_Helper.Extensions.GameModelExt.AddUpgrades(thisGameModel,System.Collections.Generic.List_UpgradeModel_).model'></a>

`model` [Il2CppAssets.Scripts.Models.GameModel](https://docs.microsoft.com/en-us/dotnet/api/Il2CppAssets.Scripts.Models.GameModel 'Il2CppAssets.Scripts.Models.GameModel')

<a name='BTD_Mod_Helper.Extensions.GameModelExt.AddUpgrades(thisGameModel,System.Collections.Generic.List_UpgradeModel_).upgradeModels'></a>

`upgradeModels` [System.Collections.Generic.List&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.List-1 'System.Collections.Generic.List`1')[Il2CppAssets.Scripts.Models.Towers.Upgrades.UpgradeModel](https://docs.microsoft.com/en-us/dotnet/api/Il2CppAssets.Scripts.Models.Towers.Upgrades.UpgradeModel 'Il2CppAssets.Scripts.Models.Towers.Upgrades.UpgradeModel')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.List-1 'System.Collections.Generic.List`1')

<a name='BTD_Mod_Helper.Extensions.GameModelExt.AddUpgrades(thisGameModel,UpgradeModel[])'></a>

## GameModelExt.AddUpgrades(this GameModel, UpgradeModel[]) Method

Fully adds multiple UpgradeModels to the GameModel

```csharp
public static void AddUpgrades(this GameModel model, UpgradeModel[] upgradeModels);
```
#### Parameters

<a name='BTD_Mod_Helper.Extensions.GameModelExt.AddUpgrades(thisGameModel,UpgradeModel[]).model'></a>

`model` [Il2CppAssets.Scripts.Models.GameModel](https://docs.microsoft.com/en-us/dotnet/api/Il2CppAssets.Scripts.Models.GameModel 'Il2CppAssets.Scripts.Models.GameModel')

<a name='BTD_Mod_Helper.Extensions.GameModelExt.AddUpgrades(thisGameModel,UpgradeModel[]).upgradeModels'></a>

`upgradeModels` [Il2CppAssets.Scripts.Models.Towers.Upgrades.UpgradeModel](https://docs.microsoft.com/en-us/dotnet/api/Il2CppAssets.Scripts.Models.Towers.Upgrades.UpgradeModel 'Il2CppAssets.Scripts.Models.Towers.Upgrades.UpgradeModel')[[]](https://docs.microsoft.com/en-us/dotnet/api/System.Array 'System.Array')

<a name='BTD_Mod_Helper.Extensions.GameModelExt.CreateBloonEmission(thisGameModel,string,float)'></a>

## GameModelExt.CreateBloonEmission(this GameModel, string, float) Method

Create a single BloonEmission

```csharp
public static BloonEmissionModel CreateBloonEmission(this GameModel model, string bloonName, float time);
```
#### Parameters

<a name='BTD_Mod_Helper.Extensions.GameModelExt.CreateBloonEmission(thisGameModel,string,float).model'></a>

`model` [Il2CppAssets.Scripts.Models.GameModel](https://docs.microsoft.com/en-us/dotnet/api/Il2CppAssets.Scripts.Models.GameModel 'Il2CppAssets.Scripts.Models.GameModel')

the GameModel instance

<a name='BTD_Mod_Helper.Extensions.GameModelExt.CreateBloonEmission(thisGameModel,string,float).bloonName'></a>

`bloonName` [System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')

Name of this bloon. Example: "Red"

<a name='BTD_Mod_Helper.Extensions.GameModelExt.CreateBloonEmission(thisGameModel,string,float).time'></a>

`time` [System.Single](https://docs.microsoft.com/en-us/dotnet/api/System.Single 'System.Single')

Time the bloon should be spawned

#### Returns
[Il2CppAssets.Scripts.Models.Rounds.BloonEmissionModel](https://docs.microsoft.com/en-us/dotnet/api/Il2CppAssets.Scripts.Models.Rounds.BloonEmissionModel 'Il2CppAssets.Scripts.Models.Rounds.BloonEmissionModel')

<a name='BTD_Mod_Helper.Extensions.GameModelExt.CreateBloonEmissions(thisGameModel,BloonModel,int,float)'></a>

## GameModelExt.CreateBloonEmissions(this GameModel, BloonModel, int, float) Method

Create a BloonEmissionModel from a bloonModel

```csharp
public static Il2CppReferenceArray<BloonEmissionModel> CreateBloonEmissions(this GameModel model, BloonModel bloonModel, int number, float spacing);
```
#### Parameters

<a name='BTD_Mod_Helper.Extensions.GameModelExt.CreateBloonEmissions(thisGameModel,BloonModel,int,float).model'></a>

`model` [Il2CppAssets.Scripts.Models.GameModel](https://docs.microsoft.com/en-us/dotnet/api/Il2CppAssets.Scripts.Models.GameModel 'Il2CppAssets.Scripts.Models.GameModel')

the GameModel instance

<a name='BTD_Mod_Helper.Extensions.GameModelExt.CreateBloonEmissions(thisGameModel,BloonModel,int,float).bloonModel'></a>

`bloonModel` [Il2CppAssets.Scripts.Models.Bloons.BloonModel](https://docs.microsoft.com/en-us/dotnet/api/Il2CppAssets.Scripts.Models.Bloons.BloonModel 'Il2CppAssets.Scripts.Models.Bloons.BloonModel')

The bloon model that these bloons should be

<a name='BTD_Mod_Helper.Extensions.GameModelExt.CreateBloonEmissions(thisGameModel,BloonModel,int,float).number'></a>

`number` [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/System.Int32 'System.Int32')

Number of Bloons in this emission

<a name='BTD_Mod_Helper.Extensions.GameModelExt.CreateBloonEmissions(thisGameModel,BloonModel,int,float).spacing'></a>

`spacing` [System.Single](https://docs.microsoft.com/en-us/dotnet/api/System.Single 'System.Single')

Space between each bloon in this emission

#### Returns
[Il2CppInterop.Runtime.InteropTypes.Arrays.Il2CppReferenceArray](https://docs.microsoft.com/en-us/dotnet/api/Il2CppInterop.Runtime.InteropTypes.Arrays.Il2CppReferenceArray 'Il2CppInterop.Runtime.InteropTypes.Arrays.Il2CppReferenceArray')

<a name='BTD_Mod_Helper.Extensions.GameModelExt.CreateBloonEmissions(thisGameModel,string,int,float)'></a>

## GameModelExt.CreateBloonEmissions(this GameModel, string, int, float) Method

Create a BloonEmissionModel from a bloon's name

```csharp
public static Il2CppReferenceArray<BloonEmissionModel> CreateBloonEmissions(this GameModel model, string bloonName, int number, float spacing);
```
#### Parameters

<a name='BTD_Mod_Helper.Extensions.GameModelExt.CreateBloonEmissions(thisGameModel,string,int,float).model'></a>

`model` [Il2CppAssets.Scripts.Models.GameModel](https://docs.microsoft.com/en-us/dotnet/api/Il2CppAssets.Scripts.Models.GameModel 'Il2CppAssets.Scripts.Models.GameModel')

the GameModel instance

<a name='BTD_Mod_Helper.Extensions.GameModelExt.CreateBloonEmissions(thisGameModel,string,int,float).bloonName'></a>

`bloonName` [System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')

Name of bloon. Example: "Red"

<a name='BTD_Mod_Helper.Extensions.GameModelExt.CreateBloonEmissions(thisGameModel,string,int,float).number'></a>

`number` [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/System.Int32 'System.Int32')

Number of Bloons in this emission

<a name='BTD_Mod_Helper.Extensions.GameModelExt.CreateBloonEmissions(thisGameModel,string,int,float).spacing'></a>

`spacing` [System.Single](https://docs.microsoft.com/en-us/dotnet/api/System.Single 'System.Single')

Space between each bloon in this emission

#### Returns
[Il2CppInterop.Runtime.InteropTypes.Arrays.Il2CppReferenceArray](https://docs.microsoft.com/en-us/dotnet/api/Il2CppInterop.Runtime.InteropTypes.Arrays.Il2CppReferenceArray 'Il2CppInterop.Runtime.InteropTypes.Arrays.Il2CppReferenceArray')

<a name='BTD_Mod_Helper.Extensions.GameModelExt.CreateBloonGroup(thisGameModel,string,float,float,int)'></a>

## GameModelExt.CreateBloonGroup(this GameModel, string, float, float, int) Method

Creates a BloonGroup

```csharp
public static BloonGroupModel CreateBloonGroup(this GameModel model, string bloonName, float startTime, float spacing, int count);
```
#### Parameters

<a name='BTD_Mod_Helper.Extensions.GameModelExt.CreateBloonGroup(thisGameModel,string,float,float,int).model'></a>

`model` [Il2CppAssets.Scripts.Models.GameModel](https://docs.microsoft.com/en-us/dotnet/api/Il2CppAssets.Scripts.Models.GameModel 'Il2CppAssets.Scripts.Models.GameModel')

<a name='BTD_Mod_Helper.Extensions.GameModelExt.CreateBloonGroup(thisGameModel,string,float,float,int).bloonName'></a>

`bloonName` [System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')

<a name='BTD_Mod_Helper.Extensions.GameModelExt.CreateBloonGroup(thisGameModel,string,float,float,int).startTime'></a>

`startTime` [System.Single](https://docs.microsoft.com/en-us/dotnet/api/System.Single 'System.Single')

<a name='BTD_Mod_Helper.Extensions.GameModelExt.CreateBloonGroup(thisGameModel,string,float,float,int).spacing'></a>

`spacing` [System.Single](https://docs.microsoft.com/en-us/dotnet/api/System.Single 'System.Single')

<a name='BTD_Mod_Helper.Extensions.GameModelExt.CreateBloonGroup(thisGameModel,string,float,float,int).count'></a>

`count` [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/System.Int32 'System.Int32')

#### Returns
[Il2CppAssets.Scripts.Models.Rounds.BloonGroupModel](https://docs.microsoft.com/en-us/dotnet/api/Il2CppAssets.Scripts.Models.Rounds.BloonGroupModel 'Il2CppAssets.Scripts.Models.Rounds.BloonGroupModel')

<a name='BTD_Mod_Helper.Extensions.GameModelExt.DoesBloonExist(thisGameModel,string)'></a>

## GameModelExt.DoesBloonExist(this GameModel, string) Method

Returns whether or not a bloon exists with this name

```csharp
public static bool DoesBloonExist(this GameModel gameModel, string bloonName);
```
#### Parameters

<a name='BTD_Mod_Helper.Extensions.GameModelExt.DoesBloonExist(thisGameModel,string).gameModel'></a>

`gameModel` [Il2CppAssets.Scripts.Models.GameModel](https://docs.microsoft.com/en-us/dotnet/api/Il2CppAssets.Scripts.Models.GameModel 'Il2CppAssets.Scripts.Models.GameModel')

<a name='BTD_Mod_Helper.Extensions.GameModelExt.DoesBloonExist(thisGameModel,string).bloonName'></a>

`bloonName` [System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')

#### Returns
[System.Boolean](https://docs.microsoft.com/en-us/dotnet/api/System.Boolean 'System.Boolean')

<a name='BTD_Mod_Helper.Extensions.GameModelExt.DoesTowerDetailsExist(thisGameModel,string)'></a>

## GameModelExt.DoesTowerDetailsExist(this GameModel, string) Method

Returns whether or not any TowerDetailsModels in [Il2CppAssets.Scripts.Models.GameModel.towerSet](https://docs.microsoft.com/en-us/dotnet/api/Il2CppAssets.Scripts.Models.GameModel.towerSet 'Il2CppAssets.Scripts.Models.GameModel.towerSet') have [towerId](BTD_Mod_Helper.Extensions.GameModelExt.md#BTD_Mod_Helper.Extensions.GameModelExt.DoesTowerDetailsExist(thisGameModel,string).towerId 'BTD_Mod_Helper.Extensions.GameModelExt.DoesTowerDetailsExist(this GameModel, string).towerId')  
in it's name

```csharp
public static bool DoesTowerDetailsExist(this GameModel model, string towerId);
```
#### Parameters

<a name='BTD_Mod_Helper.Extensions.GameModelExt.DoesTowerDetailsExist(thisGameModel,string).model'></a>

`model` [Il2CppAssets.Scripts.Models.GameModel](https://docs.microsoft.com/en-us/dotnet/api/Il2CppAssets.Scripts.Models.GameModel 'Il2CppAssets.Scripts.Models.GameModel')

<a name='BTD_Mod_Helper.Extensions.GameModelExt.DoesTowerDetailsExist(thisGameModel,string).towerId'></a>

`towerId` [System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')

#### Returns
[System.Boolean](https://docs.microsoft.com/en-us/dotnet/api/System.Boolean 'System.Boolean')

<a name='BTD_Mod_Helper.Extensions.GameModelExt.DoesTowerModelExist(thisGameModel,string)'></a>

## GameModelExt.DoesTowerModelExist(this GameModel, string) Method

Returns whether or not any TowerModels in [Il2CppAssets.Scripts.Models.GameModel.towers](https://docs.microsoft.com/en-us/dotnet/api/Il2CppAssets.Scripts.Models.GameModel.towers 'Il2CppAssets.Scripts.Models.GameModel.towers') have [towerId](BTD_Mod_Helper.Extensions.GameModelExt.md#BTD_Mod_Helper.Extensions.GameModelExt.DoesTowerModelExist(thisGameModel,string).towerId 'BTD_Mod_Helper.Extensions.GameModelExt.DoesTowerModelExist(this GameModel, string).towerId')  
in it's name

```csharp
public static bool DoesTowerModelExist(this GameModel model, string towerId);
```
#### Parameters

<a name='BTD_Mod_Helper.Extensions.GameModelExt.DoesTowerModelExist(thisGameModel,string).model'></a>

`model` [Il2CppAssets.Scripts.Models.GameModel](https://docs.microsoft.com/en-us/dotnet/api/Il2CppAssets.Scripts.Models.GameModel 'Il2CppAssets.Scripts.Models.GameModel')

<a name='BTD_Mod_Helper.Extensions.GameModelExt.DoesTowerModelExist(thisGameModel,string).towerId'></a>

`towerId` [System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')

#### Returns
[System.Boolean](https://docs.microsoft.com/en-us/dotnet/api/System.Boolean 'System.Boolean')

<a name='BTD_Mod_Helper.Extensions.GameModelExt.GetAllAbilityModels(thisGameModel)'></a>

## GameModelExt.GetAllAbilityModels(this GameModel) Method

Return all AbilityModels from every TowerModel in the game

```csharp
public static System.Collections.Generic.List<AbilityModel> GetAllAbilityModels(this GameModel model);
```
#### Parameters

<a name='BTD_Mod_Helper.Extensions.GameModelExt.GetAllAbilityModels(thisGameModel).model'></a>

`model` [Il2CppAssets.Scripts.Models.GameModel](https://docs.microsoft.com/en-us/dotnet/api/Il2CppAssets.Scripts.Models.GameModel 'Il2CppAssets.Scripts.Models.GameModel')

#### Returns
[System.Collections.Generic.List&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.List-1 'System.Collections.Generic.List`1')[Il2CppAssets.Scripts.Models.Towers.Behaviors.Abilities.AbilityModel](https://docs.microsoft.com/en-us/dotnet/api/Il2CppAssets.Scripts.Models.Towers.Behaviors.Abilities.AbilityModel 'Il2CppAssets.Scripts.Models.Towers.Behaviors.Abilities.AbilityModel')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.List-1 'System.Collections.Generic.List`1')

<a name='BTD_Mod_Helper.Extensions.GameModelExt.GetAllAttackModels(thisGameModel)'></a>

## GameModelExt.GetAllAttackModels(this GameModel) Method

Return all AttackModels from every TowerModel in the game

```csharp
public static System.Collections.Generic.List<AttackModel> GetAllAttackModels(this GameModel model);
```
#### Parameters

<a name='BTD_Mod_Helper.Extensions.GameModelExt.GetAllAttackModels(thisGameModel).model'></a>

`model` [Il2CppAssets.Scripts.Models.GameModel](https://docs.microsoft.com/en-us/dotnet/api/Il2CppAssets.Scripts.Models.GameModel 'Il2CppAssets.Scripts.Models.GameModel')

#### Returns
[System.Collections.Generic.List&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.List-1 'System.Collections.Generic.List`1')[Il2CppAssets.Scripts.Models.Towers.Behaviors.Attack.AttackModel](https://docs.microsoft.com/en-us/dotnet/api/Il2CppAssets.Scripts.Models.Towers.Behaviors.Attack.AttackModel 'Il2CppAssets.Scripts.Models.Towers.Behaviors.Attack.AttackModel')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.List-1 'System.Collections.Generic.List`1')

<a name='BTD_Mod_Helper.Extensions.GameModelExt.GetAllProjectileModels(thisGameModel)'></a>

## GameModelExt.GetAllProjectileModels(this GameModel) Method

Return all ProjectileModels from every TowerModel in the game

```csharp
public static System.Collections.Generic.List<ProjectileModel> GetAllProjectileModels(this GameModel model);
```
#### Parameters

<a name='BTD_Mod_Helper.Extensions.GameModelExt.GetAllProjectileModels(thisGameModel).model'></a>

`model` [Il2CppAssets.Scripts.Models.GameModel](https://docs.microsoft.com/en-us/dotnet/api/Il2CppAssets.Scripts.Models.GameModel 'Il2CppAssets.Scripts.Models.GameModel')

#### Returns
[System.Collections.Generic.List&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.List-1 'System.Collections.Generic.List`1')[Il2CppAssets.Scripts.Models.Towers.Projectiles.ProjectileModel](https://docs.microsoft.com/en-us/dotnet/api/Il2CppAssets.Scripts.Models.Towers.Projectiles.ProjectileModel 'Il2CppAssets.Scripts.Models.Towers.Projectiles.ProjectileModel')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.List-1 'System.Collections.Generic.List`1')

<a name='BTD_Mod_Helper.Extensions.GameModelExt.GetAllShopTowerDetails(thisGameModel)'></a>

## GameModelExt.GetAllShopTowerDetails(this GameModel) Method

Return all ShopTowerDetailModels

```csharp
public static List<ShopTowerDetailsModel> GetAllShopTowerDetails(this GameModel model);
```
#### Parameters

<a name='BTD_Mod_Helper.Extensions.GameModelExt.GetAllShopTowerDetails(thisGameModel).model'></a>

`model` [Il2CppAssets.Scripts.Models.GameModel](https://docs.microsoft.com/en-us/dotnet/api/Il2CppAssets.Scripts.Models.GameModel 'Il2CppAssets.Scripts.Models.GameModel')

#### Returns
[Il2CppSystem.Collections.Generic.List](https://docs.microsoft.com/en-us/dotnet/api/Il2CppSystem.Collections.Generic.List 'Il2CppSystem.Collections.Generic.List')

<a name='BTD_Mod_Helper.Extensions.GameModelExt.GetAllTowerDetails(thisGameModel)'></a>

## GameModelExt.GetAllTowerDetails(this GameModel) Method

Return all TowerDetailModels

```csharp
public static List<TowerDetailsModel> GetAllTowerDetails(this GameModel model);
```
#### Parameters

<a name='BTD_Mod_Helper.Extensions.GameModelExt.GetAllTowerDetails(thisGameModel).model'></a>

`model` [Il2CppAssets.Scripts.Models.GameModel](https://docs.microsoft.com/en-us/dotnet/api/Il2CppAssets.Scripts.Models.GameModel 'Il2CppAssets.Scripts.Models.GameModel')

#### Returns
[Il2CppSystem.Collections.Generic.List](https://docs.microsoft.com/en-us/dotnet/api/Il2CppSystem.Collections.Generic.List 'Il2CppSystem.Collections.Generic.List')

<a name='BTD_Mod_Helper.Extensions.GameModelExt.GetAllWeaponModels(thisGameModel)'></a>

## GameModelExt.GetAllWeaponModels(this GameModel) Method

Return all WeaponModels from every AttackModel in the game

```csharp
public static System.Collections.Generic.List<WeaponModel> GetAllWeaponModels(this GameModel model);
```
#### Parameters

<a name='BTD_Mod_Helper.Extensions.GameModelExt.GetAllWeaponModels(thisGameModel).model'></a>

`model` [Il2CppAssets.Scripts.Models.GameModel](https://docs.microsoft.com/en-us/dotnet/api/Il2CppAssets.Scripts.Models.GameModel 'Il2CppAssets.Scripts.Models.GameModel')

#### Returns
[System.Collections.Generic.List&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.List-1 'System.Collections.Generic.List`1')[Il2CppAssets.Scripts.Models.Towers.Weapons.WeaponModel](https://docs.microsoft.com/en-us/dotnet/api/Il2CppAssets.Scripts.Models.Towers.Weapons.WeaponModel 'Il2CppAssets.Scripts.Models.Towers.Weapons.WeaponModel')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.List-1 'System.Collections.Generic.List`1')

<a name='BTD_Mod_Helper.Extensions.GameModelExt.GetTowerDetails(thisGameModel,string)'></a>

## GameModelExt.GetTowerDetails(this GameModel, string) Method

Returns the first TowerDetailsModel in [Il2CppAssets.Scripts.Models.GameModel.towerSet](https://docs.microsoft.com/en-us/dotnet/api/Il2CppAssets.Scripts.Models.GameModel.towerSet 'Il2CppAssets.Scripts.Models.GameModel.towerSet') that has a towerId of  
[towerDetailsName](BTD_Mod_Helper.Extensions.GameModelExt.md#BTD_Mod_Helper.Extensions.GameModelExt.GetTowerDetails(thisGameModel,string).towerDetailsName 'BTD_Mod_Helper.Extensions.GameModelExt.GetTowerDetails(this GameModel, string).towerDetailsName')

```csharp
public static TowerDetailsModel GetTowerDetails(this GameModel model, string towerDetailsName);
```
#### Parameters

<a name='BTD_Mod_Helper.Extensions.GameModelExt.GetTowerDetails(thisGameModel,string).model'></a>

`model` [Il2CppAssets.Scripts.Models.GameModel](https://docs.microsoft.com/en-us/dotnet/api/Il2CppAssets.Scripts.Models.GameModel 'Il2CppAssets.Scripts.Models.GameModel')

<a name='BTD_Mod_Helper.Extensions.GameModelExt.GetTowerDetails(thisGameModel,string).towerDetailsName'></a>

`towerDetailsName` [System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')

The [Il2CppAssets.Scripts.Models.TowerSets.TowerDetailsModel.towerId](https://docs.microsoft.com/en-us/dotnet/api/Il2CppAssets.Scripts.Models.TowerSets.TowerDetailsModel.towerId 'Il2CppAssets.Scripts.Models.TowerSets.TowerDetailsModel.towerId') you are searching for

#### Returns
[Il2CppAssets.Scripts.Models.TowerSets.TowerDetailsModel](https://docs.microsoft.com/en-us/dotnet/api/Il2CppAssets.Scripts.Models.TowerSets.TowerDetailsModel 'Il2CppAssets.Scripts.Models.TowerSets.TowerDetailsModel')  
The first TowerDetailsModel found, otherwise returns null

<a name='BTD_Mod_Helper.Extensions.GameModelExt.GetTowerModel(thisGameModel,string,int,int,int)'></a>

## GameModelExt.GetTowerModel(this GameModel, string, int, int, int) Method

Get a TowerModel from model.towers.  
NOTE: model.GetTower cannot get custom towers so use this method instead

```csharp
public static TowerModel GetTowerModel(this GameModel model, string towerId, int path1=0, int path2=0, int path3=0);
```
#### Parameters

<a name='BTD_Mod_Helper.Extensions.GameModelExt.GetTowerModel(thisGameModel,string,int,int,int).model'></a>

`model` [Il2CppAssets.Scripts.Models.GameModel](https://docs.microsoft.com/en-us/dotnet/api/Il2CppAssets.Scripts.Models.GameModel 'Il2CppAssets.Scripts.Models.GameModel')

<a name='BTD_Mod_Helper.Extensions.GameModelExt.GetTowerModel(thisGameModel,string,int,int,int).towerId'></a>

`towerId` [System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')

<a name='BTD_Mod_Helper.Extensions.GameModelExt.GetTowerModel(thisGameModel,string,int,int,int).path1'></a>

`path1` [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/System.Int32 'System.Int32')

<a name='BTD_Mod_Helper.Extensions.GameModelExt.GetTowerModel(thisGameModel,string,int,int,int).path2'></a>

`path2` [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/System.Int32 'System.Int32')

<a name='BTD_Mod_Helper.Extensions.GameModelExt.GetTowerModel(thisGameModel,string,int,int,int).path3'></a>

`path3` [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/System.Int32 'System.Int32')

#### Returns
[Il2CppAssets.Scripts.Models.Towers.TowerModel](https://docs.microsoft.com/en-us/dotnet/api/Il2CppAssets.Scripts.Models.Towers.TowerModel 'Il2CppAssets.Scripts.Models.Towers.TowerModel')

<a name='BTD_Mod_Helper.Extensions.GameModelExt.GetTowerModels(thisGameModel,string)'></a>

## GameModelExt.GetTowerModels(this GameModel, string) Method

Return all TowerModels with a specific base id

```csharp
public static System.Collections.Generic.List<TowerModel> GetTowerModels(this GameModel model, string towerBaseId);
```
#### Parameters

<a name='BTD_Mod_Helper.Extensions.GameModelExt.GetTowerModels(thisGameModel,string).model'></a>

`model` [Il2CppAssets.Scripts.Models.GameModel](https://docs.microsoft.com/en-us/dotnet/api/Il2CppAssets.Scripts.Models.GameModel 'Il2CppAssets.Scripts.Models.GameModel')

the GameModel instance

<a name='BTD_Mod_Helper.Extensions.GameModelExt.GetTowerModels(thisGameModel,string).towerBaseId'></a>

`towerBaseId` [System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')

The base id all towers should share. Example: "DartMonkey"

#### Returns
[System.Collections.Generic.List&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.List-1 'System.Collections.Generic.List`1')[Il2CppAssets.Scripts.Models.Towers.TowerModel](https://docs.microsoft.com/en-us/dotnet/api/Il2CppAssets.Scripts.Models.Towers.TowerModel 'Il2CppAssets.Scripts.Models.Towers.TowerModel')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.List-1 'System.Collections.Generic.List`1')

<a name='BTD_Mod_Helper.Extensions.GameModelExt.GetTowerModelsWithAbilities(thisGameModel)'></a>

## GameModelExt.GetTowerModelsWithAbilities(this GameModel) Method

Return all TowerModels that have at least one AbilityModel

```csharp
public static System.Collections.Generic.List<TowerModel> GetTowerModelsWithAbilities(this GameModel model);
```
#### Parameters

<a name='BTD_Mod_Helper.Extensions.GameModelExt.GetTowerModelsWithAbilities(thisGameModel).model'></a>

`model` [Il2CppAssets.Scripts.Models.GameModel](https://docs.microsoft.com/en-us/dotnet/api/Il2CppAssets.Scripts.Models.GameModel 'Il2CppAssets.Scripts.Models.GameModel')

#### Returns
[System.Collections.Generic.List&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.List-1 'System.Collections.Generic.List`1')[Il2CppAssets.Scripts.Models.Towers.TowerModel](https://docs.microsoft.com/en-us/dotnet/api/Il2CppAssets.Scripts.Models.Towers.TowerModel 'Il2CppAssets.Scripts.Models.Towers.TowerModel')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.List-1 'System.Collections.Generic.List`1')