#### [BloonsTD6 Mod Helper](index.md 'index')
### [BTD_Mod_Helper.Api.ModOptions](index.md#BTD_Mod_Helper.Api.ModOptions 'BTD_Mod_Helper.Api.ModOptions')

## ModSettingString Class

ModSetting for a string value

```csharp
public class ModSettingString : BTD_Mod_Helper.Api.ModOptions.ModSetting<string>
```

Inheritance [System.Object](https://docs.microsoft.com/en-us/dotnet/api/System.Object 'System.Object') &#129106; [ModSetting](BTD_Mod_Helper.Api.ModOptions.ModSetting.md 'BTD_Mod_Helper.Api.ModOptions.ModSetting') &#129106; [BTD_Mod_Helper.Api.ModOptions.ModSetting&lt;](BTD_Mod_Helper.Api.ModOptions.ModSetting_T_.md 'BTD_Mod_Helper.Api.ModOptions.ModSetting<T>')[System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')[&gt;](BTD_Mod_Helper.Api.ModOptions.ModSetting_T_.md 'BTD_Mod_Helper.Api.ModOptions.ModSetting<T>') &#129106; ModSettingString
### Fields

<a name='BTD_Mod_Helper.Api.ModOptions.ModSettingString.Alphanumeric'></a>

## ModSettingString.Alphanumeric Field

Allow only alphanumeric characters

```csharp
public static readonly string Alphanumeric;
```

#### Field Value
[System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')

<a name='BTD_Mod_Helper.Api.ModOptions.ModSettingString.characterValidation'></a>

## ModSettingString.characterValidation Field

Validation for the input field, determining which characters are allowed

```csharp
public CharacterValidation characterValidation;
```

#### Field Value
[TMPro.TMP_InputField.CharacterValidation](https://docs.microsoft.com/en-us/dotnet/api/TMPro.TMP_InputField.CharacterValidation 'TMPro.TMP_InputField.CharacterValidation')

<a name='BTD_Mod_Helper.Api.ModOptions.ModSettingString.Decimal'></a>

## ModSettingString.Decimal Field

Allow only valid decimals

```csharp
public static readonly string Decimal;
```

#### Field Value
[System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')

<a name='BTD_Mod_Helper.Api.ModOptions.ModSettingString.Integer'></a>

## ModSettingString.Integer Field

Allow only valid integers

```csharp
public static readonly string Integer;
```

#### Field Value
[System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')

<a name='BTD_Mod_Helper.Api.ModOptions.ModSettingString.modifyInput'></a>

## ModSettingString.modifyInput Field

Action to modify the ModHelperInputField after it's created

```csharp
public Action<ModHelperInputField> modifyInput;
```

#### Field Value
[System.Action&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Action-1 'System.Action`1')[ModHelperInputField](BTD_Mod_Helper.Api.Components.ModHelperInputField.md 'BTD_Mod_Helper.Api.Components.ModHelperInputField')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Action-1 'System.Action`1')

<a name='BTD_Mod_Helper.Api.ModOptions.ModSettingString.None'></a>

## ModSettingString.None Field

Allow all characters

```csharp
public static readonly string None;
```

#### Field Value
[System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')

<a name='BTD_Mod_Helper.Api.ModOptions.ModSettingString.validation'></a>

## ModSettingString.validation Field

InputField validation, use one of the ModSettingString.[thing] constants

```csharp
public string validation;
```

#### Field Value
[System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')
### Methods

<a name='BTD_Mod_Helper.Api.ModOptions.ModSettingString.CreateComponent()'></a>

## ModSettingString.CreateComponent() Method

Constructs a visual ModHelperComponent for this ModSetting

```csharp
internal override BTD_Mod_Helper.Api.Components.ModHelperOption CreateComponent();
```

#### Returns
[ModHelperOption](BTD_Mod_Helper.Api.Components.ModHelperOption.md 'BTD_Mod_Helper.Api.Components.ModHelperOption')  
The created ModHelperComponent
### Operators

<a name='BTD_Mod_Helper.Api.ModOptions.ModSettingString.op_ImplicitBTD_Mod_Helper.Api.ModOptions.ModSettingString(string)'></a>

## ModSettingString.implicit operator ModSettingString(string) Operator

Constructs a new ModSetting with the given value as default

```csharp
public static BTD_Mod_Helper.Api.ModOptions.ModSettingString implicit operator ModSettingString(string value);
```
#### Parameters

<a name='BTD_Mod_Helper.Api.ModOptions.ModSettingString.op_ImplicitBTD_Mod_Helper.Api.ModOptions.ModSettingString(string).value'></a>

`value` [System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')

#### Returns
[ModSettingString](BTD_Mod_Helper.Api.ModOptions.ModSettingString.md 'BTD_Mod_Helper.Api.ModOptions.ModSettingString')

<a name='BTD_Mod_Helper.Api.ModOptions.ModSettingString.op_Implicitstring(BTD_Mod_Helper.Api.ModOptions.ModSettingString)'></a>

## ModSettingString.implicit operator string(ModSettingString) Operator

Gets the current value out of a ModSetting

```csharp
public static string implicit operator string(BTD_Mod_Helper.Api.ModOptions.ModSettingString modSettingString);
```
#### Parameters

<a name='BTD_Mod_Helper.Api.ModOptions.ModSettingString.op_Implicitstring(BTD_Mod_Helper.Api.ModOptions.ModSettingString).modSettingString'></a>

`modSettingString` [ModSettingString](BTD_Mod_Helper.Api.ModOptions.ModSettingString.md 'BTD_Mod_Helper.Api.ModOptions.ModSettingString')

#### Returns
[System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')