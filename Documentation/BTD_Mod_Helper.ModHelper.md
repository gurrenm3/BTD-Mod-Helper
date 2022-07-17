#### [BloonsTD6 Mod Helper](README.md 'README')
### [BTD_Mod_Helper](README.md#BTD_Mod_Helper 'BTD_Mod_Helper')

## ModHelper Class

Catch-all class for non-extension static methods

```csharp
public static class ModHelper
```

Inheritance [System.Object](https://docs.microsoft.com/en-us/dotnet/api/System.Object 'System.Object') &#129106; ModHelper
### Properties

<a name='BTD_Mod_Helper.ModHelper.DisabledModsDirectory'></a>

## ModHelper.DisabledModsDirectory Property

Directory for where disabled mods are stored

```csharp
public static string DisabledModsDirectory { get; }
```

#### Property Value
[System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')

<a name='BTD_Mod_Helper.ModHelper.Melons'></a>

## ModHelper.Melons Property

All active mods, whether they're Mod Helper or not

```csharp
public static System.Collections.Generic.IEnumerable<MelonLoader.MelonMod> Melons { get; }
```

#### Property Value
[System.Collections.Generic.IEnumerable&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.IEnumerable-1 'System.Collections.Generic.IEnumerable`1')[MelonLoader.MelonMod](https://docs.microsoft.com/en-us/dotnet/api/MelonLoader.MelonMod 'MelonLoader.MelonMod')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.IEnumerable-1 'System.Collections.Generic.IEnumerable`1')

<a name='BTD_Mod_Helper.ModHelper.ModHelperDirectory'></a>

## ModHelper.ModHelperDirectory Property

Directory where the Mod Helper stores most of its extra info

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