using Il2CppAssets.Scripts.Simulation.Factory;
using Il2CppAssets.Scripts.Unity.UI_New.InGame;
using Il2CppAssets.Scripts.Simulation.Towers.Projectiles;

namespace BTD_Mod_Helper.Extensions;

public static partial class ProjectileExt
{
    /// <summary>
    /// Return the Factory that creates Projectiles
    /// </summary>
    /// <param name="projectile"></param>
    /// <returns></returns>
    public static Factory<Projectile> GetFactory(this Projectile projectile)
    {
        return InGame.instance.GetFactory<Projectile>();
    }
}