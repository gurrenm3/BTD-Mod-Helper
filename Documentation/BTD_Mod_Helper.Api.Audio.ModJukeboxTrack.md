#### [BloonsTD6 Mod Helper](README.md 'README')
### [BTD_Mod_Helper.Api.Audio](README.md#BTD_Mod_Helper.Api.Audio 'BTD_Mod_Helper.Api.Audio')

## ModJukeboxTrack Class

Class that lets you add custom Jukebox Tracks from embedded audio

```csharp
public abstract class ModJukeboxTrack : BTD_Mod_Helper.Api.NamedModContent
```

Inheritance [System.Object](https://docs.microsoft.com/en-us/dotnet/api/System.Object 'System.Object') &#129106; [ModContent](BTD_Mod_Helper.Api.ModContent.md 'BTD_Mod_Helper.Api.ModContent') &#129106; [NamedModContent](BTD_Mod_Helper.Api.NamedModContent.md 'BTD_Mod_Helper.Api.NamedModContent') &#129106; ModJukeboxTrack
### Properties

<a name='BTD_Mod_Helper.Api.Audio.ModJukeboxTrack.AssetBundleName'></a>

## ModJukeboxTrack.AssetBundleName Property

If set, will load from an embedded AssetBundle with this name rather than directly from an embedded resource

```csharp
public virtual string AssetBundleName { get; }
```

#### Property Value
[System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')

<a name='BTD_Mod_Helper.Api.Audio.ModJukeboxTrack.AudioClip'></a>

## ModJukeboxTrack.AudioClip Property

The final AudioClip used for this track

```csharp
public virtual AudioClip AudioClip { get; }
```

#### Property Value
[UnityEngine.AudioClip](https://docs.microsoft.com/en-us/dotnet/api/UnityEngine.AudioClip 'UnityEngine.AudioClip')

<a name='BTD_Mod_Helper.Api.Audio.ModJukeboxTrack.AudioClipName'></a>

## ModJukeboxTrack.AudioClipName Property

Name of the AudioClip to use for this track.  
<br/>  
If loading directly from an embedded resource in your project, simply include the name of the audio file without the extension  
<br/>  
If your loading the AudioClip from [AssetBundleName](BTD_Mod_Helper.Api.Audio.ModJukeboxTrack.md#BTD_Mod_Helper.Api.Audio.ModJukeboxTrack.AssetBundleName 'BTD_Mod_Helper.Api.Audio.ModJukeboxTrack.AssetBundleName'), this should be exact name of the asset within the bundle

```csharp
public virtual string AudioClipName { get; }
```

#### Property Value
[System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')

<a name='BTD_Mod_Helper.Api.Audio.ModJukeboxTrack.Description'></a>

## ModJukeboxTrack.Description Property

The in game description of this

```csharp
public sealed override string Description { get; }
```

#### Property Value
[System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')

<a name='BTD_Mod_Helper.Api.Audio.ModJukeboxTrack.DisplayNamePlural'></a>

## ModJukeboxTrack.DisplayNamePlural Property

The name that will actually be display when referring to multiple of these

```csharp
public sealed override string DisplayNamePlural { get; }
```

#### Property Value
[System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')

<a name='BTD_Mod_Helper.Api.Audio.ModJukeboxTrack.MusicItem'></a>

## ModJukeboxTrack.MusicItem Property

The BTD6 MusicItem that gets created for this track

```csharp
public MusicItem MusicItem { get; set; }
```

#### Property Value
[Il2CppAssets.Scripts.Data.Audio.MusicItem](https://docs.microsoft.com/en-us/dotnet/api/Il2CppAssets.Scripts.Data.Audio.MusicItem 'Il2CppAssets.Scripts.Data.Audio.MusicItem')
### Methods

<a name='BTD_Mod_Helper.Api.Audio.ModJukeboxTrack.CreateMusicItem()'></a>

## ModJukeboxTrack.CreateMusicItem() Method

Creates the MusicItem for this track

```csharp
public virtual MusicItem CreateMusicItem();
```

#### Returns
[Il2CppAssets.Scripts.Data.Audio.MusicItem](https://docs.microsoft.com/en-us/dotnet/api/Il2CppAssets.Scripts.Data.Audio.MusicItem 'Il2CppAssets.Scripts.Data.Audio.MusicItem')  
the MusicItem