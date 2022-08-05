#### [BloonsTD6 Mod Helper](README.md 'README')
### [BTD_Mod_Helper.Api.ModOptions](README.md#BTD_Mod_Helper.Api.ModOptions 'BTD_Mod_Helper.Api.ModOptions')

## ModSettingCategory Class

Category of mod settings

```csharp
public class ModSettingCategory
```

Inheritance [System.Object](https://docs.microsoft.com/en-us/dotnet/api/System.Object 'System.Object') &#129106; ModSettingCategory
### Constructors

<a name='BTD_Mod_Helper.Api.ModOptions.ModSettingCategory.ModSettingCategory(string)'></a>

## ModSettingCategory(string) Constructor

Creates a new ModSettingCategory with the given displayName

```csharp
public ModSettingCategory(string displayName);
```
#### Parameters

<a name='BTD_Mod_Helper.Api.ModOptions.ModSettingCategory.ModSettingCategory(string).displayName'></a>

`displayName` [System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')
### Fields

<a name='BTD_Mod_Helper.Api.ModOptions.ModSettingCategory.collapsed'></a>

## ModSettingCategory.collapsed Field

Whether this category is currently collapsed / hiding its elements

```csharp
public bool collapsed;
```

#### Field Value
[System.Boolean](https://docs.microsoft.com/en-us/dotnet/api/System.Boolean 'System.Boolean')

<a name='BTD_Mod_Helper.Api.ModOptions.ModSettingCategory.displayName'></a>

## ModSettingCategory.displayName Field

Name of the category

```csharp
public string displayName;
```

#### Field Value
[System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')

<a name='BTD_Mod_Helper.Api.ModOptions.ModSettingCategory.icon'></a>

## ModSettingCategory.icon Field

Icon of the category, if any

```csharp
public string icon;
```

#### Field Value
[System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')

<a name='BTD_Mod_Helper.Api.ModOptions.ModSettingCategory.modifyCategory'></a>

## ModSettingCategory.modifyCategory Field

Action to modify the ModHelperCategory after it's created

```csharp
public Action<ModHelperCategory> modifyCategory;
```

#### Field Value
[System.Action&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Action-1 'System.Action`1')[ModHelperCategory](BTD_Mod_Helper.Api.Components.ModHelperCategory.md 'BTD_Mod_Helper.Api.Components.ModHelperCategory')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Action-1 'System.Action`1')

<a name='BTD_Mod_Helper.Api.ModOptions.ModSettingCategory.order'></a>

## ModSettingCategory.order Field

Order of this category in relation to other categories. A setting not having a category will have order = 0

```csharp
public int order;
```

#### Field Value
[System.Int32](https://docs.microsoft.com/en-us/dotnet/api/System.Int32 'System.Int32')
### Methods

<a name='BTD_Mod_Helper.Api.ModOptions.ModSettingCategory.Create()'></a>

## ModSettingCategory.Create() Method

Creates the visual ModHelperCategory for this option

```csharp
public BTD_Mod_Helper.Api.Components.ModHelperCategory Create();
```

#### Returns
[ModHelperCategory](BTD_Mod_Helper.Api.Components.ModHelperCategory.md 'BTD_Mod_Helper.Api.Components.ModHelperCategory')
### Operators

<a name='BTD_Mod_Helper.Api.ModOptions.ModSettingCategory.op_ImplicitBTD_Mod_Helper.Api.ModOptions.ModSettingCategory(string)'></a>

## ModSettingCategory.implicit operator ModSettingCategory(string) Operator

Creates a new category with the given name

```csharp
public static BTD_Mod_Helper.Api.ModOptions.ModSettingCategory implicit operator ModSettingCategory(string displayName);
```
#### Parameters

<a name='BTD_Mod_Helper.Api.ModOptions.ModSettingCategory.op_ImplicitBTD_Mod_Helper.Api.ModOptions.ModSettingCategory(string).displayName'></a>

`displayName` [System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')

#### Returns
[ModSettingCategory](BTD_Mod_Helper.Api.ModOptions.ModSettingCategory.md 'BTD_Mod_Helper.Api.ModOptions.ModSettingCategory')

<a name='BTD_Mod_Helper.Api.ModOptions.ModSettingCategory.op_Implicitstring(BTD_Mod_Helper.Api.ModOptions.ModSettingCategory)'></a>

## ModSettingCategory.implicit operator string(ModSettingCategory) Operator

Gets the name from a category

```csharp
public static string implicit operator string(BTD_Mod_Helper.Api.ModOptions.ModSettingCategory category);
```
#### Parameters

<a name='BTD_Mod_Helper.Api.ModOptions.ModSettingCategory.op_Implicitstring(BTD_Mod_Helper.Api.ModOptions.ModSettingCategory).category'></a>

`category` [ModSettingCategory](BTD_Mod_Helper.Api.ModOptions.ModSettingCategory.md 'BTD_Mod_Helper.Api.ModOptions.ModSettingCategory')

#### Returns
[System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')