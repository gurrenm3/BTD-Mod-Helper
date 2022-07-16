#### [BloonsTD6 Mod Helper](index.md 'index')
### [BTD_Mod_Helper.Api.ModOptions](index.md#BTD_Mod_Helper.Api.ModOptions 'BTD_Mod_Helper.Api.ModOptions')

## ModSettingFile Class

ModSetting for selecting a specific file on the host computer

```csharp
public class ModSettingFile : BTD_Mod_Helper.Api.ModOptions.ModSetting<string>
```

Inheritance [System.Object](https://docs.microsoft.com/en-us/dotnet/api/System.Object 'System.Object') &#129106; [ModSetting](BTD_Mod_Helper.Api.ModOptions.ModSetting.md 'BTD_Mod_Helper.Api.ModOptions.ModSetting') &#129106; [BTD_Mod_Helper.Api.ModOptions.ModSetting&lt;](BTD_Mod_Helper.Api.ModOptions.ModSetting_T_.md 'BTD_Mod_Helper.Api.ModOptions.ModSetting<T>')[System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')[&gt;](BTD_Mod_Helper.Api.ModOptions.ModSetting_T_.md 'BTD_Mod_Helper.Api.ModOptions.ModSetting<T>') &#129106; ModSettingFile
### Fields

<a name='BTD_Mod_Helper.Api.ModOptions.ModSettingFile.filter'></a>

## ModSettingFile.filter Field

https://github.com/mlabbe/nativefiledialog/blob/master/README.md#file-filter-syntax

```csharp
public string filter;
```

#### Field Value
[System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')
### Methods

<a name='BTD_Mod_Helper.Api.ModOptions.ModSettingFile.SetValue(object)'></a>

## ModSettingFile.SetValue(object) Method

Sets the current value of this ModSetting

```csharp
public override void SetValue(object val);
```
#### Parameters

<a name='BTD_Mod_Helper.Api.ModOptions.ModSettingFile.SetValue(object).val'></a>

`val` [System.Object](https://docs.microsoft.com/en-us/dotnet/api/System.Object 'System.Object')

The new value
### Operators

<a name='BTD_Mod_Helper.Api.ModOptions.ModSettingFile.op_ImplicitBTD_Mod_Helper.Api.ModOptions.ModSettingFile(string)'></a>

## ModSettingFile.implicit operator ModSettingFile(string) Operator

Constructs a new ModSetting with the given value as default

```csharp
public static BTD_Mod_Helper.Api.ModOptions.ModSettingFile implicit operator ModSettingFile(string value);
```
#### Parameters

<a name='BTD_Mod_Helper.Api.ModOptions.ModSettingFile.op_ImplicitBTD_Mod_Helper.Api.ModOptions.ModSettingFile(string).value'></a>

`value` [System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')

#### Returns
[ModSettingFile](BTD_Mod_Helper.Api.ModOptions.ModSettingFile.md 'BTD_Mod_Helper.Api.ModOptions.ModSettingFile')

<a name='BTD_Mod_Helper.Api.ModOptions.ModSettingFile.op_Implicitstring(BTD_Mod_Helper.Api.ModOptions.ModSettingFile)'></a>

## ModSettingFile.implicit operator string(ModSettingFile) Operator

Gets the current value out of a ModSetting

```csharp
public static string implicit operator string(BTD_Mod_Helper.Api.ModOptions.ModSettingFile modSettingFile);
```
#### Parameters

<a name='BTD_Mod_Helper.Api.ModOptions.ModSettingFile.op_Implicitstring(BTD_Mod_Helper.Api.ModOptions.ModSettingFile).modSettingFile'></a>

`modSettingFile` [ModSettingFile](BTD_Mod_Helper.Api.ModOptions.ModSettingFile.md 'BTD_Mod_Helper.Api.ModOptions.ModSettingFile')

#### Returns
[System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')