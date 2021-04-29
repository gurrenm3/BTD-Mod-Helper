using Assets.Scripts.Simulation.Towers.Projectiles.Behaviors;
using Assets.Scripts.Unity.Bridge;
using Assets.Scripts.Unity.UI_New.InGame;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BTD_Mod_Helper.Extensions
{
    public static partial class ProjectileExt
    {
        /// <summary>
        /// Get the ProjectileToSimulation for this specific Projectile
        /// </summary>
        /*public static ProjectileToSimulation GetProjectileToSim(this Projectile projectile)
        {
            return InGame.instance.GetUnityToSimulation().().FirstOrDefault(b => b.id == bloon.Id);
        }*/
    }
}
