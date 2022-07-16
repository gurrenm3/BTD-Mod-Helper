#### [BloonsTD6 Mod Helper](index.md 'index')
### [BTD_Mod_Helper.Extensions](index.md#BTD_Mod_Helper.Extensions 'BTD_Mod_Helper.Extensions')

## DirectoryInfoExt Class

Extensions for DirectoryInfo

```csharp
public static class DirectoryInfoExt
```

Inheritance [System.Object](https://docs.microsoft.com/en-us/dotnet/api/System.Object 'System.Object') &#129106; DirectoryInfoExt
### Methods

<a name='BTD_Mod_Helper.Extensions.DirectoryInfoExt.GetAllMelonMods(thisSystem.IO.DirectoryInfo)'></a>

## DirectoryInfoExt.GetAllMelonMods(this DirectoryInfo) Method

(Cross-Game compatible) Returns all Files in this directory that reference MelonLoader.dll or MelonLoader.ModHandler.dll

```csharp
public static System.IO.FileInfo[] GetAllMelonMods(this System.IO.DirectoryInfo directoryInfo);
```
#### Parameters

<a name='BTD_Mod_Helper.Extensions.DirectoryInfoExt.GetAllMelonMods(thisSystem.IO.DirectoryInfo).directoryInfo'></a>

`directoryInfo` [System.IO.DirectoryInfo](https://docs.microsoft.com/en-us/dotnet/api/System.IO.DirectoryInfo 'System.IO.DirectoryInfo')

#### Returns
[System.IO.FileInfo](https://docs.microsoft.com/en-us/dotnet/api/System.IO.FileInfo 'System.IO.FileInfo')[[]](https://docs.microsoft.com/en-us/dotnet/api/System.Array 'System.Array')