#### [BloonsTD6 Mod Helper](README.md 'README')
### [BTD_Mod_Helper.Extensions](README.md#BTD_Mod_Helper.Extensions 'BTD_Mod_Helper.Extensions')

## WeaponBehaviorExt Class

Behavior extensions for Weapons

```csharp
public static class WeaponBehaviorExt
```

Inheritance [System.Object](https://docs.microsoft.com/en-us/dotnet/api/System.Object 'System.Object') &#129106; WeaponBehaviorExt
### Methods

<a name='BTD_Mod_Helper.Extensions.WeaponBehaviorExt.AddWeaponBehavior_T_(thisIl2CppAssets.Scripts.Simulation.Towers.Weapons.Weapon,T)'></a>

## WeaponBehaviorExt.AddWeaponBehavior<T>(this Weapon, T) Method

Add a Behavior to this

```csharp
public static void AddWeaponBehavior<T>(this Il2CppAssets.Scripts.Simulation.Towers.Weapons.Weapon weapon, T behavior)
    where T : Il2CppAssets.Scripts.Simulation.Towers.Weapons.WeaponBehavior;
```
#### Type parameters

<a name='BTD_Mod_Helper.Extensions.WeaponBehaviorExt.AddWeaponBehavior_T_(thisIl2CppAssets.Scripts.Simulation.Towers.Weapons.Weapon,T).T'></a>

`T`

The Behavior you want to add
#### Parameters

<a name='BTD_Mod_Helper.Extensions.WeaponBehaviorExt.AddWeaponBehavior_T_(thisIl2CppAssets.Scripts.Simulation.Towers.Weapons.Weapon,T).weapon'></a>

`weapon` [Il2CppAssets.Scripts.Simulation.Towers.Weapons.Weapon](https://docs.microsoft.com/en-us/dotnet/api/Il2CppAssets.Scripts.Simulation.Towers.Weapons.Weapon 'Il2CppAssets.Scripts.Simulation.Towers.Weapons.Weapon')

<a name='BTD_Mod_Helper.Extensions.WeaponBehaviorExt.AddWeaponBehavior_T_(thisIl2CppAssets.Scripts.Simulation.Towers.Weapons.Weapon,T).behavior'></a>

`behavior` [T](BTD_Mod_Helper.Extensions.WeaponBehaviorExt.md#BTD_Mod_Helper.Extensions.WeaponBehaviorExt.AddWeaponBehavior_T_(thisIl2CppAssets.Scripts.Simulation.Towers.Weapons.Weapon,T).T 'BTD_Mod_Helper.Extensions.WeaponBehaviorExt.AddWeaponBehavior<T>(this Il2CppAssets.Scripts.Simulation.Towers.Weapons.Weapon, T).T')

<a name='BTD_Mod_Helper.Extensions.WeaponBehaviorExt.GetWeaponBehavior_T_(thisIl2CppAssets.Scripts.Simulation.Towers.Weapons.Weapon)'></a>

## WeaponBehaviorExt.GetWeaponBehavior<T>(this Weapon) Method

Return the first Behavior of type T

```csharp
public static T GetWeaponBehavior<T>(this Il2CppAssets.Scripts.Simulation.Towers.Weapons.Weapon weapon)
    where T : Il2CppAssets.Scripts.Simulation.Towers.Weapons.WeaponBehavior;
```
#### Type parameters

<a name='BTD_Mod_Helper.Extensions.WeaponBehaviorExt.GetWeaponBehavior_T_(thisIl2CppAssets.Scripts.Simulation.Towers.Weapons.Weapon).T'></a>

`T`

The Behavior you want
#### Parameters

<a name='BTD_Mod_Helper.Extensions.WeaponBehaviorExt.GetWeaponBehavior_T_(thisIl2CppAssets.Scripts.Simulation.Towers.Weapons.Weapon).weapon'></a>

`weapon` [Il2CppAssets.Scripts.Simulation.Towers.Weapons.Weapon](https://docs.microsoft.com/en-us/dotnet/api/Il2CppAssets.Scripts.Simulation.Towers.Weapons.Weapon 'Il2CppAssets.Scripts.Simulation.Towers.Weapons.Weapon')

#### Returns
[T](BTD_Mod_Helper.Extensions.WeaponBehaviorExt.md#BTD_Mod_Helper.Extensions.WeaponBehaviorExt.GetWeaponBehavior_T_(thisIl2CppAssets.Scripts.Simulation.Towers.Weapons.Weapon).T 'BTD_Mod_Helper.Extensions.WeaponBehaviorExt.GetWeaponBehavior<T>(this Il2CppAssets.Scripts.Simulation.Towers.Weapons.Weapon).T')

<a name='BTD_Mod_Helper.Extensions.WeaponBehaviorExt.GetWeaponBehaviors_T_(thisIl2CppAssets.Scripts.Simulation.Towers.Weapons.Weapon)'></a>

## WeaponBehaviorExt.GetWeaponBehaviors<T>(this Weapon) Method

Return all Behaviors of type T

```csharp
public static System.Collections.Generic.List<T> GetWeaponBehaviors<T>(this Il2CppAssets.Scripts.Simulation.Towers.Weapons.Weapon weapon)
    where T : Il2CppAssets.Scripts.Simulation.Towers.Weapons.WeaponBehavior;
```
#### Type parameters

<a name='BTD_Mod_Helper.Extensions.WeaponBehaviorExt.GetWeaponBehaviors_T_(thisIl2CppAssets.Scripts.Simulation.Towers.Weapons.Weapon).T'></a>

`T`

The Behavior you want
#### Parameters

<a name='BTD_Mod_Helper.Extensions.WeaponBehaviorExt.GetWeaponBehaviors_T_(thisIl2CppAssets.Scripts.Simulation.Towers.Weapons.Weapon).weapon'></a>

`weapon` [Il2CppAssets.Scripts.Simulation.Towers.Weapons.Weapon](https://docs.microsoft.com/en-us/dotnet/api/Il2CppAssets.Scripts.Simulation.Towers.Weapons.Weapon 'Il2CppAssets.Scripts.Simulation.Towers.Weapons.Weapon')

#### Returns
[System.Collections.Generic.List&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.List-1 'System.Collections.Generic.List`1')[T](BTD_Mod_Helper.Extensions.WeaponBehaviorExt.md#BTD_Mod_Helper.Extensions.WeaponBehaviorExt.GetWeaponBehaviors_T_(thisIl2CppAssets.Scripts.Simulation.Towers.Weapons.Weapon).T 'BTD_Mod_Helper.Extensions.WeaponBehaviorExt.GetWeaponBehaviors<T>(this Il2CppAssets.Scripts.Simulation.Towers.Weapons.Weapon).T')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.List-1 'System.Collections.Generic.List`1')

<a name='BTD_Mod_Helper.Extensions.WeaponBehaviorExt.HasWeaponBehavior_T_(thisIl2CppAssets.Scripts.Simulation.Towers.Weapons.Weapon)'></a>

## WeaponBehaviorExt.HasWeaponBehavior<T>(this Weapon) Method

Check if this has a specific Behavior

```csharp
public static bool HasWeaponBehavior<T>(this Il2CppAssets.Scripts.Simulation.Towers.Weapons.Weapon weapon)
    where T : Il2CppAssets.Scripts.Simulation.Towers.Weapons.WeaponBehavior;
```
#### Type parameters

<a name='BTD_Mod_Helper.Extensions.WeaponBehaviorExt.HasWeaponBehavior_T_(thisIl2CppAssets.Scripts.Simulation.Towers.Weapons.Weapon).T'></a>

`T`

The Behavior you're checking for
#### Parameters

<a name='BTD_Mod_Helper.Extensions.WeaponBehaviorExt.HasWeaponBehavior_T_(thisIl2CppAssets.Scripts.Simulation.Towers.Weapons.Weapon).weapon'></a>

`weapon` [Il2CppAssets.Scripts.Simulation.Towers.Weapons.Weapon](https://docs.microsoft.com/en-us/dotnet/api/Il2CppAssets.Scripts.Simulation.Towers.Weapons.Weapon 'Il2CppAssets.Scripts.Simulation.Towers.Weapons.Weapon')

#### Returns
[System.Boolean](https://docs.microsoft.com/en-us/dotnet/api/System.Boolean 'System.Boolean')

<a name='BTD_Mod_Helper.Extensions.WeaponBehaviorExt.RemoveWeaponBehavior_T_(thisIl2CppAssets.Scripts.Simulation.Towers.Weapons.Weapon)'></a>

## WeaponBehaviorExt.RemoveWeaponBehavior<T>(this Weapon) Method

Remove the first Behavior of Type T

```csharp
public static void RemoveWeaponBehavior<T>(this Il2CppAssets.Scripts.Simulation.Towers.Weapons.Weapon weapon)
    where T : Il2CppAssets.Scripts.Simulation.Towers.Weapons.WeaponBehavior;
```
#### Type parameters

<a name='BTD_Mod_Helper.Extensions.WeaponBehaviorExt.RemoveWeaponBehavior_T_(thisIl2CppAssets.Scripts.Simulation.Towers.Weapons.Weapon).T'></a>

`T`

The Behavior you want to remove
#### Parameters

<a name='BTD_Mod_Helper.Extensions.WeaponBehaviorExt.RemoveWeaponBehavior_T_(thisIl2CppAssets.Scripts.Simulation.Towers.Weapons.Weapon).weapon'></a>

`weapon` [Il2CppAssets.Scripts.Simulation.Towers.Weapons.Weapon](https://docs.microsoft.com/en-us/dotnet/api/Il2CppAssets.Scripts.Simulation.Towers.Weapons.Weapon 'Il2CppAssets.Scripts.Simulation.Towers.Weapons.Weapon')

<a name='BTD_Mod_Helper.Extensions.WeaponBehaviorExt.RemoveWeaponBehavior_T_(thisIl2CppAssets.Scripts.Simulation.Towers.Weapons.Weapon,T)'></a>

## WeaponBehaviorExt.RemoveWeaponBehavior<T>(this Weapon, T) Method

Remove the first Behavior of type T

```csharp
public static void RemoveWeaponBehavior<T>(this Il2CppAssets.Scripts.Simulation.Towers.Weapons.Weapon weapon, T behavior)
    where T : Il2CppAssets.Scripts.Simulation.Towers.Weapons.WeaponBehavior;
```
#### Type parameters

<a name='BTD_Mod_Helper.Extensions.WeaponBehaviorExt.RemoveWeaponBehavior_T_(thisIl2CppAssets.Scripts.Simulation.Towers.Weapons.Weapon,T).T'></a>

`T`

The Behavior you want to remove
#### Parameters

<a name='BTD_Mod_Helper.Extensions.WeaponBehaviorExt.RemoveWeaponBehavior_T_(thisIl2CppAssets.Scripts.Simulation.Towers.Weapons.Weapon,T).weapon'></a>

`weapon` [Il2CppAssets.Scripts.Simulation.Towers.Weapons.Weapon](https://docs.microsoft.com/en-us/dotnet/api/Il2CppAssets.Scripts.Simulation.Towers.Weapons.Weapon 'Il2CppAssets.Scripts.Simulation.Towers.Weapons.Weapon')

<a name='BTD_Mod_Helper.Extensions.WeaponBehaviorExt.RemoveWeaponBehavior_T_(thisIl2CppAssets.Scripts.Simulation.Towers.Weapons.Weapon,T).behavior'></a>

`behavior` [T](BTD_Mod_Helper.Extensions.WeaponBehaviorExt.md#BTD_Mod_Helper.Extensions.WeaponBehaviorExt.RemoveWeaponBehavior_T_(thisIl2CppAssets.Scripts.Simulation.Towers.Weapons.Weapon,T).T 'BTD_Mod_Helper.Extensions.WeaponBehaviorExt.RemoveWeaponBehavior<T>(this Il2CppAssets.Scripts.Simulation.Towers.Weapons.Weapon, T).T')

<a name='BTD_Mod_Helper.Extensions.WeaponBehaviorExt.RemoveWeaponBehaviors_T_(thisIl2CppAssets.Scripts.Simulation.Towers.Weapons.Weapon)'></a>

## WeaponBehaviorExt.RemoveWeaponBehaviors<T>(this Weapon) Method

Remove all Behaviors of type T

```csharp
public static void RemoveWeaponBehaviors<T>(this Il2CppAssets.Scripts.Simulation.Towers.Weapons.Weapon weapon)
    where T : Il2CppAssets.Scripts.Simulation.Towers.Weapons.WeaponBehavior;
```
#### Type parameters

<a name='BTD_Mod_Helper.Extensions.WeaponBehaviorExt.RemoveWeaponBehaviors_T_(thisIl2CppAssets.Scripts.Simulation.Towers.Weapons.Weapon).T'></a>

`T`

The Behavior you want to remove
#### Parameters

<a name='BTD_Mod_Helper.Extensions.WeaponBehaviorExt.RemoveWeaponBehaviors_T_(thisIl2CppAssets.Scripts.Simulation.Towers.Weapons.Weapon).weapon'></a>

`weapon` [Il2CppAssets.Scripts.Simulation.Towers.Weapons.Weapon](https://docs.microsoft.com/en-us/dotnet/api/Il2CppAssets.Scripts.Simulation.Towers.Weapons.Weapon 'Il2CppAssets.Scripts.Simulation.Towers.Weapons.Weapon')