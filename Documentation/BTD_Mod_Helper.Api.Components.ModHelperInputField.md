#### [BloonsTD6 Mod Helper](README.md 'README')
### [BTD_Mod_Helper.Api.Components](README.md#BTD_Mod_Helper.Api.Components 'BTD_Mod_Helper.Api.Components')

## ModHelperInputField Class

ModHelperComponent for a text input field

```csharp
public class ModHelperInputField : BTD_Mod_Helper.Api.Components.ModHelperComponent
```

Inheritance [UnityEngine.MonoBehaviour](https://docs.microsoft.com/en-us/dotnet/api/UnityEngine.MonoBehaviour 'UnityEngine.MonoBehaviour') &#129106; [ModHelperComponent](BTD_Mod_Helper.Api.Components.ModHelperComponent.md 'BTD_Mod_Helper.Api.Components.ModHelperComponent') &#129106; ModHelperInputField
### Properties

<a name='BTD_Mod_Helper.Api.Components.ModHelperInputField.CurrentValue'></a>

## ModHelperInputField.CurrentValue Property

Gets the current value of the InputField

```csharp
public string CurrentValue { get; }
```

#### Property Value
[System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')

<a name='BTD_Mod_Helper.Api.Components.ModHelperInputField.InputField'></a>

## ModHelperInputField.InputField Property

The InputField component

```csharp
public NK_TextMeshProInputField InputField { get; }
```

#### Property Value
[Il2Cpp.NK_TextMeshProInputField](https://docs.microsoft.com/en-us/dotnet/api/Il2Cpp.NK_TextMeshProInputField 'Il2Cpp.NK_TextMeshProInputField')

<a name='BTD_Mod_Helper.Api.Components.ModHelperInputField.Text'></a>

## ModHelperInputField.Text Property

The Text ModHelperComponent

```csharp
public BTD_Mod_Helper.Api.Components.ModHelperText Text { get; }
```

#### Property Value
[ModHelperText](BTD_Mod_Helper.Api.Components.ModHelperText.md 'BTD_Mod_Helper.Api.Components.ModHelperText')
### Methods

<a name='BTD_Mod_Helper.Api.Components.ModHelperInputField.OnUpdate()'></a>

## ModHelperInputField.OnUpdate() Method

Unity Component OnUpdate

```csharp
protected override void OnUpdate();
```

<a name='BTD_Mod_Helper.Api.Components.ModHelperInputField.SetText(string,bool)'></a>

## ModHelperInputField.SetText(string, bool) Method

Sets the current value of this

```csharp
public void SetText(string text, bool sendCallback=true);
```
#### Parameters

<a name='BTD_Mod_Helper.Api.Components.ModHelperInputField.SetText(string,bool).text'></a>

`text` [System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')

The new text

<a name='BTD_Mod_Helper.Api.Components.ModHelperInputField.SetText(string,bool).sendCallback'></a>

`sendCallback` [System.Boolean](https://docs.microsoft.com/en-us/dotnet/api/System.Boolean 'System.Boolean')

Whether the onValueChanged listener should fire