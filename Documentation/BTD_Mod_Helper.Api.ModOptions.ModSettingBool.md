#### [BloonsTD6 Mod Helper](README.md 'README')
### [BTD_Mod_Helper.Api.ModOptions](README.md#BTD_Mod_Helper.Api.ModOptions 'BTD_Mod_Helper.Api.ModOptions')

## ModSettingBool Class

ModSetting class for a boolean value

```csharp
public class ModSettingBool : BTD_Mod_Helper.Api.ModOptions.ModSetting<bool>
```

Inheritance [System.Object](https://docs.microsoft.com/en-us/dotnet/api/System.Object 'System.Object') &#129106; [ModSetting](BTD_Mod_Helper.Api.ModOptions.ModSetting.md 'BTD_Mod_Helper.Api.ModOptions.ModSetting') &#129106; [BTD_Mod_Helper.Api.ModOptions.ModSetting&lt;](BTD_Mod_Helper.Api.ModOptions.ModSetting_T_.md 'BTD_Mod_Helper.Api.ModOptions.ModSetting<T>')[System.Boolean](https://docs.microsoft.com/en-us/dotnet/api/System.Boolean 'System.Boolean')[&gt;](BTD_Mod_Helper.Api.ModOptions.ModSetting_T_.md 'BTD_Mod_Helper.Api.ModOptions.ModSetting<T>') &#129106; ModSettingBool
### Fields

<a name='BTD_Mod_Helper.Api.ModOptions.ModSettingBool.button'></a>

## ModSettingBool.button Field

Whether this should display as an Enabled/Disabled button instead of a checkbox

```csharp
public bool button;
```

#### Field Value
[System.Boolean](https://docs.microsoft.com/en-us/dotnet/api/System.Boolean 'System.Boolean')

<a name='BTD_Mod_Helper.Api.ModOptions.ModSettingBool.disabledButton'></a>

## ModSettingBool.disabledButton Field

The sprite to use for the button when it's disabled, RedBtnLong by default

```csharp
public string disabledButton;
```

#### Field Value
[System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')

<a name='BTD_Mod_Helper.Api.ModOptions.ModSettingBool.disabledText'></a>

## ModSettingBool.disabledText Field

The text that the button should have when it's disabled, if this is a button

```csharp
public string disabledText;
```

#### Field Value
[System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')

<a name='BTD_Mod_Helper.Api.ModOptions.ModSettingBool.enabledButton'></a>

## ModSettingBool.enabledButton Field

The sprite to use for the button when it's enabled, GreenBtnLong by default

```csharp
public string enabledButton;
```

#### Field Value
[System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')

<a name='BTD_Mod_Helper.Api.ModOptions.ModSettingBool.enabledText'></a>

## ModSettingBool.enabledText Field

The text that the button should have when it's enabled, if this is a button

```csharp
public string enabledText;
```

#### Field Value
[System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')

<a name='BTD_Mod_Helper.Api.ModOptions.ModSettingBool.modifyButton'></a>

## ModSettingBool.modifyButton Field

Action to modify the ModHelperCheckbox after it's created

```csharp
public Action<ModHelperButton> modifyButton;
```

#### Field Value
[System.Action&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Action-1 'System.Action`1')[ModHelperButton](BTD_Mod_Helper.Api.Components.ModHelperButton.md 'BTD_Mod_Helper.Api.Components.ModHelperButton')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Action-1 'System.Action`1')

<a name='BTD_Mod_Helper.Api.ModOptions.ModSettingBool.modifyCheckbox'></a>

## ModSettingBool.modifyCheckbox Field

Action to modify the ModHelperCheckbox after it's created

```csharp
public Action<ModHelperCheckbox> modifyCheckbox;
```

#### Field Value
[System.Action&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Action-1 'System.Action`1')[ModHelperCheckbox](BTD_Mod_Helper.Api.Components.ModHelperCheckbox.md 'BTD_Mod_Helper.Api.Components.ModHelperCheckbox')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Action-1 'System.Action`1')
### Properties

<a name='BTD_Mod_Helper.Api.ModOptions.ModSettingBool.IsButton'></a>

## ModSettingBool.IsButton Property

Old way to do a button before ModSettingButton was a thing

```csharp
public bool IsButton { get; set; }
```

#### Property Value
[System.Boolean](https://docs.microsoft.com/en-us/dotnet/api/System.Boolean 'System.Boolean')
### Methods

<a name='BTD_Mod_Helper.Api.ModOptions.ModSettingBool.SetValue(object)'></a>

## ModSettingBool.SetValue(object) Method

Sets the current value of this ModSetting

```csharp
public override void SetValue(object val);
```
#### Parameters

<a name='BTD_Mod_Helper.Api.ModOptions.ModSettingBool.SetValue(object).val'></a>

`val` [System.Object](https://docs.microsoft.com/en-us/dotnet/api/System.Object 'System.Object')

The new value
### Operators

<a name='BTD_Mod_Helper.Api.ModOptions.ModSettingBool.op_Implicitbool(BTD_Mod_Helper.Api.ModOptions.ModSettingBool)'></a>

## ModSettingBool.implicit operator bool(ModSettingBool) Operator

Gets the current value out of a ModSettingBool

```csharp
public static bool implicit operator bool(BTD_Mod_Helper.Api.ModOptions.ModSettingBool modSettingBool);
```
#### Parameters

<a name='BTD_Mod_Helper.Api.ModOptions.ModSettingBool.op_Implicitbool(BTD_Mod_Helper.Api.ModOptions.ModSettingBool).modSettingBool'></a>

`modSettingBool` [ModSettingBool](BTD_Mod_Helper.Api.ModOptions.ModSettingBool.md 'BTD_Mod_Helper.Api.ModOptions.ModSettingBool')

#### Returns
[System.Boolean](https://docs.microsoft.com/en-us/dotnet/api/System.Boolean 'System.Boolean')

<a name='BTD_Mod_Helper.Api.ModOptions.ModSettingBool.op_ImplicitBTD_Mod_Helper.Api.ModOptions.ModSettingBool(bool)'></a>

## ModSettingBool.implicit operator ModSettingBool(bool) Operator

Create a new ModSetting bool with the given value as default

```csharp
public static BTD_Mod_Helper.Api.ModOptions.ModSettingBool implicit operator ModSettingBool(bool value);
```
#### Parameters

<a name='BTD_Mod_Helper.Api.ModOptions.ModSettingBool.op_ImplicitBTD_Mod_Helper.Api.ModOptions.ModSettingBool(bool).value'></a>

`value` [System.Boolean](https://docs.microsoft.com/en-us/dotnet/api/System.Boolean 'System.Boolean')

#### Returns
[ModSettingBool](BTD_Mod_Helper.Api.ModOptions.ModSettingBool.md 'BTD_Mod_Helper.Api.ModOptions.ModSettingBool')