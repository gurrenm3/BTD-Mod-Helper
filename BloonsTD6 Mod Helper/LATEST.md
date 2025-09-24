- Created a new Updater Plugin that keep Mod Helper and other mods automatically up to date when you start the game
  - Mod Helper will automatically manage the download and installation of the Updater Plugin, no need to manually download the .dll
  - Enabled by default; use the "Auto Update" setting at the top of Mod Helper Settings if you don't want to use it
  - The Updater Plugin has its own settings page to control which mods you want to keep updated, if not all of them
  - The plugin will also be able to display important messages to users at startup for cases like recently when users needed to be told about downgrading the game
- For `ModRoundSet`, `Rounds1Index` will now finally be true by default
- Added a VanillaAudioClips file listing all the GUIDs for game sounds
- Updated the game data exporter to use a custom serializer implementation that does not fail on any towers (e.g. top
  path alchemists)
- Made some more members of `ResourceHandler` be public, and added `ResourceHandler.AddTexture(guid, texture2d)`