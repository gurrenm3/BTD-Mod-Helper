#### [BloonsTD6 Mod Helper](README.md 'README')
### [BTD_Mod_Helper.Api.Helpers](README.md#BTD_Mod_Helper.Api.Helpers 'BTD_Mod_Helper.Api.Helpers')

## ModelSerializer Class

Handles serializing and deserializing models in a way that utilizes their actual constructors

```csharp
public static class ModelSerializer
```

Inheritance [System.Object](https://docs.microsoft.com/en-us/dotnet/api/System.Object 'System.Object') &#129106; ModelSerializer
### Methods

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