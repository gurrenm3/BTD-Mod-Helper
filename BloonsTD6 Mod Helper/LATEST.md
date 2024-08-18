## Many Localization Updates

### General

- Added a new button in the Mods Menu to export a mod's localization to a json file, which can be edited to change its
  supported displayed text for your language
  - This goes to a newly added subfolder `Mods/BloonsTD6 Mod Helper/Localization/[Language]`
  - Edits to files will refresh without requiring a game restart
- Added a new [Translation Tool page on the website](https://gurrenm3.github.io/BTD-Mod-Helper/tools/translate) that can
  easily put Localization files through Google translate for individual or all supported languages
- The text in mods that should be automatically supported for localization editing includes
  - Names and Descriptions for Towers, Upgrades, Heroes, Bloons etc
  - Names and Descriptions for Mod Settings
  - General mod info like the description

### For Modders

- The standard btd6.targets import will now automatically embed `/Localization/[Language].json` files in your mod
  project
  - Use the Localization Button on your own mod with active language English to get a basis json for your mod
  - If you press the "Translate All" button on the site it will create a .zip file with all the correctly named .json
    files you'd need
- ModHelperText and ModHelperDropdown components now Localize their texts by default
- For Localization Entries, putting text within [Square Brackets] will make it try to fetch existing localization for
  that key
  - e.g. `The description is [DartMonkey Description]` ->
    `The description is Throws a single dart at nearby Bloons. Short range and low pierce but cheap.`
- Added new `ModContent.Localize` methods that can add new mod specific localizations from variables
  ```csharp
  private static readonly string DoTheThing = ModContent.Localize<MyMod>(nameof(DoTheThing), "Do The Thing!");
  ```
  Or if already within a ModContent descendent class
  ```csharp
  private readonly string DoTheThing = ModContent.Localize(nameof(DoTheThing), "Do The Thing!");
  ```
  The result assigned to the `DoTheThing` is your mod specific localization key, that you can use in a `ModHelperText.SetText(...)` directly or as `DoTheThing.Localize()` otherwise
- As before, you can still override the `RegisterText` method in any class that extends `NamedModContent` to
  directly add extra stuff to the text table
  ```csharp
  public override void RegisterText(Il2CppSystem.Collections.Generic.Dictionary<string, string> textTable)
  {
      base.RegisterText(textTable); // Call the base to still register DisplayName / Description
            
      textTable[Id + " Long Description"] = LongDescription; // More specific stuff to your ModContent
  }
  ```