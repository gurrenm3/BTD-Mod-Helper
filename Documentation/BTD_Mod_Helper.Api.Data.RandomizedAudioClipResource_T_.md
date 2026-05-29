#### [BloonsTD6 Mod Helper](README.md 'README')
### [BTD_Mod_Helper.Api.Data](README.md#BTD_Mod_Helper.Api.Data 'BTD_Mod_Helper.Api.Data')

## RandomizedAudioClipResource<T> Class

Randomized audio clip amongst a number of variants

```csharp
public class RandomizedAudioClipResource<T> : BTD_Mod_Helper.Api.Data.AudioClipResource<T>
    where T : BTD_Mod_Helper.BloonsMod
```
#### Type parameters

<a name='BTD_Mod_Helper.Api.Data.RandomizedAudioClipResource_T_.T'></a>

`T`

Inheritance [System.Object](https://docs.microsoft.com/en-us/dotnet/api/System.Object 'System.Object') &#129106; [Resource](BTD_Mod_Helper.Api.Data.Resource.md 'BTD_Mod_Helper.Api.Data.Resource') &#129106; [BTD_Mod_Helper.Api.Data.AudioClipResource&lt;](BTD_Mod_Helper.Api.Data.AudioClipResource_T_.md 'BTD_Mod_Helper.Api.Data.AudioClipResource<T>')[T](BTD_Mod_Helper.Api.Data.RandomizedAudioClipResource_T_.md#BTD_Mod_Helper.Api.Data.RandomizedAudioClipResource_T_.T 'BTD_Mod_Helper.Api.Data.RandomizedAudioClipResource<T>.T')[&gt;](BTD_Mod_Helper.Api.Data.AudioClipResource_T_.md 'BTD_Mod_Helper.Api.Data.AudioClipResource<T>') &#129106; RandomizedAudioClipResource<T>
### Constructors

<a name='BTD_Mod_Helper.Api.Data.RandomizedAudioClipResource_T_.RandomizedAudioClipResource(string,System.Collections.Generic.IEnumerable_BTD_Mod_Helper.Api.Data.AudioClipResource_T__)'></a>

## RandomizedAudioClipResource(string, IEnumerable<AudioClipResource<T>>) Constructor

Randomized audio clip amongst a number of variants

```csharp
public RandomizedAudioClipResource(string name, System.Collections.Generic.IEnumerable<BTD_Mod_Helper.Api.Data.AudioClipResource<T>> clips);
```
#### Parameters

<a name='BTD_Mod_Helper.Api.Data.RandomizedAudioClipResource_T_.RandomizedAudioClipResource(string,System.Collections.Generic.IEnumerable_BTD_Mod_Helper.Api.Data.AudioClipResource_T__).name'></a>

`name` [System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')

<a name='BTD_Mod_Helper.Api.Data.RandomizedAudioClipResource_T_.RandomizedAudioClipResource(string,System.Collections.Generic.IEnumerable_BTD_Mod_Helper.Api.Data.AudioClipResource_T__).clips'></a>

`clips` [System.Collections.Generic.IEnumerable&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.IEnumerable-1 'System.Collections.Generic.IEnumerable`1')[BTD_Mod_Helper.Api.Data.AudioClipResource&lt;](BTD_Mod_Helper.Api.Data.AudioClipResource_T_.md 'BTD_Mod_Helper.Api.Data.AudioClipResource<T>')[T](BTD_Mod_Helper.Api.Data.RandomizedAudioClipResource_T_.md#BTD_Mod_Helper.Api.Data.RandomizedAudioClipResource_T_.T 'BTD_Mod_Helper.Api.Data.RandomizedAudioClipResource<T>.T')[&gt;](BTD_Mod_Helper.Api.Data.AudioClipResource_T_.md 'BTD_Mod_Helper.Api.Data.AudioClipResource<T>')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.IEnumerable-1 'System.Collections.Generic.IEnumerable`1')
### Properties

<a name='BTD_Mod_Helper.Api.Data.RandomizedAudioClipResource_T_.AudioClipReference'></a>

## RandomizedAudioClipResource<T>.AudioClipReference Property

The [AudioClipReference](BTD_Mod_Helper.Api.Data.AudioClipResource_T_.md#BTD_Mod_Helper.Api.Data.AudioClipResource_T_.AudioClipReference 'BTD_Mod_Helper.Api.Data.AudioClipResource<T>.AudioClipReference') for this resource.

```csharp
public override AudioClipReference AudioClipReference { get; }
```

#### Property Value
[Il2CppNinjaKiwi.Common.ResourceUtils.AudioClipReference](https://docs.microsoft.com/en-us/dotnet/api/Il2CppNinjaKiwi.Common.ResourceUtils.AudioClipReference 'Il2CppNinjaKiwi.Common.ResourceUtils.AudioClipReference')