#### [BloonsTD6 Mod Helper](index.md 'index')
### [BTD_Mod_Helper.Extensions](index.md#BTD_Mod_Helper.Extensions 'BTD_Mod_Helper.Extensions')

## ButtonExt Class

Extensions for Buttons

```csharp
public static class ButtonExt
```

Inheritance [System.Object](https://docs.microsoft.com/en-us/dotnet/api/System.Object 'System.Object') &#129106; ButtonExt
### Methods

<a name='BTD_Mod_Helper.Extensions.ButtonExt.AddOnClick(thisUnityEngine.UI.Button,BTD_Mod_Helper.Extensions.Function)'></a>

## ButtonExt.AddOnClick(this Button, Function) Method

Adds an onclick function to a button

```csharp
public static void AddOnClick(this UnityEngine.UI.Button button, BTD_Mod_Helper.Extensions.Function funcToExecute);
```
#### Parameters

<a name='BTD_Mod_Helper.Extensions.ButtonExt.AddOnClick(thisUnityEngine.UI.Button,BTD_Mod_Helper.Extensions.Function).button'></a>

`button` [UnityEngine.UI.Button](https://docs.microsoft.com/en-us/dotnet/api/UnityEngine.UI.Button 'UnityEngine.UI.Button')

<a name='BTD_Mod_Helper.Extensions.ButtonExt.AddOnClick(thisUnityEngine.UI.Button,BTD_Mod_Helper.Extensions.Function).funcToExecute'></a>

`funcToExecute` [Function()](BTD_Mod_Helper.Extensions.Function().md 'BTD_Mod_Helper.Extensions.Function()')

<a name='BTD_Mod_Helper.Extensions.ButtonExt.RemoveOnClickAction(thisUnityEngine.UI.Button,int)'></a>

## ButtonExt.RemoveOnClickAction(this Button, int) Method

Removes the onclick function of a button

```csharp
public static void RemoveOnClickAction(this UnityEngine.UI.Button button, int actionIndex);
```
#### Parameters

<a name='BTD_Mod_Helper.Extensions.ButtonExt.RemoveOnClickAction(thisUnityEngine.UI.Button,int).button'></a>

`button` [UnityEngine.UI.Button](https://docs.microsoft.com/en-us/dotnet/api/UnityEngine.UI.Button 'UnityEngine.UI.Button')

<a name='BTD_Mod_Helper.Extensions.ButtonExt.RemoveOnClickAction(thisUnityEngine.UI.Button,int).actionIndex'></a>

`actionIndex` [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/System.Int32 'System.Int32')

<a name='BTD_Mod_Helper.Extensions.ButtonExt.SetOnClick(thisUnityEngine.UI.Button,BTD_Mod_Helper.Extensions.Function)'></a>

## ButtonExt.SetOnClick(this Button, Function) Method

Sets the onclick function of a button

```csharp
public static void SetOnClick(this UnityEngine.UI.Button button, BTD_Mod_Helper.Extensions.Function funcToExecute);
```
#### Parameters

<a name='BTD_Mod_Helper.Extensions.ButtonExt.SetOnClick(thisUnityEngine.UI.Button,BTD_Mod_Helper.Extensions.Function).button'></a>

`button` [UnityEngine.UI.Button](https://docs.microsoft.com/en-us/dotnet/api/UnityEngine.UI.Button 'UnityEngine.UI.Button')

<a name='BTD_Mod_Helper.Extensions.ButtonExt.SetOnClick(thisUnityEngine.UI.Button,BTD_Mod_Helper.Extensions.Function).funcToExecute'></a>

`funcToExecute` [Function()](BTD_Mod_Helper.Extensions.Function().md 'BTD_Mod_Helper.Extensions.Function()')

<a name='BTD_Mod_Helper.Extensions.ButtonExt.SetSprite(thisUnityEngine.UI.Button,UnityEngine.Sprite,string)'></a>

## ButtonExt.SetSprite(this Button, Sprite, string) Method

Set the sprite for this button.

```csharp
public static void SetSprite(this UnityEngine.UI.Button button, UnityEngine.Sprite sprite, string newSpriteName="");
```
#### Parameters

<a name='BTD_Mod_Helper.Extensions.ButtonExt.SetSprite(thisUnityEngine.UI.Button,UnityEngine.Sprite,string).button'></a>

`button` [UnityEngine.UI.Button](https://docs.microsoft.com/en-us/dotnet/api/UnityEngine.UI.Button 'UnityEngine.UI.Button')

<a name='BTD_Mod_Helper.Extensions.ButtonExt.SetSprite(thisUnityEngine.UI.Button,UnityEngine.Sprite,string).sprite'></a>

`sprite` [UnityEngine.Sprite](https://docs.microsoft.com/en-us/dotnet/api/UnityEngine.Sprite 'UnityEngine.Sprite')

Sprite to change to

<a name='BTD_Mod_Helper.Extensions.ButtonExt.SetSprite(thisUnityEngine.UI.Button,UnityEngine.Sprite,string).newSpriteName'></a>

`newSpriteName` [System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')

Optionally provide a new name for the sprite