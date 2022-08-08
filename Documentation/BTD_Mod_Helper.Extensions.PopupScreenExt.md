#### [BloonsTD6 Mod Helper](README.md 'README')
### [BTD_Mod_Helper.Extensions](README.md#BTD_Mod_Helper.Extensions 'BTD_Mod_Helper.Extensions')

## PopupScreenExt Class

Extensions for PopupScreen

```csharp
public static class PopupScreenExt
```

Inheritance [System.Object](https://docs.microsoft.com/en-us/dotnet/api/System.Object 'System.Object') &#129106; PopupScreenExt
### Methods

<a name='BTD_Mod_Helper.Extensions.PopupScreenExt.GetBodyText(thisAssets.Scripts.Unity.UI_New.Popups.PopupScreen)'></a>

## PopupScreenExt.GetBodyText(this PopupScreen) Method

Gets the NK_TextMeshProUGUI of the ActivePopup, or null

```csharp
public static global::NK_TextMeshProUGUI GetBodyText(this Assets.Scripts.Unity.UI_New.Popups.PopupScreen popupScreen);
```
#### Parameters

<a name='BTD_Mod_Helper.Extensions.PopupScreenExt.GetBodyText(thisAssets.Scripts.Unity.UI_New.Popups.PopupScreen).popupScreen'></a>

`popupScreen` [Assets.Scripts.Unity.UI_New.Popups.PopupScreen](https://docs.microsoft.com/en-us/dotnet/api/Assets.Scripts.Unity.UI_New.Popups.PopupScreen 'Assets.Scripts.Unity.UI_New.Popups.PopupScreen')

#### Returns
[NK_TextMeshProUGUI](https://docs.microsoft.com/en-us/dotnet/api/NK_TextMeshProUGUI 'NK_TextMeshProUGUI')

<a name='BTD_Mod_Helper.Extensions.PopupScreenExt.GetTMP_InputField(thisAssets.Scripts.Unity.UI_New.Popups.PopupScreen)'></a>

## PopupScreenExt.GetTMP_InputField(this PopupScreen) Method

Gets the InputField of the ActivePopup, or null

```csharp
public static TMPro.TMP_InputField GetTMP_InputField(this Assets.Scripts.Unity.UI_New.Popups.PopupScreen popupScreen);
```
#### Parameters

<a name='BTD_Mod_Helper.Extensions.PopupScreenExt.GetTMP_InputField(thisAssets.Scripts.Unity.UI_New.Popups.PopupScreen).popupScreen'></a>

`popupScreen` [Assets.Scripts.Unity.UI_New.Popups.PopupScreen](https://docs.microsoft.com/en-us/dotnet/api/Assets.Scripts.Unity.UI_New.Popups.PopupScreen 'Assets.Scripts.Unity.UI_New.Popups.PopupScreen')

#### Returns
[TMPro.TMP_InputField](https://docs.microsoft.com/en-us/dotnet/api/TMPro.TMP_InputField 'TMPro.TMP_InputField')

<a name='BTD_Mod_Helper.Extensions.PopupScreenExt.ModifyBodyText(thisAssets.Scripts.Unity.UI_New.Popups.PopupScreen,System.Action_global__NK_TextMeshProUGUI_)'></a>

## PopupScreenExt.ModifyBodyText(this PopupScreen, Action<NK_TextMeshProUGUI>) Method

Modifies the TMP InputField of the most recently created popup

```csharp
public static void ModifyBodyText(this Assets.Scripts.Unity.UI_New.Popups.PopupScreen popupScreen, System.Action<global::NK_TextMeshProUGUI> func);
```
#### Parameters

<a name='BTD_Mod_Helper.Extensions.PopupScreenExt.ModifyBodyText(thisAssets.Scripts.Unity.UI_New.Popups.PopupScreen,System.Action_global__NK_TextMeshProUGUI_).popupScreen'></a>

`popupScreen` [Assets.Scripts.Unity.UI_New.Popups.PopupScreen](https://docs.microsoft.com/en-us/dotnet/api/Assets.Scripts.Unity.UI_New.Popups.PopupScreen 'Assets.Scripts.Unity.UI_New.Popups.PopupScreen')

<a name='BTD_Mod_Helper.Extensions.PopupScreenExt.ModifyBodyText(thisAssets.Scripts.Unity.UI_New.Popups.PopupScreen,System.Action_global__NK_TextMeshProUGUI_).func'></a>

`func` [System.Action&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Action-1 'System.Action`1')[NK_TextMeshProUGUI](https://docs.microsoft.com/en-us/dotnet/api/NK_TextMeshProUGUI 'NK_TextMeshProUGUI')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Action-1 'System.Action`1')

<a name='BTD_Mod_Helper.Extensions.PopupScreenExt.ModifyField(thisAssets.Scripts.Unity.UI_New.Popups.PopupScreen,System.Action_TMPro.TMP_InputField_)'></a>

## PopupScreenExt.ModifyField(this PopupScreen, Action<TMP_InputField>) Method

Modifies the NK_TextMeshProUGUI of the most recently created popup

```csharp
public static void ModifyField(this Assets.Scripts.Unity.UI_New.Popups.PopupScreen popupScreen, System.Action<TMPro.TMP_InputField> func);
```
#### Parameters

<a name='BTD_Mod_Helper.Extensions.PopupScreenExt.ModifyField(thisAssets.Scripts.Unity.UI_New.Popups.PopupScreen,System.Action_TMPro.TMP_InputField_).popupScreen'></a>

`popupScreen` [Assets.Scripts.Unity.UI_New.Popups.PopupScreen](https://docs.microsoft.com/en-us/dotnet/api/Assets.Scripts.Unity.UI_New.Popups.PopupScreen 'Assets.Scripts.Unity.UI_New.Popups.PopupScreen')

<a name='BTD_Mod_Helper.Extensions.PopupScreenExt.ModifyField(thisAssets.Scripts.Unity.UI_New.Popups.PopupScreen,System.Action_TMPro.TMP_InputField_).func'></a>

`func` [System.Action&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Action-1 'System.Action`1')[TMPro.TMP_InputField](https://docs.microsoft.com/en-us/dotnet/api/TMPro.TMP_InputField 'TMPro.TMP_InputField')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Action-1 'System.Action`1')

<a name='BTD_Mod_Helper.Extensions.PopupScreenExt.SafelyQueue(thisAssets.Scripts.Unity.UI_New.Popups.PopupScreen,System.Action_Assets.Scripts.Unity.UI_New.Popups.PopupScreen_)'></a>

## PopupScreenExt.SafelyQueue(this PopupScreen, Action<PopupScreen>) Method

Since a recent BTD6 update, trying to show a popup while there already is one can cause a game crash. This method  
safely queues a popup for once there aren't any already active

```csharp
public static void SafelyQueue(this Assets.Scripts.Unity.UI_New.Popups.PopupScreen popupScreen, System.Action<Assets.Scripts.Unity.UI_New.Popups.PopupScreen> action);
```
#### Parameters

<a name='BTD_Mod_Helper.Extensions.PopupScreenExt.SafelyQueue(thisAssets.Scripts.Unity.UI_New.Popups.PopupScreen,System.Action_Assets.Scripts.Unity.UI_New.Popups.PopupScreen_).popupScreen'></a>

`popupScreen` [Assets.Scripts.Unity.UI_New.Popups.PopupScreen](https://docs.microsoft.com/en-us/dotnet/api/Assets.Scripts.Unity.UI_New.Popups.PopupScreen 'Assets.Scripts.Unity.UI_New.Popups.PopupScreen')

<a name='BTD_Mod_Helper.Extensions.PopupScreenExt.SafelyQueue(thisAssets.Scripts.Unity.UI_New.Popups.PopupScreen,System.Action_Assets.Scripts.Unity.UI_New.Popups.PopupScreen_).action'></a>

`action` [System.Action&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Action-1 'System.Action`1')[Assets.Scripts.Unity.UI_New.Popups.PopupScreen](https://docs.microsoft.com/en-us/dotnet/api/Assets.Scripts.Unity.UI_New.Popups.PopupScreen 'Assets.Scripts.Unity.UI_New.Popups.PopupScreen')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Action-1 'System.Action`1')