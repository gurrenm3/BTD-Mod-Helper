#### [BloonsTD6 Mod Helper](README.md 'README')
### [BTD_Mod_Helper.Api.Helpers](README.md#BTD_Mod_Helper.Api.Helpers 'BTD_Mod_Helper.Api.Helpers')

## ProcessHelper Class

Helper methods for processes

```csharp
public static class ProcessHelper
```

Inheritance [System.Object](https://docs.microsoft.com/en-us/dotnet/api/System.Object 'System.Object') &#129106; ProcessHelper
### Methods

<a name='BTD_Mod_Helper.Api.Helpers.ProcessHelper.OpenFile(string)'></a>

## ProcessHelper.OpenFile(string) Method

Opens a file in the default app for it

```csharp
public static void OpenFile(string filePath);
```
#### Parameters

<a name='BTD_Mod_Helper.Api.Helpers.ProcessHelper.OpenFile(string).filePath'></a>

`filePath` [System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')

File path

<a name='BTD_Mod_Helper.Api.Helpers.ProcessHelper.OpenFolder(string)'></a>

## ProcessHelper.OpenFolder(string) Method

Opens a folder in the file explorer

```csharp
public static void OpenFolder(string folderPath);
```
#### Parameters

<a name='BTD_Mod_Helper.Api.Helpers.ProcessHelper.OpenFolder(string).folderPath'></a>

`folderPath` [System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')

Folder to open

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

Exits the game and starts a new process after waiting 10 seconds, to ensure no "Another instance is already running"  
errors

```csharp
public static void RestartGame();
```