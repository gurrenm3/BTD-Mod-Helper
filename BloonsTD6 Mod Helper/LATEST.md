- Fixed a performance issue with the background Task Scheduler
  - Also added new `ScheduleType.WaitForSecondsScaled` that is affected by fast-forward mode
- Added a `ModRoundSet.Rounds1Index` override that changes the behavior of the `ModifyRoundModels` methods to match the
  player facing 1, 2, 3 and not the internal 0, 1, 2.
  - This will become the default in a later Mod Helper update, just not this patch version since it's a breaking change
- Added a new `ModelSerializer` that can more reliably serialize and deserialize things like TowerModels to/from JSON
- Making use of the above, added a new "Sandbox Tower Quick Edit" hotkey that can let you try changes to TowerModels in
  game
  - When pressing the Hotkey (default Backslash) with a tower selected in Sandbox mode, a text editor will open up and
    let you edit the TowerModel as JSON.
    When you close the file, it will apply the changes back to the tower.
    - By default, it changes the "root" model of the tower, which is before any Mutators have been applied. If you
      instead want to see/edit the full tower model (e.g. one that has Paths++ mutators applied), hold "Alt" alongside the hotkey.
      NOTE: This can have the side effect of stacking / reapplying mutators on the tower.
  - The default editor it opens with is Notepad
    - To make it edit with VsCode, change the "Quick Edit Program" mod helper setting to "code -w -n"
    - To make it edit with JetBrains Rider, change it to "%LOCALAPPDATA%\Programs\Rider\bin\rider64.exe --wait"