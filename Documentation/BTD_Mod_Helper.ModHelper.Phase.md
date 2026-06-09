#### [BloonsTD6 Mod Helper](README.md 'README')
### [BTD_Mod_Helper](README.md#BTD_Mod_Helper 'BTD_Mod_Helper').[ModHelper](BTD_Mod_Helper.ModHelper.md 'BTD_Mod_Helper.ModHelper')

## ModHelper.Phase Enum

Enum describing the phases of Mod Helper's loading and registration process

```csharp
public enum ModHelper.Phase
```
### Fields

<a name='BTD_Mod_Helper.ModHelper.Phase.Loading'></a>

`Loading` 1

Mods and mod content are actively being loaded

<a name='BTD_Mod_Helper.ModHelper.Phase.PostRegistration'></a>

`PostRegistration` 4

Mods and mod content have been fully loaded and registered

<a name='BTD_Mod_Helper.ModHelper.Phase.PreLoading'></a>

`PreLoading` 0

Before any mods or mod content have been loaded in

<a name='BTD_Mod_Helper.ModHelper.Phase.PreRegistration'></a>

`PreRegistration` 2

Mods and mod content have been loaded but not yet registered

<a name='BTD_Mod_Helper.ModHelper.Phase.Registration'></a>

`Registration` 3

Mods and mod content are actively being registered