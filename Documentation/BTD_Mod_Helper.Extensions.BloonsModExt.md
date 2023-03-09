#### [BloonsTD6 Mod Helper](README.md 'README')
### [BTD_Mod_Helper.Extensions](README.md#BTD_Mod_Helper.Extensions 'BTD_Mod_Helper.Extensions')

## BloonsModExt Class

Extensions for BloonsMods (for some reason lol)

```csharp
public static class BloonsModExt
```

Inheritance [System.Object](https://docs.microsoft.com/en-us/dotnet/api/System.Object 'System.Object') &#129106; BloonsModExt
### Methods

<a name='BTD_Mod_Helper.Extensions.BloonsModExt.GetModDirectory(thisBTD_Mod_Helper.BloonsMod,bool)'></a>

## BloonsModExt.GetModDirectory(this BloonsMod, bool) Method

Get the personal mod directory for this specific mod. Useful for keeping this mod's files seperate from other mods. Example: "BloonsTD6/Mods/BloonsTD6 Mod Helper/settings.txt"

```csharp
public static string GetModDirectory(this BTD_Mod_Helper.BloonsMod bloonsMod, bool createIfNotExists);
```
#### Parameters

<a name='BTD_Mod_Helper.Extensions.BloonsModExt.GetModDirectory(thisBTD_Mod_Helper.BloonsMod,bool).bloonsMod'></a>

`bloonsMod` [BloonsMod](BTD_Mod_Helper.BloonsMod.md 'BTD_Mod_Helper.BloonsMod')

<a name='BTD_Mod_Helper.Extensions.BloonsModExt.GetModDirectory(thisBTD_Mod_Helper.BloonsMod,bool).createIfNotExists'></a>

`createIfNotExists` [System.Boolean](https://docs.microsoft.com/en-us/dotnet/api/System.Boolean 'System.Boolean')

Create the mod's directory if it doesn't exist yet?

#### Returns
[System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')

<a name='BTD_Mod_Helper.Extensions.BloonsModExt.GetModDirectory(thisBTD_Mod_Helper.BloonsMod)'></a>

## BloonsModExt.GetModDirectory(this BloonsMod) Method

Get the personal mod directory for this specific mod. Useful for keeping this mod's files seperate from other mods. Example: "BloonsTD6/Mods/BloonsTD6 Mod Helper/settings.txt"

```csharp
public static string GetModDirectory(this BTD_Mod_Helper.BloonsMod bloonsMod);
```
#### Parameters

<a name='BTD_Mod_Helper.Extensions.BloonsModExt.GetModDirectory(thisBTD_Mod_Helper.BloonsMod).bloonsMod'></a>

`bloonsMod` [BloonsMod](BTD_Mod_Helper.BloonsMod.md 'BTD_Mod_Helper.BloonsMod')

#### Returns
[System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')

<a name='BTD_Mod_Helper.Extensions.BloonsModExt.GetModName(thisBTD_Mod_Helper.BloonsMod)'></a>

## BloonsModExt.GetModName(this BloonsMod) Method

Get the name of this mod from it's dll name

```csharp
public static string GetModName(this BTD_Mod_Helper.BloonsMod bloonsMod);
```
#### Parameters

<a name='BTD_Mod_Helper.Extensions.BloonsModExt.GetModName(thisBTD_Mod_Helper.BloonsMod).bloonsMod'></a>

`bloonsMod` [BloonsMod](BTD_Mod_Helper.BloonsMod.md 'BTD_Mod_Helper.BloonsMod')

#### Returns
[System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')

<a name='BTD_Mod_Helper.Extensions.BloonsModExt.GetModSettingsDir(thisBTD_Mod_Helper.BloonsMod,bool)'></a>

## BloonsModExt.GetModSettingsDir(this BloonsMod, bool) Method

Gets the directory where this mod's settings are or will be stored. Example: "BloonsTD6/Mods/BloonsTD6 Mod Helper/settings.txt"

```csharp
public static string GetModSettingsDir(this BTD_Mod_Helper.BloonsMod bloonsMod, bool createIfNotExists);
```
#### Parameters

<a name='BTD_Mod_Helper.Extensions.BloonsModExt.GetModSettingsDir(thisBTD_Mod_Helper.BloonsMod,bool).bloonsMod'></a>

`bloonsMod` [BloonsMod](BTD_Mod_Helper.BloonsMod.md 'BTD_Mod_Helper.BloonsMod')

<a name='BTD_Mod_Helper.Extensions.BloonsModExt.GetModSettingsDir(thisBTD_Mod_Helper.BloonsMod,bool).createIfNotExists'></a>

`createIfNotExists` [System.Boolean](https://docs.microsoft.com/en-us/dotnet/api/System.Boolean 'System.Boolean')

Create the mod's directory if it doesn't exist yet?

#### Returns
[System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')

<a name='BTD_Mod_Helper.Extensions.BloonsModExt.GetModSettingsDir(thisBTD_Mod_Helper.BloonsMod)'></a>

## BloonsModExt.GetModSettingsDir(this BloonsMod) Method

Gets the directory where this mod's settings are or will be stored. Example: "BloonsTD6/Mods/BloonsTD6 Mod Helper/settings.txt"

```csharp
public static string GetModSettingsDir(this BTD_Mod_Helper.BloonsMod bloonsMod);
```
#### Parameters

<a name='BTD_Mod_Helper.Extensions.BloonsModExt.GetModSettingsDir(thisBTD_Mod_Helper.BloonsMod).bloonsMod'></a>

`bloonsMod` [BloonsMod](BTD_Mod_Helper.BloonsMod.md 'BTD_Mod_Helper.BloonsMod')

#### Returns
[System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')