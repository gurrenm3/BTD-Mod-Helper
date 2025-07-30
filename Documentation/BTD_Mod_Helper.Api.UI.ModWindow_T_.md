#### [BloonsTD6 Mod Helper](README.md 'README')
### [BTD_Mod_Helper.Api.UI](README.md#BTD_Mod_Helper.Api.UI 'BTD_Mod_Helper.Api.UI')

## ModWindow<T> Class

Helper class for defining a ModWindow whose start menu entry is nested beneath another

```csharp
public abstract class ModWindow<T> : BTD_Mod_Helper.Api.UI.ModWindow
    where T : BTD_Mod_Helper.Api.UI.ModStartMenuEntry
```
#### Type parameters

<a name='BTD_Mod_Helper.Api.UI.ModWindow_T_.T'></a>

`T`

the parent Start Menu entry

Inheritance [System.Object](https://docs.microsoft.com/en-us/dotnet/api/System.Object 'System.Object') &#129106; [ModContent](BTD_Mod_Helper.Api.ModContent.md 'BTD_Mod_Helper.Api.ModContent') &#129106; [NamedModContent](BTD_Mod_Helper.Api.NamedModContent.md 'BTD_Mod_Helper.Api.NamedModContent') &#129106; [ModStartMenuEntry](BTD_Mod_Helper.Api.UI.ModStartMenuEntry.md 'BTD_Mod_Helper.Api.UI.ModStartMenuEntry') &#129106; [ModWindow](BTD_Mod_Helper.Api.UI.ModWindow.md 'BTD_Mod_Helper.Api.UI.ModWindow') &#129106; ModWindow<T>
### Properties

<a name='BTD_Mod_Helper.Api.UI.ModWindow_T_.ParentEntry'></a>

## ModWindow<T>.ParentEntry Property

The parent entry that this should be nested under

```csharp
public override BTD_Mod_Helper.Api.UI.ModStartMenuEntry ParentEntry { get; }
```

#### Property Value
[ModStartMenuEntry](BTD_Mod_Helper.Api.UI.ModStartMenuEntry.md 'BTD_Mod_Helper.Api.UI.ModStartMenuEntry')