#### [BloonsTD6 Mod Helper](README.md 'README')
### [BTD_Mod_Helper.Api.Testing](README.md#BTD_Mod_Helper.Api.Testing 'BTD_Mod_Helper.Api.Testing')

## IHasDefaultTest Interface

Indicates this type has a default [ModTest](BTD_Mod_Helper.Api.Testing.ModTest.md 'BTD_Mod_Helper.Api.Testing.ModTest') available for it

```csharp
public interface IHasDefaultTest
```

Derived  
&#8627; [ModBloon](BTD_Mod_Helper.Api.Bloons.ModBloon.md 'BTD_Mod_Helper.Api.Bloons.ModBloon')  
&#8627; [ModRoundSet](BTD_Mod_Helper.Api.Bloons.ModRoundSet.md 'BTD_Mod_Helper.Api.Bloons.ModRoundSet')  
&#8627; [ModDisplay](BTD_Mod_Helper.Api.Display.ModDisplay.md 'BTD_Mod_Helper.Api.Display.ModDisplay')  
&#8627; [ModGameMode](BTD_Mod_Helper.Api.Scenarios.ModGameMode.md 'BTD_Mod_Helper.Api.Scenarios.ModGameMode')  
&#8627; [ModTower](BTD_Mod_Helper.Api.Towers.ModTower.md 'BTD_Mod_Helper.Api.Towers.ModTower')  
&#8627; [ModVanillaContent](BTD_Mod_Helper.Api.Towers.ModVanillaContent.md 'BTD_Mod_Helper.Api.Towers.ModVanillaContent')
### Properties

<a name='BTD_Mod_Helper.Api.Testing.IHasDefaultTest.UseDefaultTest'></a>

## IHasDefaultTest.UseDefaultTest Property

Allow ModHelper to automatically register a default [ModTest](BTD_Mod_Helper.Api.Testing.ModTest.md 'BTD_Mod_Helper.Api.Testing.ModTest') for this content

```csharp
bool UseDefaultTest { get; }
```

#### Property Value
[System.Boolean](https://docs.microsoft.com/en-us/dotnet/api/System.Boolean 'System.Boolean')