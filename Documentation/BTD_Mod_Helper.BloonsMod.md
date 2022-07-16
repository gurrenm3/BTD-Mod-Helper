#### [BloonsTD6 Mod Helper](index.md 'index')
### [BTD_Mod_Helper](index.md#BTD_Mod_Helper 'BTD_Mod_Helper')

## BloonsMod Class

Expanded version of MelonMod to suit the needs of Bloons games and the Mod Helper

```csharp
public abstract class BloonsMod : MelonLoader.MelonMod,
BTD_Mod_Helper.Api.IModContent
```

Inheritance [System.Object](https://docs.microsoft.com/en-us/dotnet/api/System.Object 'System.Object') &#129106; [MelonLoader.MelonBase](https://docs.microsoft.com/en-us/dotnet/api/MelonLoader.MelonBase 'MelonLoader.MelonBase') &#129106; [MelonLoader.MelonTypeBase&lt;](https://docs.microsoft.com/en-us/dotnet/api/MelonLoader.MelonTypeBase-1 'MelonLoader.MelonTypeBase`1')[MelonLoader.MelonMod](https://docs.microsoft.com/en-us/dotnet/api/MelonLoader.MelonMod 'MelonLoader.MelonMod')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/MelonLoader.MelonTypeBase-1 'MelonLoader.MelonTypeBase`1') &#129106; [MelonLoader.MelonMod](https://docs.microsoft.com/en-us/dotnet/api/MelonLoader.MelonMod 'MelonLoader.MelonMod') &#129106; BloonsMod

Derived  
&#8627; [BloonsTD6Mod](BTD_Mod_Helper.BloonsTD6Mod.md 'BTD_Mod_Helper.BloonsTD6Mod')

Implements [IModContent](BTD_Mod_Helper.Api.IModContent.md 'BTD_Mod_Helper.Api.IModContent')
### Fields

<a name='BTD_Mod_Helper.BloonsMod.modHelperPatchAll'></a>

## BloonsMod.modHelperPatchAll Field

Lets the ModHelper control patching, allowing for individual patches to fail without the entire mod getting  
unloaded.

```csharp
internal bool modHelperPatchAll;
```

#### Field Value
[System.Boolean](https://docs.microsoft.com/en-us/dotnet/api/System.Boolean 'System.Boolean')
### Properties

<a name='BTD_Mod_Helper.BloonsMod.CheatMod'></a>

## BloonsMod.CheatMod Property

Setting this to true will prevent your BloonsMod hooks from executing if the player could get flagged for using mods at that time.  
  
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

Github API URL used to check if this mod is up to date.  
  
    For example: "https://api.github.com/repos/gurrenm3/BTD-Mod-Helper/releases"

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

Link that people should be prompted to go to when this mod is out of date.  
  
    For example: "https://github.com/gurrenm3/BTD-Mod-Helper/releases/latest"

```csharp
public virtual string LatestURL { get; }
```

#### Property Value
[System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')

<a name='BTD_Mod_Helper.BloonsMod.MelonInfoCsURL'></a>

## BloonsMod.MelonInfoCsURL Property

As an alternative to a GithubReleaseURL, a direct link to a web-hosted version of the .cs file that  
has the "MelonInfo" attribute with the version of your mod  
  
      
    For example: "https://raw.githubusercontent.com/doombubbles/BTD6-Mods/main/MegaKnowledge/Main.cs"  
  
    because the file contains  
    [assembly: MelonInfo(typeof(MegaKnowledge.Main), "Mega Knowledge", "1.0.1", "doombubbles")]

```csharp
public virtual string MelonInfoCsURL { get; }
```

#### Property Value
[System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')

<a name='BTD_Mod_Helper.BloonsMod.ModSettings'></a>

## BloonsMod.ModSettings Property

The settings in this mod organized by name

```csharp
public System.Collections.Generic.Dictionary<string,BTD_Mod_Helper.Api.ModOptions.ModSetting> ModSettings { get; set; }
```

#### Property Value
[System.Collections.Generic.Dictionary&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.Dictionary-2 'System.Collections.Generic.Dictionary`2')[System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')[,](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.Dictionary-2 'System.Collections.Generic.Dictionary`2')[ModSetting](BTD_Mod_Helper.Api.ModOptions.ModSetting.md 'BTD_Mod_Helper.Api.ModOptions.ModSetting')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.Dictionary-2 'System.Collections.Generic.Dictionary`2')

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

The embedded resources of this mod

```csharp
public System.Collections.Generic.Dictionary<string,byte[]> Resources { get; set; }
```

#### Property Value
[System.Collections.Generic.Dictionary&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.Dictionary-2 'System.Collections.Generic.Dictionary`2')[System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')[,](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.Dictionary-2 'System.Collections.Generic.Dictionary`2')[System.Byte](https://docs.microsoft.com/en-us/dotnet/api/System.Byte 'System.Byte')[[]](https://docs.microsoft.com/en-us/dotnet/api/System.Array 'System.Array')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.Dictionary-2 'System.Collections.Generic.Dictionary`2')
### Methods

<a name='BTD_Mod_Helper.BloonsMod.Call(string,object[])'></a>

## BloonsMod.Call(string, object[]) Method

Allows you to define ways for other mods to interact with this mod. Other mods could do:  
  
```csharp  
ModContent.GetMod("YourModName")?.Call("YourOperationName", ...);  
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

<a name='BTD_Mod_Helper.BloonsMod.OnApplicationStart()'></a>

## BloonsMod.OnApplicationStart() Method

Runs after the Melon has registered. This callback waits until MelonLoader has fully initialized ([MelonLoader.MelonEvents.OnApplicationStart](https://docs.microsoft.com/en-us/dotnet/api/MelonLoader.MelonEvents.OnApplicationStart 'MelonLoader.MelonEvents.OnApplicationStart')).

```csharp
public virtual void OnApplicationStart();
```

<a name='BTD_Mod_Helper.BloonsMod.OnInitialize()'></a>

## BloonsMod.OnInitialize() Method

Runs when the Melon is registered. Executed before the Melon's info is printed to the console. This callback should only be used a constructor for the Melon.  
  
Please note that this callback may run before the Support Module is loaded and before the Engine is fully initialized.  
            <br>As a result, using unhollowed assemblies and creating/getting UnityEngine Objects may not be possible and you would have to override <see cref="M:MelonLoader.MelonBase.OnLoaderInitialized"/> instead.</br>

```csharp
public virtual void OnInitialize();
```

<a name='BTD_Mod_Helper.BloonsMod.OnInitializeMelon()'></a>

## BloonsMod.OnInitializeMelon() Method

Runs when the Melon is registered. Executed before the Melon's info is printed to the console. This callback should only be used a constructor for the Melon.  
  
Please note that this callback may run before the Support Module is loaded and before the Engine is fully initialized.  
            <br>As a result, using unhollowed assemblies and creating/getting UnityEngine Objects may not be possible and you would have to override <see cref="M:MelonLoader.MelonBase.OnLoaderInitialized"/> instead.</br>

```csharp
public sealed override void OnInitializeMelon();
```

<a name='BTD_Mod_Helper.BloonsMod.OnKeyDown(UnityEngine.KeyCode)'></a>

## BloonsMod.OnKeyDown(KeyCode) Method

Called on the frame that a key starts being held  
  
Equivalent to a HarmonyPostFix on Input.GetKeyDown

```csharp
public virtual void OnKeyDown(UnityEngine.KeyCode keyCode);
```
#### Parameters

<a name='BTD_Mod_Helper.BloonsMod.OnKeyDown(UnityEngine.KeyCode).keyCode'></a>

`keyCode` [UnityEngine.KeyCode](https://docs.microsoft.com/en-us/dotnet/api/UnityEngine.KeyCode 'UnityEngine.KeyCode')

<a name='BTD_Mod_Helper.BloonsMod.OnKeyHeld(UnityEngine.KeyCode)'></a>

## BloonsMod.OnKeyHeld(KeyCode) Method

Called every frame that a key is being held   
  
Equivalent to a HarmonyPostFix on Input.GetKey

```csharp
public virtual void OnKeyHeld(UnityEngine.KeyCode keyCode);
```
#### Parameters

<a name='BTD_Mod_Helper.BloonsMod.OnKeyHeld(UnityEngine.KeyCode).keyCode'></a>

`keyCode` [UnityEngine.KeyCode](https://docs.microsoft.com/en-us/dotnet/api/UnityEngine.KeyCode 'UnityEngine.KeyCode')

<a name='BTD_Mod_Helper.BloonsMod.OnKeyUp(UnityEngine.KeyCode)'></a>

## BloonsMod.OnKeyUp(KeyCode) Method

Called on the frame that a key stops being held  
  
Equivalent to a HarmonyPostFix on Input.GetKeyUp

```csharp
public virtual void OnKeyUp(UnityEngine.KeyCode keyCode);
```
#### Parameters

<a name='BTD_Mod_Helper.BloonsMod.OnKeyUp(UnityEngine.KeyCode).keyCode'></a>

`keyCode` [UnityEngine.KeyCode](https://docs.microsoft.com/en-us/dotnet/api/UnityEngine.KeyCode 'UnityEngine.KeyCode')

<a name='BTD_Mod_Helper.BloonsMod.OnLoaderInitialized()'></a>

## BloonsMod.OnLoaderInitialized() Method

Runs after the Melon has registered. This callback waits until MelonLoader has fully initialized ([MelonLoader.MelonEvents.OnApplicationStart](https://docs.microsoft.com/en-us/dotnet/api/MelonLoader.MelonEvents.OnApplicationStart 'MelonLoader.MelonEvents.OnApplicationStart')).

```csharp
public sealed override void OnLoaderInitialized();
```

<a name='BTD_Mod_Helper.BloonsMod.OnModOptionsOpened()'></a>

## BloonsMod.OnModOptionsOpened() Method

Called whenever the Mod Options Menu gets opened, after it finishes initializing

```csharp
public virtual void OnModOptionsOpened();
```