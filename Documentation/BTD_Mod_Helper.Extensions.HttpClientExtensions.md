#### [BloonsTD6 Mod Helper](README.md 'README')
### [BTD_Mod_Helper.Extensions](README.md#BTD_Mod_Helper.Extensions 'BTD_Mod_Helper.Extensions')

## HttpClientExtensions Class

Extensions for HttpClient

```csharp
public static class HttpClientExtensions
```

Inheritance [System.Object](https://docs.microsoft.com/en-us/dotnet/api/System.Object 'System.Object') &#129106; HttpClientExtensions
### Methods

<a name='BTD_Mod_Helper.Extensions.HttpClientExtensions.GetBytesWithAuthAsync(thisSystem.Net.Http.HttpClient,string,string,System.Threading.CancellationToken)'></a>

## HttpClientExtensions.GetBytesWithAuthAsync(this HttpClient, string, string, CancellationToken) Method

Version of [System.Net.Http.HttpClient.GetByteArrayAsync(System.String,System.Threading.CancellationToken)](https://docs.microsoft.com/en-us/dotnet/api/System.Net.Http.HttpClient.GetByteArrayAsync#System_Net_Http_HttpClient_GetByteArrayAsync_System_String,System_Threading_CancellationToken_ 'System.Net.Http.HttpClient.GetByteArrayAsync(System.String,System.Threading.CancellationToken)') that passes in an auth header value

```csharp
public static System.Threading.Tasks.Task<byte[]> GetBytesWithAuthAsync(this System.Net.Http.HttpClient client, string requestUri, string auth=null, System.Threading.CancellationToken ct=default(System.Threading.CancellationToken));
```
#### Parameters

<a name='BTD_Mod_Helper.Extensions.HttpClientExtensions.GetBytesWithAuthAsync(thisSystem.Net.Http.HttpClient,string,string,System.Threading.CancellationToken).client'></a>

`client` [System.Net.Http.HttpClient](https://docs.microsoft.com/en-us/dotnet/api/System.Net.Http.HttpClient 'System.Net.Http.HttpClient')

<a name='BTD_Mod_Helper.Extensions.HttpClientExtensions.GetBytesWithAuthAsync(thisSystem.Net.Http.HttpClient,string,string,System.Threading.CancellationToken).requestUri'></a>

`requestUri` [System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')

<a name='BTD_Mod_Helper.Extensions.HttpClientExtensions.GetBytesWithAuthAsync(thisSystem.Net.Http.HttpClient,string,string,System.Threading.CancellationToken).auth'></a>

`auth` [System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')

<a name='BTD_Mod_Helper.Extensions.HttpClientExtensions.GetBytesWithAuthAsync(thisSystem.Net.Http.HttpClient,string,string,System.Threading.CancellationToken).ct'></a>

`ct` [System.Threading.CancellationToken](https://docs.microsoft.com/en-us/dotnet/api/System.Threading.CancellationToken 'System.Threading.CancellationToken')

#### Returns
[System.Threading.Tasks.Task&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Threading.Tasks.Task-1 'System.Threading.Tasks.Task`1')[System.Byte](https://docs.microsoft.com/en-us/dotnet/api/System.Byte 'System.Byte')[[]](https://docs.microsoft.com/en-us/dotnet/api/System.Array 'System.Array')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Threading.Tasks.Task-1 'System.Threading.Tasks.Task`1')

<a name='BTD_Mod_Helper.Extensions.HttpClientExtensions.GetStringWithAuthAsync(thisSystem.Net.Http.HttpClient,string,string,System.Threading.CancellationToken)'></a>

## HttpClientExtensions.GetStringWithAuthAsync(this HttpClient, string, string, CancellationToken) Method

Version of [System.Net.Http.HttpClient.GetStringAsync(System.String,System.Threading.CancellationToken)](https://docs.microsoft.com/en-us/dotnet/api/System.Net.Http.HttpClient.GetStringAsync#System_Net_Http_HttpClient_GetStringAsync_System_String,System_Threading_CancellationToken_ 'System.Net.Http.HttpClient.GetStringAsync(System.String,System.Threading.CancellationToken)') that passes in an auth header value

```csharp
public static System.Threading.Tasks.Task<string> GetStringWithAuthAsync(this System.Net.Http.HttpClient client, string requestUri, string auth=null, System.Threading.CancellationToken ct=default(System.Threading.CancellationToken));
```
#### Parameters

<a name='BTD_Mod_Helper.Extensions.HttpClientExtensions.GetStringWithAuthAsync(thisSystem.Net.Http.HttpClient,string,string,System.Threading.CancellationToken).client'></a>

`client` [System.Net.Http.HttpClient](https://docs.microsoft.com/en-us/dotnet/api/System.Net.Http.HttpClient 'System.Net.Http.HttpClient')

<a name='BTD_Mod_Helper.Extensions.HttpClientExtensions.GetStringWithAuthAsync(thisSystem.Net.Http.HttpClient,string,string,System.Threading.CancellationToken).requestUri'></a>

`requestUri` [System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')

<a name='BTD_Mod_Helper.Extensions.HttpClientExtensions.GetStringWithAuthAsync(thisSystem.Net.Http.HttpClient,string,string,System.Threading.CancellationToken).auth'></a>

`auth` [System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')

<a name='BTD_Mod_Helper.Extensions.HttpClientExtensions.GetStringWithAuthAsync(thisSystem.Net.Http.HttpClient,string,string,System.Threading.CancellationToken).ct'></a>

`ct` [System.Threading.CancellationToken](https://docs.microsoft.com/en-us/dotnet/api/System.Threading.CancellationToken 'System.Threading.CancellationToken')

#### Returns
[System.Threading.Tasks.Task&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Threading.Tasks.Task-1 'System.Threading.Tasks.Task`1')[System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Threading.Tasks.Task-1 'System.Threading.Tasks.Task`1')