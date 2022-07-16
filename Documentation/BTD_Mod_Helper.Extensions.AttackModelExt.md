#### [BloonsTD6 Mod Helper](index.md 'index')
### [BTD_Mod_Helper.Extensions](index.md#BTD_Mod_Helper.Extensions 'BTD_Mod_Helper.Extensions')

## AttackModelExt Class

Extensions for AttackModels

```csharp
public static class AttackModelExt
```

Inheritance [System.Object](https://docs.microsoft.com/en-us/dotnet/api/System.Object 'System.Object') &#129106; AttackModelExt
### Methods

<a name='BTD_Mod_Helper.Extensions.AttackModelExt.AddWeapon(thisAssets.Scripts.Models.Towers.Behaviors.Attack.AttackModel,Assets.Scripts.Models.Towers.Weapons.WeaponModel)'></a>

## AttackModelExt.AddWeapon(this AttackModel, WeaponModel) Method

(Cross-Game compatible) Add a weapon to this Attack Model

```csharp
public static void AddWeapon(this Assets.Scripts.Models.Towers.Behaviors.Attack.AttackModel attackModel, Assets.Scripts.Models.Towers.Weapons.WeaponModel weaponToAdd);
```
#### Parameters

<a name='BTD_Mod_Helper.Extensions.AttackModelExt.AddWeapon(thisAssets.Scripts.Models.Towers.Behaviors.Attack.AttackModel,Assets.Scripts.Models.Towers.Weapons.WeaponModel).attackModel'></a>

`attackModel` [Assets.Scripts.Models.Towers.Behaviors.Attack.AttackModel](https://docs.microsoft.com/en-us/dotnet/api/Assets.Scripts.Models.Towers.Behaviors.Attack.AttackModel 'Assets.Scripts.Models.Towers.Behaviors.Attack.AttackModel')

<a name='BTD_Mod_Helper.Extensions.AttackModelExt.AddWeapon(thisAssets.Scripts.Models.Towers.Behaviors.Attack.AttackModel,Assets.Scripts.Models.Towers.Weapons.WeaponModel).weaponToAdd'></a>

`weaponToAdd` [Assets.Scripts.Models.Towers.Weapons.WeaponModel](https://docs.microsoft.com/en-us/dotnet/api/Assets.Scripts.Models.Towers.Weapons.WeaponModel 'Assets.Scripts.Models.Towers.Weapons.WeaponModel')

Weapon to add

<a name='BTD_Mod_Helper.Extensions.AttackModelExt.ApplyDisplay_T_(thisAssets.Scripts.Models.Towers.Behaviors.Attack.AttackModel,int)'></a>

## AttackModelExt.ApplyDisplay<T>(this AttackModel, int) Method

Applies the given ModDisplay to the index'th (or first) DisplayModel in the behaviors of the AttackModel.  
<br/>  
If there are no DisplayModels, then this does nothing

```csharp
public static void ApplyDisplay<T>(this Assets.Scripts.Models.Towers.Behaviors.Attack.AttackModel attackModel, int index=0)
    where T : BTD_Mod_Helper.Api.Display.ModDisplay;
```
#### Type parameters

<a name='BTD_Mod_Helper.Extensions.AttackModelExt.ApplyDisplay_T_(thisAssets.Scripts.Models.Towers.Behaviors.Attack.AttackModel,int).T'></a>

`T`
#### Parameters

<a name='BTD_Mod_Helper.Extensions.AttackModelExt.ApplyDisplay_T_(thisAssets.Scripts.Models.Towers.Behaviors.Attack.AttackModel,int).attackModel'></a>

`attackModel` [Assets.Scripts.Models.Towers.Behaviors.Attack.AttackModel](https://docs.microsoft.com/en-us/dotnet/api/Assets.Scripts.Models.Towers.Behaviors.Attack.AttackModel 'Assets.Scripts.Models.Towers.Behaviors.Attack.AttackModel')

<a name='BTD_Mod_Helper.Extensions.AttackModelExt.ApplyDisplay_T_(thisAssets.Scripts.Models.Towers.Behaviors.Attack.AttackModel,int).index'></a>

`index` [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/System.Int32 'System.Int32')

<a name='BTD_Mod_Helper.Extensions.AttackModelExt.GetAllProjectiles(thisAssets.Scripts.Models.Towers.Behaviors.Attack.AttackModel)'></a>

## AttackModelExt.GetAllProjectiles(this AttackModel) Method

(Cross-Game compatible) Recursively get all ProjectileModels for this attack model and all of it's weapons

```csharp
public static System.Collections.Generic.List<Assets.Scripts.Models.Towers.Projectiles.ProjectileModel> GetAllProjectiles(this Assets.Scripts.Models.Towers.Behaviors.Attack.AttackModel attackModel);
```
#### Parameters

<a name='BTD_Mod_Helper.Extensions.AttackModelExt.GetAllProjectiles(thisAssets.Scripts.Models.Towers.Behaviors.Attack.AttackModel).attackModel'></a>

`attackModel` [Assets.Scripts.Models.Towers.Behaviors.Attack.AttackModel](https://docs.microsoft.com/en-us/dotnet/api/Assets.Scripts.Models.Towers.Behaviors.Attack.AttackModel 'Assets.Scripts.Models.Towers.Behaviors.Attack.AttackModel')

#### Returns
[System.Collections.Generic.List&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.List-1 'System.Collections.Generic.List`1')[Assets.Scripts.Models.Towers.Projectiles.ProjectileModel](https://docs.microsoft.com/en-us/dotnet/api/Assets.Scripts.Models.Towers.Projectiles.ProjectileModel 'Assets.Scripts.Models.Towers.Projectiles.ProjectileModel')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.List-1 'System.Collections.Generic.List`1')

<a name='BTD_Mod_Helper.Extensions.AttackModelExt.RemoveWeapon(thisAssets.Scripts.Models.Towers.Behaviors.Attack.AttackModel,Assets.Scripts.Models.Towers.Weapons.WeaponModel)'></a>

## AttackModelExt.RemoveWeapon(this AttackModel, WeaponModel) Method

(Cross-Game compatible) Remove a weapon from this Attack Model

```csharp
public static void RemoveWeapon(this Assets.Scripts.Models.Towers.Behaviors.Attack.AttackModel attackModel, Assets.Scripts.Models.Towers.Weapons.WeaponModel weaponToRemove);
```
#### Parameters

<a name='BTD_Mod_Helper.Extensions.AttackModelExt.RemoveWeapon(thisAssets.Scripts.Models.Towers.Behaviors.Attack.AttackModel,Assets.Scripts.Models.Towers.Weapons.WeaponModel).attackModel'></a>

`attackModel` [Assets.Scripts.Models.Towers.Behaviors.Attack.AttackModel](https://docs.microsoft.com/en-us/dotnet/api/Assets.Scripts.Models.Towers.Behaviors.Attack.AttackModel 'Assets.Scripts.Models.Towers.Behaviors.Attack.AttackModel')

<a name='BTD_Mod_Helper.Extensions.AttackModelExt.RemoveWeapon(thisAssets.Scripts.Models.Towers.Behaviors.Attack.AttackModel,Assets.Scripts.Models.Towers.Weapons.WeaponModel).weaponToRemove'></a>

`weaponToRemove` [Assets.Scripts.Models.Towers.Weapons.WeaponModel](https://docs.microsoft.com/en-us/dotnet/api/Assets.Scripts.Models.Towers.Weapons.WeaponModel 'Assets.Scripts.Models.Towers.Weapons.WeaponModel')