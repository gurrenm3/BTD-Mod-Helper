#### [BloonsTD6 Mod Helper](README.md 'README')
### [BTD_Mod_Helper.Extensions](README.md#BTD_Mod_Helper.Extensions 'BTD_Mod_Helper.Extensions')

## FileInfoExt Class

Extensions for FileInfo

```csharp
public static class FileInfoExt
```

Inheritance [System.Object](https://docs.microsoft.com/en-us/dotnet/api/System.Object 'System.Object') &#129106; FileInfoExt
### Methods

<a name='BTD_Mod_Helper.Extensions.FileInfoExt.GetAllReferences(thisSystem.IO.FileInfo)'></a>

## FileInfoExt.GetAllReferences(this FileInfo) Method

Get all Assembly References from this FileInfo. Returns null if there are none

```csharp
public static System.Reflection.AssemblyName[] GetAllReferences(this System.IO.FileInfo fileInfo);
```
#### Parameters

<a name='BTD_Mod_Helper.Extensions.FileInfoExt.GetAllReferences(thisSystem.IO.FileInfo).fileInfo'></a>

`fileInfo` [System.IO.FileInfo](https://docs.microsoft.com/en-us/dotnet/api/System.IO.FileInfo 'System.IO.FileInfo')

#### Returns
[System.Reflection.AssemblyName](https://docs.microsoft.com/en-us/dotnet/api/System.Reflection.AssemblyName 'System.Reflection.AssemblyName')[[]](https://docs.microsoft.com/en-us/dotnet/api/System.Array 'System.Array')

<a name='BTD_Mod_Helper.Extensions.FileInfoExt.IsMelonMod(thisSystem.IO.FileInfo)'></a>

## FileInfoExt.IsMelonMod(this FileInfo) Method

Returns whether or not this File has a reference to the newer MelonLoader.dll or the older MelonLoader.ModHandler.dll

```csharp
public static bool IsMelonMod(this System.IO.FileInfo fileInfo);
```
#### Parameters

<a name='BTD_Mod_Helper.Extensions.FileInfoExt.IsMelonMod(thisSystem.IO.FileInfo).fileInfo'></a>

`fileInfo` [System.IO.FileInfo](https://docs.microsoft.com/en-us/dotnet/api/System.IO.FileInfo 'System.IO.FileInfo')

#### Returns
[System.Boolean](https://docs.microsoft.com/en-us/dotnet/api/System.Boolean 'System.Boolean')

<a name='BTD_Mod_Helper.Extensions.FileInfoExt.IsNewerMelonMod(thisSystem.IO.FileInfo)'></a>

## FileInfoExt.IsNewerMelonMod(this FileInfo) Method

Returns whether or not this File has a reference to the newer MelonLoader.dll (For MelonLoader 3.0 and up)

```csharp
public static bool IsNewerMelonMod(this System.IO.FileInfo fileInfo);
```
#### Parameters

<a name='BTD_Mod_Helper.Extensions.FileInfoExt.IsNewerMelonMod(thisSystem.IO.FileInfo).fileInfo'></a>

`fileInfo` [System.IO.FileInfo](https://docs.microsoft.com/en-us/dotnet/api/System.IO.FileInfo 'System.IO.FileInfo')

#### Returns
[System.Boolean](https://docs.microsoft.com/en-us/dotnet/api/System.Boolean 'System.Boolean')

<a name='BTD_Mod_Helper.Extensions.FileInfoExt.IsOlderMelonMod(thisSystem.IO.FileInfo)'></a>

## FileInfoExt.IsOlderMelonMod(this FileInfo) Method

Returns whether or not this File has a reference to the older MelonLoader.ModHandler.dll (For MelonLoader 2.7.4 and below)

```csharp
public static bool IsOlderMelonMod(this System.IO.FileInfo fileInfo);
```
#### Parameters

<a name='BTD_Mod_Helper.Extensions.FileInfoExt.IsOlderMelonMod(thisSystem.IO.FileInfo).fileInfo'></a>

`fileInfo` [System.IO.FileInfo](https://docs.microsoft.com/en-us/dotnet/api/System.IO.FileInfo 'System.IO.FileInfo')

#### Returns
[System.Boolean](https://docs.microsoft.com/en-us/dotnet/api/System.Boolean 'System.Boolean')