#### [BloonsTD6 Mod Helper](README.md 'README')
### [BTD_Mod_Helper.Api.Data](README.md#BTD_Mod_Helper.Api.Data 'BTD_Mod_Helper.Api.Data')

## ModTextOverride Class

Class for dynamically overriding In-Game text in a way that's compatible with other mods

```csharp
public abstract class ModTextOverride : BTD_Mod_Helper.Api.ModContent
```

Inheritance [System.Object](https://docs.microsoft.com/en-us/dotnet/api/System.Object 'System.Object') &#129106; [ModContent](BTD_Mod_Helper.Api.ModContent.md 'BTD_Mod_Helper.Api.ModContent') &#129106; ModTextOverride

Derived  
&#8627; [ModMultiTextOverride](BTD_Mod_Helper.Api.Data.ModMultiTextOverride.md 'BTD_Mod_Helper.Api.Data.ModMultiTextOverride')
### Properties

<a name='BTD_Mod_Helper.Api.Data.ModTextOverride.Active'></a>

## ModTextOverride.Active Property

Whether this is active or not at the given moment (that the text is retrieved)

```csharp
public abstract bool Active { get; }
```

#### Property Value
[System.Boolean](https://docs.microsoft.com/en-us/dotnet/api/System.Boolean 'System.Boolean')

<a name='BTD_Mod_Helper.Api.Data.ModTextOverride.LocalizationKey'></a>

## ModTextOverride.LocalizationKey Property

The key within the localization text table that this replaces

```csharp
public abstract string LocalizationKey { get; }
```

#### Property Value
[System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')

<a name='BTD_Mod_Helper.Api.Data.ModTextOverride.TextValue'></a>

## ModTextOverride.TextValue Property

The text that will actually be returned if this is active

```csharp
public abstract string TextValue { get; }
```

#### Property Value
[System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')