Some useful information about the internal structure of BTD6 so that you don't have to find it out yourself.

## Game.instance

From any of your .cs files, you can use `Game.instance` to access the BloonTD6 `Game`. This class contains many important references to the data structures that power the overall running of the game.

## The GameModel

Arguably the most important thing you'll find in `Game.instance` is `Game.instance.model` which is the main instance of the BloonsTD6 `GameModel` (but importantly not the only one). The `GameModel` isn't a model like a 3D display model, but rather a blueprint / collection of blueprints for playing a match of BloonsTD6.

For instance, for all the information about Towers, such as their behavior, cost, damage, etc are all held in `TowerModels` that you can find in `Game.instance.model.towers`. The `GameModel` contains various methods for finding `TowerModels` such as `GetTower()` and `GetTowerFromId()`.

Similarly all the information about upgrades are stored in the `UpgradeModel`s of `Game.instance.model.upgrades`, all the Bloons in `BloonModel`s of `Game.instance.model.bloons` and etc.

## InGame.instance

Similarly to `Game.instance`, you can use `InGame.instance` in any of your .cs files to access the `InGame` class which has a lot of important information and functions relating to running the current match of BTD6.

## UnityToSimulation (aka the "bridge")

The `UnityToSimulation` class found at `InGame.instance.bridge` controls the interaction between the simulation (all of the information about the current state) and Unity (the engine powering the visualization of the game. This has more methods for handling / manipulating current match information, so if you didn't find what you were looking for in `InGame.instance`, this is another good place to look.

Also in this class `InGame.instance.bridge.Model` or (`InGame.instance.GetGameModel()` with our extension method) is another `GameModel` class. Read more to see why this is.

## Cloned GameModels

The `GameModel` that can be found at `Game.instance.model` is in a pure / default state, effectively. It has all the `TowerModels` unmodified by Monkey Knowledge, all at their Medium difficulty price, etc.

When starting a new match of BTD6, the game makes a clone of this base `GameModel`, and then applies all the necessary modifications to it (the things that are referred to as "mods" in the source code). This includes things like Monkey Knowledge, Difficulty based pricing, CHIMPS rules, and more.

Thus, when making a mod, you as a modder need to decide which `GameModel` would be better to modify.

You can use the `OnGameModelLoaded()` hook in your BloonsTD6Mod file to change the core `GameModel` if you're doing something very important. This is dangerous, however, because other mods could implicitly rely on certain default functionality of the core `GameModel`.

The alternative is to use the `OnNewGameModel()` hook to modify the newly cloned `GameModel` whenever a match starts. This has the benefit of being safer with respect to other mods, as well as being able to interact with Monkey Knowledge and such. If you only sometimes want to make a change to the `GameModel`, this is definitely the way to go. Additionally, if we as a modding community ever want to get to the point where we can load and unload mods without restarting the game, this is the way we have to change the `GameModel`.
