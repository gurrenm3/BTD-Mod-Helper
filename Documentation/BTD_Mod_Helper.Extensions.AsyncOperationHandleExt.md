#### [BloonsTD6 Mod Helper](README.md 'README')
### [BTD_Mod_Helper.Extensions](README.md#BTD_Mod_Helper.Extensions 'BTD_Mod_Helper.Extensions')

## AsyncOperationHandleExt Class

Extensions for AsyncOperationHandles

```csharp
public static class AsyncOperationHandleExt
```

Inheritance [System.Object](https://docs.microsoft.com/en-us/dotnet/api/System.Object 'System.Object') &#129106; AsyncOperationHandleExt
### Methods

<a name='BTD_Mod_Helper.Extensions.AsyncOperationHandleExt.IsModded(thisAsyncOperationHandle_Sprite_,string)'></a>

## AsyncOperationHandleExt.IsModded(this AsyncOperationHandle<Sprite>, string) Method

Gets whether the AsyncOperationHandle is for a modded sprite

```csharp
public static bool IsModded(this AsyncOperationHandle<Sprite> handle, out string name);
```
#### Parameters

<a name='BTD_Mod_Helper.Extensions.AsyncOperationHandleExt.IsModded(thisAsyncOperationHandle_Sprite_,string).handle'></a>

`handle` [UnityEngine.ResourceManagement.AsyncOperations.AsyncOperationHandle](https://docs.microsoft.com/en-us/dotnet/api/UnityEngine.ResourceManagement.AsyncOperations.AsyncOperationHandle 'UnityEngine.ResourceManagement.AsyncOperations.AsyncOperationHandle')

this

<a name='BTD_Mod_Helper.Extensions.AsyncOperationHandleExt.IsModded(thisAsyncOperationHandle_Sprite_,string).name'></a>

`name` [System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')

resource name of modded sprite

#### Returns
[System.Boolean](https://docs.microsoft.com/en-us/dotnet/api/System.Boolean 'System.Boolean')  
whether it's for a modded sprite or not