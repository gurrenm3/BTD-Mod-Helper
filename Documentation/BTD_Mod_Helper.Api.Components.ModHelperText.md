#### [BloonsTD6 Mod Helper](README.md 'README')
### [BTD_Mod_Helper.Api.Components](README.md#BTD_Mod_Helper.Api.Components 'BTD_Mod_Helper.Api.Components')

## ModHelperText Class

ModHelperComponent for a background panel

```csharp
public class ModHelperText : BTD_Mod_Helper.Api.Components.ModHelperComponent
```

Inheritance [UnityEngine.MonoBehaviour](https://docs.microsoft.com/en-us/dotnet/api/UnityEngine.MonoBehaviour 'UnityEngine.MonoBehaviour') &#129106; [ModHelperComponent](BTD_Mod_Helper.Api.Components.ModHelperComponent.md 'BTD_Mod_Helper.Api.Components.ModHelperComponent') &#129106; ModHelperText
### Properties

<a name='BTD_Mod_Helper.Api.Components.ModHelperText.SizingWidthToText'></a>

## ModHelperText.SizingWidthToText Property

Makes the width of this object scale with the text its holding

```csharp
public bool SizingWidthToText { get; set; }
```

#### Property Value
[System.Boolean](https://docs.microsoft.com/en-us/dotnet/api/System.Boolean 'System.Boolean')

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

<a name='BTD_Mod_Helper.Api.Components.ModHelperText.EnableAutoSizing()'></a>

## ModHelperText.EnableAutoSizing() Method

Enables auto sizing for this [Text](BTD_Mod_Helper.Api.Components.ModHelperText.md#BTD_Mod_Helper.Api.Components.ModHelperText.Text 'BTD_Mod_Helper.Api.Components.ModHelperText.Text') component

```csharp
public void EnableAutoSizing();
```

<a name='BTD_Mod_Helper.Api.Components.ModHelperText.EnableAutoSizing(bool)'></a>

## ModHelperText.EnableAutoSizing(bool) Method

Enables or disables auto sizing for this [Text](BTD_Mod_Helper.Api.Components.ModHelperText.md#BTD_Mod_Helper.Api.Components.ModHelperText.Text 'BTD_Mod_Helper.Api.Components.ModHelperText.Text') component

```csharp
public void EnableAutoSizing(bool enable);
```
#### Parameters

<a name='BTD_Mod_Helper.Api.Components.ModHelperText.EnableAutoSizing(bool).enable'></a>

`enable` [System.Boolean](https://docs.microsoft.com/en-us/dotnet/api/System.Boolean 'System.Boolean')

<a name='BTD_Mod_Helper.Api.Components.ModHelperText.EnableAutoSizing(float,float)'></a>

## ModHelperText.EnableAutoSizing(float, float) Method

Enables auto sizing for [Text](BTD_Mod_Helper.Api.Components.ModHelperText.md#BTD_Mod_Helper.Api.Components.ModHelperText.Text 'BTD_Mod_Helper.Api.Components.ModHelperText.Text')

```csharp
public void EnableAutoSizing(float fontSizeMax, float fontSizeMin);
```
#### Parameters

<a name='BTD_Mod_Helper.Api.Components.ModHelperText.EnableAutoSizing(float,float).fontSizeMax'></a>

`fontSizeMax` [System.Single](https://docs.microsoft.com/en-us/dotnet/api/System.Single 'System.Single')

<a name='BTD_Mod_Helper.Api.Components.ModHelperText.EnableAutoSizing(float,float).fontSizeMin'></a>

`fontSizeMin` [System.Single](https://docs.microsoft.com/en-us/dotnet/api/System.Single 'System.Single')

<a name='BTD_Mod_Helper.Api.Components.ModHelperText.EnableAutoSizing(float)'></a>

## ModHelperText.EnableAutoSizing(float) Method

Enables auto sizing for this [Text](BTD_Mod_Helper.Api.Components.ModHelperText.md#BTD_Mod_Helper.Api.Components.ModHelperText.Text 'BTD_Mod_Helper.Api.Components.ModHelperText.Text') component

```csharp
public void EnableAutoSizing(float fontSizeMax);
```
#### Parameters

<a name='BTD_Mod_Helper.Api.Components.ModHelperText.EnableAutoSizing(float).fontSizeMax'></a>

`fontSizeMax` [System.Single](https://docs.microsoft.com/en-us/dotnet/api/System.Single 'System.Single')

<a name='BTD_Mod_Helper.Api.Components.ModHelperText.OnUpdate()'></a>

## ModHelperText.OnUpdate() Method

Unity Component OnUpdate

```csharp
protected override void OnUpdate();
```

<a name='BTD_Mod_Helper.Api.Components.ModHelperText.SetText(string)'></a>

## ModHelperText.SetText(string) Method

Sets the text of this text to the given text

```csharp
public void SetText(string text);
```
#### Parameters

<a name='BTD_Mod_Helper.Api.Components.ModHelperText.SetText(string).text'></a>

`text` [System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')

<a name='BTD_Mod_Helper.Api.Components.ModHelperText.SizeWidthToText(bool)'></a>

## ModHelperText.SizeWidthToText(bool) Method

Makes the width of this object scale with the text its holding

```csharp
public void SizeWidthToText(bool sizeWidthToText=true);
```
#### Parameters

<a name='BTD_Mod_Helper.Api.Components.ModHelperText.SizeWidthToText(bool).sizeWidthToText'></a>

`sizeWidthToText` [System.Boolean](https://docs.microsoft.com/en-us/dotnet/api/System.Boolean 'System.Boolean')