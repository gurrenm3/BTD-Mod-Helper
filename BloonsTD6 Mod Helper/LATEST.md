- Now natively works on Epic Games version, and prompts user to download the compatability plugin to make other mods work if they don't have it
- Added ModHelperData `bool Plugin` field for mods that are MelonPlugins
- Fixed SteamWebView usage on the Epic Games version
- Fixed a crash that could happen on Linux (thanks @GrahamKracker)
- Fixed more crashes from TowerInventory / subtower interactions (thanks @Onixiya)
- Added new `AttackHelper`, `WeaponHelper` and `ProjectileHelper` that can be used to more easily create those models
  from scratch
    - The classes will implicitly convert themselves to their respective models
    - Make use of the object initialization syntax; don't need to specific every single field, will use sensible defaults