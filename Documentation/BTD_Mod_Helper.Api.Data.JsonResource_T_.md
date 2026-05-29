#### [BloonsTD6 Mod Helper](README.md 'README')
### [BTD_Mod_Helper.Api.Data](README.md#BTD_Mod_Helper.Api.Data 'BTD_Mod_Helper.Api.Data')

## JsonResource<T> Class

An embedded JSON resource belonging to mod [T](BTD_Mod_Helper.Api.Data.JsonResource_T_.md#BTD_Mod_Helper.Api.Data.JsonResource_T_.T 'BTD_Mod_Helper.Api.Data.JsonResource<T>.T').

```csharp
public class JsonResource<T> : BTD_Mod_Helper.Api.Data.Resource
    where T : BTD_Mod_Helper.BloonsMod
```
#### Type parameters

<a name='BTD_Mod_Helper.Api.Data.JsonResource_T_.T'></a>

`T`

Inheritance [System.Object](https://docs.microsoft.com/en-us/dotnet/api/System.Object 'System.Object') &#129106; [Resource](BTD_Mod_Helper.Api.Data.Resource.md 'BTD_Mod_Helper.Api.Data.Resource') &#129106; JsonResource<T>
### Constructors

<a name='BTD_Mod_Helper.Api.Data.JsonResource_T_.JsonResource(string)'></a>

## JsonResource(string) Constructor

An embedded JSON resource belonging to mod [T](BTD_Mod_Helper.Api.Data.JsonResource_T_.md#BTD_Mod_Helper.Api.Data.JsonResource_T_.T 'BTD_Mod_Helper.Api.Data.JsonResource<T>.T').

```csharp
public JsonResource(string name);
```
#### Parameters

<a name='BTD_Mod_Helper.Api.Data.JsonResource_T_.JsonResource(string).name'></a>

`name` [System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')
### Properties

<a name='BTD_Mod_Helper.Api.Data.JsonResource_T_.Json'></a>

## JsonResource<T>.Json Property

The parsed [Newtonsoft.Json.Linq.JObject](https://docs.microsoft.com/en-us/dotnet/api/Newtonsoft.Json.Linq.JObject 'Newtonsoft.Json.Linq.JObject') contents of this resource.

```csharp
public virtual JObject Json { get; }
```

#### Property Value
[Newtonsoft.Json.Linq.JObject](https://docs.microsoft.com/en-us/dotnet/api/Newtonsoft.Json.Linq.JObject 'Newtonsoft.Json.Linq.JObject')
### Operators

<a name='BTD_Mod_Helper.Api.Data.JsonResource_T_.op_ImplicitJObject(BTD_Mod_Helper.Api.Data.JsonResource_T_)'></a>

## JsonResource<T>.implicit operator JObject(JsonResource<T>) Operator

Implicit conversion to [Newtonsoft.Json.Linq.JObject](https://docs.microsoft.com/en-us/dotnet/api/Newtonsoft.Json.Linq.JObject 'Newtonsoft.Json.Linq.JObject').

```csharp
public static JObject implicit operator JObject(BTD_Mod_Helper.Api.Data.JsonResource<T> resource);
```
#### Parameters

<a name='BTD_Mod_Helper.Api.Data.JsonResource_T_.op_ImplicitJObject(BTD_Mod_Helper.Api.Data.JsonResource_T_).resource'></a>

`resource` [BTD_Mod_Helper.Api.Data.JsonResource&lt;](BTD_Mod_Helper.Api.Data.JsonResource_T_.md 'BTD_Mod_Helper.Api.Data.JsonResource<T>')[T](BTD_Mod_Helper.Api.Data.JsonResource_T_.md#BTD_Mod_Helper.Api.Data.JsonResource_T_.T 'BTD_Mod_Helper.Api.Data.JsonResource<T>.T')[&gt;](BTD_Mod_Helper.Api.Data.JsonResource_T_.md 'BTD_Mod_Helper.Api.Data.JsonResource<T>')

#### Returns
[Newtonsoft.Json.Linq.JObject](https://docs.microsoft.com/en-us/dotnet/api/Newtonsoft.Json.Linq.JObject 'Newtonsoft.Json.Linq.JObject')