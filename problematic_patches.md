# Problematic Patches List

### An unfortunate drawback of using Harmony Patches is that sometimes just their existence on a method can cause unexpected side effects on the original. This is a non-exhaustive list of known bad patches.

## General

- As of v32.0, nearly every method that has a `SpriteReference`, `PrefabReference` or `AudioSourceReference` as a
  parameter will have side effects ranging from crashing the game to preventing the original from running. (This was the
  cause of the v32.0 custom display crisis). E.g.
    - `Factory.FindAndSetupPrototypeAsync`
    - `ResourceLoader.LoadSpriteFromSpriteReferenceAsync`

## Specific Methods

| Method                             | Side Effect                                             | Last Checked Version | Reported By |
|------------------------------------|---------------------------------------------------------|----------------------|-------------|
| `Simulation.AddCash`               | Double cash affects income generation when it shouldn't | v32.0                | doombubbles |
| `InputManager.CreateTowerAt`       | Free dart monkeys never stop being free                 | v32.0                | doombubbles |
| `TSMThemeDefault.TowerInfoChanged` | Paragon sacrifices dont actually remove the towers      | v32.0                | doombubbles |
| `TowerManager.CreateTower`         | Tower cost payments dont resolve                        | v32.0                | doombubbles |
