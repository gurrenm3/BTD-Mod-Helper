#### [BloonsTD6 Mod Helper](README.md 'README')
### [BTD_Mod_Helper.Api.Helpers](README.md#BTD_Mod_Helper.Api.Helpers 'BTD_Mod_Helper.Api.Helpers')

## ProcessHelper Class

Helper methods for processes

```csharp
public static class ProcessHelper
```

Inheritance [System.Object](https://docs.microsoft.com/en-us/dotnet/api/System.Object 'System.Object') &#129106; ProcessHelper
### Methods

<a name='BTD_Mod_Helper.Api.Helpers.ProcessHelper.OpenURL(string)'></a>

## ProcessHelper.OpenURL(string) Method

Opens a url in the default browser

```csharp
public static void OpenURL(string url);
```
#### Parameters

<a name='BTD_Mod_Helper.Api.Helpers.ProcessHelper.OpenURL(string).url'></a>

`url` [System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')

URL to open

<a name='BTD_Mod_Helper.Api.Helpers.ProcessHelper.RestartGame()'></a>

## ProcessHelper.RestartGame() Method

Exits the game and starts a new process after waiting 10 seconds, to ensure no "Another instance is already running" errors

```csharp
public static void RestartGame();
```