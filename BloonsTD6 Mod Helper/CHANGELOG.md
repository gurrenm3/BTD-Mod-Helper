# Changelog

## [Unreleased]

- Made it so that the `DisableMonkeyKnowledgeModModel` will actually have an effect for `ModGameMode`s (even though it apparently has no actual effect in the base game, it's all hardcoded)
- Fixed error when trying to prime a `ModCustomInput` without an associated Tower
- Added an override `ModCommand.SuggestionsForValue` that lets you populate custom autocomplete suggestion strings for your `[Value]` arguments
- Improved the loading for `ModSetting`s that are manually added late into the `ModContent` Registration phase
- Added a `ModHelper.LoadPhase` enum in case anyone needs to check what load phase ModHelper is in
  - PreLoading -> Loading -> PreRegistration -> Registration -> PostRegistration

## [3.6.4] - 2026-06-03

- Fixes for BTD6 v55
- Added `OnUpgraded` overrides for `ModUpgrade` and `ModTower`
- `ModGameMode`s will now once again show up as options for being used on Custom Maps and Challenges (though you can't share a challenge of a custom mode)
- `btd6.targets` now has new functionality using C# Source Generators to populate an internal `ModResources` class with strongly typed entries for all your embedded resources
  - For example, for your Icon.png it would have `internal static readonly SpriteResource<YourMod> Icon = new("Icon");` and then `ModResources.Icon` can be used to retrieve the icon as a string, SpriteReference, or full Sprite as needed
  - Can opt out by putting `<ModHelperSourceGenerators>false</ModHelperSourceGenerators>` in your csproj

## [3.6.3] - 2026-05-27

- Fixed an issue with custom sound loading for certain mp3 files
- Added the `BloonsMod.NormalizeAllAudioVolume` override (default true) and the `BloonsMod.NormalizeAudioVolume` static id list to control making custom sounds have their volume increased as needed to match base game sounds

## [3.6.2] - 2026-05-27

- Fixed a possible race condition for the initial `ModLoadTask` setup that affected a couple users
- Made public some new `.CatchErrors()` extensions for coroutines

## [3.6.1] - 2026-05-26

- Fixed a `ModLoadTask` issue that could make the "Pre-loading mod resources..." task crash

## [3.6.0] - 2026-05-26

- Added [ModTsmTheme and ModVanillaTsmTheme](https://gurrenm3.github.io/BTD-Mod-Helper/wiki/Making-a-Custom-TSM-Theme)
- Added [ModMutator](https://gurrenm3.github.io/BTD-Mod-Helper/wiki/Making-a-Custom-Mutator)
- Added [ModCustomInput](https://gurrenm3.github.io/BTD-Mod-Helper/wiki/Making-a-Custom-Input)
- Added [ModTest](https://gurrenm3.github.io/BTD-Mod-Helper/wiki/Automated-Testing) for Automated Testing support
- Revamped the `ModLoadTask` system: coroutine based load tasks are back to being visualized in the BTD6 initial loading screen in a future-proof way
  - Users will now see "Modded Step X of Y..." for Mod Content registration and other tasks after the base Steps are complete
  - The "Use Old Loading" mod helper setting returns if you want to fallback to the original way
- Marked Obsolete the `AttackHelper`, `WeaponHelper`, `ProjectileHelper`, and `AbilityHelper` classes in favor of the
  `AttackModel.Create`,`WeaponModel.Create`,`ProjectileModel.Create`, and `AttackModel.Create` extensions, which now have the same / more conviences as the Helper classes
- Updated `ModCommand` to support a Coroutines being a valid main Execute method with `public override IEnumerator Execute(Output output) { ... }`
  - Can set `output.success` (defaults to true) and `output.resultText` (which will update live)
- Updated btd6.targets with some new features
  - New csproj property `<Dependencies>` that can be set in an `<ItemGroup>` like `<Dependencies>PathsPlusPlus;UltimateCrosspathing</Dependencies>` whcih automatically references dll from mods folder (or disabled mods folder if not found)
  - Keeps mod launchSettings.json up to date automatically, unless you add csproj property `<DontCopyLaunchSettings>true</DontCopyLaunchSettings>`
- Added a number of new command lines arguments for mod makers
  - `--modhelper.only=ModA,ModB`/`--modhelper.only ModA,ModB` load the game with only the specified mod(s) loaded (and Mod Helper)
  - `--modhelper.noaudio` disables all game audio, primarily meant to be used alongside `-batchmode` to run the game headlessly
  - `--modhelper.offline` to put the game in offline mode and not run mod helper browser or updater plugin functionality
  - `--modhelper.run [-q?] [-e?] [command] [&& another command ...] ` runs a ModCommand after the game loads
    - `-q` make the game quit automatically after running the command, exit code 0 for success or 1 for failure
    - `-e` if specifying multiple commands with `&&`, stop whenever the first one fails
    - Should be the last argument

## [3.5.15] - 2026-05-07

- Small fix for a null reference in a harmony patch
- Updated VanillaSprites

## [3.5.14] - 2026-05-06

- TrySaveToPNG and related methods will now export the full original size of the texture rather than the packed size
  - This affects the `export assets` and `export display` commands
- Updated SetName extension and ModTowerHelper.FinalizeTowerModel to account for the new modelName field
- Fixed another edge case where custom sprites could fail to load and instead just show a white square
- Moved Mod Helper's ILRepack setup into `btd6.targets`, allowing any mod to easily bundle any nuget / library dlls using the `IncludeLibs` property
  - Matches Mod Helper's style of copying the libs to UserLibs if it's a debug build, or embedding them in the DLL for a release build
  - Example in a mod csproj (using IncludeLibs will automatically add ILRepack as a nuget dependency)
    ```csproj
    <ItemGroup>
      <PackageReference Include="Octokit" Version="4.0.3"/>
      <PackageReference Include="FuzzySharp" Version="2.0.2"/>
    </ItemGroup>
    
    <PropertyGroup>
      <IncludeLibs>Octokit,FuzzySharp</IncludeLibs>
    </PropertyGroup>
    ```

## [3.5.13] - 2026-04-25

- Update model extensions for v54.2
- Fixed the `/export display` command not properly saving some SpriteRenderer textures
- Added a bizarre fix that somehow prevents certain Fatal internal CLR errors from sometimes happening on launch

## [3.5.12] - 2026-04-14

- Update model extensions for v54.1

## [3.5.11] - 2026-04-09

- Fixed a minor console message that could come up on starting a match
- Fixed ModByteLoader generated import statements for v54

## [3.5.10] - 2026-04-09

- Updated for BTD6 v54
- Added a new set of `Tick` method overrides to ModTowers and ModBloons that can run code for the entity every tick of the ingame simulation (thanks @DarkTerraYT !)

## [3.5.9] - 2026-02-23

- Added support for .flac, .aac, .wma, .m4a audio files

## [3.5.8] - 2026-02-12

- Fixed an issue with some people's BTD6 localization tables not getting fully setup which lead to many different problems with mods
- Fixed the Mod Browser screen not being properly renamed from Content Browser

## [3.5.7] - 2026-02-12

- Initial fixes for BTD6 v53

## [3.5.6] - 2025-12-13

- Fixed the patch that ensured only vanilla towers were rewarded as Insta Monkeys from including the Sheriff tower
  - The extension `towerModel.IsVanillaTower()` will still return true for the Sheriff, but the new extension `towerModel.IsStandardVanillaTower()` will return false

## [3.5.5] - 2025-12-11

- Updated extensions for BTD6 v52.1
- Fixed an error with ModBloons using `KeepBaseId`
- Frontier Data is now also exported with Export Game Data

## [3.5.4] - 2025-12-03

- Initial fixes for BTD6 v52
- Added support for using .ogg files for audio
  - btd6.targets will now automatically mark .ogg files as Embedded Resources
- Fixed issue where custom sounds could stop being available via PrefabReference from the AudioFactory after quitting a match
- Added better support for ModGameModes using and modifying `DailyChallengeModel`s for games
  - Override `ApplyChallengeRules` to true to make normal games have challenge rules (since they otherwise don't)
  - Override `ModifyChallengeRules(DailyChallengeModel)` to edit challenge rules
- Added the ability to register sound GUIDs that will correspond to a different random sound from a list each time they're played, for example to make "CustomSound" choose from any of CustomSound1.mp3, CustomSound2.mp3 or CustomSound3.mp3 in your mod you can do

```csharp
public override void OnTitleScreen()
{
    RegisterRandomizedAudioClip("CustomSound", "CustomSound1", "CustomSound2", "CustomSound3");
}

...
  
GetAudioClipReference<MyMod>("CustomSound")
```
- Using the new C# 14 static extensions feature, added new static .Create() methods for many Models. These have the benefit of not breaking if the constructor for the model gets changed by an update
```csharp
new DamageModel("", 2, 0, true, false, false, Lead | Frozen, Lead | Frozen, false, false)
// ... now can instead do
DamageModel.Create(new()
{
    damage = 2, distributeToChildren = true, immuneBloonProperties = Lead | Frozen, immuneBloonPropertiesOriginal = Lead | Frozen
}),
```

## [3.5.3] - 2025-11-13

- For modded Paragons, it's no longer required for the player to use them in a real game before they are usable in Sandbox
- Improved the Mod Browser's search functionality to switch to ordering by Relevance by default while searching
  - Also made this change for the website Mod Browser
- Added some more misc extensions such as
  - `model.HasBehavior<T>(nameContains)` and `model.HasDescendant<T>(nameContains)` (no out param)
  - `model.Duplicate(m => ...)` duplicate with function for inline changes
  - `.StartCoroutine()` for both normal and Il2Cpp IEnumerators

## [3.5.2] - 2025-10-14

- Initial Fixes for BTD6 v51
  - Disabled the Embedded Browser functionality for the moment pending a fix

## [3.5.1] - 2025-09-29

- Fixed an error that could make custom towers sometimes appear locked
- Made a new fix for custom upgrade icons occasionally becoming white squares
- Made some minor performance improvements for the Updater Plugin

## [3.5.0] - 2025-09-24

- Created a new Updater Plugin that keep Mod Helper and other mods automatically up to date when you start the game
  - Mod Helper will automatically manage the download and installation of the Updater Plugin, no need to manually download the .dll
  - Enabled by default; use the "Auto Update" setting at the top of Mod Helper Settings if you don't want to use it
  - The Updater Plugin has its own settings page to control which mods you want to keep updated, if not all of them
  - The plugin will also be able to display important messages to users at startup for cases like recently when users needed to be told about downgrading the game
- For `ModRoundSet`, `Rounds1Index` will now finally be true by default
- Added a VanillaAudioClips file listing all the GUIDs for game sounds
- Updated the game data exporter to use a custom serializer implementation that does not fail on any towers (e.g. top
  path alchemists)
- Made some more members of `ResourceHandler` be public, and added `ResourceHandler.AddTexture(guid, texture2d)`

## [3.4.12] - 2025-09-02

- Fixed for BTD6 v50.1

## [3.4.11] - 2025-08-29

- If an installed mod has a higher WorksOnVersion than the current installed version of the game, an explicit load error will be shown
- If a mod update has a higher WorksOnVersion than the current installed version of the game, no update button will be shown
- Fixed an issue with ModSettingHotkeys not saving changed values
- Updated VanillaSprites and UpgradeType lists, fixed the `export assets` command
- Fixed AddBehaviorToBloonModel extensions having ambiguous invocation errors
- Added some new overrides: `ModTower.DontApplyModUpgrades`, `ModTower.ShouldUnlockTower(...)`, `ModUpgrade.ShouldAcquireUpgrade(...)`

## [3.4.10] - 2025-08-27

- Initial fixes for BTD6 v50
- Added a class `ModFakeTower` that is a variant of `ModTower` that allows for custom functionality when purchased from the shop instead of actually placing a tower
  - Most important overrides are `OnPlace` for determining what happens when purchased, and `CanPlaceAt` to determine if it's a valid spot
  - Also has `PlacementSound` and `PlacementEffect` effect overrides
  - The `Icon` is what's displayed when trying to place it, akin to a Power
- Added a static class SpriteResizer with methods aimed at helping use resized versions of Vanilla Sprites
  - Call `SpriteResizer.Scaled(VanillaSprites.XYZ, scale)` to get a new sprite GUID for a resized version of that sprite
    - e.g. `SpriteResizer.Scaled(VanillaSprites.DartMonkeyIcon, .5f)` gets a Dart Monkey Icon that is half as large without having to resize the Unity UI Image it gets loaded on
  - You can also directly call the extension methods on a Sprite itself for `.PadSpriteToScale(...)` for resizing and `.PadSpriteToSquare()` for making it 1:1 total aspect ratio
- Added an `.AsIEnumerable()` extension for easily converting an IL2CPP IEnumerable/ICollection/IList into a standard IEnumerable that can be iterated normally
- Added an `.EffectiveCooldown()` extension for AbilityModels that factors in the `CooldownSpeedScale`
- Normalized some model extensions so that all supported classes have access to `.GetBehavior<T>(stringNameContains)` and `.HasBehavior(out BehaviorModel behaviorModel)`

## [3.4.9] - 2025-08-06

- ModWindow improvements
  - Windows can now save their position and data between matches
  - Opacity can be set separately for the background and foreground of windows
  - Added an entry to the start menu options for changing default window color
  - Added an entry to the start menu options for closing all windows
  - Fixed a submenu not syncing its window color

## [3.4.8] - 2025-07-30

- Fixed embedded audio track length for non-stereo (mono) .wav and .mp3 files
- Fixed an error in the hero screen for custom heroes
- Added some new ModHelperComponents and ModContent classes that help in making general purpose ingame UI windows / menus
  - [ModStartMenuEntry](https://gurrenm3.github.io/BTD-Mod-Helper/docs/BTD_Mod_Helper.Api.UI.ModStartMenuEntry) - ModContent that defines a button in a new ingame "Start Menu" that appears if any mods make entries for it
    - Useful for making custom mod actions be triggerable by the user without needing a hotkey
  - [ModWindow](https://gurrenm3.github.io/BTD-Mod-Helper/docs/BTD_Mod_Helper.Api.UI.ModWindow) - ModStartMenuEntry that creates an entry for opening a custom moveable+resizable UI window
  - [ModHelperWindow](https://gurrenm3.github.io/BTD-Mod-Helper/docs/BTD_Mod_Helper.Api.Components.ModHelperWindow) - The underlying ModHelperComponent that powers ModWindows, but can be used separately
  - [ModHelperPopupMenu](https://gurrenm3.github.io/BTD-Mod-Helper/docs/BTD_Mod_Helper.Api.Components.ModHelperPopupMenu) - ModHelperComponent that powers the options / right click menus of ModHelperWindows, but can be used separately
    - [ModHelperPopupOption](https://gurrenm3.github.io/BTD-Mod-Helper/docs/BTD_Mod_Helper.Api.Components.ModHelperPopupOption) - ModHelperComponent for the entries to popup menus
    - [ModHelperPopDown](https://gurrenm3.github.io/BTD-Mod-Helper/docs/BTD_Mod_Helper.Api.Components.ModHelperPopdown) - ModHelperComponent that is an alternatively implemented ModHelperDropdown using a ModHelperPopupMenu

## [3.4.7] - 2025-06-18

- Fixes for BTD6 v49
- Updated VanillaSprites and UpgradeType references for the new Desperado tower
- [Added a few new helpful api methods](https://github.com/gurrenm3/BTD-Mod-Helper/pull/301) (Thanks @DarkTerraYT !)

### Folder Location Change

To prepare for an upcoming new version of MelonLoader, some directories created by Mod Helper will be moving to a new
location.
This should happen automatically on startup; any issues will display as load warning for Mod Helper in the mods menu
that can be addressed by just moving the folders manually if need be.

- The `BloonsTD6 Mod Helper` folder that previously was within the `BloonsTD6/Mods` folder is now the `BTD6ModHelper` folder
  within the root `BloonsTD6` directory
- The `Disabled` folder that previously was within the `BloonsTD6/Mods` folder is now the `Disabled Mods` folder within the root
  `BloonsTD6` directory

## [3.4.6] - 2025-04-23

- Internal fixes and improvements for the ModHook system from @MatthewOGuerra

## [3.4.5] - 2025-04-16

- Added a new `ModHook` system that can be used to work around patching some specific methods that harmony currently
  can't, read more on the wiki page https://gurrenm3.github.io/BTD-Mod-Helper/wiki/ModHooks

## [3.4.4] - 2025-04-16

- Fixed an issue with profile cleaning where Legends starter artifacts weren't getting properly removed once they no
  longer existed within installed mods

## [3.4.3] - 2025-04-02

- Fixed an issue with profile cleaning where Legends starter artifacts weren't getting properly removed once they no
  longer existed within installed mods

## [3.4.2] - 2025-04-02

- Minor fixes for BTD6 V48

## [3.4.1] - 2025-03-03

- Added a new `export assets` command that locally exports all the addressable sprite textures in an organized way
- Added a `precisionDigits` field to `ModSettingDouble` / `ModSettingFloat` to control rounding
- Cleaned up the internals of some il2cpp extensions

### ModArtifact

- Added a new property `SmallIcon` that can be overriden to resize the icon so using most VanillaSprites will be framed
  correctly
- Added overrides for `OnActivated(Simulation simulation, int tier)` and
  `ModifyGameModel(GameModel gameModel, int tier)` for easier custom artifact effects
- Added new methods `string InstaMonkey(int tier)` and `int[] InstaTiers(int tier)` that can be overriden to set up
  artifact's Insta Monkey and automatically adds it to the description
- Added new ArtifactModel extension methods `AddTowerBehavior`, `AddTowerBehaviors`, `AddProjectileBehavior`,
  `AddProjectileBehaviors` that work similar to `AddBoostBehavior` but via `AddTowerBehaviorsArtifactModel` and
  `AddProjectileBehaviorsArtifactModel`

## [3.4.0] - 2025-02-04

- Minor fix for BTD6 v47

### Rogue Legends

- Added a preliminary version of custom artifacts via `ModItemArtifact` and `ModBoostArtifact`
  - Read more on the [wiki page](https://gurrenm3.github.io/BTD-Mod-Helper/wiki/Making-a-Custom-Artifact)
  - Vanilla artifact data will also now be included in Mod Helper's Export Game Data output
    - Viewable online [here](https://github.com/Btd6ModHelper/btd6-game-data/tree/main/Artifacts)
- Added new `ModHero` properties `RogueStarterArtifact` and `RogueStarterInstas` for defining custom loadouts
  - If not specified, defaults to Starting Strong Common with a 2-0-0 Ninja Monkey and 2-0-0 Alchemist
  - See the [wiki page](https://gurrenm3.github.io/BTD-Mod-Helper/wiki/Making-a-Custom-Hero#example) for more info
- Added new `ModTower` property `IncludeInRogueLegends` to control if a custom tower should be allowed to appear in Rogue Legends
  - Defaults to false

## [3.3.4] - 2024-12-10

- Fixed for BTD6 v46 (thanks @GrahamKracker !)

## [3.3.3] - 2024-10-26

- Fixed an issue with downloading new mods from the Mod Browser when the disabled mods folder didn't exist

## [3.3.2] - 2024-10-25

- Fixed an issue that made embedded audio clips be loaded with extra silence at the end of them
- Added a `ModBloonOverlay` class for making custom Bloon Overlays
  - NOTE: Due to a MelonLoader bug, these won't display correctly on ML 0.6.5, but work again starting with [0.6.6 / nightly versions](https://nightly.link/LavaGang/MelonLoader/workflows/build/master)
- Added a `Sprite.TrySaveToPNG()` extension like the one for Textures except accounting for the Sprite's position and size within its texture atlas
- Added `export image` console command that exports all UI images underneath your mouse cursor to png files

## [3.3.1] - 2024-10-17

- Fixed a TimeManager patch for BTD6 v45.2 (fixes Faster Forward)
- Made some methods in ResourceHandler public
- Fixed a bug with the Shift+Shift to open console setting

## [3.3.0] - 2024-10-09

### NOTE: BTD6 v45 will require MelonLoader v0.6.5 to work

- Fixed for BTD6 v45.0
- Fixed a performance issue with the background Task Scheduler
  - Also added new `ScheduleType.WaitForSecondsScaled` that is affected by fast-forward mode
- Added a `ModRoundSet.Rounds1Index` override that changes the behavior of the `ModifyRoundModels` methods to match the
  player facing 1, 2, 3 and not the internal 0, 1, 2.
  - This will become the default in a later Mod Helper update
- Updated the way VanillaSprites.cs is generated, so it no longer includes some duplicates and many "false positives" of
  Sprites that have GUIDs but aren't properly able to be loaded on demand
- Added a Renderer extension `.ReplaceColor(Color targetColor, Color replacementColor, float threshold)` that
  replaces all the colors in the main texture within a certain threshold of the target with a new color.
- Added a Renderer extension `.AdjustHSV(float hueAdjust, float saturationAdjust, float valueAdjust)` that edits
  the Hue/Saturation/Value of the main texture.
  - Can also do
    `.AdjustHSV(float hueAdjust, float saturationAdjust, float valueAdjust, Color targetColor, float threshold)` to only
    apply the adjustment to certain colors in the texture
- Added `TimeHelper` class with properties `OverrideFastForwardTimeScale` and `OverrideMaxSimulationStepsPerUpdate`

### Custom Jukebox Tracks

- Added a `ModJukeboxTrack` class that lets you easily add your own jukebox music from custom audio
- Also updated resource embedding behavior to also automatically embed .mp3 files in your project in addition to .wav
  files
- See the [wiki page](https://gurrenm3.github.io/BTD-Mod-Helper/wiki/Making-a-Custom-Jukebox-Track) for more info

### Model Serialize / Tower Quick Edit

- Added a new `ModelSerializer` that's better at serializing and deserializing things like TowerModels to/from JSON (
  sadly still not perfect)
- Making use of the above, added a new "Tower Quick Edit" functionality that can let you try out changes to TowerModels
  from within a Sandbox game
  - When activated (default hotkey Shift + Backslash) with a tower selected in Sandbox mode, a text editor will open up
    and let you edit the TowerModel as JSON. When you close the file, it will apply the changes back to the tower.
    - By default, it changes the "root" model of the tower, which is before any Mutators have been applied. If you
      instead want to see/edit the full tower model (e.g. one that has Paths++ mutators applied),
      use the "Quick Edit Mutated Model" hotkey (default Alt + Backslash)
      NOTE: This can have the side effect of stacking / reapplying mutators on the tower.
  - The default editor it opens with is Notepad
    - To make it edit with VsCode, change the "Quick Edit Program" mod helper setting to "code -w -n"
    - To make it edit with JetBrains Rider, change it to "%LOCALAPPDATA%\Programs\Rider\bin\rider64.exe --wait"

### Developer Console

- Simple CLI-style interface that modders can add commands to that can be run in game
  - Mainly an alternative to adding miscellaneous hotkeys or buttons for infrequently used actions
- Default hotkey is F8 (can be changed in settings under "Mod Making")
  - There's also a Mod Setting you can opt in to that make pressing Shift twice in a row activate it
- Define commands by creating classes that extend
  `ModCommand`, [see here for Mod Helper's examples](https://github.com/gurrenm3/BTD-Mod-Helper/tree/master/BloonsTD6%20Mod%20Helper/Api/Commands)

## [3.2.1] - 2024-09-03

- Pause Screen Mods Button now shows number of active mods
- Updated icon for Pause Screen mods button
- Made it less likely for other mods to have errors if they tried to use file/folder picker popups outside standard mod settings
- Apopalypse Mode is now correctly affected by the Round Set changer
- Made the Round Changer button also show up in the Challenge Editor Play screen
  - Note: The Round Set Changer would always technically apply to challenges, this is just making it clearer and easier
    to change without going back to the normal map play screens

## [3.2.0] - 2024-08-25

### Misc Updates

- Added a button that lets you open the Mods Menu from the In Game Pause Screen
  - This includes opening Mod Settings menus, but not many settings yet will probably live update in a game
- Added a button in the Mods Menu that can display the SHA 256 hashes of active mods
- Added a new `ModTower.IncludeInMonkeyTeams` override
- Fixed some inconsistencies where some simulation behavior extensions would throw exceptions instead of just returning null
- ModHelperData now supports multiline raw strings for descriptions, [example](https://github.com/doombubbles/ability-choice/blob/699658591855043372a128294de679670600e3c1/ModHelperData.cs#L10)

### Localization Updates

#### General

- Added a new button in the Mods Menu to export a mod's localization to a json file, which can be edited to change its
  supported displayed text for your language
  - This goes to a newly added subfolder `Mods/BloonsTD6 Mod Helper/Localization/[Language]`
  - Edits to files here should refresh the text without requiring a game restart
- Added a new [Translation Tool page on the website](https://gurrenm3.github.io/BTD-Mod-Helper/tools/translate) that can
  easily put Localization files through Google translate for individual or all supported languages
  - Using this tool, Mod Helper now contains Localizations for all supported BTD6 language. If you see a way that
    one/many of the Google Translations could be improved for your language, you can help out by submitting edits to
    the [corresponding Language file](https://github.com/gurrenm3/BTD-Mod-Helper/tree/master/BloonsTD6%20Mod%20Helper/Localization) through GitHub
- The text in mods that should be automatically supported for localization editing includes
  - Names and Descriptions for Towers, Upgrades, Heroes, Bloons etc
  - Names and Descriptions for Mod Settings
  - General mod info like the description

#### For Modders

- The standard btd6.targets import will now automatically embed `/Localization/[Language].json` files in your mod
  project
  - Use the Localization Button on your own mod with active language English to get a starter .json for your mod
  - If you paste in the .json content on the website and press the "Translate All" button it will create a .zip file
    with all the correctly named .json files you'd need for your mod
- ModHelperText and ModHelperDropdown components now Localize their texts by default
- For Localization Entries, putting text within [Square Brackets] will make it try to fetch existing localization for
  that key
  - e.g. `The description is [DartMonkey Description]` ->
    `The description is Throws a single dart at nearby Bloons. Short range and low pierce but cheap.`
- Added new `ModContent.Localize` methods that can add new mod specific localizations from variables
  ```csharp
  private static readonly string DoTheThing = ModContent.Localize<MyMod>(nameof(DoTheThing), "Do The Thing!");
  ```
  Or within any method/constructor that's going to run as the game loads
  ```csharp
  var doTheThing = ModContent.Localize(nameof(DoTheThing), "Do The Thing!");
  ```
  The result assigned to the `DoTheThing` is your mod specific localization key, that you can use in a
  `ModHelperText.SetText(DoTheThing)` directly or as `string localizedText = DoTheThing.Localize()` otherwise
- As before, you can still override the `RegisterText` method in any class that extends `NamedModContent` to
  directly add extra stuff to the text table
  ```csharp
  public override void RegisterText(Il2CppSystem.Collections.Generic.Dictionary<string, string> textTable)
  {
      base.RegisterText(textTable); // Call the base to still register DisplayName / Description
            
      textTable[Id + " Long Description"] = LongDescription; // More specific stuff to your ModContent
  }
  ```

## [3.1.25] - 2024-08-08

- An error indicator will now show on the main menu Mods Button if any mods have load errors
- Added a new load error for not being on MelonLoader 0.6.1
- Fixed unneeded errors on Epic about Il2CppFacepunch.Steamworks

## [3.1.24] - 2024-08-07

- Removed a no longer needed patch that had side effects with X/3+/X Mermonkey damage calculations

## [3.1.23] - 2024-08-02

- Fixed ApplyOutlineShader
- Updated UpgradeTypes and VanillaSprites enums for Mermonkey

## [3.1.22] - 2024-08-01

### This update will require a manual download from GitHub here

- Initial fixes for BTD6 v44
- Removed the BypassSavingRestrictions settings as it's no longer needed (hurray!)
  - Also removed the AutoHideModdedClientPopup setting as the new popup requests

- Added a new String extension for GetBtd6Localization (thanks @DarkTerraYT !)

## [3.1.21] - 2024-05-29

- Initial fixes for BTD6 v43.0

### Notes for Modders

- For any place where you previously used `InGame.instance.UnityToSimulation`, just switch it now to either `InGame.instance.bridge` or `InGame.Bridge` or `InGame.instance.GetUnityToSimulation()`

## [3.1.20] - 2024-04-14

- Fixed a bug preventing modded heroes from reaching level 20

## [3.1.19] - 2024-04-11

- Fixed a patch for BTD6 v42.1

## [3.1.18] - 2024-04-08

- Fixes for BTD6 v42.0

This Mod Helper update will not be able to be made via the in game Mod Browser.

### Note for Modders

A large number of mods will need to be updated for this patch, as the namespace
for `SpriteReference`, `PrefabReference`, and `AudioSourceReference` has been changed from `Il2CppAssets.Scripts.Utils`
to `Il2CppNinjaKiwi.Common.ResourceUtils`.

## [3.1.17] - 2024-02-07

- Fixes for BTD6 v41.0
- Updated VanillaSprites and UpgradeTypes for v41.0
- Fixed hints for custom round sets
- Fixed some more crashes for Linux / Wine / Proton users

## [3.1.16] - 2023-12-05

- Preliminary fixes for v40.0 (thanks @KosmicShovel!)
- Updates for v40.0 UpgradeTypes, VanillaSprites, etc
- The `TopPathUpgrades`, `MiddlePathUpgrades` and `BottomPathUpgrades` properties no longer need to be manually specified for `ModTower`s, they will be inferred
  - Same goes for `MaxLevel` in `ModHero`
- Added a `Model.RemoveBehaviors()` extension (no type argument) that simply clears all behaviors
- Fixed a possible visual error with ModSettingFile and ModSettingFolder
- Let a number of api methods use params arguments
- Added GetBloonDisplay method to ModDisplay.cs (thanks @DarkTerraYT!)

## [3.1.15] - 2023-10-10

- Fixes for v39
  - Due to the new Community Button, the Round Set Changer button now only appears while selecting the difficulty/mode for a map
  - Fixed ModHero font name material reference
  - Fixed JSON settings
- Added setting to toggle Mod Browser Populating on Startup
    - From my personal testing, this leads to ~1s faster startup on average, in exchange for waiting 5s - 10s when you
      first open the browser
- Added `Instances` and `Lists` classes for modders that have getters for commonly used BTD6 singleton classes and game objects
  - eg `InGame.instance.coopGame.Cast<Btd6CoopGameNetworked>().Connection.Connection.NKGI` can instead be `Instances.NKGI`
  - Also gets added as a component to a Game Object at the root of a global scene, so you can easily access fields from the default Unity Explorer window

## [3.1.14] - 2023-09-02

- Added `AbilityHelper` class
- Reverted a previous change that was leading to a selling / rebuying 5th tiers issue

## [3.1.13] - 2023-08-20

- Now natively works on Epic Games version, and prompts user to download the compatability plugin to make other mods work if they don't have it
- Added ModHelperData `bool Plugin` field for mods that are MelonPlugins
- Fixed SteamWebView usage on the Epic Games version
- Fixed a crash that could happen on Linux (thanks @GrahamKracker)
- Fixed more crashes from TowerInventory / subtower interactions (thanks @Onixiya)
- Added `AttackHelper`, `WeaponHelper` and `ProjectileHelper` that can be used to less painfully create those models
  from scratch
    - The classes will implicitly convert themselves to their respective models
    - Make use of the object initialization syntax; don't need to specify every single field, will use sensible defaults

## [3.1.12] - 2023-07-26

- Fixes for BTD6 v38

## [3.1.11] - 2023-07-21

- Added `ModTower.Hotkey` override to assign a `ModSettingHotkey` for placing your tower in game
- Added the `Renderer.ApplyOutlineShader` extension to give a custom display's renderer the standard outlining / selection highlight that regular towers have
- Added the `IModSettings` interface that controls if ModSettings will be added from that ModContent type
- Added `UpgradeType.ByName` lookup
- Added some more misc `Model` extensions
- Fixed issue with custom 3d Bloons' damaged displays
- Fixed Tower background in the challenge rules screen always being Magic
- Fixed issue with Profile Cleaning for mod heroes
- Fixed issue with `ModSettingHotkey.JustReleased` on Hotkeys without modifiers

## [3.1.10] - 2023-06-17

- Fixed mod hotkeys sometimes not saving new values
- Fixed OnNewGameModel hook signature change
  - This impacted some other mods such as Mega Knowledge
- Fixed in game messages (like from Faster Forward) sometimes breaking after back to back matches

## [3.1.9] - 2023-06-12

- Added `ModBloon.ModifyBloonModelForMatch` override like the ones for towers and upgrades
- Create mod button will now work when your mods folder is on a different volume than your BTD6 install
- Hotkeys can now be easily unset via pressing Escape while setting
- Fixed ModVanillaParagon crash issue
- Fixed 2d towers for the new DisplayCategory
- Fixed issue with custom heroes appearing in the shop multiple times
- Fixed extraneous "cleaning acquiredUpgrade" messages after disabling mods
- Fixed false positive warnings for disabling certain mods that weren't actually dependencies

## [3.1.8] - 2023-06-07

- Fixed for BTD6 37
- Added `ModTower.ModifyTowerModelForMatch` and `ModUpgrade.ApplyUpgradeForMatch` overrides for easily modifying custom
  towers on a per match basis / based on mod settings without needing a restart
- `FileIOHelper.SaveObject` now will use `ReferenceLoopHandling.Ignore` by default
    - (More Alchemist TowerModels will now be included in the exported game data)
- Added `ModTower.ShopTowerCount` override to easily set how many of a tower you can purchase at once in a standard game
- Some fixes for ModBloon default displays

## [3.1.7] - 2023-04-25

**If you haven't already seen, there is now a [website version of the Mod Browser](https://gurrenm3.github.io/BTD-Mod-Helper/mod-browser) on the new github pages site.**

- Regenerated UpgradeType constants for v36
- Added a stopgap patch onto `Il2CppDetourMethodPatcher_RaiseException` to make "During invoking native->managed trampoline" errors also print their full exceptions
  - This will eventually be removed once MelonLoader fixes it
- Added a "Dependencies" field to ModHelperData, letting modders specify a comma separated list of "owner/repository" format GitHub mod dependencies
  - When a user first downloads a mod, they will be prompted to also download the dependencies (including dependencies of dependencies)
  - If not all of a mod's dependencies are active when trying to use a mod, a load error will be displayed for it in the Mods Menu
- For modders: the BtdModHelper.xml documentation file will now be automatically downloaded for you when you first use a new Mod Helper version
- Added the `ModTower.GetBaseTowerModel(int[] tiers)` override that lets you copy from different base TowerModels depending on what tier/crosspath you're using.
- Added `BloonsMod.OnSaveSettings(JObject settings)` and `BloonsMod.OnLoadSetings(JObject settings)` hooks
- Modded Towers with Custom Tower Sets now appear in the Monkeys menu once again (thanks MelonLoader 0.6.1)
- Fixed internal GitHub API pagination, aka there should be less mods slipping through the cracks and sometimes not being shown in the Mod Browser
- Fixed the ModTower Instas blocker not knowing about Beast Handlers and ignoring Primary/Military/Magic only (thanks @Jonyboylovespie)
- Fixed using Number keys for ModSettingHotkeys

## [3.1.6] - 2023-04-04

- Recompiled and fixed patches for BTD6 v36.0
- Added new VanillaSprites references for v36.0 images

## [3.1.5] - 2023-03-25

- @GrahamKracker has started an `AdvancedBloonsTD6Mod` class that has pre/post versions and ref parameters for hooks
- .wav files in your project will now be automatically included as embedded resources and loaded into AudioClips
  - To directly get and play a custom sound "MySound.wav" `AudioClip`, you'd do `ModContent.GetAudioClip<YourBloonsTD6Mod>("MySound").Play()`
  - To use the custom sound in a `SoundModel` you'd do `soundModel.assetId = ModContent.CreateAudioSourceReference<YourBloonsTD6Mod>("MySound")`
- Fixed FileIOHelper.LoadObject<T>
- Updated VanillaSprites with v35 textures
- Fixed Open Local Files Directory button
- Re enabled Monkey Knowledge getting exported from the Game Model
- Game Model Export also will create a `resources.json` file listing the GUID / resource mappings
- Added `LateApplyUpgrade` and `EarlyApplyUpgrade` methods to simplify having some parts of upgrade effects apply after/before all others

## [3.1.4] - 2023-02-16

- Updated for BTD6 v35.0 (hastened by @GrahamKracker !)

## [3.1.3] - 2023-01-28

- Fixed ModSettingHotkeys to allow easier overlap with vanilla hotkeys
- Fixed filtering mods menu empty page
- Fixes for ModSettingEnums (thanks Baydock!)
- Added BuffLocsName and BuffIconName properties to ModBuffIcons for clarity when manually applying them

## [3.1.2] - 2023-01-05

- Fixed Exporting Game Data button for modders
- Added `application/x-msdos-program` as an allowed download content type for the Mod Browser
- Increased the default mod browser download limit from 50 MB to 75 MB
  - Added a more descriptive error message for mods that are too big
- Fixed some upgrade screen UI glitches

## [3.1.1] - 2022-12-27

- Fixed a crash that a couple people were getting when placing down a Tower
- Custom tower sets will work in game again, but will still not yet be back to appearing in the Monkeys screen
- Added the "Hide Broken Mods" Mod Browser option (default true) to only show mods that have been updated to work with MelonLoader 0.6.0

### For those still having trouble switching to MelonLoader 0.6.0, [see this page](https://github.com/gurrenm3/BTD-Mod-Helper/wiki/Switching-to-MelonLoader-0.6.0)

## [3.1.0] - 2022-12-26

Same features as 3.1.0-a1, but now updated for the official 0.6.0 alpha release of MelonLoader.

Note that this MelonLoader update *breaks compatibility with old mods*. Practically all mods will need to be updated for this new version.

Will soon put together a quick migration guide for the refactoring that needs to happen.

## [3.1.0-a1] - 2022-12-22

This is a preliminary fix for Mod Helper on v34.2 using the MelonLoader build found in the 1330 studio server.
https://discord.gg/1330studios
https://discord.com/channels/758553724226109480/1055280598891110441/1055280799760519293

Reminder: MANY mods will still need to be fixed themselves to work with v34 / the new MelonLoader. Only some smaller mods will already be back working, e.g. Faster Forward

Known Issues:
Custom Tower Sets broken by v34
The usual falling back to no custom load tasks
For modders, exporting game data won't fully work

## [3.0.9] - 2022-12-10

### While LavaGang continues working to get MelonLoader compatible with the new v34 update, this is a temporary fix to allow people to more easily continue playing on v33 in the meantime (and in similar situations like this in the future).

Changes:
- Disables the mandatory Popup that forces you to update, so that you can keep playing
- Doing the above will disable Mod Helper's saving fixes to prevent data corruption

### If you've already updated to v34, here is a way you can downgrade:

1. Copy/paste the following into your web browser search bar and allow it to open Steam to access the console: `steam://nav/console`
    - This can sometimes take a couple seconds to open
2. Copy in the command `download_depot 960090 960091 8819303902483866961` to download the files for v33
    - There will be no progress indicator, so just let it run for a minute or two
    - When it's finished it'll say "Depot download complete: (path it downloaded to)"
3. Optional but recommended: create a copy of your `...\Steam\steamapps\common\BloonsTD6` folder as backup
4. Copy (not move) the newly downloaded game files from `...\Steam\steamapps\content\app_960090\depot_960091` into the
   normal game directory `...\Steam\steamapps\common\BloonsTD6`, telling it to replace the existing files
    - If you copy instead of move you can leave the base files there to copy again if Steam ever auto-updates on you
    - To help prevent auto-updating, you can go into the Steam properties page for BloonsTD6 and switch the Updates -> Automatic
      Updates option to "Only update this game when I launch it"
5. Run the game as before, and noticed the inescapable Update popup is replaced with a quite escapable one about Mod Helper
   disabling saving

### This is a stop gap measure until MelonLoader is fixed, so please do not annoy staff in the Discord servers trying to get help with this. Depending on how much you've already been playing v34 on your account, your profile may not be reconcilable with v33 anymore one way or another, and this change will just let you know that for sure.

## [3.0.8] - 2022-12-02

- Added new buttons to the mods menu for disabling all, enabling all and resetting the enabled/disabled status for all mods
  - Mod Helper is omitted from disabling
  - Mods can now also be quickly enabled/disabled by right-clicking them in the list
- Fixed ModSetting slider options sometimes showing the wrong starting value
  - ModHelperSlider components can now more easily be created with a different "starting" value than their "default" value
- Improved the performance of the Export Game Model button
- Added `UpgradePathModel.GetUpgrade` and `UpgradePathModel.GetModUpgrade` extension methods
- Made a few internal api methods accessible
- Makes the game actually respect the UpgradePathModel's requested tower ID for upgrading a tower
  - This is a subtle difference that has no effect for vanilla upgrades, but prevents the patch being needed by all mods that try funky things with UpgradePathModels
- Added `ModTower.IsUpgradePathClosed`, `ModTower.MaxUpgradePips`, `ModTower.GetUpgradePathModel` overrides

## [3.0.7] - 2022-11-07

### Added a new "Filter by Topic" option at the top right of the Mod Browser

- Filter to only show mods that have the given github topic
- Default visible options are
    - `new-towers`: Adding new custom towers to the game
    - `new-heroes`: Adding new custom heroes to the game
    - `new-bloons`: Adding new custom bloons to the game
    - `new-paragons`: Adding new paragons to base towers (modded towers that have paragons are still just `new-towers`)
    - `utility`: Quality of life changes for how you interact with the game
    - `tweaks`: Smaller changes / additions to base game play
    - `expansion`: Extensive changes / additions to base game play
    - `bosses`: Content adding or affecting bosses
    - `modes`: Adding new game modes / round sets / other ways to play
    - `maps`: Content adding or affecting maps
    - `memes`: Silly changes not meant to be taken seriously
- If you have "Show Unverified Mod Browser Content" enabled, then any other assigned topics people use will also be shown
- If another topic garners enough usage it'll be added to the default list
- Add topics to your mod through github (like the btd6-mod topic, or through `ExtraTopics` in ModHelperData)

Other changes

- Can close the Round Set Changer by clicking elsewhere on the background
- Fixed custom game mode RemoveMutators extension
- Added direct `ModGameMode.ModifyGameModel` and `ModRoundSet.ModifyGameModel` overrides
- Fixed ModSettingBool buttons not text switching
- Fixed default position of ModSetting sliders with step sizes

## [3.0.6] - 2022-10-30

- These official released versions are now cross-compatible with both regular MelonLoader and [net6 MelonLoader](https://github.com/LavaGang/MelonLoader/actions/workflows/build.yml?query=branch%3Acoreclr-reborn)
  - The build-net6.yml github action will still be in effect just to keep an eye on compatibility with compiling for net6
- Added a spinner icons for when background tasks are in progress in mods menu / browser
- Added the `OnGameDataLoaded` hook
- Added `BloonsMod.AddContent` methods
- Prevented non-vanilla towers from being chosen for Insta Monkeys (theoretically)
- Updated VanillaSprites for v33 and added a `ByName` string lookup
- Added `AttackModel.SetWeapon` helper extension
- Some fixes to `ModCustomDisplay` and `ModTowerCustomDisplay`
- Fixed a niche situation where mod browser mods could load the wrong icons
- Fixed a crash when exiting the mod browser while a download was in progress
- Mod Browser will now correctly refresh if Mods haven't finished populating yet when you first open it
- Re-added UnityDisplayNode DumpTextures extension

## [3.0.5] - 2022-10-20

- Fixed visual side effect where monkeys visuals weren't always being removed after exiting a match

## [3.0.4] - 2022-10-20

Fixed Custom Load Task Functionality

- Back to no longer freezing the process while mod tasks are being run
  - If you prefer that behavior however (since it can be slightly faster depending on your situation), you can enable the "Use Old Loading" Mod Helper Setting.
  - You can also now press space bar during the title screen to switch to running the rest of the startup this way
- Custom load tasks now support using the Progress Bar and having subtext for progress
  - Use `ShowProgressBar => true` and set `Progress = ...` throughout the coroutine
  - For sub text use `Description = "..."` during the coroutine.

## [3.0.3] - 2022-10-12

Initial Fixes for BloonsTD6 v33.0

- Added the `FileIOHelper` class that replicates the methods of `FileIOUtil` that've been removed in v33.0
- Fixed the try-catching of Harmony Patches that wasn't working correctly on official release ML 0.5.5.
- **Reverted to the old loading system** until I update our custom load tasks to the new way NK is doing it internally
    - This means we're temporarily going back to freezing after Step 8 of 8 to wait for mods to load rather than having our
      own steps

Also as a PSA about MelonLoader, if things ever seem TOO frozen on Step 8 of 8, with no more log messages appearing,
check that you haven't accidentally clicked into the console as below, as that can stall things

![console clicking infographic](https://media.discordapp.net/attachments/800115046134186026/1029864079873032253/unknown.png)

## [3.0.2] - 2022-09-30

- Updated for the official MelonLoader v0.5.5 release

Use this version of the mod alongside the MelonLoader 0.5.5 you get from the official installer, not the github actions / nightly builds that have been linked previously.

## [3.0.1] - 2022-08-16

### See the [Install Guide](https://github.com/gurrenm3/BTD-Mod-Helper/wiki/Install-Guide) if this is your first time downloading

- Added the `SquareIcon` ModHelperData bool property to make the icon draw as constrained within panels rather than being allowed to slightly overflow
- Added an impossible to miss Popup for if you're not using a compatible MelonLoader version
- Added the ability to use a `<!--Mod Browser Message Start-->` markdown comment in release messages to only include information beyond a certain point
- Added checkmark icons for Verified Modders in the Mod Browser
- Fixed issue where Double Cash mode was doubling cash generation it wasn't supposed to
- Fixed Round Set Changer setting
- Fixed sporadic issue with backing out of a Mod Settings menu
- Fixed `OnMenuClosed()` still happening if you pressed Escape too early for the menu to actually close
- Fixed monorepo mods using ZipName without DllName not showing up in the Mod Browser
- Internally switched from `.parent =` to `SetParent` calls to avoid flooding the MelonLoader debug log

## [3.0.0] - 2022-08-13

### Mod Helper 3.0 Update

A long time in the making, this update finishes the v32.0 fixes for Sprites / Displays and adds a ton of other stuff.

#### What's most important to immediately know about installing this update is that it requires [MelonLoader v0.5.5](https://github.com/LavaGang/MelonLoader/suites/7738215183/artifacts/324586390) and that the DLL name has changed. See the new [Install Guide](https://github.com/gurrenm3/BTD-Mod-Helper/wiki/Install-Guide) page for further details.

The most notable 3.0 addition is a revamped <u>Mods Menu</u> and new <u>In-Game Mod Browser</u>, which you can use to view and download mods updated for 3.0 that have been published on GitHub.
See the [3.0 Update Overview](https://github.com/gurrenm3/BTD-Mod-Helper/wiki/3.0-Update-Overview) page for a more comprehensive list of changes (there's a lot!).

For modders, I've put together a [3.0 Migration Guide](https://github.com/gurrenm3/BTD-Mod-Helper/wiki/%5B3.0%5D-Migration-Guide) page for information about how to best make use of the new features.


Note that this is not a universal fix for every mod broken by v32.0, many mods will still need to apply similar fixes to the ones done internally in Mod Helper before they'll be working again.

Also, this update has been in public alpha for a couple weeks now, but there still may need to be some hotfix updates within the days following this release. Luckily they'll be easily downloadable from right within your BTD6 game :D

Special thanks to Silentstorm, GrahamKracker, CommanderCat, and chrisroberts777 for doing as much testing as they did!

Hope everyone enjoys <3

-doombubbles

![Mods Menu](https://media.discordapp.net/attachments/800115046134186026/1007790104904998932/unknown.png)

![Mod Browser](https://media.discordapp.net/attachments/800115046134186026/1007790297025106040/unknown.png)

## [2.4.11] - 2022-08-05

BTD6 Update 32.0 has come with a lot of breaking changes. Most significantly it has broken the current strategies used by Mod Helper and other modders for using custom SpriteReferences and displays. This update *DOES NOT YET* fix those things.

This update disables those broken systems internally and fixes the rest of the new runtime errors, allowing other mods that don't rely on that to still function in the mean time while a bigger overhaul is in the works.

For modders: creating a sprite reference via `new SpriteReference(guid)` can now cause game crashes. Instead you now should use [object intializer syntax](https://docs.microsoft.com/en-us/dotnet/csharp/programming-guide/classes-and-structs/how-to-initialize-objects-by-using-an-object-initializer) like ` new SpriteReference { guidRef = guid }` or by using `ModContent.CreateSpriteReference(guid)` if you want to avoid having to ever change it again yourself. Same applies to the new type `PrefabReference` added in this update.

Custom tower / paragon mods may or may not functionally work depending on if modders have updated them based on the above changes, but visually their custom images will be white squares / random and their custom displays invisible / wrong.

## [2.4.10] - 2022-06-15

@Sewer56 has contributed some new useful features to our Co-Op / Networking API !

You can check out the new mods they've made to utilize these features [here](https://github.com/Sewer56/BloonsTD6.Mod.SalariedMonkeys) and [here](https://github.com/Sewer56/BloonsTD6.Mod.MultiUser)

For modders, they've also graciously provided documentation which can be found [here](https://github.com/gurrenm3/BTD-Mod-Helper/pull/42#issue-1259156902)

(also yup .10 lol, this is semantic versioning not decimals, don't @ me)

## [2.4.9] - 2022-06-01

Fixed an issue in co-op where the tower selection menu wouldn't visually update properly after upgrading a tower.

## [2.4.8] - 2022-04-21

Custom heroes will now appear in the new revamped Hero screen
Updated progress saving to account for an internal rename in v31.1
Improved the progress saving's MethodInfo targeting to be more robust against future renames

## [2.4.7] - 2022-04-19

Updates the Mod Helper's re-enabling of progress saving to account for changes in v31.0
New map saves should now once again be correctly getting created at the end of each round

## [2.4.6] - 2022-04-13

Preliminary fixes for v31.0
Fixing compilation errors based off NK's internal refactoring
With that new Hero Screen overhaul, custom hero fixes will take some more time and come in a later update

## [2.4.5] - 2022-03-17

Fixes to account for internal changes in BTD6 v30.2.5

## [2.4.4] - 2022-02-13

Small follow up to the previous release fixing saving in some more situations

## [2.4.3] - 2022-02-12

With BTD6 v30.0, Ninja Kiwi made it so that progress can not be saved on your profile if it detects that you have mods, or even just MelonLoader, installed. We think that they have gone too far with this change, and that it is not consistent with their stated goal in the patch notes of trying "not to detract from modding". So, this Mod Helper update overrides that restriction and will allow progress to be saved once more.

To be clear, all other restrictions on modded clients will still be in effect, including their latest trophy-related changes.

## [2.4.2] - 2022-02-08

- Fixes for update 30.0
- New extension method for dumping all renderers of a UnityDisplayNode (thanks @Void-n-Null!)
- Configurable export path / sandbox root in Mod Settings (thanks @Onixiya!)

## [2.4.1] - 2021-12-26

- Fixed the tower selection sound also playing when upgrading a tower
- Fixed a crash when playing BTD6 without being logged in

## [2.4.0] - 2021-12-22

After a victorious war against unjust hacker pooling, Custom Heroes are now supported by the Mod Helper! For modders, this comes in the form of the `ModHero` and `ModHeroLevel` classes (which work similar to `ModTower` and `ModUpgrade` respectively). Heroes can have the full 20 levels, up to 3 Abilities and are fully integrated into the game's UI.

A disclaimer: to avoid mistaken hacker pooling, the Mod Helper's profile cleaning will always save your selected hero as Quincy instead of a Custom Hero, both inside of games and outside. It's slightly janky I admit, but it's better than getting hacker pooled (insert "I guide others to a treasure I cannot possess" meme here).

Other additions include:

- Simple cross mod interaction through the `Call(operation, ...parameters)` override within a `BloonsMod`. Other mods will be able to do `ModContent.GetMod("YourModName")?.Call("AnOperationName", ...)` to execute your `Call` in whatever way you want to set it up.
- Internal improvements to the `ModContent` system, allowing Mods to add their own `ModContent` (more on this coming soon)
- `ModVanillaTower` and `ModVanillaUpgrade` classes meant as beginner-friendly ways to modify vanilla towers and upgrades (will make wiki posts about them)
- `RestrictUpgrading(tower)` override in ModUpgrade that lets you more dynamically determine whether an upgrade should be blocked
- New mod setting for automatically dismissing the Modded Client warning (thanks @Void-n-Null!)

While I was developing custom hero capability I also made an example hero for people to play with and see the source code of a la Card Monkey. So, meet [Norman, the Industrial Farmer](https://github.com/doombubbles/IndustrialFarmer#readme), another economy oriented hero as an alternative to Benjamin, featuring synergies with top path Banana farms.

## [2.3.2] - 2021-12-15

Features:

- New `OnDegreeSet` and `ModifyPowerDegreeMutator` methods that can be overriden in `ModParagonUpgrade` to further customize your paragon based on its degree
- New `AllowInRestrictedModes` property that can be override in `ModTowerSet` to control if the set should be usable in Primary/Military/Magic Only modes (defaults to false)
- (Since v2.3.1) A mod's `MelonPriority` attribute can control the order in which Mod Helper content is added and hooks are run in relation to other mods
- (Since v2.3.1) The `ModVanillaParagon` class can be used to create a custom paragon (`ModParagonUpgrade`) for a Vanilla tower

Fixes:

- Fixed a crash when looking at the upgrades screen for a ModTower with no upgrades

## [2.3.1] - 2021-12-09

This update adds a few extra helpful extension methods and updates the mod helper to BTD6 version 29.0

The mod helper now also has a setting (true by default) to clean player profiles of some of the information commonly added by mods (e.g. unlocked towers, unlocked upgrades etc) before sending the data to NK.

## [2.2.0] - 2021-10-31

**New Features:**
- Paragons for Custom Towers can now be easily created
- Monkeys menu now shows custom towers
- Custom tower sets can be made, which also fully integrate with the Monkeys menu

**Fixes:**
- Lych boss no longer crashes the game

Until the wiki is updated, modders interested in utilizing these new features can look at these Card Monkey commits as examples: [Custom Paragons](https://github.com/doombubbles/card-monkey/commit/3f278173eef9ccdfabe6c199a09b3c1f31e76e86) and [Custom Tower Sets](https://github.com/doombubbles/card-monkey/commit/090516ae0b3488ea19a231eea5db4beadbe3d48e)

## [2.1.2] - 2021-10-16

## [2.1.1] - 2021-10-15

This version of the mod helper comes with a few changes and has been updated to work with BTD6 version 28.0. The small changes include a few more helpful extension methods like "List.SaveToFile" and "List.LoadFromFile", as well as some extra support for modding Bloons and Powers

## [2.1.0] - 2021-09-10

This update begins support for automatic importing of custom displays from Unity asset bundles. These can be used via the ModCustomDisplay and ModTowerCustomDisplay classes in a similar way to ModDisplay and ModTowerDisplay. There's also ModContent.GetBundle methods to go along with these.

There's also a new AddTowersToGame extension method that can more efficiently add large amounts of new TowerModels to the game (I wonder which mod needed that 👀 ).

Other than that just some typo fixes and improvements to handling MeshRenderers.

## [2.0.5] - 2021-08-27

This update features:

- A fix for non-github-releases mod auto updating
- Better AutoSave error handling
- New Mod Options buttons for exporting TowerModels and UpgradeModels to JSON files, and opening the BloonsTD6 local folder
- For modders, an UpgradeType class for if you want to strongly type Upgrade IDs like you can TowerIDs with NinjaKiwi's TowerType class

## [2.0.4] - 2021-08-24

This update features:
- Improved Mod Settings GUI
- Fix Mod Settings Button overlap with Twitch Button
- Fix some Mod Settings bugs
- Minor internal improvements to the ModTower system
- Autosave feature backs up your player save every 10 minutes

## [2.0.3] - 2021-07-29

This is a small update to version 2.0.2. There was a couple bugs remaining in it so they have been fixed. Additionally the mod helper now uses the latest version of Melonloader. Lastly, some extra support for Mod Options has been added, so you can now

Make sure to only download one of the mod helpers from below, the one that's for the game you want to mod

### NOTE:
#### This version requires the latest version of Melonloader

## [2.0.2] - 2021-07-28

These are the latest and most updated versions of the mod helper for BTD6 and BATTD.

### **NOTE:**
Only download **ONE** of the zip files. Make sure it's the one for the game you want to play mods with

## [2.0.1] - 2021-07-02

* Fixed a bug where In Game mod settings could reset to default on startup
* Fixed the `InGame.instance.AddCash` and `InGame.instance.SetCash` extension methods
* Fixed Upgrade Screen for ModTowers without the full 15 upgrades
* Fix MelonLoader v0.4 less Bloon children bug by temporarily disabling the OnBloonDestroyedHook (There appears to be a real issue with the new HarmonyX altering the default behavior of methods)

## [2.0.0] - 2021-06-29

At long last, the Mod Helper 2.0 Update is ready! This is our biggest update yet, featuring:
- A brand new system for making Custom Towers!
      - Automates all the tedious bits of Tower adding
      - Automatically generates full cross pathing
      - Seamlessly adds the Tower Upgrades menu and even more integration (They even show up in Monkey Teams lol)
      - Allows for 2D and 3D towers with easy complete texturing
- In Game Mod Settings, configurable via a Button / Menu within the Settings screen
- Automatic custom texture registering for mods (no more dealing with URLs)
- A shiny new Wiki with information about Getting Started with Modding, General Modding Info, and using Mod Helper features

The Mod Helper is now compatible with MelonLoader v0.4 as well as v0.3. Exclusive compatibility with v0.4 and beyond will happen in a later update

## [1.0.3] - 2021-04-26

Previous Mod Helper releases will fail to automatically update themselves to new versions.
This release temporarily switches back to the download button just opening the download link in a browser, just for the case of trying to update the Mod Helper itself.

## [1.0.2] - 2021-04-24

Improved mod updater so now anyone can setup auto-updating for their mod. This release also has a few small tweaks that can improve performance a bit

## [1.0.1] - 2021-04-19

This release comes with a Task Scheduler! You can use it to schedule code to run after a number of seconds or frames have passed. Also comes with some more documentation.

## [1.0.0] - 2021-04-18

Initial release of the new Mod Helper
