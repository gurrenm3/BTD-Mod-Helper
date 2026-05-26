# Test Runner

xUnit harness that builds and runs `ModTest`s for every mod in the parent **Mod Sources** folder (should be the folder containing this repo). Tests are discovered as standard xUnit theories and show up in Rider / VS / `dotnet test` per mod.

## Requirements

Required .NET SDK 10.0 or higher to build the project

## What it discovers

`ModSourcesTests` scans every subdirectory of `../` and treats one as a mod when **all** of:
- a `<Name>/<Name>.csproj` exists,
- there's a top-level `ModHelperData.*` file,
- and `<Name>.dll` is present in either `BloonsTD6/Mods/` or `BloonsTD6/Disabled Mods/`.

`ModHelperTests` runs the BTD Mod Helper's own test suite (always present).

## What each test does

1. `dotnet build` the mod project (Debug or Release — see below). A build failure surfaces the MSBuild error lines in the test's failure message.
2. Skip (not fail) if the project has no `BloonsTD6 (Tests)` launch profile.
3. `dotnet run --no-launch-profile -- <resolved args>` — `commandLineArgs` from the profile are read directly, `$(MSBuild)` properties are expanded via `dotnet msbuild -getProperty`, and the result is passed straight to BTD6.
4. After the run, copy `BloonsTD6/MelonLoader/Latest.log` to `TestResults/<modName>.log` and emit a `[WARNING]` / `[ERROR]` / post-`Running N test(s)` summary into the xUnit output pane.
5. Restore the mod's DLL to its original location (Mods vs Disabled Mods).

## Debug vs Release

`ModTestRunner.Configuration` is a `#if DEBUG` compile-time constant, so it tracks whatever the solution dropdown is set to in Rider/VS. Tests run `dotnet build -c {Configuration}` and `dotnet run -c {Configuration} ...` accordingly.