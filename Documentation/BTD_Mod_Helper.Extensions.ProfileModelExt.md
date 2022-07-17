#### [BloonsTD6 Mod Helper](README.md 'README')
### [BTD_Mod_Helper.Extensions](README.md#BTD_Mod_Helper.Extensions 'BTD_Mod_Helper.Extensions')

## ProfileModelExt Class

Extensions for ProfileModels

```csharp
public static class ProfileModelExt
```

Inheritance [System.Object](https://docs.microsoft.com/en-us/dotnet/api/System.Object 'System.Object') &#129106; ProfileModelExt
### Methods

<a name='BTD_Mod_Helper.Extensions.ProfileModelExt.UnlockTower(thisAssets.Scripts.Models.Profile.ProfileModel,string)'></a>

## ProfileModelExt.UnlockTower(this ProfileModel, string) Method

Add a tower to the list of UnlockedTowers

```csharp
public static void UnlockTower(this Assets.Scripts.Models.Profile.ProfileModel profileModel, string towerId);
```
#### Parameters

<a name='BTD_Mod_Helper.Extensions.ProfileModelExt.UnlockTower(thisAssets.Scripts.Models.Profile.ProfileModel,string).profileModel'></a>

`profileModel` [Assets.Scripts.Models.Profile.ProfileModel](https://docs.microsoft.com/en-us/dotnet/api/Assets.Scripts.Models.Profile.ProfileModel 'Assets.Scripts.Models.Profile.ProfileModel')

<a name='BTD_Mod_Helper.Extensions.ProfileModelExt.UnlockTower(thisAssets.Scripts.Models.Profile.ProfileModel,string).towerId'></a>

`towerId` [System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')

The ID of the tower you want to unlock

<a name='BTD_Mod_Helper.Extensions.ProfileModelExt.UnlockTower(thisAssets.Scripts.Models.Profile.ProfileModel,string,bool)'></a>

## ProfileModelExt.UnlockTower(this ProfileModel, string, bool) Method

Add a tower to the list of UnlockedTowers only if the TowerModel is in Game.instance.model.towers

```csharp
public static bool UnlockTower(this Assets.Scripts.Models.Profile.ProfileModel profileModel, string towerId, bool unlockIfTowerModelExists);
```
#### Parameters

<a name='BTD_Mod_Helper.Extensions.ProfileModelExt.UnlockTower(thisAssets.Scripts.Models.Profile.ProfileModel,string,bool).profileModel'></a>

`profileModel` [Assets.Scripts.Models.Profile.ProfileModel](https://docs.microsoft.com/en-us/dotnet/api/Assets.Scripts.Models.Profile.ProfileModel 'Assets.Scripts.Models.Profile.ProfileModel')

<a name='BTD_Mod_Helper.Extensions.ProfileModelExt.UnlockTower(thisAssets.Scripts.Models.Profile.ProfileModel,string,bool).towerId'></a>

`towerId` [System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')

The ID of the tower you want to unlock

<a name='BTD_Mod_Helper.Extensions.ProfileModelExt.UnlockTower(thisAssets.Scripts.Models.Profile.ProfileModel,string,bool).unlockIfTowerModelExists'></a>

`unlockIfTowerModelExists` [System.Boolean](https://docs.microsoft.com/en-us/dotnet/api/System.Boolean 'System.Boolean')

If set to true the TowerModel will only be unlocked if it has been registered in the game

#### Returns
[System.Boolean](https://docs.microsoft.com/en-us/dotnet/api/System.Boolean 'System.Boolean')  
Returns whether or not the tower was unlocked