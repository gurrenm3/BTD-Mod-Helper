#### [BloonsTD6 Mod Helper](README.md 'README')
### [BTD_Mod_Helper.Api.ModOptions](README.md#BTD_Mod_Helper.Api.ModOptions 'BTD_Mod_Helper.Api.ModOptions')

## ModSettingHotkey Class

ModSetting for a customizable Hotkey

```csharp
public class ModSettingHotkey : BTD_Mod_Helper.Api.ModOptions.ModSetting<string>
```

Inheritance [System.Object](https://docs.microsoft.com/en-us/dotnet/api/System.Object 'System.Object') &#129106; [ModSetting](BTD_Mod_Helper.Api.ModOptions.ModSetting.md 'BTD_Mod_Helper.Api.ModOptions.ModSetting') &#129106; [BTD_Mod_Helper.Api.ModOptions.ModSetting&lt;](BTD_Mod_Helper.Api.ModOptions.ModSetting_T_.md 'BTD_Mod_Helper.Api.ModOptions.ModSetting<T>')[System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')[&gt;](BTD_Mod_Helper.Api.ModOptions.ModSetting_T_.md 'BTD_Mod_Helper.Api.ModOptions.ModSetting<T>') &#129106; ModSettingHotkey
### Constructors

<a name='BTD_Mod_Helper.Api.ModOptions.ModSettingHotkey.ModSettingHotkey()'></a>

## ModSettingHotkey() Constructor

Initializes a new instance of the [System.Object](https://docs.microsoft.com/en-us/dotnet/api/System.Object 'System.Object') class.

```csharp
public ModSettingHotkey();
```
### Methods

<a name='BTD_Mod_Helper.Api.ModOptions.ModSettingHotkey.IsPressed()'></a>

## ModSettingHotkey.IsPressed() Method

Returns whether the Hotkey is currently being pressed / held

```csharp
public bool IsPressed();
```

#### Returns
[System.Boolean](https://docs.microsoft.com/en-us/dotnet/api/System.Boolean 'System.Boolean')

<a name='BTD_Mod_Helper.Api.ModOptions.ModSettingHotkey.JustPressed()'></a>

## ModSettingHotkey.JustPressed() Method

Returns whether the Hotkey was pressed down on this frame

```csharp
public bool JustPressed();
```

#### Returns
[System.Boolean](https://docs.microsoft.com/en-us/dotnet/api/System.Boolean 'System.Boolean')

<a name='BTD_Mod_Helper.Api.ModOptions.ModSettingHotkey.JustReleased()'></a>

## ModSettingHotkey.JustReleased() Method

Returns whether the Hotkey just went from being pressed to not being pressed on this frame

```csharp
public bool JustReleased();
```

#### Returns
[System.Boolean](https://docs.microsoft.com/en-us/dotnet/api/System.Boolean 'System.Boolean')

<a name='BTD_Mod_Helper.Api.ModOptions.ModSettingHotkey.SetValue(object)'></a>

## ModSettingHotkey.SetValue(object) Method

Sets the current value of this ModSetting

```csharp
public override void SetValue(object val);
```
#### Parameters

<a name='BTD_Mod_Helper.Api.ModOptions.ModSettingHotkey.SetValue(object).val'></a>

`val` [System.Object](https://docs.microsoft.com/en-us/dotnet/api/System.Object 'System.Object')

The new value
### Operators

<a name='BTD_Mod_Helper.Api.ModOptions.ModSettingHotkey.op_ImplicitBTD_Mod_Helper.Api.ModOptions.ModSettingHotkey(KeyCode)'></a>

## ModSettingHotkey.implicit operator ModSettingHotkey(KeyCode) Operator

Creates a new ModSettingHotkey from a KeyCode

```csharp
public static BTD_Mod_Helper.Api.ModOptions.ModSettingHotkey implicit operator ModSettingHotkey(KeyCode key);
```
#### Parameters

<a name='BTD_Mod_Helper.Api.ModOptions.ModSettingHotkey.op_ImplicitBTD_Mod_Helper.Api.ModOptions.ModSettingHotkey(KeyCode).key'></a>

`key` [UnityEngine.KeyCode](https://docs.microsoft.com/en-us/dotnet/api/UnityEngine.KeyCode 'UnityEngine.KeyCode')

#### Returns
[ModSettingHotkey](BTD_Mod_Helper.Api.ModOptions.ModSettingHotkey.md 'BTD_Mod_Helper.Api.ModOptions.ModSettingHotkey')