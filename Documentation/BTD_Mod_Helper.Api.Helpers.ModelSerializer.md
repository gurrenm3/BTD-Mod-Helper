#### [BloonsTD6 Mod Helper](README.md 'README')
### [BTD_Mod_Helper.Api.Helpers](README.md#BTD_Mod_Helper.Api.Helpers 'BTD_Mod_Helper.Api.Helpers')

## ModelSerializer Class

Handles serializing and deserializing models in a way that utilizes their actual constructors

```csharp
public static class ModelSerializer
```

Inheritance [System.Object](https://docs.microsoft.com/en-us/dotnet/api/System.Object 'System.Object') &#129106; ModelSerializer
### Methods

<a name='BTD_Mod_Helper.Api.Helpers.ModelSerializer.DeserializeModel(JObject,System.Type)'></a>

## ModelSerializer.DeserializeModel(JObject, Type) Method

Recreates a model from serialized JSON, attempting to exactly recreate its types and references

```csharp
public static object DeserializeModel(JObject jObject, System.Type type);
```
#### Parameters

<a name='BTD_Mod_Helper.Api.Helpers.ModelSerializer.DeserializeModel(JObject,System.Type).jObject'></a>

`jObject` [Newtonsoft.Json.Linq.JObject](https://docs.microsoft.com/en-us/dotnet/api/Newtonsoft.Json.Linq.JObject 'Newtonsoft.Json.Linq.JObject')

Serialized model JSON

<a name='BTD_Mod_Helper.Api.Helpers.ModelSerializer.DeserializeModel(JObject,System.Type).type'></a>

`type` [System.Type](https://docs.microsoft.com/en-us/dotnet/api/System.Type 'System.Type')

The type of Model to deserialize this as

#### Returns
[System.Object](https://docs.microsoft.com/en-us/dotnet/api/System.Object 'System.Object')

<a name='BTD_Mod_Helper.Api.Helpers.ModelSerializer.DeserializeModel_T_(JObject)'></a>

## ModelSerializer.DeserializeModel<T>(JObject) Method

Recreates a model from serialized JSON, attempting to exactly recreate its types and references

```csharp
public static T DeserializeModel<T>(JObject jObject)
    where T : Model;
```
#### Type parameters

<a name='BTD_Mod_Helper.Api.Helpers.ModelSerializer.DeserializeModel_T_(JObject).T'></a>

`T`

The type of Model to deserialize this as
#### Parameters

<a name='BTD_Mod_Helper.Api.Helpers.ModelSerializer.DeserializeModel_T_(JObject).jObject'></a>

`jObject` [Newtonsoft.Json.Linq.JObject](https://docs.microsoft.com/en-us/dotnet/api/Newtonsoft.Json.Linq.JObject 'Newtonsoft.Json.Linq.JObject')

Serialized model JSON

#### Returns
[T](BTD_Mod_Helper.Api.Helpers.ModelSerializer.md#BTD_Mod_Helper.Api.Helpers.ModelSerializer.DeserializeModel_T_(JObject).T 'BTD_Mod_Helper.Api.Helpers.ModelSerializer.DeserializeModel<T>(JObject).T')

<a name='BTD_Mod_Helper.Api.Helpers.ModelSerializer.DeserializeModel_T_(string)'></a>

## ModelSerializer.DeserializeModel<T>(string) Method

Recreates a model from serialized JSON, attempting to exactly recreate its types and references

```csharp
public static T DeserializeModel<T>(string text)
    where T : Model;
```
#### Type parameters

<a name='BTD_Mod_Helper.Api.Helpers.ModelSerializer.DeserializeModel_T_(string).T'></a>

`T`

The type of Model to deserialize this as
#### Parameters

<a name='BTD_Mod_Helper.Api.Helpers.ModelSerializer.DeserializeModel_T_(string).text'></a>

`text` [System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')

Serialized model JSON string

#### Returns
[T](BTD_Mod_Helper.Api.Helpers.ModelSerializer.md#BTD_Mod_Helper.Api.Helpers.ModelSerializer.DeserializeModel_T_(string).T 'BTD_Mod_Helper.Api.Helpers.ModelSerializer.DeserializeModel<T>(string).T')

<a name='BTD_Mod_Helper.Api.Helpers.ModelSerializer.SerializeModel(Model)'></a>

## ModelSerializer.SerializeModel(Model) Method

Serializes a model to JSON, preserving types and references

```csharp
public static string SerializeModel(Model model);
```
#### Parameters

<a name='BTD_Mod_Helper.Api.Helpers.ModelSerializer.SerializeModel(Model).model'></a>

`model` [Il2CppAssets.Scripts.Models.Model](https://docs.microsoft.com/en-us/dotnet/api/Il2CppAssets.Scripts.Models.Model 'Il2CppAssets.Scripts.Models.Model')

#### Returns
[System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')