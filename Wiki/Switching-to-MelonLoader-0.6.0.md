# MelonLoader 0.6.0 alpha is the first official release that works for BTD6 v34, but NO OLD MODS will work on it; EVERYTHING will need to be updated.

This page covers some tips for users / modders for dealing with the update to 0.6.0

## Tips for Users:
* To see 0.6.0 in the MelonLoader installer, you need to check the "Show ALPHA Pre-Releases" box in the settings. You can also directly download it from the [GitHub release](https://github.com/LavaGang/MelonLoader) to manually install it.

![Show ALPHA Pre-Releases Screenshot](https://cdn.discordapp.com/attachments/800115046134186026/1057073879744524318/image.png)

* If you get any error about "il2cpp_init_detour ..." You need to [download a newer version of dotNet from Microsoft's website.](https://dotnet.microsoft.com/en-us/download/dotnet/6.0) Your best will be the ".NET Runtime 6.0.12" in the bottom right, choosing the installer appropriate for your operating system (most commonly Windows x64). Once you download the installer, you'll need to run it and let it properly install on your system.

![.NET Runtime 6.0.12 Windows x64 Screenshot](https://cdn.discordapp.com/attachments/800115046134186026/1057075537668997200/image.png)

* Since **no old mods will work** without being updated, you may as well take all other mod .dlls you already had in your Mods folder and move them into the Disabled folder.

![All other mods in Disabled folder](https://cdn.discordapp.com/attachments/800115046134186026/1057081636031836212/image.png)

## Tips for Modders:

* Switch your .csproj to targeting `net6.0` instead of `net48`.

![net6.0 in csproj](https://cdn.discordapp.com/attachments/800115046134186026/1057082225587408896/image.png)

* If you aren't already, it'd really make your life easier to [make use of the `btd6.targets` file that Mod Helper provides](https://github.com/gurrenm3/BTD-Mod-Helper/wiki/%5B3.0%5D-Migration-Guide#3-update-to-using-btd6targets-and-the-mod-sources-folder). The updated `btd6.targets` will already handle switching to the new dll references, so most of what's left is fixing your `using ...` statements.

* 0.6.0 replaces the old Unhollower library with the new Il2CppInterop library. Anywhere where you have
```cs
using UnhollowerBaseLib;
```
should be replaced with one of the following: 
```cs
using Il2CppInterop.Runtime;
using Il2CppInterop.Runtime.InteropTypes;
using Il2CppInterop.Runtime.InteropTypes.Arrays;
```

*  0.6.0 also renames many other packages to have `Il2Cpp` in their name, most notable `Assets` => `Il2CppAssets`. You can address this pretty easily by doing a project-wide Find + Replace for `using Assets` to `using Il2CppAssets`.

* Some Il2Cpp classes will simply require a `using Il2Cpp;`

* As of Mod Helper 3.1.1, only mods that include the "WorksOnVersion" property with a value of "34" / "34.3" or higher will show up in the Mod Browser to make it clearer what mods will actually work. Once you've fixed your mods, update your ModHelperData [in a similar way to Ultimate Crosspathing](https://github.com/doombubbles/ultimate-crosspathing/blob/main/ModHelperData.cs#L7)