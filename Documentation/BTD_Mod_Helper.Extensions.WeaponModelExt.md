#### [BloonsTD6 Mod Helper](README.md 'README')
### [BTD_Mod_Helper.Extensions](README.md#BTD_Mod_Helper.Extensions 'BTD_Mod_Helper.Extensions')

## WeaponModelExt Class

Extensions for WeaponModels

```csharp
public static class WeaponModelExt
```

Inheritance [System.Object](https://docs.microsoft.com/en-us/dotnet/api/System.Object 'System.Object') &#129106; WeaponModelExt
### Methods

<a name='BTD_Mod_Helper.Extensions.WeaponModelExt.GetEject(thisWeaponModel)'></a>

## WeaponModelExt.GetEject(this WeaponModel) Method

Gets the eject position of the weapon as a vector

```csharp
public static Vector3 GetEject(this WeaponModel weapon);
```
#### Parameters

<a name='BTD_Mod_Helper.Extensions.WeaponModelExt.GetEject(thisWeaponModel).weapon'></a>

`weapon` [Il2CppAssets.Scripts.Models.Towers.Weapons.WeaponModel](https://docs.microsoft.com/en-us/dotnet/api/Il2CppAssets.Scripts.Models.Towers.Weapons.WeaponModel 'Il2CppAssets.Scripts.Models.Towers.Weapons.WeaponModel')

#### Returns
[Il2CppAssets.Scripts.Simulation.SMath.Vector3](https://docs.microsoft.com/en-us/dotnet/api/Il2CppAssets.Scripts.Simulation.SMath.Vector3 'Il2CppAssets.Scripts.Simulation.SMath.Vector3')

<a name='BTD_Mod_Helper.Extensions.WeaponModelExt.SetEject(thisWeaponModel,Vector3,bool,bool,bool)'></a>

## WeaponModelExt.SetEject(this WeaponModel, Vector3, bool, bool, bool) Method

Sets ejectX/ejectY/ejectZ all at once

```csharp
public static void SetEject(this WeaponModel weapon, Vector3 eject, bool ignoreX=false, bool ignoreY=false, bool ignoreZ=false);
```
#### Parameters

<a name='BTD_Mod_Helper.Extensions.WeaponModelExt.SetEject(thisWeaponModel,Vector3,bool,bool,bool).weapon'></a>

`weapon` [Il2CppAssets.Scripts.Models.Towers.Weapons.WeaponModel](https://docs.microsoft.com/en-us/dotnet/api/Il2CppAssets.Scripts.Models.Towers.Weapons.WeaponModel 'Il2CppAssets.Scripts.Models.Towers.Weapons.WeaponModel')

<a name='BTD_Mod_Helper.Extensions.WeaponModelExt.SetEject(thisWeaponModel,Vector3,bool,bool,bool).eject'></a>

`eject` [UnityEngine.Vector3](https://docs.microsoft.com/en-us/dotnet/api/UnityEngine.Vector3 'UnityEngine.Vector3')

<a name='BTD_Mod_Helper.Extensions.WeaponModelExt.SetEject(thisWeaponModel,Vector3,bool,bool,bool).ignoreX'></a>

`ignoreX` [System.Boolean](https://docs.microsoft.com/en-us/dotnet/api/System.Boolean 'System.Boolean')

<a name='BTD_Mod_Helper.Extensions.WeaponModelExt.SetEject(thisWeaponModel,Vector3,bool,bool,bool).ignoreY'></a>

`ignoreY` [System.Boolean](https://docs.microsoft.com/en-us/dotnet/api/System.Boolean 'System.Boolean')

<a name='BTD_Mod_Helper.Extensions.WeaponModelExt.SetEject(thisWeaponModel,Vector3,bool,bool,bool).ignoreZ'></a>

`ignoreZ` [System.Boolean](https://docs.microsoft.com/en-us/dotnet/api/System.Boolean 'System.Boolean')

<a name='BTD_Mod_Helper.Extensions.WeaponModelExt.SetEject(thisWeaponModel,Vector3,bool,bool,bool)'></a>

## WeaponModelExt.SetEject(this WeaponModel, Vector3, bool, bool, bool) Method

Sets ejectX/ejectY/ejectZ all at once

```csharp
public static void SetEject(this WeaponModel weapon, Vector3 eject, bool ignoreX=false, bool ignoreY=false, bool ignoreZ=false);
```
#### Parameters

<a name='BTD_Mod_Helper.Extensions.WeaponModelExt.SetEject(thisWeaponModel,Vector3,bool,bool,bool).weapon'></a>

`weapon` [Il2CppAssets.Scripts.Models.Towers.Weapons.WeaponModel](https://docs.microsoft.com/en-us/dotnet/api/Il2CppAssets.Scripts.Models.Towers.Weapons.WeaponModel 'Il2CppAssets.Scripts.Models.Towers.Weapons.WeaponModel')

<a name='BTD_Mod_Helper.Extensions.WeaponModelExt.SetEject(thisWeaponModel,Vector3,bool,bool,bool).eject'></a>

`eject` [Il2CppAssets.Scripts.Simulation.SMath.Vector3](https://docs.microsoft.com/en-us/dotnet/api/Il2CppAssets.Scripts.Simulation.SMath.Vector3 'Il2CppAssets.Scripts.Simulation.SMath.Vector3')

<a name='BTD_Mod_Helper.Extensions.WeaponModelExt.SetEject(thisWeaponModel,Vector3,bool,bool,bool).ignoreX'></a>

`ignoreX` [System.Boolean](https://docs.microsoft.com/en-us/dotnet/api/System.Boolean 'System.Boolean')

<a name='BTD_Mod_Helper.Extensions.WeaponModelExt.SetEject(thisWeaponModel,Vector3,bool,bool,bool).ignoreY'></a>

`ignoreY` [System.Boolean](https://docs.microsoft.com/en-us/dotnet/api/System.Boolean 'System.Boolean')

<a name='BTD_Mod_Helper.Extensions.WeaponModelExt.SetEject(thisWeaponModel,Vector3,bool,bool,bool).ignoreZ'></a>

`ignoreZ` [System.Boolean](https://docs.microsoft.com/en-us/dotnet/api/System.Boolean 'System.Boolean')

<a name='BTD_Mod_Helper.Extensions.WeaponModelExt.SetEmission(thisWeaponModel,EmissionModel)'></a>

## WeaponModelExt.SetEmission(this WeaponModel, EmissionModel) Method

Sets the emission for a WeaponModel, properly handling the child dependents

```csharp
public static void SetEmission(this WeaponModel weapon, EmissionModel emission);
```
#### Parameters

<a name='BTD_Mod_Helper.Extensions.WeaponModelExt.SetEmission(thisWeaponModel,EmissionModel).weapon'></a>

`weapon` [Il2CppAssets.Scripts.Models.Towers.Weapons.WeaponModel](https://docs.microsoft.com/en-us/dotnet/api/Il2CppAssets.Scripts.Models.Towers.Weapons.WeaponModel 'Il2CppAssets.Scripts.Models.Towers.Weapons.WeaponModel')

<a name='BTD_Mod_Helper.Extensions.WeaponModelExt.SetEmission(thisWeaponModel,EmissionModel).emission'></a>

`emission` [Il2CppAssets.Scripts.Models.Towers.Behaviors.Emissions.EmissionModel](https://docs.microsoft.com/en-us/dotnet/api/Il2CppAssets.Scripts.Models.Towers.Behaviors.Emissions.EmissionModel 'Il2CppAssets.Scripts.Models.Towers.Behaviors.Emissions.EmissionModel')

<a name='BTD_Mod_Helper.Extensions.WeaponModelExt.SetProjectile(thisWeaponModel,ProjectileModel)'></a>

## WeaponModelExt.SetProjectile(this WeaponModel, ProjectileModel) Method

Sets the emission for a WeaponModel, properly handling the child dependents

```csharp
public static void SetProjectile(this WeaponModel weapon, ProjectileModel projectile);
```
#### Parameters

<a name='BTD_Mod_Helper.Extensions.WeaponModelExt.SetProjectile(thisWeaponModel,ProjectileModel).weapon'></a>

`weapon` [Il2CppAssets.Scripts.Models.Towers.Weapons.WeaponModel](https://docs.microsoft.com/en-us/dotnet/api/Il2CppAssets.Scripts.Models.Towers.Weapons.WeaponModel 'Il2CppAssets.Scripts.Models.Towers.Weapons.WeaponModel')

<a name='BTD_Mod_Helper.Extensions.WeaponModelExt.SetProjectile(thisWeaponModel,ProjectileModel).projectile'></a>

`projectile` [Il2CppAssets.Scripts.Models.Towers.Projectiles.ProjectileModel](https://docs.microsoft.com/en-us/dotnet/api/Il2CppAssets.Scripts.Models.Towers.Projectiles.ProjectileModel 'Il2CppAssets.Scripts.Models.Towers.Projectiles.ProjectileModel')