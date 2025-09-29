#### [BloonsTD6 Mod Helper](README.md 'README')
### [BTD_Mod_Helper.Api.Internal](README.md#BTD_Mod_Helper.Api.Internal 'BTD_Mod_Helper.Api.Internal')

## ResourceHandler Class

Handles embedded resources within Mod Helper mods

```csharp
public static class ResourceHandler
```

Inheritance [System.Object](https://docs.microsoft.com/en-us/dotnet/api/System.Object 'System.Object') &#129106; ResourceHandler
### Fields

<a name='BTD_Mod_Helper.Api.Internal.ResourceHandler.AudioClips'></a>

## ResourceHandler.AudioClips Field

Map of created Audio Clips by Id

```csharp
public static readonly Dictionary<string,AudioClip> AudioClips;
```

#### Field Value
[System.Collections.Generic.Dictionary&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.Dictionary-2 'System.Collections.Generic.Dictionary`2')[System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')[,](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.Dictionary-2 'System.Collections.Generic.Dictionary`2')[UnityEngine.AudioClip](https://docs.microsoft.com/en-us/dotnet/api/UnityEngine.AudioClip 'UnityEngine.AudioClip')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.Dictionary-2 'System.Collections.Generic.Dictionary`2')

<a name='BTD_Mod_Helper.Api.Internal.ResourceHandler.Bundles'></a>

## ResourceHandler.Bundles Field

Map of loaded Asset Bundles by Id

```csharp
public static readonly Dictionary<string,AssetBundle> Bundles;
```

#### Field Value
[System.Collections.Generic.Dictionary&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.Dictionary-2 'System.Collections.Generic.Dictionary`2')[System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')[,](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.Dictionary-2 'System.Collections.Generic.Dictionary`2')[UnityEngine.AssetBundle](https://docs.microsoft.com/en-us/dotnet/api/UnityEngine.AssetBundle 'UnityEngine.AssetBundle')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.Dictionary-2 'System.Collections.Generic.Dictionary`2')

<a name='BTD_Mod_Helper.Api.Internal.ResourceHandler.Resources'></a>

## ResourceHandler.Resources Field

Map of raw embedded resource data by Id

```csharp
public static readonly Dictionary<string,byte[]> Resources;
```

#### Field Value
[System.Collections.Generic.Dictionary&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.Dictionary-2 'System.Collections.Generic.Dictionary`2')[System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')[,](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.Dictionary-2 'System.Collections.Generic.Dictionary`2')[System.Byte](https://docs.microsoft.com/en-us/dotnet/api/System.Byte 'System.Byte')[[]](https://docs.microsoft.com/en-us/dotnet/api/System.Array 'System.Array')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.Dictionary-2 'System.Collections.Generic.Dictionary`2')

<a name='BTD_Mod_Helper.Api.Internal.ResourceHandler.SpriteCache'></a>

## ResourceHandler.SpriteCache Field

Cache of created Sprites by Id

```csharp
public static readonly Dictionary<string,Sprite> SpriteCache;
```

#### Field Value
[System.Collections.Generic.Dictionary&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.Dictionary-2 'System.Collections.Generic.Dictionary`2')[System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')[,](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.Dictionary-2 'System.Collections.Generic.Dictionary`2')[UnityEngine.Sprite](https://docs.microsoft.com/en-us/dotnet/api/UnityEngine.Sprite 'UnityEngine.Sprite')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.Dictionary-2 'System.Collections.Generic.Dictionary`2')

<a name='BTD_Mod_Helper.Api.Internal.ResourceHandler.TextureCache'></a>

## ResourceHandler.TextureCache Field

Cache of created Textures by Id

```csharp
public static readonly Dictionary<string,Texture2D> TextureCache;
```

#### Field Value
[System.Collections.Generic.Dictionary&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.Dictionary-2 'System.Collections.Generic.Dictionary`2')[System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')[,](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.Dictionary-2 'System.Collections.Generic.Dictionary`2')[UnityEngine.Texture2D](https://docs.microsoft.com/en-us/dotnet/api/UnityEngine.Texture2D 'UnityEngine.Texture2D')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.Dictionary-2 'System.Collections.Generic.Dictionary`2')
### Methods

<a name='BTD_Mod_Helper.Api.Internal.ResourceHandler.AddTexture(string,Texture2D)'></a>

## ResourceHandler.AddTexture(string, Texture2D) Method

Adds a texture that can be accessed as a Sprite via the given guid

```csharp
public static void AddTexture(string guid, Texture2D texture);
```
#### Parameters

<a name='BTD_Mod_Helper.Api.Internal.ResourceHandler.AddTexture(string,Texture2D).guid'></a>

`guid` [System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')

Texture id "ModName-TextureName"

<a name='BTD_Mod_Helper.Api.Internal.ResourceHandler.AddTexture(string,Texture2D).texture'></a>

`texture` [UnityEngine.Texture2D](https://docs.microsoft.com/en-us/dotnet/api/UnityEngine.Texture2D 'UnityEngine.Texture2D')

The texture

<a name='BTD_Mod_Helper.Api.Internal.ResourceHandler.CreateAudioClip(NAudio.Wave.Mp3FileReader,string)'></a>

## ResourceHandler.CreateAudioClip(Mp3FileReader, string) Method

Create an AudioClip from an mp3 file

```csharp
public static AudioClip CreateAudioClip(NAudio.Wave.Mp3FileReader reader, string id);
```
#### Parameters

<a name='BTD_Mod_Helper.Api.Internal.ResourceHandler.CreateAudioClip(NAudio.Wave.Mp3FileReader,string).reader'></a>

`reader` [NAudio.Wave.Mp3FileReader](https://docs.microsoft.com/en-us/dotnet/api/NAudio.Wave.Mp3FileReader 'NAudio.Wave.Mp3FileReader')

mp3 file reader

<a name='BTD_Mod_Helper.Api.Internal.ResourceHandler.CreateAudioClip(NAudio.Wave.Mp3FileReader,string).id'></a>

`id` [System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')

Id for AudioClip

#### Returns
[UnityEngine.AudioClip](https://docs.microsoft.com/en-us/dotnet/api/UnityEngine.AudioClip 'UnityEngine.AudioClip')  
new AudioClip, or null if unsuccessful

<a name='BTD_Mod_Helper.Api.Internal.ResourceHandler.CreateAudioClip(NAudio.Wave.WaveFileReader,string)'></a>

## ResourceHandler.CreateAudioClip(WaveFileReader, string) Method

Create an AudioClip from a wav file

```csharp
public static AudioClip CreateAudioClip(NAudio.Wave.WaveFileReader reader, string id);
```
#### Parameters

<a name='BTD_Mod_Helper.Api.Internal.ResourceHandler.CreateAudioClip(NAudio.Wave.WaveFileReader,string).reader'></a>

`reader` [NAudio.Wave.WaveFileReader](https://docs.microsoft.com/en-us/dotnet/api/NAudio.Wave.WaveFileReader 'NAudio.Wave.WaveFileReader')

Wav file reader

<a name='BTD_Mod_Helper.Api.Internal.ResourceHandler.CreateAudioClip(NAudio.Wave.WaveFileReader,string).id'></a>

`id` [System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')

Id for AudioClip

#### Returns
[UnityEngine.AudioClip](https://docs.microsoft.com/en-us/dotnet/api/UnityEngine.AudioClip 'UnityEngine.AudioClip')  
new AudioClip, or null if unsuccessful

<a name='BTD_Mod_Helper.Api.Internal.ResourceHandler.CreateSprite(thisTexture2D,float)'></a>

## ResourceHandler.CreateSprite(this Texture2D, float) Method

Creates a Sprite from a Texture2D

```csharp
public static Sprite CreateSprite(this Texture2D texture, float pixelsPerUnit=10.8f);
```
#### Parameters

<a name='BTD_Mod_Helper.Api.Internal.ResourceHandler.CreateSprite(thisTexture2D,float).texture'></a>

`texture` [UnityEngine.Texture2D](https://docs.microsoft.com/en-us/dotnet/api/UnityEngine.Texture2D 'UnityEngine.Texture2D')

Texture

<a name='BTD_Mod_Helper.Api.Internal.ResourceHandler.CreateSprite(thisTexture2D,float).pixelsPerUnit'></a>

`pixelsPerUnit` [System.Single](https://docs.microsoft.com/en-us/dotnet/api/System.Single 'System.Single')

Pixels per Unit to use

#### Returns
[UnityEngine.Sprite](https://docs.microsoft.com/en-us/dotnet/api/UnityEngine.Sprite 'UnityEngine.Sprite')  
new Sprite

<a name='BTD_Mod_Helper.Api.Internal.ResourceHandler.GetSprite(string,float)'></a>

## ResourceHandler.GetSprite(string, float) Method

Creates or gets a sprite from its Id

```csharp
public static Sprite GetSprite(string id, float pixelsPerUnit=10.8f);
```
#### Parameters

<a name='BTD_Mod_Helper.Api.Internal.ResourceHandler.GetSprite(string,float).id'></a>

`id` [System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')

Sprite id "ModName-FileName" (no file extension)

<a name='BTD_Mod_Helper.Api.Internal.ResourceHandler.GetSprite(string,float).pixelsPerUnit'></a>

`pixelsPerUnit` [System.Single](https://docs.microsoft.com/en-us/dotnet/api/System.Single 'System.Single')

Pixels per Unit to use

#### Returns
[UnityEngine.Sprite](https://docs.microsoft.com/en-us/dotnet/api/UnityEngine.Sprite 'UnityEngine.Sprite')  
The texture

<a name='BTD_Mod_Helper.Api.Internal.ResourceHandler.GetTexture(string)'></a>

## ResourceHandler.GetTexture(string) Method

Creates or gets a texture from its Id

```csharp
public static Texture2D GetTexture(string id);
```
#### Parameters

<a name='BTD_Mod_Helper.Api.Internal.ResourceHandler.GetTexture(string).id'></a>

`id` [System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')

Texture id "ModName-FileName" (no file extension)

#### Returns
[UnityEngine.Texture2D](https://docs.microsoft.com/en-us/dotnet/api/UnityEngine.Texture2D 'UnityEngine.Texture2D')  
The texture