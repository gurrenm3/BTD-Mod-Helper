## Misc Updates

- Added a button that lets you open the Mods Menu from the In Game Pause Screen
  - This includes opening Mod Settings menus, but not many settings yet will probably live update in a game
- Added a button in the Mods Menu that can display the SHA 256 hashes of active mods
- Added a new `ModTower.IncludeInMonkeyTeams` override
- Fixed some inconsistencies where some simulation behavior extensions would throw exceptions instead of just returning null
- ModHelperData now supports multiline raw strings for descriptions, [example](https://github.com/doombubbles/ability-choice/blob/699658591855043372a128294de679670600e3c1/ModHelperData.cs#L10)

## Localization Updates

### General

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

### For Modders

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
