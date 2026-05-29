#### [BloonsTD6 Mod Helper](README.md 'README')
### [BTD_Mod_Helper.Api.Data](README.md#BTD_Mod_Helper.Api.Data 'BTD_Mod_Helper.Api.Data')

## SpriteResource<T> Class

An embedded sprite resource belonging to mod [T](BTD_Mod_Helper.Api.Data.SpriteResource_T_.md#BTD_Mod_Helper.Api.Data.SpriteResource_T_.T 'BTD_Mod_Helper.Api.Data.SpriteResource<T>.T').

```csharp
public class SpriteResource<T> : BTD_Mod_Helper.Api.Data.Resource
    where T : BTD_Mod_Helper.BloonsMod
```
#### Type parameters

<a name='BTD_Mod_Helper.Api.Data.SpriteResource_T_.T'></a>

`T`

Inheritance [System.Object](https://docs.microsoft.com/en-us/dotnet/api/System.Object 'System.Object') &#129106; [Resource](BTD_Mod_Helper.Api.Data.Resource.md 'BTD_Mod_Helper.Api.Data.Resource') &#129106; SpriteResource<T>
### Constructors

<a name='BTD_Mod_Helper.Api.Data.SpriteResource_T_.SpriteResource(string)'></a>

## SpriteResource(string) Constructor

An embedded sprite resource belonging to mod [T](BTD_Mod_Helper.Api.Data.SpriteResource_T_.md#BTD_Mod_Helper.Api.Data.SpriteResource_T_.T 'BTD_Mod_Helper.Api.Data.SpriteResource<T>.T').

```csharp
public SpriteResource(string name);
```
#### Parameters

<a name='BTD_Mod_Helper.Api.Data.SpriteResource_T_.SpriteResource(string).name'></a>

`name` [System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')
### Properties

<a name='BTD_Mod_Helper.Api.Data.SpriteResource_T_.Sprite'></a>

## SpriteResource<T>.Sprite Property

The loaded [UnityEngine.Sprite](https://docs.microsoft.com/en-us/dotnet/api/UnityEngine.Sprite 'UnityEngine.Sprite') for this resource.

```csharp
public virtual Sprite Sprite { get; }
```

#### Property Value
[UnityEngine.Sprite](https://docs.microsoft.com/en-us/dotnet/api/UnityEngine.Sprite 'UnityEngine.Sprite')

<a name='BTD_Mod_Helper.Api.Data.SpriteResource_T_.SpriteReference'></a>

## SpriteResource<T>.SpriteReference Property

The [SpriteReference](BTD_Mod_Helper.Api.Data.SpriteResource_T_.md#BTD_Mod_Helper.Api.Data.SpriteResource_T_.SpriteReference 'BTD_Mod_Helper.Api.Data.SpriteResource<T>.SpriteReference') for this resource.

```csharp
public virtual SpriteReference SpriteReference { get; }
```

#### Property Value
[Il2CppNinjaKiwi.Common.ResourceUtils.SpriteReference](https://docs.microsoft.com/en-us/dotnet/api/Il2CppNinjaKiwi.Common.ResourceUtils.SpriteReference 'Il2CppNinjaKiwi.Common.ResourceUtils.SpriteReference')
### Operators

<a name='BTD_Mod_Helper.Api.Data.SpriteResource_T_.op_ImplicitSprite(BTD_Mod_Helper.Api.Data.SpriteResource_T_)'></a>

## SpriteResource<T>.implicit operator Sprite(SpriteResource<T>) Operator

Implicit conversion to [UnityEngine.Sprite](https://docs.microsoft.com/en-us/dotnet/api/UnityEngine.Sprite 'UnityEngine.Sprite').

```csharp
public static Sprite implicit operator Sprite(BTD_Mod_Helper.Api.Data.SpriteResource<T> resource);
```
#### Parameters

<a name='BTD_Mod_Helper.Api.Data.SpriteResource_T_.op_ImplicitSprite(BTD_Mod_Helper.Api.Data.SpriteResource_T_).resource'></a>

`resource` [BTD_Mod_Helper.Api.Data.SpriteResource&lt;](BTD_Mod_Helper.Api.Data.SpriteResource_T_.md 'BTD_Mod_Helper.Api.Data.SpriteResource<T>')[T](BTD_Mod_Helper.Api.Data.SpriteResource_T_.md#BTD_Mod_Helper.Api.Data.SpriteResource_T_.T 'BTD_Mod_Helper.Api.Data.SpriteResource<T>.T')[&gt;](BTD_Mod_Helper.Api.Data.SpriteResource_T_.md 'BTD_Mod_Helper.Api.Data.SpriteResource<T>')

#### Returns
[UnityEngine.Sprite](https://docs.microsoft.com/en-us/dotnet/api/UnityEngine.Sprite 'UnityEngine.Sprite')

<a name='BTD_Mod_Helper.Api.Data.SpriteResource_T_.op_ImplicitSpriteReference(BTD_Mod_Helper.Api.Data.SpriteResource_T_)'></a>

## SpriteResource<T>.implicit operator SpriteReference(SpriteResource<T>) Operator

Implicit conversion to [SpriteReference](BTD_Mod_Helper.Api.Data.SpriteResource_T_.md#BTD_Mod_Helper.Api.Data.SpriteResource_T_.SpriteReference 'BTD_Mod_Helper.Api.Data.SpriteResource<T>.SpriteReference').

```csharp
public static SpriteReference implicit operator SpriteReference(BTD_Mod_Helper.Api.Data.SpriteResource<T> resource);
```
#### Parameters

<a name='BTD_Mod_Helper.Api.Data.SpriteResource_T_.op_ImplicitSpriteReference(BTD_Mod_Helper.Api.Data.SpriteResource_T_).resource'></a>

`resource` [BTD_Mod_Helper.Api.Data.SpriteResource&lt;](BTD_Mod_Helper.Api.Data.SpriteResource_T_.md 'BTD_Mod_Helper.Api.Data.SpriteResource<T>')[T](BTD_Mod_Helper.Api.Data.SpriteResource_T_.md#BTD_Mod_Helper.Api.Data.SpriteResource_T_.T 'BTD_Mod_Helper.Api.Data.SpriteResource<T>.T')[&gt;](BTD_Mod_Helper.Api.Data.SpriteResource_T_.md 'BTD_Mod_Helper.Api.Data.SpriteResource<T>')

#### Returns
[Il2CppNinjaKiwi.Common.ResourceUtils.SpriteReference](https://docs.microsoft.com/en-us/dotnet/api/Il2CppNinjaKiwi.Common.ResourceUtils.SpriteReference 'Il2CppNinjaKiwi.Common.ResourceUtils.SpriteReference')