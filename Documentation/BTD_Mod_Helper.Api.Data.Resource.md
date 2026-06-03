#### [BloonsTD6 Mod Helper](README.md 'README')
### [BTD_Mod_Helper.Api.Data](README.md#BTD_Mod_Helper.Api.Data 'BTD_Mod_Helper.Api.Data')

## Resource Class

Base class for an embedded resource referenced by name.

```csharp
public abstract class Resource
```

Inheritance [System.Object](https://docs.microsoft.com/en-us/dotnet/api/System.Object 'System.Object') &#129106; Resource

Derived  
&#8627; [AudioClipResource&lt;T&gt;](BTD_Mod_Helper.Api.Data.AudioClipResource_T_.md 'BTD_Mod_Helper.Api.Data.AudioClipResource<T>')  
&#8627; [BundleResource&lt;T&gt;](BTD_Mod_Helper.Api.Data.BundleResource_T_.md 'BTD_Mod_Helper.Api.Data.BundleResource<T>')  
&#8627; [JsonResource&lt;T&gt;](BTD_Mod_Helper.Api.Data.JsonResource_T_.md 'BTD_Mod_Helper.Api.Data.JsonResource<T>')  
&#8627; [SpriteResource&lt;T&gt;](BTD_Mod_Helper.Api.Data.SpriteResource_T_.md 'BTD_Mod_Helper.Api.Data.SpriteResource<T>')
### Constructors

<a name='BTD_Mod_Helper.Api.Data.Resource.Resource(string)'></a>

## Resource(string) Constructor

Base class for an embedded resource referenced by name.

```csharp
protected Resource(string name);
```
#### Parameters

<a name='BTD_Mod_Helper.Api.Data.Resource.Resource(string).name'></a>

`name` [System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')
### Properties

<a name='BTD_Mod_Helper.Api.Data.Resource.Name'></a>

## Resource.Name Property

The resource's file name without extension.

```csharp
public string Name { get; }
```

#### Property Value
[System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')