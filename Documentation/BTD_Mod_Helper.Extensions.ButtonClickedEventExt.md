#### [BloonsTD6 Mod Helper](README.md 'README')
### [BTD_Mod_Helper.Extensions](README.md#BTD_Mod_Helper.Extensions 'BTD_Mod_Helper.Extensions')

## ButtonClickedEventExt Class

Extensions for ButtonClickedEvents

```csharp
public static class ButtonClickedEventExt
```

Inheritance [System.Object](https://docs.microsoft.com/en-us/dotnet/api/System.Object 'System.Object') &#129106; ButtonClickedEventExt
### Methods

<a name='BTD_Mod_Helper.Extensions.ButtonClickedEventExt.AddListener(thisUnityEngine.UI.Button.ButtonClickedEvent,BTD_Mod_Helper.Extensions.Function)'></a>

## ButtonClickedEventExt.AddListener(this ButtonClickedEvent, Function) Method

Adds a function to the click event

```csharp
public static void AddListener(this UnityEngine.UI.Button.ButtonClickedEvent clickEvent, BTD_Mod_Helper.Extensions.Function funcToExecute);
```
#### Parameters

<a name='BTD_Mod_Helper.Extensions.ButtonClickedEventExt.AddListener(thisUnityEngine.UI.Button.ButtonClickedEvent,BTD_Mod_Helper.Extensions.Function).clickEvent'></a>

`clickEvent` [UnityEngine.UI.Button.ButtonClickedEvent](https://docs.microsoft.com/en-us/dotnet/api/UnityEngine.UI.Button.ButtonClickedEvent 'UnityEngine.UI.Button.ButtonClickedEvent')

<a name='BTD_Mod_Helper.Extensions.ButtonClickedEventExt.AddListener(thisUnityEngine.UI.Button.ButtonClickedEvent,BTD_Mod_Helper.Extensions.Function).funcToExecute'></a>

`funcToExecute` [Function()](BTD_Mod_Helper.Extensions.Function().md 'BTD_Mod_Helper.Extensions.Function()')

<a name='BTD_Mod_Helper.Extensions.ButtonClickedEventExt.RemoveAllPersistantCalls(thisUnityEngine.UI.Button.ButtonClickedEvent)'></a>

## ButtonClickedEventExt.RemoveAllPersistantCalls(this ButtonClickedEvent) Method

Removes all specific persistent call from a click event

```csharp
public static void RemoveAllPersistantCalls(this UnityEngine.UI.Button.ButtonClickedEvent clickEvent);
```
#### Parameters

<a name='BTD_Mod_Helper.Extensions.ButtonClickedEventExt.RemoveAllPersistantCalls(thisUnityEngine.UI.Button.ButtonClickedEvent).clickEvent'></a>

`clickEvent` [UnityEngine.UI.Button.ButtonClickedEvent](https://docs.microsoft.com/en-us/dotnet/api/UnityEngine.UI.Button.ButtonClickedEvent 'UnityEngine.UI.Button.ButtonClickedEvent')

<a name='BTD_Mod_Helper.Extensions.ButtonClickedEventExt.RemovePersistantCall(thisUnityEngine.UI.Button.ButtonClickedEvent,int)'></a>

## ButtonClickedEventExt.RemovePersistantCall(this ButtonClickedEvent, int) Method

Remove a specific persistent call from a click event

```csharp
public static void RemovePersistantCall(this UnityEngine.UI.Button.ButtonClickedEvent clickEvent, int index);
```
#### Parameters

<a name='BTD_Mod_Helper.Extensions.ButtonClickedEventExt.RemovePersistantCall(thisUnityEngine.UI.Button.ButtonClickedEvent,int).clickEvent'></a>

`clickEvent` [UnityEngine.UI.Button.ButtonClickedEvent](https://docs.microsoft.com/en-us/dotnet/api/UnityEngine.UI.Button.ButtonClickedEvent 'UnityEngine.UI.Button.ButtonClickedEvent')

<a name='BTD_Mod_Helper.Extensions.ButtonClickedEventExt.RemovePersistantCall(thisUnityEngine.UI.Button.ButtonClickedEvent,int).index'></a>

`index` [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/System.Int32 'System.Int32')

<a name='BTD_Mod_Helper.Extensions.ButtonClickedEventExt.SetListener(thisUnityEngine.UI.Button.ButtonClickedEvent,BTD_Mod_Helper.Extensions.Function)'></a>

## ButtonClickedEventExt.SetListener(this ButtonClickedEvent, Function) Method

Sets a function to be the only listener of a click event

```csharp
public static void SetListener(this UnityEngine.UI.Button.ButtonClickedEvent clickEvent, BTD_Mod_Helper.Extensions.Function funcToExecute);
```
#### Parameters

<a name='BTD_Mod_Helper.Extensions.ButtonClickedEventExt.SetListener(thisUnityEngine.UI.Button.ButtonClickedEvent,BTD_Mod_Helper.Extensions.Function).clickEvent'></a>

`clickEvent` [UnityEngine.UI.Button.ButtonClickedEvent](https://docs.microsoft.com/en-us/dotnet/api/UnityEngine.UI.Button.ButtonClickedEvent 'UnityEngine.UI.Button.ButtonClickedEvent')

<a name='BTD_Mod_Helper.Extensions.ButtonClickedEventExt.SetListener(thisUnityEngine.UI.Button.ButtonClickedEvent,BTD_Mod_Helper.Extensions.Function).funcToExecute'></a>

`funcToExecute` [Function()](BTD_Mod_Helper.Extensions.Function().md 'BTD_Mod_Helper.Extensions.Function()')