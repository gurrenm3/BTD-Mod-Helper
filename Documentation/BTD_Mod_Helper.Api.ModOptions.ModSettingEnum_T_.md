#### [BloonsTD6 Mod Helper](index.md 'index')
### [BTD_Mod_Helper.Api.ModOptions](index.md#BTD_Mod_Helper.Api.ModOptions 'BTD_Mod_Helper.Api.ModOptions')

## ModSettingEnum<T> Class

ModSetting for an Enum value

```csharp
public class ModSettingEnum<T> : BTD_Mod_Helper.Api.ModOptions.ModSetting<T>
    where T : System.Enum
```
#### Type parameters

<a name='BTD_Mod_Helper.Api.ModOptions.ModSettingEnum_T_.T'></a>

`T`

The Enum in question

Inheritance [System.Object](https://docs.microsoft.com/en-us/dotnet/api/System.Object 'System.Object') &#129106; [ModSetting](BTD_Mod_Helper.Api.ModOptions.ModSetting.md 'BTD_Mod_Helper.Api.ModOptions.ModSetting') &#129106; [BTD_Mod_Helper.Api.ModOptions.ModSetting&lt;](BTD_Mod_Helper.Api.ModOptions.ModSetting_T_.md 'BTD_Mod_Helper.Api.ModOptions.ModSetting<T>')[T](BTD_Mod_Helper.Api.ModOptions.ModSettingEnum_T_.md#BTD_Mod_Helper.Api.ModOptions.ModSettingEnum_T_.T 'BTD_Mod_Helper.Api.ModOptions.ModSettingEnum<T>.T')[&gt;](BTD_Mod_Helper.Api.ModOptions.ModSetting_T_.md 'BTD_Mod_Helper.Api.ModOptions.ModSetting<T>') &#129106; ModSettingEnum<T>
### Constructors

<a name='BTD_Mod_Helper.Api.ModOptions.ModSettingEnum_T_.ModSettingEnum(T)'></a>

## ModSettingEnum(T) Constructor

Constructs a new ModSetting for the given value

```csharp
public ModSettingEnum(T value);
```
#### Parameters

<a name='BTD_Mod_Helper.Api.ModOptions.ModSettingEnum_T_.ModSettingEnum(T).value'></a>

`value` [T](BTD_Mod_Helper.Api.ModOptions.ModSettingEnum_T_.md#BTD_Mod_Helper.Api.ModOptions.ModSettingEnum_T_.T 'BTD_Mod_Helper.Api.ModOptions.ModSettingEnum<T>.T')
### Fields

<a name='BTD_Mod_Helper.Api.ModOptions.ModSettingEnum_T_.modifyDropdown'></a>

## ModSettingEnum<T>.modifyDropdown Field

Action to modify the ModHelperDropdown after it's created

```csharp
public Action<ModHelperDropdown> modifyDropdown;
```

#### Field Value
[System.Action&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Action-1 'System.Action`1')[ModHelperDropdown](BTD_Mod_Helper.Api.Components.ModHelperDropdown.md 'BTD_Mod_Helper.Api.Components.ModHelperDropdown')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Action-1 'System.Action`1')
### Operators

<a name='BTD_Mod_Helper.Api.ModOptions.ModSettingEnum_T_.op_ImplicitBTD_Mod_Helper.Api.ModOptions.ModSettingEnum_T_(T)'></a>

## ModSettingEnum<T>.implicit operator ModSettingEnum<T>(T) Operator

Constructs a new ModSetting with the given value as default

```csharp
public static BTD_Mod_Helper.Api.ModOptions.ModSettingEnum<T> implicit operator ModSettingEnum<T>(T value);
```
#### Parameters

<a name='BTD_Mod_Helper.Api.ModOptions.ModSettingEnum_T_.op_ImplicitBTD_Mod_Helper.Api.ModOptions.ModSettingEnum_T_(T).value'></a>

`value` [T](BTD_Mod_Helper.Api.ModOptions.ModSettingEnum_T_.md#BTD_Mod_Helper.Api.ModOptions.ModSettingEnum_T_.T 'BTD_Mod_Helper.Api.ModOptions.ModSettingEnum<T>.T')

#### Returns
[BTD_Mod_Helper.Api.ModOptions.ModSettingEnum&lt;](BTD_Mod_Helper.Api.ModOptions.ModSettingEnum_T_.md 'BTD_Mod_Helper.Api.ModOptions.ModSettingEnum<T>')[T](BTD_Mod_Helper.Api.ModOptions.ModSettingEnum_T_.md#BTD_Mod_Helper.Api.ModOptions.ModSettingEnum_T_.T 'BTD_Mod_Helper.Api.ModOptions.ModSettingEnum<T>.T')[&gt;](BTD_Mod_Helper.Api.ModOptions.ModSettingEnum_T_.md 'BTD_Mod_Helper.Api.ModOptions.ModSettingEnum<T>')

<a name='BTD_Mod_Helper.Api.ModOptions.ModSettingEnum_T_.op_ImplicitT(BTD_Mod_Helper.Api.ModOptions.ModSettingEnum_T_)'></a>

## ModSettingEnum<T>.implicit operator T(ModSettingEnum<T>) Operator

Gets the current value out of a ModSetting

```csharp
public static T implicit operator T(BTD_Mod_Helper.Api.ModOptions.ModSettingEnum<T> modSettingEnum);
```
#### Parameters

<a name='BTD_Mod_Helper.Api.ModOptions.ModSettingEnum_T_.op_ImplicitT(BTD_Mod_Helper.Api.ModOptions.ModSettingEnum_T_).modSettingEnum'></a>

`modSettingEnum` [BTD_Mod_Helper.Api.ModOptions.ModSettingEnum&lt;](BTD_Mod_Helper.Api.ModOptions.ModSettingEnum_T_.md 'BTD_Mod_Helper.Api.ModOptions.ModSettingEnum<T>')[T](BTD_Mod_Helper.Api.ModOptions.ModSettingEnum_T_.md#BTD_Mod_Helper.Api.ModOptions.ModSettingEnum_T_.T 'BTD_Mod_Helper.Api.ModOptions.ModSettingEnum<T>.T')[&gt;](BTD_Mod_Helper.Api.ModOptions.ModSettingEnum_T_.md 'BTD_Mod_Helper.Api.ModOptions.ModSettingEnum<T>')

#### Returns
[T](BTD_Mod_Helper.Api.ModOptions.ModSettingEnum_T_.md#BTD_Mod_Helper.Api.ModOptions.ModSettingEnum_T_.T 'BTD_Mod_Helper.Api.ModOptions.ModSettingEnum<T>.T')