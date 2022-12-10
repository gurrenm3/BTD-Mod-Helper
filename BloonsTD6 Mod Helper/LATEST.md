### While LavaGang continues working to get MelonLoader compatible with the new v34 update, this is a temporary fix to allow people to more easily continue playing on v33 in the meantime (and in similar situations like this in the future).
Changes:
- Disables the mandatory Popup that forces you to update, so that you can keep playing
- Doing the above will disable Mod Helper's saving fixes to prevent data corruption

### If you've already updated to v34, here is a way you can downgrade:

1. Copy/paste the following into your web browser search bar and allow it to open Steam to access the console: `steam://nav/console`
    - This can sometimes take a couple seconds to open
2. Copy in the command `download_depot 960090 960091 8819303902483866961` to download the files for v33
    - There will be no progress indicator, so just let it run for a minute or two
    - When it's finished it'll say "Depot download complete: (path it downloaded to)"
3. Optional but recommended: create a copy of your `...\Steam\steamapps\common\BloonsTD6` folder as backup
4. Copy (not move) the newly downloaded game files from `...\Steam\steamapps\content\app_960090\depot_960091` into the
   normal game directory `...\Steam\steamapps\common\BloonsTD6`, telling it to replace the existing files
    - If you copy instead of move you can leave the base files there to copy again if Steam ever auto-updates on you
    - To help prevent auto-updating, you can go into the Steam properties page for BloonsTD6 and switch the Updates -> Automatic
      Updates option to "Only update this game when I launch it"
5. Run the game as before, and noticed the inescapable Update popup is replaced with a quite escapable one about Mod Helper
   disabling saving

### This is a stop gap measure until MelonLoader is fixed, so please do not annoy staff in the Discord servers trying to get help with this