#### [BloonsTD6 Mod Helper](index.md 'index')
### [BTD_Mod_Helper.Api.ModOptions](index.md#BTD_Mod_Helper.Api.ModOptions 'BTD_Mod_Helper.Api.ModOptions')

## ModSettingNumber<T> Class

ModSetting class for a number, implying it can have a min/max value, and be an input or a slider

```csharp
public abstract class ModSettingNumber<T> : BTD_Mod_Helper.Api.ModOptions.ModSetting<T>
    where T : struct, System.IComparable<T>, System.ValueType, System.ValueType
```
#### Type parameters

<a name='BTD_Mod_Helper.Api.ModOptions.ModSettingNumber_T_.T'></a>

`T`

Inheritance [System.Object](https://docs.microsoft.com/en-us/dotnet/api/System.Object 'System.Object') &#129106; [ModSetting](BTD_Mod_Helper.Api.ModOptions.ModSetting.md 'BTD_Mod_Helper.Api.ModOptions.ModSetting') &#129106; [BTD_Mod_Helper.Api.ModOptions.ModSetting&lt;](BTD_Mod_Helper.Api.ModOptions.ModSetting_T_.md 'BTD_Mod_Helper.Api.ModOptions.ModSetting<T>')[T](BTD_Mod_Helper.Api.ModOptions.ModSettingNumber_T_.md#BTD_Mod_Helper.Api.ModOptions.ModSettingNumber_T_.T 'BTD_Mod_Helper.Api.ModOptions.ModSettingNumber<T>.T')[&gt;](BTD_Mod_Helper.Api.ModOptions.ModSetting_T_.md 'BTD_Mod_Helper.Api.ModOptions.ModSetting<T>') &#129106; ModSettingNumber<T>

Derived  
&#8627; [ModSettingDouble](BTD_Mod_Helper.Api.ModOptions.ModSettingDouble.md 'BTD_Mod_Helper.Api.ModOptions.ModSettingDouble')  
&#8627; [ModSettingInt](BTD_Mod_Helper.Api.ModOptions.ModSettingInt.md 'BTD_Mod_Helper.Api.ModOptions.ModSettingInt')
### Constructors

<a name='BTD_Mod_Helper.Api.ModOptions.ModSettingNumber_T_.ModSettingNumber(T)'></a>

## ModSettingNumber(T) Constructor

Constructs a new ModSetting for the given value

```csharp
protected ModSettingNumber(T value);
```
#### Parameters

<a name='BTD_Mod_Helper.Api.ModOptions.ModSettingNumber_T_.ModSettingNumber(T).value'></a>

`value` [T](BTD_Mod_Helper.Api.ModOptions.ModSettingNumber_T_.md#BTD_Mod_Helper.Api.ModOptions.ModSettingNumber_T_.T 'BTD_Mod_Helper.Api.ModOptions.ModSettingNumber<T>.T')
### Fields

<a name='BTD_Mod_Helper.Api.ModOptions.ModSettingNumber_T_.max'></a>

## ModSettingNumber<T>.max Field

The largest allowed value, or null for unbounded

```csharp
public Nullable<T> max;
```

#### Field Value
[System.Nullable&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Nullable-1 'System.Nullable`1')[T](BTD_Mod_Helper.Api.ModOptions.ModSettingNumber_T_.md#BTD_Mod_Helper.Api.ModOptions.ModSettingNumber_T_.T 'BTD_Mod_Helper.Api.ModOptions.ModSettingNumber<T>.T')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Nullable-1 'System.Nullable`1')

<a name='BTD_Mod_Helper.Api.ModOptions.ModSettingNumber_T_.min'></a>

## ModSettingNumber<T>.min Field

The lowest allowed value, or null for unbounded

```csharp
public Nullable<T> min;
```

#### Field Value
[System.Nullable&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Nullable-1 'System.Nullable`1')[T](BTD_Mod_Helper.Api.ModOptions.ModSettingNumber_T_.md#BTD_Mod_Helper.Api.ModOptions.ModSettingNumber_T_.T 'BTD_Mod_Helper.Api.ModOptions.ModSettingNumber<T>.T')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Nullable-1 'System.Nullable`1')

<a name='BTD_Mod_Helper.Api.ModOptions.ModSettingNumber_T_.modifyInput'></a>

## ModSettingNumber<T>.modifyInput Field

Action to modify the ModHelperInputField after it's created

```csharp
public Action<ModHelperInputField> modifyInput;
```

#### Field Value
[System.Action&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Action-1 'System.Action`1')[ModHelperInputField](BTD_Mod_Helper.Api.Components.ModHelperInputField.md 'BTD_Mod_Helper.Api.Components.ModHelperInputField')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Action-1 'System.Action`1')

<a name='BTD_Mod_Helper.Api.ModOptions.ModSettingNumber_T_.modifySlider'></a>

## ModSettingNumber<T>.modifySlider Field

Action to modify the ModHelperSlider after it's created

```csharp
public Action<ModHelperSlider> modifySlider;
```

#### Field Value
[System.Action&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Action-1 'System.Action`1')[ModHelperSlider](BTD_Mod_Helper.Api.Components.ModHelperSlider.md 'BTD_Mod_Helper.Api.Components.ModHelperSlider')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Action-1 'System.Action`1')

<a name='BTD_Mod_Helper.Api.ModOptions.ModSettingNumber_T_.slider'></a>

## ModSettingNumber<T>.slider Field

Whether this displays as a slider

```csharp
public bool slider;
```

#### Field Value
[System.Boolean](https://docs.microsoft.com/en-us/dotnet/api/System.Boolean 'System.Boolean')
### Properties

<a name='BTD_Mod_Helper.Api.ModOptions.ModSettingNumber_T_.StepSize'></a>

## ModSettingNumber<T>.StepSize Property

Step Size for the slider

```csharp
protected virtual float StepSize { get; }
```

#### Property Value
[System.Single](https://docs.microsoft.com/en-us/dotnet/api/System.Single 'System.Single')

<a name='BTD_Mod_Helper.Api.ModOptions.ModSettingNumber_T_.Validation'></a>

## ModSettingNumber<T>.Validation Property

Validation to use for the input component

```csharp
protected abstract TMPro.TMP_InputField.CharacterValidation Validation { get; }
```

#### Property Value
[TMPro.TMP_InputField.CharacterValidation](https://docs.microsoft.com/en-us/dotnet/api/TMPro.TMP_InputField.CharacterValidation 'TMPro.TMP_InputField.CharacterValidation')
### Methods

<a name='BTD_Mod_Helper.Api.ModOptions.ModSettingNumber_T_.FromFloat(float)'></a>

## ModSettingNumber<T>.FromFloat(float) Method

Conversion of the type from a float for the slider component

```csharp
protected abstract T FromFloat(float f);
```
#### Parameters

<a name='BTD_Mod_Helper.Api.ModOptions.ModSettingNumber_T_.FromFloat(float).f'></a>

`f` [System.Single](https://docs.microsoft.com/en-us/dotnet/api/System.Single 'System.Single')

#### Returns
[T](BTD_Mod_Helper.Api.ModOptions.ModSettingNumber_T_.md#BTD_Mod_Helper.Api.ModOptions.ModSettingNumber_T_.T 'BTD_Mod_Helper.Api.ModOptions.ModSettingNumber<T>.T')

<a name='BTD_Mod_Helper.Api.ModOptions.ModSettingNumber_T_.FromString(string)'></a>

## ModSettingNumber<T>.FromString(string) Method

Get the value from the string input component

```csharp
protected abstract T FromString(string s);
```
#### Parameters

<a name='BTD_Mod_Helper.Api.ModOptions.ModSettingNumber_T_.FromString(string).s'></a>

`s` [System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')

#### Returns
[T](BTD_Mod_Helper.Api.ModOptions.ModSettingNumber_T_.md#BTD_Mod_Helper.Api.ModOptions.ModSettingNumber_T_.T 'BTD_Mod_Helper.Api.ModOptions.ModSettingNumber<T>.T')

<a name='BTD_Mod_Helper.Api.ModOptions.ModSettingNumber_T_.ToFloat(T)'></a>

## ModSettingNumber<T>.ToFloat(T) Method

Conversion of the type to a float for the slider component

```csharp
protected abstract float ToFloat(T input);
```
#### Parameters

<a name='BTD_Mod_Helper.Api.ModOptions.ModSettingNumber_T_.ToFloat(T).input'></a>

`input` [T](BTD_Mod_Helper.Api.ModOptions.ModSettingNumber_T_.md#BTD_Mod_Helper.Api.ModOptions.ModSettingNumber_T_.T 'BTD_Mod_Helper.Api.ModOptions.ModSettingNumber<T>.T')

#### Returns
[System.Single](https://docs.microsoft.com/en-us/dotnet/api/System.Single 'System.Single')

<a name='BTD_Mod_Helper.Api.ModOptions.ModSettingNumber_T_.ToString(T)'></a>

## ModSettingNumber<T>.ToString(T) Method

Turn the value into a string for labels

```csharp
protected abstract string ToString(T input);
```
#### Parameters

<a name='BTD_Mod_Helper.Api.ModOptions.ModSettingNumber_T_.ToString(T).input'></a>

`input` [T](BTD_Mod_Helper.Api.ModOptions.ModSettingNumber_T_.md#BTD_Mod_Helper.Api.ModOptions.ModSettingNumber_T_.T 'BTD_Mod_Helper.Api.ModOptions.ModSettingNumber<T>.T')

#### Returns
[System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')