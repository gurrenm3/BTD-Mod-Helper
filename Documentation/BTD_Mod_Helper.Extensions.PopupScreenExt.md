#### [BloonsTD6 Mod Helper](README.md 'README')
### [BTD_Mod_Helper.Extensions](README.md#BTD_Mod_Helper.Extensions 'BTD_Mod_Helper.Extensions')

## PopupScreenExt Class

Extensions for PopupScreen

```csharp
public static class PopupScreenExt
```

Inheritance [System.Object](https://docs.microsoft.com/en-us/dotnet/api/System.Object 'System.Object') &#129106; PopupScreenExt
### Methods

<a name='BTD_Mod_Helper.Extensions.PopupScreenExt.GetBodyText(thisPopupScreen)'></a>

## PopupScreenExt.GetBodyText(this PopupScreen) Method

Gets the NK_TextMeshProUGUI of the ActivePopup, or null

```csharp
public static NK_TextMeshProUGUI GetBodyText(this PopupScreen popupScreen);
```
#### Parameters

<a name='BTD_Mod_Helper.Extensions.PopupScreenExt.GetBodyText(thisPopupScreen).popupScreen'></a>

`popupScreen` [Il2CppAssets.Scripts.Unity.UI_New.Popups.PopupScreen](https://docs.microsoft.com/en-us/dotnet/api/Il2CppAssets.Scripts.Unity.UI_New.Popups.PopupScreen 'Il2CppAssets.Scripts.Unity.UI_New.Popups.PopupScreen')

#### Returns
[Il2Cpp.NK_TextMeshProUGUI](https://docs.microsoft.com/en-us/dotnet/api/Il2Cpp.NK_TextMeshProUGUI 'Il2Cpp.NK_TextMeshProUGUI')

<a name='BTD_Mod_Helper.Extensions.PopupScreenExt.GetTMP_InputField(thisPopupScreen)'></a>

## PopupScreenExt.GetTMP_InputField(this PopupScreen) Method

Gets the InputField of the ActivePopup, or null

```csharp
public static TMP_InputField GetTMP_InputField(this PopupScreen popupScreen);
```
#### Parameters

<a name='BTD_Mod_Helper.Extensions.PopupScreenExt.GetTMP_InputField(thisPopupScreen).popupScreen'></a>

`popupScreen` [Il2CppAssets.Scripts.Unity.UI_New.Popups.PopupScreen](https://docs.microsoft.com/en-us/dotnet/api/Il2CppAssets.Scripts.Unity.UI_New.Popups.PopupScreen 'Il2CppAssets.Scripts.Unity.UI_New.Popups.PopupScreen')

#### Returns
[Il2CppTMPro.TMP_InputField](https://docs.microsoft.com/en-us/dotnet/api/Il2CppTMPro.TMP_InputField 'Il2CppTMPro.TMP_InputField')

<a name='BTD_Mod_Helper.Extensions.PopupScreenExt.ModifyBodyText(thisPopupScreen,System.Action_NK_TextMeshProUGUI_)'></a>

## PopupScreenExt.ModifyBodyText(this PopupScreen, Action<NK_TextMeshProUGUI>) Method

Modifies the TMP InputField of the most recently created popup

```csharp
public static void ModifyBodyText(this PopupScreen popupScreen, System.Action<NK_TextMeshProUGUI> func);
```
#### Parameters

<a name='BTD_Mod_Helper.Extensions.PopupScreenExt.ModifyBodyText(thisPopupScreen,System.Action_NK_TextMeshProUGUI_).popupScreen'></a>

`popupScreen` [Il2CppAssets.Scripts.Unity.UI_New.Popups.PopupScreen](https://docs.microsoft.com/en-us/dotnet/api/Il2CppAssets.Scripts.Unity.UI_New.Popups.PopupScreen 'Il2CppAssets.Scripts.Unity.UI_New.Popups.PopupScreen')

<a name='BTD_Mod_Helper.Extensions.PopupScreenExt.ModifyBodyText(thisPopupScreen,System.Action_NK_TextMeshProUGUI_).func'></a>

`func` [System.Action&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Action-1 'System.Action`1')[Il2Cpp.NK_TextMeshProUGUI](https://docs.microsoft.com/en-us/dotnet/api/Il2Cpp.NK_TextMeshProUGUI 'Il2Cpp.NK_TextMeshProUGUI')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Action-1 'System.Action`1')

<a name='BTD_Mod_Helper.Extensions.PopupScreenExt.ModifyField(thisPopupScreen,System.Action_TMP_InputField_)'></a>

## PopupScreenExt.ModifyField(this PopupScreen, Action<TMP_InputField>) Method

Modifies the NK_TextMeshProUGUI of the most recently created popup

```csharp
public static void ModifyField(this PopupScreen popupScreen, System.Action<TMP_InputField> func);
```
#### Parameters

<a name='BTD_Mod_Helper.Extensions.PopupScreenExt.ModifyField(thisPopupScreen,System.Action_TMP_InputField_).popupScreen'></a>

`popupScreen` [Il2CppAssets.Scripts.Unity.UI_New.Popups.PopupScreen](https://docs.microsoft.com/en-us/dotnet/api/Il2CppAssets.Scripts.Unity.UI_New.Popups.PopupScreen 'Il2CppAssets.Scripts.Unity.UI_New.Popups.PopupScreen')

<a name='BTD_Mod_Helper.Extensions.PopupScreenExt.ModifyField(thisPopupScreen,System.Action_TMP_InputField_).func'></a>

`func` [System.Action&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Action-1 'System.Action`1')[Il2CppTMPro.TMP_InputField](https://docs.microsoft.com/en-us/dotnet/api/Il2CppTMPro.TMP_InputField 'Il2CppTMPro.TMP_InputField')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Action-1 'System.Action`1')

<a name='BTD_Mod_Helper.Extensions.PopupScreenExt.SafelyQueue(thisPopupScreen,System.Action_PopupScreen_)'></a>

## PopupScreenExt.SafelyQueue(this PopupScreen, Action<PopupScreen>) Method

Since a recent BTD6 update, trying to show a popup while there already is one can cause a game crash. This method  
safely queues a popup for once there aren't any already active

```csharp
public static void SafelyQueue(this PopupScreen popupScreen, System.Action<PopupScreen> action);
```
#### Parameters

<a name='BTD_Mod_Helper.Extensions.PopupScreenExt.SafelyQueue(thisPopupScreen,System.Action_PopupScreen_).popupScreen'></a>

`popupScreen` [Il2CppAssets.Scripts.Unity.UI_New.Popups.PopupScreen](https://docs.microsoft.com/en-us/dotnet/api/Il2CppAssets.Scripts.Unity.UI_New.Popups.PopupScreen 'Il2CppAssets.Scripts.Unity.UI_New.Popups.PopupScreen')

<a name='BTD_Mod_Helper.Extensions.PopupScreenExt.SafelyQueue(thisPopupScreen,System.Action_PopupScreen_).action'></a>

`action` [System.Action&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Action-1 'System.Action`1')[Il2CppAssets.Scripts.Unity.UI_New.Popups.PopupScreen](https://docs.microsoft.com/en-us/dotnet/api/Il2CppAssets.Scripts.Unity.UI_New.Popups.PopupScreen 'Il2CppAssets.Scripts.Unity.UI_New.Popups.PopupScreen')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Action-1 'System.Action`1')