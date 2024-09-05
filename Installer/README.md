# Mod Helper Installer

This package creates a WIX installer for BTD6 Mod Helper that bundles together installing dotNet 6.0, MelonLoader and Mod Helper (+ the Compatability Plugin on Epic)

Locally building the installer requires the following files downloaded within the Installer directory as shown:
<pre>
<a href="">windowsdesktop-runtime-6.0.29-win-x64.exe</a>
BloonsTD6
| <a href="https://github.com/LavaGang/MelonLoader/releases/download/v0.6.1/MelonLoader.x64.zip">MelonLoader</a>
| | (MelonLoader Install Files)
| Mods
| | <a href="https://github.com/gurrenm3/BTD-Mod-Helper/releases/latest/download/Btd6ModHelper.dll">Btd6ModHelper.dll</a>
| Plugins
| | <a href="https://github.com/GrahamKracker/BTD6EpicGamesModCompat/releases/latest/download/BTD6EpicGamesModCompat.dll">BTD6EpicGamesModCompat.dll</a>
| dobby.dll (From MelonLoader)
| NOTICE.txt (From MelonLoader)
| version.dll (From MelonLoader)
</pre>

You also need WIX installed

```shell
dotnet tool install --global wix
```