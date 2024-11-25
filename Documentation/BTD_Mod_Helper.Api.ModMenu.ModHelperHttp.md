#### [BloonsTD6 Mod Helper](README.md 'README')
### [BTD_Mod_Helper.Api.ModMenu](README.md#BTD_Mod_Helper.Api.ModMenu 'BTD_Mod_Helper.Api.ModMenu')

## ModHelperHttp Class

Http client used by the mod helper

```csharp
public class ModHelperHttp
```

Inheritance [System.Object](https://docs.microsoft.com/en-us/dotnet/api/System.Object 'System.Object') &#129106; ModHelperHttp
### Properties

<a name='BTD_Mod_Helper.Api.ModMenu.ModHelperHttp.Client'></a>

## ModHelperHttp.Client Property

The HttpClient instance

```csharp
public static System.Net.Http.HttpClient Client { get; set; }
```

#### Property Value
[System.Net.Http.HttpClient](https://docs.microsoft.com/en-us/dotnet/api/System.Net.Http.HttpClient 'System.Net.Http.HttpClient')
### Methods

<a name='BTD_Mod_Helper.Api.ModMenu.ModHelperHttp.DownloadFile(string,string)'></a>

## ModHelperHttp.DownloadFile(string, string) Method

Asynchronously downloads from a url to the given file path, returning whether the operation was successful

```csharp
public static System.Threading.Tasks.Task<bool> DownloadFile(string url, string filePath);
```
#### Parameters

<a name='BTD_Mod_Helper.Api.ModMenu.ModHelperHttp.DownloadFile(string,string).url'></a>

`url` [System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')

URL to download from

<a name='BTD_Mod_Helper.Api.ModMenu.ModHelperHttp.DownloadFile(string,string).filePath'></a>

`filePath` [System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')

File path for the resulting file

#### Returns
[System.Threading.Tasks.Task&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Threading.Tasks.Task-1 'System.Threading.Tasks.Task`1')[System.Boolean](https://docs.microsoft.com/en-us/dotnet/api/System.Boolean 'System.Boolean')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Threading.Tasks.Task-1 'System.Threading.Tasks.Task`1')  
Whether it was successful

<a name='BTD_Mod_Helper.Api.ModMenu.ModHelperHttp.DownloadZip(string,string)'></a>

## ModHelperHttp.DownloadZip(string, string) Method

Downloads and extracts the contents of a zip file into the Zip Temp directory, returning the file paths  
of the extracted files

```csharp
public static System.Threading.Tasks.Task<System.IO.DirectoryInfo> DownloadZip(string url, string path=null);
```
#### Parameters

<a name='BTD_Mod_Helper.Api.ModMenu.ModHelperHttp.DownloadZip(string,string).url'></a>

`url` [System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')

URL to download from

<a name='BTD_Mod_Helper.Api.ModMenu.ModHelperHttp.DownloadZip(string,string).path'></a>

`path` [System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')

Path to unzip into, or null for using the zip temp directory

#### Returns
[System.Threading.Tasks.Task&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Threading.Tasks.Task-1 'System.Threading.Tasks.Task`1')[System.IO.DirectoryInfo](https://docs.microsoft.com/en-us/dotnet/api/System.IO.DirectoryInfo 'System.IO.DirectoryInfo')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Threading.Tasks.Task-1 'System.Threading.Tasks.Task`1')  
Enumeration of extracted file paths, or null

<a name='BTD_Mod_Helper.Api.ModMenu.ModHelperHttp.GetZip(string)'></a>

## ModHelperHttp.GetZip(string) Method

Downloads a zip file directly into a zip archive

```csharp
public static System.Threading.Tasks.Task<System.IO.Compression.ZipArchive> GetZip(string url);
```
#### Parameters

<a name='BTD_Mod_Helper.Api.ModMenu.ModHelperHttp.GetZip(string).url'></a>

`url` [System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')

#### Returns
[System.Threading.Tasks.Task&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Threading.Tasks.Task-1 'System.Threading.Tasks.Task`1')[System.IO.Compression.ZipArchive](https://docs.microsoft.com/en-us/dotnet/api/System.IO.Compression.ZipArchive 'System.IO.Compression.ZipArchive')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Threading.Tasks.Task-1 'System.Threading.Tasks.Task`1')