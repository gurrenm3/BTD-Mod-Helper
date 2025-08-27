#### [BloonsTD6 Mod Helper](README.md 'README')
### [BTD_Mod_Helper.Extensions](README.md#BTD_Mod_Helper.Extensions 'BTD_Mod_Helper.Extensions')

## AssemblyExt Class

Extensions for Assemblies

```csharp
public static class AssemblyExt
```

Inheritance [System.Object](https://docs.microsoft.com/en-us/dotnet/api/System.Object 'System.Object') &#129106; AssemblyExt
### Methods

<a name='BTD_Mod_Helper.Extensions.AssemblyExt.GetEmbeddedJson(thisSystem.Reflection.Assembly,string)'></a>

## AssemblyExt.GetEmbeddedJson(this Assembly, string) Method

Gets the contents of an embedded file in this assembly as json object

```csharp
public static JObject GetEmbeddedJson(this System.Reflection.Assembly assembly, string endsWith);
```
#### Parameters

<a name='BTD_Mod_Helper.Extensions.AssemblyExt.GetEmbeddedJson(thisSystem.Reflection.Assembly,string).assembly'></a>

`assembly` [System.Reflection.Assembly](https://docs.microsoft.com/en-us/dotnet/api/System.Reflection.Assembly 'System.Reflection.Assembly')

<a name='BTD_Mod_Helper.Extensions.AssemblyExt.GetEmbeddedJson(thisSystem.Reflection.Assembly,string).endsWith'></a>

`endsWith` [System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')

#### Returns
[Newtonsoft.Json.Linq.JObject](https://docs.microsoft.com/en-us/dotnet/api/Newtonsoft.Json.Linq.JObject 'Newtonsoft.Json.Linq.JObject')

<a name='BTD_Mod_Helper.Extensions.AssemblyExt.GetEmbeddedResource(thisSystem.Reflection.Assembly,string)'></a>

## AssemblyExt.GetEmbeddedResource(this Assembly, string) Method

Gets the bytes for an embedded resource with the given name (found with endsWith), or null if no matches

```csharp
public static System.IO.Stream GetEmbeddedResource(this System.Reflection.Assembly assembly, string endsWith);
```
#### Parameters

<a name='BTD_Mod_Helper.Extensions.AssemblyExt.GetEmbeddedResource(thisSystem.Reflection.Assembly,string).assembly'></a>

`assembly` [System.Reflection.Assembly](https://docs.microsoft.com/en-us/dotnet/api/System.Reflection.Assembly 'System.Reflection.Assembly')

<a name='BTD_Mod_Helper.Extensions.AssemblyExt.GetEmbeddedResource(thisSystem.Reflection.Assembly,string).endsWith'></a>

`endsWith` [System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')

#### Returns
[System.IO.Stream](https://docs.microsoft.com/en-us/dotnet/api/System.IO.Stream 'System.IO.Stream')

<a name='BTD_Mod_Helper.Extensions.AssemblyExt.GetEmbeddedText(thisSystem.Reflection.Assembly,string)'></a>

## AssemblyExt.GetEmbeddedText(this Assembly, string) Method

Gets the contents of an embedded file in this assembly as plain text (UTF8)

```csharp
public static string GetEmbeddedText(this System.Reflection.Assembly assembly, string endsWith);
```
#### Parameters

<a name='BTD_Mod_Helper.Extensions.AssemblyExt.GetEmbeddedText(thisSystem.Reflection.Assembly,string).assembly'></a>

`assembly` [System.Reflection.Assembly](https://docs.microsoft.com/en-us/dotnet/api/System.Reflection.Assembly 'System.Reflection.Assembly')

<a name='BTD_Mod_Helper.Extensions.AssemblyExt.GetEmbeddedText(thisSystem.Reflection.Assembly,string).endsWith'></a>

`endsWith` [System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')

#### Returns
[System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')

<a name='BTD_Mod_Helper.Extensions.AssemblyExt.TryGetEmbeddedResource(thisSystem.Reflection.Assembly,string,System.IO.Stream)'></a>

## AssemblyExt.TryGetEmbeddedResource(this Assembly, string, Stream) Method

Gets the bytes for an embedded resource with the given name (found with endsWith), or null if no matches

```csharp
public static bool TryGetEmbeddedResource(this System.Reflection.Assembly assembly, string endsWith, out System.IO.Stream stream);
```
#### Parameters

<a name='BTD_Mod_Helper.Extensions.AssemblyExt.TryGetEmbeddedResource(thisSystem.Reflection.Assembly,string,System.IO.Stream).assembly'></a>

`assembly` [System.Reflection.Assembly](https://docs.microsoft.com/en-us/dotnet/api/System.Reflection.Assembly 'System.Reflection.Assembly')

<a name='BTD_Mod_Helper.Extensions.AssemblyExt.TryGetEmbeddedResource(thisSystem.Reflection.Assembly,string,System.IO.Stream).endsWith'></a>

`endsWith` [System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')

<a name='BTD_Mod_Helper.Extensions.AssemblyExt.TryGetEmbeddedResource(thisSystem.Reflection.Assembly,string,System.IO.Stream).stream'></a>

`stream` [System.IO.Stream](https://docs.microsoft.com/en-us/dotnet/api/System.IO.Stream 'System.IO.Stream')

#### Returns
[System.Boolean](https://docs.microsoft.com/en-us/dotnet/api/System.Boolean 'System.Boolean')