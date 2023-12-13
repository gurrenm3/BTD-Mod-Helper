#### [BloonsTD6 Mod Helper](README.md 'README')
### [BTD_Mod_Helper.Api.Helpers](README.md#BTD_Mod_Helper.Api.Helpers 'BTD_Mod_Helper.Api.Helpers')

## ModelHelper<T> Class

A wrapper class around a Model

```csharp
public abstract class ModelHelper<T> : BTD_Mod_Helper.Api.Helpers.ModelHelper
    where T : Model
```
#### Type parameters

<a name='BTD_Mod_Helper.Api.Helpers.ModelHelper_T_.T'></a>

`T`

Inheritance [System.Object](https://docs.microsoft.com/en-us/dotnet/api/System.Object 'System.Object') &#129106; [ModelHelper](BTD_Mod_Helper.Api.Helpers.ModelHelper.md 'BTD_Mod_Helper.Api.Helpers.ModelHelper') &#129106; ModelHelper<T>

Derived  
&#8627; [AbilityHelper](BTD_Mod_Helper.Api.Helpers.AbilityHelper.md 'BTD_Mod_Helper.Api.Helpers.AbilityHelper')  
&#8627; [AttackHelper](BTD_Mod_Helper.Api.Helpers.AttackHelper.md 'BTD_Mod_Helper.Api.Helpers.AttackHelper')  
&#8627; [ProjectileHelper](BTD_Mod_Helper.Api.Helpers.ProjectileHelper.md 'BTD_Mod_Helper.Api.Helpers.ProjectileHelper')  
&#8627; [WeaponHelper](BTD_Mod_Helper.Api.Helpers.WeaponHelper.md 'BTD_Mod_Helper.Api.Helpers.WeaponHelper')
### Constructors

<a name='BTD_Mod_Helper.Api.Helpers.ModelHelper_T_.ModelHelper(T)'></a>

## ModelHelper(T) Constructor

Creates a wrapper around an existing model

```csharp
protected ModelHelper(T model);
```
#### Parameters

<a name='BTD_Mod_Helper.Api.Helpers.ModelHelper_T_.ModelHelper(T).model'></a>

`model` [T](BTD_Mod_Helper.Api.Helpers.ModelHelper_T_.md#BTD_Mod_Helper.Api.Helpers.ModelHelper_T_.T 'BTD_Mod_Helper.Api.Helpers.ModelHelper<T>.T')
### Properties

<a name='BTD_Mod_Helper.Api.Helpers.ModelHelper_T_.Model'></a>

## ModelHelper<T>.Model Property

The internal model

```csharp
public virtual T Model { get; }
```

#### Property Value
[T](BTD_Mod_Helper.Api.Helpers.ModelHelper_T_.md#BTD_Mod_Helper.Api.Helpers.ModelHelper_T_.T 'BTD_Mod_Helper.Api.Helpers.ModelHelper<T>.T')