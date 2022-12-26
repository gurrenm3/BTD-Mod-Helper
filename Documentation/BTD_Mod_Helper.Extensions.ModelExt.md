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
    where T : Il2CppAssets.Scripts.Models.Model;
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