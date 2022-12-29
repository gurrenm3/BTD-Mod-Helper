#### [BloonsTD6 Mod Helper](README.md 'README')
### [BTD_Mod_Helper.Extensions](README.md#BTD_Mod_Helper.Extensions 'BTD_Mod_Helper.Extensions')

## ButtonExt Class

Extensions for Buttons

```csharp
public static class ButtonExt
```

Inheritance [System.Object](https://docs.microsoft.com/en-us/dotnet/api/System.Object 'System.Object') &#129106; ButtonExt
### Methods

<a name='BTD_Mod_Helper.Extensions.ButtonExt.AddOnClick(thisButton,BTD_Mod_Helper.Extensions.Function)'></a>

## ButtonExt.AddOnClick(this Button, Function) Method

Adds an onclick function to a button

```csharp
public static void AddOnClick(this Button button, BTD_Mod_Helper.Extensions.Function funcToExecute);
```
#### Parameters

<a name='BTD_Mod_Helper.Extensions.ButtonExt.AddOnClick(thisButton,BTD_Mod_Helper.Extensions.Function).button'></a>

`button` [UnityEngine.UI.Button](https://docs.microsoft.com/en-us/dotnet/api/UnityEngine.UI.Button 'UnityEngine.UI.Button')

<a name='BTD_Mod_Helper.Extensions.ButtonExt.AddOnClick(thisButton,BTD_Mod_Helper.Extensions.Function).funcToExecute'></a>

`funcToExecute` [Function()](BTD_Mod_Helper.Extensions.Function().md 'BTD_Mod_Helper.Extensions.Function()')

<a name='BTD_Mod_Helper.Extensions.ButtonExt.RemoveOnClickAction(thisButton,int)'></a>

## ButtonExt.RemoveOnClickAction(this Button, int) Method

Removes the onclick function of a button

```csharp
public static void RemoveOnClickAction(this Button button, int actionIndex);
```
#### Parameters

<a name='BTD_Mod_Helper.Extensions.ButtonExt.RemoveOnClickAction(thisButton,int).button'></a>

`button` [UnityEngine.UI.Button](https://docs.microsoft.com/en-us/dotnet/api/UnityEngine.UI.Button 'UnityEngine.UI.Button')

<a name='BTD_Mod_Helper.Extensions.ButtonExt.RemoveOnClickAction(thisButton,int).actionIndex'></a>

`actionIndex` [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/System.Int32 'System.Int32')

<a name='BTD_Mod_Helper.Extensions.ButtonExt.SetOnClick(thisButton,BTD_Mod_Helper.Extensions.Function)'></a>

## ButtonExt.SetOnClick(this Button, Function) Method

Sets the onclick function of a button

```csharp
public static void SetOnClick(this Button button, BTD_Mod_Helper.Extensions.Function funcToExecute);
```
#### Parameters

<a name='BTD_Mod_Helper.Extensions.ButtonExt.SetOnClick(thisButton,BTD_Mod_Helper.Extensions.Function).button'></a>

`button` [UnityEngine.UI.Button](https://docs.microsoft.com/en-us/dotnet/api/UnityEngine.UI.Button 'UnityEngine.UI.Button')

<a name='BTD_Mod_Helper.Extensions.ButtonExt.SetOnClick(thisButton,BTD_Mod_Helper.Extensions.Function).funcToExecute'></a>

`funcToExecute` [Function()](BTD_Mod_Helper.Extensions.Function().md 'BTD_Mod_Helper.Extensions.Function()')

<a name='BTD_Mod_Helper.Extensions.ButtonExt.SetSprite(thisButton,Sprite,string)'></a>

## ButtonExt.SetSprite(this Button, Sprite, string) Method

Set the sprite for this button.

```csharp
public static void SetSprite(this Button button, Sprite sprite, string newSpriteName="");
```
#### Parameters

<a name='BTD_Mod_Helper.Extensions.ButtonExt.SetSprite(thisButton,Sprite,string).button'></a>

`button` [UnityEngine.UI.Button](https://docs.microsoft.com/en-us/dotnet/api/UnityEngine.UI.Button 'UnityEngine.UI.Button')

<a name='BTD_Mod_Helper.Extensions.ButtonExt.SetSprite(thisButton,Sprite,string).sprite'></a>

`sprite` [UnityEngine.Sprite](https://docs.microsoft.com/en-us/dotnet/api/UnityEngine.Sprite 'UnityEngine.Sprite')

Sprite to change to

<a name='BTD_Mod_Helper.Extensions.ButtonExt.SetSprite(thisButton,Sprite,string).newSpriteName'></a>

`newSpriteName` [System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')

Optionally provide a new name for the sprite