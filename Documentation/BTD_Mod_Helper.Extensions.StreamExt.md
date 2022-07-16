#### [BloonsTD6 Mod Helper](README.md 'README')
### [BTD_Mod_Helper.Extensions](README.md#BTD_Mod_Helper.Extensions 'BTD_Mod_Helper.Extensions')

## StreamExt Class

Extensions for streams

```csharp
public static class StreamExt
```

Inheritance [System.Object](https://docs.microsoft.com/en-us/dotnet/api/System.Object 'System.Object') &#129106; StreamExt
### Methods

<a name='BTD_Mod_Helper.Extensions.StreamExt.GetByteArray(thisSystem.IO.Stream)'></a>

## StreamExt.GetByteArray(this Stream) Method

Synchronously gets the full array of bytes from any stream, disposing with the Stream afterwards

```csharp
public static byte[] GetByteArray(this System.IO.Stream stream);
```
#### Parameters

<a name='BTD_Mod_Helper.Extensions.StreamExt.GetByteArray(thisSystem.IO.Stream).stream'></a>

`stream` [System.IO.Stream](https://docs.microsoft.com/en-us/dotnet/api/System.IO.Stream 'System.IO.Stream')

#### Returns
[System.Byte](https://docs.microsoft.com/en-us/dotnet/api/System.Byte 'System.Byte')[[]](https://docs.microsoft.com/en-us/dotnet/api/System.Array 'System.Array')