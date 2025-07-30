- Fixed embedded audio track length for non-stereo (mono) .wav and .mp3 files
- Fixed an error in the hero screen for custom heroes
- Added some new ModHelperComponents and ModContent classes that help in making general purpose ingame UI windows / menus
  - [ModStartMenuEntry](https://gurrenm3.github.io/BTD-Mod-Helper/docs/BTD_Mod_Helper.Api.UI.ModStartMenuEntry) -
    ModContent that defines a button in a new ingame "Start Menu" that appears if any mods make entries for it
    - Useful for making custom mod actions be triggerable by the user without needing a hotkey
  - [ModWindow](https://gurrenm3.github.io/BTD-Mod-Helper/docs/BTD_Mod_Helper.Api.UI.ModWindow) - ModStartMenuEntry that
    creates an entry for opening a custom moveable+resizable UI window
  - [ModHelperWindow](https://gurrenm3.github.io/BTD-Mod-Helper/docs/BTD_Mod_Helper.Api.Components.ModHelperWindow) -
    The underlying ModHelperComponent that powers ModWindows, but can be used separately
  - [ModHelperPopupMenu](https://gurrenm3.github.io/BTD-Mod-Helper/docs/BTD_Mod_Helper.Api.Components.ModHelperPopupMenu) -
    ModHelperComponent that powers the options / right click menus of ModHelperWindows, but can be used separately
    - [ModHelperPopupOption](https://gurrenm3.github.io/BTD-Mod-Helper/docs/BTD_Mod_Helper.Api.Components.ModHelperPopupOption) -
      ModHelperComponent for the entries to popup menus
    - [ModHelperPopDown](https://gurrenm3.github.io/BTD-Mod-Helper/docs/BTD_Mod_Helper.Api.Components.ModHelperPopdown) -
      ModHelperComponent that is an alternatively implemented ModHelperDropdown using a ModHelperPopupMenu