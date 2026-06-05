<!--Mod Browser Message Start-->

- Made it so that the `DisableMonkeyKnowledgeModModel` will actually have an effect for `ModGameMode`s (even though it apparently has no actual effect in the base game, it's all hardcoded)
- Fixed error when trying to prime a `ModCustomInput` without an associated Tower
- Added an override `ModCommand.SuggestionsForValue` that lets you populate custom autocomplete suggestion strings for your `[Value]` arguments