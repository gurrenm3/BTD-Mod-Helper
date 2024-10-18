#### [BloonsTD6 Mod Helper](README.md 'README')
### [BTD_Mod_Helper.Api.Helpers](README.md#BTD_Mod_Helper.Api.Helpers 'BTD_Mod_Helper.Api.Helpers')

## FileIOHelper Class

Class replacing the original functionality of FileIOUtil before BTD6 update 33.0

```csharp
public static class FileIOHelper
```

Inheritance [System.Object](https://docs.microsoft.com/en-us/dotnet/api/System.Object 'System.Object') &#129106; FileIOHelper
### Fields

<a name='BTD_Mod_Helper.Api.Helpers.FileIOHelper.Settings'></a>

## FileIOHelper.Settings Field

JSON Serializer settings used for methods in this class

```csharp
public static readonly JsonSerializerSettings Settings;
```

#### Field Value
[Il2CppNewtonsoft.Json.JsonSerializerSettings](https://docs.microsoft.com/en-us/dotnet/api/Il2CppNewtonsoft.Json.JsonSerializerSettings 'Il2CppNewtonsoft.Json.JsonSerializerSettings')
### Properties

<a name='BTD_Mod_Helper.Api.Helpers.FileIOHelper.sandboxRoot'></a>

## FileIOHelper.sandboxRoot Property

Same as the original FileIOUtil.sandboxRoot, INCLUDES A SLASH AT THE END

```csharp
public static string sandboxRoot { get; }
```

#### Property Value
[System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')
### Methods

<a name='BTD_Mod_Helper.Api.Helpers.FileIOHelper.GetSandboxPath()'></a>

## FileIOHelper.GetSandboxPath() Method

Same as the original FileIOUtil.GetSandboxPath(), INCLUDES A SLASH AT THE END

```csharp
public static string GetSandboxPath();
```

#### Returns
[System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')

<a name='BTD_Mod_Helper.Api.Helpers.FileIOHelper.LoadFile(string)'></a>

## FileIOHelper.LoadFile(string) Method

Same as the original FileIOUtil.LoadFile

```csharp
public static string LoadFile(string fileName);
```
#### Parameters

<a name='BTD_Mod_Helper.Api.Helpers.FileIOHelper.LoadFile(string).fileName'></a>

`fileName` [System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')

File name within the sandbox directory

#### Returns
[System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')

<a name='BTD_Mod_Helper.Api.Helpers.FileIOHelper.LoadObject_T_(string)'></a>

## FileIOHelper.LoadObject<T>(string) Method

Same as the original FileIOUtil.LoadObject

```csharp
public static T LoadObject<T>(string fileName)
    where T : Object;
```
#### Type parameters

<a name='BTD_Mod_Helper.Api.Helpers.FileIOHelper.LoadObject_T_(string).T'></a>

`T`
#### Parameters

<a name='BTD_Mod_Helper.Api.Helpers.FileIOHelper.LoadObject_T_(string).fileName'></a>

`fileName` [System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')

File name within the sandbox directory

#### Returns
[T](BTD_Mod_Helper.Api.Helpers.FileIOHelper.md#BTD_Mod_Helper.Api.Helpers.FileIOHelper.LoadObject_T_(string).T 'BTD_Mod_Helper.Api.Helpers.FileIOHelper.LoadObject<T>(string).T')

<a name='BTD_Mod_Helper.Api.Helpers.FileIOHelper.SaveFile(string,string)'></a>

## FileIOHelper.SaveFile(string, string) Method

Same as the original FileIOUtil.SaveFile

```csharp
public static void SaveFile(string fileName, string text);
```
#### Parameters

<a name='BTD_Mod_Helper.Api.Helpers.FileIOHelper.SaveFile(string,string).fileName'></a>

`fileName` [System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')

File name within the sandbox directory

<a name='BTD_Mod_Helper.Api.Helpers.FileIOHelper.SaveFile(string,string).text'></a>

`text` [System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')

Text file contents to save

<a name='BTD_Mod_Helper.Api.Helpers.FileIOHelper.SaveObject(string,Object)'></a>

## FileIOHelper.SaveObject(string, Object) Method

Saves an il2cpp object directly to the sandbox path like the original FileIOUtil.SaveObject  
<br/>  
Will also create subdirectories as needed to save the file

```csharp
public static void SaveObject(string fileName, Object data);
```
#### Parameters

<a name='BTD_Mod_Helper.Api.Helpers.FileIOHelper.SaveObject(string,Object).fileName'></a>

`fileName` [System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')

Name of file, extension included

<a name='BTD_Mod_Helper.Api.Helpers.FileIOHelper.SaveObject(string,Object).data'></a>

`data` [Il2CppSystem.Object](https://docs.microsoft.com/en-us/dotnet/api/Il2CppSystem.Object 'Il2CppSystem.Object')