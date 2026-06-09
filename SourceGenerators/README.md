# Btd6ModHelper.SourceGenerators

Source generators for [BTD6 Mod Helper](https://github.com/doombubbles/BTD-Mod-Helper) mods.

## `ModResources`

Auto-generates a strongly-typed `ModResources` class so you can reference your embedded resources by name without typos and without writing string literals.

For every `EmbeddedResource` in your mod project with a known extension, a `static readonly` field is emitted on the `ModResources` class:

| Extension                                               | Type                      |
|---------------------------------------------------------|---------------------------|
| `.png`, `.jpg`                                          | `SpriteResource<TMod>`    |
| `.wav`, `.mp3`, `.ogg`, `.flac`, `.aac`, `.wma`, `.m4a` | `AudioClipResource<TMod>` |
| `.bundle`                                               | `BundleResource<TMod>`    |
| `.json`                                                 | `JsonResource<TMod>`      |

`TMod` is auto-detected as the concrete class in your project that inherits from `BloonsMod`.

If you have a series of numbered audio clips (`pop1.wav`, `pop2.wav`, `pop3.wav`, ...), a `RandomizedAudioClipResource<TMod>` named after the shared base (`pop`) is also generated — unless an audio clip with that exact base name already exists.

## GitHub Actions workflow

If your project already has a `.github/workflows/build.yml`, the generator will keep that file in sync with values from your `ModHelperData` (currently `PROJECT_NAME` and `DLL_NAME`).

- The generator only touches files that already exist — delete `.github/workflows/build.yml` to opt out for the project.
- Opt out at the csproj level with `<GenerateActionsWorkflow>false</GenerateActionsWorkflow>`.

## Opt out

Set `<ModHelperSourceGenerators>false</ModHelperSourceGenerators>` in your csproj to skip all generators.

Set `<GenerateModResources>false</GenerateModResources>` to skip just the ModResources generator.

Set `<GenerateActionsWorkflow>false</GenerateActionsWorkflow>` to skip just the workflow generator.