#### [BloonsTD6 Mod Helper](README.md 'README')
### [BTD_Mod_Helper.Extensions](README.md#BTD_Mod_Helper.Extensions 'BTD_Mod_Helper.Extensions')

## UpgradeModelExt Class

Extensions for UpgradeModels

```csharp
public static class UpgradeModelExt
```

Inheritance [System.Object](https://docs.microsoft.com/en-us/dotnet/api/System.Object 'System.Object') &#129106; UpgradeModelExt
### Methods

<a name='BTD_Mod_Helper.Extensions.UpgradeModelExt.GetModUpgrade(thisAssets.Scripts.Models.Towers.Upgrades.UpgradeModel)'></a>

## UpgradeModelExt.GetModUpgrade(this UpgradeModel) Method

Gets the ModUpgrade associated with this UpgradeModel  
<br/>  
If there is no associated ModUpgrade, returns null

```csharp
public static BTD_Mod_Helper.Api.Towers.ModUpgrade GetModUpgrade(this Assets.Scripts.Models.Towers.Upgrades.UpgradeModel upgradeModel);
```
#### Parameters

<a name='BTD_Mod_Helper.Extensions.UpgradeModelExt.GetModUpgrade(thisAssets.Scripts.Models.Towers.Upgrades.UpgradeModel).upgradeModel'></a>

`upgradeModel` [Assets.Scripts.Models.Towers.Upgrades.UpgradeModel](https://docs.microsoft.com/en-us/dotnet/api/Assets.Scripts.Models.Towers.Upgrades.UpgradeModel 'Assets.Scripts.Models.Towers.Upgrades.UpgradeModel')

#### Returns
[ModUpgrade](BTD_Mod_Helper.Api.Towers.ModUpgrade.md 'BTD_Mod_Helper.Api.Towers.ModUpgrade')

<a name='BTD_Mod_Helper.Extensions.UpgradeModelExt.IsUpgradeUnlocked(thisAssets.Scripts.Models.Towers.Upgrades.UpgradeModel)'></a>

## UpgradeModelExt.IsUpgradeUnlocked(this UpgradeModel) Method

Return whether or not this upgrade has been unlocked by the player

```csharp
public static bool IsUpgradeUnlocked(this Assets.Scripts.Models.Towers.Upgrades.UpgradeModel upgradeModel);
```
#### Parameters

<a name='BTD_Mod_Helper.Extensions.UpgradeModelExt.IsUpgradeUnlocked(thisAssets.Scripts.Models.Towers.Upgrades.UpgradeModel).upgradeModel'></a>

`upgradeModel` [Assets.Scripts.Models.Towers.Upgrades.UpgradeModel](https://docs.microsoft.com/en-us/dotnet/api/Assets.Scripts.Models.Towers.Upgrades.UpgradeModel 'Assets.Scripts.Models.Towers.Upgrades.UpgradeModel')

#### Returns
[System.Boolean](https://docs.microsoft.com/en-us/dotnet/api/System.Boolean 'System.Boolean')