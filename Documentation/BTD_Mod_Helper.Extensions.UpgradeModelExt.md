#### [BloonsTD6 Mod Helper](README.md 'README')
### [BTD_Mod_Helper.Extensions](README.md#BTD_Mod_Helper.Extensions 'BTD_Mod_Helper.Extensions')

## UpgradeModelExt Class

Extensions for UpgradeModels

```csharp
public static class UpgradeModelExt
```

Inheritance [System.Object](https://docs.microsoft.com/en-us/dotnet/api/System.Object 'System.Object') &#129106; UpgradeModelExt
### Methods

<a name='BTD_Mod_Helper.Extensions.UpgradeModelExt.GetModUpgrade(thisUpgradeModel)'></a>

## UpgradeModelExt.GetModUpgrade(this UpgradeModel) Method

Gets the ModUpgrade associated with this UpgradeModel  
<br/>  
If there is no associated ModUpgrade, returns null

```csharp
public static BTD_Mod_Helper.Api.Towers.ModUpgrade GetModUpgrade(this UpgradeModel upgradeModel);
```
#### Parameters

<a name='BTD_Mod_Helper.Extensions.UpgradeModelExt.GetModUpgrade(thisUpgradeModel).upgradeModel'></a>

`upgradeModel` [Il2CppAssets.Scripts.Models.Towers.Upgrades.UpgradeModel](https://docs.microsoft.com/en-us/dotnet/api/Il2CppAssets.Scripts.Models.Towers.Upgrades.UpgradeModel 'Il2CppAssets.Scripts.Models.Towers.Upgrades.UpgradeModel')

#### Returns
[ModUpgrade](BTD_Mod_Helper.Api.Towers.ModUpgrade.md 'BTD_Mod_Helper.Api.Towers.ModUpgrade')

<a name='BTD_Mod_Helper.Extensions.UpgradeModelExt.GetModUpgrade(thisUpgradePathModel)'></a>

## UpgradeModelExt.GetModUpgrade(this UpgradePathModel) Method

Gets the ModUpgrade that this UpgradePathModel is for, or null if it's vanilla

```csharp
public static BTD_Mod_Helper.Api.Towers.ModUpgrade GetModUpgrade(this UpgradePathModel upgradePathModel);
```
#### Parameters

<a name='BTD_Mod_Helper.Extensions.UpgradeModelExt.GetModUpgrade(thisUpgradePathModel).upgradePathModel'></a>

`upgradePathModel` [Il2CppAssets.Scripts.Models.Towers.Upgrades.UpgradePathModel](https://docs.microsoft.com/en-us/dotnet/api/Il2CppAssets.Scripts.Models.Towers.Upgrades.UpgradePathModel 'Il2CppAssets.Scripts.Models.Towers.Upgrades.UpgradePathModel')

#### Returns
[ModUpgrade](BTD_Mod_Helper.Api.Towers.ModUpgrade.md 'BTD_Mod_Helper.Api.Towers.ModUpgrade')

<a name='BTD_Mod_Helper.Extensions.UpgradeModelExt.GetUpgrade(thisUpgradePathModel)'></a>

## UpgradeModelExt.GetUpgrade(this UpgradePathModel) Method

Gets the UpgradeModel that this UpgradePathModel uses

```csharp
public static UpgradeModel GetUpgrade(this UpgradePathModel upgradePathModel);
```
#### Parameters

<a name='BTD_Mod_Helper.Extensions.UpgradeModelExt.GetUpgrade(thisUpgradePathModel).upgradePathModel'></a>

`upgradePathModel` [Il2CppAssets.Scripts.Models.Towers.Upgrades.UpgradePathModel](https://docs.microsoft.com/en-us/dotnet/api/Il2CppAssets.Scripts.Models.Towers.Upgrades.UpgradePathModel 'Il2CppAssets.Scripts.Models.Towers.Upgrades.UpgradePathModel')

#### Returns
[Il2CppAssets.Scripts.Models.Towers.Upgrades.UpgradeModel](https://docs.microsoft.com/en-us/dotnet/api/Il2CppAssets.Scripts.Models.Towers.Upgrades.UpgradeModel 'Il2CppAssets.Scripts.Models.Towers.Upgrades.UpgradeModel')

<a name='BTD_Mod_Helper.Extensions.UpgradeModelExt.IsUpgradeUnlocked(thisUpgradeModel)'></a>

## UpgradeModelExt.IsUpgradeUnlocked(this UpgradeModel) Method

Return whether or not this upgrade has been unlocked by the player

```csharp
public static bool IsUpgradeUnlocked(this UpgradeModel upgradeModel);
```
#### Parameters

<a name='BTD_Mod_Helper.Extensions.UpgradeModelExt.IsUpgradeUnlocked(thisUpgradeModel).upgradeModel'></a>

`upgradeModel` [Il2CppAssets.Scripts.Models.Towers.Upgrades.UpgradeModel](https://docs.microsoft.com/en-us/dotnet/api/Il2CppAssets.Scripts.Models.Towers.Upgrades.UpgradeModel 'Il2CppAssets.Scripts.Models.Towers.Upgrades.UpgradeModel')

#### Returns
[System.Boolean](https://docs.microsoft.com/en-us/dotnet/api/System.Boolean 'System.Boolean')