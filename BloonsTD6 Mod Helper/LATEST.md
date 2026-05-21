<!--Mod Browser Message Start-->

- Added [ModTsmTheme and ModVanillaTsmTheme](https://gurrenm3.github.io/BTD-Mod-Helper/wiki/Making-a-Custom-TSM-Theme)
- Added [ModMutator](https://gurrenm3.github.io/BTD-Mod-Helper/wiki/Making-a-Custom-Mutator)
- Added [ModCustomInput](https://gurrenm3.github.io/BTD-Mod-Helper/wiki/Making-a-Custom-Input)
- Added ModTest
- Minor ModContent registration change: content manually added by mod.AddContent(...) during a Register() method will still be Registered automatically
- Marked Obsolete the `AttackHelper`, `WeaponHelper`, `ProjectileHelper`, and `AbilityHelper` classes in favor of the
  `AttackModel.Create`,`WeaponModel.Create`,`ProjectileModel.Create`, and `AttackModel.Create` extensions, which now have the same / more conviences as the Helper classes
- Updated `ModCommand` to support a Coroutines being a valid main Execute method with `public override IEnumerator Execute(Output output) { ... }`
  - Can set `output.success` and `output.resultText` which will update live
- Updated btd6.targets with some new features
  - New csrpoj property that can be set `<Dependencies>PathsPlusPlus;UltimateCrosspathing</Dependencies>` will automatically reference dll from mods folder (or disabled mods folder if not found)
  - Keeps mod launchSettings.json up to date, unless you add csproj property `<DontCopyLaunchSettings>true</DontCopyLaunchSettings>`
  - Updates targets and launchSettings so that the `dotnet run` command will work automatically for projects
- Added a number of new command lines arguments for mod makers
  - `--modhelper.only=ModA,ModB`/`--modhelper.only ModA,ModB` load the game with only the specified mod(s) loaded (and Mod Helper)
  - `--modhelper.noaudio` disables all game audio, primarily meant to be used alongside `-batchmode` to run the game headlessly
  - `--modehelper.offline` to put the game in offline mode and not run mod helper browser or updater plugin functionality
  - `--modhelper.run [-q?] [-e?] [command] [&& another command ...] ` runs a ModCommand after the game loads
    - `-q` make the game quit automatically after running the command, exit code 0 for success or 1 for failure
    - `-e` if specifying multiple commands with `&&`, stop whenever the first one fails
    - Should be the last argument