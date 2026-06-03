<!--Mod Browser Message Start-->

- Fixes for BTD6 v55
- Added `OnUpgraded` overrides for `ModUpgrade` and `ModTower`
- `ModGameMode`s will now once again show up as options for being used on Custom Maps and Challenges (though you can't share a challenge of a custom mode)
- `btd6.targets` now has new functionality using C# Source Generators to populate an internal `ModResources` class with strongly typed entries for all your embedded resources
  - For example, for your Icon.png it would have `internal static readonly SpriteResource<YourMod> Icon = new("Icon");` and then `ModResources.Icon` can be used to retrieve the icon as a string, SpriteReference, or full Sprite as needed
  - Can opt out by putting `<ModHelperSourceGenerators>false</ModHelperSourceGenerators>` in your csproj