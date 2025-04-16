#### [BloonsTD6 Mod Helper](README.md 'README')
### [BTD_Mod_Helper.Extensions](README.md#BTD_Mod_Helper.Extensions 'BTD_Mod_Helper.Extensions')

## AttackModelExt Class

Extensions for AttackModels

```csharp
public static class AttackModelExt
```

Inheritance [System.Object](https://docs.microsoft.com/en-us/dotnet/api/System.Object 'System.Object') &#129106; AttackModelExt
### Methods

<a name='BTD_Mod_Helper.Extensions.AttackModelExt.AddFilter(thisAttackModel,FilterModel)'></a>

## AttackModelExt.AddFilter(this AttackModel, FilterModel) Method

Adds a new filter to this projectile model

```csharp
public static void AddFilter(this AttackModel attack, FilterModel filter);
```
#### Parameters

<a name='BTD_Mod_Helper.Extensions.AttackModelExt.AddFilter(thisAttackModel,FilterModel).attack'></a>

`attack` [Il2CppAssets.Scripts.Models.Towers.Behaviors.Attack.AttackModel](https://docs.microsoft.com/en-us/dotnet/api/Il2CppAssets.Scripts.Models.Towers.Behaviors.Attack.AttackModel 'Il2CppAssets.Scripts.Models.Towers.Behaviors.Attack.AttackModel')

<a name='BTD_Mod_Helper.Extensions.AttackModelExt.AddFilter(thisAttackModel,FilterModel).filter'></a>

`filter` [Il2CppAssets.Scripts.Models.Towers.Filters.FilterModel](https://docs.microsoft.com/en-us/dotnet/api/Il2CppAssets.Scripts.Models.Towers.Filters.FilterModel 'Il2CppAssets.Scripts.Models.Towers.Filters.FilterModel')

<a name='BTD_Mod_Helper.Extensions.AttackModelExt.AddWeapon(thisAttackModel,WeaponModel)'></a>

## AttackModelExt.AddWeapon(this AttackModel, WeaponModel) Method

Add a weapon to this Attack Model

```csharp
public static void AddWeapon(this AttackModel attackModel, WeaponModel weaponToAdd);
```
#### Parameters

<a name='BTD_Mod_Helper.Extensions.AttackModelExt.AddWeapon(thisAttackModel,WeaponModel).attackModel'></a>

`attackModel` [Il2CppAssets.Scripts.Models.Towers.Behaviors.Attack.AttackModel](https://docs.microsoft.com/en-us/dotnet/api/Il2CppAssets.Scripts.Models.Towers.Behaviors.Attack.AttackModel 'Il2CppAssets.Scripts.Models.Towers.Behaviors.Attack.AttackModel')

this

<a name='BTD_Mod_Helper.Extensions.AttackModelExt.AddWeapon(thisAttackModel,WeaponModel).weaponToAdd'></a>

`weaponToAdd` [Il2CppAssets.Scripts.Models.Towers.Weapons.WeaponModel](https://docs.microsoft.com/en-us/dotnet/api/Il2CppAssets.Scripts.Models.Towers.Weapons.WeaponModel 'Il2CppAssets.Scripts.Models.Towers.Weapons.WeaponModel')

Weapon to add

<a name='BTD_Mod_Helper.Extensions.AttackModelExt.ApplyDisplay_T_(thisAttackModel,int)'></a>

## AttackModelExt.ApplyDisplay<T>(this AttackModel, int) Method

Applies the given ModDisplay to the index'th (or first) DisplayModel in the behaviors of the AttackModel.  
<br/>  
If there are no DisplayModels, then this does nothing

```csharp
public static void ApplyDisplay<T>(this AttackModel attackModel, int index=0)
    where T : BTD_Mod_Helper.Api.Display.ModDisplay;
```
#### Type parameters

<a name='BTD_Mod_Helper.Extensions.AttackModelExt.ApplyDisplay_T_(thisAttackModel,int).T'></a>

`T`
#### Parameters

<a name='BTD_Mod_Helper.Extensions.AttackModelExt.ApplyDisplay_T_(thisAttackModel,int).attackModel'></a>

`attackModel` [Il2CppAssets.Scripts.Models.Towers.Behaviors.Attack.AttackModel](https://docs.microsoft.com/en-us/dotnet/api/Il2CppAssets.Scripts.Models.Towers.Behaviors.Attack.AttackModel 'Il2CppAssets.Scripts.Models.Towers.Behaviors.Attack.AttackModel')

<a name='BTD_Mod_Helper.Extensions.AttackModelExt.ApplyDisplay_T_(thisAttackModel,int).index'></a>

`index` [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/System.Int32 'System.Int32')

<a name='BTD_Mod_Helper.Extensions.AttackModelExt.GetAllProjectiles(thisAttackModel)'></a>

## AttackModelExt.GetAllProjectiles(this AttackModel) Method

Recursively get all ProjectileModels for this attack model and all of it's weapons

```csharp
public static System.Collections.Generic.List<ProjectileModel> GetAllProjectiles(this AttackModel attackModel);
```
#### Parameters

<a name='BTD_Mod_Helper.Extensions.AttackModelExt.GetAllProjectiles(thisAttackModel).attackModel'></a>

`attackModel` [Il2CppAssets.Scripts.Models.Towers.Behaviors.Attack.AttackModel](https://docs.microsoft.com/en-us/dotnet/api/Il2CppAssets.Scripts.Models.Towers.Behaviors.Attack.AttackModel 'Il2CppAssets.Scripts.Models.Towers.Behaviors.Attack.AttackModel')

#### Returns
[System.Collections.Generic.List&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.List-1 'System.Collections.Generic.List`1')[Il2CppAssets.Scripts.Models.Towers.Projectiles.ProjectileModel](https://docs.microsoft.com/en-us/dotnet/api/Il2CppAssets.Scripts.Models.Towers.Projectiles.ProjectileModel 'Il2CppAssets.Scripts.Models.Towers.Projectiles.ProjectileModel')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.List-1 'System.Collections.Generic.List`1')

<a name='BTD_Mod_Helper.Extensions.AttackModelExt.RemoveFilter(thisAttackModel,FilterModel)'></a>

## AttackModelExt.RemoveFilter(this AttackModel, FilterModel) Method

Removes a specific filter from this attack model

```csharp
public static void RemoveFilter(this AttackModel attack, FilterModel filter);
```
#### Parameters

<a name='BTD_Mod_Helper.Extensions.AttackModelExt.RemoveFilter(thisAttackModel,FilterModel).attack'></a>

`attack` [Il2CppAssets.Scripts.Models.Towers.Behaviors.Attack.AttackModel](https://docs.microsoft.com/en-us/dotnet/api/Il2CppAssets.Scripts.Models.Towers.Behaviors.Attack.AttackModel 'Il2CppAssets.Scripts.Models.Towers.Behaviors.Attack.AttackModel')

<a name='BTD_Mod_Helper.Extensions.AttackModelExt.RemoveFilter(thisAttackModel,FilterModel).filter'></a>

`filter` [Il2CppAssets.Scripts.Models.Towers.Filters.FilterModel](https://docs.microsoft.com/en-us/dotnet/api/Il2CppAssets.Scripts.Models.Towers.Filters.FilterModel 'Il2CppAssets.Scripts.Models.Towers.Filters.FilterModel')

<a name='BTD_Mod_Helper.Extensions.AttackModelExt.RemoveFilter_T_(thisAttackModel)'></a>

## AttackModelExt.RemoveFilter<T>(this AttackModel) Method

Removes the first filter of a given type from this attack model

```csharp
public static void RemoveFilter<T>(this AttackModel attack)
    where T : FilterModel;
```
#### Type parameters

<a name='BTD_Mod_Helper.Extensions.AttackModelExt.RemoveFilter_T_(thisAttackModel).T'></a>

`T`
#### Parameters

<a name='BTD_Mod_Helper.Extensions.AttackModelExt.RemoveFilter_T_(thisAttackModel).attack'></a>

`attack` [Il2CppAssets.Scripts.Models.Towers.Behaviors.Attack.AttackModel](https://docs.microsoft.com/en-us/dotnet/api/Il2CppAssets.Scripts.Models.Towers.Behaviors.Attack.AttackModel 'Il2CppAssets.Scripts.Models.Towers.Behaviors.Attack.AttackModel')

<a name='BTD_Mod_Helper.Extensions.AttackModelExt.RemoveWeapon(thisAttackModel,WeaponModel)'></a>

## AttackModelExt.RemoveWeapon(this AttackModel, WeaponModel) Method

Remove a weapon from this Attack Model

```csharp
public static void RemoveWeapon(this AttackModel attackModel, WeaponModel weaponToRemove);
```
#### Parameters

<a name='BTD_Mod_Helper.Extensions.AttackModelExt.RemoveWeapon(thisAttackModel,WeaponModel).attackModel'></a>

`attackModel` [Il2CppAssets.Scripts.Models.Towers.Behaviors.Attack.AttackModel](https://docs.microsoft.com/en-us/dotnet/api/Il2CppAssets.Scripts.Models.Towers.Behaviors.Attack.AttackModel 'Il2CppAssets.Scripts.Models.Towers.Behaviors.Attack.AttackModel')

this

<a name='BTD_Mod_Helper.Extensions.AttackModelExt.RemoveWeapon(thisAttackModel,WeaponModel).weaponToRemove'></a>

`weaponToRemove` [Il2CppAssets.Scripts.Models.Towers.Weapons.WeaponModel](https://docs.microsoft.com/en-us/dotnet/api/Il2CppAssets.Scripts.Models.Towers.Weapons.WeaponModel 'Il2CppAssets.Scripts.Models.Towers.Weapons.WeaponModel')

Weapon to remove

<a name='BTD_Mod_Helper.Extensions.AttackModelExt.SetWeapon(thisAttackModel,WeaponModel,int)'></a>

## AttackModelExt.SetWeapon(this AttackModel, WeaponModel, int) Method

Sets the weapon at the given index (default 0) of this attack model to be the given one.

```csharp
public static void SetWeapon(this AttackModel attackModel, WeaponModel weaponModel, int index=0);
```
#### Parameters

<a name='BTD_Mod_Helper.Extensions.AttackModelExt.SetWeapon(thisAttackModel,WeaponModel,int).attackModel'></a>

`attackModel` [Il2CppAssets.Scripts.Models.Towers.Behaviors.Attack.AttackModel](https://docs.microsoft.com/en-us/dotnet/api/Il2CppAssets.Scripts.Models.Towers.Behaviors.Attack.AttackModel 'Il2CppAssets.Scripts.Models.Towers.Behaviors.Attack.AttackModel')

this

<a name='BTD_Mod_Helper.Extensions.AttackModelExt.SetWeapon(thisAttackModel,WeaponModel,int).weaponModel'></a>

`weaponModel` [Il2CppAssets.Scripts.Models.Towers.Weapons.WeaponModel](https://docs.microsoft.com/en-us/dotnet/api/Il2CppAssets.Scripts.Models.Towers.Weapons.WeaponModel 'Il2CppAssets.Scripts.Models.Towers.Weapons.WeaponModel')

Weapon to add

<a name='BTD_Mod_Helper.Extensions.AttackModelExt.SetWeapon(thisAttackModel,WeaponModel,int).index'></a>

`index` [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/System.Int32 'System.Int32')

Index within weapons array

#### Exceptions

[System.ArgumentException](https://docs.microsoft.com/en-us/dotnet/api/System.ArgumentException 'System.ArgumentException')  
thrown when index < 0