### Export Localization Button

Mod Helper 3.2 added a new button in the Mods Menu to export a mod's localization to a json file, which can be edited to
change its supported displayed text for your language

- This goes to a newly added subfolder `Mods/BloonsTD6 Mod Helper/Localization/[Language]`
- Edits to files will refresh without requiring a game restart
- It also added a new [Translation Tool page on the website](https://gurrenm3.github.io/BTD-Mod-Helper/tools/translate)
  that can
  easily put Localization files through Google translate for individual or all supported languages

### New Localization Behavior

For Localization Entries, putting text within [Square Brackets] will make it try to fetch existing localization for that
key, e.g.

`The description is [DartMonkey Description]` ->
`The description is Throws a single dart at nearby Bloons. Short range and low pierce but cheap.`

Additionally, `ModHelperText` and `ModHelperDropdown` components Localize their texts by default.

The text in mods that should be automatically supported for localization editing includes

- Names and Descriptions for Towers, Upgrades, Heroes, Bloons etc
- Names and Descriptions for Mod Settings
- General mod info like the description

### Adding More Localization Keys

Classes like `ModTower`, `ModUpgrade` etc that extend from `NamedModContent` already automatically use localization keys
for their common text fields like `DisplayName` and `Description`. For adding more localized text, there are two
added options by mod helper (apart from just editing `LocalizationManager.Instance.defaultTable` directly)

#### ModContent.Localize Calls

`ModContent.Localize` methods can add new mod specific localizations from variables

```csharp
private static readonly string DoTheThing = ModContent.Localize<MyMod>(nameof(DoTheThing), "Do The Thing!");
```

Or if already within a ModContent descendent class

```csharp
private readonly string DoTheThing = ModContent.Localize(nameof(DoTheThing), "Do The Thing!");
```

The result assigned to the `DoTheThing` is your mod specific localization key, that you can use in a
`ModHelperText.SetText(...)` directly or as `DoTheThing.Localize()` otherwise

Generally speaking you'd want to use `ModContent.Localize` exactly as above, either a static variable anywhere,
or an instanced variable inside a ModContent class. Other usages than that would still work, but would not make their
localization key appear for purposes of the Export Localization button.

#### NamedModContent.RegisterText Override

Override the `RegisterText` method in any class that extends `NamedModContent` to directly add extra stuff to the text
table.

```csharp
public override void RegisterText(Il2CppSystem.Collections.Generic.Dictionary<string, string> textTable)
{
    base.RegisterText(textTable); // Call the base to still register DisplayName / Description
          
    textTable[Id + " Long Description"] = LongDescription; // More specific stuff to your ModContent
}
```

### Supporting Other Languages

The standard btd6.targets import automatically embeds `/Localization/[Language].json` files in your mod
project.

You can use the Localization Button on your own mod with active language English to get a basis json for your mod

TIP: If you press the "Translate All" button on the [site](https://gurrenm3.github.io/BTD-Mod-Helper/tools/translate) it
will create a .zip file with all the correctly named .json files you'd need so you can just put those directly in
your Localization folder.