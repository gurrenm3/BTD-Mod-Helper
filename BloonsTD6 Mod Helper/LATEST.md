Fixed Custom Load Task Functionality

- Back to no longer freezing the process while mod tasks are being run
  - If you prefer that behavior however (since it can be slightly faster depending on your situation), you can enable the "Use Old Loading" Mod Helper Setting.
  - You can also now press space bar during the title screen to switch to running the rest of the startup this way
- Custom load tasks now support using the Progress Bar having subtext for progress
  - Use `ShowProgressBar => true` and update `Progress = ...` during the coroutine
  - For sub text update `Description = "..."` during the coroutine.