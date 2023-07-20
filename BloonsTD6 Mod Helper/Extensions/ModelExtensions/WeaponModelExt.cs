using Il2CppAssets.Scripts.Models.Towers.Behaviors.Emissions;
using Il2CppAssets.Scripts.Models.Towers.Projectiles;
using Il2CppAssets.Scripts.Models.Towers.Weapons;
namespace BTD_Mod_Helper.Extensions;

/// <summary>
/// Extensions for WeaponModels
/// </summary>
public static class WeaponModelExt
{
    /// <summary>
    /// Sets the emission for a WeaponModel, properly handling the child dependents 
    /// </summary>
    public static void SetProjectile(this WeaponModel weapon, ProjectileModel projectile)
    {
        weapon.RemoveChildDependant(weapon.projectile);
        weapon.projectile = projectile;
        weapon.AddChildDependant(projectile);
    }

    /// <summary>
    /// Sets the emission for a WeaponModel, properly handling the child dependents 
    /// </summary>
    public static void SetEmission(this WeaponModel weapon, EmissionModel emission)
    {
        weapon.RemoveChildDependant(weapon.emission);
        weapon.emission = emission;
        weapon.AddChildDependant(emission);
    }

    /// <summary>
    /// Sets ejectX/ejectY/ejectZ all at once
    /// </summary>
    public static void SetEject(this WeaponModel weapon, UnityEngine.Vector3 eject, bool ignoreX = false,
        bool ignoreY = false, bool ignoreZ = false)
    {
        weapon.SetEject(new Il2CppAssets.Scripts.Simulation.SMath.Vector3(eject), ignoreX, ignoreY, ignoreZ);
    }

    /// <summary>
    /// Sets ejectX/ejectY/ejectZ all at once
    /// </summary>
    public static void SetEject(this WeaponModel weapon, Il2CppAssets.Scripts.Simulation.SMath.Vector3 eject,
        bool ignoreX = false, bool ignoreY = false, bool ignoreZ = false)
    {
        if (!ignoreX) weapon.ejectX = eject.x;
        if (!ignoreY) weapon.ejectY = eject.y;
        if (!ignoreZ) weapon.ejectZ = eject.z;
    }

    /// <summary>
    /// Gets the eject position of the weapon as a vector
    /// </summary>
    public static Il2CppAssets.Scripts.Simulation.SMath.Vector3 GetEject(this WeaponModel weapon) =>
        new(weapon.ejectX, weapon.ejectY, weapon.ejectZ);
}