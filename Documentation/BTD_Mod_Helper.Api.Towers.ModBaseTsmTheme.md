#### [BloonsTD6 Mod Helper](README.md 'README')
### [BTD_Mod_Helper.Api.Towers](README.md#BTD_Mod_Helper.Api.Towers 'BTD_Mod_Helper.Api.Towers')

## ModBaseTsmTheme Class

Base ModContent for making Tower Selection Menu Theme related additions

```csharp
public abstract class ModBaseTsmTheme : BTD_Mod_Helper.Api.ModContent
```

Inheritance [System.Object](https://docs.microsoft.com/en-us/dotnet/api/System.Object 'System.Object') &#129106; [ModContent](BTD_Mod_Helper.Api.ModContent.md 'BTD_Mod_Helper.Api.ModContent') &#129106; ModBaseTsmTheme

Derived  
&#8627; [ModTsmTheme](BTD_Mod_Helper.Api.Towers.ModTsmTheme.md 'BTD_Mod_Helper.Api.Towers.ModTsmTheme')  
&#8627; [ModVanillaTsmTheme](BTD_Mod_Helper.Api.Towers.ModVanillaTsmTheme.md 'BTD_Mod_Helper.Api.Towers.ModVanillaTsmTheme')
### Fields

<a name='BTD_Mod_Helper.Api.Towers.ModBaseTsmTheme.AboveArrowsY'></a>

## ModBaseTsmTheme.AboveArrowsY Field

Y position above the target type switch arrows, at which TSM Buttons are often placed

```csharp
public const int AboveArrowsY = -428;
```

#### Field Value
[System.Int32](https://docs.microsoft.com/en-us/dotnet/api/System.Int32 'System.Int32')

<a name='BTD_Mod_Helper.Api.Towers.ModBaseTsmTheme.DefaultButtonSize'></a>

## ModBaseTsmTheme.DefaultButtonSize Field

Default size for [Il2CppAssets.Scripts.Unity.UI_New.InGame.TowerSelectionMenu.TowerSelectionMenuThemes.TSMButton](https://docs.microsoft.com/en-us/dotnet/api/Il2CppAssets.Scripts.Unity.UI_New.InGame.TowerSelectionMenu.TowerSelectionMenuThemes.TSMButton 'Il2CppAssets.Scripts.Unity.UI_New.InGame.TowerSelectionMenu.TowerSelectionMenuThemes.TSMButton')s

```csharp
public const int DefaultButtonSize = 180;
```

#### Field Value
[System.Int32](https://docs.microsoft.com/en-us/dotnet/api/System.Int32 'System.Int32')

<a name='BTD_Mod_Helper.Api.Towers.ModBaseTsmTheme.DefaultButtonSpacing'></a>

## ModBaseTsmTheme.DefaultButtonSpacing Field

Default spacing between [Il2CppAssets.Scripts.Unity.UI_New.InGame.TowerSelectionMenu.TowerSelectionMenuThemes.TSMButton](https://docs.microsoft.com/en-us/dotnet/api/Il2CppAssets.Scripts.Unity.UI_New.InGame.TowerSelectionMenu.TowerSelectionMenuThemes.TSMButton 'Il2CppAssets.Scripts.Unity.UI_New.InGame.TowerSelectionMenu.TowerSelectionMenuThemes.TSMButton')s when there are multiple

```csharp
public const int DefaultButtonSpacing = 198;
```

#### Field Value
[System.Int32](https://docs.microsoft.com/en-us/dotnet/api/System.Int32 'System.Int32')

<a name='BTD_Mod_Helper.Api.Towers.ModBaseTsmTheme.DefaultIconSize'></a>

## ModBaseTsmTheme.DefaultIconSize Field

Default size for icons within [Il2CppAssets.Scripts.Unity.UI_New.InGame.TowerSelectionMenu.TowerSelectionMenuThemes.TSMButton](https://docs.microsoft.com/en-us/dotnet/api/Il2CppAssets.Scripts.Unity.UI_New.InGame.TowerSelectionMenu.TowerSelectionMenuThemes.TSMButton 'Il2CppAssets.Scripts.Unity.UI_New.InGame.TowerSelectionMenu.TowerSelectionMenuThemes.TSMButton')s

```csharp
public const int DefaultIconSize = 128;
```

#### Field Value
[System.Int32](https://docs.microsoft.com/en-us/dotnet/api/System.Int32 'System.Int32')

<a name='BTD_Mod_Helper.Api.Towers.ModBaseTsmTheme.LeftArrowX'></a>

## ModBaseTsmTheme.LeftArrowX Field

X position of the left target type switch arrow, at which TSM Buttons are often placed

```csharp
public const int LeftArrowX = -372;
```

#### Field Value
[System.Int32](https://docs.microsoft.com/en-us/dotnet/api/System.Int32 'System.Int32')

<a name='BTD_Mod_Helper.Api.Towers.ModBaseTsmTheme.RightArrowX'></a>

## ModBaseTsmTheme.RightArrowX Field

X position of the right target type switch arrow, at which TSM Buttons are often placed

```csharp
public const int RightArrowX = 372;
```

#### Field Value
[System.Int32](https://docs.microsoft.com/en-us/dotnet/api/System.Int32 'System.Int32')
### Methods

<a name='BTD_Mod_Helper.Api.Towers.ModBaseTsmTheme.AppliesTo(string)'></a>

## ModBaseTsmTheme.AppliesTo(string) Method

Whether to affect the theme based on the Id, defaults to always affecting

```csharp
public virtual bool AppliesTo(string themeId);
```
#### Parameters

<a name='BTD_Mod_Helper.Api.Towers.ModBaseTsmTheme.AppliesTo(string).themeId'></a>

`themeId` [System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')

string ID for the theme, same as [Il2CppAssets.Scripts.Models.Towers.TowerModel.towerSelectionMenuThemeId](https://docs.microsoft.com/en-us/dotnet/api/Il2CppAssets.Scripts.Models.Towers.TowerModel.towerSelectionMenuThemeId 'Il2CppAssets.Scripts.Models.Towers.TowerModel.towerSelectionMenuThemeId')

#### Returns
[System.Boolean](https://docs.microsoft.com/en-us/dotnet/api/System.Boolean 'System.Boolean')

<a name='BTD_Mod_Helper.Api.Towers.ModBaseTsmTheme.OnButtonPressed(BaseTSMTheme,TowerToSimulation,string)'></a>

## ModBaseTsmTheme.OnButtonPressed(BaseTSMTheme, TowerToSimulation, string) Method

Called when a [Il2CppAssets.Scripts.Unity.UI_New.InGame.TowerSelectionMenu.TowerSelectionMenuThemes.TSMButton](https://docs.microsoft.com/en-us/dotnet/api/Il2CppAssets.Scripts.Unity.UI_New.InGame.TowerSelectionMenu.TowerSelectionMenuThemes.TSMButton 'Il2CppAssets.Scripts.Unity.UI_New.InGame.TowerSelectionMenu.TowerSelectionMenuThemes.TSMButton') is pressed on this theme

```csharp
public virtual void OnButtonPressed(BaseTSMTheme theme, TowerToSimulation tower, string buttonId);
```
#### Parameters

<a name='BTD_Mod_Helper.Api.Towers.ModBaseTsmTheme.OnButtonPressed(BaseTSMTheme,TowerToSimulation,string).theme'></a>

`theme` [Il2CppAssets.Scripts.Unity.UI_New.InGame.TowerSelectionMenu.TowerSelectionMenuThemes.BaseTSMTheme](https://docs.microsoft.com/en-us/dotnet/api/Il2CppAssets.Scripts.Unity.UI_New.InGame.TowerSelectionMenu.TowerSelectionMenuThemes.BaseTSMTheme 'Il2CppAssets.Scripts.Unity.UI_New.InGame.TowerSelectionMenu.TowerSelectionMenuThemes.BaseTSMTheme')

BaseTSMTheme

<a name='BTD_Mod_Helper.Api.Towers.ModBaseTsmTheme.OnButtonPressed(BaseTSMTheme,TowerToSimulation,string).tower'></a>

`tower` [Il2CppAssets.Scripts.Unity.Bridge.TowerToSimulation](https://docs.microsoft.com/en-us/dotnet/api/Il2CppAssets.Scripts.Unity.Bridge.TowerToSimulation 'Il2CppAssets.Scripts.Unity.Bridge.TowerToSimulation')

tower

<a name='BTD_Mod_Helper.Api.Towers.ModBaseTsmTheme.OnButtonPressed(BaseTSMTheme,TowerToSimulation,string).buttonId'></a>

`buttonId` [System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')

id of the TSMButton

<a name='BTD_Mod_Helper.Api.Towers.ModBaseTsmTheme.OnDestroy(BaseTSMTheme)'></a>

## ModBaseTsmTheme.OnDestroy(BaseTSMTheme) Method

Unity lifecycle OnDestroy for the theme component

```csharp
public virtual void OnDestroy(BaseTSMTheme theme);
```
#### Parameters

<a name='BTD_Mod_Helper.Api.Towers.ModBaseTsmTheme.OnDestroy(BaseTSMTheme).theme'></a>

`theme` [Il2CppAssets.Scripts.Unity.UI_New.InGame.TowerSelectionMenu.TowerSelectionMenuThemes.BaseTSMTheme](https://docs.microsoft.com/en-us/dotnet/api/Il2CppAssets.Scripts.Unity.UI_New.InGame.TowerSelectionMenu.TowerSelectionMenuThemes.BaseTSMTheme 'Il2CppAssets.Scripts.Unity.UI_New.InGame.TowerSelectionMenu.TowerSelectionMenuThemes.BaseTSMTheme')

<a name='BTD_Mod_Helper.Api.Towers.ModBaseTsmTheme.OnDisable(BaseTSMTheme)'></a>

## ModBaseTsmTheme.OnDisable(BaseTSMTheme) Method

Unity lifecycle OnDisable for the theme component

```csharp
public virtual void OnDisable(BaseTSMTheme theme);
```
#### Parameters

<a name='BTD_Mod_Helper.Api.Towers.ModBaseTsmTheme.OnDisable(BaseTSMTheme).theme'></a>

`theme` [Il2CppAssets.Scripts.Unity.UI_New.InGame.TowerSelectionMenu.TowerSelectionMenuThemes.BaseTSMTheme](https://docs.microsoft.com/en-us/dotnet/api/Il2CppAssets.Scripts.Unity.UI_New.InGame.TowerSelectionMenu.TowerSelectionMenuThemes.BaseTSMTheme 'Il2CppAssets.Scripts.Unity.UI_New.InGame.TowerSelectionMenu.TowerSelectionMenuThemes.BaseTSMTheme')

<a name='BTD_Mod_Helper.Api.Towers.ModBaseTsmTheme.OnEnable(BaseTSMTheme)'></a>

## ModBaseTsmTheme.OnEnable(BaseTSMTheme) Method

Unity lifecycle OnEnable for the theme component

```csharp
public virtual void OnEnable(BaseTSMTheme theme);
```
#### Parameters

<a name='BTD_Mod_Helper.Api.Towers.ModBaseTsmTheme.OnEnable(BaseTSMTheme).theme'></a>

`theme` [Il2CppAssets.Scripts.Unity.UI_New.InGame.TowerSelectionMenu.TowerSelectionMenuThemes.BaseTSMTheme](https://docs.microsoft.com/en-us/dotnet/api/Il2CppAssets.Scripts.Unity.UI_New.InGame.TowerSelectionMenu.TowerSelectionMenuThemes.BaseTSMTheme 'Il2CppAssets.Scripts.Unity.UI_New.InGame.TowerSelectionMenu.TowerSelectionMenuThemes.BaseTSMTheme')

<a name='BTD_Mod_Helper.Api.Towers.ModBaseTsmTheme.SetupTheme(BaseTSMTheme)'></a>

## ModBaseTsmTheme.SetupTheme(BaseTSMTheme) Method

Called once the first time the theme is being setup, usually the first time a tower that uses it is selected

```csharp
public abstract void SetupTheme(BaseTSMTheme theme);
```
#### Parameters

<a name='BTD_Mod_Helper.Api.Towers.ModBaseTsmTheme.SetupTheme(BaseTSMTheme).theme'></a>

`theme` [Il2CppAssets.Scripts.Unity.UI_New.InGame.TowerSelectionMenu.TowerSelectionMenuThemes.BaseTSMTheme](https://docs.microsoft.com/en-us/dotnet/api/Il2CppAssets.Scripts.Unity.UI_New.InGame.TowerSelectionMenu.TowerSelectionMenuThemes.BaseTSMTheme 'Il2CppAssets.Scripts.Unity.UI_New.InGame.TowerSelectionMenu.TowerSelectionMenuThemes.BaseTSMTheme')

BaseTSMTheme

<a name='BTD_Mod_Helper.Api.Towers.ModBaseTsmTheme.TowerChanged(BaseTSMTheme,TowerToSimulation)'></a>

## ModBaseTsmTheme.TowerChanged(BaseTSMTheme, TowerToSimulation) Method

Called when the tower that uses this theme is changed, either from a change in which tower is selected or an update of that tower's info

```csharp
public virtual void TowerChanged(BaseTSMTheme theme, TowerToSimulation tower);
```
#### Parameters

<a name='BTD_Mod_Helper.Api.Towers.ModBaseTsmTheme.TowerChanged(BaseTSMTheme,TowerToSimulation).theme'></a>

`theme` [Il2CppAssets.Scripts.Unity.UI_New.InGame.TowerSelectionMenu.TowerSelectionMenuThemes.BaseTSMTheme](https://docs.microsoft.com/en-us/dotnet/api/Il2CppAssets.Scripts.Unity.UI_New.InGame.TowerSelectionMenu.TowerSelectionMenuThemes.BaseTSMTheme 'Il2CppAssets.Scripts.Unity.UI_New.InGame.TowerSelectionMenu.TowerSelectionMenuThemes.BaseTSMTheme')

BaseTSMTheme

<a name='BTD_Mod_Helper.Api.Towers.ModBaseTsmTheme.TowerChanged(BaseTSMTheme,TowerToSimulation).tower'></a>

`tower` [Il2CppAssets.Scripts.Unity.Bridge.TowerToSimulation](https://docs.microsoft.com/en-us/dotnet/api/Il2CppAssets.Scripts.Unity.Bridge.TowerToSimulation 'Il2CppAssets.Scripts.Unity.Bridge.TowerToSimulation')

tower

<a name='BTD_Mod_Helper.Api.Towers.ModBaseTsmTheme.Update(BaseTSMTheme)'></a>

## ModBaseTsmTheme.Update(BaseTSMTheme) Method

Unity lifecycle Update for the theme component

```csharp
public virtual void Update(BaseTSMTheme theme);
```
#### Parameters

<a name='BTD_Mod_Helper.Api.Towers.ModBaseTsmTheme.Update(BaseTSMTheme).theme'></a>

`theme` [Il2CppAssets.Scripts.Unity.UI_New.InGame.TowerSelectionMenu.TowerSelectionMenuThemes.BaseTSMTheme](https://docs.microsoft.com/en-us/dotnet/api/Il2CppAssets.Scripts.Unity.UI_New.InGame.TowerSelectionMenu.TowerSelectionMenuThemes.BaseTSMTheme 'Il2CppAssets.Scripts.Unity.UI_New.InGame.TowerSelectionMenu.TowerSelectionMenuThemes.BaseTSMTheme')