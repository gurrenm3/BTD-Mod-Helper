#### [BloonsTD6 Mod Helper](README.md 'README')
### [BTD_Mod_Helper.Api](README.md#BTD_Mod_Helper.Api 'BTD_Mod_Helper.Api')

## ModGameMenu Class

Class for a custom BTD6 menu

```csharp
public abstract class ModGameMenu : BTD_Mod_Helper.Api.ModContent
```

Inheritance [System.Object](https://docs.microsoft.com/en-us/dotnet/api/System.Object 'System.Object') &#129106; [ModContent](BTD_Mod_Helper.Api.ModContent.md 'BTD_Mod_Helper.Api.ModContent') &#129106; ModGameMenu

Derived  
&#8627; [ModGameMenu&lt;T&gt;](BTD_Mod_Helper.Api.ModGameMenu_T_.md 'BTD_Mod_Helper.Api.ModGameMenu<T>')
### Properties

<a name='BTD_Mod_Helper.Api.ModGameMenu.BaseMenu'></a>

## ModGameMenu.BaseMenu Property

The string name of the in game menu to copy from

```csharp
public abstract string BaseMenu { get; }
```

#### Property Value
[System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')

<a name='BTD_Mod_Helper.Api.ModGameMenu.CommonForegroundHeader'></a>

## ModGameMenu.CommonForegroundHeader Property

The text of the Header component that's on many UI screens, might be null

```csharp
protected NK_TextMeshProUGUI CommonForegroundHeader { get; }
```

#### Property Value
[Il2Cpp.NK_TextMeshProUGUI](https://docs.microsoft.com/en-us/dotnet/api/Il2Cpp.NK_TextMeshProUGUI 'Il2Cpp.NK_TextMeshProUGUI')

<a name='BTD_Mod_Helper.Api.ModGameMenu.GameMenu'></a>

## ModGameMenu.GameMenu Property

The current GameMenu

```csharp
public GameMenu GameMenu { get; set; }
```

#### Property Value
[Il2CppAssets.Scripts.Unity.Menu.GameMenu](https://docs.microsoft.com/en-us/dotnet/api/Il2CppAssets.Scripts.Unity.Menu.GameMenu 'Il2CppAssets.Scripts.Unity.Menu.GameMenu')

<a name='BTD_Mod_Helper.Api.ModGameMenu.IsOpen'></a>

## ModGameMenu.IsOpen Property

Whether this Menu is open or not

```csharp
public bool IsOpen { get; set; }
```

#### Property Value
[System.Boolean](https://docs.microsoft.com/en-us/dotnet/api/System.Boolean 'System.Boolean')
### Methods

<a name='BTD_Mod_Helper.Api.ModGameMenu.MenuName_T_()'></a>

## ModGameMenu.MenuName<T>() Method

The name NinjaKiwi gave to the menu of the given screen type

```csharp
protected static string MenuName<T>()
    where T : GameMenu;
```
#### Type parameters

<a name='BTD_Mod_Helper.Api.ModGameMenu.MenuName_T_().T'></a>

`T`

#### Returns
[System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')

<a name='BTD_Mod_Helper.Api.ModGameMenu.OnMenuClosed()'></a>

## ModGameMenu.OnMenuClosed() Method

Runs right as your custom menu is being closed

```csharp
public virtual void OnMenuClosed();
```

<a name='BTD_Mod_Helper.Api.ModGameMenu.OnMenuOpened(Object)'></a>

## ModGameMenu.OnMenuOpened(Object) Method

Runs right as your custom menu is being opened, with the optional data argument that can be passed into  
[Open&lt;T&gt;(Object, Object)](BTD_Mod_Helper.Api.ModGameMenu.md#BTD_Mod_Helper.Api.ModGameMenu.Open_T_(Object,Object) 'BTD_Mod_Helper.Api.ModGameMenu.Open<T>(Object, Object)')

```csharp
public abstract bool OnMenuOpened(Object data);
```
#### Parameters

<a name='BTD_Mod_Helper.Api.ModGameMenu.OnMenuOpened(Object).data'></a>

`data` [Il2CppSystem.Object](https://docs.microsoft.com/en-us/dotnet/api/Il2CppSystem.Object 'Il2CppSystem.Object')

#### Returns
[System.Boolean](https://docs.microsoft.com/en-us/dotnet/api/System.Boolean 'System.Boolean')  
Whether to run the base menu's OnOpen code

<a name='BTD_Mod_Helper.Api.ModGameMenu.OnMenuUpdate()'></a>

## ModGameMenu.OnMenuUpdate() Method

Runs every time that your custom menu updates

```csharp
public virtual void OnMenuUpdate();
```

<a name='BTD_Mod_Helper.Api.ModGameMenu.Open(Object,Object)'></a>

## ModGameMenu.Open(Object, Object) Method

Opens this menu

```csharp
public void Open(Object data=null, Object baseData=null);
```
#### Parameters

<a name='BTD_Mod_Helper.Api.ModGameMenu.Open(Object,Object).data'></a>

`data` [Il2CppSystem.Object](https://docs.microsoft.com/en-us/dotnet/api/Il2CppSystem.Object 'Il2CppSystem.Object')

The custom data to pass into your ModGameMenu's [OnMenuOpened(Object)](BTD_Mod_Helper.Api.ModGameMenu.md#BTD_Mod_Helper.Api.ModGameMenu.OnMenuOpened(Object) 'BTD_Mod_Helper.Api.ModGameMenu.OnMenuOpened(Object)') method

<a name='BTD_Mod_Helper.Api.ModGameMenu.Open(Object,Object).baseData'></a>

`baseData` [Il2CppSystem.Object](https://docs.microsoft.com/en-us/dotnet/api/Il2CppSystem.Object 'Il2CppSystem.Object')

The data that you want to pass into the base menu's Open method, if you're still running the  
code

<a name='BTD_Mod_Helper.Api.ModGameMenu.Open_T_(Object,Object)'></a>

## ModGameMenu.Open<T>(Object, Object) Method

Opens a custom menu

```csharp
public static void Open<T>(Object data=null, Object baseData=null)
    where T : BTD_Mod_Helper.Api.ModGameMenu;
```
#### Type parameters

<a name='BTD_Mod_Helper.Api.ModGameMenu.Open_T_(Object,Object).T'></a>

`T`

The custom menu type to open
#### Parameters

<a name='BTD_Mod_Helper.Api.ModGameMenu.Open_T_(Object,Object).data'></a>

`data` [Il2CppSystem.Object](https://docs.microsoft.com/en-us/dotnet/api/Il2CppSystem.Object 'Il2CppSystem.Object')

The custom data to pass into your ModGameMenu's [OnMenuOpened(Object)](BTD_Mod_Helper.Api.ModGameMenu.md#BTD_Mod_Helper.Api.ModGameMenu.OnMenuOpened(Object) 'BTD_Mod_Helper.Api.ModGameMenu.OnMenuOpened(Object)') method

<a name='BTD_Mod_Helper.Api.ModGameMenu.Open_T_(Object,Object).baseData'></a>

`baseData` [Il2CppSystem.Object](https://docs.microsoft.com/en-us/dotnet/api/Il2CppSystem.Object 'Il2CppSystem.Object')

The data that you want to pass into the base menu's Open method, if you're still running the  
code