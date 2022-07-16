#### [BloonsTD6 Mod Helper](index.md 'index')
### [BTD_Mod_Helper.Extensions](index.md#BTD_Mod_Helper.Extensions 'BTD_Mod_Helper.Extensions')

## AssemblyExt Class

Extensions for Assemblies

```csharp
public static class AssemblyExt
```

Inheritance [System.Object](https://docs.microsoft.com/en-us/dotnet/api/System.Object 'System.Object') &#129106; AssemblyExt
### Methods

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