#### [BloonsTD6 Mod Helper](README.md 'README')
### [BTD_Mod_Helper.Api.Data](README.md#BTD_Mod_Helper.Api.Data 'BTD_Mod_Helper.Api.Data')

## ModMultiTextOverride Class

A bunch of ModTextOverrides that all share the same Active condition and don't require any on the fly determinations of  
their text

```csharp
public abstract class ModMultiTextOverride : BTD_Mod_Helper.Api.Data.ModTextOverride
```

Inheritance [System.Object](https://docs.microsoft.com/en-us/dotnet/api/System.Object 'System.Object') &#129106; [ModContent](BTD_Mod_Helper.Api.ModContent.md 'BTD_Mod_Helper.Api.ModContent') &#129106; [ModTextOverride](BTD_Mod_Helper.Api.Data.ModTextOverride.md 'BTD_Mod_Helper.Api.Data.ModTextOverride') &#129106; ModMultiTextOverride
### Properties

<a name='BTD_Mod_Helper.Api.Data.ModMultiTextOverride.KeyPrefix'></a>

## ModMultiTextOverride.KeyPrefix Property

Suffix added to all keys in the table, by default nothing ""

```csharp
public virtual string KeyPrefix { get; }
```

#### Property Value
[System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')

<a name='BTD_Mod_Helper.Api.Data.ModMultiTextOverride.KeySuffix'></a>

## ModMultiTextOverride.KeySuffix Property

Suffix added to all keys in the table, by default nothing ""

```csharp
public virtual string KeySuffix { get; }
```

#### Property Value
[System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')

<a name='BTD_Mod_Helper.Api.Data.ModMultiTextOverride.LocalizationKey'></a>

## ModMultiTextOverride.LocalizationKey Property

The key within the localization text table that this replaces

```csharp
public sealed override string LocalizationKey { get; }
```

#### Property Value
[System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')

<a name='BTD_Mod_Helper.Api.Data.ModMultiTextOverride.Table'></a>

## ModMultiTextOverride.Table Property

The table of keys and values

```csharp
public abstract System.Collections.Generic.Dictionary<string,string> Table { get; }
```

#### Property Value
[System.Collections.Generic.Dictionary&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.Dictionary-2 'System.Collections.Generic.Dictionary`2')[System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')[,](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.Dictionary-2 'System.Collections.Generic.Dictionary`2')[System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.Dictionary-2 'System.Collections.Generic.Dictionary`2')

<a name='BTD_Mod_Helper.Api.Data.ModMultiTextOverride.TextValue'></a>

## ModMultiTextOverride.TextValue Property

The text that will actually be returned if this is active

```csharp
public sealed override string TextValue { get; }
```

#### Property Value
[System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')