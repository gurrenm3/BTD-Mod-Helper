#### [BloonsTD6 Mod Helper](README.md 'README')
### [BTD_Mod_Helper.Extensions](README.md#BTD_Mod_Helper.Extensions 'BTD_Mod_Helper.Extensions')

## ModelExt Class

Extensions for Models

```csharp
public static class ModelExt
```

Inheritance [System.Object](https://docs.microsoft.com/en-us/dotnet/api/System.Object 'System.Object') &#129106; ModelExt
### Methods

<a name='BTD_Mod_Helper.Extensions.ModelExt.Duplicate_T_(thisT)'></a>

## ModelExt.Duplicate<T>(this T) Method

Create a new and separate copy of this object. Same as using:  .Clone().Cast();

```csharp
public static T Duplicate<T>(this T model)
    where T : Model;
```
#### Type parameters

<a name='BTD_Mod_Helper.Extensions.ModelExt.Duplicate_T_(thisT).T'></a>

`T`

Type of object you want to cast to when duplicating. Done automatically
#### Parameters

<a name='BTD_Mod_Helper.Extensions.ModelExt.Duplicate_T_(thisT).model'></a>

`model` [T](BTD_Mod_Helper.Extensions.ModelExt.md#BTD_Mod_Helper.Extensions.ModelExt.Duplicate_T_(thisT).T 'BTD_Mod_Helper.Extensions.ModelExt.Duplicate<T>(this T).T')

#### Returns
[T](BTD_Mod_Helper.Extensions.ModelExt.md#BTD_Mod_Helper.Extensions.ModelExt.Duplicate_T_(thisT).T 'BTD_Mod_Helper.Extensions.ModelExt.Duplicate<T>(this T).T')

<a name='BTD_Mod_Helper.Extensions.ModelExt.FindDescendant_T_(thisModel,string)'></a>

## ModelExt.FindDescendant<T>(this Model, string) Method

Finds the first descendent of a given type whose name contains the specified string, or null if not found

```csharp
public static T FindDescendant<T>(this Model model, string nameContains)
    where T : Model;
```
#### Type parameters

<a name='BTD_Mod_Helper.Extensions.ModelExt.FindDescendant_T_(thisModel,string).T'></a>

`T`
#### Parameters

<a name='BTD_Mod_Helper.Extensions.ModelExt.FindDescendant_T_(thisModel,string).model'></a>

`model` [Il2CppAssets.Scripts.Models.Model](https://docs.microsoft.com/en-us/dotnet/api/Il2CppAssets.Scripts.Models.Model 'Il2CppAssets.Scripts.Models.Model')

<a name='BTD_Mod_Helper.Extensions.ModelExt.FindDescendant_T_(thisModel,string).nameContains'></a>

`nameContains` [System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')

#### Returns
[T](BTD_Mod_Helper.Extensions.ModelExt.md#BTD_Mod_Helper.Extensions.ModelExt.FindDescendant_T_(thisModel,string).T 'BTD_Mod_Helper.Extensions.ModelExt.FindDescendant<T>(this Model, string).T')

<a name='BTD_Mod_Helper.Extensions.ModelExt.FindDescendant_T_(thisModel,System.Predicate_T_)'></a>

## ModelExt.FindDescendant<T>(this Model, Predicate<T>) Method

Finds the first descendent of a given type that matches the given condition, or null if not found

```csharp
public static T FindDescendant<T>(this Model model, System.Predicate<T> condition)
    where T : Model;
```
#### Type parameters

<a name='BTD_Mod_Helper.Extensions.ModelExt.FindDescendant_T_(thisModel,System.Predicate_T_).T'></a>

`T`
#### Parameters

<a name='BTD_Mod_Helper.Extensions.ModelExt.FindDescendant_T_(thisModel,System.Predicate_T_).model'></a>

`model` [Il2CppAssets.Scripts.Models.Model](https://docs.microsoft.com/en-us/dotnet/api/Il2CppAssets.Scripts.Models.Model 'Il2CppAssets.Scripts.Models.Model')

<a name='BTD_Mod_Helper.Extensions.ModelExt.FindDescendant_T_(thisModel,System.Predicate_T_).condition'></a>

`condition` [System.Predicate&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Predicate-1 'System.Predicate`1')[T](BTD_Mod_Helper.Extensions.ModelExt.md#BTD_Mod_Helper.Extensions.ModelExt.FindDescendant_T_(thisModel,System.Predicate_T_).T 'BTD_Mod_Helper.Extensions.ModelExt.FindDescendant<T>(this Model, System.Predicate<T>).T')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Predicate-1 'System.Predicate`1')

#### Returns
[T](BTD_Mod_Helper.Extensions.ModelExt.md#BTD_Mod_Helper.Extensions.ModelExt.FindDescendant_T_(thisModel,System.Predicate_T_).T 'BTD_Mod_Helper.Extensions.ModelExt.FindDescendant<T>(this Model, System.Predicate<T>).T')