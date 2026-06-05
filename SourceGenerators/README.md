# Btd6ModHelper.SourceGenerators

Source generators for [BTD6 Mod Helper](https://github.com/doombubbles/BTD-Mod-Helper) mods.

Auto-generates a strongly-typed `ModResources` class so you can reference your embedded resources by name without typos and without writing string literals.

## What it generates

For every `EmbeddedResource` in your mod project with a known extension, a `static readonly` field is emitted on the `ModResources` class:

| Extension                                               | Type                      |
|---------------------------------------------------------|---------------------------|
| `.png`, `.jpg`                                          | `SpriteResource<TMod>`    |
| `.wav`, `.mp3`, `.ogg`, `.flac`, `.aac`, `.wma`, `.m4a` | `AudioClipResource<TMod>` |
| `.bundle`                                               | `BundleResource<TMod>`    |
| `.json`                                                 | `JsonResource<TMod>`      |

`TMod` is auto-detected as the concrete class in your project that inherits from `BloonsMod`.

If you have a series of numbered audio clips (`pop1.wav`, `pop2.wav`, `pop3.wav`, ...), a `RandomizedAudioClipResource<TMod>` named after the shared base (`pop`) is also generated — unless an audio clip with that exact base name already exists.

## Install

```xml

<PackageReference Include="Btd6ModHelper.SourceGenerators" Version="1.0.0" PrivateAssets="all"/>
```

`PrivateAssets="all"` keeps the generator out of your mod's runtime dependencies.

This package only does anything in projects that already import `btd6.targets` from BTD6 Mod Helper — the targets file is what exposes your `EmbeddedResource` items to the generator.

## Opt out

Set `<ModHelperSourceGenerators>false</ModHelperSourceGenerators>` in your csproj to skip the generator entirely.


## Publish
```
dotnet nuget push bin/Debug/Btd6ModHelper.SourceGenerators.X.X.X.nupkg -k $(op read "op://Private/Microsoft/nuget api key")
```