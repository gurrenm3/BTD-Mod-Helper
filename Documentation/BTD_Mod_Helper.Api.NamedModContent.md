#### [BloonsTD6 Mod Helper](README.md 'README')
### [BTD_Mod_Helper.Api](README.md#BTD_Mod_Helper.Api 'BTD_Mod_Helper.Api')

## NamedModContent Class

ModContent with DisplayName and Description that registers values in the LocalizationManger's textTable

```csharp
public abstract class NamedModContent : BTD_Mod_Helper.Api.ModContent
```

Inheritance [System.Object](https://docs.microsoft.com/en-us/dotnet/api/System.Object 'System.Object') &#129106; [ModContent](BTD_Mod_Helper.Api.ModContent.md 'BTD_Mod_Helper.Api.ModContent') &#129106; NamedModContent

Derived  
&#8627; [ModBloon](BTD_Mod_Helper.Api.Bloons.ModBloon.md 'BTD_Mod_Helper.Api.Bloons.ModBloon')  
&#8627; [ModRoundSet](BTD_Mod_Helper.Api.Bloons.ModRoundSet.md 'BTD_Mod_Helper.Api.Bloons.ModRoundSet')  
&#8627; [ModBuffIcon](BTD_Mod_Helper.Api.Display.ModBuffIcon.md 'BTD_Mod_Helper.Api.Display.ModBuffIcon')  
&#8627; [ModLoadTask](BTD_Mod_Helper.Api.ModLoadTask.md 'BTD_Mod_Helper.Api.ModLoadTask')  
&#8627; [ModGameMode](BTD_Mod_Helper.Api.Scenarios.ModGameMode.md 'BTD_Mod_Helper.Api.Scenarios.ModGameMode')  
&#8627; [ModTower](BTD_Mod_Helper.Api.Towers.ModTower.md 'BTD_Mod_Helper.Api.Towers.ModTower')  
&#8627; [ModTowerSet](BTD_Mod_Helper.Api.Towers.ModTowerSet.md 'BTD_Mod_Helper.Api.Towers.ModTowerSet')  
&#8627; [ModUpgrade](BTD_Mod_Helper.Api.Towers.ModUpgrade.md 'BTD_Mod_Helper.Api.Towers.ModUpgrade')
### Properties

<a name='BTD_Mod_Helper.Api.NamedModContent.Description'></a>

## NamedModContent.Description Property

The in game description of this

```csharp
public virtual string Description { get; }
```

#### Property Value
[System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')

<a name='BTD_Mod_Helper.Api.NamedModContent.DisplayName'></a>

## NamedModContent.DisplayName Property

The name that will be actually displayed for this in game

```csharp
public virtual string DisplayName { get; }
```

#### Property Value
[System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')

<a name='BTD_Mod_Helper.Api.NamedModContent.DisplayNamePlural'></a>

## NamedModContent.DisplayNamePlural Property

The name that will actually be display when referring to multiple of these

```csharp
public virtual string DisplayNamePlural { get; }
```

#### Property Value
[System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')