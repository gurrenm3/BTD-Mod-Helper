#### [BloonsTD6 Mod Helper](index.md 'index')
### [BTD_Mod_Helper.Api](index.md#BTD_Mod_Helper.Api 'BTD_Mod_Helper.Api')

## ModHelperData Class

Class representing all the data ModHelper can utilize about a mod as separate from the MelonMod / .dll itself.  
<br/>  
This is used for getting mod information from its GitHub repo, for getting information about enabled mods even  
if they don't want to have Mod Helper as a dependency, and keeping track of info about disabled mods.

```csharp
internal class ModHelperData
```

Inheritance [System.Object](https://docs.microsoft.com/en-us/dotnet/api/System.Object 'System.Object') &#129106; ModHelperData
### Constructors

<a name='BTD_Mod_Helper.Api.ModHelperData.ModHelperData()'></a>

## ModHelperData() Constructor

Statically gets the Setters and Getters for easier accessing of the serialized fields

```csharp
static ModHelperData();
```
### Fields

<a name='BTD_Mod_Helper.Api.ModHelperData.Active'></a>

## ModHelperData.Active Field

ModHelperData for mods that are present in the Mods folder

```csharp
internal static readonly List<ModHelperData> Active;
```

#### Field Value
[System.Collections.Generic.List&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.List-1 'System.Collections.Generic.List`1')[ModHelperData](BTD_Mod_Helper.Api.ModHelperData.md 'BTD_Mod_Helper.Api.ModHelperData')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.List-1 'System.Collections.Generic.List`1')

<a name='BTD_Mod_Helper.Api.ModHelperData.Cache'></a>

## ModHelperData.Cache Field

The ModHelperData objects for currently enabled mods

```csharp
internal static readonly Dictionary<MelonMod,ModHelperData> Cache;
```

#### Field Value
[System.Collections.Generic.Dictionary&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.Dictionary-2 'System.Collections.Generic.Dictionary`2')[MelonLoader.MelonMod](https://docs.microsoft.com/en-us/dotnet/api/MelonLoader.MelonMod 'MelonLoader.MelonMod')[,](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.Dictionary-2 'System.Collections.Generic.Dictionary`2')[ModHelperData](BTD_Mod_Helper.Api.ModHelperData.md 'BTD_Mod_Helper.Api.ModHelperData')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.Dictionary-2 'System.Collections.Generic.Dictionary`2')

<a name='BTD_Mod_Helper.Api.ModHelperData.Inactive'></a>

## ModHelperData.Inactive Field

ModHelperData for mods that are in the disabled mods folder

```csharp
internal static readonly List<ModHelperData> Inactive;
```

#### Field Value
[System.Collections.Generic.List&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.List-1 'System.Collections.Generic.List`1')[ModHelperData](BTD_Mod_Helper.Api.ModHelperData.md 'BTD_Mod_Helper.Api.ModHelperData')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.List-1 'System.Collections.Generic.List`1')
### Properties

<a name='BTD_Mod_Helper.Api.ModHelperData.Enabled'></a>

## ModHelperData.Enabled Property

Whether this mod is correctly in the Enabled mods folder

```csharp
internal bool Enabled { get; }
```

#### Property Value
[System.Boolean](https://docs.microsoft.com/en-us/dotnet/api/System.Boolean 'System.Boolean')

<a name='BTD_Mod_Helper.Api.ModHelperData.FilePath'></a>

## ModHelperData.FilePath Property

The place that the .dll file for this mod is on the local machine, if any

```csharp
internal string FilePath { get; set; }
```

#### Property Value
[System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')

<a name='BTD_Mod_Helper.Api.ModHelperData.Mod'></a>

## ModHelperData.Mod Property

The currently active mod that this is associated with, if any

```csharp
internal MelonLoader.MelonMod Mod { get; }
```

#### Property Value
[MelonLoader.MelonMod](https://docs.microsoft.com/en-us/dotnet/api/MelonLoader.MelonMod 'MelonLoader.MelonMod')

<a name='BTD_Mod_Helper.Api.ModHelperData.RestartRequired'></a>

## ModHelperData.RestartRequired Property

Either a Mod's "Enabled" status is different from whether or not it's loaded into the game,  
or the data Version is ahead of the currently loaded mod's version

```csharp
internal bool RestartRequired { get; }
```

#### Property Value
[System.Boolean](https://docs.microsoft.com/en-us/dotnet/api/System.Boolean 'System.Boolean')