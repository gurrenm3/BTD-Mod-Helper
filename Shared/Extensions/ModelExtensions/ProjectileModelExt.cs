using Assets.Scripts.Unity.UI_New.InGame;
using System.Collections.Generic;
using System.Linq;
using BTD_Mod_Helper.Api;
using BTD_Mod_Helper.Api.Display;
#if BloonsTD6
using Assets.Scripts.Models.Towers.Projectiles;
using Assets.Scripts.Simulation.Towers.Projectiles;
using Assets.Scripts.Models.Towers.Projectiles.Behaviors;
#elif BloonsAT
using Assets.Scripts.Models.Towers.Projectiles.Behaviors;
using Assets.Scripts.Simulation.Towers.Projectiles.Behaviors;
#endif

namespace BTD_Mod_Helper.Extensions
{
    /// <summary>
    /// Extensions for ProjectileModels
    /// </summary>
    public static partial class ProjectileModelExt
    {
        /// <summary>
        /// (Cross-Game compatible) Get the DamageModel behavior from the list of behaviors
        /// </summary>
        public static DamageModel? GetDamageModel(this ProjectileModel projectileModel)
        {
            return projectileModel.GetBehavior<DamageModel>();
        }

        /// <summary>
        /// (Cross-Game compatible) Get all Projectile Simulations that have this ProjectileModel
        /// </summary>
        public static List<Projectile> GetProjectileSims(this ProjectileModel projectileModel)
        {
            var projectileSims = InGame.instance.GetProjectiles();
            return projectileSims?.Where(projectile => projectile.projectileModel.name == projectileModel.name).ToList() ?? new List<Projectile>();
        }

#if BloonsTD6
        /// <summary>
        /// Applies a given ModDisplay to this ProjectileModel
        /// </summary>
        /// <typeparam name="T">The type of ModDisplay</typeparam>
        public static void ApplyDisplay<T>(this ProjectileModel projectileModel) where T : ModDisplay
        {
            ModContent.GetInstance<T>().Apply(projectileModel);
        }
#endif
    }
}