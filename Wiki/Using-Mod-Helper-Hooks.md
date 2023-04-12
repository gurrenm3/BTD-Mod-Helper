The Mod Helper provides an assortment of "Hooks" that modders can use to very quickly and easily run code at certain times. All Hooks are methods that you can override from within your Main mod class that extends `BloonsTD6Mod`.

## Examples:

`OnGameModelLoaded(GameModel model)` to edit the main `GameModel` when it's first created.

`OnNewGameModel(GameModel result)` to edit a cloned `GameModel` for a new match. (You can read more about why you'd want to do that [here](https://github.com/gurrenm3/BTD-Mod-Helper/wiki/BTD6-Internal-Structure#cloned-gamemodels))

`OnMainMenu()` to do something whenever the player enters the Main Menu.

`OnTitleScreen()` to do something when the game finishes loading everything and prepares the Title Screen for the player to click "play".

`OnTowerSaved(Tower tower, TowerSaveDataModel saveData)` and `OnTowerLoaded(Tower tower, TowerSaveDataModel saveData)` to deal with saving and loading custom data for towers.


To see all the hooks, just go into your Main mod class and start typing in "override", and your IDE should show you all the possible methods that you can override.

At the end of the day, our hooks are just built-in Harmony Patches that we thought might be useful for a large number of people. Many mods will want to go beyond just these, and should thus take a look at [Useful Resources](https://github.com/gurrenm3/BTD-Mod-Helper/wiki/Useful-Resources) for information about doing your own Harmony Patching, and [Looking at BTD6 Code (Sorta)](https://github.com/gurrenm3/BTD-Mod-Helper/wiki/Looking-at-BTD6-Code-(Sorta)) and [BTD6 Internal Structure](https://github.com/gurrenm3/BTD-Mod-Helper/wiki/BTD6-Internal-Structure) to find the right method to patch.
