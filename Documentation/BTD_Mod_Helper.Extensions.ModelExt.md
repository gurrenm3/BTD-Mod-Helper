#### [BloonsTD6 Mod Helper](README.md 'README')
### [BTD_Mod_Helper.Extensions](README.md#BTD_Mod_Helper.Extensions 'BTD_Mod_Helper.Extensions')

## ModelExt Class

Extensions for Models

```csharp
public static class ModelExt
```

Inheritance [System.Object](https://docs.microsoft.com/en-us/dotnet/api/System.Object 'System.Object') &#129106; ModelExt
### Methods

<a name='BTD_Mod_Helper.Extensions.ModelExt.AddChildDependants_T_(thisModel,System.Collections.Generic.IEnumerable_T_)'></a>

## ModelExt.AddChildDependants<T>(this Model, IEnumerable<T>) Method

Add multiple Child Dependants at the same time. Equivalent to calling the (weirdly non plural named) Model.AddChild  
method but without having to do an ICollection cast

```csharp
public static void AddChildDependants<T>(this Model model, System.Collections.Generic.IEnumerable<T> children)
    where T : Model;
```
#### Type parameters

<a name='BTD_Mod_Helper.Extensions.ModelExt.AddChildDependants_T_(thisModel,System.Collections.Generic.IEnumerable_T_).T'></a>

`T`
#### Parameters

<a name='BTD_Mod_Helper.Extensions.ModelExt.AddChildDependants_T_(thisModel,System.Collections.Generic.IEnumerable_T_).model'></a>

`model` [Il2CppAssets.Scripts.Models.Model](https://docs.microsoft.com/en-us/dotnet/api/Il2CppAssets.Scripts.Models.Model 'Il2CppAssets.Scripts.Models.Model')

<a name='BTD_Mod_Helper.Extensions.ModelExt.AddChildDependants_T_(thisModel,System.Collections.Generic.IEnumerable_T_).children'></a>

`children` [System.Collections.Generic.IEnumerable&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.IEnumerable-1 'System.Collections.Generic.IEnumerable`1')[T](BTD_Mod_Helper.Extensions.ModelExt.md#BTD_Mod_Helper.Extensions.ModelExt.AddChildDependants_T_(thisModel,System.Collections.Generic.IEnumerable_T_).T 'BTD_Mod_Helper.Extensions.ModelExt.AddChildDependants<T>(this Model, System.Collections.Generic.IEnumerable<T>).T')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.IEnumerable-1 'System.Collections.Generic.IEnumerable`1')

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

<a name='BTD_Mod_Helper.Extensions.ModelExt.FindDescendants_T_(thisModel)'></a>

## ModelExt.FindDescendants<T>(this Model) Method

Finds the descendents of a given type

```csharp
public static T[] FindDescendants<T>(this Model model)
    where T : Model;
```
#### Type parameters

<a name='BTD_Mod_Helper.Extensions.ModelExt.FindDescendants_T_(thisModel).T'></a>

`T`
#### Parameters

<a name='BTD_Mod_Helper.Extensions.ModelExt.FindDescendants_T_(thisModel).model'></a>

`model` [Il2CppAssets.Scripts.Models.Model](https://docs.microsoft.com/en-us/dotnet/api/Il2CppAssets.Scripts.Models.Model 'Il2CppAssets.Scripts.Models.Model')

#### Returns
[T](BTD_Mod_Helper.Extensions.ModelExt.md#BTD_Mod_Helper.Extensions.ModelExt.FindDescendants_T_(thisModel).T 'BTD_Mod_Helper.Extensions.ModelExt.FindDescendants<T>(this Model).T')[[]](https://docs.microsoft.com/en-us/dotnet/api/System.Array 'System.Array')

<a name='BTD_Mod_Helper.Extensions.ModelExt.FindDescendants_T_(thisModel,string)'></a>

## ModelExt.FindDescendants<T>(this Model, string) Method

Finds the descendents of a given type whose name contains the specified string

```csharp
public static T[] FindDescendants<T>(this Model model, string nameContains)
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
[T](BTD_Mod_Helper.Extensions.ModelExt.md#BTD_Mod_Helper.Extensions.ModelExt.FindDescendants_T_(thisModel,string).T 'BTD_Mod_Helper.Extensions.ModelExt.FindDescendants<T>(this Model, string).T')[[]](https://docs.microsoft.com/en-us/dotnet/api/System.Array 'System.Array')

<a name='BTD_Mod_Helper.Extensions.ModelExt.FindDescendants_T_(thisModel,System.Predicate_T_)'></a>

## ModelExt.FindDescendants<T>(this Model, Predicate<T>) Method

Finds the descendents of a given type that matches the given condition

```csharp
public static T[] FindDescendants<T>(this Model model, System.Predicate<T> condition)
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
[T](BTD_Mod_Helper.Extensions.ModelExt.md#BTD_Mod_Helper.Extensions.ModelExt.FindDescendants_T_(thisModel,System.Predicate_T_).T 'BTD_Mod_Helper.Extensions.ModelExt.FindDescendants<T>(this Model, System.Predicate<T>).T')[[]](https://docs.microsoft.com/en-us/dotnet/api/System.Array 'System.Array')

<a name='BTD_Mod_Helper.Extensions.ModelExt.HasDescendant_T_(thisModel)'></a>

## ModelExt.HasDescendant<T>(this Model) Method

Returns whether a model has a descendant of a given type

```csharp
public static bool HasDescendant<T>(this Model model)
    where T : Model;
```
#### Type parameters

<a name='BTD_Mod_Helper.Extensions.ModelExt.HasDescendant_T_(thisModel).T'></a>

`T`
#### Parameters

<a name='BTD_Mod_Helper.Extensions.ModelExt.HasDescendant_T_(thisModel).model'></a>

`model` [Il2CppAssets.Scripts.Models.Model](https://docs.microsoft.com/en-us/dotnet/api/Il2CppAssets.Scripts.Models.Model 'Il2CppAssets.Scripts.Models.Model')

#### Returns
[System.Boolean](https://docs.microsoft.com/en-us/dotnet/api/System.Boolean 'System.Boolean')

<a name='BTD_Mod_Helper.Extensions.ModelExt.HasDescendant_T_(thisModel,string,T)'></a>

## ModelExt.HasDescendant<T>(this Model, string, T) Method

Returns whether a model has a descendant of a given type with a filtered name, providing it via the out parameter if so

```csharp
public static bool HasDescendant<T>(this Model model, string nameContains, out T t)
    where T : Model;
```
#### Type parameters

<a name='BTD_Mod_Helper.Extensions.ModelExt.HasDescendant_T_(thisModel,string,T).T'></a>

`T`
#### Parameters

<a name='BTD_Mod_Helper.Extensions.ModelExt.HasDescendant_T_(thisModel,string,T).model'></a>

`model` [Il2CppAssets.Scripts.Models.Model](https://docs.microsoft.com/en-us/dotnet/api/Il2CppAssets.Scripts.Models.Model 'Il2CppAssets.Scripts.Models.Model')

<a name='BTD_Mod_Helper.Extensions.ModelExt.HasDescendant_T_(thisModel,string,T).nameContains'></a>

`nameContains` [System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')

<a name='BTD_Mod_Helper.Extensions.ModelExt.HasDescendant_T_(thisModel,string,T).t'></a>

`t` [T](BTD_Mod_Helper.Extensions.ModelExt.md#BTD_Mod_Helper.Extensions.ModelExt.HasDescendant_T_(thisModel,string,T).T 'BTD_Mod_Helper.Extensions.ModelExt.HasDescendant<T>(this Model, string, T).T')

#### Returns
[System.Boolean](https://docs.microsoft.com/en-us/dotnet/api/System.Boolean 'System.Boolean')

<a name='BTD_Mod_Helper.Extensions.ModelExt.HasDescendant_T_(thisModel,T)'></a>

## ModelExt.HasDescendant<T>(this Model, T) Method

Returns whether a model has a descendant of a given type, providing it via the out parameter if so

```csharp
public static bool HasDescendant<T>(this Model model, out T t)
    where T : Model;
```
#### Type parameters

<a name='BTD_Mod_Helper.Extensions.ModelExt.HasDescendant_T_(thisModel,T).T'></a>

`T`
#### Parameters

<a name='BTD_Mod_Helper.Extensions.ModelExt.HasDescendant_T_(thisModel,T).model'></a>

`model` [Il2CppAssets.Scripts.Models.Model](https://docs.microsoft.com/en-us/dotnet/api/Il2CppAssets.Scripts.Models.Model 'Il2CppAssets.Scripts.Models.Model')

<a name='BTD_Mod_Helper.Extensions.ModelExt.HasDescendant_T_(thisModel,T).t'></a>

`t` [T](BTD_Mod_Helper.Extensions.ModelExt.md#BTD_Mod_Helper.Extensions.ModelExt.HasDescendant_T_(thisModel,T).T 'BTD_Mod_Helper.Extensions.ModelExt.HasDescendant<T>(this Model, T).T')

#### Returns
[System.Boolean](https://docs.microsoft.com/en-us/dotnet/api/System.Boolean 'System.Boolean')

<a name='BTD_Mod_Helper.Extensions.ModelExt.RemoveChildDependants_T_(thisModel,System.Collections.Generic.IEnumerable_T_)'></a>

## ModelExt.RemoveChildDependants<T>(this Model, IEnumerable<T>) Method

Remove multiple Child Dependants at the same time. Equivalent to calling the (weirdly non plural named) Model.RemoveChild  
method but without having to do an ICollection cast

```csharp
public static void RemoveChildDependants<T>(this Model model, System.Collections.Generic.IEnumerable<T> children)
    where T : Model;
```
#### Type parameters

<a name='BTD_Mod_Helper.Extensions.ModelExt.RemoveChildDependants_T_(thisModel,System.Collections.Generic.IEnumerable_T_).T'></a>

`T`
#### Parameters

<a name='BTD_Mod_Helper.Extensions.ModelExt.RemoveChildDependants_T_(thisModel,System.Collections.Generic.IEnumerable_T_).model'></a>

`model` [Il2CppAssets.Scripts.Models.Model](https://docs.microsoft.com/en-us/dotnet/api/Il2CppAssets.Scripts.Models.Model 'Il2CppAssets.Scripts.Models.Model')

<a name='BTD_Mod_Helper.Extensions.ModelExt.RemoveChildDependants_T_(thisModel,System.Collections.Generic.IEnumerable_T_).children'></a>

`children` [System.Collections.Generic.IEnumerable&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.IEnumerable-1 'System.Collections.Generic.IEnumerable`1')[T](BTD_Mod_Helper.Extensions.ModelExt.md#BTD_Mod_Helper.Extensions.ModelExt.RemoveChildDependants_T_(thisModel,System.Collections.Generic.IEnumerable_T_).T 'BTD_Mod_Helper.Extensions.ModelExt.RemoveChildDependants<T>(this Model, System.Collections.Generic.IEnumerable<T>).T')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.IEnumerable-1 'System.Collections.Generic.IEnumerable`1')

<a name='BTD_Mod_Helper.Extensions.ModelExt.SetName_T_(thisT,string)'></a>

## ModelExt.SetName<T>(this T, string) Method

Sets the name of this model, properly appending the type prefix to it.  
<br/>  
Also sets the id if it's a ProjectileModel  
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