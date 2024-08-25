#### [BloonsTD6 Mod Helper](README.md 'README')
### [BTD_Mod_Helper.UI.Menus](README.md#BTD_Mod_Helper.UI.Menus 'BTD_Mod_Helper.UI.Menus')

## ModSettingsMenu Class

The ModGameMenu for Mod Settings

```csharp
public class ModSettingsMenu : BTD_Mod_Helper.Api.ModGameMenu<HotkeysScreen>
```

Inheritance [System.Object](https://docs.microsoft.com/en-us/dotnet/api/System.Object 'System.Object') &#129106; [ModContent](BTD_Mod_Helper.Api.ModContent.md 'BTD_Mod_Helper.Api.ModContent') &#129106; [ModGameMenu](BTD_Mod_Helper.Api.ModGameMenu.md 'BTD_Mod_Helper.Api.ModGameMenu') &#129106; [BTD_Mod_Helper.Api.ModGameMenu&lt;](BTD_Mod_Helper.Api.ModGameMenu_T_.md 'BTD_Mod_Helper.Api.ModGameMenu<T>')[Il2CppAssets.Scripts.Unity.UI_New.Settings.HotkeysScreen](https://docs.microsoft.com/en-us/dotnet/api/Il2CppAssets.Scripts.Unity.UI_New.Settings.HotkeysScreen 'Il2CppAssets.Scripts.Unity.UI_New.Settings.HotkeysScreen')[&gt;](BTD_Mod_Helper.Api.ModGameMenu_T_.md 'BTD_Mod_Helper.Api.ModGameMenu<T>') &#129106; ModSettingsMenu
### Properties

<a name='BTD_Mod_Helper.UI.Menus.ModSettingsMenu.BloonsMod'></a>

## ModSettingsMenu.BloonsMod Property

The most recent mod with opened settings

```csharp
public static BTD_Mod_Helper.BloonsMod BloonsMod { get; set; }
```

#### Property Value
[BloonsMod](BTD_Mod_Helper.BloonsMod.md 'BTD_Mod_Helper.BloonsMod')
### Methods

<a name='BTD_Mod_Helper.UI.Menus.ModSettingsMenu.OnMenuClosed()'></a>

## ModSettingsMenu.OnMenuClosed() Method

Runs right as your custom menu is being closed

```csharp
public override void OnMenuClosed();
```

<a name='BTD_Mod_Helper.UI.Menus.ModSettingsMenu.OnMenuOpened(Object)'></a>

## ModSettingsMenu.OnMenuOpened(Object) Method

Runs right as your custom menu is being opened, with the optional data argument that can be passed into  
[Open&lt;T&gt;(Object, Object)](BTD_Mod_Helper.Api.ModGameMenu.md#BTD_Mod_Helper.Api.ModGameMenu.Open_T_(Object,Object) 'BTD_Mod_Helper.Api.ModGameMenu.Open<T>(Object, Object)')

```csharp
public override bool OnMenuOpened(Object data);
```
#### Parameters

<a name='BTD_Mod_Helper.UI.Menus.ModSettingsMenu.OnMenuOpened(Object).data'></a>

`data` [Il2CppSystem.Object](https://docs.microsoft.com/en-us/dotnet/api/Il2CppSystem.Object 'Il2CppSystem.Object')

#### Returns
[System.Boolean](https://docs.microsoft.com/en-us/dotnet/api/System.Boolean 'System.Boolean')  
Whether to run the base menu's OnOpen code

<a name='BTD_Mod_Helper.UI.Menus.ModSettingsMenu.OnMenuUpdate()'></a>

## ModSettingsMenu.OnMenuUpdate() Method

Runs every time that your custom menu updates

```csharp
public override void OnMenuUpdate();
```

<a name='BTD_Mod_Helper.UI.Menus.ModSettingsMenu.Open(BTD_Mod_Helper.BloonsMod)'></a>

## ModSettingsMenu.Open(BloonsMod) Method

Opens the Mod Settings for a specific mod

```csharp
public static void Open(BTD_Mod_Helper.BloonsMod mod);
```
#### Parameters

<a name='BTD_Mod_Helper.UI.Menus.ModSettingsMenu.Open(BTD_Mod_Helper.BloonsMod).mod'></a>

`mod` [BloonsMod](BTD_Mod_Helper.BloonsMod.md 'BTD_Mod_Helper.BloonsMod')