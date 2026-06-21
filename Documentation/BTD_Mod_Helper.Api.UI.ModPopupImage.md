#### [BloonsTD6 Mod Helper](README.md 'README')
### [BTD_Mod_Helper.Api.UI](README.md#BTD_Mod_Helper.Api.UI 'BTD_Mod_Helper.Api.UI')

## ModPopupImage Class

Registers an image that can be used within hint / event popups

```csharp
public abstract class ModPopupImage : BTD_Mod_Helper.Api.ModContent
```

Inheritance [System.Object](https://docs.microsoft.com/en-us/dotnet/api/System.Object 'System.Object') &#129106; [ModContent](BTD_Mod_Helper.Api.ModContent.md 'BTD_Mod_Helper.Api.ModContent') &#129106; ModPopupImage
### Properties

<a name='BTD_Mod_Helper.Api.UI.ModPopupImage.Image'></a>

## ModPopupImage.Image Property

The Image to use  
<br/>  
(Name of .png or .jpg, not including file extension)

```csharp
public virtual string Image { get; }
```

#### Property Value
[System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')

<a name='BTD_Mod_Helper.Api.UI.ModPopupImage.ImageReference'></a>

## ModPopupImage.ImageReference Property

If you're not going to use a custom .png for your Image, use this to directly control its SpriteReference

```csharp
public virtual SpriteReference ImageReference { get; }
```

#### Property Value
[Il2CppNinjaKiwi.Common.ResourceUtils.SpriteReference](https://docs.microsoft.com/en-us/dotnet/api/Il2CppNinjaKiwi.Common.ResourceUtils.SpriteReference 'Il2CppNinjaKiwi.Common.ResourceUtils.SpriteReference')

<a name='BTD_Mod_Helper.Api.UI.ModPopupImage.Index'></a>

## ModPopupImage.Index Property

What should be passed in to methods like [Il2CppAssets.Scripts.Unity.UI_New.Popups.PopupScreen.QueueHint(System.Int32,System.String,System.Int32,System.Boolean,System.Boolean,System.Int32,Il2CppAssets.Scripts.Unity.UI_New.Popups.PopupScreen.ReturnCallback)](https://docs.microsoft.com/en-us/dotnet/api/Il2CppAssets.Scripts.Unity.UI_New.Popups.PopupScreen.QueueHint#Il2CppAssets_Scripts_Unity_UI_New_Popups_PopupScreen_QueueHint_System_Int32,System_String,System_Int32,System_Boolean,System_Boolean,System_Int32,Il2CppAssets_Scripts_Unity_UI_New_Popups_PopupScreen_ReturnCallback_ 'Il2CppAssets.Scripts.Unity.UI_New.Popups.PopupScreen.QueueHint(System.Int32,System.String,System.Int32,System.Boolean,System.Boolean,System.Int32,Il2CppAssets.Scripts.Unity.UI_New.Popups.PopupScreen.ReturnCallback)') and [Il2CppAssets.Scripts.Unity.UI_New.Popups.PopupScreen.ShowEventPopup(Il2CppAssets.Scripts.Unity.UI_New.Popups.PopupScreen.Placement,System.String,System.String,System.String,Il2CppAssets.Scripts.Unity.UI_New.Popups.PopupScreen.ReturnCallback,System.String,Il2CppAssets.Scripts.Unity.UI_New.Popups.PopupScreen.ReturnCallback,Il2CppAssets.Scripts.Unity.UI_New.Popups.Popup.TransitionAnim,System.Int32,Il2CppAssets.Scripts.Unity.UI_New.Popups.PopupScreen.BackGround,UnityEngine.Sprite)](https://docs.microsoft.com/en-us/dotnet/api/Il2CppAssets.Scripts.Unity.UI_New.Popups.PopupScreen.ShowEventPopup#Il2CppAssets_Scripts_Unity_UI_New_Popups_PopupScreen_ShowEventPopup_Il2CppAssets_Scripts_Unity_UI_New_Popups_PopupScreen_Placement,System_String,System_String,System_String,Il2CppAssets_Scripts_Unity_UI_New_Popups_PopupScreen_ReturnCallback,System_String,Il2CppAssets_Scripts_Unity_UI_New_Popups_PopupScreen_ReturnCallback,Il2CppAssets_Scripts_Unity_UI_New_Popups_Popup_TransitionAnim,System_Int32,Il2CppAssets_Scripts_Unity_UI_New_Popups_PopupScreen_BackGround,UnityEngine_Sprite_ 'Il2CppAssets.Scripts.Unity.UI_New.Popups.PopupScreen.ShowEventPopup(Il2CppAssets.Scripts.Unity.UI_New.Popups.PopupScreen.Placement,System.String,System.String,System.String,Il2CppAssets.Scripts.Unity.UI_New.Popups.PopupScreen.ReturnCallback,System.String,Il2CppAssets.Scripts.Unity.UI_New.Popups.PopupScreen.ReturnCallback,Il2CppAssets.Scripts.Unity.UI_New.Popups.Popup.TransitionAnim,System.Int32,Il2CppAssets.Scripts.Unity.UI_New.Popups.PopupScreen.BackGround,UnityEngine.Sprite)')

```csharp
public int Index { get; set; }
```

#### Property Value
[System.Int32](https://docs.microsoft.com/en-us/dotnet/api/System.Int32 'System.Int32')
### Operators

<a name='BTD_Mod_Helper.Api.UI.ModPopupImage.op_Implicitint(BTD_Mod_Helper.Api.UI.ModPopupImage)'></a>

## ModPopupImage.implicit operator int(ModPopupImage) Operator

What should be passed in to methods like [Il2CppAssets.Scripts.Unity.UI_New.Popups.PopupScreen.QueueHint(System.Int32,System.String,System.Int32,System.Boolean,System.Boolean,System.Int32,Il2CppAssets.Scripts.Unity.UI_New.Popups.PopupScreen.ReturnCallback)](https://docs.microsoft.com/en-us/dotnet/api/Il2CppAssets.Scripts.Unity.UI_New.Popups.PopupScreen.QueueHint#Il2CppAssets_Scripts_Unity_UI_New_Popups_PopupScreen_QueueHint_System_Int32,System_String,System_Int32,System_Boolean,System_Boolean,System_Int32,Il2CppAssets_Scripts_Unity_UI_New_Popups_PopupScreen_ReturnCallback_ 'Il2CppAssets.Scripts.Unity.UI_New.Popups.PopupScreen.QueueHint(System.Int32,System.String,System.Int32,System.Boolean,System.Boolean,System.Int32,Il2CppAssets.Scripts.Unity.UI_New.Popups.PopupScreen.ReturnCallback)') and [Il2CppAssets.Scripts.Unity.UI_New.Popups.PopupScreen.ShowEventPopup(Il2CppAssets.Scripts.Unity.UI_New.Popups.PopupScreen.Placement,System.String,System.String,System.String,Il2CppAssets.Scripts.Unity.UI_New.Popups.PopupScreen.ReturnCallback,System.String,Il2CppAssets.Scripts.Unity.UI_New.Popups.PopupScreen.ReturnCallback,Il2CppAssets.Scripts.Unity.UI_New.Popups.Popup.TransitionAnim,System.Int32,Il2CppAssets.Scripts.Unity.UI_New.Popups.PopupScreen.BackGround,UnityEngine.Sprite)](https://docs.microsoft.com/en-us/dotnet/api/Il2CppAssets.Scripts.Unity.UI_New.Popups.PopupScreen.ShowEventPopup#Il2CppAssets_Scripts_Unity_UI_New_Popups_PopupScreen_ShowEventPopup_Il2CppAssets_Scripts_Unity_UI_New_Popups_PopupScreen_Placement,System_String,System_String,System_String,Il2CppAssets_Scripts_Unity_UI_New_Popups_PopupScreen_ReturnCallback,System_String,Il2CppAssets_Scripts_Unity_UI_New_Popups_PopupScreen_ReturnCallback,Il2CppAssets_Scripts_Unity_UI_New_Popups_Popup_TransitionAnim,System_Int32,Il2CppAssets_Scripts_Unity_UI_New_Popups_PopupScreen_BackGround,UnityEngine_Sprite_ 'Il2CppAssets.Scripts.Unity.UI_New.Popups.PopupScreen.ShowEventPopup(Il2CppAssets.Scripts.Unity.UI_New.Popups.PopupScreen.Placement,System.String,System.String,System.String,Il2CppAssets.Scripts.Unity.UI_New.Popups.PopupScreen.ReturnCallback,System.String,Il2CppAssets.Scripts.Unity.UI_New.Popups.PopupScreen.ReturnCallback,Il2CppAssets.Scripts.Unity.UI_New.Popups.Popup.TransitionAnim,System.Int32,Il2CppAssets.Scripts.Unity.UI_New.Popups.PopupScreen.BackGround,UnityEngine.Sprite)')

```csharp
public static int implicit operator int(BTD_Mod_Helper.Api.UI.ModPopupImage image);
```
#### Parameters

<a name='BTD_Mod_Helper.Api.UI.ModPopupImage.op_Implicitint(BTD_Mod_Helper.Api.UI.ModPopupImage).image'></a>

`image` [ModPopupImage](BTD_Mod_Helper.Api.UI.ModPopupImage.md 'BTD_Mod_Helper.Api.UI.ModPopupImage')

#### Returns
[System.Int32](https://docs.microsoft.com/en-us/dotnet/api/System.Int32 'System.Int32')