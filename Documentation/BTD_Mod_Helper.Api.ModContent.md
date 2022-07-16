#### [BloonsTD6 Mod Helper](index.md 'index')
### [BTD_Mod_Helper.Api](index.md#BTD_Mod_Helper.Api 'BTD_Mod_Helper.Api')

## ModContent Class

ModContent serves two major purposes:  
    <br/>  
    1. It is a base class for things that needs to be loaded via reflection from mods and given Ids,  
    such as ModTower and ModUpgrade  
    <br/>  
    2. It is a utility class with methods to access instances of those classes and other resources

```csharp
public abstract class ModContent :
BTD_Mod_Helper.Api.IModContent
```

Inheritance [System.Object](https://docs.microsoft.com/en-us/dotnet/api/System.Object 'System.Object') &#129106; ModContent

Derived  
&#8627; [ModDisplay](BTD_Mod_Helper.Api.Display.ModDisplay.md 'BTD_Mod_Helper.Api.Display.ModDisplay')  
&#8627; [ModByteLoader](BTD_Mod_Helper.Api.ModByteLoader.md 'BTD_Mod_Helper.Api.ModByteLoader')  
&#8627; [ModGameMenu](BTD_Mod_Helper.Api.ModGameMenu.md 'BTD_Mod_Helper.Api.ModGameMenu')  
&#8627; [NamedModContent](BTD_Mod_Helper.Api.NamedModContent.md 'BTD_Mod_Helper.Api.NamedModContent')  
&#8627; [ModVanillaContent](BTD_Mod_Helper.Api.Towers.ModVanillaContent.md 'BTD_Mod_Helper.Api.Towers.ModVanillaContent')

Implements [IModContent](BTD_Mod_Helper.Api.IModContent.md 'BTD_Mod_Helper.Api.IModContent')
### Fields

<a name='BTD_Mod_Helper.Api.ModContent.mod'></a>

## ModContent.mod Field

(Cross-Game compatible) The BloonsMod that this content was added by

```csharp
public BloonsMod mod;
```

#### Field Value
[BloonsMod](BTD_Mod_Helper.BloonsMod.md 'BTD_Mod_Helper.BloonsMod')
### Properties

<a name='BTD_Mod_Helper.Api.ModContent.Id'></a>

## ModContent.Id Property

(Cross-Game compatible) The id that this ModContent will be given; a combination of the Mod's prefix and the name

```csharp
public string Id { get; }
```

#### Property Value
[System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')

<a name='BTD_Mod_Helper.Api.ModContent.ID'></a>

## ModContent.ID Property

(Cross-Game compatible) Backing property for ID that's only able to be overriden internally

```csharp
protected internal virtual string ID { get; }
```

#### Property Value
[System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')

<a name='BTD_Mod_Helper.Api.ModContent.Name'></a>

## ModContent.Name Property

(Cross-Game compatible) The name that will be at the end of the ID for this ModContent, by default the class name

```csharp
public virtual string Name { get; }
```

#### Property Value
[System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')

<a name='BTD_Mod_Helper.Api.ModContent.RegisterPerFrame'></a>

## ModContent.RegisterPerFrame Property

(Cross-Game compatible) How many of this ModContent should it try to register in each frame. Higher numbers could lead to faster but choppier loading.

```csharp
public virtual int RegisterPerFrame { get; }
```

#### Property Value
[System.Int32](https://docs.microsoft.com/en-us/dotnet/api/System.Int32 'System.Int32')

<a name='BTD_Mod_Helper.Api.ModContent.RegistrationPriority'></a>

## ModContent.RegistrationPriority Property

(Cross-Game compatible) Used to allow some ModContent to Register before or after others

```csharp
protected virtual float RegistrationPriority { get; }
```

#### Property Value
[System.Single](https://docs.microsoft.com/en-us/dotnet/api/System.Single 'System.Single')
### Methods

<a name='BTD_Mod_Helper.Api.ModContent.BloonID_T_()'></a>

## ModContent.BloonID<T>() Method

(Cross-Game compatible) Gets the ID for the given ModBloon

```csharp
public static string BloonID<T>()
    where T : BTD_Mod_Helper.Api.Bloons.ModBloon;
```
#### Type parameters

<a name='BTD_Mod_Helper.Api.ModContent.BloonID_T_().T'></a>

`T`

#### Returns
[System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')

<a name='BTD_Mod_Helper.Api.ModContent.CreateInstances(System.Type,BTD_Mod_Helper.BloonsMod)'></a>

## ModContent.CreateInstances(Type, BloonsMod) Method

(Cross-Game compatible) Creates the Instances of a ModContent type within a Mod and adds them to ModContentInstances

```csharp
private static System.Collections.Generic.IEnumerable<BTD_Mod_Helper.Api.ModContent> CreateInstances(System.Type type, BTD_Mod_Helper.BloonsMod mod);
```
#### Parameters

<a name='BTD_Mod_Helper.Api.ModContent.CreateInstances(System.Type,BTD_Mod_Helper.BloonsMod).type'></a>

`type` [System.Type](https://docs.microsoft.com/en-us/dotnet/api/System.Type 'System.Type')

<a name='BTD_Mod_Helper.Api.ModContent.CreateInstances(System.Type,BTD_Mod_Helper.BloonsMod).mod'></a>

`mod` [BloonsMod](BTD_Mod_Helper.BloonsMod.md 'BTD_Mod_Helper.BloonsMod')

#### Returns
[System.Collections.Generic.IEnumerable&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.IEnumerable-1 'System.Collections.Generic.IEnumerable`1')[ModContent](BTD_Mod_Helper.Api.ModContent.md 'BTD_Mod_Helper.Api.ModContent')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.IEnumerable-1 'System.Collections.Generic.IEnumerable`1')

<a name='BTD_Mod_Helper.Api.ModContent.CreateSpriteReference(string)'></a>

## ModContent.CreateSpriteReference(string) Method

(Cross-Game compatible) Returns a new SpriteReference that uses the given guid

```csharp
public static Assets.Scripts.Utils.SpriteReference CreateSpriteReference(string guid);
```
#### Parameters

<a name='BTD_Mod_Helper.Api.ModContent.CreateSpriteReference(string).guid'></a>

`guid` [System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')

The guid that you'd like to assign to the SpriteReference

#### Returns
[Assets.Scripts.Utils.SpriteReference](https://docs.microsoft.com/en-us/dotnet/api/Assets.Scripts.Utils.SpriteReference 'Assets.Scripts.Utils.SpriteReference')

<a name='BTD_Mod_Helper.Api.ModContent.CreateSpriteReference(uint[])'></a>

## ModContent.CreateSpriteReference(uint[]) Method

(Cross-Game compatible) Creates a Sprite reference from the unsigned ints that can be found for a vanilla Sprite in AssetStudio

```csharp
public static Assets.Scripts.Utils.SpriteReference CreateSpriteReference(params uint[] data);
```
#### Parameters

<a name='BTD_Mod_Helper.Api.ModContent.CreateSpriteReference(uint[]).data'></a>

`data` [System.UInt32](https://docs.microsoft.com/en-us/dotnet/api/System.UInt32 'System.UInt32')[[]](https://docs.microsoft.com/en-us/dotnet/api/System.Array 'System.Array')

#### Returns
[Assets.Scripts.Utils.SpriteReference](https://docs.microsoft.com/en-us/dotnet/api/Assets.Scripts.Utils.SpriteReference 'Assets.Scripts.Utils.SpriteReference')

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

<a name='BTD_Mod_Helper.Api.ModContent.GetBundle(BTD_Mod_Helper.BloonsMod,string)'></a>

## ModContent.GetBundle(BloonsMod, string) Method

(Cross-Game compatible) Gets a bundle from a mod with the specified name (no file extension)

```csharp
public static UnityEngine.AssetBundle GetBundle(BTD_Mod_Helper.BloonsMod mod, string name);
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

(Cross-Game compatible) Gets a bundle from your mod with the specified name (no file extension)

```csharp
protected UnityEngine.AssetBundle GetBundle(string name);
```
#### Parameters

<a name='BTD_Mod_Helper.Api.ModContent.GetBundle(string).name'></a>

`name` [System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')

#### Returns
[UnityEngine.AssetBundle](https://docs.microsoft.com/en-us/dotnet/api/UnityEngine.AssetBundle 'UnityEngine.AssetBundle')

<a name='BTD_Mod_Helper.Api.ModContent.GetBundle_T_(string)'></a>

## ModContent.GetBundle<T>(string) Method

(Cross-Game compatible) Gets a bundle from the mod T with the specified name (no file extension)

```csharp
public static UnityEngine.AssetBundle GetBundle<T>(string name)
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

(Cross-Game compatible) Gets all loaded ModContent objects that are T or a subclass of T

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

(Cross-Game compatible) Gets the GUID (thing that should be used in the display field for things) for a specific ModDisplay

```csharp
public static string GetDisplayGUID<T>()
    where T : BTD_Mod_Helper.Api.Display.ModDisplay;
```
#### Type parameters

<a name='BTD_Mod_Helper.Api.ModContent.GetDisplayGUID_T_().T'></a>

`T`

#### Returns
[System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')

<a name='BTD_Mod_Helper.Api.ModContent.GetInstance(System.Type)'></a>

## ModContent.GetInstance(Type) Method

(Cross-Game compatible) Gets the official instance of a particular ModContent or BloonsMod based on its type

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

(Cross-Game compatible) Gets the singleton instance of a particular ModContent or BloonsMod based on its type

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

(Cross-Game compatible) Gets all loaded ModContent objects that are of type T

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

(Cross-Game compatible) Gets a BloonsMod by its name, or returns null if none are loaded with that name

```csharp
public static BTD_Mod_Helper.BloonsMod GetMod(string name);
```
#### Parameters

<a name='BTD_Mod_Helper.Api.ModContent.GetMod(string).name'></a>

`name` [System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')

#### Returns
[BloonsMod](BTD_Mod_Helper.BloonsMod.md 'BTD_Mod_Helper.BloonsMod')

<a name='BTD_Mod_Helper.Api.ModContent.GetModMap(string)'></a>

## ModContent.GetModMap(string) Method

Returns a ModMap based on it's name.

```csharp
public static BTD_Mod_Helper.Api.Scenarios.ModMap GetModMap(string mapName);
```
#### Parameters

<a name='BTD_Mod_Helper.Api.ModContent.GetModMap(string).mapName'></a>

`mapName` [System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')

#### Returns
[ModMap](BTD_Mod_Helper.Api.Scenarios.ModMap.md 'BTD_Mod_Helper.Api.Scenarios.ModMap')

<a name='BTD_Mod_Helper.Api.ModContent.GetSprite(BTD_Mod_Helper.BloonsMod,string,float)'></a>

## ModContent.GetSprite(BloonsMod, string, float) Method

(Cross-Game compatible) Constructs a Sprite for a given texture name within a given mod

```csharp
public static UnityEngine.Sprite GetSprite(BTD_Mod_Helper.BloonsMod mod, string name, float pixelsPerUnit=10f);
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

(Cross-Game compatible) Constructs a Sprite for a given texture name within this mod

```csharp
protected UnityEngine.Sprite GetSprite(string name, float pixelsPerUnit=10f);
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

(Cross-Game compatible) Constructs a Sprite for a given texture name within a given mod

```csharp
public static UnityEngine.Sprite GetSprite<T>(string name, float pixelsPerUnit=10f)
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

(Cross-Game compatible) Gets a sprite reference by name for a specific mod

```csharp
public static Assets.Scripts.Utils.SpriteReference GetSpriteReference(BTD_Mod_Helper.BloonsMod mod, string name);
```
#### Parameters

<a name='BTD_Mod_Helper.Api.ModContent.GetSpriteReference(BTD_Mod_Helper.BloonsMod,string).mod'></a>

`mod` [BloonsMod](BTD_Mod_Helper.BloonsMod.md 'BTD_Mod_Helper.BloonsMod')

The BloonsMod that the texture is from

<a name='BTD_Mod_Helper.Api.ModContent.GetSpriteReference(BTD_Mod_Helper.BloonsMod,string).name'></a>

`name` [System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')

The file name of your texture, without the extension

#### Returns
[Assets.Scripts.Utils.SpriteReference](https://docs.microsoft.com/en-us/dotnet/api/Assets.Scripts.Utils.SpriteReference 'Assets.Scripts.Utils.SpriteReference')  
A new SpriteReference

<a name='BTD_Mod_Helper.Api.ModContent.GetSpriteReference(string)'></a>

## ModContent.GetSpriteReference(string) Method

(Cross-Game compatible) Gets a sprite reference by name for this mod

```csharp
protected Assets.Scripts.Utils.SpriteReference GetSpriteReference(string name);
```
#### Parameters

<a name='BTD_Mod_Helper.Api.ModContent.GetSpriteReference(string).name'></a>

`name` [System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')

The file name of your texture, without the extension

#### Returns
[Assets.Scripts.Utils.SpriteReference](https://docs.microsoft.com/en-us/dotnet/api/Assets.Scripts.Utils.SpriteReference 'Assets.Scripts.Utils.SpriteReference')  
A new SpriteReference

<a name='BTD_Mod_Helper.Api.ModContent.GetSpriteReference_T_(string)'></a>

## ModContent.GetSpriteReference<T>(string) Method

(Cross-Game compatible) Gets a sprite reference by name for a specific mod

```csharp
public static Assets.Scripts.Utils.SpriteReference GetSpriteReference<T>(string name)
    where T : BTD_Mod_Helper.BloonsMod;
```
#### Type parameters

<a name='BTD_Mod_Helper.Api.ModContent.GetSpriteReference_T_(string).T'></a>

`T`

Your mod's main BloonsMod extending class
#### Parameters

<a name='BTD_Mod_Helper.Api.ModContent.GetSpriteReference_T_(string).name'></a>

`name` [System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')

The file name of your texture, without the extension

#### Returns
[Assets.Scripts.Utils.SpriteReference](https://docs.microsoft.com/en-us/dotnet/api/Assets.Scripts.Utils.SpriteReference 'Assets.Scripts.Utils.SpriteReference')  
A new SpriteReference

<a name='BTD_Mod_Helper.Api.ModContent.GetSpriteReferenceOrNull(BTD_Mod_Helper.BloonsMod,string)'></a>

## ModContent.GetSpriteReferenceOrNull(BloonsMod, string) Method

(Cross-Game compatible) Gets a sprite reference by name for a specific mod,returning null if the texture hasn't currently been  
loaded instead of an invalid SpriteReference

```csharp
public static Assets.Scripts.Utils.SpriteReference GetSpriteReferenceOrNull(BTD_Mod_Helper.BloonsMod mod, string name);
```
#### Parameters

<a name='BTD_Mod_Helper.Api.ModContent.GetSpriteReferenceOrNull(BTD_Mod_Helper.BloonsMod,string).mod'></a>

`mod` [BloonsMod](BTD_Mod_Helper.BloonsMod.md 'BTD_Mod_Helper.BloonsMod')

The BloonsMod that the texture is from

<a name='BTD_Mod_Helper.Api.ModContent.GetSpriteReferenceOrNull(BTD_Mod_Helper.BloonsMod,string).name'></a>

`name` [System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')

The file name of your texture, without the extension

#### Returns
[Assets.Scripts.Utils.SpriteReference](https://docs.microsoft.com/en-us/dotnet/api/Assets.Scripts.Utils.SpriteReference 'Assets.Scripts.Utils.SpriteReference')  
A new SpriteReference

<a name='BTD_Mod_Helper.Api.ModContent.GetSpriteReferenceOrNull(string)'></a>

## ModContent.GetSpriteReferenceOrNull(string) Method

(Cross-Game compatible) Gets a sprite reference by name for this mod, returning null if the texture hasn't currently been  
loaded instead of an invalid SpriteReference

```csharp
protected Assets.Scripts.Utils.SpriteReference GetSpriteReferenceOrNull(string name);
```
#### Parameters

<a name='BTD_Mod_Helper.Api.ModContent.GetSpriteReferenceOrNull(string).name'></a>

`name` [System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')

The file name of your texture, without the extension

#### Returns
[Assets.Scripts.Utils.SpriteReference](https://docs.microsoft.com/en-us/dotnet/api/Assets.Scripts.Utils.SpriteReference 'Assets.Scripts.Utils.SpriteReference')  
A new SpriteReference

<a name='BTD_Mod_Helper.Api.ModContent.GetSpriteReferenceOrNull_T_(string)'></a>

## ModContent.GetSpriteReferenceOrNull<T>(string) Method

(Cross-Game compatible) Gets a sprite reference by name for a specific mod, returning null if the texture hasn't currently been  
loaded instead of an invalid SpriteReference

```csharp
public static Assets.Scripts.Utils.SpriteReference GetSpriteReferenceOrNull<T>(string name)
    where T : BTD_Mod_Helper.BloonsMod;
```
#### Type parameters

<a name='BTD_Mod_Helper.Api.ModContent.GetSpriteReferenceOrNull_T_(string).T'></a>

`T`

Your mod's main BloonsMod extending class
#### Parameters

<a name='BTD_Mod_Helper.Api.ModContent.GetSpriteReferenceOrNull_T_(string).name'></a>

`name` [System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')

The file name of your texture, without the extension

#### Returns
[Assets.Scripts.Utils.SpriteReference](https://docs.microsoft.com/en-us/dotnet/api/Assets.Scripts.Utils.SpriteReference 'Assets.Scripts.Utils.SpriteReference')  
A new SpriteReference

<a name='BTD_Mod_Helper.Api.ModContent.GetTexture(BTD_Mod_Helper.BloonsMod,string)'></a>

## ModContent.GetTexture(BloonsMod, string) Method

(Cross-Game compatible) Constructs a Texture2D for a given texture name within a mod

```csharp
public static UnityEngine.Texture2D GetTexture(BTD_Mod_Helper.BloonsMod bloonsMod, string fileName);
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

(Cross-Game compatible) Constructs a Texture2D for a given texture name within this mod

```csharp
protected UnityEngine.Texture2D GetTexture(string fileName);
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

(Cross-Game compatible) Constructs a Texture2D for a given texture name within a mod

```csharp
public static UnityEngine.Texture2D GetTexture<T>(string fileName)
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

(Cross-Game compatible) Returns the Bytes associated with a texture.

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

(Cross-Game compatible) Returns the Bytes associated with a texture.

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

(Cross-Game compatible) Returns the Bytes associated with a texture.

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

(Cross-Game compatible) Gets a texture's GUID by name for a specific mod

```csharp
public static string GetTextureGUID(BTD_Mod_Helper.BloonsMod mod, string fileName);
```
#### Parameters

<a name='BTD_Mod_Helper.Api.ModContent.GetTextureGUID(BTD_Mod_Helper.BloonsMod,string).mod'></a>

`mod` [BloonsMod](BTD_Mod_Helper.BloonsMod.md 'BTD_Mod_Helper.BloonsMod')

The BloonsMod that the texture is from

<a name='BTD_Mod_Helper.Api.ModContent.GetTextureGUID(BTD_Mod_Helper.BloonsMod,string).fileName'></a>

`fileName` [System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')

The file name of your texture, without the extension

#### Returns
[System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')  
The texture's GUID

<a name='BTD_Mod_Helper.Api.ModContent.GetTextureGUID(string)'></a>

## ModContent.GetTextureGUID(string) Method

(Cross-Game compatible) Gets a texture's GUID by name for this mod  
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

(Cross-Game compatible) Gets a texture's GUID by name for a specific mod  
<br/>  
Returns null if a Texture hasn't been loaded with that name

```csharp
public static string GetTextureGUID<T>(string name)
    where T : BTD_Mod_Helper.BloonsMod;
```
#### Type parameters

<a name='BTD_Mod_Helper.Api.ModContent.GetTextureGUID_T_(string).T'></a>

`T`

Your mod's main BloonsMod extending class
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
public static Assets.Scripts.Models.Towers.TowerModel GetTowerModel<T>(int top=0, int mid=0, int bot=0)
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
[Assets.Scripts.Models.Towers.TowerModel](https://docs.microsoft.com/en-us/dotnet/api/Assets.Scripts.Models.Towers.TowerModel 'Assets.Scripts.Models.Towers.TowerModel')  
The tower name/id

<a name='BTD_Mod_Helper.Api.ModContent.Load()'></a>

## ModContent.Load() Method

(Cross-Game compatible) Used for when you want to programmatically create multiple instances of a given ModContent

```csharp
public virtual System.Collections.Generic.IEnumerable<BTD_Mod_Helper.Api.ModContent> Load();
```

#### Returns
[System.Collections.Generic.IEnumerable&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.IEnumerable-1 'System.Collections.Generic.IEnumerable`1')[ModContent](BTD_Mod_Helper.Api.ModContent.md 'BTD_Mod_Helper.Api.ModContent')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.IEnumerable-1 'System.Collections.Generic.IEnumerable`1')

<a name='BTD_Mod_Helper.Api.ModContent.Register()'></a>

## ModContent.Register() Method

(Cross-Game compatible) Registers this ModContent into the game

```csharp
public abstract void Register();
```

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

(Cross-Game compatible) Gets whether a texture with a given name has been loaded by the Mod Helper for a mod

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

(Cross-Game compatible) Gets whether a texture with a given name has been loaded by the Mod Helper for this mod

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

(Cross-Game compatible) Gets whether a texture with a given name has been loaded by the Mod Helper for a mod

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

<a name='BTD_Mod_Helper.Api.ModContent.TowerSet_T_()'></a>

## ModContent.TowerSet<T>() Method

Gets the internal tower set id for a given TowerSet

```csharp
public static string TowerSet<T>()
    where T : BTD_Mod_Helper.Api.Towers.ModTowerSet;
```
#### Type parameters

<a name='BTD_Mod_Helper.Api.ModContent.TowerSet_T_().T'></a>

`T`

The ModUpgrade type

#### Returns
[System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')  
The upgrade name/id

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