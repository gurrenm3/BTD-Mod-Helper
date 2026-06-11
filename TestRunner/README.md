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

### `Mod_builds_and_tests_pass`

1. `dotnet build` the mod project (Debug or Release — see below). A build failure surfaces the MSBuild error lines in the test's failure message.
2. Skip (not fail) if the project has no `BloonsTD6 (Tests)` launch profile.
3. `dotnet run --no-launch-profile -- <resolved args>` — `commandLineArgs` from the profile are read directly, `$(MSBuild)` properties are expanded via `dotnet msbuild -getProperty`, and the result is passed straight to BTD6.
4. After the run, copy `BloonsTD6/MelonLoader/Latest.log` to `TestResults/<modName>.log` and emit a `[WARNING]` / `[ERROR]` / post-`Running N test(s)` summary into the xUnit output pane.
5. Restore the mod's DLL to its original location (Mods vs Disabled Mods).

### `Latest_release_tests_pass`

Same flow as `Mod_builds_and_tests_pass`, except step 1 swaps the local build for a GitHub release download:

1. Parse `RepoOwner` / `RepoName` / `DllName` (and `ManualDownload` / `ZipName`) from the mod's top-level `ModHelperData.cs` / `.json` / `.txt`. Skip if those repo fields are missing, if the mod is `ManualDownload`, or if it ships as a zip.
2. Download `https://github.com/{RepoOwner}/{RepoName}/releases/latest/download/{DllName ?? <Name>.dll}` into `BloonsTD6/Mods/<Name>.dll`, overwriting the local build.
3. Steps 2-5 of the build test (launch profile check, `dotnet run`, log capture, DLL restore) run unchanged.

This is useful for verifying the currently-published release still passes its tests against the current game build without rebuilding from source.

## Debug vs Release

`ModTestRunner.Configuration` is a `#if DEBUG` compile-time constant, so it tracks whatever the solution dropdown is set to in Rider/VS. Tests run `dotnet build -c {Configuration}` and `dotnet run -c {Configuration} ...` accordingly.