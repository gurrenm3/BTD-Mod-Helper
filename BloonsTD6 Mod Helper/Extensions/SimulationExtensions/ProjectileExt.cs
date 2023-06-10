using Il2CppAssets.Scripts.Simulation.Display;
using Il2CppAssets.Scripts.Simulation.Factory;
using Il2CppAssets.Scripts.Simulation.Towers.Projectiles;
using Il2CppAssets.Scripts.Unity.Display;
using Il2CppAssets.Scripts.Unity.UI_New.InGame;
namespace BTD_Mod_Helper.Extensions;

/// <summary>
/// Extensions for Projectiles
/// </summary>
public static class ProjectileExt
{
    /// <summary>
    /// Get the DisplayNode for this Projectile
    /// </summary>
    /// <returns></returns>
    public static DisplayNode GetDisplayNode(this Projectile projectile) => projectile.Node;

    /// <summary>
    /// Get the UnityDisplayNode for this Projectile. Is apart of DisplayNode. Needed to modify sprites
    /// </summary>
    /// <returns></returns>
    public static UnityDisplayNode GetUnityDisplayNode(this Projectile projectile) => projectile.GetDisplayNode()?.graphic;

    /// <summary>
    /// Return the Factory that creates Projectiles
    /// </summary>
    /// <param name="projectile"></param>
    /// <returns></returns>
    public static Factory<Projectile> GetFactory(this Projectile projectile) => InGame.instance.GetFactory<Projectile>();
}