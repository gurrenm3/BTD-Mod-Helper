<!--Mod Browser Message Start-->

- Made it so that the `DisableMonkeyKnowledgeModModel` will actually have an effect for `ModGameMode`s (even though it apparently has no actual effect in the base game, it's all hardcoded)
- Fixed error when trying to prime a `ModCustomInput` without an associated Tower
- Added an override `ModCommand.SuggestionsForValue` that lets you populate custom autocomplete suggestion strings for your `[Value]` arguments
- Improved the loading for `ModSetting`s that are manually added late into the `ModContent` Registration phase
- Added a `ModHelper.LoadPhase` enum in case anyone needs to check what load phase ModHelper is in
  - PreLoading -> Loading -> PreRegistration -> Registration -> PostRegistration