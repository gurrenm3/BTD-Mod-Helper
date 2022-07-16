#### [BloonsTD6 Mod Helper](index.md 'index')
### [BTD_Mod_Helper.UI.Modded](index.md#BTD_Mod_Helper.UI.Modded 'BTD_Mod_Helper.UI.Modded')

## ModdedMonkeySelectMenu Class

```csharp
internal class ModdedMonkeySelectMenu
```

Inheritance [System.Object](https://docs.microsoft.com/en-us/dotnet/api/System.Object 'System.Object') &#129106; ModdedMonkeySelectMenu
### Methods

<a name='BTD_Mod_Helper.UI.Modded.ModdedMonkeySelectMenu.Cycle(int)'></a>

## ModdedMonkeySelectMenu.Cycle(int) Method

Change the MonkeySelectButtons on the current page

```csharp
internal static void Cycle(int offset);
```
#### Parameters

<a name='BTD_Mod_Helper.UI.Modded.ModdedMonkeySelectMenu.Cycle(int).offset'></a>

`offset` [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/System.Int32 'System.Int32')

<a name='BTD_Mod_Helper.UI.Modded.ModdedMonkeySelectMenu.RefreshButtons()'></a>

## ModdedMonkeySelectMenu.RefreshButtons() Method

Actually make the displayed buttons change

```csharp
internal static void RefreshButtons();
```

<a name='BTD_Mod_Helper.UI.Modded.ModdedMonkeySelectMenu.ResetGameModel()'></a>

## ModdedMonkeySelectMenu.ResetGameModel() Method

Put the GameModel's TowerDetails ordering back to normal

```csharp
internal static void ResetGameModel();
```

<a name='BTD_Mod_Helper.UI.Modded.ModdedMonkeySelectMenu.UpdateGameModel(string)'></a>

## ModdedMonkeySelectMenu.UpdateGameModel(string) Method

Changes the order of the TowerDetails in the GameModel  
<br/>  
Their order in the GameModel is what determines their order in the screen

```csharp
internal static void UpdateGameModel(string set="");
```
#### Parameters

<a name='BTD_Mod_Helper.UI.Modded.ModdedMonkeySelectMenu.UpdateGameModel(string).set'></a>

`set` [System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')

<a name='BTD_Mod_Helper.UI.Modded.ModdedMonkeySelectMenu.UpdateTowerSet(Assets.Scripts.Unity.UI_New.Main.MonkeySelect.MonkeySelectMenu,int)'></a>

## ModdedMonkeySelectMenu.UpdateTowerSet(MonkeySelectMenu, int) Method

Update the currentTowerSet tracker, and change the state if need be

```csharp
internal static void UpdateTowerSet(Assets.Scripts.Unity.UI_New.Main.MonkeySelect.MonkeySelectMenu __instance, int offset=0);
```
#### Parameters

<a name='BTD_Mod_Helper.UI.Modded.ModdedMonkeySelectMenu.UpdateTowerSet(Assets.Scripts.Unity.UI_New.Main.MonkeySelect.MonkeySelectMenu,int).__instance'></a>

`__instance` [Assets.Scripts.Unity.UI_New.Main.MonkeySelect.MonkeySelectMenu](https://docs.microsoft.com/en-us/dotnet/api/Assets.Scripts.Unity.UI_New.Main.MonkeySelect.MonkeySelectMenu 'Assets.Scripts.Unity.UI_New.Main.MonkeySelect.MonkeySelectMenu')

<a name='BTD_Mod_Helper.UI.Modded.ModdedMonkeySelectMenu.UpdateTowerSet(Assets.Scripts.Unity.UI_New.Main.MonkeySelect.MonkeySelectMenu,int).offset'></a>

`offset` [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/System.Int32 'System.Int32')