#### [BloonsTD6 Mod Helper](README.md 'README')
### [BTD_Mod_Helper.Extensions](README.md#BTD_Mod_Helper.Extensions 'BTD_Mod_Helper.Extensions')

## AttackBehaviorExt Class

Behavior extensions for attacks

```csharp
public static class AttackBehaviorExt
```

Inheritance [System.Object](https://docs.microsoft.com/en-us/dotnet/api/System.Object 'System.Object') &#129106; AttackBehaviorExt
### Methods

<a name='BTD_Mod_Helper.Extensions.AttackBehaviorExt.AddAttackBehavior_T_(thisAssets.Scripts.Simulation.Towers.Behaviors.Attack.Attack,T)'></a>

## AttackBehaviorExt.AddAttackBehavior<T>(this Attack, T) Method

Add a Behavior to this

```csharp
public static void AddAttackBehavior<T>(this Assets.Scripts.Simulation.Towers.Behaviors.Attack.Attack attack, T behavior)
    where T : Assets.Scripts.Simulation.Towers.Behaviors.Attack.AttackBehavior;
```
#### Type parameters

<a name='BTD_Mod_Helper.Extensions.AttackBehaviorExt.AddAttackBehavior_T_(thisAssets.Scripts.Simulation.Towers.Behaviors.Attack.Attack,T).T'></a>

`T`

The Behavior you want to add
#### Parameters

<a name='BTD_Mod_Helper.Extensions.AttackBehaviorExt.AddAttackBehavior_T_(thisAssets.Scripts.Simulation.Towers.Behaviors.Attack.Attack,T).attack'></a>

`attack` [Assets.Scripts.Simulation.Towers.Behaviors.Attack.Attack](https://docs.microsoft.com/en-us/dotnet/api/Assets.Scripts.Simulation.Towers.Behaviors.Attack.Attack 'Assets.Scripts.Simulation.Towers.Behaviors.Attack.Attack')

<a name='BTD_Mod_Helper.Extensions.AttackBehaviorExt.AddAttackBehavior_T_(thisAssets.Scripts.Simulation.Towers.Behaviors.Attack.Attack,T).behavior'></a>

`behavior` [T](BTD_Mod_Helper.Extensions.AttackBehaviorExt.md#BTD_Mod_Helper.Extensions.AttackBehaviorExt.AddAttackBehavior_T_(thisAssets.Scripts.Simulation.Towers.Behaviors.Attack.Attack,T).T 'BTD_Mod_Helper.Extensions.AttackBehaviorExt.AddAttackBehavior<T>(this Assets.Scripts.Simulation.Towers.Behaviors.Attack.Attack, T).T')

<a name='BTD_Mod_Helper.Extensions.AttackBehaviorExt.GetAttackBehavior_T_(thisAssets.Scripts.Simulation.Towers.Behaviors.Attack.Attack)'></a>

## AttackBehaviorExt.GetAttackBehavior<T>(this Attack) Method

Return the first Behavior of type T

```csharp
public static T GetAttackBehavior<T>(this Assets.Scripts.Simulation.Towers.Behaviors.Attack.Attack attack)
    where T : Assets.Scripts.Simulation.Towers.Behaviors.Attack.AttackBehavior;
```
#### Type parameters

<a name='BTD_Mod_Helper.Extensions.AttackBehaviorExt.GetAttackBehavior_T_(thisAssets.Scripts.Simulation.Towers.Behaviors.Attack.Attack).T'></a>

`T`

The Behavior you want
#### Parameters

<a name='BTD_Mod_Helper.Extensions.AttackBehaviorExt.GetAttackBehavior_T_(thisAssets.Scripts.Simulation.Towers.Behaviors.Attack.Attack).attack'></a>

`attack` [Assets.Scripts.Simulation.Towers.Behaviors.Attack.Attack](https://docs.microsoft.com/en-us/dotnet/api/Assets.Scripts.Simulation.Towers.Behaviors.Attack.Attack 'Assets.Scripts.Simulation.Towers.Behaviors.Attack.Attack')

#### Returns
[T](BTD_Mod_Helper.Extensions.AttackBehaviorExt.md#BTD_Mod_Helper.Extensions.AttackBehaviorExt.GetAttackBehavior_T_(thisAssets.Scripts.Simulation.Towers.Behaviors.Attack.Attack).T 'BTD_Mod_Helper.Extensions.AttackBehaviorExt.GetAttackBehavior<T>(this Assets.Scripts.Simulation.Towers.Behaviors.Attack.Attack).T')

<a name='BTD_Mod_Helper.Extensions.AttackBehaviorExt.GetAttackBehaviors_T_(thisAssets.Scripts.Simulation.Towers.Behaviors.Attack.Attack)'></a>

## AttackBehaviorExt.GetAttackBehaviors<T>(this Attack) Method

Return all Behaviors of type T

```csharp
public static System.Collections.Generic.List<T> GetAttackBehaviors<T>(this Assets.Scripts.Simulation.Towers.Behaviors.Attack.Attack attack)
    where T : Assets.Scripts.Simulation.Towers.Behaviors.Attack.AttackBehavior;
```
#### Type parameters

<a name='BTD_Mod_Helper.Extensions.AttackBehaviorExt.GetAttackBehaviors_T_(thisAssets.Scripts.Simulation.Towers.Behaviors.Attack.Attack).T'></a>

`T`

The Behavior you want
#### Parameters

<a name='BTD_Mod_Helper.Extensions.AttackBehaviorExt.GetAttackBehaviors_T_(thisAssets.Scripts.Simulation.Towers.Behaviors.Attack.Attack).attack'></a>

`attack` [Assets.Scripts.Simulation.Towers.Behaviors.Attack.Attack](https://docs.microsoft.com/en-us/dotnet/api/Assets.Scripts.Simulation.Towers.Behaviors.Attack.Attack 'Assets.Scripts.Simulation.Towers.Behaviors.Attack.Attack')

#### Returns
[System.Collections.Generic.List&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.List-1 'System.Collections.Generic.List`1')[T](BTD_Mod_Helper.Extensions.AttackBehaviorExt.md#BTD_Mod_Helper.Extensions.AttackBehaviorExt.GetAttackBehaviors_T_(thisAssets.Scripts.Simulation.Towers.Behaviors.Attack.Attack).T 'BTD_Mod_Helper.Extensions.AttackBehaviorExt.GetAttackBehaviors<T>(this Assets.Scripts.Simulation.Towers.Behaviors.Attack.Attack).T')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.List-1 'System.Collections.Generic.List`1')

<a name='BTD_Mod_Helper.Extensions.AttackBehaviorExt.HasAttackBehavior_T_(thisAssets.Scripts.Simulation.Towers.Behaviors.Attack.Attack)'></a>

## AttackBehaviorExt.HasAttackBehavior<T>(this Attack) Method

Check if this has a specific Behavior

```csharp
public static bool HasAttackBehavior<T>(this Assets.Scripts.Simulation.Towers.Behaviors.Attack.Attack attack)
    where T : Assets.Scripts.Simulation.Towers.Behaviors.Attack.AttackBehavior;
```
#### Type parameters

<a name='BTD_Mod_Helper.Extensions.AttackBehaviorExt.HasAttackBehavior_T_(thisAssets.Scripts.Simulation.Towers.Behaviors.Attack.Attack).T'></a>

`T`

The Behavior you're checking for
#### Parameters

<a name='BTD_Mod_Helper.Extensions.AttackBehaviorExt.HasAttackBehavior_T_(thisAssets.Scripts.Simulation.Towers.Behaviors.Attack.Attack).attack'></a>

`attack` [Assets.Scripts.Simulation.Towers.Behaviors.Attack.Attack](https://docs.microsoft.com/en-us/dotnet/api/Assets.Scripts.Simulation.Towers.Behaviors.Attack.Attack 'Assets.Scripts.Simulation.Towers.Behaviors.Attack.Attack')

#### Returns
[System.Boolean](https://docs.microsoft.com/en-us/dotnet/api/System.Boolean 'System.Boolean')

<a name='BTD_Mod_Helper.Extensions.AttackBehaviorExt.RemoveAttackBehavior_T_(thisAssets.Scripts.Simulation.Towers.Behaviors.Attack.Attack)'></a>

## AttackBehaviorExt.RemoveAttackBehavior<T>(this Attack) Method

Remove the first Behavior of Type T

```csharp
public static void RemoveAttackBehavior<T>(this Assets.Scripts.Simulation.Towers.Behaviors.Attack.Attack attack)
    where T : Assets.Scripts.Simulation.Towers.Behaviors.Attack.AttackBehavior;
```
#### Type parameters

<a name='BTD_Mod_Helper.Extensions.AttackBehaviorExt.RemoveAttackBehavior_T_(thisAssets.Scripts.Simulation.Towers.Behaviors.Attack.Attack).T'></a>

`T`

The Behavior you want to remove
#### Parameters

<a name='BTD_Mod_Helper.Extensions.AttackBehaviorExt.RemoveAttackBehavior_T_(thisAssets.Scripts.Simulation.Towers.Behaviors.Attack.Attack).attack'></a>

`attack` [Assets.Scripts.Simulation.Towers.Behaviors.Attack.Attack](https://docs.microsoft.com/en-us/dotnet/api/Assets.Scripts.Simulation.Towers.Behaviors.Attack.Attack 'Assets.Scripts.Simulation.Towers.Behaviors.Attack.Attack')

<a name='BTD_Mod_Helper.Extensions.AttackBehaviorExt.RemoveAttackBehavior_T_(thisAssets.Scripts.Simulation.Towers.Behaviors.Attack.Attack,T)'></a>

## AttackBehaviorExt.RemoveAttackBehavior<T>(this Attack, T) Method

Remove the first Behavior of type T

```csharp
public static void RemoveAttackBehavior<T>(this Assets.Scripts.Simulation.Towers.Behaviors.Attack.Attack attack, T behavior)
    where T : Assets.Scripts.Simulation.Towers.Behaviors.Attack.AttackBehavior;
```
#### Type parameters

<a name='BTD_Mod_Helper.Extensions.AttackBehaviorExt.RemoveAttackBehavior_T_(thisAssets.Scripts.Simulation.Towers.Behaviors.Attack.Attack,T).T'></a>

`T`

The Behavior you want to remove
#### Parameters

<a name='BTD_Mod_Helper.Extensions.AttackBehaviorExt.RemoveAttackBehavior_T_(thisAssets.Scripts.Simulation.Towers.Behaviors.Attack.Attack,T).attack'></a>

`attack` [Assets.Scripts.Simulation.Towers.Behaviors.Attack.Attack](https://docs.microsoft.com/en-us/dotnet/api/Assets.Scripts.Simulation.Towers.Behaviors.Attack.Attack 'Assets.Scripts.Simulation.Towers.Behaviors.Attack.Attack')

<a name='BTD_Mod_Helper.Extensions.AttackBehaviorExt.RemoveAttackBehavior_T_(thisAssets.Scripts.Simulation.Towers.Behaviors.Attack.Attack,T).behavior'></a>

`behavior` [T](BTD_Mod_Helper.Extensions.AttackBehaviorExt.md#BTD_Mod_Helper.Extensions.AttackBehaviorExt.RemoveAttackBehavior_T_(thisAssets.Scripts.Simulation.Towers.Behaviors.Attack.Attack,T).T 'BTD_Mod_Helper.Extensions.AttackBehaviorExt.RemoveAttackBehavior<T>(this Assets.Scripts.Simulation.Towers.Behaviors.Attack.Attack, T).T')

<a name='BTD_Mod_Helper.Extensions.AttackBehaviorExt.RemoveAttackBehaviors_T_(thisAssets.Scripts.Simulation.Towers.Behaviors.Attack.Attack)'></a>

## AttackBehaviorExt.RemoveAttackBehaviors<T>(this Attack) Method

Remove all Behaviors of type T

```csharp
public static void RemoveAttackBehaviors<T>(this Assets.Scripts.Simulation.Towers.Behaviors.Attack.Attack attack)
    where T : Assets.Scripts.Simulation.Towers.Behaviors.Attack.AttackBehavior;
```
#### Type parameters

<a name='BTD_Mod_Helper.Extensions.AttackBehaviorExt.RemoveAttackBehaviors_T_(thisAssets.Scripts.Simulation.Towers.Behaviors.Attack.Attack).T'></a>

`T`

The Behavior you want to remove
#### Parameters

<a name='BTD_Mod_Helper.Extensions.AttackBehaviorExt.RemoveAttackBehaviors_T_(thisAssets.Scripts.Simulation.Towers.Behaviors.Attack.Attack).attack'></a>

`attack` [Assets.Scripts.Simulation.Towers.Behaviors.Attack.Attack](https://docs.microsoft.com/en-us/dotnet/api/Assets.Scripts.Simulation.Towers.Behaviors.Attack.Attack 'Assets.Scripts.Simulation.Towers.Behaviors.Attack.Attack')