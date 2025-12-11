#### [BloonsTD6 Mod Helper](README.md 'README')
### [BTD_Mod_Helper.Extensions](README.md#BTD_Mod_Helper.Extensions 'BTD_Mod_Helper.Extensions')

## KeyCodeExt Class

Extension methods for keycodes

```csharp
public static class KeyCodeExt
```

Inheritance [System.Object](https://docs.microsoft.com/en-us/dotnet/api/System.Object 'System.Object') &#129106; KeyCodeExt
### Methods

<a name='BTD_Mod_Helper.Extensions.KeyCodeExt.GetKeyCode(thisstring)'></a>

## KeyCodeExt.GetKeyCode(this string) Method

Gets the Key code for a given path string

```csharp
public static KeyCode GetKeyCode(this string path);
```
#### Parameters

<a name='BTD_Mod_Helper.Extensions.KeyCodeExt.GetKeyCode(thisstring).path'></a>

`path` [System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')

#### Returns
[UnityEngine.KeyCode](https://docs.microsoft.com/en-us/dotnet/api/UnityEngine.KeyCode 'UnityEngine.KeyCode')

<a name='BTD_Mod_Helper.Extensions.KeyCodeExt.GetPath(thisKeyCode)'></a>

## KeyCodeExt.GetPath(this KeyCode) Method

Gets the path string for the given key code

```csharp
public static string GetPath(this KeyCode keyCode);
```
#### Parameters

<a name='BTD_Mod_Helper.Extensions.KeyCodeExt.GetPath(thisKeyCode).keyCode'></a>

`keyCode` [UnityEngine.KeyCode](https://docs.microsoft.com/en-us/dotnet/api/UnityEngine.KeyCode 'UnityEngine.KeyCode')

#### Returns
[System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')