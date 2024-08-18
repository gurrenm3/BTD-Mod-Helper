#### [BloonsTD6 Mod Helper](README.md 'README')
### [BTD_Mod_Helper.Extensions](README.md#BTD_Mod_Helper.Extensions 'BTD_Mod_Helper.Extensions')

## StringExt Class

Extensions for strings

```csharp
public static class StringExt
```

Inheritance [System.Object](https://docs.microsoft.com/en-us/dotnet/api/System.Object 'System.Object') &#129106; StringExt
### Methods

<a name='BTD_Mod_Helper.Extensions.StringExt.GetBtd6Localization(thisstring,bool)'></a>

## StringExt.GetBtd6Localization(this string, bool) Method

Gets the localization from the current localization text table, or the default one if it's not present in the current one.   
If the id is not present in any of these, returned as spaced or not spaced depending on parameters.

```csharp
public static string GetBtd6Localization(this string id, bool returnAsSpacedIfNoEntry=true);
```
#### Parameters

<a name='BTD_Mod_Helper.Extensions.StringExt.GetBtd6Localization(thisstring,bool).id'></a>

`id` [System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')

The ID of the thing you're trying to get the localization of.

<a name='BTD_Mod_Helper.Extensions.StringExt.GetBtd6Localization(thisstring,bool).returnAsSpacedIfNoEntry'></a>

`returnAsSpacedIfNoEntry` [System.Boolean](https://docs.microsoft.com/en-us/dotnet/api/System.Boolean 'System.Boolean')

Should this return the id with spaces if there's no localization present?

#### Returns
[System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')

<a name='BTD_Mod_Helper.Extensions.StringExt.Localize(thisstring)'></a>

## StringExt.Localize(this string) Method

Gets the localization from the current localization text table, or the default one if it's not present in the current one.   
If the id is not present in any of these, returned as spaced or not spaced depending on parameters.

```csharp
public static string Localize(this string id);
```
#### Parameters

<a name='BTD_Mod_Helper.Extensions.StringExt.Localize(thisstring).id'></a>

`id` [System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')

The ID of the thing you're trying to get the localization of.

#### Returns
[System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')

<a name='BTD_Mod_Helper.Extensions.StringExt.NullIfEmpty(thisstring)'></a>

## StringExt.NullIfEmpty(this string) Method

Returns null if a string is empty / whitespace, otherwise just returns back the string

```csharp
public static string NullIfEmpty(this string s);
```
#### Parameters

<a name='BTD_Mod_Helper.Extensions.StringExt.NullIfEmpty(thisstring).s'></a>

`s` [System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')

#### Returns
[System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')

<a name='BTD_Mod_Helper.Extensions.StringExt.RegexReplace(thisstring,string,string)'></a>

## StringExt.RegexReplace(this string, string, string) Method

<inheritdoc cref="M:System.Text.RegularExpressions.Regex.Replace(System.String,System.String,System.String)"/>

```csharp
public static string RegexReplace(this string input, string pattern, string replacement);
```
#### Parameters

<a name='BTD_Mod_Helper.Extensions.StringExt.RegexReplace(thisstring,string,string).input'></a>

`input` [System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')

<a name='BTD_Mod_Helper.Extensions.StringExt.RegexReplace(thisstring,string,string).pattern'></a>

`pattern` [System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')

<a name='BTD_Mod_Helper.Extensions.StringExt.RegexReplace(thisstring,string,string).replacement'></a>

`replacement` [System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')

#### Returns
[System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')

<a name='BTD_Mod_Helper.Extensions.StringExt.Spaced(thisstring)'></a>

## StringExt.Spaced(this string) Method

Puts spaces between capitalized words within a string

```csharp
public static string Spaced(this string s);
```
#### Parameters

<a name='BTD_Mod_Helper.Extensions.StringExt.Spaced(thisstring).s'></a>

`s` [System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')

#### Returns
[System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')

<a name='BTD_Mod_Helper.Extensions.StringExt.ToTitleCase(thisstring)'></a>

## StringExt.ToTitleCase(this string) Method

<inheritdoc cref="M:System.Globalization.TextInfo.ToTitleCase(System.String)"/>

```csharp
public static string ToTitleCase(this string input);
```
#### Parameters

<a name='BTD_Mod_Helper.Extensions.StringExt.ToTitleCase(thisstring).input'></a>

`input` [System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')

#### Returns
[System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')