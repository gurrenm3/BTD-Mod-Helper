#### [BloonsTD6 Mod Helper](README.md 'README')
### [BTD_Mod_Helper.Api.Components](README.md#BTD_Mod_Helper.Api.Components 'BTD_Mod_Helper.Api.Components')

## ModHelperInputField Class

ModHelperComponent for a text input field

```csharp
public class ModHelperInputField : BTD_Mod_Helper.Api.Components.ModHelperComponent
```

Inheritance [System.Object](https://docs.microsoft.com/en-us/dotnet/api/System.Object 'System.Object') &#129106; [Il2CppInterop.Runtime.InteropTypes.Il2CppObjectBase](https://docs.microsoft.com/en-us/dotnet/api/Il2CppInterop.Runtime.InteropTypes.Il2CppObjectBase 'Il2CppInterop.Runtime.InteropTypes.Il2CppObjectBase') &#129106; [Il2CppSystem.Object](https://docs.microsoft.com/en-us/dotnet/api/Il2CppSystem.Object 'Il2CppSystem.Object') &#129106; [UnityEngine.Object](https://docs.microsoft.com/en-us/dotnet/api/UnityEngine.Object 'UnityEngine.Object') &#129106; [UnityEngine.Component](https://docs.microsoft.com/en-us/dotnet/api/UnityEngine.Component 'UnityEngine.Component') &#129106; [UnityEngine.Behaviour](https://docs.microsoft.com/en-us/dotnet/api/UnityEngine.Behaviour 'UnityEngine.Behaviour') &#129106; [UnityEngine.MonoBehaviour](https://docs.microsoft.com/en-us/dotnet/api/UnityEngine.MonoBehaviour 'UnityEngine.MonoBehaviour') &#129106; [ModHelperComponent](BTD_Mod_Helper.Api.Components.ModHelperComponent.md 'BTD_Mod_Helper.Api.Components.ModHelperComponent') &#129106; ModHelperInputField
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
public global::NK_TextMeshProInputField InputField { get; }
```

#### Property Value
[NK_TextMeshProInputField](https://docs.microsoft.com/en-us/dotnet/api/NK_TextMeshProInputField 'NK_TextMeshProInputField')

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

Unity Component Update

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