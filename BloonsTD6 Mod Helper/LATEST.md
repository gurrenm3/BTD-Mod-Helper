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