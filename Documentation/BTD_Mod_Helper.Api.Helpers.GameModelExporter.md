#### [BloonsTD6 Mod Helper](README.md 'README')
### [BTD_Mod_Helper.Api.Helpers](README.md#BTD_Mod_Helper.Api.Helpers 'BTD_Mod_Helper.Api.Helpers')

## GameModelExporter Class

Class for handily exporting elements of the GameModel to json files

```csharp
public static class GameModelExporter
```

Inheritance [System.Object](https://docs.microsoft.com/en-us/dotnet/api/System.Object 'System.Object') &#129106; GameModelExporter
### Methods

<a name='BTD_Mod_Helper.Api.Helpers.GameModelExporter.Export(Il2CppSystem.Object,string)'></a>

## GameModelExporter.Export(Object, string) Method

Tries to save a specific Model and logs doing so

```csharp
public static void Export(Il2CppSystem.Object data, string path);
```
#### Parameters

<a name='BTD_Mod_Helper.Api.Helpers.GameModelExporter.Export(Il2CppSystem.Object,string).data'></a>

`data` [Il2CppSystem.Object](https://docs.microsoft.com/en-us/dotnet/api/Il2CppSystem.Object 'Il2CppSystem.Object')

<a name='BTD_Mod_Helper.Api.Helpers.GameModelExporter.Export(Il2CppSystem.Object,string).path'></a>

`path` [System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')

<a name='BTD_Mod_Helper.Api.Helpers.GameModelExporter.ExportAll()'></a>

## GameModelExporter.ExportAll() Method

Exports every bit of GameModel and GameData info of note to the local folder

```csharp
public static void ExportAll();
```