#### [BloonsTD6 Mod Helper](README.md 'README')
### [BTD_Mod_Helper.Api.Components](README.md#BTD_Mod_Helper.Api.Components 'BTD_Mod_Helper.Api.Components')

## ModHelperText Class

ModHelperComponent for a background panel

```csharp
public class ModHelperText : BTD_Mod_Helper.Api.Components.ModHelperComponent
```

Inheritance [System.Object](https://docs.microsoft.com/en-us/dotnet/api/System.Object 'System.Object') &#129106; [Il2CppInterop.Runtime.InteropTypes.Il2CppObjectBase](https://docs.microsoft.com/en-us/dotnet/api/Il2CppInterop.Runtime.InteropTypes.Il2CppObjectBase 'Il2CppInterop.Runtime.InteropTypes.Il2CppObjectBase') &#129106; [Il2CppSystem.Object](https://docs.microsoft.com/en-us/dotnet/api/Il2CppSystem.Object 'Il2CppSystem.Object') &#129106; [UnityEngine.Object](https://docs.microsoft.com/en-us/dotnet/api/UnityEngine.Object 'UnityEngine.Object') &#129106; [UnityEngine.Component](https://docs.microsoft.com/en-us/dotnet/api/UnityEngine.Component 'UnityEngine.Component') &#129106; [UnityEngine.Behaviour](https://docs.microsoft.com/en-us/dotnet/api/UnityEngine.Behaviour 'UnityEngine.Behaviour') &#129106; [UnityEngine.MonoBehaviour](https://docs.microsoft.com/en-us/dotnet/api/UnityEngine.MonoBehaviour 'UnityEngine.MonoBehaviour') &#129106; [ModHelperComponent](BTD_Mod_Helper.Api.Components.ModHelperComponent.md 'BTD_Mod_Helper.Api.Components.ModHelperComponent') &#129106; ModHelperText
### Properties

<a name='BTD_Mod_Helper.Api.Components.ModHelperText.Text'></a>

## ModHelperText.Text Property

The component that handles the Text rendering

```csharp
public Il2Cpp.NK_TextMeshProUGUI Text { get; }
```

#### Property Value
[Il2Cpp.NK_TextMeshProUGUI](https://docs.microsoft.com/en-us/dotnet/api/Il2Cpp.NK_TextMeshProUGUI 'Il2Cpp.NK_TextMeshProUGUI')
### Methods

<a name='BTD_Mod_Helper.Api.Components.ModHelperText.Create(BTD_Mod_Helper.Api.Components.Info,string,float,Il2CppTMPro.TextAlignmentOptions)'></a>

## ModHelperText.Create(Info, string, float, TextAlignmentOptions) Method

Creates a new ModHelperText

```csharp
public static BTD_Mod_Helper.Api.Components.ModHelperText Create(BTD_Mod_Helper.Api.Components.Info info, string text, float fontSize=42f, Il2CppTMPro.TextAlignmentOptions align=Il2CppTMPro.TextAlignmentOptions.Midline);
```
#### Parameters

<a name='BTD_Mod_Helper.Api.Components.ModHelperText.Create(BTD_Mod_Helper.Api.Components.Info,string,float,Il2CppTMPro.TextAlignmentOptions).info'></a>

`info` [Info](BTD_Mod_Helper.Api.Components.Info.md 'BTD_Mod_Helper.Api.Components.Info')

The name/position/size info

<a name='BTD_Mod_Helper.Api.Components.ModHelperText.Create(BTD_Mod_Helper.Api.Components.Info,string,float,Il2CppTMPro.TextAlignmentOptions).text'></a>

`text` [System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')

The text to display

<a name='BTD_Mod_Helper.Api.Components.ModHelperText.Create(BTD_Mod_Helper.Api.Components.Info,string,float,Il2CppTMPro.TextAlignmentOptions).fontSize'></a>

`fontSize` [System.Single](https://docs.microsoft.com/en-us/dotnet/api/System.Single 'System.Single')

Size of font

<a name='BTD_Mod_Helper.Api.Components.ModHelperText.Create(BTD_Mod_Helper.Api.Components.Info,string,float,Il2CppTMPro.TextAlignmentOptions).align'></a>

`align` [Il2CppTMPro.TextAlignmentOptions](https://docs.microsoft.com/en-us/dotnet/api/Il2CppTMPro.TextAlignmentOptions 'Il2CppTMPro.TextAlignmentOptions')

Alignment of text

#### Returns
[ModHelperText](BTD_Mod_Helper.Api.Components.ModHelperText.md 'BTD_Mod_Helper.Api.Components.ModHelperText')  
The created ModHelperText

<a name='BTD_Mod_Helper.Api.Components.ModHelperText.SetText(string)'></a>

## ModHelperText.SetText(string) Method

Sets the text of this text to the given text

```csharp
public void SetText(string text);
```
#### Parameters

<a name='BTD_Mod_Helper.Api.Components.ModHelperText.SetText(string).text'></a>

`text` [System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')