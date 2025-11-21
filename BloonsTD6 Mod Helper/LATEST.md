## NOTE: As of this release, BTD6 still needs the latest NIGHTLY build of MelonLoader. 0.7.0 or 0.7.1 will not work. [See the Install Guide](https://gurrenm3.github.io/BTD-Mod-Helper/wiki/Install-Guide)

<!--Mod Browser Message Start-->

- Added support for using .ogg files for audio
  - btd6.targets will now automatically mark .ogg files as Embedded Resources
- Fixed issue where custom sounds could stop being available via PrefabReference from the AudioFactory after quitting a match
- Added better support for ModGameModes using and modifying `DailyChallengeModel`s for games
  - Override `ApplyChallengeRules` to true to make normal games have challenge rules (since they otherwise don't)
  - Override `ModifyChallengeRules(DailyChallengeModel)` to edit challenge rules