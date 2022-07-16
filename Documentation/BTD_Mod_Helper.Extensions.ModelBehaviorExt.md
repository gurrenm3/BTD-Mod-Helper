#### [BloonsTD6 Mod Helper](index.md 'index')
### [BTD_Mod_Helper.Extensions](index.md#BTD_Mod_Helper.Extensions 'BTD_Mod_Helper.Extensions')

## ModelBehaviorExt Class

Extensions for dealing with the behaviors of Models

```csharp
internal static class ModelBehaviorExt
```

Inheritance [System.Object](https://docs.microsoft.com/en-us/dotnet/api/System.Object 'System.Object') &#129106; ModelBehaviorExt
### Methods

<a name='BTD_Mod_Helper.Extensions.ModelBehaviorExt.AddBehavior(thisAssets.Scripts.Models.Model,Assets.Scripts.Models.Model)'></a>

## ModelBehaviorExt.AddBehavior(this Model, Model) Method

(Cross-Game compatible) Add a Behavior to this model

```csharp
public static void AddBehavior(this Assets.Scripts.Models.Model model, Assets.Scripts.Models.Model behavior);
```
#### Parameters

<a name='BTD_Mod_Helper.Extensions.ModelBehaviorExt.AddBehavior(thisAssets.Scripts.Models.Model,Assets.Scripts.Models.Model).model'></a>

`model` [Assets.Scripts.Models.Model](https://docs.microsoft.com/en-us/dotnet/api/Assets.Scripts.Models.Model 'Assets.Scripts.Models.Model')

<a name='BTD_Mod_Helper.Extensions.ModelBehaviorExt.AddBehavior(thisAssets.Scripts.Models.Model,Assets.Scripts.Models.Model).behavior'></a>

`behavior` [Assets.Scripts.Models.Model](https://docs.microsoft.com/en-us/dotnet/api/Assets.Scripts.Models.Model 'Assets.Scripts.Models.Model')

<a name='BTD_Mod_Helper.Extensions.ModelBehaviorExt.GetBehavior_T_(thisAssets.Scripts.Models.Model)'></a>

## ModelBehaviorExt.GetBehavior<T>(this Model) Method

(Cross-Game compatible) Return the first Behavior of type T, or null if there isn't one

```csharp
public static T GetBehavior<T>(this Assets.Scripts.Models.Model model)
    where T : Assets.Scripts.Models.Model;
```
#### Type parameters

<a name='BTD_Mod_Helper.Extensions.ModelBehaviorExt.GetBehavior_T_(thisAssets.Scripts.Models.Model).T'></a>

`T`

The Behavior you want
#### Parameters

<a name='BTD_Mod_Helper.Extensions.ModelBehaviorExt.GetBehavior_T_(thisAssets.Scripts.Models.Model).model'></a>

`model` [Assets.Scripts.Models.Model](https://docs.microsoft.com/en-us/dotnet/api/Assets.Scripts.Models.Model 'Assets.Scripts.Models.Model')

#### Returns
[T](BTD_Mod_Helper.Extensions.ModelBehaviorExt.md#BTD_Mod_Helper.Extensions.ModelBehaviorExt.GetBehavior_T_(thisAssets.Scripts.Models.Model).T 'BTD_Mod_Helper.Extensions.ModelBehaviorExt.GetBehavior<T>(this Assets.Scripts.Models.Model).T')

<a name='BTD_Mod_Helper.Extensions.ModelBehaviorExt.GetBehavior_T_(thisAssets.Scripts.Models.Model,int)'></a>

## ModelBehaviorExt.GetBehavior<T>(this Model, int) Method

(Cross-Game compatible) Return the index'th Behavior of type T, or null

```csharp
public static T GetBehavior<T>(this Assets.Scripts.Models.Model model, int index)
    where T : Assets.Scripts.Models.Model;
```
#### Type parameters

<a name='BTD_Mod_Helper.Extensions.ModelBehaviorExt.GetBehavior_T_(thisAssets.Scripts.Models.Model,int).T'></a>

`T`

The Behavior you want
#### Parameters

<a name='BTD_Mod_Helper.Extensions.ModelBehaviorExt.GetBehavior_T_(thisAssets.Scripts.Models.Model,int).model'></a>

`model` [Assets.Scripts.Models.Model](https://docs.microsoft.com/en-us/dotnet/api/Assets.Scripts.Models.Model 'Assets.Scripts.Models.Model')

<a name='BTD_Mod_Helper.Extensions.ModelBehaviorExt.GetBehavior_T_(thisAssets.Scripts.Models.Model,int).index'></a>

`index` [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/System.Int32 'System.Int32')

#### Returns
[T](BTD_Mod_Helper.Extensions.ModelBehaviorExt.md#BTD_Mod_Helper.Extensions.ModelBehaviorExt.GetBehavior_T_(thisAssets.Scripts.Models.Model,int).T 'BTD_Mod_Helper.Extensions.ModelBehaviorExt.GetBehavior<T>(this Assets.Scripts.Models.Model, int).T')

<a name='BTD_Mod_Helper.Extensions.ModelBehaviorExt.GetBehavior_T_(thisAssets.Scripts.Models.Model,string)'></a>

## ModelBehaviorExt.GetBehavior<T>(this Model, string) Method

(Cross-Game compatible) Return the first Behavior of type T whose name contains the given string, or null

```csharp
public static T GetBehavior<T>(this Assets.Scripts.Models.Model model, string nameContains)
    where T : Assets.Scripts.Models.Model;
```
#### Type parameters

<a name='BTD_Mod_Helper.Extensions.ModelBehaviorExt.GetBehavior_T_(thisAssets.Scripts.Models.Model,string).T'></a>

`T`

The Behavior you want
#### Parameters

<a name='BTD_Mod_Helper.Extensions.ModelBehaviorExt.GetBehavior_T_(thisAssets.Scripts.Models.Model,string).model'></a>

`model` [Assets.Scripts.Models.Model](https://docs.microsoft.com/en-us/dotnet/api/Assets.Scripts.Models.Model 'Assets.Scripts.Models.Model')

<a name='BTD_Mod_Helper.Extensions.ModelBehaviorExt.GetBehavior_T_(thisAssets.Scripts.Models.Model,string).nameContains'></a>

`nameContains` [System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')

#### Returns
[T](BTD_Mod_Helper.Extensions.ModelBehaviorExt.md#BTD_Mod_Helper.Extensions.ModelBehaviorExt.GetBehavior_T_(thisAssets.Scripts.Models.Model,string).T 'BTD_Mod_Helper.Extensions.ModelBehaviorExt.GetBehavior<T>(this Assets.Scripts.Models.Model, string).T')

<a name='BTD_Mod_Helper.Extensions.ModelBehaviorExt.GetBehaviors(thisAssets.Scripts.Models.Model)'></a>

## ModelBehaviorExt.GetBehaviors(this Model) Method

Gets the behaviors of a model. If the model does not have a behaviors field, then this returns null.

```csharp
public static System.Collections.Generic.IEnumerable<Assets.Scripts.Models.Model> GetBehaviors(this Assets.Scripts.Models.Model model);
```
#### Parameters

<a name='BTD_Mod_Helper.Extensions.ModelBehaviorExt.GetBehaviors(thisAssets.Scripts.Models.Model).model'></a>

`model` [Assets.Scripts.Models.Model](https://docs.microsoft.com/en-us/dotnet/api/Assets.Scripts.Models.Model 'Assets.Scripts.Models.Model')

#### Returns
[System.Collections.Generic.IEnumerable&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.IEnumerable-1 'System.Collections.Generic.IEnumerable`1')[Assets.Scripts.Models.Model](https://docs.microsoft.com/en-us/dotnet/api/Assets.Scripts.Models.Model 'Assets.Scripts.Models.Model')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.IEnumerable-1 'System.Collections.Generic.IEnumerable`1')

<a name='BTD_Mod_Helper.Extensions.ModelBehaviorExt.GetBehaviors_T_(thisAssets.Scripts.Models.Model)'></a>

## ModelBehaviorExt.GetBehaviors<T>(this Model) Method

(Cross-Game compatible) Return all Behaviors of type T

```csharp
public static System.Collections.Generic.IEnumerable<T> GetBehaviors<T>(this Assets.Scripts.Models.Model model)
    where T : Assets.Scripts.Models.Model;
```
#### Type parameters

<a name='BTD_Mod_Helper.Extensions.ModelBehaviorExt.GetBehaviors_T_(thisAssets.Scripts.Models.Model).T'></a>

`T`

The Behavior you want
#### Parameters

<a name='BTD_Mod_Helper.Extensions.ModelBehaviorExt.GetBehaviors_T_(thisAssets.Scripts.Models.Model).model'></a>

`model` [Assets.Scripts.Models.Model](https://docs.microsoft.com/en-us/dotnet/api/Assets.Scripts.Models.Model 'Assets.Scripts.Models.Model')

#### Returns
[System.Collections.Generic.IEnumerable&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.IEnumerable-1 'System.Collections.Generic.IEnumerable`1')[T](BTD_Mod_Helper.Extensions.ModelBehaviorExt.md#BTD_Mod_Helper.Extensions.ModelBehaviorExt.GetBehaviors_T_(thisAssets.Scripts.Models.Model).T 'BTD_Mod_Helper.Extensions.ModelBehaviorExt.GetBehaviors<T>(this Assets.Scripts.Models.Model).T')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.IEnumerable-1 'System.Collections.Generic.IEnumerable`1')

<a name='BTD_Mod_Helper.Extensions.ModelBehaviorExt.HasBehavior_T_(thisAssets.Scripts.Models.Model)'></a>

## ModelBehaviorExt.HasBehavior<T>(this Model) Method

(Cross-Game compatible) Check if this has a specific Behavior

```csharp
public static bool HasBehavior<T>(this Assets.Scripts.Models.Model model)
    where T : Assets.Scripts.Models.Model;
```
#### Type parameters

<a name='BTD_Mod_Helper.Extensions.ModelBehaviorExt.HasBehavior_T_(thisAssets.Scripts.Models.Model).T'></a>

`T`

The Behavior you're checking for
#### Parameters

<a name='BTD_Mod_Helper.Extensions.ModelBehaviorExt.HasBehavior_T_(thisAssets.Scripts.Models.Model).model'></a>

`model` [Assets.Scripts.Models.Model](https://docs.microsoft.com/en-us/dotnet/api/Assets.Scripts.Models.Model 'Assets.Scripts.Models.Model')

#### Returns
[System.Boolean](https://docs.microsoft.com/en-us/dotnet/api/System.Boolean 'System.Boolean')

<a name='BTD_Mod_Helper.Extensions.ModelBehaviorExt.HasBehavior_T_(thisAssets.Scripts.Models.Model,T)'></a>

## ModelBehaviorExt.HasBehavior<T>(this Model, T) Method

(Cross-Game compatible) Check if this has a specific Behavior and return it

```csharp
public static bool HasBehavior<T>(this Assets.Scripts.Models.Model model, out T behavior)
    where T : Assets.Scripts.Models.Model;
```
#### Type parameters

<a name='BTD_Mod_Helper.Extensions.ModelBehaviorExt.HasBehavior_T_(thisAssets.Scripts.Models.Model,T).T'></a>

`T`

The Behavior you're checking for
#### Parameters

<a name='BTD_Mod_Helper.Extensions.ModelBehaviorExt.HasBehavior_T_(thisAssets.Scripts.Models.Model,T).model'></a>

`model` [Assets.Scripts.Models.Model](https://docs.microsoft.com/en-us/dotnet/api/Assets.Scripts.Models.Model 'Assets.Scripts.Models.Model')

<a name='BTD_Mod_Helper.Extensions.ModelBehaviorExt.HasBehavior_T_(thisAssets.Scripts.Models.Model,T).behavior'></a>

`behavior` [T](BTD_Mod_Helper.Extensions.ModelBehaviorExt.md#BTD_Mod_Helper.Extensions.ModelBehaviorExt.HasBehavior_T_(thisAssets.Scripts.Models.Model,T).T 'BTD_Mod_Helper.Extensions.ModelBehaviorExt.HasBehavior<T>(this Assets.Scripts.Models.Model, T).T')

#### Returns
[System.Boolean](https://docs.microsoft.com/en-us/dotnet/api/System.Boolean 'System.Boolean')

<a name='BTD_Mod_Helper.Extensions.ModelBehaviorExt.RemoveBehavior(thisAssets.Scripts.Models.Model,Assets.Scripts.Models.Model)'></a>

## ModelBehaviorExt.RemoveBehavior(this Model, Model) Method

(Cross-Game compatible) Removes a specific behavior from a tower

```csharp
public static void RemoveBehavior(this Assets.Scripts.Models.Model model, Assets.Scripts.Models.Model behavior);
```
#### Parameters

<a name='BTD_Mod_Helper.Extensions.ModelBehaviorExt.RemoveBehavior(thisAssets.Scripts.Models.Model,Assets.Scripts.Models.Model).model'></a>

`model` [Assets.Scripts.Models.Model](https://docs.microsoft.com/en-us/dotnet/api/Assets.Scripts.Models.Model 'Assets.Scripts.Models.Model')

<a name='BTD_Mod_Helper.Extensions.ModelBehaviorExt.RemoveBehavior(thisAssets.Scripts.Models.Model,Assets.Scripts.Models.Model).behavior'></a>

`behavior` [Assets.Scripts.Models.Model](https://docs.microsoft.com/en-us/dotnet/api/Assets.Scripts.Models.Model 'Assets.Scripts.Models.Model')

<a name='BTD_Mod_Helper.Extensions.ModelBehaviorExt.RemoveBehavior_T_(thisAssets.Scripts.Models.Model)'></a>

## ModelBehaviorExt.RemoveBehavior<T>(this Model) Method

(Cross-Game compatible) Remove the first Behavior of Type T

```csharp
public static void RemoveBehavior<T>(this Assets.Scripts.Models.Model model)
    where T : Assets.Scripts.Models.Model;
```
#### Type parameters

<a name='BTD_Mod_Helper.Extensions.ModelBehaviorExt.RemoveBehavior_T_(thisAssets.Scripts.Models.Model).T'></a>

`T`

The Behavior you want to remove
#### Parameters

<a name='BTD_Mod_Helper.Extensions.ModelBehaviorExt.RemoveBehavior_T_(thisAssets.Scripts.Models.Model).model'></a>

`model` [Assets.Scripts.Models.Model](https://docs.microsoft.com/en-us/dotnet/api/Assets.Scripts.Models.Model 'Assets.Scripts.Models.Model')

<a name='BTD_Mod_Helper.Extensions.ModelBehaviorExt.RemoveBehavior_T_(thisAssets.Scripts.Models.Model,int)'></a>

## ModelBehaviorExt.RemoveBehavior<T>(this Model, int) Method

(Cross-Game compatible) Remove the index'th Behavior of Type T

```csharp
public static void RemoveBehavior<T>(this Assets.Scripts.Models.Model model, int index)
    where T : Assets.Scripts.Models.Model;
```
#### Type parameters

<a name='BTD_Mod_Helper.Extensions.ModelBehaviorExt.RemoveBehavior_T_(thisAssets.Scripts.Models.Model,int).T'></a>

`T`

The Behavior you want to remove
#### Parameters

<a name='BTD_Mod_Helper.Extensions.ModelBehaviorExt.RemoveBehavior_T_(thisAssets.Scripts.Models.Model,int).model'></a>

`model` [Assets.Scripts.Models.Model](https://docs.microsoft.com/en-us/dotnet/api/Assets.Scripts.Models.Model 'Assets.Scripts.Models.Model')

<a name='BTD_Mod_Helper.Extensions.ModelBehaviorExt.RemoveBehavior_T_(thisAssets.Scripts.Models.Model,int).index'></a>

`index` [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/System.Int32 'System.Int32')

<a name='BTD_Mod_Helper.Extensions.ModelBehaviorExt.RemoveBehavior_T_(thisAssets.Scripts.Models.Model,string)'></a>

## ModelBehaviorExt.RemoveBehavior<T>(this Model, string) Method

(Cross-Game compatible) Remove the first Behavior of Type T whose name contains a certain string

```csharp
public static void RemoveBehavior<T>(this Assets.Scripts.Models.Model model, string nameContains)
    where T : Assets.Scripts.Models.Model;
```
#### Type parameters

<a name='BTD_Mod_Helper.Extensions.ModelBehaviorExt.RemoveBehavior_T_(thisAssets.Scripts.Models.Model,string).T'></a>

`T`

The Behavior you want to remove
#### Parameters

<a name='BTD_Mod_Helper.Extensions.ModelBehaviorExt.RemoveBehavior_T_(thisAssets.Scripts.Models.Model,string).model'></a>

`model` [Assets.Scripts.Models.Model](https://docs.microsoft.com/en-us/dotnet/api/Assets.Scripts.Models.Model 'Assets.Scripts.Models.Model')

<a name='BTD_Mod_Helper.Extensions.ModelBehaviorExt.RemoveBehavior_T_(thisAssets.Scripts.Models.Model,string).nameContains'></a>

`nameContains` [System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')

<a name='BTD_Mod_Helper.Extensions.ModelBehaviorExt.RemoveBehaviors_T_(thisAssets.Scripts.Models.Model)'></a>

## ModelBehaviorExt.RemoveBehaviors<T>(this Model) Method

(Cross-Game compatible) Remove all Behaviors of type T

```csharp
public static void RemoveBehaviors<T>(this Assets.Scripts.Models.Model model)
    where T : Assets.Scripts.Models.Model;
```
#### Type parameters

<a name='BTD_Mod_Helper.Extensions.ModelBehaviorExt.RemoveBehaviors_T_(thisAssets.Scripts.Models.Model).T'></a>

`T`
#### Parameters

<a name='BTD_Mod_Helper.Extensions.ModelBehaviorExt.RemoveBehaviors_T_(thisAssets.Scripts.Models.Model).model'></a>

`model` [Assets.Scripts.Models.Model](https://docs.microsoft.com/en-us/dotnet/api/Assets.Scripts.Models.Model 'Assets.Scripts.Models.Model')

<a name='BTD_Mod_Helper.Extensions.ModelBehaviorExt.SetBehaviors(thisAssets.Scripts.Models.Model,System.Collections.Generic.IEnumerable_Assets.Scripts.Models.Model_,bool)'></a>

## ModelBehaviorExt.SetBehaviors(this Model, IEnumerable<Model>, bool) Method

Sets the behaviors of a model to the specified IEnumerable of behaviors

```csharp
public static void SetBehaviors(this Assets.Scripts.Models.Model model, System.Collections.Generic.IEnumerable<Assets.Scripts.Models.Model> behaviors, bool handleDependents=true);
```
#### Parameters

<a name='BTD_Mod_Helper.Extensions.ModelBehaviorExt.SetBehaviors(thisAssets.Scripts.Models.Model,System.Collections.Generic.IEnumerable_Assets.Scripts.Models.Model_,bool).model'></a>

`model` [Assets.Scripts.Models.Model](https://docs.microsoft.com/en-us/dotnet/api/Assets.Scripts.Models.Model 'Assets.Scripts.Models.Model')

The model

<a name='BTD_Mod_Helper.Extensions.ModelBehaviorExt.SetBehaviors(thisAssets.Scripts.Models.Model,System.Collections.Generic.IEnumerable_Assets.Scripts.Models.Model_,bool).behaviors'></a>

`behaviors` [System.Collections.Generic.IEnumerable&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.IEnumerable-1 'System.Collections.Generic.IEnumerable`1')[Assets.Scripts.Models.Model](https://docs.microsoft.com/en-us/dotnet/api/Assets.Scripts.Models.Model 'Assets.Scripts.Models.Model')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.IEnumerable-1 'System.Collections.Generic.IEnumerable`1')

The new behaviors

<a name='BTD_Mod_Helper.Extensions.ModelBehaviorExt.SetBehaviors(thisAssets.Scripts.Models.Model,System.Collections.Generic.IEnumerable_Assets.Scripts.Models.Model_,bool).handleDependents'></a>

`handleDependents` [System.Boolean](https://docs.microsoft.com/en-us/dotnet/api/System.Boolean 'System.Boolean')

Whether this should handle adding and removing dependents itself