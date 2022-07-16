#### [BloonsTD6 Mod Helper](index.md 'index')
### [BTD_Mod_Helper.Api.ModOptions](index.md#BTD_Mod_Helper.Api.ModOptions 'BTD_Mod_Helper.Api.ModOptions')

## ModSettingFolder Class

ModSetting for selecting a specific folder on the host computer

```csharp
public class ModSettingFolder : BTD_Mod_Helper.Api.ModOptions.ModSetting<string>
```

Inheritance [System.Object](https://docs.microsoft.com/en-us/dotnet/api/System.Object 'System.Object') &#129106; [ModSetting](BTD_Mod_Helper.Api.ModOptions.ModSetting.md 'BTD_Mod_Helper.Api.ModOptions.ModSetting') &#129106; [BTD_Mod_Helper.Api.ModOptions.ModSetting&lt;](BTD_Mod_Helper.Api.ModOptions.ModSetting_T_.md 'BTD_Mod_Helper.Api.ModOptions.ModSetting<T>')[System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')[&gt;](BTD_Mod_Helper.Api.ModOptions.ModSetting_T_.md 'BTD_Mod_Helper.Api.ModOptions.ModSetting<T>') &#129106; ModSettingFolder
### Methods

<a name='BTD_Mod_Helper.Api.ModOptions.ModSettingFolder.SetValue(object)'></a>

## ModSettingFolder.SetValue(object) Method

Sets the current value of this ModSetting

```csharp
public override void SetValue(object val);
```
#### Parameters

<a name='BTD_Mod_Helper.Api.ModOptions.ModSettingFolder.SetValue(object).val'></a>

`val` [System.Object](https://docs.microsoft.com/en-us/dotnet/api/System.Object 'System.Object')

The new value
### Operators

<a name='BTD_Mod_Helper.Api.ModOptions.ModSettingFolder.op_ImplicitBTD_Mod_Helper.Api.ModOptions.ModSettingFolder(string)'></a>

## ModSettingFolder.implicit operator ModSettingFolder(string) Operator

Constructs a new ModSetting with the given value as default

```csharp
public static BTD_Mod_Helper.Api.ModOptions.ModSettingFolder implicit operator ModSettingFolder(string value);
```
#### Parameters

<a name='BTD_Mod_Helper.Api.ModOptions.ModSettingFolder.op_ImplicitBTD_Mod_Helper.Api.ModOptions.ModSettingFolder(string).value'></a>

`value` [System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')

#### Returns
[ModSettingFolder](BTD_Mod_Helper.Api.ModOptions.ModSettingFolder.md 'BTD_Mod_Helper.Api.ModOptions.ModSettingFolder')

<a name='BTD_Mod_Helper.Api.ModOptions.ModSettingFolder.op_Implicitstring(BTD_Mod_Helper.Api.ModOptions.ModSettingFolder)'></a>

## ModSettingFolder.implicit operator string(ModSettingFolder) Operator

Gets the current value out of a ModSetting

```csharp
public static string implicit operator string(BTD_Mod_Helper.Api.ModOptions.ModSettingFolder modSettingFolder);
```
#### Parameters

<a name='BTD_Mod_Helper.Api.ModOptions.ModSettingFolder.op_Implicitstring(BTD_Mod_Helper.Api.ModOptions.ModSettingFolder).modSettingFolder'></a>

`modSettingFolder` [ModSettingFolder](BTD_Mod_Helper.Api.ModOptions.ModSettingFolder.md 'BTD_Mod_Helper.Api.ModOptions.ModSettingFolder')

#### Returns
[System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')