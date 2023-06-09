#### [BloonsTD6 Mod Helper](README.md 'README')
### [BTD_Mod_Helper.Extensions](README.md#BTD_Mod_Helper.Extensions 'BTD_Mod_Helper.Extensions')

## BloonsTD6ModExt Class

Extensions for BloonsTD6Mods (for some reason lol)

```csharp
public static class BloonsTD6ModExt
```

Inheritance [System.Object](https://docs.microsoft.com/en-us/dotnet/api/System.Object 'System.Object') &#129106; BloonsTD6ModExt
### Methods

<a name='BTD_Mod_Helper.Extensions.BloonsTD6ModExt.GetModDirectory(thisBTD_Mod_Helper.BloonsTD6Mod,bool)'></a>

## BloonsTD6ModExt.GetModDirectory(this BloonsTD6Mod, bool) Method

Get the personal mod directory for this specific mod. Useful for keeping this mod's files seperate from other mods.  
Example: "BloonsTD6/Mods/BloonsTD6 Mod Helper/settings.txt"

```csharp
public static string GetModDirectory(this BTD_Mod_Helper.BloonsTD6Mod BloonsTD6Mod, bool createIfNotExists);
```
#### Parameters

<a name='BTD_Mod_Helper.Extensions.BloonsTD6ModExt.GetModDirectory(thisBTD_Mod_Helper.BloonsTD6Mod,bool).BloonsTD6Mod'></a>

`BloonsTD6Mod` [BloonsTD6Mod](BTD_Mod_Helper.BloonsTD6Mod.md 'BTD_Mod_Helper.BloonsTD6Mod')

<a name='BTD_Mod_Helper.Extensions.BloonsTD6ModExt.GetModDirectory(thisBTD_Mod_Helper.BloonsTD6Mod,bool).createIfNotExists'></a>

`createIfNotExists` [System.Boolean](https://docs.microsoft.com/en-us/dotnet/api/System.Boolean 'System.Boolean')

Create the mod's directory if it doesn't exist yet?

#### Returns
[System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')

<a name='BTD_Mod_Helper.Extensions.BloonsTD6ModExt.GetModDirectory(thisBTD_Mod_Helper.BloonsTD6Mod)'></a>

## BloonsTD6ModExt.GetModDirectory(this BloonsTD6Mod) Method

Get the personal mod directory for this specific mod. Useful for keeping this mod's files seperate from other mods.  
Example: "BloonsTD6/Mods/BloonsTD6 Mod Helper/settings.txt"

```csharp
public static string GetModDirectory(this BTD_Mod_Helper.BloonsTD6Mod BloonsTD6Mod);
```
#### Parameters

<a name='BTD_Mod_Helper.Extensions.BloonsTD6ModExt.GetModDirectory(thisBTD_Mod_Helper.BloonsTD6Mod).BloonsTD6Mod'></a>

`BloonsTD6Mod` [BloonsTD6Mod](BTD_Mod_Helper.BloonsTD6Mod.md 'BTD_Mod_Helper.BloonsTD6Mod')

#### Returns
[System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')

<a name='BTD_Mod_Helper.Extensions.BloonsTD6ModExt.GetModName(thisBTD_Mod_Helper.BloonsTD6Mod)'></a>

## BloonsTD6ModExt.GetModName(this BloonsTD6Mod) Method

Get the name of this mod from it's dll name

```csharp
public static string GetModName(this BTD_Mod_Helper.BloonsTD6Mod BloonsTD6Mod);
```
#### Parameters

<a name='BTD_Mod_Helper.Extensions.BloonsTD6ModExt.GetModName(thisBTD_Mod_Helper.BloonsTD6Mod).BloonsTD6Mod'></a>

`BloonsTD6Mod` [BloonsTD6Mod](BTD_Mod_Helper.BloonsTD6Mod.md 'BTD_Mod_Helper.BloonsTD6Mod')

#### Returns
[System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')

<a name='BTD_Mod_Helper.Extensions.BloonsTD6ModExt.GetModSettingsDir(thisBTD_Mod_Helper.BloonsTD6Mod,bool)'></a>

## BloonsTD6ModExt.GetModSettingsDir(this BloonsTD6Mod, bool) Method

Gets the directory where this mod's settings are or will be stored. Example: "BloonsTD6/Mods/BloonsTD6 Mod  
Helper/settings.txt"

```csharp
public static string GetModSettingsDir(this BTD_Mod_Helper.BloonsTD6Mod BloonsTD6Mod, bool createIfNotExists);
```
#### Parameters

<a name='BTD_Mod_Helper.Extensions.BloonsTD6ModExt.GetModSettingsDir(thisBTD_Mod_Helper.BloonsTD6Mod,bool).BloonsTD6Mod'></a>

`BloonsTD6Mod` [BloonsTD6Mod](BTD_Mod_Helper.BloonsTD6Mod.md 'BTD_Mod_Helper.BloonsTD6Mod')

<a name='BTD_Mod_Helper.Extensions.BloonsTD6ModExt.GetModSettingsDir(thisBTD_Mod_Helper.BloonsTD6Mod,bool).createIfNotExists'></a>

`createIfNotExists` [System.Boolean](https://docs.microsoft.com/en-us/dotnet/api/System.Boolean 'System.Boolean')

Create the mod's directory if it doesn't exist yet?

#### Returns
[System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')

<a name='BTD_Mod_Helper.Extensions.BloonsTD6ModExt.GetModSettingsDir(thisBTD_Mod_Helper.BloonsTD6Mod)'></a>

## BloonsTD6ModExt.GetModSettingsDir(this BloonsTD6Mod) Method

Gets the directory where this mod's settings are or will be stored. Example: "BloonsTD6/Mods/BloonsTD6 Mod  
Helper/settings.txt"

```csharp
public static string GetModSettingsDir(this BTD_Mod_Helper.BloonsTD6Mod BloonsTD6Mod);
```
#### Parameters

<a name='BTD_Mod_Helper.Extensions.BloonsTD6ModExt.GetModSettingsDir(thisBTD_Mod_Helper.BloonsTD6Mod).BloonsTD6Mod'></a>

`BloonsTD6Mod` [BloonsTD6Mod](BTD_Mod_Helper.BloonsTD6Mod.md 'BTD_Mod_Helper.BloonsTD6Mod')

#### Returns
[System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')