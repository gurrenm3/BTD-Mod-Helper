- Added a new `export assets` command that locally exports all the addressable sprite textures in an organized way
- Added a `precisionDigits` field to `ModSettingDouble` / `ModSettingFloat` to control rounding
- Cleaned up the internals of some il2cpp extensions

### ModArtifact

- Added a new property `SmallIcon` that can be overriden to resize the icon so using most VanillaSprites will be framed
  correctly
- Added overrides for `OnActivated(Simulation simulation, int tier)` and
  `ModifyGameModel(GameModel gameModel, int tier)` for easier custom artifact effects
- Added new methods `string InstaMonkey(int tier)` and `int[] InstaTiers(int tier)` that can be overriden to set up
  artifact's Insta Monkey and automatically adds it to the description
- Added new ArtifactModel extension methods `AddTowerBehavior`, `AddTowerBehaviors`, `AddProjectileBehavior`,
  `AddProjectileBehaviors` that work similar to `AddBoostBehavior` but via `AddTowerBehaviorsArtifactModel` and
  `AddProjectileBehaviorsArtifactModel`