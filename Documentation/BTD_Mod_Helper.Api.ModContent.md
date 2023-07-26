#### [BloonsTD6 Mod Helper](README.md 'README')
### [BTD_Mod_Helper.Api](README.md#BTD_Mod_Helper.Api 'BTD_Mod_Helper.Api')

## ModContent Class

ModContent serves two major purposes:  
<br/>  
1. It is a base class for things that needs to be loaded via reflection from mods and given Ids,  
    such as ModTower and ModUpgrade  
<br/>  
2. It is a utility class with methods to access instances of those classes and other resources

```csharp
public abstract class ModContent :
BTD_Mod_Helper.Api.IModContent,
System.IComparable<BTD_Mod_Helper.Api.ModContent>
```

Inheritance [System.Object](https://docs.microsoft.com/en-us/dotnet/api/System.Object 'System.Object') &#129106; ModContent

Derived  
&#8627; [ModSettings](BTD_Mod_Helper.Api.Data.ModSettings.md 'BTD_Mod_Helper.Api.Data.ModSettings')  
&#8627; [ModTextOverride](BTD_Mod_Helper.Api.Data.ModTextOverride.md 'BTD_Mod_Helper.Api.Data.ModTextOverride')  
&#8627; [ModDisplay](BTD_Mod_Helper.Api.Display.ModDisplay.md 'BTD_Mod_Helper.Api.Display.ModDisplay')  
&#8627; [ModByteLoader](BTD_Mod_Helper.Api.ModByteLoader.md 'BTD_Mod_Helper.Api.ModByteLoader')  
&#8627; [ModGameMenu](BTD_Mod_Helper.Api.ModGameMenu.md 'BTD_Mod_Helper.Api.ModGameMenu')  
&#8627; [NamedModContent](BTD_Mod_Helper.Api.NamedModContent.md 'BTD_Mod_Helper.Api.NamedModContent')  
&#8627; [ModVanillaContent](BTD_Mod_Helper.Api.Towers.ModVanillaContent.md 'BTD_Mod_Helper.Api.Towers.ModVanillaContent')

Implements [IModContent](BTD_Mod_Helper.Api.IModContent.md 'BTD_Mod_Helper.Api.IModContent'), [System.IComparable&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.IComparable-1 'System.IComparable`1')[ModContent](BTD_Mod_Helper.Api.ModContent.md 'BTD_Mod_Helper.Api.ModContent')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.IComparable-1 'System.IComparable`1')
### Fields

<a name='BTD_Mod_Helper.Api.ModContent.mod'></a>

## ModContent.mod Field

The BloonsTD6Mod that this content was added by

```csharp
public BloonsMod mod;
```

#### Field Value
[BloonsMod](BTD_Mod_Helper.BloonsMod.md 'BTD_Mod_Helper.BloonsMod')
### Properties

<a name='BTD_Mod_Helper.Api.ModContent.Id'></a>

## ModContent.Id Property

The id that this ModContent will be given; a combination of the Mod's prefix and the name

```csharp
public string Id { get; }
```

