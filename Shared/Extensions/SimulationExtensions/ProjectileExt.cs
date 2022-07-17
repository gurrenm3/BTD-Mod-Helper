using Assets.Scripts.Simulation.Factory;
using Assets.Scripts.Unity.UI_New.InGame;
using Assets.Scripts.Simulation.Towers.Projectiles;

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