#### [BloonsTD6 Mod Helper](README.md 'README')
### [BTD_Mod_Helper.Api](README.md#BTD_Mod_Helper.Api 'BTD_Mod_Helper.Api')

## ModGameMenu<T> Class

Generic class for creating a ModGameMenu with the given type as it's base menu

```csharp
public abstract class ModGameMenu<T> : BTD_Mod_Helper.Api.ModGameMenu
    where T : GameMenu
```
#### Type parameters

<a name='BTD_Mod_Helper.Api.ModGameMenu_T_.T'></a>

`T`

Inheritance [System.Object](https://docs.microsoft.com/en-us/dotnet/api/System.Object 'System.Object') &#129106; [ModContent](BTD_Mod_Helper.Api.ModContent.md 'BTD_Mod_Helper.Api.ModContent') &#129106; [ModGameMenu](BTD_Mod_Helper.Api.ModGameMenu.md 'BTD_Mod_Helper.Api.ModGameMenu') &#129106; ModGameMenu<T>

Derived  
&#8627; [ModsMenu](BTD_Mod_Helper.UI.Menus.ModsMenu.md 'BTD_Mod_Helper.UI.Menus.ModsMenu')
### Properties

<a name='BTD_Mod_Helper.Api.ModGameMenu_T_.BaseMenu'></a>

## ModGameMenu<T>.BaseMenu Property

The string name of the in game menu to copy from

```csharp
public override string BaseMenu { get; }
```

#### Property Value
[System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')

<a name='BTD_Mod_Helper.Api.ModGameMenu_T_.GameMenu'></a>

## ModGameMenu<T>.GameMenu Property

The current GameMenu

```csharp
public T GameMenu { get; }
```

#### Property Value
[T](BTD_Mod_Helper.Api.ModGameMenu_T_.md#BTD_Mod_Helper.Api.ModGameMenu_T_.T 'BTD_Mod_Helper.Api.ModGameMenu<T>.T')