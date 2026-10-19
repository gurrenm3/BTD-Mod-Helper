#### [BloonsTD6 Mod Helper](README.md 'README')
### [BTD_Mod_Helper.Api.Audio](README.md#BTD_Mod_Helper.Api.Audio 'BTD_Mod_Helper.Api.Audio')

## AudioSamples Class

Decoded audio data that can be turned into an AudioClip

```csharp
public class AudioSamples :
System.IEquatable<BTD_Mod_Helper.Api.Audio.AudioSamples>
```

Inheritance [System.Object](https://docs.microsoft.com/en-us/dotnet/api/System.Object 'System.Object') &#129106; AudioSamples

Implements [System.IEquatable&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.IEquatable-1 'System.IEquatable`1')[AudioSamples](BTD_Mod_Helper.Api.Audio.AudioSamples.md 'BTD_Mod_Helper.Api.Audio.AudioSamples')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.IEquatable-1 'System.IEquatable`1')
### Constructors

<a name='BTD_Mod_Helper.Api.Audio.AudioSamples.AudioSamples(float[],int,int)'></a>

## AudioSamples(float[], int, int) Constructor

Decoded audio data that can be turned into an AudioClip

```csharp
public AudioSamples(float[] Data, int Channels, int SampleRate);
```
#### Parameters

<a name='BTD_Mod_Helper.Api.Audio.AudioSamples.AudioSamples(float[],int,int).Data'></a>

`Data` [System.Single](https://docs.microsoft.com/en-us/dotnet/api/System.Single 'System.Single')[[]](https://docs.microsoft.com/en-us/dotnet/api/System.Array 'System.Array')

Interleaved samples for all channels

<a name='BTD_Mod_Helper.Api.Audio.AudioSamples.AudioSamples(float[],int,int).Channels'></a>

`Channels` [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/System.Int32 'System.Int32')

Number of channels

<a name='BTD_Mod_Helper.Api.Audio.AudioSamples.AudioSamples(float[],int,int).SampleRate'></a>

`SampleRate` [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/System.Int32 'System.Int32')

Samples per second for each channel
### Properties

<a name='BTD_Mod_Helper.Api.Audio.AudioSamples.Channels'></a>

## AudioSamples.Channels Property

Number of channels

```csharp
public int Channels { get; set; }
```

#### Property Value
[System.Int32](https://docs.microsoft.com/en-us/dotnet/api/System.Int32 'System.Int32')

<a name='BTD_Mod_Helper.Api.Audio.AudioSamples.Data'></a>

## AudioSamples.Data Property

Interleaved samples for all channels

```csharp
public float[] Data { get; set; }
```

#### Property Value
[System.Single](https://docs.microsoft.com/en-us/dotnet/api/System.Single 'System.Single')[[]](https://docs.microsoft.com/en-us/dotnet/api/System.Array 'System.Array')

<a name='BTD_Mod_Helper.Api.Audio.AudioSamples.Length'></a>

## AudioSamples.Length Property

Length of the audio in seconds

```csharp
public double Length { get; }
```

#### Property Value
[System.Double](https://docs.microsoft.com/en-us/dotnet/api/System.Double 'System.Double')

<a name='BTD_Mod_Helper.Api.Audio.AudioSamples.SampleRate'></a>

## AudioSamples.SampleRate Property

Samples per second for each channel

```csharp
public int SampleRate { get; set; }
```

#### Property Value
[System.Int32](https://docs.microsoft.com/en-us/dotnet/api/System.Int32 'System.Int32')