## NOTE: As of this release, BTD6 still needs the latest NIGHTLY build of MelonLoader. 0.7.0 or 0.7.1 will not work. [See the Install Guide](https://gurrenm3.github.io/BTD-Mod-Helper/wiki/Install-Guide)

<!--Mod Browser Message Start-->

- For modded Paragons, it's no longer required for the player to use them in a real game before they are usable in Sandbox
- Improved the Mod Browser's search functionality to switch to ordering by Relevance by default while searching
  - Also made this change for the website Mod Browser
- Added some more misc extensions such as
  - `model.HasBehavior<T>(nameContains)` and `model.HasDescendant<T>(nameContains)` (no out param)
  - `model.Duplicate(m => ...)` duplicate with function for inline changes
  - `.StartCoroutine()` for both normal and Il2Cpp IEnumerators