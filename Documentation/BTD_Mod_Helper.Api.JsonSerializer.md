#### [BloonsTD6 Mod Helper](README.md 'README')
### [BTD_Mod_Helper.Api](README.md#BTD_Mod_Helper.Api 'BTD_Mod_Helper.Api')

## JsonSerializer Class

Class for serializing and deserializing JSON files

```csharp
public class JsonSerializer
```

Inheritance [System.Object](https://docs.microsoft.com/en-us/dotnet/api/System.Object 'System.Object') &#129106; JsonSerializer
### Fields

<a name='BTD_Mod_Helper.Api.JsonSerializer.instance'></a>

## JsonSerializer.instance Field

Singleton instance for this class

```csharp
public static JsonSerializer instance;
```

#### Field Value
[JsonSerializer](BTD_Mod_Helper.Api.JsonSerializer.md 'BTD_Mod_Helper.Api.JsonSerializer')
### Methods

<a name='BTD_Mod_Helper.Api.JsonSerializer.DeserializeJson_T_(string)'></a>

## JsonSerializer.DeserializeJson<T>(string) Method

Deserialize a non-Il2cpp object

```csharp
public T DeserializeJson<T>(string text);
```
#### Type parameters

<a name='BTD_Mod_Helper.Api.JsonSerializer.DeserializeJson_T_(string).T'></a>

`T`
#### Parameters

<a name='BTD_Mod_Helper.Api.JsonSerializer.DeserializeJson_T_(string).text'></a>

`text` [System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')

#### Returns
[T](BTD_Mod_Helper.Api.JsonSerializer.md#BTD_Mod_Helper.Api.JsonSerializer.DeserializeJson_T_(string).T 'BTD_Mod_Helper.Api.JsonSerializer.DeserializeJson<T>(string).T')

<a name='BTD_Mod_Helper.Api.JsonSerializer.Il2CppDeserializeJson_T_(string)'></a>

## JsonSerializer.Il2CppDeserializeJson<T>(string) Method

Deserialize an Il2cpp object

```csharp
public T Il2CppDeserializeJson<T>(string text);
```
#### Type parameters

<a name='BTD_Mod_Helper.Api.JsonSerializer.Il2CppDeserializeJson_T_(string).T'></a>

`T`
#### Parameters

<a name='BTD_Mod_Helper.Api.JsonSerializer.Il2CppDeserializeJson_T_(string).text'></a>

`text` [System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')

#### Returns
[T](BTD_Mod_Helper.Api.JsonSerializer.md#BTD_Mod_Helper.Api.JsonSerializer.Il2CppDeserializeJson_T_(string).T 'BTD_Mod_Helper.Api.JsonSerializer.Il2CppDeserializeJson<T>(string).T')

<a name='BTD_Mod_Helper.Api.JsonSerializer.Il2CppLoadFromFile_T_(string)'></a>

## JsonSerializer.Il2CppLoadFromFile<T>(string) Method

Create an instance of an il2cpp class from file

```csharp
public T Il2CppLoadFromFile<T>(string filePath)
    where T : class;
```
#### Type parameters

<a name='BTD_Mod_Helper.Api.JsonSerializer.Il2CppLoadFromFile_T_(string).T'></a>

`T`

The type to load
#### Parameters

<a name='BTD_Mod_Helper.Api.JsonSerializer.Il2CppLoadFromFile_T_(string).filePath'></a>

`filePath` [System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')

Location of the file

#### Returns
[T](BTD_Mod_Helper.Api.JsonSerializer.md#BTD_Mod_Helper.Api.JsonSerializer.Il2CppLoadFromFile_T_(string).T 'BTD_Mod_Helper.Api.JsonSerializer.Il2CppLoadFromFile<T>(string).T')

<a name='BTD_Mod_Helper.Api.JsonSerializer.Il2CppSaveToFile_T_(T,string,bool,bool)'></a>

## JsonSerializer.Il2CppSaveToFile<T>(T, string, bool, bool) Method

Save an instance of a class to file

```csharp
public void Il2CppSaveToFile<T>(T jsonObject, string savePath, bool shouldIndent=true, bool overwriteExisting=true)
    where T : Object;
```
#### Type parameters

<a name='BTD_Mod_Helper.Api.JsonSerializer.Il2CppSaveToFile_T_(T,string,bool,bool).T'></a>

`T`

Type of class to save
#### Parameters

<a name='BTD_Mod_Helper.Api.JsonSerializer.Il2CppSaveToFile_T_(T,string,bool,bool).jsonObject'></a>

`jsonObject` [T](BTD_Mod_Helper.Api.JsonSerializer.md#BTD_Mod_Helper.Api.JsonSerializer.Il2CppSaveToFile_T_(T,string,bool,bool).T 'BTD_Mod_Helper.Api.JsonSerializer.Il2CppSaveToFile<T>(T, string, bool, bool).T')

Object to save. Must be of Type T

<a name='BTD_Mod_Helper.Api.JsonSerializer.Il2CppSaveToFile_T_(T,string,bool,bool).savePath'></a>

`savePath` [System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')

Location to save file to

<a name='BTD_Mod_Helper.Api.JsonSerializer.Il2CppSaveToFile_T_(T,string,bool,bool).shouldIndent'></a>

`shouldIndent` [System.Boolean](https://docs.microsoft.com/en-us/dotnet/api/System.Boolean 'System.Boolean')

Whether it should be indented

<a name='BTD_Mod_Helper.Api.JsonSerializer.Il2CppSaveToFile_T_(T,string,bool,bool).overwriteExisting'></a>

`overwriteExisting` [System.Boolean](https://docs.microsoft.com/en-us/dotnet/api/System.Boolean 'System.Boolean')

Overwrite the file if it already exists

<a name='BTD_Mod_Helper.Api.JsonSerializer.Il2CppSerializeJson_T_(T,bool)'></a>

## JsonSerializer.Il2CppSerializeJson<T>(T, bool) Method

Serialize a il2cpp object

```csharp
public string Il2CppSerializeJson<T>(T il2cppObject, bool shouldIndent=true)
    where T : Object;
```
#### Type parameters

<a name='BTD_Mod_Helper.Api.JsonSerializer.Il2CppSerializeJson_T_(T,bool).T'></a>

`T`
#### Parameters

<a name='BTD_Mod_Helper.Api.JsonSerializer.Il2CppSerializeJson_T_(T,bool).il2cppObject'></a>

`il2cppObject` [T](BTD_Mod_Helper.Api.JsonSerializer.md#BTD_Mod_Helper.Api.JsonSerializer.Il2CppSerializeJson_T_(T,bool).T 'BTD_Mod_Helper.Api.JsonSerializer.Il2CppSerializeJson<T>(T, bool).T')

<a name='BTD_Mod_Helper.Api.JsonSerializer.Il2CppSerializeJson_T_(T,bool).shouldIndent'></a>

`shouldIndent` [System.Boolean](https://docs.microsoft.com/en-us/dotnet/api/System.Boolean 'System.Boolean')

#### Returns
[System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')

<a name='BTD_Mod_Helper.Api.JsonSerializer.LoadFromFile_T_(string)'></a>

## JsonSerializer.LoadFromFile<T>(string) Method

Create an instance of a class from file

```csharp
public T LoadFromFile<T>(string filePath)
    where T : class;
```
#### Type parameters

<a name='BTD_Mod_Helper.Api.JsonSerializer.LoadFromFile_T_(string).T'></a>

`T`

The type to load
#### Parameters

<a name='BTD_Mod_Helper.Api.JsonSerializer.LoadFromFile_T_(string).filePath'></a>

`filePath` [System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')

Location of the file

#### Returns
[T](BTD_Mod_Helper.Api.JsonSerializer.md#BTD_Mod_Helper.Api.JsonSerializer.LoadFromFile_T_(string).T 'BTD_Mod_Helper.Api.JsonSerializer.LoadFromFile<T>(string).T')

<a name='BTD_Mod_Helper.Api.JsonSerializer.SaveToFile_T_(T,string,bool,bool,bool)'></a>

## JsonSerializer.SaveToFile<T>(T, string, bool, bool, bool) Method

Save an instance of a class to file

```csharp
public void SaveToFile<T>(T jsonObject, string savePath, bool shouldIndent=true, bool ignoreNulls=false, bool overwriteExisting=true);
```
#### Type parameters

<a name='BTD_Mod_Helper.Api.JsonSerializer.SaveToFile_T_(T,string,bool,bool,bool).T'></a>

`T`

Type of class to save
#### Parameters

<a name='BTD_Mod_Helper.Api.JsonSerializer.SaveToFile_T_(T,string,bool,bool,bool).jsonObject'></a>

`jsonObject` [T](BTD_Mod_Helper.Api.JsonSerializer.md#BTD_Mod_Helper.Api.JsonSerializer.SaveToFile_T_(T,string,bool,bool,bool).T 'BTD_Mod_Helper.Api.JsonSerializer.SaveToFile<T>(T, string, bool, bool, bool).T')

Object to save. Must be of Type T

<a name='BTD_Mod_Helper.Api.JsonSerializer.SaveToFile_T_(T,string,bool,bool,bool).savePath'></a>

`savePath` [System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')

Location to save file to

<a name='BTD_Mod_Helper.Api.JsonSerializer.SaveToFile_T_(T,string,bool,bool,bool).shouldIndent'></a>

`shouldIndent` [System.Boolean](https://docs.microsoft.com/en-us/dotnet/api/System.Boolean 'System.Boolean')

Whether it should be indented

<a name='BTD_Mod_Helper.Api.JsonSerializer.SaveToFile_T_(T,string,bool,bool,bool).ignoreNulls'></a>

`ignoreNulls` [System.Boolean](https://docs.microsoft.com/en-us/dotnet/api/System.Boolean 'System.Boolean')

Whether nulls should be ignored

<a name='BTD_Mod_Helper.Api.JsonSerializer.SaveToFile_T_(T,string,bool,bool,bool).overwriteExisting'></a>

`overwriteExisting` [System.Boolean](https://docs.microsoft.com/en-us/dotnet/api/System.Boolean 'System.Boolean')

Overwrite the file if it already exists

<a name='BTD_Mod_Helper.Api.JsonSerializer.SaveToFile_T_(T,string,JsonSerializerSettings,bool,bool)'></a>

## JsonSerializer.SaveToFile<T>(T, string, JsonSerializerSettings, bool, bool) Method

Save an instance of a class to file

```csharp
public void SaveToFile<T>(T jsonObject, string savePath, JsonSerializerSettings serializerSettings, bool shouldIndent=true, bool overwriteExisting=true);
```
#### Type parameters

<a name='BTD_Mod_Helper.Api.JsonSerializer.SaveToFile_T_(T,string,JsonSerializerSettings,bool,bool).T'></a>

`T`

Type of class to save
#### Parameters

<a name='BTD_Mod_Helper.Api.JsonSerializer.SaveToFile_T_(T,string,JsonSerializerSettings,bool,bool).jsonObject'></a>

`jsonObject` [T](BTD_Mod_Helper.Api.JsonSerializer.md#BTD_Mod_Helper.Api.JsonSerializer.SaveToFile_T_(T,string,JsonSerializerSettings,bool,bool).T 'BTD_Mod_Helper.Api.JsonSerializer.SaveToFile<T>(T, string, JsonSerializerSettings, bool, bool).T')

Object to save. Must be of Type T

<a name='BTD_Mod_Helper.Api.JsonSerializer.SaveToFile_T_(T,string,JsonSerializerSettings,bool,bool).savePath'></a>

`savePath` [System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')

Location to save file to

<a name='BTD_Mod_Helper.Api.JsonSerializer.SaveToFile_T_(T,string,JsonSerializerSettings,bool,bool).serializerSettings'></a>

`serializerSettings` [Newtonsoft.Json.JsonSerializerSettings](https://docs.microsoft.com/en-us/dotnet/api/Newtonsoft.Json.JsonSerializerSettings 'Newtonsoft.Json.JsonSerializerSettings')

<a name='BTD_Mod_Helper.Api.JsonSerializer.SaveToFile_T_(T,string,JsonSerializerSettings,bool,bool).shouldIndent'></a>

`shouldIndent` [System.Boolean](https://docs.microsoft.com/en-us/dotnet/api/System.Boolean 'System.Boolean')

Whether it should be indented

<a name='BTD_Mod_Helper.Api.JsonSerializer.SaveToFile_T_(T,string,JsonSerializerSettings,bool,bool).overwriteExisting'></a>

`overwriteExisting` [System.Boolean](https://docs.microsoft.com/en-us/dotnet/api/System.Boolean 'System.Boolean')

Overwrite the file if it already exists

<a name='BTD_Mod_Helper.Api.JsonSerializer.SerializeJson_T_(T,bool,bool)'></a>

## JsonSerializer.SerializeJson<T>(T, bool, bool) Method

Serialize a non-il2cpp object

```csharp
public string SerializeJson<T>(T objectToSerialize, bool shouldIndent=true, bool ignoreNulls=false);
```
#### Type parameters

<a name='BTD_Mod_Helper.Api.JsonSerializer.SerializeJson_T_(T,bool,bool).T'></a>

`T`
#### Parameters

<a name='BTD_Mod_Helper.Api.JsonSerializer.SerializeJson_T_(T,bool,bool).objectToSerialize'></a>

`objectToSerialize` [T](BTD_Mod_Helper.Api.JsonSerializer.md#BTD_Mod_Helper.Api.JsonSerializer.SerializeJson_T_(T,bool,bool).T 'BTD_Mod_Helper.Api.JsonSerializer.SerializeJson<T>(T, bool, bool).T')

<a name='BTD_Mod_Helper.Api.JsonSerializer.SerializeJson_T_(T,bool,bool).shouldIndent'></a>

`shouldIndent` [System.Boolean](https://docs.microsoft.com/en-us/dotnet/api/System.Boolean 'System.Boolean')

<a name='BTD_Mod_Helper.Api.JsonSerializer.SerializeJson_T_(T,bool,bool).ignoreNulls'></a>

`ignoreNulls` [System.Boolean](https://docs.microsoft.com/en-us/dotnet/api/System.Boolean 'System.Boolean')

#### Returns
[System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')

<a name='BTD_Mod_Helper.Api.JsonSerializer.SerializeJson_T_(T,JsonSerializerSettings,bool)'></a>

## JsonSerializer.SerializeJson<T>(T, JsonSerializerSettings, bool) Method

Serialize a non-il2cpp object

```csharp
public string SerializeJson<T>(T objectToSerialize, JsonSerializerSettings serializerSettings, bool shouldIndent=true);
```
#### Type parameters

<a name='BTD_Mod_Helper.Api.JsonSerializer.SerializeJson_T_(T,JsonSerializerSettings,bool).T'></a>

`T`
#### Parameters

<a name='BTD_Mod_Helper.Api.JsonSerializer.SerializeJson_T_(T,JsonSerializerSettings,bool).objectToSerialize'></a>

`objectToSerialize` [T](BTD_Mod_Helper.Api.JsonSerializer.md#BTD_Mod_Helper.Api.JsonSerializer.SerializeJson_T_(T,JsonSerializerSettings,bool).T 'BTD_Mod_Helper.Api.JsonSerializer.SerializeJson<T>(T, JsonSerializerSettings, bool).T')

<a name='BTD_Mod_Helper.Api.JsonSerializer.SerializeJson_T_(T,JsonSerializerSettings,bool).serializerSettings'></a>

`serializerSettings` [Newtonsoft.Json.JsonSerializerSettings](https://docs.microsoft.com/en-us/dotnet/api/Newtonsoft.Json.JsonSerializerSettings 'Newtonsoft.Json.JsonSerializerSettings')

<a name='BTD_Mod_Helper.Api.JsonSerializer.SerializeJson_T_(T,JsonSerializerSettings,bool).shouldIndent'></a>

`shouldIndent` [System.Boolean](https://docs.microsoft.com/en-us/dotnet/api/System.Boolean 'System.Boolean')

#### Returns
[System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')