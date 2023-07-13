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

<a name='BTD_Mod_Helper.Extensions.ModelExt.Duplicate_T_(thisT,string)'></a>

## ModelExt.Duplicate<T>(this T, string) Method

Duplicates a model and also sets its name to something new

```csharp
public static T Duplicate<T>(this T model, string name)
    where T : Model;
```
#### Type parameters

<a name='BTD_Mod_Helper.Extensions.ModelExt.Duplicate_T_(thisT,string).T'></a>

`T`

Type of object you want to cast to when duplicating. Done automatically
#### Parameters

<a name='BTD_Mod_Helper.Extensions.ModelExt.Duplicate_T_(thisT,string).model'></a>

`model` [T](BTD_Mod_Helper.Extensions.ModelExt.md#BTD_Mod_Helper.Extensions.ModelExt.Duplicate_T_(thisT,string).T 'BTD_Mod_Helper.Extensions.ModelExt.Duplicate<T>(this T, string).T')

<a name='BTD_Mod_Helper.Extensions.ModelExt.Duplicate_T_(thisT,string).name'></a>

`name` [System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')

#### Returns
[T](BTD_Mod_Helper.Extensions.ModelExt.md#BTD_Mod_Helper.Extensions.ModelExt.Duplicate_T_(thisT,string).T 'BTD_Mod_Helper.Extensions.ModelExt.Duplicate<T>(this T, string).T')

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

<a name='BTD_Mod_Helper.Extensions.ModelExt.FindDescendants_T_(thisModel,string)'></a>

## ModelExt.FindDescendants<T>(this Model, string) Method

Finds the descendents of a given type whose name contains the specified string

```csharp
public static System.Collections.Generic.List<T> FindDescendants<T>(this Model model, string nameContains)
    where T : Model;
```
#### Type parameters

<a name='BTD_Mod_Helper.Extensions.ModelExt.FindDescendants_T_(thisModel,string).T'></a>

`T`
#### Parameters

<a name='BTD_Mod_Helper.Extensions.ModelExt.FindDescendants_T_(thisModel,string).model'></a>

`model` [Il2CppAssets.Scripts.Models.Model](https://docs.microsoft.com/en-us/dotnet/api/Il2CppAssets.Scripts.Models.Model 'Il2CppAssets.Scripts.Models.Model')

<a name='BTD_Mod_Helper.Extensions.ModelExt.FindDescendants_T_(thisModel,string).nameContains'></a>

`nameContains` [System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')

#### Returns
[System.Collections.Generic.List&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.List-1 'System.Collections.Generic.List`1')[T](BTD_Mod_Helper.Extensions.ModelExt.md#BTD_Mod_Helper.Extensions.ModelExt.FindDescendants_T_(thisModel,string).T 'BTD_Mod_Helper.Extensions.ModelExt.FindDescendants<T>(this Model, string).T')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.List-1 'System.Collections.Generic.List`1')

<a name='BTD_Mod_Helper.Extensions.ModelExt.FindDescendants_T_(thisModel,System.Predicate_T_)'></a>

## ModelExt.FindDescendants<T>(this Model, Predicate<T>) Method

Finds the descendents of a given type that matches the given condition

```csharp
public static System.Collections.Generic.List<T> FindDescendants<T>(this Model model, System.Predicate<T> condition)
    where T : Model;
```
#### Type parameters

<a name='BTD_Mod_Helper.Extensions.ModelExt.FindDescendants_T_(thisModel,System.Predicate_T_).T'></a>

`T`
#### Parameters

<a name='BTD_Mod_Helper.Extensions.ModelExt.FindDescendants_T_(thisModel,System.Predicate_T_).model'></a>

`model` [Il2CppAssets.Scripts.Models.Model](https://docs.microsoft.com/en-us/dotnet/api/Il2CppAssets.Scripts.Models.Model 'Il2CppAssets.Scripts.Models.Model')

<a name='BTD_Mod_Helper.Extensions.ModelExt.FindDescendants_T_(thisModel,System.Predicate_T_).condition'></a>

`condition` [System.Predicate&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Predicate-1 'System.Predicate`1')[T](BTD_Mod_Helper.Extensions.ModelExt.md#BTD_Mod_Helper.Extensions.ModelExt.FindDescendants_T_(thisModel,System.Predicate_T_).T 'BTD_Mod_Helper.Extensions.ModelExt.FindDescendants<T>(this Model, System.Predicate<T>).T')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Predicate-1 'System.Predicate`1')

#### Returns
[System.Collections.Generic.List&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.List-1 'System.Collections.Generic.List`1')[T](BTD_Mod_Helper.Extensions.ModelExt.md#BTD_Mod_Helper.Extensions.ModelExt.FindDescendants_T_(thisModel,System.Predicate_T_).T 'BTD_Mod_Helper.Extensions.ModelExt.FindDescendants<T>(this Model, System.Predicate<T>).T')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.List-1 'System.Collections.Generic.List`1')

<a name='BTD_Mod_Helper.Extensions.ModelExt.SetName_T_(thisT,string)'></a>

## ModelExt.SetName<T>(this T, string) Method

Sets the name of this model, properly appending the type prefix to it.  
<returns>The model itself</returns>

```csharp
public static T SetName<T>(this T model, string name)
    where T : Model;
```
#### Type parameters

<a name='BTD_Mod_Helper.Extensions.ModelExt.SetName_T_(thisT,string).T'></a>

`T`
#### Parameters

<a name='BTD_Mod_Helper.Extensions.ModelExt.SetName_T_(thisT,string).model'></a>

`model` [T](BTD_Mod_Helper.Extensions.ModelExt.md#BTD_Mod_Helper.Extensions.ModelExt.SetName_T_(thisT,string).T 'BTD_Mod_Helper.Extensions.ModelExt.SetName<T>(this T, string).T')

<a name='BTD_Mod_Helper.Extensions.ModelExt.SetName_T_(thisT,string).name'></a>

`name` [System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')

#### Returns
[T](BTD_Mod_Helper.Extensions.ModelExt.md#BTD_Mod_Helper.Extensions.ModelExt.SetName_T_(thisT,string).T 'BTD_Mod_Helper.Extensions.ModelExt.SetName<T>(this T, string).T')