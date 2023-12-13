#### [BloonsTD6 Mod Helper](README.md 'README')
### [BTD_Mod_Helper.Api.ModOptions](README.md#BTD_Mod_Helper.Api.ModOptions 'BTD_Mod_Helper.Api.ModOptions')

## ModSettingDouble Class

ModSetting for a decimal value

```csharp
public class ModSettingDouble : BTD_Mod_Helper.Api.ModOptions.ModSettingNumber<double>
```

Inheritance [System.Object](https://docs.microsoft.com/en-us/dotnet/api/System.Object 'System.Object') &#129106; [ModSetting](BTD_Mod_Helper.Api.ModOptions.ModSetting.md 'BTD_Mod_Helper.Api.ModOptions.ModSetting') &#129106; [BTD_Mod_Helper.Api.ModOptions.ModSetting&lt;](BTD_Mod_Helper.Api.ModOptions.ModSetting_T_.md 'BTD_Mod_Helper.Api.ModOptions.ModSetting<T>')[System.Double](https://docs.microsoft.com/en-us/dotnet/api/System.Double 'System.Double')[&gt;](BTD_Mod_Helper.Api.ModOptions.ModSetting_T_.md 'BTD_Mod_Helper.Api.ModOptions.ModSetting<T>') &#129106; [BTD_Mod_Helper.Api.ModOptions.ModSettingNumber&lt;](BTD_Mod_Helper.Api.ModOptions.ModSettingNumber_T_.md 'BTD_Mod_Helper.Api.ModOptions.ModSettingNumber<T>')[System.Double](https://docs.microsoft.com/en-us/dotnet/api/System.Double 'System.Double')[&gt;](BTD_Mod_Helper.Api.ModOptions.ModSettingNumber_T_.md 'BTD_Mod_Helper.Api.ModOptions.ModSettingNumber<T>') &#129106; ModSettingDouble

Derived  
&#8627; [ModSettingFloat](BTD_Mod_Helper.Api.ModOptions.ModSettingFloat.md 'BTD_Mod_Helper.Api.ModOptions.ModSettingFloat')
### Fields

<a name='BTD_Mod_Helper.Api.ModOptions.ModSettingDouble.isSlider'></a>

## ModSettingDouble.isSlider Field

Old way of doing slider

```csharp
public bool isSlider;
```

#### Field Value
[System.Boolean](https://docs.microsoft.com/en-us/dotnet/api/System.Boolean 'System.Boolean')

<a name='BTD_Mod_Helper.Api.ModOptions.ModSettingDouble.maxValue'></a>

## ModSettingDouble.maxValue Field

Old way of doing max

```csharp
public Nullable<double> maxValue;
```

#### Field Value
[System.Nullable&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Nullable-1 'System.Nullable`1')[System.Double](https://docs.microsoft.com/en-us/dotnet/api/System.Double 'System.Double')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Nullable-1 'System.Nullable`1')

<a name='BTD_Mod_Helper.Api.ModOptions.ModSettingDouble.minValue'></a>

## ModSettingDouble.minValue Field

Old way of doing min

```csharp
public Nullable<double> minValue;
```

#### Field Value
[System.Nullable&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Nullable-1 'System.Nullable`1')[System.Double](https://docs.microsoft.com/en-us/dotnet/api/System.Double 'System.Double')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Nullable-1 'System.Nullable`1')

<a name='BTD_Mod_Helper.Api.ModOptions.ModSettingDouble.stepSize'></a>

## ModSettingDouble.stepSize Field

Step size to use for slider, or how much to round the input

```csharp
public float stepSize;
```

#### Field Value
[System.Single](https://docs.microsoft.com/en-us/dotnet/api/System.Single 'System.Single')
### Properties

<a name='BTD_Mod_Helper.Api.ModOptions.ModSettingDouble.StepSize'></a>

## ModSettingDouble.StepSize Property

Step Size for the slider

```csharp
protected override float StepSize { get; }
```

#### Property Value
[System.Single](https://docs.microsoft.com/en-us/dotnet/api/System.Single 'System.Single')

<a name='BTD_Mod_Helper.Api.ModOptions.ModSettingDouble.Validation'></a>

## ModSettingDouble.Validation Property

Validation to use for the input component

```csharp
protected override CharacterValidation Validation { get; }
```

#### Property Value
[Il2CppTMPro.CharacterValidation](https://docs.microsoft.com/en-us/dotnet/api/Il2CppTMPro.CharacterValidation 'Il2CppTMPro.CharacterValidation')
### Methods

<a name='BTD_Mod_Helper.Api.ModOptions.ModSettingDouble.FromFloat(float)'></a>

## ModSettingDouble.FromFloat(float) Method

Conversion of the type from a float for the slider component

```csharp
protected override double FromFloat(float f);
```
#### Parameters

<a name='BTD_Mod_Helper.Api.ModOptions.ModSettingDouble.FromFloat(float).f'></a>

`f` [System.Single](https://docs.microsoft.com/en-us/dotnet/api/System.Single 'System.Single')

#### Returns
[System.Double](https://docs.microsoft.com/en-us/dotnet/api/System.Double 'System.Double')

<a name='BTD_Mod_Helper.Api.ModOptions.ModSettingDouble.FromString(string)'></a>

## ModSettingDouble.FromString(string) Method

Get the value from the string input component

```csharp
protected override double FromString(string s);
```
#### Parameters

<a name='BTD_Mod_Helper.Api.ModOptions.ModSettingDouble.FromString(string).s'></a>

`s` [System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')

#### Returns
[System.Double](https://docs.microsoft.com/en-us/dotnet/api/System.Double 'System.Double')
### Operators

<a name='BTD_Mod_Helper.Api.ModOptions.ModSettingDouble.op_ImplicitBTD_Mod_Helper.Api.ModOptions.ModSettingDouble(double)'></a>

## ModSettingDouble.implicit operator ModSettingDouble(double) Operator

Constructs a new ModSetting with the given value as default

```csharp
public static BTD_Mod_Helper.Api.ModOptions.ModSettingDouble implicit operator ModSettingDouble(double value);
```
#### Parameters

<a name='BTD_Mod_Helper.Api.ModOptions.ModSettingDouble.op_ImplicitBTD_Mod_Helper.Api.ModOptions.ModSettingDouble(double).value'></a>

`value` [System.Double](https://docs.microsoft.com/en-us/dotnet/api/System.Double 'System.Double')

#### Returns
[ModSettingDouble](BTD_Mod_Helper.Api.ModOptions.ModSettingDouble.md 'BTD_Mod_Helper.Api.ModOptions.ModSettingDouble')

<a name='BTD_Mod_Helper.Api.ModOptions.ModSettingDouble.op_ImplicitBTD_Mod_Helper.Api.ModOptions.ModSettingDouble(float)'></a>

## ModSettingDouble.implicit operator ModSettingDouble(float) Operator

Constructs a new ModSetting with the given value as default

```csharp
public static BTD_Mod_Helper.Api.ModOptions.ModSettingDouble implicit operator ModSettingDouble(float value);
```
#### Parameters

<a name='BTD_Mod_Helper.Api.ModOptions.ModSettingDouble.op_ImplicitBTD_Mod_Helper.Api.ModOptions.ModSettingDouble(float).value'></a>

`value` [System.Single](https://docs.microsoft.com/en-us/dotnet/api/System.Single 'System.Single')

#### Returns
[ModSettingDouble](BTD_Mod_Helper.Api.ModOptions.ModSettingDouble.md 'BTD_Mod_Helper.Api.ModOptions.ModSettingDouble')

<a name='BTD_Mod_Helper.Api.ModOptions.ModSettingDouble.op_Implicitdouble(BTD_Mod_Helper.Api.ModOptions.ModSettingDouble)'></a>

## ModSettingDouble.implicit operator double(ModSettingDouble) Operator

Gets the current value out of a ModSetting

```csharp
public static double implicit operator double(BTD_Mod_Helper.Api.ModOptions.ModSettingDouble modSettingDouble);
```
#### Parameters

<a name='BTD_Mod_Helper.Api.ModOptions.ModSettingDouble.op_Implicitdouble(BTD_Mod_Helper.Api.ModOptions.ModSettingDouble).modSettingDouble'></a>

`modSettingDouble` [ModSettingDouble](BTD_Mod_Helper.Api.ModOptions.ModSettingDouble.md 'BTD_Mod_Helper.Api.ModOptions.ModSettingDouble')

#### Returns
[System.Double](https://docs.microsoft.com/en-us/dotnet/api/System.Double 'System.Double')

<a name='BTD_Mod_Helper.Api.ModOptions.ModSettingDouble.op_Implicitfloat(BTD_Mod_Helper.Api.ModOptions.ModSettingDouble)'></a>

## ModSettingDouble.implicit operator float(ModSettingDouble) Operator

Gets the current value out of a ModSetting

```csharp
public static float implicit operator float(BTD_Mod_Helper.Api.ModOptions.ModSettingDouble modSettingDouble);
```
#### Parameters

<a name='BTD_Mod_Helper.Api.ModOptions.ModSettingDouble.op_Implicitfloat(BTD_Mod_Helper.Api.ModOptions.ModSettingDouble).modSettingDouble'></a>

`modSettingDouble` [ModSettingDouble](BTD_Mod_Helper.Api.ModOptions.ModSettingDouble.md 'BTD_Mod_Helper.Api.ModOptions.ModSettingDouble')

#### Returns
[System.Single](https://docs.microsoft.com/en-us/dotnet/api/System.Single 'System.Single')