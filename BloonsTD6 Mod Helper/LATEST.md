While LavaGang continues to work on an update for MelonLoader to work with the new v34 update, this is a temporary fix
to allow people to more easily continue playing on v33 in the meantime and in any similar situations like this in the future.

- Allows the bypassing of the Popup forcing you to update if you want to keep playing
- Doing the above will disable Mod Helper's saving fixes to prevent data corruption

If you've already updated to v34, here is a way you can downgrade:

1. Click this link and allow your browser to open it in Steam to access the Steam
   console: [steam://nav/console](steam://nav/console)
    - This can sometimes take a couple seconds to open
2. Copy in the command `download_depot 960090 960091 8819303902483866961` to download the files for v33
    - There will be no progress indicator, so just let it run for up to a couple minutes
    - When it's finished it'll say "Depot download complete: (path it downloaded to)"
3. Optional but recommended: create a copy of your `..\Steam\steamapps\common\BloonsTD6` folder as backup
4. Copy (not move) the newly downloaded game files from `..\Steam\steamapps\content\app_960090\depot_960091` into the
   normal game directory `..\Steam\steamapps\common\BloonsTD6`, telling it to replace the existing files
    - If you copy instead of move you can leave the base files there to copy again if Steam ever auto-updates on you
    - To help prevent auto-updating, you can go into the Steam properties page for BloonsTD6 and switch the Updates -> Automatic
      Updates option to "Only update this game when I launch it"
5. Run the game as before, and noticed the inescapable Update popup is replaced with a very escapable one about Mod Helper
   disabling saving