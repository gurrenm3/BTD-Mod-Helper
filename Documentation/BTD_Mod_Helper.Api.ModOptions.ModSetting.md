#### [BloonsTD6 Mod Helper](README.md 'README')
### [BTD_Mod_Helper.Api.ModOptions](README.md#BTD_Mod_Helper.Api.ModOptions 'BTD_Mod_Helper.Api.ModOptions')

## ModSetting Class

Base class for a ModSetting without the generics

```csharp
public abstract class ModSetting
```

Inheritance [System.Object](https://docs.microsoft.com/en-us/dotnet/api/System.Object 'System.Object') &#129106; ModSetting

Derived  
&#8627; [ModSetting&lt;T&gt;](BTD_Mod_Helper.Api.ModOptions.ModSetting_T_.md 'BTD_Mod_Helper.Api.ModOptions.ModSetting<T>')
### Fields

<a name='BTD_Mod_Helper.Api.ModOptions.ModSetting.category'></a>

## ModSetting.category Field

The category that this is part of, or null

```csharp
public ModSettingCategory category;
```

#### Field Value
[ModSettingCategory](BTD_Mod_Helper.Api.ModOptions.ModSettingCategory.md 'BTD_Mod_Helper.Api.ModOptions.ModSettingCategory')

<a name='BTD_Mod_Helper.Api.ModOptions.ModSetting.description'></a>

## ModSetting.description Field

The description / explanation of this mod setting

```csharp
public string description;
```

#### Field Value
[System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')

<a name='BTD_Mod_Helper.Api.ModOptions.ModSetting.displayName'></a>

## ModSetting.displayName Field

The exact name displayed for this mod setting. If unset, will use the variable name.

```csharp
public string displayName;
```

#### Field Value
[System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')

<a name='BTD_Mod_Helper.Api.ModOptions.ModSetting.icon'></a>

## ModSetting.icon Field

Icon to display alongside the setting

```csharp
public SpriteReference icon;
```

#### Field Value
[Assets.Scripts.Utils.SpriteReference](https://docs.microsoft.com/en-us/dotnet/api/Assets.Scripts.Utils.SpriteReference 'Assets.Scripts.Utils.SpriteReference')

<a name='BTD_Mod_Helper.Api.ModOptions.ModSetting.modifyOption'></a>

## ModSetting.modifyOption Field

Action to modify the ModHelperOption after it's created

```csharp
public Action<ModHelperOption> modifyOption;
```

#### Field Value
[System.Action&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Action-1 'System.Action`1')[ModHelperOption](BTD_Mod_Helper.Api.Components.ModHelperOption.md 'BTD_Mod_Helper.Api.Components.ModHelperOption')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Action-1 'System.Action`1')

<a name='BTD_Mod_Helper.Api.ModOptions.ModSetting.requiresRestart'></a>

## ModSetting.requiresRestart Field

Indicates to players that the effects of changing this setting will only take place after a restart

```csharp
public bool requiresRestart;
```

#### Field Value
[System.Boolean](https://docs.microsoft.com/en-us/dotnet/api/System.Boolean 'System.Boolean')
### Methods

<a name='BTD_Mod_Helper.Api.ModOptions.ModSetting.GetDefaultValue()'></a>

## ModSetting.GetDefaultValue() Method

Gets the default value for this ModSetting

```csharp
public abstract object GetDefaultValue();
```

#### Returns
[System.Object](https://docs.microsoft.com/en-us/dotnet/api/System.Object 'System.Object')  
The default value

<a name='BTD_Mod_Helper.Api.ModOptions.ModSetting.GetValue()'></a>

## ModSetting.GetValue() Method

Gets the current value that this ModSetting holds

```csharp
public abstract object GetValue();
```

#### Returns
[System.Object](https://docs.microsoft.com/en-us/dotnet/api/System.Object 'System.Object')  
The value

<a name='BTD_Mod_Helper.Api.ModOptions.ModSetting.SetValue(object)'></a>

## ModSetting.SetValue(object) Method

Sets the current value of this ModSetting

```csharp
public abstract void SetValue(object val);
```
#### Parameters

<a name='BTD_Mod_Helper.Api.ModOptions.ModSetting.SetValue(object).val'></a>

`val` [System.Object](https://docs.microsoft.com/en-us/dotnet/api/System.Object 'System.Object')

The new value