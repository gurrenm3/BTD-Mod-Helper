#### [BloonsTD6 Mod Helper](README.md 'README')
### [BTD_Mod_Helper.Extensions](README.md#BTD_Mod_Helper.Extensions 'BTD_Mod_Helper.Extensions')

## AttackBehaviorExt Class

Behavior extensions for attacks

```csharp
public static class AttackBehaviorExt
```

Inheritance [System.Object](https://docs.microsoft.com/en-us/dotnet/api/System.Object 'System.Object') &#129106; AttackBehaviorExt
### Methods

<a name='BTD_Mod_Helper.Extensions.AttackBehaviorExt.AddAttackBehavior_T_(thisAttack,T)'></a>

## AttackBehaviorExt.AddAttackBehavior<T>(this Attack, T) Method

Add a Behavior to this

```csharp
public static void AddAttackBehavior<T>(this Attack attack, T behavior)
    where T : AttackBehavior;
```
#### Type parameters

<a name='BTD_Mod_Helper.Extensions.AttackBehaviorExt.AddAttackBehavior_T_(thisAttack,T).T'></a>

`T`

The Behavior you want to add
#### Parameters

<a name='BTD_Mod_Helper.Extensions.AttackBehaviorExt.AddAttackBehavior_T_(thisAttack,T).attack'></a>

`attack` [Il2CppAssets.Scripts.Simulation.Towers.Behaviors.Attack.Attack](https://docs.microsoft.com/en-us/dotnet/api/Il2CppAssets.Scripts.Simulation.Towers.Behaviors.Attack.Attack 'Il2CppAssets.Scripts.Simulation.Towers.Behaviors.Attack.Attack')

<a name='BTD_Mod_Helper.Extensions.AttackBehaviorExt.AddAttackBehavior_T_(thisAttack,T).behavior'></a>

`behavior` [T](BTD_Mod_Helper.Extensions.AttackBehaviorExt.md#BTD_Mod_Helper.Extensions.AttackBehaviorExt.AddAttackBehavior_T_(thisAttack,T).T 'BTD_Mod_Helper.Extensions.AttackBehaviorExt.AddAttackBehavior<T>(this Attack, T).T')

<a name='BTD_Mod_Helper.Extensions.AttackBehaviorExt.GetAttackBehavior_T_(thisAttack)'></a>

## AttackBehaviorExt.GetAttackBehavior<T>(this Attack) Method

Return the first Behavior of type T

```csharp
public static T GetAttackBehavior<T>(this Attack attack)
    where T : AttackBehavior;
```
#### Type parameters

<a name='BTD_Mod_Helper.Extensions.AttackBehaviorExt.GetAttackBehavior_T_(thisAttack).T'></a>

`T`

The Behavior you want
#### Parameters

<a name='BTD_Mod_Helper.Extensions.AttackBehaviorExt.GetAttackBehavior_T_(thisAttack).attack'></a>

`attack` [Il2CppAssets.Scripts.Simulation.Towers.Behaviors.Attack.Attack](https://docs.microsoft.com/en-us/dotnet/api/Il2CppAssets.Scripts.Simulation.Towers.Behaviors.Attack.Attack 'Il2CppAssets.Scripts.Simulation.Towers.Behaviors.Attack.Attack')

#### Returns
[T](BTD_Mod_Helper.Extensions.AttackBehaviorExt.md#BTD_Mod_Helper.Extensions.AttackBehaviorExt.GetAttackBehavior_T_(thisAttack).T 'BTD_Mod_Helper.Extensions.AttackBehaviorExt.GetAttackBehavior<T>(this Attack).T')

<a name='BTD_Mod_Helper.Extensions.AttackBehaviorExt.GetAttackBehaviors_T_(thisAttack)'></a>

## AttackBehaviorExt.GetAttackBehaviors<T>(this Attack) Method

Return all Behaviors of type T

```csharp
public static System.Collections.Generic.List<T> GetAttackBehaviors<T>(this Attack attack)
    where T : AttackBehavior;
```
#### Type parameters

<a name='BTD_Mod_Helper.Extensions.AttackBehaviorExt.GetAttackBehaviors_T_(thisAttack).T'></a>

`T`

The Behavior you want
#### Parameters

<a name='BTD_Mod_Helper.Extensions.AttackBehaviorExt.GetAttackBehaviors_T_(thisAttack).attack'></a>

`attack` [Il2CppAssets.Scripts.Simulation.Towers.Behaviors.Attack.Attack](https://docs.microsoft.com/en-us/dotnet/api/Il2CppAssets.Scripts.Simulation.Towers.Behaviors.Attack.Attack 'Il2CppAssets.Scripts.Simulation.Towers.Behaviors.Attack.Attack')

#### Returns
[System.Collections.Generic.List&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.List-1 'System.Collections.Generic.List`1')[T](BTD_Mod_Helper.Extensions.AttackBehaviorExt.md#BTD_Mod_Helper.Extensions.AttackBehaviorExt.GetAttackBehaviors_T_(thisAttack).T 'BTD_Mod_Helper.Extensions.AttackBehaviorExt.GetAttackBehaviors<T>(this Attack).T')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.List-1 'System.Collections.Generic.List`1')

<a name='BTD_Mod_Helper.Extensions.AttackBehaviorExt.HasAttackBehavior_T_(thisAttack)'></a>

## AttackBehaviorExt.HasAttackBehavior<T>(this Attack) Method

Check if this has a specific Behavior

```csharp
public static bool HasAttackBehavior<T>(this Attack attack)
    where T : AttackBehavior;
```
#### Type parameters

<a name='BTD_Mod_Helper.Extensions.AttackBehaviorExt.HasAttackBehavior_T_(thisAttack).T'></a>

`T`

The Behavior you're checking for
#### Parameters

<a name='BTD_Mod_Helper.Extensions.AttackBehaviorExt.HasAttackBehavior_T_(thisAttack).attack'></a>

`attack` [Il2CppAssets.Scripts.Simulation.Towers.Behaviors.Attack.Attack](https://docs.microsoft.com/en-us/dotnet/api/Il2CppAssets.Scripts.Simulation.Towers.Behaviors.Attack.Attack 'Il2CppAssets.Scripts.Simulation.Towers.Behaviors.Attack.Attack')

#### Returns
[System.Boolean](https://docs.microsoft.com/en-us/dotnet/api/System.Boolean 'System.Boolean')

<a name='BTD_Mod_Helper.Extensions.AttackBehaviorExt.RemoveAttackBehavior_T_(thisAttack,T)'></a>

## AttackBehaviorExt.RemoveAttackBehavior<T>(this Attack, T) Method

Remove the first Behavior of type T

```csharp
public static void RemoveAttackBehavior<T>(this Attack attack, T behavior)
    where T : AttackBehavior;
```
#### Type parameters

<a name='BTD_Mod_Helper.Extensions.AttackBehaviorExt.RemoveAttackBehavior_T_(thisAttack,T).T'></a>

`T`

The Behavior you want to remove
#### Parameters

<a name='BTD_Mod_Helper.Extensions.AttackBehaviorExt.RemoveAttackBehavior_T_(thisAttack,T).attack'></a>

`attack` [Il2CppAssets.Scripts.Simulation.Towers.Behaviors.Attack.Attack](https://docs.microsoft.com/en-us/dotnet/api/Il2CppAssets.Scripts.Simulation.Towers.Behaviors.Attack.Attack 'Il2CppAssets.Scripts.Simulation.Towers.Behaviors.Attack.Attack')

<a name='BTD_Mod_Helper.Extensions.AttackBehaviorExt.RemoveAttackBehavior_T_(thisAttack,T).behavior'></a>

`behavior` [T](BTD_Mod_Helper.Extensions.AttackBehaviorExt.md#BTD_Mod_Helper.Extensions.AttackBehaviorExt.RemoveAttackBehavior_T_(thisAttack,T).T 'BTD_Mod_Helper.Extensions.AttackBehaviorExt.RemoveAttackBehavior<T>(this Attack, T).T')

<a name='BTD_Mod_Helper.Extensions.AttackBehaviorExt.RemoveAttackBehavior_T_(thisAttack)'></a>

## AttackBehaviorExt.RemoveAttackBehavior<T>(this Attack) Method

Remove the first Behavior of Type T

```csharp
public static void RemoveAttackBehavior<T>(this Attack attack)
    where T : AttackBehavior;
```
#### Type parameters

<a name='BTD_Mod_Helper.Extensions.AttackBehaviorExt.RemoveAttackBehavior_T_(thisAttack).T'></a>

`T`

The Behavior you want to remove
#### Parameters

<a name='BTD_Mod_Helper.Extensions.AttackBehaviorExt.RemoveAttackBehavior_T_(thisAttack).attack'></a>

`attack` [Il2CppAssets.Scripts.Simulation.Towers.Behaviors.Attack.Attack](https://docs.microsoft.com/en-us/dotnet/api/Il2CppAssets.Scripts.Simulation.Towers.Behaviors.Attack.Attack 'Il2CppAssets.Scripts.Simulation.Towers.Behaviors.Attack.Attack')

<a name='BTD_Mod_Helper.Extensions.AttackBehaviorExt.RemoveAttackBehaviors_T_(thisAttack)'></a>

## AttackBehaviorExt.RemoveAttackBehaviors<T>(this Attack) Method

Remove all Behaviors of type T

```csharp
public static void RemoveAttackBehaviors<T>(this Attack attack)
    where T : AttackBehavior;
```
#### Type parameters

<a name='BTD_Mod_Helper.Extensions.AttackBehaviorExt.RemoveAttackBehaviors_T_(thisAttack).T'></a>

`T`

The Behavior you want to remove
#### Parameters

<a name='BTD_Mod_Helper.Extensions.AttackBehaviorExt.RemoveAttackBehaviors_T_(thisAttack).attack'></a>

`attack` [Il2CppAssets.Scripts.Simulation.Towers.Behaviors.Attack.Attack](https://docs.microsoft.com/en-us/dotnet/api/Il2CppAssets.Scripts.Simulation.Towers.Behaviors.Attack.Attack 'Il2CppAssets.Scripts.Simulation.Towers.Behaviors.Attack.Attack')