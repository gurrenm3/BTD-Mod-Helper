#### [BloonsTD6 Mod Helper](README.md 'README')
### [BTD_Mod_Helper.Api.Data](README.md#BTD_Mod_Helper.Api.Data 'BTD_Mod_Helper.Api.Data')

## AudioClipResource<T> Class

An embedded audio clip resource belonging to mod [T](BTD_Mod_Helper.Api.Data.AudioClipResource_T_.md#BTD_Mod_Helper.Api.Data.AudioClipResource_T_.T 'BTD_Mod_Helper.Api.Data.AudioClipResource<T>.T').

```csharp
public class AudioClipResource<T> : BTD_Mod_Helper.Api.Data.Resource
    where T : BTD_Mod_Helper.BloonsMod
```
#### Type parameters

<a name='BTD_Mod_Helper.Api.Data.AudioClipResource_T_.T'></a>

`T`

Inheritance [System.Object](https://docs.microsoft.com/en-us/dotnet/api/System.Object 'System.Object') &#129106; [Resource](BTD_Mod_Helper.Api.Data.Resource.md 'BTD_Mod_Helper.Api.Data.Resource') &#129106; AudioClipResource<T>

Derived  
&#8627; [RandomizedAudioClipResource&lt;T&gt;](BTD_Mod_Helper.Api.Data.RandomizedAudioClipResource_T_.md 'BTD_Mod_Helper.Api.Data.RandomizedAudioClipResource<T>')
### Constructors

<a name='BTD_Mod_Helper.Api.Data.AudioClipResource_T_.AudioClipResource(string)'></a>

## AudioClipResource(string) Constructor

An embedded audio clip resource belonging to mod [T](BTD_Mod_Helper.Api.Data.AudioClipResource_T_.md#BTD_Mod_Helper.Api.Data.AudioClipResource_T_.T 'BTD_Mod_Helper.Api.Data.AudioClipResource<T>.T').

```csharp
public AudioClipResource(string name);
```
#### Parameters

<a name='BTD_Mod_Helper.Api.Data.AudioClipResource_T_.AudioClipResource(string).name'></a>

`name` [System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')
### Properties

<a name='BTD_Mod_Helper.Api.Data.AudioClipResource_T_.AudioClipReference'></a>

## AudioClipResource<T>.AudioClipReference Property

The [AudioClipReference](BTD_Mod_Helper.Api.Data.AudioClipResource_T_.md#BTD_Mod_Helper.Api.Data.AudioClipResource_T_.AudioClipReference 'BTD_Mod_Helper.Api.Data.AudioClipResource<T>.AudioClipReference') for this resource.

```csharp
public virtual AudioClipReference AudioClipReference { get; }
```

#### Property Value
[Il2CppNinjaKiwi.Common.ResourceUtils.AudioClipReference](https://docs.microsoft.com/en-us/dotnet/api/Il2CppNinjaKiwi.Common.ResourceUtils.AudioClipReference 'Il2CppNinjaKiwi.Common.ResourceUtils.AudioClipReference')

<a name='BTD_Mod_Helper.Api.Data.AudioClipResource_T_.Sound'></a>

## AudioClipResource<T>.Sound Property

A created [Il2CppAssets.Scripts.Models.Audio.SoundModel](https://docs.microsoft.com/en-us/dotnet/api/Il2CppAssets.Scripts.Models.Audio.SoundModel 'Il2CppAssets.Scripts.Models.Audio.SoundModel') for this audio clip

```csharp
public virtual SoundModel Sound { get; }
```

#### Property Value
[Il2CppAssets.Scripts.Models.Audio.SoundModel](https://docs.microsoft.com/en-us/dotnet/api/Il2CppAssets.Scripts.Models.Audio.SoundModel 'Il2CppAssets.Scripts.Models.Audio.SoundModel')
### Operators

<a name='BTD_Mod_Helper.Api.Data.AudioClipResource_T_.op_ImplicitAudioClipReference(BTD_Mod_Helper.Api.Data.AudioClipResource_T_)'></a>

## AudioClipResource<T>.implicit operator AudioClipReference(AudioClipResource<T>) Operator

Implicit conversion to [AudioClipReference](BTD_Mod_Helper.Api.Data.AudioClipResource_T_.md#BTD_Mod_Helper.Api.Data.AudioClipResource_T_.AudioClipReference 'BTD_Mod_Helper.Api.Data.AudioClipResource<T>.AudioClipReference').

```csharp
public static AudioClipReference implicit operator AudioClipReference(BTD_Mod_Helper.Api.Data.AudioClipResource<T> resource);
```
#### Parameters

<a name='BTD_Mod_Helper.Api.Data.AudioClipResource_T_.op_ImplicitAudioClipReference(BTD_Mod_Helper.Api.Data.AudioClipResource_T_).resource'></a>

`resource` [BTD_Mod_Helper.Api.Data.AudioClipResource&lt;](BTD_Mod_Helper.Api.Data.AudioClipResource_T_.md 'BTD_Mod_Helper.Api.Data.AudioClipResource<T>')[T](BTD_Mod_Helper.Api.Data.AudioClipResource_T_.md#BTD_Mod_Helper.Api.Data.AudioClipResource_T_.T 'BTD_Mod_Helper.Api.Data.AudioClipResource<T>.T')[&gt;](BTD_Mod_Helper.Api.Data.AudioClipResource_T_.md 'BTD_Mod_Helper.Api.Data.AudioClipResource<T>')

#### Returns
[Il2CppNinjaKiwi.Common.ResourceUtils.AudioClipReference](https://docs.microsoft.com/en-us/dotnet/api/Il2CppNinjaKiwi.Common.ResourceUtils.AudioClipReference 'Il2CppNinjaKiwi.Common.ResourceUtils.AudioClipReference')

<a name='BTD_Mod_Helper.Api.Data.AudioClipResource_T_.op_ImplicitSoundModel(BTD_Mod_Helper.Api.Data.AudioClipResource_T_)'></a>

## AudioClipResource<T>.implicit operator SoundModel(AudioClipResource<T>) Operator

Implicit conversion to [Il2CppAssets.Scripts.Models.Audio.SoundModel](https://docs.microsoft.com/en-us/dotnet/api/Il2CppAssets.Scripts.Models.Audio.SoundModel 'Il2CppAssets.Scripts.Models.Audio.SoundModel').

```csharp
public static SoundModel implicit operator SoundModel(BTD_Mod_Helper.Api.Data.AudioClipResource<T> resource);
```
#### Parameters

<a name='BTD_Mod_Helper.Api.Data.AudioClipResource_T_.op_ImplicitSoundModel(BTD_Mod_Helper.Api.Data.AudioClipResource_T_).resource'></a>

`resource` [BTD_Mod_Helper.Api.Data.AudioClipResource&lt;](BTD_Mod_Helper.Api.Data.AudioClipResource_T_.md 'BTD_Mod_Helper.Api.Data.AudioClipResource<T>')[T](BTD_Mod_Helper.Api.Data.AudioClipResource_T_.md#BTD_Mod_Helper.Api.Data.AudioClipResource_T_.T 'BTD_Mod_Helper.Api.Data.AudioClipResource<T>.T')[&gt;](BTD_Mod_Helper.Api.Data.AudioClipResource_T_.md 'BTD_Mod_Helper.Api.Data.AudioClipResource<T>')

#### Returns
[Il2CppAssets.Scripts.Models.Audio.SoundModel](https://docs.microsoft.com/en-us/dotnet/api/Il2CppAssets.Scripts.Models.Audio.SoundModel 'Il2CppAssets.Scripts.Models.Audio.SoundModel')

<a name='BTD_Mod_Helper.Api.Data.AudioClipResource_T_.op_Implicitstring(BTD_Mod_Helper.Api.Data.AudioClipResource_T_)'></a>

## AudioClipResource<T>.implicit operator string(AudioClipResource<T>) Operator

Implicit conversion to the resource's guid.

```csharp
public static string implicit operator string(BTD_Mod_Helper.Api.Data.AudioClipResource<T> resource);
```
#### Parameters

<a name='BTD_Mod_Helper.Api.Data.AudioClipResource_T_.op_Implicitstring(BTD_Mod_Helper.Api.Data.AudioClipResource_T_).resource'></a>

`resource` [BTD_Mod_Helper.Api.Data.AudioClipResource&lt;](BTD_Mod_Helper.Api.Data.AudioClipResource_T_.md 'BTD_Mod_Helper.Api.Data.AudioClipResource<T>')[T](BTD_Mod_Helper.Api.Data.AudioClipResource_T_.md#BTD_Mod_Helper.Api.Data.AudioClipResource_T_.T 'BTD_Mod_Helper.Api.Data.AudioClipResource<T>.T')[&gt;](BTD_Mod_Helper.Api.Data.AudioClipResource_T_.md 'BTD_Mod_Helper.Api.Data.AudioClipResource<T>')

#### Returns
[System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')