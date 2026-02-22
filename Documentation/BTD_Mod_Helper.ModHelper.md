#### [BloonsTD6 Mod Helper](README.md 'README')
### [BTD_Mod_Helper](README.md#BTD_Mod_Helper 'BTD_Mod_Helper')

## ModHelper Class

Catch-all class for non-extension static methods and accessors, as well as the ModHelperData for this mod

```csharp
public static class ModHelper
```

Inheritance [System.Object](https://docs.microsoft.com/en-us/dotnet/api/System.Object 'System.Object') &#129106; ModHelper
### Fields

<a name='BTD_Mod_Helper.ModHelper.CompiledVersion'></a>

## ModHelper.CompiledVersion Field

The version of Mod Helper that this mod was compiled with

```csharp
public const string CompiledVersion = "3.5.8";
```

#### Field Value
[System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')
### Properties

<a name='BTD_Mod_Helper.ModHelper.DisabledModsDirectory'></a>

## ModHelper.DisabledModsDirectory Property

Directory where disabled mods are stored

```csharp
public static string DisabledModsDirectory { get; }
```

#### Property Value
[System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')

<a name='BTD_Mod_Helper.ModHelper.InstalledVersion'></a>

## ModHelper.InstalledVersion Property

The current installed version of Mod Helper

```csharp
public static string InstalledVersion { get; }
```

#### Property Value
[System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')

<a name='BTD_Mod_Helper.ModHelper.IsEpic'></a>

## ModHelper.IsEpic Property

Gets whether the game is running as the Epic Store version

```csharp
public static bool IsEpic { get; }
```

#### Property Value
[System.Boolean](https://docs.microsoft.com/en-us/dotnet/api/System.Boolean 'System.Boolean')

<a name='BTD_Mod_Helper.ModHelper.IsNet6'></a>

## ModHelper.IsNet6 Property

Gets whether this is running on net6 MelonLoader

```csharp
public static bool IsNet6 { get; }
```

#### Property Value
[System.Boolean](https://docs.microsoft.com/en-us/dotnet/api/System.Boolean 'System.Boolean')

<a name='BTD_Mod_Helper.ModHelper.Melons'></a>

## ModHelper.Melons Property

All active mods, whether they're Mod Helper or not

```csharp
public static System.Collections.Generic.IEnumerable<MelonMod> Melons { get; }
```

#### Property Value
[System.Collections.Generic.IEnumerable&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.IEnumerable-1 'System.Collections.Generic.IEnumerable`1')[MelonLoader.MelonMod](https://docs.microsoft.com/en-us/dotnet/api/MelonLoader.MelonMod 'MelonLoader.MelonMod')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.IEnumerable-1 'System.Collections.Generic.IEnumerable`1')

<a name='BTD_Mod_Helper.ModHelper.Mod'></a>

## ModHelper.Mod Property

ModHelper's BloonsTD6 mod class

```csharp
public static BTD_Mod_Helper.BloonsTD6Mod Mod { get; }
```

#### Property Value
[BloonsTD6Mod](BTD_Mod_Helper.BloonsTD6Mod.md 'BTD_Mod_Helper.BloonsTD6Mod')

<a name='BTD_Mod_Helper.ModHelper.ModHelperDirectory'></a>

## ModHelper.ModHelperDirectory Property

Directory where Mod Helper stores most of its extra info

```csharp
public static string ModHelperDirectory { get; }
```

#### Property Value
[System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')

<a name='BTD_Mod_Helper.ModHelper.Mods'></a>

## ModHelper.Mods Property

Active mods that use ModHelper functionality

```csharp
public static System.Collections.Generic.IEnumerable<BTD_Mod_Helper.BloonsMod> Mods { get; }
```

#### Property Value
[System.Collections.Generic.IEnumerable&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.IEnumerable-1 'System.Collections.Generic.IEnumerable`1')[BloonsMod](BTD_Mod_Helper.BloonsMod.md 'BTD_Mod_Helper.BloonsMod')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.IEnumerable-1 'System.Collections.Generic.IEnumerable`1')

<a name='BTD_Mod_Helper.ModHelper.ModSourcesDirectory'></a>

## ModHelper.ModSourcesDirectory Property

The directory path on the user's system that's set as their Mod Sources folder

```csharp
public static string ModSourcesDirectory { get; }
```

#### Property Value
[System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')
### Methods

<a name='BTD_Mod_Helper.ModHelper.Error_T_(object)'></a>

## ModHelper.Error<T>(object) Method

Logs an error from the specified Mod's LoggerInstance

```csharp
public static void Error<T>(object obj)
    where T : BTD_Mod_Helper.BloonsMod;
```
#### Type parameters

<a name='BTD_Mod_Helper.ModHelper.Error_T_(object).T'></a>

`T`
#### Parameters

<a name='BTD_Mod_Helper.ModHelper.Error_T_(object).obj'></a>

`obj` [System.Object](https://docs.microsoft.com/en-us/dotnet/api/System.Object 'System.Object')

<a name='BTD_Mod_Helper.ModHelper.GetMod(string)'></a>

## ModHelper.GetMod(string) Method

Gets a BloonsTD6Mod by its name, or returns null if none are loaded with that name  
<br/>  
In this case a mod's name is its Assembly Name, which is almost always the same as the file name, but for the  
Mod Helper due to compatibility reasons it is "BloonsTD6 Mod Helper" rather than "Btd6ModHelper"

```csharp
public static BTD_Mod_Helper.BloonsMod GetMod(string name);
```
#### Parameters

<a name='BTD_Mod_Helper.ModHelper.GetMod(string).name'></a>

`name` [System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')

#### Returns
[BloonsMod](BTD_Mod_Helper.BloonsMod.md 'BTD_Mod_Helper.BloonsMod')

<a name='BTD_Mod_Helper.ModHelper.GetMod_T_()'></a>

## ModHelper.GetMod<T>() Method

Gets the instance of a specific BloonsTD6Mod by its type

```csharp
public static T GetMod<T>()
    where T : BTD_Mod_Helper.BloonsMod;
```
#### Type parameters

<a name='BTD_Mod_Helper.ModHelper.GetMod_T_().T'></a>

`T`

#### Returns
[T](BTD_Mod_Helper.ModHelper.md#BTD_Mod_Helper.ModHelper.GetMod_T_().T 'BTD_Mod_Helper.ModHelper.GetMod<T>().T')

<a name='BTD_Mod_Helper.ModHelper.HasMod(string,BTD_Mod_Helper.BloonsMod)'></a>

## ModHelper.HasMod(string, BloonsMod) Method

Returns whether a mod with the given name is installed, and pass it to the out param if it is

```csharp
public static bool HasMod(string name, out BTD_Mod_Helper.BloonsMod bloonsMod);
```
#### Parameters

<a name='BTD_Mod_Helper.ModHelper.HasMod(string,BTD_Mod_Helper.BloonsMod).name'></a>

`name` [System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')

<a name='BTD_Mod_Helper.ModHelper.HasMod(string,BTD_Mod_Helper.BloonsMod).bloonsMod'></a>

`bloonsMod` [BloonsMod](BTD_Mod_Helper.BloonsMod.md 'BTD_Mod_Helper.BloonsMod')

#### Returns
[System.Boolean](https://docs.microsoft.com/en-us/dotnet/api/System.Boolean 'System.Boolean')

<a name='BTD_Mod_Helper.ModHelper.HasMod(string)'></a>

## ModHelper.HasMod(string) Method

Returns whether a mod with the given name is installed

```csharp
public static bool HasMod(string name);
```
#### Parameters

<a name='BTD_Mod_Helper.ModHelper.HasMod(string).name'></a>

`name` [System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')

#### Returns
[System.Boolean](https://docs.microsoft.com/en-us/dotnet/api/System.Boolean 'System.Boolean')

<a name='BTD_Mod_Helper.ModHelper.Log_T_(object)'></a>

## ModHelper.Log<T>(object) Method

Logs a message from the specified Mod's LoggerInstance

```csharp
public static void Log<T>(object obj)
    where T : BTD_Mod_Helper.BloonsMod;
```
#### Type parameters

<a name='BTD_Mod_Helper.ModHelper.Log_T_(object).T'></a>

`T`
#### Parameters

<a name='BTD_Mod_Helper.ModHelper.Log_T_(object).obj'></a>

`obj` [System.Object](https://docs.microsoft.com/en-us/dotnet/api/System.Object 'System.Object')

<a name='BTD_Mod_Helper.ModHelper.Msg_T_(object)'></a>

## ModHelper.Msg<T>(object) Method

Logs a message from the specified Mod's LoggerInstance

```csharp
public static void Msg<T>(object obj)
    where T : BTD_Mod_Helper.BloonsMod;
```
#### Type parameters

<a name='BTD_Mod_Helper.ModHelper.Msg_T_(object).T'></a>

`T`
#### Parameters

<a name='BTD_Mod_Helper.ModHelper.Msg_T_(object).obj'></a>

`obj` [System.Object](https://docs.microsoft.com/en-us/dotnet/api/System.Object 'System.Object')

<a name='BTD_Mod_Helper.ModHelper.Warning_T_(object)'></a>

## ModHelper.Warning<T>(object) Method

Logs a warning from the specified Mod's LoggerInstance

```csharp
public static void Warning<T>(object obj)
    where T : BTD_Mod_Helper.BloonsMod;
```
#### Type parameters

<a name='BTD_Mod_Helper.ModHelper.Warning_T_(object).T'></a>

`T`
#### Parameters

<a name='BTD_Mod_Helper.ModHelper.Warning_T_(object).obj'></a>

`obj` [System.Object](https://docs.microsoft.com/en-us/dotnet/api/System.Object 'System.Object')