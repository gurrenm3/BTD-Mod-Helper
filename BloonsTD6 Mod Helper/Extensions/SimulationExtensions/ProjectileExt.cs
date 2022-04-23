using Assets.Scripts.Simulation.Display;
using Assets.Scripts.Simulation.Towers.Projectiles;
using Assets.Scripts.Unity.Display;

namespace BTD_Mod_Helper.Extensions;

/// <summary>
/// Extensions for Projectiles
/// </summary>
public static partial class ProjectileExt
{
    /// <summary>
    /// Get the DisplayNode for this Projectile
    /// </summary>
    /// <returns></returns>
    public static DisplayNode GetDisplayNode(this Projectile projectile)
    {
        return projectile.Node;
    }

    /// <summary>
    /// Get the UnityDisplayNode for this Projectile. Is apart of DisplayNode. Needed to modify sprites
    /// </summary>
    /// <returns></returns>
    public static UnityDisplayNode? GetUnityDisplayNode(this Projectile projectile)
    {
        return projectile.GetDisplayNode()?.graphic;
    }
}