#### Property Value
[System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')

<a name='BTD_Mod_Helper.Api.ModContent.Name'></a>

## ModContent.Name Property

The name that will be at the end of the ID for this ModContent, by default the class name

```csharp
public virtual string Name { get; }
```

#### Property Value
[System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')

<a name='BTD_Mod_Helper.Api.ModContent.Order'></a>

## ModContent.Order Property

The order that this ModContent will be loaded/registered in by Mod Helper.  
Useful for changing the ordering that it will appear in in-game relative to other content of this type in your mod,  
or for making certain content load before others like may be necessary for sub-towers.  
Default/0 will use arbitrary ordering.

```csharp
protected virtual int Order { get; }
```

#### Property Value
[System.Int32](https://docs.microsoft.com/en-us/dotnet/api/System.Int32 'System.Int32')
### Methods

<a name='BTD_Mod_Helper.Api.ModContent.BloonID_T_()'></a>

## ModContent.BloonID<T>() Method

Gets the ID for the given ModBloon

```csharp
public static string BloonID<T>()
    where T : BTD_Mod_Helper.Api.Bloons.ModBloon;
```
#### Type parameters

<a name='BTD_Mod_Helper.Api.ModContent.BloonID_T_().T'></a>

`T`

#### Returns
[System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')

<a name='BTD_Mod_Helper.Api.ModContent.CreateAudioSourceReference(string)'></a>

## ModContent.CreateAudioSourceReference(string) Method

Returns a new AudioSourceReference that uses the given guid

```csharp
public static AudioSourceReference CreateAudioSourceReference(string guid);
```
#### Parameters

<a name='BTD_Mod_Helper.Api.ModContent.CreateAudioSourceReference(string).guid'></a>

`guid` [System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')

The guid that you'd like to assign to the AudioSourceReference

#### Returns
[Il2CppAssets.Scripts.Utils.AudioSourceReference](https://docs.microsoft.com/en-us/dotnet/api/Il2CppAssets.Scripts.Utils.AudioSourceReference 'Il2CppAssets.Scripts.Utils.AudioSourceReference')

<a name='BTD_Mod_Helper.Api.ModContent.CreateAudioSourceReference_T_(string)'></a>

## ModContent.CreateAudioSourceReference<T>(string) Method

Gets an AudioSource reference for a given sound within a mod

```csharp
public static AudioSourceReference CreateAudioSourceReference<T>(string name)
    where T : BTD_Mod_Helper.BloonsMod;
```
#### Type parameters

<a name='BTD_Mod_Helper.Api.ModContent.CreateAudioSourceReference_T_(string).T'></a>

`T`

The mod
#### Parameters

<a name='BTD_Mod_Helper.Api.ModContent.CreateAudioSourceReference_T_(string).name'></a>

`name` [System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')

Sound name (no .wav)

#### Returns
[Il2CppAssets.Scripts.Utils.AudioSourceReference](https://docs.microsoft.com/en-us/dotnet/api/Il2CppAssets.Scripts.Utils.AudioSourceReference 'Il2CppAssets.Scripts.Utils.AudioSourceReference')  
An AudioSoundReference

<a name='BTD_Mod_Helper.Api.ModContent.CreatePrefabReference(string)'></a>

## ModContent.CreatePrefabReference(string) Method

Returns a new PrefabReference that uses the given guid

```csharp
public static PrefabReference CreatePrefabReference(string guid);
```
#### Parameters

<a name='BTD_Mod_Helper.Api.ModContent.CreatePrefabReference(string).guid'></a>

`guid` [System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')

The guid that you'd like to assign to the PrefabReference

#### Returns
[Il2CppAssets.Scripts.Utils.PrefabReference](https://docs.microsoft.com/en-us/dotnet/api/Il2CppAssets.Scripts.Utils.PrefabReference 'Il2CppAssets.Scripts.Utils.PrefabReference')

<a name='BTD_Mod_Helper.Api.ModContent.CreatePrefabReference_T_()'></a>

## ModContent.CreatePrefabReference<T>() Method

Creates a Prefab Reference for a ModDisplay

```csharp
public static PrefabReference CreatePrefabReference<T>()
    where T : BTD_Mod_Helper.Api.Display.ModDisplay;
```
#### Type parameters

<a name='BTD_Mod_Helper.Api.ModContent.CreatePrefabReference_T_().T'></a>

`T`

#### Returns
[Il2CppAssets.Scripts.Utils.PrefabReference](https://docs.microsoft.com/en-us/dotnet/api/Il2CppAssets.Scripts.Utils.PrefabReference 'Il2CppAssets.Scripts.Utils.PrefabReference')

<a name='BTD_Mod_Helper.Api.ModContent.CreateSpriteReference(string)'></a>

## ModContent.CreateSpriteReference(string) Method

Returns a new SpriteReference that uses the given guid

```csharp
public static SpriteReference CreateSpriteReference(string guid);
```
#### Parameters

<a name='BTD_Mod_Helper.Api.ModContent.CreateSpriteReference(string).guid'></a>

`guid` [System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')

The guid that you'd like to assign to the SpriteReference

#### Returns
[Il2CppAssets.Scripts.Utils.SpriteReference](https://docs.microsoft.com/en-us/dotnet/api/Il2CppAssets.Scripts.Utils.SpriteReference 'Il2CppAssets.Scripts.Utils.SpriteReference')

<a name='BTD_Mod_Helper.Api.ModContent.Find_T_(string)'></a>

## ModContent.Find<T>(string) Method

Finds the loaded ModContent with the given Id and type T

```csharp
public static T Find<T>(string id)
    where T : BTD_Mod_Helper.Api.ModContent;
```
#### Type parameters

<a name='BTD_Mod_Helper.Api.ModContent.Find_T_(string).T'></a>

`T`
#### Parameters

<a name='BTD_Mod_Helper.Api.ModContent.Find_T_(string).id'></a>

`id` [System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')

#### Returns
[T](BTD_Mod_Helper.Api.ModContent.md#BTD_Mod_Helper.Api.ModContent.Find_T_(string).T 'BTD_Mod_Helper.Api.ModContent.Find<T>(string).T')

<a name='BTD_Mod_Helper.Api.ModContent.GameModeId_T_()'></a>

## ModContent.GameModeId<T>() Method

Gets the ID for the given ModGameMode

```csharp
public static string GameModeId<T>()
    where T : BTD_Mod_Helper.Api.Scenarios.ModGameMode;
```
#### Type parameters

<a name='BTD_Mod_Helper.Api.ModContent.GameModeId_T_().T'></a>

`T`

#### Returns
[System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')

<a name='BTD_Mod_Helper.Api.ModContent.GetAudioClip(BTD_Mod_Helper.BloonsMod,string)'></a>

## ModContent.GetAudioClip(BloonsMod, string) Method

Gets an AudioClip from a mod by its name (no file extension included)

```csharp
public static AudioClip GetAudioClip(BTD_Mod_Helper.BloonsMod mod, string name);
```
#### Parameters

<a name='BTD_Mod_Helper.Api.ModContent.GetAudioClip(BTD_Mod_Helper.BloonsMod,string).mod'></a>

`mod` [BloonsMod](BTD_Mod_Helper.BloonsMod.md 'BTD_Mod_Helper.BloonsMod')

The mod

<a name='BTD_Mod_Helper.Api.ModContent.GetAudioClip(BTD_Mod_Helper.BloonsMod,string).name'></a>

`name` [System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')

Sound name (no .wav)

#### Returns
[UnityEngine.AudioClip](https://docs.microsoft.com/en-us/dotnet/api/UnityEngine.AudioClip 'UnityEngine.AudioClip')  
a playable AudioClip

<a name='BTD_Mod_Helper.Api.ModContent.GetAudioClip(string)'></a>

## ModContent.GetAudioClip(string) Method

Gets an AudioClip from this mod by its name (no file extension included)

```csharp
public AudioClip GetAudioClip(string name);
```
#### Parameters

<a name='BTD_Mod_Helper.Api.ModContent.GetAudioClip(string).name'></a>

`name` [System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')

Sound name (no .wav)

#### Returns
[UnityEngine.AudioClip](https://docs.microsoft.com/en-us/dotnet/api/UnityEngine.AudioClip 'UnityEngine.AudioClip')  
a playable AudioClip

<a name='BTD_Mod_Helper.Api.ModContent.GetAudioClip_T_(string)'></a>

## ModContent.GetAudioClip<T>(string) Method

Gets an AudioClip from a mod by its name (no file extension included)

```csharp
public static AudioClip GetAudioClip<T>(string name)
    where T : BTD_Mod_Helper.BloonsMod;
```
#### Type parameters

<a name='BTD_Mod_Helper.Api.ModContent.GetAudioClip_T_(string).T'></a>

`T`

The mod
#### Parameters

<a name='BTD_Mod_Helper.Api.ModContent.GetAudioClip_T_(string).name'></a>

`name` [System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')

Sound name (no .wav)

#### Returns
[UnityEngine.AudioClip](https://docs.microsoft.com/en-us/dotnet/api/UnityEngine.AudioClip 'UnityEngine.AudioClip')  
a playable AudioClip

<a name='BTD_Mod_Helper.Api.ModContent.GetAudioSourceReference(BTD_Mod_Helper.BloonsMod,string)'></a>

## ModContent.GetAudioSourceReference(BloonsMod, string) Method

Gets an AudioSource reference for a given sound within a mod

```csharp
public static AudioSourceReference GetAudioSourceReference(BTD_Mod_Helper.BloonsMod mod, string name);
```
#### Parameters

<a name='BTD_Mod_Helper.Api.ModContent.GetAudioSourceReference(BTD_Mod_Helper.BloonsMod,string).mod'></a>

`mod` [BloonsMod](BTD_Mod_Helper.BloonsMod.md 'BTD_Mod_Helper.BloonsMod')

<a name='BTD_Mod_Helper.Api.ModContent.GetAudioSourceReference(BTD_Mod_Helper.BloonsMod,string).name'></a>

`name` [System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')

Sound name (no .wav)

#### Returns
[Il2CppAssets.Scripts.Utils.AudioSourceReference](https://docs.microsoft.com/en-us/dotnet/api/Il2CppAssets.Scripts.Utils.AudioSourceReference 'Il2CppAssets.Scripts.Utils.AudioSourceReference')  
An AudioSoundReference

<a name='BTD_Mod_Helper.Api.ModContent.GetAudioSourceReference(string)'></a>

## ModContent.GetAudioSourceReference(string) Method

Gets an AudioSource reference for a given sound within this mod

```csharp
public AudioSourceReference GetAudioSourceReference(string name);
```
#### Parameters

<a name='BTD_Mod_Helper.Api.ModContent.GetAudioSourceReference(string).name'></a>

`name` [System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')

Sound name (no .wav)

#### Returns
[Il2CppAssets.Scripts.Utils.AudioSourceReference](https://docs.microsoft.com/en-us/dotnet/api/Il2CppAssets.Scripts.Utils.AudioSourceReference 'Il2CppAssets.Scripts.Utils.AudioSourceReference')  
An AudioSoundReference

<a name='BTD_Mod_Helper.Api.ModContent.GetAudioSourceReference_T_(string)'></a>

## ModContent.GetAudioSourceReference<T>(string) Method

Gets an AudioSource reference for a given sound within a mod

```csharp
public static AudioSourceReference GetAudioSourceReference<T>(string name)
    where T : BTD_Mod_Helper.BloonsMod;
```
#### Type parameters

<a name='BTD_Mod_Helper.Api.ModContent.GetAudioSourceReference_T_(string).T'></a>

`T`

The mod
#### Parameters

<a name='BTD_Mod_Helper.Api.ModContent.GetAudioSourceReference_T_(string).name'></a>

`name` [System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')

Sound name (no .wav)

#### Returns
[Il2CppAssets.Scripts.Utils.AudioSourceReference](https://docs.microsoft.com/en-us/dotnet/api/Il2CppAssets.Scripts.Utils.AudioSourceReference 'Il2CppAssets.Scripts.Utils.AudioSourceReference')  
An AudioSoundReference

<a name='BTD_Mod_Helper.Api.ModContent.GetBundle(BTD_Mod_Helper.BloonsMod,string)'></a>

## ModContent.GetBundle(BloonsMod, string) Method

Gets a bundle from a mod with the specified name (no file extension)

```csharp
public static AssetBundle GetBundle(BTD_Mod_Helper.BloonsMod mod, string name);
```
#### Parameters

<a name='BTD_Mod_Helper.Api.ModContent.GetBundle(BTD_Mod_Helper.BloonsMod,string).mod'></a>

`mod` [BloonsMod](BTD_Mod_Helper.BloonsMod.md 'BTD_Mod_Helper.BloonsMod')

<a name='BTD_Mod_Helper.Api.ModContent.GetBundle(BTD_Mod_Helper.BloonsMod,string).name'></a>

`name` [System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')

#### Returns
[UnityEngine.AssetBundle](https://docs.microsoft.com/en-us/dotnet/api/UnityEngine.AssetBundle 'UnityEngine.AssetBundle')

<a name='BTD_Mod_Helper.Api.ModContent.GetBundle(string)'></a>

## ModContent.GetBundle(string) Method

Gets a bundle from your mod with the specified name (no file extension)

```csharp
protected AssetBundle GetBundle(string name);
```
#### Parameters

<a name='BTD_Mod_Helper.Api.ModContent.GetBundle(string).name'></a>

`name` [System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')

#### Returns
[UnityEngine.AssetBundle](https://docs.microsoft.com/en-us/dotnet/api/UnityEngine.AssetBundle 'UnityEngine.AssetBundle')

<a name='BTD_Mod_Helper.Api.ModContent.GetBundle_T_(string)'></a>

## ModContent.GetBundle<T>(string) Method

Gets a bundle from the mod T with the specified name (no file extension)

```csharp
public static AssetBundle GetBundle<T>(string name)
    where T : BTD_Mod_Helper.BloonsMod;
```
#### Type parameters

<a name='BTD_Mod_Helper.Api.ModContent.GetBundle_T_(string).T'></a>

`T`
#### Parameters

<a name='BTD_Mod_Helper.Api.ModContent.GetBundle_T_(string).name'></a>

`name` [System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')

#### Returns
[UnityEngine.AssetBundle](https://docs.microsoft.com/en-us/dotnet/api/UnityEngine.AssetBundle 'UnityEngine.AssetBundle')

<a name='BTD_Mod_Helper.Api.ModContent.GetContent_T_()'></a>

## ModContent.GetContent<T>() Method

Gets all loaded ModContent objects that are T or a subclass of T

```csharp
public static System.Collections.Generic.List<T> GetContent<T>()
    where T : BTD_Mod_Helper.Api.ModContent;
```
#### Type parameters

<a name='BTD_Mod_Helper.Api.ModContent.GetContent_T_().T'></a>

`T`

#### Returns
[System.Collections.Generic.List&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.List-1 'System.Collections.Generic.List`1')[T](BTD_Mod_Helper.Api.ModContent.md#BTD_Mod_Helper.Api.ModContent.GetContent_T_().T 'BTD_Mod_Helper.Api.ModContent.GetContent<T>().T')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.List-1 'System.Collections.Generic.List`1')

<a name='BTD_Mod_Helper.Api.ModContent.GetDisplayGUID_T_()'></a>

## ModContent.GetDisplayGUID<T>() Method

Gets the GUID (thing that should be used in the display field for things) for a specific ModDisplay

```csharp
public static string GetDisplayGUID<T>()
    where T : BTD_Mod_Helper.Api.Display.ModDisplay;
```
#### Type parameters

<a name='BTD_Mod_Helper.Api.ModContent.GetDisplayGUID_T_().T'></a>

`T`

#### Returns
[System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')

<a name='BTD_Mod_Helper.Api.ModContent.GetId(BTD_Mod_Helper.BloonsMod,string)'></a>

## ModContent.GetId(BloonsMod, string) Method

Gets the id of a resource by appending the mod's ID prefix to its name

```csharp
public static string GetId(BTD_Mod_Helper.BloonsMod bloonsMod, string name);
```
#### Parameters

<a name='BTD_Mod_Helper.Api.ModContent.GetId(BTD_Mod_Helper.BloonsMod,string).bloonsMod'></a>

`bloonsMod` [BloonsMod](BTD_Mod_Helper.BloonsMod.md 'BTD_Mod_Helper.BloonsMod')

<a name='BTD_Mod_Helper.Api.ModContent.GetId(BTD_Mod_Helper.BloonsMod,string).name'></a>

`name` [System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')

#### Returns
[System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')

<a name='BTD_Mod_Helper.Api.ModContent.GetId(string)'></a>

## ModContent.GetId(string) Method

Gets the id of a resource by appending the mod's ID prefix to its name

```csharp
public string GetId(string name);
```
#### Parameters

<a name='BTD_Mod_Helper.Api.ModContent.GetId(string).name'></a>

`name` [System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')

#### Returns
[System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')

<a name='BTD_Mod_Helper.Api.ModContent.GetId_T_(string)'></a>

## ModContent.GetId<T>(string) Method

Gets the id of a resource by appending the mod's ID prefix to its name

```csharp
public static string GetId<T>(string name)
    where T : BTD_Mod_Helper.BloonsMod;
```
#### Type parameters

<a name='BTD_Mod_Helper.Api.ModContent.GetId_T_(string).T'></a>

`T`
#### Parameters

<a name='BTD_Mod_Helper.Api.ModContent.GetId_T_(string).name'></a>

`name` [System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')

#### Returns
[System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')

<a name='BTD_Mod_Helper.Api.ModContent.GetInstance(System.Type)'></a>

## ModContent.GetInstance(Type) Method

Gets the official instance of a particular ModContent or BloonsTD6Mod based on its type

```csharp
public static BTD_Mod_Helper.Api.IModContent GetInstance(System.Type type);
```
#### Parameters

<a name='BTD_Mod_Helper.Api.ModContent.GetInstance(System.Type).type'></a>

`type` [System.Type](https://docs.microsoft.com/en-us/dotnet/api/System.Type 'System.Type')

The type to get the instance of

#### Returns
[IModContent](BTD_Mod_Helper.Api.IModContent.md 'BTD_Mod_Helper.Api.IModContent')  
The official instance of it

<a name='BTD_Mod_Helper.Api.ModContent.GetInstance_T_()'></a>

## ModContent.GetInstance<T>() Method

Gets the singleton instance of a particular ModContent or BloonsTD6Mod based on its type

```csharp
public static T GetInstance<T>()
    where T : BTD_Mod_Helper.Api.IModContent;
```
#### Type parameters

<a name='BTD_Mod_Helper.Api.ModContent.GetInstance_T_().T'></a>

`T`

The type to get the instance of

#### Returns
[T](BTD_Mod_Helper.Api.ModContent.md#BTD_Mod_Helper.Api.ModContent.GetInstance_T_().T 'BTD_Mod_Helper.Api.ModContent.GetInstance<T>().T')  
The singleton instance of it

<a name='BTD_Mod_Helper.Api.ModContent.GetInstances_T_()'></a>

## ModContent.GetInstances<T>() Method

Gets all loaded ModContent objects that are exactly of type T

```csharp
public static System.Collections.Generic.List<T> GetInstances<T>()
    where T : BTD_Mod_Helper.Api.ModContent;
```
#### Type parameters

<a name='BTD_Mod_Helper.Api.ModContent.GetInstances_T_().T'></a>

`T`

#### Returns
[System.Collections.Generic.List&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.List-1 'System.Collections.Generic.List`1')[T](BTD_Mod_Helper.Api.ModContent.md#BTD_Mod_Helper.Api.ModContent.GetInstances_T_().T 'BTD_Mod_Helper.Api.ModContent.GetInstances<T>().T')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.List-1 'System.Collections.Generic.List`1')

<a name='BTD_Mod_Helper.Api.ModContent.GetMod(string)'></a>

## ModContent.GetMod(string) Method

Gets a BloonsTD6Mod by its name, or returns null if none are loaded with that name

```csharp
public static BTD_Mod_Helper.BloonsMod GetMod(string name);
```
#### Parameters

<a name='BTD_Mod_Helper.Api.ModContent.GetMod(string).name'></a>

`name` [System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')

#### Returns
[BloonsMod](BTD_Mod_Helper.BloonsMod.md 'BTD_Mod_Helper.BloonsMod')

<a name='BTD_Mod_Helper.Api.ModContent.GetSprite(BTD_Mod_Helper.BloonsMod,string,float)'></a>

## ModContent.GetSprite(BloonsMod, string, float) Method

Constructs a Sprite for a given texture name within a given mod

```csharp
public static Sprite GetSprite(BTD_Mod_Helper.BloonsMod mod, string name, float pixelsPerUnit=10f);
```
#### Parameters

<a name='BTD_Mod_Helper.Api.ModContent.GetSprite(BTD_Mod_Helper.BloonsMod,string,float).mod'></a>

`mod` [BloonsMod](BTD_Mod_Helper.BloonsMod.md 'BTD_Mod_Helper.BloonsMod')

<a name='BTD_Mod_Helper.Api.ModContent.GetSprite(BTD_Mod_Helper.BloonsMod,string,float).name'></a>

`name` [System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')

The file name of your texture, without the extension

<a name='BTD_Mod_Helper.Api.ModContent.GetSprite(BTD_Mod_Helper.BloonsMod,string,float).pixelsPerUnit'></a>

`pixelsPerUnit` [System.Single](https://docs.microsoft.com/en-us/dotnet/api/System.Single 'System.Single')

The pixels per unit for the Sprite to have

#### Returns
[UnityEngine.Sprite](https://docs.microsoft.com/en-us/dotnet/api/UnityEngine.Sprite 'UnityEngine.Sprite')  
A Sprite

<a name='BTD_Mod_Helper.Api.ModContent.GetSprite(string,float)'></a>

## ModContent.GetSprite(string, float) Method

Constructs a Sprite for a given texture name within this mod

```csharp
protected Sprite GetSprite(string name, float pixelsPerUnit=10f);
```
#### Parameters

<a name='BTD_Mod_Helper.Api.ModContent.GetSprite(string,float).name'></a>

`name` [System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')

The file name of your texture, without the extension

<a name='BTD_Mod_Helper.Api.ModContent.GetSprite(string,float).pixelsPerUnit'></a>

`pixelsPerUnit` [System.Single](https://docs.microsoft.com/en-us/dotnet/api/System.Single 'System.Single')

The pixels per unit for the Sprite to have

#### Returns
[UnityEngine.Sprite](https://docs.microsoft.com/en-us/dotnet/api/UnityEngine.Sprite 'UnityEngine.Sprite')  
A Sprite

<a name='BTD_Mod_Helper.Api.ModContent.GetSprite_T_(string,float)'></a>

## ModContent.GetSprite<T>(string, float) Method

Constructs a Sprite for a given texture name within a given mod

```csharp
public static Sprite GetSprite<T>(string name, float pixelsPerUnit=10f)
    where T : BTD_Mod_Helper.BloonsMod;
```
#### Type parameters

<a name='BTD_Mod_Helper.Api.ModContent.GetSprite_T_(string,float).T'></a>

`T`
#### Parameters

<a name='BTD_Mod_Helper.Api.ModContent.GetSprite_T_(string,float).name'></a>

`name` [System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')

The file name of your texture, without the extension

<a name='BTD_Mod_Helper.Api.ModContent.GetSprite_T_(string,float).pixelsPerUnit'></a>

`pixelsPerUnit` [System.Single](https://docs.microsoft.com/en-us/dotnet/api/System.Single 'System.Single')

The pixels per unit for the Sprite to have

#### Returns
[UnityEngine.Sprite](https://docs.microsoft.com/en-us/dotnet/api/UnityEngine.Sprite 'UnityEngine.Sprite')  
A Sprite

<a name='BTD_Mod_Helper.Api.ModContent.GetSpriteReference(BTD_Mod_Helper.BloonsMod,string)'></a>

## ModContent.GetSpriteReference(BloonsMod, string) Method

Gets a sprite reference by name for a specific mod

```csharp
public static SpriteReference GetSpriteReference(BTD_Mod_Helper.BloonsMod mod, string name);
```
#### Parameters

<a name='BTD_Mod_Helper.Api.ModContent.GetSpriteReference(BTD_Mod_Helper.BloonsMod,string).mod'></a>

`mod` [BloonsMod](BTD_Mod_Helper.BloonsMod.md 'BTD_Mod_Helper.BloonsMod')

The BloonsTD6Mod that the texture is from

<a name='BTD_Mod_Helper.Api.ModContent.GetSpriteReference(BTD_Mod_Helper.BloonsMod,string).name'></a>

`name` [System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')

The file name of your texture, without the extension

#### Returns
[Il2CppAssets.Scripts.Utils.SpriteReference](https://docs.microsoft.com/en-us/dotnet/api/Il2CppAssets.Scripts.Utils.SpriteReference 'Il2CppAssets.Scripts.Utils.SpriteReference')  
A new SpriteReference

<a name='BTD_Mod_Helper.Api.ModContent.GetSpriteReference(string)'></a>

## ModContent.GetSpriteReference(string) Method

Gets a sprite reference by name for this mod

```csharp
protected SpriteReference GetSpriteReference(string name);
```
#### Parameters

<a name='BTD_Mod_Helper.Api.ModContent.GetSpriteReference(string).name'></a>

`name` [System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')

The file name of your texture, without the extension

#### Returns
[Il2CppAssets.Scripts.Utils.SpriteReference](https://docs.microsoft.com/en-us/dotnet/api/Il2CppAssets.Scripts.Utils.SpriteReference 'Il2CppAssets.Scripts.Utils.SpriteReference')  
A new SpriteReference

<a name='BTD_Mod_Helper.Api.ModContent.GetSpriteReference_T_(string)'></a>

## ModContent.GetSpriteReference<T>(string) Method

Gets a sprite reference by name for a specific mod

```csharp
public static SpriteReference GetSpriteReference<T>(string name)
    where T : BTD_Mod_Helper.BloonsMod;
```
#### Type parameters

<a name='BTD_Mod_Helper.Api.ModContent.GetSpriteReference_T_(string).T'></a>

`T`

Your mod's main BloonsTD6Mod extending class
#### Parameters

<a name='BTD_Mod_Helper.Api.ModContent.GetSpriteReference_T_(string).name'></a>

`name` [System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')

The file name of your texture, without the extension

#### Returns
[Il2CppAssets.Scripts.Utils.SpriteReference](https://docs.microsoft.com/en-us/dotnet/api/Il2CppAssets.Scripts.Utils.SpriteReference 'Il2CppAssets.Scripts.Utils.SpriteReference')  
A new SpriteReference

<a name='BTD_Mod_Helper.Api.ModContent.GetSpriteReferenceOrDefault(BTD_Mod_Helper.BloonsMod,string)'></a>

## ModContent.GetSpriteReferenceOrDefault(BloonsMod, string) Method

Gets a sprite reference by name for a specific mod, or if the mod does not include a texture with that name,  
treats it as a vanilla sprite reference

```csharp
public static SpriteReference GetSpriteReferenceOrDefault(BTD_Mod_Helper.BloonsMod mod, string name);
```
#### Parameters

<a name='BTD_Mod_Helper.Api.ModContent.GetSpriteReferenceOrDefault(BTD_Mod_Helper.BloonsMod,string).mod'></a>

`mod` [BloonsMod](BTD_Mod_Helper.BloonsMod.md 'BTD_Mod_Helper.BloonsMod')

The BloonsTD6Mod that the texture is from

<a name='BTD_Mod_Helper.Api.ModContent.GetSpriteReferenceOrDefault(BTD_Mod_Helper.BloonsMod,string).name'></a>

`name` [System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')

The file name of your texture, without the extension

#### Returns
[Il2CppAssets.Scripts.Utils.SpriteReference](https://docs.microsoft.com/en-us/dotnet/api/Il2CppAssets.Scripts.Utils.SpriteReference 'Il2CppAssets.Scripts.Utils.SpriteReference')  
A new SpriteReference

<a name='BTD_Mod_Helper.Api.ModContent.GetSpriteReferenceOrDefault(string)'></a>

## ModContent.GetSpriteReferenceOrDefault(string) Method

Gets a sprite reference by name for a specific mod, or if the mod does not include a texture with that name,  
treats it as a vanilla sprite reference

```csharp
protected SpriteReference GetSpriteReferenceOrDefault(string name);
```
#### Parameters

<a name='BTD_Mod_Helper.Api.ModContent.GetSpriteReferenceOrDefault(string).name'></a>

`name` [System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')

The file name of your texture, without the extension

#### Returns
[Il2CppAssets.Scripts.Utils.SpriteReference](https://docs.microsoft.com/en-us/dotnet/api/Il2CppAssets.Scripts.Utils.SpriteReference 'Il2CppAssets.Scripts.Utils.SpriteReference')  
A new SpriteReference

<a name='BTD_Mod_Helper.Api.ModContent.GetSpriteReferenceOrDefault_T_(string)'></a>

## ModContent.GetSpriteReferenceOrDefault<T>(string) Method

Gets a sprite reference by name for a specific mod, or if the mod does not include a texture with that name,  
treats it as a vanilla sprite reference

```csharp
public static SpriteReference GetSpriteReferenceOrDefault<T>(string name)
    where T : BTD_Mod_Helper.BloonsMod;
```
#### Type parameters

<a name='BTD_Mod_Helper.Api.ModContent.GetSpriteReferenceOrDefault_T_(string).T'></a>

`T`

Your mod's main BloonsTD6Mod extending class
#### Parameters

<a name='BTD_Mod_Helper.Api.ModContent.GetSpriteReferenceOrDefault_T_(string).name'></a>

`name` [System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')

The file name of your texture, without the extension

#### Returns
[Il2CppAssets.Scripts.Utils.SpriteReference](https://docs.microsoft.com/en-us/dotnet/api/Il2CppAssets.Scripts.Utils.SpriteReference 'Il2CppAssets.Scripts.Utils.SpriteReference')  
A new SpriteReference

<a name='BTD_Mod_Helper.Api.ModContent.GetSpriteReferenceOrNull(BTD_Mod_Helper.BloonsMod,string)'></a>

## ModContent.GetSpriteReferenceOrNull(BloonsMod, string) Method

Gets a sprite reference by name for a specific mod, returning null if the texture hasn't currently been  
loaded instead of an invalid SpriteReference

```csharp
public static SpriteReference GetSpriteReferenceOrNull(BTD_Mod_Helper.BloonsMod mod, string name);
```
#### Parameters

<a name='BTD_Mod_Helper.Api.ModContent.GetSpriteReferenceOrNull(BTD_Mod_Helper.BloonsMod,string).mod'></a>

`mod` [BloonsMod](BTD_Mod_Helper.BloonsMod.md 'BTD_Mod_Helper.BloonsMod')

The BloonsTD6Mod that the texture is from

<a name='BTD_Mod_Helper.Api.ModContent.GetSpriteReferenceOrNull(BTD_Mod_Helper.BloonsMod,string).name'></a>

`name` [System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')

The file name of your texture, without the extension

#### Returns
[Il2CppAssets.Scripts.Utils.SpriteReference](https://docs.microsoft.com/en-us/dotnet/api/Il2CppAssets.Scripts.Utils.SpriteReference 'Il2CppAssets.Scripts.Utils.SpriteReference')  
A new SpriteReference

<a name='BTD_Mod_Helper.Api.ModContent.GetSpriteReferenceOrNull(string)'></a>

## ModContent.GetSpriteReferenceOrNull(string) Method

Gets a sprite reference by name for this mod, returning null if the texture hasn't currently been  
loaded instead of an invalid SpriteReference

```csharp
protected SpriteReference GetSpriteReferenceOrNull(string name);
```
#### Parameters

<a name='BTD_Mod_Helper.Api.ModContent.GetSpriteReferenceOrNull(string).name'></a>

`name` [System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')

The file name of your texture, without the extension

#### Returns
[Il2CppAssets.Scripts.Utils.SpriteReference](https://docs.microsoft.com/en-us/dotnet/api/Il2CppAssets.Scripts.Utils.SpriteReference 'Il2CppAssets.Scripts.Utils.SpriteReference')  
A new SpriteReference

<a name='BTD_Mod_Helper.Api.ModContent.GetSpriteReferenceOrNull_T_(string)'></a>

## ModContent.GetSpriteReferenceOrNull<T>(string) Method

Gets a sprite reference by name for a specific mod, returning null if the texture hasn't currently been  
loaded instead of an invalid SpriteReference

```csharp
public static SpriteReference GetSpriteReferenceOrNull<T>(string name)
    where T : BTD_Mod_Helper.BloonsMod;
```
#### Type parameters

<a name='BTD_Mod_Helper.Api.ModContent.GetSpriteReferenceOrNull_T_(string).T'></a>

`T`

Your mod's main BloonsTD6Mod extending class
#### Parameters

<a name='BTD_Mod_Helper.Api.ModContent.GetSpriteReferenceOrNull_T_(string).name'></a>

`name` [System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')

The file name of your texture, without the extension

#### Returns
[Il2CppAssets.Scripts.Utils.SpriteReference](https://docs.microsoft.com/en-us/dotnet/api/Il2CppAssets.Scripts.Utils.SpriteReference 'Il2CppAssets.Scripts.Utils.SpriteReference')  
A new SpriteReference

<a name='BTD_Mod_Helper.Api.ModContent.GetTexture(BTD_Mod_Helper.BloonsMod,string)'></a>

## ModContent.GetTexture(BloonsMod, string) Method

Constructs a Texture2D for a given texture name within a mod

```csharp
public static Texture2D GetTexture(BTD_Mod_Helper.BloonsMod bloonsMod, string fileName);
```
#### Parameters

<a name='BTD_Mod_Helper.Api.ModContent.GetTexture(BTD_Mod_Helper.BloonsMod,string).bloonsMod'></a>

`bloonsMod` [BloonsMod](BTD_Mod_Helper.BloonsMod.md 'BTD_Mod_Helper.BloonsMod')

The mod that adds this texture

<a name='BTD_Mod_Helper.Api.ModContent.GetTexture(BTD_Mod_Helper.BloonsMod,string).fileName'></a>

`fileName` [System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')

The file name of your texture, without the extension

#### Returns
[UnityEngine.Texture2D](https://docs.microsoft.com/en-us/dotnet/api/UnityEngine.Texture2D 'UnityEngine.Texture2D')  
A Texture2D

<a name='BTD_Mod_Helper.Api.ModContent.GetTexture(string)'></a>

## ModContent.GetTexture(string) Method

Constructs a Texture2D for a given texture name within this mod

```csharp
protected Texture2D GetTexture(string fileName);
```
#### Parameters

<a name='BTD_Mod_Helper.Api.ModContent.GetTexture(string).fileName'></a>

`fileName` [System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')

The file name of your texture, without the extension

#### Returns
[UnityEngine.Texture2D](https://docs.microsoft.com/en-us/dotnet/api/UnityEngine.Texture2D 'UnityEngine.Texture2D')  
A Texture2D

<a name='BTD_Mod_Helper.Api.ModContent.GetTexture_T_(string)'></a>

## ModContent.GetTexture<T>(string) Method

Constructs a Texture2D for a given texture name within a mod

```csharp
public static Texture2D GetTexture<T>(string fileName)
    where T : BTD_Mod_Helper.BloonsMod;
```
#### Type parameters

<a name='BTD_Mod_Helper.Api.ModContent.GetTexture_T_(string).T'></a>

`T`
#### Parameters

<a name='BTD_Mod_Helper.Api.ModContent.GetTexture_T_(string).fileName'></a>

`fileName` [System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')

The file name of your texture, without the extension

#### Returns
[UnityEngine.Texture2D](https://docs.microsoft.com/en-us/dotnet/api/UnityEngine.Texture2D 'UnityEngine.Texture2D')  
A Texture2D

<a name='BTD_Mod_Helper.Api.ModContent.GetTextureBytes(BTD_Mod_Helper.BloonsMod,string)'></a>

## ModContent.GetTextureBytes(BloonsMod, string) Method

Returns the Bytes associated with a texture.

```csharp
public static byte[] GetTextureBytes(BTD_Mod_Helper.BloonsMod bloonsMod, string fileName);
```
#### Parameters

<a name='BTD_Mod_Helper.Api.ModContent.GetTextureBytes(BTD_Mod_Helper.BloonsMod,string).bloonsMod'></a>

`bloonsMod` [BloonsMod](BTD_Mod_Helper.BloonsMod.md 'BTD_Mod_Helper.BloonsMod')

The mod that adds this texture.

<a name='BTD_Mod_Helper.Api.ModContent.GetTextureBytes(BTD_Mod_Helper.BloonsMod,string).fileName'></a>

`fileName` [System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')

The file name of your texture, without the extension.

#### Returns
[System.Byte](https://docs.microsoft.com/en-us/dotnet/api/System.Byte 'System.Byte')[[]](https://docs.microsoft.com/en-us/dotnet/api/System.Array 'System.Array')  
The bytes associated with the texture.

<a name='BTD_Mod_Helper.Api.ModContent.GetTextureBytes(string)'></a>

## ModContent.GetTextureBytes(string) Method

Returns the Bytes associated with a texture.

```csharp
protected byte[] GetTextureBytes(string fileName);
```
#### Parameters

<a name='BTD_Mod_Helper.Api.ModContent.GetTextureBytes(string).fileName'></a>

`fileName` [System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')

The file name of your texture, without the extension.

#### Returns
[System.Byte](https://docs.microsoft.com/en-us/dotnet/api/System.Byte 'System.Byte')[[]](https://docs.microsoft.com/en-us/dotnet/api/System.Array 'System.Array')  
The bytes associated with the texture.

<a name='BTD_Mod_Helper.Api.ModContent.GetTextureBytes_T_(string)'></a>

## ModContent.GetTextureBytes<T>(string) Method

Returns the Bytes associated with a texture.

```csharp
public static byte[] GetTextureBytes<T>(string fileName)
    where T : BTD_Mod_Helper.BloonsMod;
```
#### Type parameters

<a name='BTD_Mod_Helper.Api.ModContent.GetTextureBytes_T_(string).T'></a>

`T`
#### Parameters

<a name='BTD_Mod_Helper.Api.ModContent.GetTextureBytes_T_(string).fileName'></a>

`fileName` [System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')

The file name of your texture, without the extension.

#### Returns
[System.Byte](https://docs.microsoft.com/en-us/dotnet/api/System.Byte 'System.Byte')[[]](https://docs.microsoft.com/en-us/dotnet/api/System.Array 'System.Array')  
The bytes associated with the texture.

<a name='BTD_Mod_Helper.Api.ModContent.GetTextureGUID(BTD_Mod_Helper.BloonsMod,string)'></a>

## ModContent.GetTextureGUID(BloonsMod, string) Method

Gets a texture's GUID by name for a specific mod

```csharp
public static string GetTextureGUID(BTD_Mod_Helper.BloonsMod mod, string fileName);
```
#### Parameters

<a name='BTD_Mod_Helper.Api.ModContent.GetTextureGUID(BTD_Mod_Helper.BloonsMod,string).mod'></a>

`mod` [BloonsMod](BTD_Mod_Helper.BloonsMod.md 'BTD_Mod_Helper.BloonsMod')

The BloonsTD6Mod that the texture is from

<a name='BTD_Mod_Helper.Api.ModContent.GetTextureGUID(BTD_Mod_Helper.BloonsMod,string).fileName'></a>

`fileName` [System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')

The file name of your texture, without the extension

#### Returns
[System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')  
The texture's GUID

<a name='BTD_Mod_Helper.Api.ModContent.GetTextureGUID(string)'></a>

## ModContent.GetTextureGUID(string) Method

Gets a texture's GUID by name for this mod  
<br/>  
Returns null if a Texture hasn't been loaded with that name

```csharp
public string GetTextureGUID(string name);
```
#### Parameters

<a name='BTD_Mod_Helper.Api.ModContent.GetTextureGUID(string).name'></a>

`name` [System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')

The file name of your texture, without the extension

#### Returns
[System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')  
The texture's GUID

<a name='BTD_Mod_Helper.Api.ModContent.GetTextureGUID_T_(string)'></a>

## ModContent.GetTextureGUID<T>(string) Method

Gets a texture's GUID by name for a specific mod, to be used in SpriteReferences  
<br/>  
Returns null if a Texture hasn't been loaded with that name

```csharp
public static string GetTextureGUID<T>(string name)
    where T : BTD_Mod_Helper.BloonsMod;
```
#### Type parameters

<a name='BTD_Mod_Helper.Api.ModContent.GetTextureGUID_T_(string).T'></a>

`T`

Your mod's main BloonsTD6Mod extending class
#### Parameters

<a name='BTD_Mod_Helper.Api.ModContent.GetTextureGUID_T_(string).name'></a>

`name` [System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')

The file name of your texture, without the extension

#### Returns
[System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')  
The texture's GUID

<a name='BTD_Mod_Helper.Api.ModContent.GetTowerModel_T_(int,int,int)'></a>

## ModContent.GetTowerModel<T>(int, int, int) Method

Gets the TowerModel for a ModTower at a specific tier level

```csharp
public static TowerModel GetTowerModel<T>(int top=0, int mid=0, int bot=0)
    where T : BTD_Mod_Helper.Api.Towers.ModTower;
```
#### Type parameters

<a name='BTD_Mod_Helper.Api.ModContent.GetTowerModel_T_(int,int,int).T'></a>

`T`

The ModTower type
#### Parameters

<a name='BTD_Mod_Helper.Api.ModContent.GetTowerModel_T_(int,int,int).top'></a>

`top` [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/System.Int32 'System.Int32')

The top path tier

<a name='BTD_Mod_Helper.Api.ModContent.GetTowerModel_T_(int,int,int).mid'></a>

`mid` [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/System.Int32 'System.Int32')

The middle path tier

<a name='BTD_Mod_Helper.Api.ModContent.GetTowerModel_T_(int,int,int).bot'></a>

`bot` [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/System.Int32 'System.Int32')

The bottom path tier

#### Returns
[Il2CppAssets.Scripts.Models.Towers.TowerModel](https://docs.microsoft.com/en-us/dotnet/api/Il2CppAssets.Scripts.Models.Towers.TowerModel 'Il2CppAssets.Scripts.Models.Towers.TowerModel')  
The tower name/id

<a name='BTD_Mod_Helper.Api.ModContent.GetTowerSet_T_()'></a>

## ModContent.GetTowerSet<T>() Method

Gets the fabricated TowerSet enum value for a ModTowerSet

```csharp
public static TowerSet GetTowerSet<T>()
    where T : BTD_Mod_Helper.Api.Towers.ModTowerSet;
```
#### Type parameters

<a name='BTD_Mod_Helper.Api.ModContent.GetTowerSet_T_().T'></a>

`T`

#### Returns
[Il2CppAssets.Scripts.Models.TowerSets.TowerSet](https://docs.microsoft.com/en-us/dotnet/api/Il2CppAssets.Scripts.Models.TowerSets.TowerSet 'Il2CppAssets.Scripts.Models.TowerSets.TowerSet')

<a name='BTD_Mod_Helper.Api.ModContent.HasMod(string,BTD_Mod_Helper.BloonsMod)'></a>

## ModContent.HasMod(string, BloonsMod) Method

Returns whether a mod with the given name is installed, and pass it to the out param if it is

```csharp
public static bool HasMod(string name, out BTD_Mod_Helper.BloonsMod bloonsMod);
```
#### Parameters

<a name='BTD_Mod_Helper.Api.ModContent.HasMod(string,BTD_Mod_Helper.BloonsMod).name'></a>

`name` [System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')

<a name='BTD_Mod_Helper.Api.ModContent.HasMod(string,BTD_Mod_Helper.BloonsMod).bloonsMod'></a>

`bloonsMod` [BloonsMod](BTD_Mod_Helper.BloonsMod.md 'BTD_Mod_Helper.BloonsMod')

#### Returns
[System.Boolean](https://docs.microsoft.com/en-us/dotnet/api/System.Boolean 'System.Boolean')

<a name='BTD_Mod_Helper.Api.ModContent.HasMod(string)'></a>

## ModContent.HasMod(string) Method

Returns whether a mod with the given name is installed

```csharp
public static bool HasMod(string name);
```
#### Parameters

<a name='BTD_Mod_Helper.Api.ModContent.HasMod(string).name'></a>

`name` [System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')

#### Returns
[System.Boolean](https://docs.microsoft.com/en-us/dotnet/api/System.Boolean 'System.Boolean')

<a name='BTD_Mod_Helper.Api.ModContent.Load(BTD_Mod_Helper.Api.ModContent)'></a>

## ModContent.Load(ModContent) Method

Creates the Instances of a ModContent type within a Mod and adds them to ModContentInstances

```csharp
private static System.Collections.Generic.IEnumerable<BTD_Mod_Helper.Api.ModContent> Load(BTD_Mod_Helper.Api.ModContent instance);
```
#### Parameters

<a name='BTD_Mod_Helper.Api.ModContent.Load(BTD_Mod_Helper.Api.ModContent).instance'></a>

`instance` [ModContent](BTD_Mod_Helper.Api.ModContent.md 'BTD_Mod_Helper.Api.ModContent')

#### Returns
[System.Collections.Generic.IEnumerable&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.IEnumerable-1 'System.Collections.Generic.IEnumerable`1')[ModContent](BTD_Mod_Helper.Api.ModContent.md 'BTD_Mod_Helper.Api.ModContent')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.IEnumerable-1 'System.Collections.Generic.IEnumerable`1')

<a name='BTD_Mod_Helper.Api.ModContent.RoundSetId_T_()'></a>

## ModContent.RoundSetId<T>() Method

Gets the ID for the given ModRoundSet

```csharp
public static string RoundSetId<T>()
    where T : BTD_Mod_Helper.Api.Bloons.ModRoundSet;
```
#### Type parameters

<a name='BTD_Mod_Helper.Api.ModContent.RoundSetId_T_().T'></a>

`T`

#### Returns
[System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')

<a name='BTD_Mod_Helper.Api.ModContent.TextureExists(BTD_Mod_Helper.BloonsMod,string)'></a>

## ModContent.TextureExists(BloonsMod, string) Method

Gets whether a texture with a given name has been loaded by the Mod Helper for a mod

```csharp
public static bool TextureExists(BTD_Mod_Helper.BloonsMod bloonsMod, string name);
```
#### Parameters

<a name='BTD_Mod_Helper.Api.ModContent.TextureExists(BTD_Mod_Helper.BloonsMod,string).bloonsMod'></a>

`bloonsMod` [BloonsMod](BTD_Mod_Helper.BloonsMod.md 'BTD_Mod_Helper.BloonsMod')

The mod to look in

<a name='BTD_Mod_Helper.Api.ModContent.TextureExists(BTD_Mod_Helper.BloonsMod,string).name'></a>

`name` [System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')

The file name of your texture, without the extension

#### Returns
[System.Boolean](https://docs.microsoft.com/en-us/dotnet/api/System.Boolean 'System.Boolean')

<a name='BTD_Mod_Helper.Api.ModContent.TextureExists(string)'></a>

## ModContent.TextureExists(string) Method

Gets whether a texture with a given name has been loaded by the Mod Helper for this mod

```csharp
protected bool TextureExists(string name);
```
#### Parameters

<a name='BTD_Mod_Helper.Api.ModContent.TextureExists(string).name'></a>

`name` [System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')

The file name of your texture, without the extension

#### Returns
[System.Boolean](https://docs.microsoft.com/en-us/dotnet/api/System.Boolean 'System.Boolean')

<a name='BTD_Mod_Helper.Api.ModContent.TextureExists_T_(string)'></a>

## ModContent.TextureExists<T>(string) Method

Gets whether a texture with a given name has been loaded by the Mod Helper for a mod

```csharp
public static bool TextureExists<T>(string name)
    where T : BTD_Mod_Helper.BloonsMod;
```
#### Type parameters

<a name='BTD_Mod_Helper.Api.ModContent.TextureExists_T_(string).T'></a>

`T`

The mod to look in
#### Parameters

<a name='BTD_Mod_Helper.Api.ModContent.TextureExists_T_(string).name'></a>

`name` [System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')

The file name of your texture, without the extension

#### Returns
[System.Boolean](https://docs.microsoft.com/en-us/dotnet/api/System.Boolean 'System.Boolean')

<a name='BTD_Mod_Helper.Api.ModContent.TowerID_T_(int,int,int)'></a>

## ModContent.TowerID<T>(int, int, int) Method

Gets the internal tower name/id for a ModTower

```csharp
public static string TowerID<T>(int top=0, int mid=0, int bot=0)
    where T : BTD_Mod_Helper.Api.Towers.ModTower;
```
#### Type parameters

<a name='BTD_Mod_Helper.Api.ModContent.TowerID_T_(int,int,int).T'></a>

`T`

The ModTower type
#### Parameters

<a name='BTD_Mod_Helper.Api.ModContent.TowerID_T_(int,int,int).top'></a>

`top` [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/System.Int32 'System.Int32')

The top path tier

<a name='BTD_Mod_Helper.Api.ModContent.TowerID_T_(int,int,int).mid'></a>

`mid` [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/System.Int32 'System.Int32')

The middle path tier

<a name='BTD_Mod_Helper.Api.ModContent.TowerID_T_(int,int,int).bot'></a>

`bot` [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/System.Int32 'System.Int32')

The bottom path tier

#### Returns
[System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')  
The tower name/id

<a name='BTD_Mod_Helper.Api.ModContent.TryFind_T_(string,T)'></a>

## ModContent.TryFind<T>(string, T) Method

Finds the loaded ModContent with the given Id and type T

```csharp
public static bool TryFind<T>(string id, out T result)
    where T : BTD_Mod_Helper.Api.ModContent;
```
#### Type parameters

<a name='BTD_Mod_Helper.Api.ModContent.TryFind_T_(string,T).T'></a>

`T`
#### Parameters

<a name='BTD_Mod_Helper.Api.ModContent.TryFind_T_(string,T).id'></a>

`id` [System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')

<a name='BTD_Mod_Helper.Api.ModContent.TryFind_T_(string,T).result'></a>

`result` [T](BTD_Mod_Helper.Api.ModContent.md#BTD_Mod_Helper.Api.ModContent.TryFind_T_(string,T).T 'BTD_Mod_Helper.Api.ModContent.TryFind<T>(string, T).T')

#### Returns
[System.Boolean](https://docs.microsoft.com/en-us/dotnet/api/System.Boolean 'System.Boolean')

<a name='BTD_Mod_Helper.Api.ModContent.UpgradeID_T_()'></a>

## ModContent.UpgradeID<T>() Method

Gets the internal upgrade name/id for a ModUpgrade

```csharp
public static string UpgradeID<T>()
    where T : BTD_Mod_Helper.Api.Towers.ModUpgrade;
```
#### Type parameters

<a name='BTD_Mod_Helper.Api.ModContent.UpgradeID_T_().T'></a>

`T`

The ModUpgrade type

#### Returns
[System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')  
The upgrade name/id