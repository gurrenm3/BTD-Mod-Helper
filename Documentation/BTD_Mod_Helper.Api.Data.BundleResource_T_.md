#### [BloonsTD6 Mod Helper](README.md 'README')
### [BTD_Mod_Helper.Api.Data](README.md#BTD_Mod_Helper.Api.Data 'BTD_Mod_Helper.Api.Data')

## BundleResource<T> Class

An embedded asset bundle resource belonging to mod [T](BTD_Mod_Helper.Api.Data.BundleResource_T_.md#BTD_Mod_Helper.Api.Data.BundleResource_T_.T 'BTD_Mod_Helper.Api.Data.BundleResource<T>.T').

```csharp
public class BundleResource<T> : BTD_Mod_Helper.Api.Data.Resource
    where T : BTD_Mod_Helper.BloonsMod
```
#### Type parameters

<a name='BTD_Mod_Helper.Api.Data.BundleResource_T_.T'></a>

`T`

Inheritance [System.Object](https://docs.microsoft.com/en-us/dotnet/api/System.Object 'System.Object') &#129106; [Resource](BTD_Mod_Helper.Api.Data.Resource.md 'BTD_Mod_Helper.Api.Data.Resource') &#129106; BundleResource<T>
### Constructors

<a name='BTD_Mod_Helper.Api.Data.BundleResource_T_.BundleResource(string)'></a>

## BundleResource(string) Constructor

An embedded asset bundle resource belonging to mod [T](BTD_Mod_Helper.Api.Data.BundleResource_T_.md#BTD_Mod_Helper.Api.Data.BundleResource_T_.T 'BTD_Mod_Helper.Api.Data.BundleResource<T>.T').

```csharp
public BundleResource(string name);
```
#### Parameters

<a name='BTD_Mod_Helper.Api.Data.BundleResource_T_.BundleResource(string).name'></a>

`name` [System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')
### Properties

<a name='BTD_Mod_Helper.Api.Data.BundleResource_T_.Bundle'></a>

## BundleResource<T>.Bundle Property

The loaded [UnityEngine.AssetBundle](https://docs.microsoft.com/en-us/dotnet/api/UnityEngine.AssetBundle 'UnityEngine.AssetBundle') for this resource.

```csharp
public virtual AssetBundle Bundle { get; }
```

#### Property Value
[UnityEngine.AssetBundle](https://docs.microsoft.com/en-us/dotnet/api/UnityEngine.AssetBundle 'UnityEngine.AssetBundle')
### Operators

<a name='BTD_Mod_Helper.Api.Data.BundleResource_T_.op_ImplicitAssetBundle(BTD_Mod_Helper.Api.Data.BundleResource_T_)'></a>

## BundleResource<T>.implicit operator AssetBundle(BundleResource<T>) Operator

Implicit conversion to [UnityEngine.AssetBundle](https://docs.microsoft.com/en-us/dotnet/api/UnityEngine.AssetBundle 'UnityEngine.AssetBundle').

```csharp
public static AssetBundle implicit operator AssetBundle(BTD_Mod_Helper.Api.Data.BundleResource<T> resource);
```
#### Parameters

<a name='BTD_Mod_Helper.Api.Data.BundleResource_T_.op_ImplicitAssetBundle(BTD_Mod_Helper.Api.Data.BundleResource_T_).resource'></a>

`resource` [BTD_Mod_Helper.Api.Data.BundleResource&lt;](BTD_Mod_Helper.Api.Data.BundleResource_T_.md 'BTD_Mod_Helper.Api.Data.BundleResource<T>')[T](BTD_Mod_Helper.Api.Data.BundleResource_T_.md#BTD_Mod_Helper.Api.Data.BundleResource_T_.T 'BTD_Mod_Helper.Api.Data.BundleResource<T>.T')[&gt;](BTD_Mod_Helper.Api.Data.BundleResource_T_.md 'BTD_Mod_Helper.Api.Data.BundleResource<T>')

#### Returns
[UnityEngine.AssetBundle](https://docs.microsoft.com/en-us/dotnet/api/UnityEngine.AssetBundle 'UnityEngine.AssetBundle')