## NOTE: As of this release, BTD6 still needs the latest NIGHTLY build of MelonLoader. 0.7.0 or 0.7.1 will not work. [See the Install Guide](https://gurrenm3.github.io/BTD-Mod-Helper/wiki/Install-Guide)

<!--Mod Browser Message Start-->

- Fixed the patch that ensured only vanilla towers were rewarded as Insta Monkeys from including the Sheriff tower
  - The extension `towerModel.IsVanillaTower()` will still return true for the Sheriff, but the new extension `towerModel.IsStandardVanillaTower()` will return false