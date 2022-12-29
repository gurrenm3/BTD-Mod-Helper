#### [BloonsTD6 Mod Helper](README.md 'README')
### [BTD_Mod_Helper.Extensions](README.md#BTD_Mod_Helper.Extensions 'BTD_Mod_Helper.Extensions')

## TowerDetailsModelExt Class

Extensions for TowerDetailsModels

```csharp
public static class TowerDetailsModelExt
```

Inheritance [System.Object](https://docs.microsoft.com/en-us/dotnet/api/System.Object 'System.Object') &#129106; TowerDetailsModelExt
### Methods

<a name='BTD_Mod_Helper.Extensions.TowerDetailsModelExt.GetIndex(thisTowerDetailsModel)'></a>

## TowerDetailsModelExt.GetIndex(this TowerDetailsModel) Method

Gets the index of this TowerDetailsModel within the GameModel

```csharp
public static int GetIndex(this TowerDetailsModel towerDetailsModel);
```
#### Parameters

<a name='BTD_Mod_Helper.Extensions.TowerDetailsModelExt.GetIndex(thisTowerDetailsModel).towerDetailsModel'></a>

`towerDetailsModel` [Il2CppAssets.Scripts.Models.TowerSets.TowerDetailsModel](https://docs.microsoft.com/en-us/dotnet/api/Il2CppAssets.Scripts.Models.TowerSets.TowerDetailsModel 'Il2CppAssets.Scripts.Models.TowerSets.TowerDetailsModel')

#### Returns
[System.Int32](https://docs.microsoft.com/en-us/dotnet/api/System.Int32 'System.Int32')

<a name='BTD_Mod_Helper.Extensions.TowerDetailsModelExt.GetShopTowerDetails(thisTowerDetailsModel)'></a>

## TowerDetailsModelExt.GetShopTowerDetails(this TowerDetailsModel) Method

Get the ShopTowerDetails for this TowerDetailModel

```csharp
public static ShopTowerDetailsModel GetShopTowerDetails(this TowerDetailsModel towerDetailsModel);
```
#### Parameters

<a name='BTD_Mod_Helper.Extensions.TowerDetailsModelExt.GetShopTowerDetails(thisTowerDetailsModel).towerDetailsModel'></a>

`towerDetailsModel` [Il2CppAssets.Scripts.Models.TowerSets.TowerDetailsModel](https://docs.microsoft.com/en-us/dotnet/api/Il2CppAssets.Scripts.Models.TowerSets.TowerDetailsModel 'Il2CppAssets.Scripts.Models.TowerSets.TowerDetailsModel')

#### Returns
[Il2CppAssets.Scripts.Models.TowerSets.ShopTowerDetailsModel](https://docs.microsoft.com/en-us/dotnet/api/Il2CppAssets.Scripts.Models.TowerSets.ShopTowerDetailsModel 'Il2CppAssets.Scripts.Models.TowerSets.ShopTowerDetailsModel')

<a name='BTD_Mod_Helper.Extensions.TowerDetailsModelExt.GetTower(thisTowerDetailsModel)'></a>

## TowerDetailsModelExt.GetTower(this TowerDetailsModel) Method

Gets the TowerModel for this TowerDetailsModel

```csharp
public static TowerModel GetTower(this TowerDetailsModel towerDetailsModel);
```
#### Parameters

<a name='BTD_Mod_Helper.Extensions.TowerDetailsModelExt.GetTower(thisTowerDetailsModel).towerDetailsModel'></a>

`towerDetailsModel` [Il2CppAssets.Scripts.Models.TowerSets.TowerDetailsModel](https://docs.microsoft.com/en-us/dotnet/api/Il2CppAssets.Scripts.Models.TowerSets.TowerDetailsModel 'Il2CppAssets.Scripts.Models.TowerSets.TowerDetailsModel')

#### Returns
[Il2CppAssets.Scripts.Models.Towers.TowerModel](https://docs.microsoft.com/en-us/dotnet/api/Il2CppAssets.Scripts.Models.Towers.TowerModel 'Il2CppAssets.Scripts.Models.Towers.TowerModel')

<a name='BTD_Mod_Helper.Extensions.TowerDetailsModelExt.GetTowerPurchaseButton(thisTowerDetailsModel)'></a>

## TowerDetailsModelExt.GetTowerPurchaseButton(this TowerDetailsModel) Method

Get the TowerPurchaseButton that is used to buy this specific TowerDetailModel

```csharp
public static TowerPurchaseButton GetTowerPurchaseButton(this TowerDetailsModel towerDetailsModel);
```
#### Parameters

<a name='BTD_Mod_Helper.Extensions.TowerDetailsModelExt.GetTowerPurchaseButton(thisTowerDetailsModel).towerDetailsModel'></a>

`towerDetailsModel` [Il2CppAssets.Scripts.Models.TowerSets.TowerDetailsModel](https://docs.microsoft.com/en-us/dotnet/api/Il2CppAssets.Scripts.Models.TowerSets.TowerDetailsModel 'Il2CppAssets.Scripts.Models.TowerSets.TowerDetailsModel')

#### Returns
[Il2CppAssets.Scripts.Unity.UI_New.InGame.StoreMenu.TowerPurchaseButton](https://docs.microsoft.com/en-us/dotnet/api/Il2CppAssets.Scripts.Unity.UI_New.InGame.StoreMenu.TowerPurchaseButton 'Il2CppAssets.Scripts.Unity.UI_New.InGame.StoreMenu.TowerPurchaseButton')

<a name='BTD_Mod_Helper.Extensions.TowerDetailsModelExt.IsHero(thisTowerDetailsModel)'></a>

## TowerDetailsModelExt.IsHero(this TowerDetailsModel) Method

Returns if this TowerDetailModel is actually for a Hero

```csharp
public static bool IsHero(this TowerDetailsModel towerDetailsModel);
```
#### Parameters

<a name='BTD_Mod_Helper.Extensions.TowerDetailsModelExt.IsHero(thisTowerDetailsModel).towerDetailsModel'></a>

`towerDetailsModel` [Il2CppAssets.Scripts.Models.TowerSets.TowerDetailsModel](https://docs.microsoft.com/en-us/dotnet/api/Il2CppAssets.Scripts.Models.TowerSets.TowerDetailsModel 'Il2CppAssets.Scripts.Models.TowerSets.TowerDetailsModel')

#### Returns
[System.Boolean](https://docs.microsoft.com/en-us/dotnet/api/System.Boolean 'System.Boolean')

<a name='BTD_Mod_Helper.Extensions.TowerDetailsModelExt.MakeCopy(thisTowerDetailsModel,string,bool)'></a>

## TowerDetailsModelExt.MakeCopy(this TowerDetailsModel, string, bool) Method

Makes a copy of this TowerDetailsModel with a new name

```csharp
public static TowerDetailsModel MakeCopy(this TowerDetailsModel towerDetailsModel, string newName, bool addToGame=false);
```
#### Parameters

<a name='BTD_Mod_Helper.Extensions.TowerDetailsModelExt.MakeCopy(thisTowerDetailsModel,string,bool).towerDetailsModel'></a>

`towerDetailsModel` [Il2CppAssets.Scripts.Models.TowerSets.TowerDetailsModel](https://docs.microsoft.com/en-us/dotnet/api/Il2CppAssets.Scripts.Models.TowerSets.TowerDetailsModel 'Il2CppAssets.Scripts.Models.TowerSets.TowerDetailsModel')

<a name='BTD_Mod_Helper.Extensions.TowerDetailsModelExt.MakeCopy(thisTowerDetailsModel,string,bool).newName'></a>

`newName` [System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')

<a name='BTD_Mod_Helper.Extensions.TowerDetailsModelExt.MakeCopy(thisTowerDetailsModel,string,bool).addToGame'></a>

`addToGame` [System.Boolean](https://docs.microsoft.com/en-us/dotnet/api/System.Boolean 'System.Boolean')

#### Returns
[Il2CppAssets.Scripts.Models.TowerSets.TowerDetailsModel](https://docs.microsoft.com/en-us/dotnet/api/Il2CppAssets.Scripts.Models.TowerSets.TowerDetailsModel 'Il2CppAssets.Scripts.Models.TowerSets.TowerDetailsModel')

<a name='BTD_Mod_Helper.Extensions.TowerDetailsModelExt.MakeCopy(thisTowerDetailsModel,string,int,bool)'></a>

## TowerDetailsModelExt.MakeCopy(this TowerDetailsModel, string, int, bool) Method

Makes a copy of this TowerDetailsModel with a new name and index

```csharp
public static TowerDetailsModel MakeCopy(this TowerDetailsModel towerDetailsModel, string newName, int newTowerIndex, bool addToGame=false);
```
#### Parameters

<a name='BTD_Mod_Helper.Extensions.TowerDetailsModelExt.MakeCopy(thisTowerDetailsModel,string,int,bool).towerDetailsModel'></a>

`towerDetailsModel` [Il2CppAssets.Scripts.Models.TowerSets.TowerDetailsModel](https://docs.microsoft.com/en-us/dotnet/api/Il2CppAssets.Scripts.Models.TowerSets.TowerDetailsModel 'Il2CppAssets.Scripts.Models.TowerSets.TowerDetailsModel')

<a name='BTD_Mod_Helper.Extensions.TowerDetailsModelExt.MakeCopy(thisTowerDetailsModel,string,int,bool).newName'></a>

`newName` [System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')

<a name='BTD_Mod_Helper.Extensions.TowerDetailsModelExt.MakeCopy(thisTowerDetailsModel,string,int,bool).newTowerIndex'></a>

`newTowerIndex` [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/System.Int32 'System.Int32')

<a name='BTD_Mod_Helper.Extensions.TowerDetailsModelExt.MakeCopy(thisTowerDetailsModel,string,int,bool).addToGame'></a>

`addToGame` [System.Boolean](https://docs.microsoft.com/en-us/dotnet/api/System.Boolean 'System.Boolean')

#### Returns
[Il2CppAssets.Scripts.Models.TowerSets.TowerDetailsModel](https://docs.microsoft.com/en-us/dotnet/api/Il2CppAssets.Scripts.Models.TowerSets.TowerDetailsModel 'Il2CppAssets.Scripts.Models.TowerSets.TowerDetailsModel')

<a name='BTD_Mod_Helper.Extensions.TowerDetailsModelExt.SetName(thisTowerDetailsModel,string)'></a>

## TowerDetailsModelExt.SetName(this TowerDetailsModel, string) Method

Sets the name of this TowerDetailsModel, following the naming convention of ofther TowerDetailModels.  
Example, using "NewMonkey" will set the name to "TowerDetailsModel_NewMonkey"

```csharp
public static void SetName(this TowerDetailsModel towerDetailsModel, string newName);
```
#### Parameters

<a name='BTD_Mod_Helper.Extensions.TowerDetailsModelExt.SetName(thisTowerDetailsModel,string).towerDetailsModel'></a>

`towerDetailsModel` [Il2CppAssets.Scripts.Models.TowerSets.TowerDetailsModel](https://docs.microsoft.com/en-us/dotnet/api/Il2CppAssets.Scripts.Models.TowerSets.TowerDetailsModel 'Il2CppAssets.Scripts.Models.TowerSets.TowerDetailsModel')

<a name='BTD_Mod_Helper.Extensions.TowerDetailsModelExt.SetName(thisTowerDetailsModel,string).newName'></a>

`newName` [System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')