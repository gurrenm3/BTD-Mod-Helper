#### [BloonsTD6 Mod Helper](README.md 'README')
### [BTD_Mod_Helper.Extensions](README.md#BTD_Mod_Helper.Extensions 'BTD_Mod_Helper.Extensions')

## WeaponBehaviorExt Class

Behavior extensions for Weapons

```csharp
public static class WeaponBehaviorExt
```

Inheritance [System.Object](https://docs.microsoft.com/en-us/dotnet/api/System.Object 'System.Object') &#129106; WeaponBehaviorExt
### Methods

<a name='BTD_Mod_Helper.Extensions.WeaponBehaviorExt.AddWeaponBehavior_T_(thisWeapon,T)'></a>

## WeaponBehaviorExt.AddWeaponBehavior<T>(this Weapon, T) Method

Add a Behavior to this

```csharp
public static void AddWeaponBehavior<T>(this Weapon weapon, T behavior)
    where T : WeaponBehavior;
```
#### Type parameters

<a name='BTD_Mod_Helper.Extensions.WeaponBehaviorExt.AddWeaponBehavior_T_(thisWeapon,T).T'></a>

`T`

The Behavior you want to add
#### Parameters

<a name='BTD_Mod_Helper.Extensions.WeaponBehaviorExt.AddWeaponBehavior_T_(thisWeapon,T).weapon'></a>

`weapon` [Il2CppAssets.Scripts.Simulation.Towers.Weapons.Weapon](https://docs.microsoft.com/en-us/dotnet/api/Il2CppAssets.Scripts.Simulation.Towers.Weapons.Weapon 'Il2CppAssets.Scripts.Simulation.Towers.Weapons.Weapon')

<a name='BTD_Mod_Helper.Extensions.WeaponBehaviorExt.AddWeaponBehavior_T_(thisWeapon,T).behavior'></a>

`behavior` [T](BTD_Mod_Helper.Extensions.WeaponBehaviorExt.md#BTD_Mod_Helper.Extensions.WeaponBehaviorExt.AddWeaponBehavior_T_(thisWeapon,T).T 'BTD_Mod_Helper.Extensions.WeaponBehaviorExt.AddWeaponBehavior<T>(this Weapon, T).T')

<a name='BTD_Mod_Helper.Extensions.WeaponBehaviorExt.GetWeaponBehavior_T_(thisWeapon)'></a>

## WeaponBehaviorExt.GetWeaponBehavior<T>(this Weapon) Method

Return the first Behavior of type T

```csharp
public static T GetWeaponBehavior<T>(this Weapon weapon)
    where T : WeaponBehavior;
```
#### Type parameters

<a name='BTD_Mod_Helper.Extensions.WeaponBehaviorExt.GetWeaponBehavior_T_(thisWeapon).T'></a>

`T`

The Behavior you want
#### Parameters

<a name='BTD_Mod_Helper.Extensions.WeaponBehaviorExt.GetWeaponBehavior_T_(thisWeapon).weapon'></a>

`weapon` [Il2CppAssets.Scripts.Simulation.Towers.Weapons.Weapon](https://docs.microsoft.com/en-us/dotnet/api/Il2CppAssets.Scripts.Simulation.Towers.Weapons.Weapon 'Il2CppAssets.Scripts.Simulation.Towers.Weapons.Weapon')

#### Returns
[T](BTD_Mod_Helper.Extensions.WeaponBehaviorExt.md#BTD_Mod_Helper.Extensions.WeaponBehaviorExt.GetWeaponBehavior_T_(thisWeapon).T 'BTD_Mod_Helper.Extensions.WeaponBehaviorExt.GetWeaponBehavior<T>(this Weapon).T')

<a name='BTD_Mod_Helper.Extensions.WeaponBehaviorExt.GetWeaponBehaviors_T_(thisWeapon)'></a>

## WeaponBehaviorExt.GetWeaponBehaviors<T>(this Weapon) Method

Return all Behaviors of type T

```csharp
public static System.Collections.Generic.List<T> GetWeaponBehaviors<T>(this Weapon weapon)
    where T : WeaponBehavior;
```
#### Type parameters

<a name='BTD_Mod_Helper.Extensions.WeaponBehaviorExt.GetWeaponBehaviors_T_(thisWeapon).T'></a>

`T`

The Behavior you want
#### Parameters

<a name='BTD_Mod_Helper.Extensions.WeaponBehaviorExt.GetWeaponBehaviors_T_(thisWeapon).weapon'></a>

`weapon` [Il2CppAssets.Scripts.Simulation.Towers.Weapons.Weapon](https://docs.microsoft.com/en-us/dotnet/api/Il2CppAssets.Scripts.Simulation.Towers.Weapons.Weapon 'Il2CppAssets.Scripts.Simulation.Towers.Weapons.Weapon')

#### Returns
[System.Collections.Generic.List&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.List-1 'System.Collections.Generic.List`1')[T](BTD_Mod_Helper.Extensions.WeaponBehaviorExt.md#BTD_Mod_Helper.Extensions.WeaponBehaviorExt.GetWeaponBehaviors_T_(thisWeapon).T 'BTD_Mod_Helper.Extensions.WeaponBehaviorExt.GetWeaponBehaviors<T>(this Weapon).T')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.List-1 'System.Collections.Generic.List`1')

<a name='BTD_Mod_Helper.Extensions.WeaponBehaviorExt.HasWeaponBehavior_T_(thisWeapon)'></a>

## WeaponBehaviorExt.HasWeaponBehavior<T>(this Weapon) Method

Check if this has a specific Behavior

```csharp
public static bool HasWeaponBehavior<T>(this Weapon weapon)
    where T : WeaponBehavior;
```
#### Type parameters

<a name='BTD_Mod_Helper.Extensions.WeaponBehaviorExt.HasWeaponBehavior_T_(thisWeapon).T'></a>

`T`

The Behavior you're checking for
#### Parameters

<a name='BTD_Mod_Helper.Extensions.WeaponBehaviorExt.HasWeaponBehavior_T_(thisWeapon).weapon'></a>

`weapon` [Il2CppAssets.Scripts.Simulation.Towers.Weapons.Weapon](https://docs.microsoft.com/en-us/dotnet/api/Il2CppAssets.Scripts.Simulation.Towers.Weapons.Weapon 'Il2CppAssets.Scripts.Simulation.Towers.Weapons.Weapon')

#### Returns
[System.Boolean](https://docs.microsoft.com/en-us/dotnet/api/System.Boolean 'System.Boolean')

<a name='BTD_Mod_Helper.Extensions.WeaponBehaviorExt.RemoveWeaponBehavior_T_(thisWeapon,T)'></a>

## WeaponBehaviorExt.RemoveWeaponBehavior<T>(this Weapon, T) Method

Remove the first Behavior of type T

```csharp
public static void RemoveWeaponBehavior<T>(this Weapon weapon, T behavior)
    where T : WeaponBehavior;
```
#### Type parameters

<a name='BTD_Mod_Helper.Extensions.WeaponBehaviorExt.RemoveWeaponBehavior_T_(thisWeapon,T).T'></a>

`T`

The Behavior you want to remove
#### Parameters

<a name='BTD_Mod_Helper.Extensions.WeaponBehaviorExt.RemoveWeaponBehavior_T_(thisWeapon,T).weapon'></a>

`weapon` [Il2CppAssets.Scripts.Simulation.Towers.Weapons.Weapon](https://docs.microsoft.com/en-us/dotnet/api/Il2CppAssets.Scripts.Simulation.Towers.Weapons.Weapon 'Il2CppAssets.Scripts.Simulation.Towers.Weapons.Weapon')

<a name='BTD_Mod_Helper.Extensions.WeaponBehaviorExt.RemoveWeaponBehavior_T_(thisWeapon,T).behavior'></a>

`behavior` [T](BTD_Mod_Helper.Extensions.WeaponBehaviorExt.md#BTD_Mod_Helper.Extensions.WeaponBehaviorExt.RemoveWeaponBehavior_T_(thisWeapon,T).T 'BTD_Mod_Helper.Extensions.WeaponBehaviorExt.RemoveWeaponBehavior<T>(this Weapon, T).T')

<a name='BTD_Mod_Helper.Extensions.WeaponBehaviorExt.RemoveWeaponBehavior_T_(thisWeapon)'></a>

## WeaponBehaviorExt.RemoveWeaponBehavior<T>(this Weapon) Method

Remove the first Behavior of Type T

```csharp
public static void RemoveWeaponBehavior<T>(this Weapon weapon)
    where T : WeaponBehavior;
```
#### Type parameters

<a name='BTD_Mod_Helper.Extensions.WeaponBehaviorExt.RemoveWeaponBehavior_T_(thisWeapon).T'></a>

`T`

The Behavior you want to remove
#### Parameters

<a name='BTD_Mod_Helper.Extensions.WeaponBehaviorExt.RemoveWeaponBehavior_T_(thisWeapon).weapon'></a>

`weapon` [Il2CppAssets.Scripts.Simulation.Towers.Weapons.Weapon](https://docs.microsoft.com/en-us/dotnet/api/Il2CppAssets.Scripts.Simulation.Towers.Weapons.Weapon 'Il2CppAssets.Scripts.Simulation.Towers.Weapons.Weapon')

<a name='BTD_Mod_Helper.Extensions.WeaponBehaviorExt.RemoveWeaponBehaviors_T_(thisWeapon)'></a>

## WeaponBehaviorExt.RemoveWeaponBehaviors<T>(this Weapon) Method

Remove all Behaviors of type T

```csharp
public static void RemoveWeaponBehaviors<T>(this Weapon weapon)
    where T : WeaponBehavior;
```
#### Type parameters

<a name='BTD_Mod_Helper.Extensions.WeaponBehaviorExt.RemoveWeaponBehaviors_T_(thisWeapon).T'></a>

`T`

The Behavior you want to remove
#### Parameters

<a name='BTD_Mod_Helper.Extensions.WeaponBehaviorExt.RemoveWeaponBehaviors_T_(thisWeapon).weapon'></a>

`weapon` [Il2CppAssets.Scripts.Simulation.Towers.Weapons.Weapon](https://docs.microsoft.com/en-us/dotnet/api/Il2CppAssets.Scripts.Simulation.Towers.Weapons.Weapon 'Il2CppAssets.Scripts.Simulation.Towers.Weapons.Weapon')