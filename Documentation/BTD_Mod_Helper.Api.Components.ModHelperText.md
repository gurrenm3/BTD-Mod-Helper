#### [BloonsTD6 Mod Helper](README.md 'README')
### [BTD_Mod_Helper.Api.Components](README.md#BTD_Mod_Helper.Api.Components 'BTD_Mod_Helper.Api.Components')

## ModHelperText Class

ModHelperComponent for a background panel

```csharp
public class ModHelperText : BTD_Mod_Helper.Api.Components.ModHelperComponent
```

Inheritance [UnityEngine.MonoBehaviour](https://docs.microsoft.com/en-us/dotnet/api/UnityEngine.MonoBehaviour 'UnityEngine.MonoBehaviour') &#129106; [ModHelperComponent](BTD_Mod_Helper.Api.Components.ModHelperComponent.md 'BTD_Mod_Helper.Api.Components.ModHelperComponent') &#129106; ModHelperText
### Properties

<a name='BTD_Mod_Helper.Api.Components.ModHelperText.Text'></a>

## ModHelperText.Text Property

The component that handles the Text rendering

```csharp
public NK_TextMeshProUGUI Text { get; }
```

#### Property Value
[Il2Cpp.NK_TextMeshProUGUI](https://docs.microsoft.com/en-us/dotnet/api/Il2Cpp.NK_TextMeshProUGUI 'Il2Cpp.NK_TextMeshProUGUI')
### Methods

<a name='BTD_Mod_Helper.Api.Components.ModHelperText.Create(BTD_Mod_Helper.Api.Components.Info,string,float,TextAlignmentOptions)'></a>

## ModHelperText.Create(Info, string, float, TextAlignmentOptions) Method

Creates a new ModHelperText

```csharp
public static BTD_Mod_Helper.Api.Components.ModHelperText Create(BTD_Mod_Helper.Api.Components.Info info, string text, float fontSize=42f, TextAlignmentOptions align=4098);
```
#### Parameters

<a name='BTD_Mod_Helper.Api.Components.ModHelperText.Create(BTD_Mod_Helper.Api.Components.Info,string,float,TextAlignmentOptions).info'></a>

`info` [Info](BTD_Mod_Helper.Api.Components.Info.md 'BTD_Mod_Helper.Api.Components.Info')

The name/position/size info

<a name='BTD_Mod_Helper.Api.Components.ModHelperText.Create(BTD_Mod_Helper.Api.Components.Info,string,float,TextAlignmentOptions).text'></a>

`text` [System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')

The text to display

<a name='BTD_Mod_Helper.Api.Components.ModHelperText.Create(BTD_Mod_Helper.Api.Components.Info,string,float,TextAlignmentOptions).fontSize'></a>

`fontSize` [System.Single](https://docs.microsoft.com/en-us/dotnet/api/System.Single 'System.Single')

Size of font

<a name='BTD_Mod_Helper.Api.Components.ModHelperText.Create(BTD_Mod_Helper.Api.Components.Info,string,float,TextAlignmentOptions).align'></a>

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