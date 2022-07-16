#### [BloonsTD6 Mod Helper](index.md 'index')
### [BTD_Mod_Helper.UI.Modded](index.md#BTD_Mod_Helper.UI.Modded 'BTD_Mod_Helper.UI.Modded').[ModdedMonkeySelectMenu](BTD_Mod_Helper.UI.Modded.ModdedMonkeySelectMenu.md 'BTD_Mod_Helper.UI.Modded.ModdedMonkeySelectMenu')

## ModdedMonkeySelectMenu.MonkeySelectMenu_SwitchTowerSet Class

Possible inputs:  
<br/>  
towerSet=null swipeGesture=false (reOpening=false) - When opening the MonkeySelectMenu from the Main Menu  
<br/>  
towerSet=not null swipeGesture=true (reOpening=false) - When swiping or clicking the left/right buttons  
<br/>  
towerSet=not null swipeGesture=false (reOpening=false) - When clicking the MonkeyGroupButtons, also the initial call to Open()  
<br/>  
towerSet=not null swipeGesture=false (reOpening=true) - Called during our calls to Open() to change the buttons

```csharp
internal class ModdedMonkeySelectMenu.MonkeySelectMenu_SwitchTowerSet
```

Inheritance [System.Object](https://docs.microsoft.com/en-us/dotnet/api/System.Object 'System.Object') &#129106; MonkeySelectMenu_SwitchTowerSet