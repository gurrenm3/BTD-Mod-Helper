<a href="https://github.com/gurrenm3/BTD-Mod-Helper/releases/latest/download/Btd6ModHelper.dll">
    <img align="left" alt="Icon" height="90" src="BloonsTD6%20Mod%20Helper/Icon.png">
    <img align="right" alt="Download" height="75" src="https://raw.githubusercontent.com/gurrenm3/BTD-Mod-Helper/master/BloonsTD6%20Mod%20Helper/Resources/DownloadBtn.png">
</a>

<h1 align="center">
BTD Mod Helper

[![total downloads](https://img.shields.io/github/downloads/gurrenm3/BTD-Mod-Helper/total 'total downloads for API')](https://github.com/gurrenm3/BTD-Mod-Helper/releases)
[![total issues](https://img.shields.io/github/issues/gurrenm3/BTD-Mod-Helper 'total issues for API')](https://github.com/gurrenm3/BTD-Mod-Helper/issues)
[![code size](https://img.shields.io/github/languages/code-size/gurrenm3/BTD-Mod-Helper 'total code size for API')](https://github.com/gurrenm3/BTD-Mod-Helper/archive/refs/heads/master.zip)
[![latest release](https://img.shields.io/github/v/tag/gurrenm3/BTD-Mod-Helper 'latest release for API')](https://github.com/gurrenm3/BTD-Mod-Helper/releases/latest)

</h1>

A powerful and easy to use API for modding BTD6, and to a lesser extent BATTD.

## Instructions

### [Get BTD6 on Steam](https://store.steampowered.com/app/960090/Bloons_TD_6/)

### [Installing BTD Mod Helper](https://github.com/gurrenm3/BTD-Mod-Helper/wiki/Install-Guide)

### [Creating Mods with BTD Mod Helper](https://github.com/gurrenm3/BTD-Mod-Helper/wiki)

## Player Features

- ### An In-Game Mod Browser for viewing/downloading/updating mods from GitHub

- ### An In-Game Mods Menu with customizable Mod Settings alongside enabled/disabling/deleting etc

- ### Re-enabling profile progress saving for specific single-player situations

## Mod Creator Features

- ### Many new API Classes for adding new BTD6 Content
    - [`ModTower`](https://github.com/gurrenm3/BTD-Mod-Helper/wiki/Making-a-Custom-Tower)
      and [`ModUpgrade`](https://github.com/gurrenm3/BTD-Mod-Helper/wiki/Making-a-Custom-Tower#modupgrades) for adding
      custom Towers
    - [`ModHero`](https://github.com/gurrenm3/BTD-Mod-Helper/wiki/Making-a-Custom-Hero)
      and [`ModHeroLevel`](https://github.com/gurrenm3/BTD-Mod-Helper/wiki/Making-a-Custom-Hero#modherolevel) for adding
      custom Heroes
    - [`ModParagonUpgrade`](https://github.com/gurrenm3/BTD-Mod-Helper/wiki/Making-a-Custom-Paragon)
      and [`ModVanillaParagon`]() for adding custom Paragons
    - [`ModDisplay`](https://github.com/gurrenm3/BTD-Mod-Helper/wiki/Custom-Textures-and-Displays#moddisplay) for
      customizing in game models for Towers and such
    - [`ModBloon`](https://github.com/gurrenm3/BTD-Mod-Helper/wiki/%5B3.0%5D-Making-a-Custom-Bloon) for adding custom
      Bloons
    - [`ModRoundSet`](https://github.com/gurrenm3/BTD-Mod-Helper/wiki/%5B3.0%5D-Making-a-Custom-Round-Set)
      and [`ModGameMode`](https://github.com/gurrenm3/BTD-Mod-Helper/wiki/%5B3.0%5D-Making-a-Custom-Game-Mode) for
      custom round sets and game modes
    - [`ModGameMenu`](https://github.com/gurrenm3/BTD-Mod-Helper/wiki/%5B3.0%5D-Custom-Menu-Screens) for custom Menu
      Screens, along with a
      whole [custom UI system](https://github.com/gurrenm3/BTD-Mod-Helper/wiki/%5B3.0%5D-Custom-UI-(ModHelperComponents))
    - Many more

- ### Hundreds of API extension methods
    - Many helpful type-based `.GetBehavior<T>()`, `.RemoveBehavior<T>()`, etc methods for working with behavior models
    - Easily accessible LINQ operations like `.Where()`, `.Select()`, `.FirstOrDefault()` etc for all Il2Cpp collection types
    - Easy conversion between normal and Il2Cpp collection types
    - Extensions on types like `Game` and `InGame` for common operations like `GetCash()`, `GetHealth()`
      , `GetGameModel()` etc

- ### The BloonsTD6Mod class
    - Easy common hooks like `OnMainMenu()`, `OnTitleScreen()`, `OnNewGameModel()` etc
    - Define [Mod Settings](https://github.com/gurrenm3/BTD-Mod-Helper/wiki/%5B3.0%5D-Mod-Settings) like `ModSettingInt`
      , `ModSettingHotKey`, `ModSettingEnum` etc
    - Make your Harmony Patches not brick your whole mod if one of them fails after a game update

- ### A dedicated BTD6 Mod Sources folder with standardized btd6.targets file

    - Develop your mods with referential dependencies that would work on anyone else's machine
    - Automatically copies your .dll to the Mods folder on build, even while the game is running
    - Automatically includes your .png, .bundle etc files as embedded resources
    - Create a new Mod from an empty template from In Game

- ### Even more
    - New strongly typed enum-like classes for base BTD6 types like `UpgradeType`, `BloonType`, `BloonTag` etc
    - API methods for handling Co Op
    - All sprites in the game easily referencable from the `VanillaSprites` class
    - Classes for accessing the in-built Fonts and Animations used by BTD6
    - Helper Unity components like `ScaleOverride`, `MatchLocationPositions`, `MatchScale`

## Credits

BTD Mod Helper was originally created by @gurrenm3, and is now primarily developed by @doombubbles.

Others who have made notable suggestions/contributions include but are not limited to: Bowdown097, Mr Nuke, James,
Timotheeee, and Silentstorm.

## Contact

Mod Helper contributors are most active on the [BTD6 Mods & Discussion Discord Server](https://discord.gg/NnD6nRH).

Discord names gurrenm4#2395 and doombubbles#1701
