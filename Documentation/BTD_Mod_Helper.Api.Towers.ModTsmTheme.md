#### [BloonsTD6 Mod Helper](README.md 'README')
### [BTD_Mod_Helper.Api.Towers](README.md#BTD_Mod_Helper.Api.Towers 'BTD_Mod_Helper.Api.Towers')

## ModTsmTheme Class

ModContent for defining a new Tower Selection Menu Theme that towers can use.  
<example>  
  
towerModel.towerSelectionMenuThemeId = ModContent.GetId&lt;MyModTsmTheme&gt;();  
</code>

```csharp
public abstract class ModTsmTheme : BTD_Mod_Helper.Api.Towers.ModBaseTsmTheme
```

Inheritance [System.Object](https://docs.microsoft.com/en-us/dotnet/api/System.Object 'System.Object') &#129106; [ModContent](BTD_Mod_Helper.Api.ModContent.md 'BTD_Mod_Helper.Api.ModContent') &#129106; [ModBaseTsmTheme](BTD_Mod_Helper.Api.Towers.ModBaseTsmTheme.md 'BTD_Mod_Helper.Api.Towers.ModBaseTsmTheme') &#129106; ModTsmTheme
### Properties

<a name='BTD_Mod_Helper.Api.Towers.ModTsmTheme.BaseTheme'></a>

## ModTsmTheme.BaseTheme Property

Which TSM theme to use as a base defaults to "Default" for [Il2CppAssets.Scripts.Unity.UI_New.InGame.TowerSelectionMenu.TowerSelectionMenuThemes.TSMThemeDefault](https://docs.microsoft.com/en-us/dotnet/api/Il2CppAssets.Scripts.Unity.UI_New.InGame.TowerSelectionMenu.TowerSelectionMenuThemes.TSMThemeDefault 'Il2CppAssets.Scripts.Unity.UI_New.InGame.TowerSelectionMenu.TowerSelectionMenuThemes.TSMThemeDefault')

```csharp
public virtual string BaseTheme { get; }
```

#### Property Value
[System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')
### Methods

<a name='BTD_Mod_Helper.Api.Towers.ModTsmTheme.AppliesTo(string)'></a>

## ModTsmTheme.AppliesTo(string) Method

Whether to affect the theme based on the Id, defaults to always affecting

```csharp
public sealed override bool AppliesTo(string themeId);
```
#### Parameters

<a name='BTD_Mod_Helper.Api.Towers.ModTsmTheme.AppliesTo(string).themeId'></a>

`themeId` [System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')

string ID for the theme, same as [Il2CppAssets.Scripts.Models.Towers.TowerModel.towerSelectionMenuThemeId](https://docs.microsoft.com/en-us/dotnet/api/Il2CppAssets.Scripts.Models.Towers.TowerModel.towerSelectionMenuThemeId 'Il2CppAssets.Scripts.Models.Towers.TowerModel.towerSelectionMenuThemeId')

#### Returns
[System.Boolean](https://docs.microsoft.com/en-us/dotnet/api/System.Boolean 'System.Boolean')