#### [BloonsTD6 Mod Helper](README.md 'README')
### [BTD_Mod_Helper.Api.ModOptions](README.md#BTD_Mod_Helper.Api.ModOptions 'BTD_Mod_Helper.Api.ModOptions')

## ModSetting<T> Class

Class for keeping track of a variable for a Mod that can be changed in game via the Mod Settings menu

```csharp
public abstract class ModSetting<T> : BTD_Mod_Helper.Api.ModOptions.ModSetting
```
#### Type parameters

<a name='BTD_Mod_Helper.Api.ModOptions.ModSetting_T_.T'></a>

`T`

The type that this ModSetting holds

Inheritance [System.Object](https://docs.microsoft.com/en-us/dotnet/api/System.Object 'System.Object') &#129106; [ModSetting](BTD_Mod_Helper.Api.ModOptions.ModSetting.md 'BTD_Mod_Helper.Api.ModOptions.ModSetting') &#129106; ModSetting<T>

Derived  
&#8627; [ModSettingBool](BTD_Mod_Helper.Api.ModOptions.ModSettingBool.md 'BTD_Mod_Helper.Api.ModOptions.ModSettingBool')  
&#8627; [ModSettingEnum&lt;T&gt;](BTD_Mod_Helper.Api.ModOptions.ModSettingEnum_T_.md 'BTD_Mod_Helper.Api.ModOptions.ModSettingEnum<T>')  
&#8627; [ModSettingFile](BTD_Mod_Helper.Api.ModOptions.ModSettingFile.md 'BTD_Mod_Helper.Api.ModOptions.ModSettingFile')  
&#8627; [ModSettingFolder](BTD_Mod_Helper.Api.ModOptions.ModSettingFolder.md 'BTD_Mod_Helper.Api.ModOptions.ModSettingFolder')  
&#8627; [ModSettingHotkey](BTD_Mod_Helper.Api.ModOptions.ModSettingHotkey.md 'BTD_Mod_Helper.Api.ModOptions.ModSettingHotkey')  
&#8627; [ModSettingNumber&lt;T&gt;](BTD_Mod_Helper.Api.ModOptions.ModSettingNumber_T_.md 'BTD_Mod_Helper.Api.ModOptions.ModSettingNumber<T>')  
&#8627; [ModSettingString](BTD_Mod_Helper.Api.ModOptions.ModSettingString.md 'BTD_Mod_Helper.Api.ModOptions.ModSettingString')
### Constructors

<a name='BTD_Mod_Helper.Api.ModOptions.ModSetting_T_.ModSetting(T)'></a>

## ModSetting(T) Constructor

Constructs a new ModSetting for the given value

```csharp
protected ModSetting(T value);
```
#### Parameters

<a name='BTD_Mod_Helper.Api.ModOptions.ModSetting_T_.ModSetting(T).value'></a>

`value` [T](BTD_Mod_Helper.Api.ModOptions.ModSetting_T_.md#BTD_Mod_Helper.Api.ModOptions.ModSetting_T_.T 'BTD_Mod_Helper.Api.ModOptions.ModSetting<T>.T')
### Fields

<a name='BTD_Mod_Helper.Api.ModOptions.ModSetting_T_.customValidation'></a>

## ModSetting<T>.customValidation Field

Will only save the result and run onSave if this custom function validates the value

```csharp
public Func<T,bool> customValidation;
```

#### Field Value
[System.Func&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Func-2 'System.Func`2')[T](BTD_Mod_Helper.Api.ModOptions.ModSetting_T_.md#BTD_Mod_Helper.Api.ModOptions.ModSetting_T_.T 'BTD_Mod_Helper.Api.ModOptions.ModSetting<T>.T')[,](https://docs.microsoft.com/en-us/dotnet/api/System.Func-2 'System.Func`2')[System.Boolean](https://docs.microsoft.com/en-us/dotnet/api/System.Boolean 'System.Boolean')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Func-2 'System.Func`2')

<a name='BTD_Mod_Helper.Api.ModOptions.ModSetting_T_.onSave'></a>

## ModSetting<T>.onSave Field

Action to call when the value is saved, i.e. once they actually close the menu

```csharp
public Action<T> onSave;
```

#### Field Value
[System.Action&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Action-1 'System.Action`1')[T](BTD_Mod_Helper.Api.ModOptions.ModSetting_T_.md#BTD_Mod_Helper.Api.ModOptions.ModSetting_T_.T 'BTD_Mod_Helper.Api.ModOptions.ModSetting<T>.T')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Action-1 'System.Action`1')

<a name='BTD_Mod_Helper.Api.ModOptions.ModSetting_T_.onValueChanged'></a>

## ModSetting<T>.onValueChanged Field

Action to call when the value changes within the menu

```csharp
public Action<T> onValueChanged;
```

#### Field Value
[System.Action&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Action-1 'System.Action`1')[T](BTD_Mod_Helper.Api.ModOptions.ModSetting_T_.md#BTD_Mod_Helper.Api.ModOptions.ModSetting_T_.T 'BTD_Mod_Helper.Api.ModOptions.ModSetting<T>.T')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Action-1 'System.Action`1')
### Properties

<a name='BTD_Mod_Helper.Api.ModOptions.ModSetting_T_.OnValueChanged'></a>

## ModSetting<T>.OnValueChanged Property

Old onValueChanged.

```csharp
public System.Collections.Generic.List<System.Action<T>> OnValueChanged { get; set; }
```

#### Property Value
[System.Collections.Generic.List&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.List-1 'System.Collections.Generic.List`1')[System.Action&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Action-1 'System.Action`1')[T](BTD_Mod_Helper.Api.ModOptions.ModSetting_T_.md#BTD_Mod_Helper.Api.ModOptions.ModSetting_T_.T 'BTD_Mod_Helper.Api.ModOptions.ModSetting<T>.T')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Action-1 'System.Action`1')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.List-1 'System.Collections.Generic.List`1')
### Methods

<a name='BTD_Mod_Helper.Api.ModOptions.ModSetting_T_.GetDefaultValue()'></a>

## ModSetting<T>.GetDefaultValue() Method

Gets the default value for this ModSetting

```csharp
public override object GetDefaultValue();
```

#### Returns
[System.Object](https://docs.microsoft.com/en-us/dotnet/api/System.Object 'System.Object')  
The default value

<a name='BTD_Mod_Helper.Api.ModOptions.ModSetting_T_.GetLastSavedValue()'></a>

## ModSetting<T>.GetLastSavedValue() Method

Gets the last saved value for this ModSetting

```csharp
public override object GetLastSavedValue();
```

#### Returns
[System.Object](https://docs.microsoft.com/en-us/dotnet/api/System.Object 'System.Object')  
The last saved value

<a name='BTD_Mod_Helper.Api.ModOptions.ModSetting_T_.GetValue()'></a>

## ModSetting<T>.GetValue() Method

Gets the current value that this ModSetting holds

```csharp
public override object GetValue();
```

#### Returns
[System.Object](https://docs.microsoft.com/en-us/dotnet/api/System.Object 'System.Object')  
The value

<a name='BTD_Mod_Helper.Api.ModOptions.ModSetting_T_.SetValue(object)'></a>

## ModSetting<T>.SetValue(object) Method

Sets the current value of this ModSetting

```csharp
public override void SetValue(object val);
```
#### Parameters

<a name='BTD_Mod_Helper.Api.ModOptions.ModSetting_T_.SetValue(object).val'></a>

`val` [System.Object](https://docs.microsoft.com/en-us/dotnet/api/System.Object 'System.Object')

The new value