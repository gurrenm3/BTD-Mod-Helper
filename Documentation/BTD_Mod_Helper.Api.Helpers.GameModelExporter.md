#### [BloonsTD6 Mod Helper](README.md 'README')
### [BTD_Mod_Helper.Api.Helpers](README.md#BTD_Mod_Helper.Api.Helpers 'BTD_Mod_Helper.Api.Helpers')

## GameModelExporter Class

Class for handily exporting elements of the GameModel to json files

```csharp
public static class GameModelExporter
```

Inheritance [System.Object](https://docs.microsoft.com/en-us/dotnet/api/System.Object 'System.Object') &#129106; GameModelExporter
### Methods

<a name='BTD_Mod_Helper.Api.Helpers.GameModelExporter.Export(Object,string)'></a>

## GameModelExporter.Export(Object, string) Method

Tries to save a specific object and logs doing so

```csharp
public static void Export(Object data, string path);
```
#### Parameters

<a name='BTD_Mod_Helper.Api.Helpers.GameModelExporter.Export(Object,string).data'></a>

`data` [Il2CppSystem.Object](https://docs.microsoft.com/en-us/dotnet/api/Il2CppSystem.Object 'Il2CppSystem.Object')

<a name='BTD_Mod_Helper.Api.Helpers.GameModelExporter.Export(Object,string).path'></a>

`path` [System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')

<a name='BTD_Mod_Helper.Api.Helpers.GameModelExporter.TryExport(Object,string)'></a>

## GameModelExporter.TryExport(Object, string) Method

Exports a Model to the path, returning whether it was successful. Does not log anything.

```csharp
public static bool TryExport(Object data, string path);
```
#### Parameters

<a name='BTD_Mod_Helper.Api.Helpers.GameModelExporter.TryExport(Object,string).data'></a>

`data` [Il2CppSystem.Object](https://docs.microsoft.com/en-us/dotnet/api/Il2CppSystem.Object 'Il2CppSystem.Object')

<a name='BTD_Mod_Helper.Api.Helpers.GameModelExporter.TryExport(Object,string).path'></a>

`path` [System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')

#### Returns
[System.Boolean](https://docs.microsoft.com/en-us/dotnet/api/System.Boolean 'System.Boolean')

<a name='BTD_Mod_Helper.Api.Helpers.GameModelExporter.TryExport(Object,string,System.Action_JObject_)'></a>

## GameModelExporter.TryExport(Object, string, Action<JObject>) Method

Exports a Model to the path, returning whether it was successful. Does not log anything.

```csharp
public static bool TryExport(Object data, string path, System.Action<JObject> modify);
```
#### Parameters

<a name='BTD_Mod_Helper.Api.Helpers.GameModelExporter.TryExport(Object,string,System.Action_JObject_).data'></a>

`data` [Il2CppSystem.Object](https://docs.microsoft.com/en-us/dotnet/api/Il2CppSystem.Object 'Il2CppSystem.Object')

<a name='BTD_Mod_Helper.Api.Helpers.GameModelExporter.TryExport(Object,string,System.Action_JObject_).path'></a>

`path` [System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')

<a name='BTD_Mod_Helper.Api.Helpers.GameModelExporter.TryExport(Object,string,System.Action_JObject_).modify'></a>

`modify` [System.Action&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Action-1 'System.Action`1')[Newtonsoft.Json.Linq.JObject](https://docs.microsoft.com/en-us/dotnet/api/Newtonsoft.Json.Linq.JObject 'Newtonsoft.Json.Linq.JObject')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Action-1 'System.Action`1')

#### Returns
[System.Boolean](https://docs.microsoft.com/en-us/dotnet/api/System.Boolean 'System.Boolean')