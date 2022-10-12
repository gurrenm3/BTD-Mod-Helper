Initial Fixes for BloonsTD6 v33.0

- Added the `FileIOHelper` class that replicates the methods of `FileIOUtil` that've been removed in v33.0
- Fixed the try-catching of Harmony Patches that wasn't working correctly on official release ML 0.5.5.
- **Reverted to the old loading system** until I update our custom load tasks to the new way NK is doing it internally
    - This means we're temporarily going back to freezing after Step 8 of 8 to wait for mods to load rather than having our
      own steps

Also as a PSA about MelonLoader, if things ever seem TOO frozen on Step 8 of 8, with no more log messages appearing,
check that you haven't accidentally clicked into the console as below, as that can stall things

![console clicking infographic](https://media.discordapp.net/attachments/800115046134186026/1029864079873032253/unknown.png)