#### [BloonsTD6 Mod Helper](README.md 'README')
### [BTD_Mod_Helper.UI.Menus](README.md#BTD_Mod_Helper.UI.Menus 'BTD_Mod_Helper.UI.Menus')

## ModsMenu Class

The ModGameMenu for the screen showing current mods

```csharp
public class ModsMenu : BTD_Mod_Helper.Api.ModGameMenu<ExtraSettingsScreen>
```

Inheritance [System.Object](https://docs.microsoft.com/en-us/dotnet/api/System.Object 'System.Object') &#129106; [ModContent](BTD_Mod_Helper.Api.ModContent.md 'BTD_Mod_Helper.Api.ModContent') &#129106; [ModGameMenu](BTD_Mod_Helper.Api.ModGameMenu.md 'BTD_Mod_Helper.Api.ModGameMenu') &#129106; [BTD_Mod_Helper.Api.ModGameMenu&lt;](BTD_Mod_Helper.Api.ModGameMenu_T_.md 'BTD_Mod_Helper.Api.ModGameMenu<T>')[Il2CppAssets.Scripts.Unity.UI_New.ChallengeEditor.ExtraSettingsScreen](https://docs.microsoft.com/en-us/dotnet/api/Il2CppAssets.Scripts.Unity.UI_New.ChallengeEditor.ExtraSettingsScreen 'Il2CppAssets.Scripts.Unity.UI_New.ChallengeEditor.ExtraSettingsScreen')[&gt;](BTD_Mod_Helper.Api.ModGameMenu_T_.md 'BTD_Mod_Helper.Api.ModGameMenu<T>') &#129106; ModsMenu
### Methods

<a name='BTD_Mod_Helper.UI.Menus.ModsMenu.OnMenuClosed()'></a>

## ModsMenu.OnMenuClosed() Method

Runs right as your custom menu is being closed

```csharp
public override void OnMenuClosed();
```

<a name='BTD_Mod_Helper.UI.Menus.ModsMenu.OnMenuOpened(Object)'></a>

## ModsMenu.OnMenuOpened(Object) Method

Runs right as your custom menu is being opened, with the optional data argument that can be passed into  
[Open&lt;T&gt;(Object, Object)](BTD_Mod_Helper.Api.ModGameMenu.md#BTD_Mod_Helper.Api.ModGameMenu.Open_T_(Object,Object) 'BTD_Mod_Helper.Api.ModGameMenu.Open<T>(Object, Object)')

```csharp
public override bool OnMenuOpened(Object data);
```
#### Parameters

<a name='BTD_Mod_Helper.UI.Menus.ModsMenu.OnMenuOpened(Object).data'></a>

`data` [Il2CppSystem.Object](https://docs.microsoft.com/en-us/dotnet/api/Il2CppSystem.Object 'Il2CppSystem.Object')

#### Returns
[System.Boolean](https://docs.microsoft.com/en-us/dotnet/api/System.Boolean 'System.Boolean')  
Whether to run the base menu's OnOpen code

<a name='BTD_Mod_Helper.UI.Menus.ModsMenu.OnMenuUpdate()'></a>

## ModsMenu.OnMenuUpdate() Method

Runs every time that your custom menu updates

```csharp
public override void OnMenuUpdate();
```