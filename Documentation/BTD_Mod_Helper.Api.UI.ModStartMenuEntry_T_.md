#### [BloonsTD6 Mod Helper](README.md 'README')
### [BTD_Mod_Helper.Api.UI](README.md#BTD_Mod_Helper.Api.UI 'BTD_Mod_Helper.Api.UI')

## ModStartMenuEntry<T> Class

Helper class for a ModStartMenuEntry that is nested beneath another entry

```csharp
public abstract class ModStartMenuEntry<T> : BTD_Mod_Helper.Api.UI.ModStartMenuEntry
    where T : BTD_Mod_Helper.Api.UI.ModStartMenuEntry
```
#### Type parameters

<a name='BTD_Mod_Helper.Api.UI.ModStartMenuEntry_T_.T'></a>

`T`

Inheritance [System.Object](https://docs.microsoft.com/en-us/dotnet/api/System.Object 'System.Object') &#129106; [ModContent](BTD_Mod_Helper.Api.ModContent.md 'BTD_Mod_Helper.Api.ModContent') &#129106; [NamedModContent](BTD_Mod_Helper.Api.NamedModContent.md 'BTD_Mod_Helper.Api.NamedModContent') &#129106; [ModStartMenuEntry](BTD_Mod_Helper.Api.UI.ModStartMenuEntry.md 'BTD_Mod_Helper.Api.UI.ModStartMenuEntry') &#129106; ModStartMenuEntry<T>
### Properties

<a name='BTD_Mod_Helper.Api.UI.ModStartMenuEntry_T_.ParentEntry'></a>

## ModStartMenuEntry<T>.ParentEntry Property

The parent entry that this should be nested under

```csharp
public override BTD_Mod_Helper.Api.UI.ModStartMenuEntry ParentEntry { get; }
```

#### Property Value
[ModStartMenuEntry](BTD_Mod_Helper.Api.UI.ModStartMenuEntry.md 'BTD_Mod_Helper.Api.UI.ModStartMenuEntry')