#### [BloonsTD6 Mod Helper](README.md 'README')
### [BTD_Mod_Helper.Api.ModOptions](README.md#BTD_Mod_Helper.Api.ModOptions 'BTD_Mod_Helper.Api.ModOptions')

## ModSettingInt Class

ModSetting for int values

```csharp
public class ModSettingInt : BTD_Mod_Helper.Api.ModOptions.ModSettingNumber<long>
```

Inheritance [System.Object](https://docs.microsoft.com/en-us/dotnet/api/System.Object 'System.Object') &#129106; [ModSetting](BTD_Mod_Helper.Api.ModOptions.ModSetting.md 'BTD_Mod_Helper.Api.ModOptions.ModSetting') &#129106; [BTD_Mod_Helper.Api.ModOptions.ModSetting&lt;](BTD_Mod_Helper.Api.ModOptions.ModSetting_T_.md 'BTD_Mod_Helper.Api.ModOptions.ModSetting<T>')[System.Int64](https://docs.microsoft.com/en-us/dotnet/api/System.Int64 'System.Int64')[&gt;](BTD_Mod_Helper.Api.ModOptions.ModSetting_T_.md 'BTD_Mod_Helper.Api.ModOptions.ModSetting<T>') &#129106; [BTD_Mod_Helper.Api.ModOptions.ModSettingNumber&lt;](BTD_Mod_Helper.Api.ModOptions.ModSettingNumber_T_.md 'BTD_Mod_Helper.Api.ModOptions.ModSettingNumber<T>')[System.Int64](https://docs.microsoft.com/en-us/dotnet/api/System.Int64 'System.Int64')[&gt;](BTD_Mod_Helper.Api.ModOptions.ModSettingNumber_T_.md 'BTD_Mod_Helper.Api.ModOptions.ModSettingNumber<T>') &#129106; ModSettingInt
### Fields

<a name='BTD_Mod_Helper.Api.ModOptions.ModSettingInt.isSlider'></a>

## ModSettingInt.isSlider Field

Old way of doing slider

```csharp
public bool isSlider;
```

#### Field Value
[System.Boolean](https://docs.microsoft.com/en-us/dotnet/api/System.Boolean 'System.Boolean')

<a name='BTD_Mod_Helper.Api.ModOptions.ModSettingInt.maxValue'></a>

## ModSettingInt.maxValue Field

Old way of doing max

```csharp
public Nullable<long> maxValue;
```

#### Field Value
[System.Nullable&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Nullable-1 'System.Nullable`1')[System.Int64](https://docs.microsoft.com/en-us/dotnet/api/System.Int64 'System.Int64')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Nullable-1 'System.Nullable`1')

<a name='BTD_Mod_Helper.Api.ModOptions.ModSettingInt.minValue'></a>

## ModSettingInt.minValue Field

Old way of doing min

```csharp
public Nullable<long> minValue;
```

#### Field Value
[System.Nullable&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Nullable-1 'System.Nullable`1')[System.Int64](https://docs.microsoft.com/en-us/dotnet/api/System.Int64 'System.Int64')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Nullable-1 'System.Nullable`1')
### Properties

<a name='BTD_Mod_Helper.Api.ModOptions.ModSettingInt.Validation'></a>

## ModSettingInt.Validation Property

Validation to use for the input component

```csharp
protected override Il2CppTMPro.TMP_InputField.CharacterValidation Validation { get; }
```

#### Property Value
[Il2CppTMPro.TMP_InputField.CharacterValidation](https://docs.microsoft.com/en-us/dotnet/api/Il2CppTMPro.TMP_InputField.CharacterValidation 'Il2CppTMPro.TMP_InputField.CharacterValidation')
### Methods

<a name='BTD_Mod_Helper.Api.ModOptions.ModSettingInt.FromFloat(float)'></a>

## ModSettingInt.FromFloat(float) Method

Conversion of the type from a float for the slider component

```csharp
protected override long FromFloat(float f);
```
#### Parameters

<a name='BTD_Mod_Helper.Api.ModOptions.ModSettingInt.FromFloat(float).f'></a>

`f` [System.Single](https://docs.microsoft.com/en-us/dotnet/api/System.Single 'System.Single')

#### Returns
[System.Int64](https://docs.microsoft.com/en-us/dotnet/api/System.Int64 'System.Int64')

<a name='BTD_Mod_Helper.Api.ModOptions.ModSettingInt.FromString(string)'></a>

## ModSettingInt.FromString(string) Method

Get the value from the string input component

```csharp
protected override long FromString(string s);
```
#### Parameters

<a name='BTD_Mod_Helper.Api.ModOptions.ModSettingInt.FromString(string).s'></a>

`s` [System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')

#### Returns
[System.Int64](https://docs.microsoft.com/en-us/dotnet/api/System.Int64 'System.Int64')
### Operators

<a name='BTD_Mod_Helper.Api.ModOptions.ModSettingInt.op_ImplicitBTD_Mod_Helper.Api.ModOptions.ModSettingInt(int)'></a>

## ModSettingInt.implicit operator ModSettingInt(int) Operator

Constructs a new ModSetting with the given value as default

```csharp
public static BTD_Mod_Helper.Api.ModOptions.ModSettingInt implicit operator ModSettingInt(int value);
```
#### Parameters

<a name='BTD_Mod_Helper.Api.ModOptions.ModSettingInt.op_ImplicitBTD_Mod_Helper.Api.ModOptions.ModSettingInt(int).value'></a>

`value` [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/System.Int32 'System.Int32')

#### Returns
[ModSettingInt](BTD_Mod_Helper.Api.ModOptions.ModSettingInt.md 'BTD_Mod_Helper.Api.ModOptions.ModSettingInt')

<a name='BTD_Mod_Helper.Api.ModOptions.ModSettingInt.op_Implicitint(BTD_Mod_Helper.Api.ModOptions.ModSettingInt)'></a>

## ModSettingInt.implicit operator int(ModSettingInt) Operator

Gets the current value out of a ModSetting

```csharp
public static int implicit operator int(BTD_Mod_Helper.Api.ModOptions.ModSettingInt modSettingInt);
```
#### Parameters

<a name='BTD_Mod_Helper.Api.ModOptions.ModSettingInt.op_Implicitint(BTD_Mod_Helper.Api.ModOptions.ModSettingInt).modSettingInt'></a>

`modSettingInt` [ModSettingInt](BTD_Mod_Helper.Api.ModOptions.ModSettingInt.md 'BTD_Mod_Helper.Api.ModOptions.ModSettingInt')

#### Returns
[System.Int32](https://docs.microsoft.com/en-us/dotnet/api/System.Int32 'System.Int32')