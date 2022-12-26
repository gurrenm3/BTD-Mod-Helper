#### [BloonsTD6 Mod Helper](README.md 'README')
### [BTD_Mod_Helper.Api.Components](README.md#BTD_Mod_Helper.Api.Components 'BTD_Mod_Helper.Api.Components')

## ModHelperCategory Class

ModHelperComponent for a category in the mod settings menu

```csharp
public class ModHelperCategory : BTD_Mod_Helper.Api.Components.ModHelperOption
```

Inheritance [System.Object](https://docs.microsoft.com/en-us/dotnet/api/System.Object 'System.Object') &#129106; [Il2CppInterop.Runtime.InteropTypes.Il2CppObjectBase](https://docs.microsoft.com/en-us/dotnet/api/Il2CppInterop.Runtime.InteropTypes.Il2CppObjectBase 'Il2CppInterop.Runtime.InteropTypes.Il2CppObjectBase') &#129106; [Il2CppSystem.Object](https://docs.microsoft.com/en-us/dotnet/api/Il2CppSystem.Object 'Il2CppSystem.Object') &#129106; [UnityEngine.Object](https://docs.microsoft.com/en-us/dotnet/api/UnityEngine.Object 'UnityEngine.Object') &#129106; [UnityEngine.Component](https://docs.microsoft.com/en-us/dotnet/api/UnityEngine.Component 'UnityEngine.Component') &#129106; [UnityEngine.Behaviour](https://docs.microsoft.com/en-us/dotnet/api/UnityEngine.Behaviour 'UnityEngine.Behaviour') &#129106; [UnityEngine.MonoBehaviour](https://docs.microsoft.com/en-us/dotnet/api/UnityEngine.MonoBehaviour 'UnityEngine.MonoBehaviour') &#129106; [ModHelperComponent](BTD_Mod_Helper.Api.Components.ModHelperComponent.md 'BTD_Mod_Helper.Api.Components.ModHelperComponent') &#129106; [ModHelperOption](BTD_Mod_Helper.Api.Components.ModHelperOption.md 'BTD_Mod_Helper.Api.Components.ModHelperOption') &#129106; ModHelperCategory
### Fields

<a name='BTD_Mod_Helper.Api.Components.ModHelperCategory.collapsed'></a>

## ModHelperCategory.collapsed Field

Whether the category is hidden or not

```csharp
public bool collapsed;
```

#### Field Value
[System.Boolean](https://docs.microsoft.com/en-us/dotnet/api/System.Boolean 'System.Boolean')
### Properties

<a name='BTD_Mod_Helper.Api.Components.ModHelperCategory.CategoryContent'></a>

## ModHelperCategory.CategoryContent Property

The panel that holds all the mod settings

```csharp
public BTD_Mod_Helper.Api.Components.ModHelperPanel CategoryContent { get; }
```

#### Property Value
[ModHelperPanel](BTD_Mod_Helper.Api.Components.ModHelperPanel.md 'BTD_Mod_Helper.Api.Components.ModHelperPanel')
### Methods

<a name='BTD_Mod_Helper.Api.Components.ModHelperCategory.Create(string,bool,string)'></a>

## ModHelperCategory.Create(string, bool, string) Method

Creates a new ModHelperCategory

```csharp
public static BTD_Mod_Helper.Api.Components.ModHelperCategory Create(string displayName, bool collapsed, string icon=null);
```
#### Parameters

<a name='BTD_Mod_Helper.Api.Components.ModHelperCategory.Create(string,bool,string).displayName'></a>

`displayName` [System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')

The name of the category

<a name='BTD_Mod_Helper.Api.Components.ModHelperCategory.Create(string,bool,string).collapsed'></a>

`collapsed` [System.Boolean](https://docs.microsoft.com/en-us/dotnet/api/System.Boolean 'System.Boolean')

Whether it's collapsed by default or not

<a name='BTD_Mod_Helper.Api.Components.ModHelperCategory.Create(string,bool,string).icon'></a>

`icon` [System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')

The icon for the category, if any

#### Returns
[ModHelperCategory](BTD_Mod_Helper.Api.Components.ModHelperCategory.md 'BTD_Mod_Helper.Api.Components.ModHelperCategory')  
The created ModHelperCategory