#### [BloonsTD6 Mod Helper](README.md 'README')
### [BTD_Mod_Helper.Api](README.md#BTD_Mod_Helper.Api 'BTD_Mod_Helper.Api')

## ModMenuData Class

Class to be passed in to the Open methods of Screens

```csharp
public class ModMenuData
```

Inheritance [Il2CppSystem.Object](https://docs.microsoft.com/en-us/dotnet/api/Il2CppSystem.Object 'Il2CppSystem.Object') &#129106; ModMenuData
### Constructors

<a name='BTD_Mod_Helper.Api.ModMenuData.ModMenuData(string,Object,Object)'></a>

## ModMenuData(string, Object, Object) Constructor

Creates a ModMenuData object with the given Id and data

```csharp
public ModMenuData(string id, Object modData, Object baseData);
```
#### Parameters

<a name='BTD_Mod_Helper.Api.ModMenuData.ModMenuData(string,Object,Object).id'></a>

`id` [System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')

<a name='BTD_Mod_Helper.Api.ModMenuData.ModMenuData(string,Object,Object).modData'></a>

`modData` [Il2CppSystem.Object](https://docs.microsoft.com/en-us/dotnet/api/Il2CppSystem.Object 'Il2CppSystem.Object')

<a name='BTD_Mod_Helper.Api.ModMenuData.ModMenuData(string,Object,Object).baseData'></a>

`baseData` [Il2CppSystem.Object](https://docs.microsoft.com/en-us/dotnet/api/Il2CppSystem.Object 'Il2CppSystem.Object')
### Fields

<a name='BTD_Mod_Helper.Api.ModMenuData.baseData'></a>

## ModMenuData.baseData Field

The data that the base menu receives, if the Open code is still run

```csharp
public Object baseData;
```

#### Field Value
[Il2CppSystem.Object](https://docs.microsoft.com/en-us/dotnet/api/Il2CppSystem.Object 'Il2CppSystem.Object')

<a name='BTD_Mod_Helper.Api.ModMenuData.id'></a>

## ModMenuData.id Field

The id of the ModGameMenu this is for

```csharp
public string id;
```

#### Field Value
[System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')

<a name='BTD_Mod_Helper.Api.ModMenuData.modData'></a>

## ModMenuData.modData Field

The data that the ModGameMenu receives

```csharp
public Object modData;
```

#### Field Value
[Il2CppSystem.Object](https://docs.microsoft.com/en-us/dotnet/api/Il2CppSystem.Object 'Il2CppSystem.Object')