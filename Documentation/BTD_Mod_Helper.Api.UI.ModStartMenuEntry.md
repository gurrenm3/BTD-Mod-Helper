#### [BloonsTD6 Mod Helper](README.md 'README')
### [BTD_Mod_Helper.Api.UI](README.md#BTD_Mod_Helper.Api.UI 'BTD_Mod_Helper.Api.UI')

## ModStartMenuEntry Class

ModContent representing an entry that will be added to the custom "Start Menu" in game, primarily used to open custom Windows

```csharp
public abstract class ModStartMenuEntry : BTD_Mod_Helper.Api.NamedModContent
```

Inheritance [System.Object](https://docs.microsoft.com/en-us/dotnet/api/System.Object 'System.Object') &#129106; [ModContent](BTD_Mod_Helper.Api.ModContent.md 'BTD_Mod_Helper.Api.ModContent') &#129106; [NamedModContent](BTD_Mod_Helper.Api.NamedModContent.md 'BTD_Mod_Helper.Api.NamedModContent') &#129106; ModStartMenuEntry

Derived  
&#8627; [ModStartMenuEntry&lt;T&gt;](BTD_Mod_Helper.Api.UI.ModStartMenuEntry_T_.md 'BTD_Mod_Helper.Api.UI.ModStartMenuEntry<T>')  
&#8627; [ModWindow](BTD_Mod_Helper.Api.UI.ModWindow.md 'BTD_Mod_Helper.Api.UI.ModWindow')
### Properties

<a name='BTD_Mod_Helper.Api.UI.ModStartMenuEntry.ChildEntries'></a>

## ModStartMenuEntry.ChildEntries Property

Entries nested beneath this entry

```csharp
public System.Collections.Generic.List<BTD_Mod_Helper.Api.UI.ModStartMenuEntry> ChildEntries { get; }
```

#### Property Value
[System.Collections.Generic.List&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.List-1 'System.Collections.Generic.List`1')[ModStartMenuEntry](BTD_Mod_Helper.Api.UI.ModStartMenuEntry.md 'BTD_Mod_Helper.Api.UI.ModStartMenuEntry')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.List-1 'System.Collections.Generic.List`1')

<a name='BTD_Mod_Helper.Api.UI.ModStartMenuEntry.DontAddToStartMenu'></a>

## ModStartMenuEntry.DontAddToStartMenu Property

Whether this entry should be hidden from the start menu

```csharp
public virtual bool DontAddToStartMenu { get; }
```

#### Property Value
[System.Boolean](https://docs.microsoft.com/en-us/dotnet/api/System.Boolean 'System.Boolean')

<a name='BTD_Mod_Helper.Api.UI.ModStartMenuEntry.Icon'></a>

## ModStartMenuEntry.Icon Property

SpriteReference to use for an icon. Null means no icon, empty string "" means a blank icon (still creates the margin for it within the option)

```csharp
public virtual string Icon { get; }
```

#### Property Value
[System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')

<a name='BTD_Mod_Helper.Api.UI.ModStartMenuEntry.IconScale'></a>

## ModStartMenuEntry.IconScale Property

Scale for the icon

```csharp
public virtual float IconScale { get; }
```

#### Property Value
[System.Single](https://docs.microsoft.com/en-us/dotnet/api/System.Single 'System.Single')

<a name='BTD_Mod_Helper.Api.UI.ModStartMenuEntry.ParentEntry'></a>

## ModStartMenuEntry.ParentEntry Property

The parent entry that this should be nested under

```csharp
public virtual BTD_Mod_Helper.Api.UI.ModStartMenuEntry ParentEntry { get; }
```

#### Property Value
[ModStartMenuEntry](BTD_Mod_Helper.Api.UI.ModStartMenuEntry.md 'BTD_Mod_Helper.Api.UI.ModStartMenuEntry')

<a name='BTD_Mod_Helper.Api.UI.ModStartMenuEntry.StartMenuEntry'></a>

## ModStartMenuEntry.StartMenuEntry Property

The Mod Helper [Info](BTD_Mod_Helper.Api.Components.Info.md 'BTD_Mod_Helper.Api.Components.Info') used to define the Start Menu entry

```csharp
public virtual BTD_Mod_Helper.Api.Components.Info StartMenuEntry { get; }
```

#### Property Value
[Info](BTD_Mod_Helper.Api.Components.Info.md 'BTD_Mod_Helper.Api.Components.Info')

<a name='BTD_Mod_Helper.Api.UI.ModStartMenuEntry.StartMenuEntryHeight'></a>

## ModStartMenuEntry.StartMenuEntryHeight Property

Height for the entry option within the Start Menu

```csharp
public virtual float StartMenuEntryHeight { get; }
```

#### Property Value
[System.Single](https://docs.microsoft.com/en-us/dotnet/api/System.Single 'System.Single')

<a name='BTD_Mod_Helper.Api.UI.ModStartMenuEntry.StartMenuEntryWidth'></a>

## ModStartMenuEntry.StartMenuEntryWidth Property

Width for the entry option within the Start Menu. 0 for automatic width

```csharp
public virtual float StartMenuEntryWidth { get; }
```

#### Property Value
[System.Single](https://docs.microsoft.com/en-us/dotnet/api/System.Single 'System.Single')
### Methods

<a name='BTD_Mod_Helper.Api.UI.ModStartMenuEntry.IsHidden()'></a>

## ModStartMenuEntry.IsHidden() Method

Whether this start menu entry should not appear in the menu at this time

```csharp
public virtual bool IsHidden();
```

#### Returns
[System.Boolean](https://docs.microsoft.com/en-us/dotnet/api/System.Boolean 'System.Boolean')  
whether it's hidden or not

<a name='BTD_Mod_Helper.Api.UI.ModStartMenuEntry.IsSelected()'></a>

## ModStartMenuEntry.IsSelected() Method

Whether this start menu entry should appear as selected in the menu.

```csharp
public virtual bool IsSelected();
```

#### Returns
[System.Boolean](https://docs.microsoft.com/en-us/dotnet/api/System.Boolean 'System.Boolean')  
whether it's selected or not

<a name='BTD_Mod_Helper.Api.UI.ModStartMenuEntry.StartMenuEntryClicked()'></a>

## ModStartMenuEntry.StartMenuEntryClicked() Method

What to do when the start menu entry is clicked. Not called if this has child entries

```csharp
public virtual void StartMenuEntryClicked();
```