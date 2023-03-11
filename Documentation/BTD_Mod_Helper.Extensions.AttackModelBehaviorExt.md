#### [BloonsTD6 Mod Helper](README.md 'README')
### [BTD_Mod_Helper.Extensions](README.md#BTD_Mod_Helper.Extensions 'BTD_Mod_Helper.Extensions')

## AttackModelBehaviorExt Class

Behavior Extensions for AttackModel

```csharp
public static class AttackModelBehaviorExt
```

Inheritance [System.Object](https://docs.microsoft.com/en-us/dotnet/api/System.Object 'System.Object') &#129106; AttackModelBehaviorExt
### Methods

<a name='BTD_Mod_Helper.Extensions.AttackModelBehaviorExt.AddBehavior_T_(thisAttackModel,T)'></a>

## AttackModelBehaviorExt.AddBehavior<T>(this AttackModel, T) Method

Add a Behavior to this

```csharp
public static void AddBehavior<T>(this AttackModel model, T behavior)
    where T : Model;
```
#### Type parameters

<a name='BTD_Mod_Helper.Extensions.AttackModelBehaviorExt.AddBehavior_T_(thisAttackModel,T).T'></a>

`T`

The Behavior you want to add
#### Parameters

<a name='BTD_Mod_Helper.Extensions.AttackModelBehaviorExt.AddBehavior_T_(thisAttackModel,T).model'></a>

`model` [Il2CppAssets.Scripts.Models.Towers.Behaviors.Attack.AttackModel](https://docs.microsoft.com/en-us/dotnet/api/Il2CppAssets.Scripts.Models.Towers.Behaviors.Attack.AttackModel 'Il2CppAssets.Scripts.Models.Towers.Behaviors.Attack.AttackModel')

<a name='BTD_Mod_Helper.Extensions.AttackModelBehaviorExt.AddBehavior_T_(thisAttackModel,T).behavior'></a>

`behavior` [T](BTD_Mod_Helper.Extensions.AttackModelBehaviorExt.md#BTD_Mod_Helper.Extensions.AttackModelBehaviorExt.AddBehavior_T_(thisAttackModel,T).T 'BTD_Mod_Helper.Extensions.AttackModelBehaviorExt.AddBehavior<T>(this AttackModel, T).T')

<a name='BTD_Mod_Helper.Extensions.AttackModelBehaviorExt.GetBehavior_T_(thisAttackModel)'></a>

## AttackModelBehaviorExt.GetBehavior<T>(this AttackModel) Method

Return the first Behavior of type T

```csharp
public static T GetBehavior<T>(this AttackModel model)
    where T : Model;
```
#### Type parameters

<a name='BTD_Mod_Helper.Extensions.AttackModelBehaviorExt.GetBehavior_T_(thisAttackModel).T'></a>

`T`

The Behavior you want
#### Parameters

<a name='BTD_Mod_Helper.Extensions.AttackModelBehaviorExt.GetBehavior_T_(thisAttackModel).model'></a>

`model` [Il2CppAssets.Scripts.Models.Towers.Behaviors.Attack.AttackModel](https://docs.microsoft.com/en-us/dotnet/api/Il2CppAssets.Scripts.Models.Towers.Behaviors.Attack.AttackModel 'Il2CppAssets.Scripts.Models.Towers.Behaviors.Attack.AttackModel')

#### Returns
[T](BTD_Mod_Helper.Extensions.AttackModelBehaviorExt.md#BTD_Mod_Helper.Extensions.AttackModelBehaviorExt.GetBehavior_T_(thisAttackModel).T 'BTD_Mod_Helper.Extensions.AttackModelBehaviorExt.GetBehavior<T>(this AttackModel).T')

<a name='BTD_Mod_Helper.Extensions.AttackModelBehaviorExt.GetBehaviors_T_(thisAttackModel)'></a>

## AttackModelBehaviorExt.GetBehaviors<T>(this AttackModel) Method

Return all Behaviors of type T

```csharp
public static System.Collections.Generic.List<T> GetBehaviors<T>(this AttackModel model)
    where T : Model;
```
#### Type parameters

<a name='BTD_Mod_Helper.Extensions.AttackModelBehaviorExt.GetBehaviors_T_(thisAttackModel).T'></a>

`T`

The Behavior you want
#### Parameters

<a name='BTD_Mod_Helper.Extensions.AttackModelBehaviorExt.GetBehaviors_T_(thisAttackModel).model'></a>

`model` [Il2CppAssets.Scripts.Models.Towers.Behaviors.Attack.AttackModel](https://docs.microsoft.com/en-us/dotnet/api/Il2CppAssets.Scripts.Models.Towers.Behaviors.Attack.AttackModel 'Il2CppAssets.Scripts.Models.Towers.Behaviors.Attack.AttackModel')

#### Returns
[System.Collections.Generic.List&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.List-1 'System.Collections.Generic.List`1')[T](BTD_Mod_Helper.Extensions.AttackModelBehaviorExt.md#BTD_Mod_Helper.Extensions.AttackModelBehaviorExt.GetBehaviors_T_(thisAttackModel).T 'BTD_Mod_Helper.Extensions.AttackModelBehaviorExt.GetBehaviors<T>(this AttackModel).T')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.List-1 'System.Collections.Generic.List`1')

<a name='BTD_Mod_Helper.Extensions.AttackModelBehaviorExt.HasBehavior_T_(thisAttackModel)'></a>

## AttackModelBehaviorExt.HasBehavior<T>(this AttackModel) Method

Check if this has a specific Behavior

```csharp
public static bool HasBehavior<T>(this AttackModel model)
    where T : Model;
```
#### Type parameters

<a name='BTD_Mod_Helper.Extensions.AttackModelBehaviorExt.HasBehavior_T_(thisAttackModel).T'></a>

`T`

The Behavior you're checking for
#### Parameters

<a name='BTD_Mod_Helper.Extensions.AttackModelBehaviorExt.HasBehavior_T_(thisAttackModel).model'></a>

`model` [Il2CppAssets.Scripts.Models.Towers.Behaviors.Attack.AttackModel](https://docs.microsoft.com/en-us/dotnet/api/Il2CppAssets.Scripts.Models.Towers.Behaviors.Attack.AttackModel 'Il2CppAssets.Scripts.Models.Towers.Behaviors.Attack.AttackModel')

#### Returns
[System.Boolean](https://docs.microsoft.com/en-us/dotnet/api/System.Boolean 'System.Boolean')

<a name='BTD_Mod_Helper.Extensions.AttackModelBehaviorExt.RemoveBehavior_T_(thisAttackModel,T)'></a>

## AttackModelBehaviorExt.RemoveBehavior<T>(this AttackModel, T) Method

Remove the first Behavior of type T

```csharp
public static void RemoveBehavior<T>(this AttackModel model, T behavior)
    where T : Model;
```
#### Type parameters

<a name='BTD_Mod_Helper.Extensions.AttackModelBehaviorExt.RemoveBehavior_T_(thisAttackModel,T).T'></a>

`T`

The Behavior you want to remove
#### Parameters

<a name='BTD_Mod_Helper.Extensions.AttackModelBehaviorExt.RemoveBehavior_T_(thisAttackModel,T).model'></a>

`model` [Il2CppAssets.Scripts.Models.Towers.Behaviors.Attack.AttackModel](https://docs.microsoft.com/en-us/dotnet/api/Il2CppAssets.Scripts.Models.Towers.Behaviors.Attack.AttackModel 'Il2CppAssets.Scripts.Models.Towers.Behaviors.Attack.AttackModel')

<a name='BTD_Mod_Helper.Extensions.AttackModelBehaviorExt.RemoveBehavior_T_(thisAttackModel,T).behavior'></a>

`behavior` [T](BTD_Mod_Helper.Extensions.AttackModelBehaviorExt.md#BTD_Mod_Helper.Extensions.AttackModelBehaviorExt.RemoveBehavior_T_(thisAttackModel,T).T 'BTD_Mod_Helper.Extensions.AttackModelBehaviorExt.RemoveBehavior<T>(this AttackModel, T).T')

<a name='BTD_Mod_Helper.Extensions.AttackModelBehaviorExt.RemoveBehavior_T_(thisAttackModel)'></a>

## AttackModelBehaviorExt.RemoveBehavior<T>(this AttackModel) Method

Remove the first Behavior of Type T

```csharp
public static void RemoveBehavior<T>(this AttackModel model)
    where T : Model;
```
#### Type parameters

<a name='BTD_Mod_Helper.Extensions.AttackModelBehaviorExt.RemoveBehavior_T_(thisAttackModel).T'></a>

`T`

The Behavior you want to remove
#### Parameters

<a name='BTD_Mod_Helper.Extensions.AttackModelBehaviorExt.RemoveBehavior_T_(thisAttackModel).model'></a>

`model` [Il2CppAssets.Scripts.Models.Towers.Behaviors.Attack.AttackModel](https://docs.microsoft.com/en-us/dotnet/api/Il2CppAssets.Scripts.Models.Towers.Behaviors.Attack.AttackModel 'Il2CppAssets.Scripts.Models.Towers.Behaviors.Attack.AttackModel')

<a name='BTD_Mod_Helper.Extensions.AttackModelBehaviorExt.RemoveBehaviors_T_(thisAttackModel)'></a>

## AttackModelBehaviorExt.RemoveBehaviors<T>(this AttackModel) Method

Remove all Behaviors of type T

```csharp
public static void RemoveBehaviors<T>(this AttackModel model)
    where T : Model;
```
#### Type parameters

<a name='BTD_Mod_Helper.Extensions.AttackModelBehaviorExt.RemoveBehaviors_T_(thisAttackModel).T'></a>

`T`

The Behavior you want to remove
#### Parameters

<a name='BTD_Mod_Helper.Extensions.AttackModelBehaviorExt.RemoveBehaviors_T_(thisAttackModel).model'></a>

`model` [Il2CppAssets.Scripts.Models.Towers.Behaviors.Attack.AttackModel](https://docs.microsoft.com/en-us/dotnet/api/Il2CppAssets.Scripts.Models.Towers.Behaviors.Attack.AttackModel 'Il2CppAssets.Scripts.Models.Towers.Behaviors.Attack.AttackModel')