#### [BloonsTD6 Mod Helper](README.md 'README')
### [BTD_Mod_Helper.Extensions](README.md#BTD_Mod_Helper.Extensions 'BTD_Mod_Helper.Extensions')

## ProfileModelExt Class

Extensions for ProfileModels

```csharp
public static class ProfileModelExt
```

Inheritance [System.Object](https://docs.microsoft.com/en-us/dotnet/api/System.Object 'System.Object') &#129106; ProfileModelExt
### Methods

<a name='BTD_Mod_Helper.Extensions.ProfileModelExt.UnlockTower(thisProfileModel,string,bool)'></a>

## ProfileModelExt.UnlockTower(this ProfileModel, string, bool) Method

Add a tower to the list of UnlockedTowers only if the TowerModel is in Game.instance.model.towers

```csharp
public static bool UnlockTower(this ProfileModel profileModel, string towerId, bool unlockIfTowerModelExists);
```
#### Parameters

<a name='BTD_Mod_Helper.Extensions.ProfileModelExt.UnlockTower(thisProfileModel,string,bool).profileModel'></a>

`profileModel` [Il2CppAssets.Scripts.Models.Profile.ProfileModel](https://docs.microsoft.com/en-us/dotnet/api/Il2CppAssets.Scripts.Models.Profile.ProfileModel 'Il2CppAssets.Scripts.Models.Profile.ProfileModel')

<a name='BTD_Mod_Helper.Extensions.ProfileModelExt.UnlockTower(thisProfileModel,string,bool).towerId'></a>

`towerId` [System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')

The ID of the tower you want to unlock

<a name='BTD_Mod_Helper.Extensions.ProfileModelExt.UnlockTower(thisProfileModel,string,bool).unlockIfTowerModelExists'></a>

`unlockIfTowerModelExists` [System.Boolean](https://docs.microsoft.com/en-us/dotnet/api/System.Boolean 'System.Boolean')

If set to true the TowerModel will only be unlocked if it has been registered in the game

#### Returns
[System.Boolean](https://docs.microsoft.com/en-us/dotnet/api/System.Boolean 'System.Boolean')  
Returns whether or not the tower was unlocked

<a name='BTD_Mod_Helper.Extensions.ProfileModelExt.UnlockTower(thisProfileModel,string)'></a>

## ProfileModelExt.UnlockTower(this ProfileModel, string) Method

Add a tower to the list of UnlockedTowers

```csharp
public static void UnlockTower(this ProfileModel profileModel, string towerId);
```
#### Parameters

<a name='BTD_Mod_Helper.Extensions.ProfileModelExt.UnlockTower(thisProfileModel,string).profileModel'></a>

`profileModel` [Il2CppAssets.Scripts.Models.Profile.ProfileModel](https://docs.microsoft.com/en-us/dotnet/api/Il2CppAssets.Scripts.Models.Profile.ProfileModel 'Il2CppAssets.Scripts.Models.Profile.ProfileModel')

<a name='BTD_Mod_Helper.Extensions.ProfileModelExt.UnlockTower(thisProfileModel,string).towerId'></a>

`towerId` [System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')

The ID of the tower you want to unlock