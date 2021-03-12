# BTD Mod Helper
A powerful and easy to use API for modding BTD6, BATTD, and other Ninja Kiwi games. It was created with the successes and failures of previous APIs in mind so it's significantly easier to use.

## How to use it
Like other API, download/clone it. In your mod's Visual Studio project add a reference to `BloonsTD6 Mod Helper.dll` or `BloonsAT Mod Helper.dll` depending on your game. Then at the top of each file in your project, add `using BTD_Mod_Helper.Extensions;`. Thats it. Each file that has this line at the top will have complete access to all of the features added by the API. This API is built using extension methods, which means it's created to work along side the game's own code. So just make your mods like normal and you'll see the new features pop up in Visual Studio Intellisense. As a side note, make sure the mod is in your game's Mods folder. It needs to be run like a mod

## What can this API currently help with
- Much of the useful game code is hidden, deeply nested, and located in obscure places. The API moves them to `Game.instance` and `InGame.instance` whenever it makes sense to make them significantly easier to access and bring awareness to their existance.
- Many extension methods added to make modifying towers, upgrades, weapons, projectiles, and bloons easier.
- A lot of code for towers/bloons is unconnected, meaning you have to go all over to find something. API connects them in as many ways as possible
  - Towers, TowerModels, TowerToSimulation, and TowerPurchaseButtons are all inter-linked.
  - Bloons, BloonModels, and BloonToSimulation are all inter-linked
  - Same for Abilities and projectiles
  - Can get every created instance from a model. Ex: Can get every Tower/TowerToSimulation from a specific TowerModel. Applies to everything in this list
- Massive amounts of support added for Behaviors. Can easily look for, add, and remove behaviors from nearly everything that has "behaviors"
- Added extension methods for Arrays, System.Lists, Il2CppSystem.Lists, LockLists, SizedLists, IEnumerables, and Il2CppReferenceArrays
  - Can convert between all of them, duplicate/clone, and change the "Type" that the collection is.
  - New support for getting items, adding items, and removing items
  - Custom linq extensions for easier manipluation
  - More
- Support for custom textures/sprites/3d models

For BTD6:
- Fully custom bloon sets (not possible in vanila BTD6), BloonBuilder (easier time creating custom bloon types), Json Serializer, and other useful features
- Co-op modding techniques
- Bugfixes for BTD6
- More

## Testimonies
Mod makers that have used this API say it's at least 3 times easier to use and more powerful than the next leading API. 

## Credits
This mod wouldn't be possible without all of the contributions from the community. DoomBubbles and Bowdown097 added a lot of nice features to the api and provided a lot of valuable suggestions. Mr.Nuke, James, and Timotheeee we're really helpful when it came to testing/suggesting new features. Since this api was built off of the successes/ failures of Gurren Core and the old NKHook6, it does reuse some of the extensions from them. Thanks to ASM for creating and testing those original methods

## Future plans
The API already has a lot of features added, however it's no where near done. My goal is to make this a universal mod helper for all of Ninja Kiwi's unity games, so there's still a ton of work ahead. Also, the Mod Helper was recently redone to allow support for BTD Battles 2 when it's released.

## Contact
If you have any suggestions please join our [Discord Server](https://discord.gg/NnD6nRH). My Discord name is gurrenm4#2395
