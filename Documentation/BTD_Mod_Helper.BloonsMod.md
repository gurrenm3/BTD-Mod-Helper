#### [BloonsTD6 Mod Helper](README.md 'README')
### [BTD_Mod_Helper](README.md#BTD_Mod_Helper 'BTD_Mod_Helper')

## BloonsMod Class

Expanded version of MelonMod to suit the needs of Bloons games and the Mod Helper

```csharp
public abstract class BloonsMod :
BTD_Mod_Helper.Api.IModContent
```

Inheritance [MelonLoader.MelonMod](https://docs.microsoft.com/en-us/dotnet/api/MelonLoader.MelonMod 'MelonLoader.MelonMod') &#129106; BloonsMod

Derived  
&#8627; [BloonsTD6Mod](BTD_Mod_Helper.BloonsTD6Mod.md 'BTD_Mod_Helper.BloonsTD6Mod')

Implements [IModContent](BTD_Mod_Helper.Api.IModContent.md 'BTD_Mod_Helper.Api.IModContent')
### Properties

<a name='BTD_Mod_Helper.BloonsMod.AudioClips'></a>

## BloonsMod.AudioClips Property

Audio clips for the embedded sounds in this mod

```csharp
public System.Collections.Generic.Dictionary<string,AudioClip> AudioClips { get; set; }
```

#### Property Value
[System.Collections.Generic.Dictionary&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.Dictionary-2 'System.Collections.Generic.Dictionary`2')[System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')[,](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.Dictionary-2 'System.Collections.Generic.Dictionary`2')[UnityEngine.AudioClip](https://docs.microsoft.com/en-us/dotnet/api/UnityEngine.AudioClip 'UnityEngine.AudioClip')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.Dictionary-2 'System.Collections.Generic.Dictionary`2')

<a name='BTD_Mod_Helper.BloonsMod.CheatMod'></a>

## BloonsMod.CheatMod Property

Setting this to true will prevent your BloonsMod hooks from executing if the player could get flagged for using mods at that time.  
<br/>   
For example, using mods in public co-op

```csharp
public virtual bool CheatMod { get; }
```

#### Property Value
[System.Boolean](https://docs.microsoft.com/en-us/dotnet/api/System.Boolean 'System.Boolean')

<a name='BTD_Mod_Helper.BloonsMod.Content'></a>

## BloonsMod.Content Property

All ModContent in ths mod

```csharp
public System.Collections.Generic.IReadOnlyList<BTD_Mod_Helper.Api.ModContent> Content { get; set; }
```

#### Property Value
[System.Collections.Generic.IReadOnlyList&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.IReadOnlyList-1 'System.Collections.Generic.IReadOnlyList`1')[ModContent](BTD_Mod_Helper.Api.ModContent.md 'BTD_Mod_Helper.Api.ModContent')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.IReadOnlyList-1 'System.Collections.Generic.IReadOnlyList`1')

<a name='BTD_Mod_Helper.BloonsMod.GithubReleaseURL'></a>

## BloonsMod.GithubReleaseURL Property

[https://github.com/gurrenm3/BTD-Mod-Helper/wiki/%5B3.0%5D-Appearing-in-the-Mod-Browser-%28ModHelperData%29](https://github.com/gurrenm3/BTD-Mod-Helper/wiki/%5B3.0%5D-Appearing-in-the-Mod-Browser-%28ModHelperData%29 'https://github.com/gurrenm3/BTD-Mod-Helper/wiki/%5B3.0%5D-Appearing-in-the-Mod-Browser-%28ModHelperData%29')

```csharp
public virtual string GithubReleaseURL { get; }
```

#### Property Value
[System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')

<a name='BTD_Mod_Helper.BloonsMod.IDPrefix'></a>

## BloonsMod.IDPrefix Property

The prefix used for the IDs of towers, upgrades, etc for this mod to prevent conflicts with other mods

```csharp
public virtual string IDPrefix { get; }
```

#### Property Value
[System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')

<a name='BTD_Mod_Helper.BloonsMod.LatestURL'></a>

## BloonsMod.LatestURL Property

[https://github.com/gurrenm3/BTD-Mod-Helper/wiki/%5B3.0%5D-Appearing-in-the-Mod-Browser-%28ModHelperData%29](https://github.com/gurrenm3/BTD-Mod-Helper/wiki/%5B3.0%5D-Appearing-in-the-Mod-Browser-%28ModHelperData%29 'https://github.com/gurrenm3/BTD-Mod-Helper/wiki/%5B3.0%5D-Appearing-in-the-Mod-Browser-%28ModHelperData%29')

```csharp
public virtual string LatestURL { get; }
```

#### Property Value
[System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')

<a name='BTD_Mod_Helper.BloonsMod.MelonInfoCsURL'></a>

## BloonsMod.MelonInfoCsURL Property

[https://github.com/gurrenm3/BTD-Mod-Helper/wiki/%5B3.0%5D-Appearing-in-the-Mod-Browser-%28ModHelperData%29](https://github.com/gurrenm3/BTD-Mod-Helper/wiki/%5B3.0%5D-Appearing-in-the-Mod-Browser-%28ModHelperData%29 'https://github.com/gurrenm3/BTD-Mod-Helper/wiki/%5B3.0%5D-Appearing-in-the-Mod-Browser-%28ModHelperData%29')

```csharp
public virtual string MelonInfoCsURL { get; }
```

#### Property Value
[System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')

<a name='BTD_Mod_Helper.BloonsMod.ModSettings'></a>

## BloonsMod.ModSettings Property

The settings in this mod organized by name

```csharp
public System.Collections.Generic.Dictionary<string,BTD_Mod_Helper.Api.ModOptions.ModSetting> ModSettings { get; }
```

#### Property Value
[System.Collections.Generic.Dictionary&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.Dictionary-2 'System.Collections.Generic.Dictionary`2')[System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')[,](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.Dictionary-2 'System.Collections.Generic.Dictionary`2')[ModSetting](BTD_Mod_Helper.Api.ModOptions.ModSetting.md 'BTD_Mod_Helper.Api.ModOptions.ModSetting')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.Dictionary-2 'System.Collections.Generic.Dictionary`2')

<a name='BTD_Mod_Helper.BloonsMod.ModSourcesPath'></a>

## BloonsMod.ModSourcesPath Property

The path that this mod would most likely be at in the Mod Sources folder

```csharp
public string ModSourcesPath { get; }
```

#### Property Value
[System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')

<a name='BTD_Mod_Helper.BloonsMod.OptionalPatches'></a>

## BloonsMod.OptionalPatches Property

Signifies that the game shouldn't crash / the mod shouldn't stop loading if one of its patches fails

```csharp
public virtual bool OptionalPatches { get; }
```

#### Property Value
[System.Boolean](https://docs.microsoft.com/en-us/dotnet/api/System.Boolean 'System.Boolean')

<a name='BTD_Mod_Helper.BloonsMod.Resources'></a>

## BloonsMod.Resources Property

The embedded resources (textures) of this mod

```csharp
public System.Collections.Generic.Dictionary<string,byte[]> Resources { get; set; }
```

#### Property Value
[System.Collections.Generic.Dictionary&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.Dictionary-2 'System.Collections.Generic.Dictionary`2')[System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')[,](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.Dictionary-2 'System.Collections.Generic.Dictionary`2')[System.Byte](https://docs.microsoft.com/en-us/dotnet/api/System.Byte 'System.Byte')[[]](https://docs.microsoft.com/en-us/dotnet/api/System.Array 'System.Array')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.Dictionary-2 'System.Collections.Generic.Dictionary`2')
### Methods

<a name='BTD_Mod_Helper.BloonsMod.AddContent(BTD_Mod_Helper.Api.ModContent)'></a>

## BloonsMod.AddContent(ModContent) Method

Manually adds new ModContent to the mod. Does not directly call [BTD_Mod_Helper.Api.ModContent.Load](https://docs.microsoft.com/en-us/dotnet/api/BTD_Mod_Helper.Api.ModContent.Load 'BTD_Mod_Helper.Api.ModContent.Load') or  
[BTD_Mod_Helper.Api.ModContent.Register](https://docs.microsoft.com/en-us/dotnet/api/BTD_Mod_Helper.Api.ModContent.Register 'BTD_Mod_Helper.Api.ModContent.Register'), but the latter will still end up being called if this is added before the  
Registration phase.

```csharp
public void AddContent(BTD_Mod_Helper.Api.ModContent modContent);
```
#### Parameters

<a name='BTD_Mod_Helper.BloonsMod.AddContent(BTD_Mod_Helper.Api.ModContent).modContent'></a>

`modContent` [ModContent](BTD_Mod_Helper.Api.ModContent.md 'BTD_Mod_Helper.Api.ModContent')

<a name='BTD_Mod_Helper.BloonsMod.AddContent(System.Collections.Generic.IEnumerable_BTD_Mod_Helper.Api.ModContent_)'></a>

## BloonsMod.AddContent(IEnumerable<ModContent>) Method

Manually adds multiple new ModContent to the mod. Does not directly call [BTD_Mod_Helper.Api.ModContent.Load](https://docs.microsoft.com/en-us/dotnet/api/BTD_Mod_Helper.Api.ModContent.Load 'BTD_Mod_Helper.Api.ModContent.Load') or  
[BTD_Mod_Helper.Api.ModContent.Register](https://docs.microsoft.com/en-us/dotnet/api/BTD_Mod_Helper.Api.ModContent.Register 'BTD_Mod_Helper.Api.ModContent.Register'), but the latter will still end up being called if this is added before the  
Registration phase.

```csharp
public void AddContent(System.Collections.Generic.IEnumerable<BTD_Mod_Helper.Api.ModContent> modContents);
```
#### Parameters

<a name='BTD_Mod_Helper.BloonsMod.AddContent(System.Collections.Generic.IEnumerable_BTD_Mod_Helper.Api.ModContent_).modContents'></a>

`modContents` [System.Collections.Generic.IEnumerable&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.IEnumerable-1 'System.Collections.Generic.IEnumerable`1')[ModContent](BTD_Mod_Helper.Api.ModContent.md 'BTD_Mod_Helper.Api.ModContent')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.IEnumerable-1 'System.Collections.Generic.IEnumerable`1')

<a name='BTD_Mod_Helper.BloonsMod.Call(string,object[])'></a>

## BloonsMod.Call(string, object[]) Method

Allows you to define ways for other mods to interact with this mod. Other mods could do:  
  
```csharp  
ModHelper.GetMod("YourModName")?.Call("YourOperationName", ...);  
```  
to execute functionality here.  
<br/>

```csharp
public virtual object Call(string operation, params object[] parameters);
```
#### Parameters

<a name='BTD_Mod_Helper.BloonsMod.Call(string,object[]).operation'></a>

`operation` [System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')

A string for the name of the operation that another mods wants to call

<a name='BTD_Mod_Helper.BloonsMod.Call(string,object[]).parameters'></a>

`parameters` [System.Object](https://docs.microsoft.com/en-us/dotnet/api/System.Object 'System.Object')[[]](https://docs.microsoft.com/en-us/dotnet/api/System.Array 'System.Array')

The parameters that another mod has provided

#### Returns
[System.Object](https://docs.microsoft.com/en-us/dotnet/api/System.Object 'System.Object')  
A possible result of this call

<a name='BTD_Mod_Helper.BloonsMod.OnLoadSettings(JObject)'></a>

## BloonsMod.OnLoadSettings(JObject) Method

Called when the settings for your mod are loaded

```csharp
public virtual void OnLoadSettings(JObject settings);
```
#### Parameters

<a name='BTD_Mod_Helper.BloonsMod.OnLoadSettings(JObject).settings'></a>

`settings` [Newtonsoft.Json.Linq.JObject](https://docs.microsoft.com/en-us/dotnet/api/Newtonsoft.Json.Linq.JObject 'Newtonsoft.Json.Linq.JObject')

The json representation of the settings that were just loaded

<a name='BTD_Mod_Helper.BloonsMod.OnModOptionsOpened()'></a>

## BloonsMod.OnModOptionsOpened() Method

Called whenever the Mod Options Menu gets opened, after it finishes initializing

```csharp
public virtual void OnModOptionsOpened();
```

<a name='BTD_Mod_Helper.BloonsMod.OnSaveSettings(JObject)'></a>

## BloonsMod.OnSaveSettings(JObject) Method

Called when the settings for your mod are saved.

```csharp
public virtual void OnSaveSettings(JObject settings);
```
#### Parameters

<a name='BTD_Mod_Helper.BloonsMod.OnSaveSettings(JObject).settings'></a>

`settings` [Newtonsoft.Json.Linq.JObject](https://docs.microsoft.com/en-us/dotnet/api/Newtonsoft.Json.Linq.JObject 'Newtonsoft.Json.Linq.JObject')

The json representation of the settings about to be saved