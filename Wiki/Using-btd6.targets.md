`btd6.targets` is an MSBuild file that helps wire up all the common things a BTD6 mod project needs: references to MelonLoader, the Il2Cpp game assemblies, Mod Helper itself, and other mods you depend on, plus the post-build steps that copy your DLL into the game's `Mods` folder.

When you make a mod using the "Create Mod" button / default template, it will automatically be setup to use `btd6.targets` properly.

# Where it comes from

Mod Helper writes `btd6.targets` (and a matching `launchSettings.json`) into your **Mod Sources** folder — usually `Documents/BTD6 Mod Sources` — on game startup. The file is embedded inside `Btd6ModHelper.dll`, so it gets refreshed automatically when you update Mod Helper.

A mod project picks it up with a single line near the bottom of its `.csproj`:

```xml

<Import Project="..\btd6.targets"/>
```

That assumes your mod's project folder lives directly inside Mod Sources (next to the `btd6.targets`).
If you ever download the source code of another person's mod who used btd6.targets, once you put it into your own Mod Sources folder, all of the references should just work.

# What it sets up for you

## Properties

`btd6.targets` defines many useful MSBuild propertes

| Property                             | Default                                                   | What it does                                                                                                                                    |
|--------------------------------------|-----------------------------------------------------------|-------------------------------------------------------------------------------------------------------------------------------------------------|
| `BloonsTD6`                          | `C:\Program Files (x86)\Steam\steamapps\common\BloonsTD6` | Absolute path to your BTD6 install. Auto-set by Mod Helper when it regenerates the file.                                                        |
| `Il2CppAssemblies`                   | `$(BloonsTD6)\MelonLoader\Il2CppAssemblies`               | Folder of generated Il2Cpp proxy DLLs.                                                                                                          |
| `ManagedFolder`                      | `$(BloonsTD6)\MelonLoader\net6`                           | MelonLoader's managed runtime folder.                                                                                                           |
| `OutputFolder`                       | `Mods`                                                    | Subfolder under `$(BloonsTD6)` that the post-build step copies your DLL into. Could be overriden to something like "Plugins" or "Disabled Mods" |
| `RunCommand` / `RunWorkingDirectory` | `$(BloonsTD6)\BloonsTD6.exe` / `$(BloonsTD6)`             | Make `dotnet run` launch the game with the working directory set to the install folder.                                                         |

## References

1. **MelonLoader** — `MelonLoader.dll` and `0Harmony.dll` from `$(ManagedFolder)`.
2. **The Il2Cpp game assemblies** — Assembly-CSharp, the Il2Cpp Unity bindings, Newtonsoft, etc. All `Private="false"`, so nothing gets copied into your `bin/` output. (Skipped entirely if `JustMelonloader=true`.)
3. **Mod Helper itself** — `$(BloonsTD6)\Mods\Btd6ModHelper.dll`, unless `DontReferenceModHelper=true`.
4. **Other mods you depend on** — driven by the `<Dependencies>` property (see below).

## Auto-embedded resources

Unless you set `<AutoEmbed>false</AutoEmbed>`, every asset under your project folder matching common art / audio / data extensions is included as an `EmbeddedResource`:

- Images: `*.png`, `*.jpg` (excluding `Screenshot*.png`)
- Audio: `*.wav`, `*.mp3`, `*.ogg`, `*.flac`, `*.aac`, `*.wma`, `*.m4a`
- Data: `*.bundle`, `*.bytes`
- Localization JSON under `Localization/`
- `ModHelperData.json` / `ModHelperData.txt` at the project root

These are what `ModContent.GetSprite(...)`, `ModContent.GetAudioClip(...)`, etc. look up at runtime.

## Post-build steps

`MoveDllToMods` / `MoveXmlToMods` copy your built DLL and optional XML doc file into `$(BloonsTD6)\$(OutputFolder)`. Before overwriting, the previous version of the DLL is moved aside to `$(BloonsTD6)\BTD6ModHelper\Old Mods\` so a running game can still finish using it.

`SyncLaunchSettings` copies the `launchSettings.json` next to `btd6.targets` into your project's `Properties/` folder on every build so the "BloonsTD6", "BloonsTD6 (Tests)", etc. profiles stay current. Set `DontCopyLaunchSettings=true` to opt out (e.g. if you want to customize it).

# Customization properties

All of these are set inside a `<PropertyGroup>` in your `.csproj`, before the `<Import Project="..\btd6.targets" />`.

| Property                                                | Effect                                                                                                                                                 |
|---------------------------------------------------------|--------------------------------------------------------------------------------------------------------------------------------------------------------|
| `<Dependencies>OtherMod;AnotherMod</Dependencies>`      | Adds a `Reference` per name, resolved against `$(BloonsTD6)\Mods\<Name>.dll` (or `Disabled Mods\<Name>.dll` as a fallback). Semicolon-separated.       |
| `<OutputFolder>Plugins</OutputFolder>`                  | Build into a folder other than `Mods`.                                                                                                                 |
| `<ProjectName>SomethingElse</ProjectName>`              | Renames the *output* DLL (used by Mod Helper itself to ship as `Btd6ModHelper.dll` while the assembly stays `BloonsTD6 Mod Helper` for posterity).     |
| `<DontReferenceModHelper>true</DontReferenceModHelper>` | Skips the implicit reference to `Btd6ModHelper.dll`. Mod Helper's own project uses this to avoid referencing itself.                                   |
| `<DontCopyLaunchSettings>true</DontCopyLaunchSettings>` | Stop overwriting your `Properties/launchSettings.json` on build.                                                                                       |
| `<JustMelonloader>true</JustMelonloader>`               | Drop the Il2Cpp / Unity reference set. Useful for plugins (like `UpdaterPlugin`) that live in MelonLoader's plugin folder instead of as a regular mod. |
| `<AutoEmbed>false</AutoEmbed>`                          | Disable the auto-embedded `.png`/`.wav`/etc resources if you want to manage embeds manually.                                                           |
| `<IncludeLibs>NugetPkg1;NugetPkg2</IncludeLibs>`        | See [ILRepack support](#ilrepack-support) below.                                                                                                       |

# ILRepack support

If your mod depends on NuGet packages or other libararies that aren't already shipped with Mod Helper or the game, list their *assembly* names (without `.dll`) in `<IncludeLibs>`. `btd6.targets` then:

- **In Debug builds**: copies each named DLL into `$(BloonsTD6)\UserLibs\` so MelonLoader loads it alongside your mod.
- **In Release builds**: runs [ILRepack](https://github.com/gluck/il-repack) to merge them directly into your mod's DLL, so you can ship a single self-contained `.dll`.

```xml

<PropertyGroup>
  <IncludeLibs>SomeNuGetLib;AnotherOne</IncludeLibs>
</PropertyGroup>

<ItemGroup>
<PackageReference Include="SomeNuGetLib" Version="1.2.3"/>
<PackageReference Include="AnotherOne" Version="4.5.6"/>
</ItemGroup>
```

# Tips

- The post-build copy works even while the game is running, because it moves the live DLL aside before overwriting. You still need to restart the game to pick up your new code, though.
- If you've added a `<Dependencies>` mod and it isn't being found at build time, double-check that the dependency's DLL actually exists in `$(BloonsTD6)\Mods` (or `$(BloonsTD6)\Disabled Mods`)
- The default `<Optimize>false</Optimize>` you'll see in generated csprojs keeps stack traces helpful, and also avoids some weird runtimes errors that can occasionally crop up. Luckily, the performance difference is negligible
