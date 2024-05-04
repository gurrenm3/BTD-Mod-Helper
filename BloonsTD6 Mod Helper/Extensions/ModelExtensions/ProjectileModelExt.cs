using System.Collections.Generic;
using System.Linq;
using BTD_Mod_Helper.Api;
using BTD_Mod_Helper.Api.Display;
using Il2CppAssets.Scripts.Models.GenericBehaviors;
using Il2CppAssets.Scripts.Models.Towers.Filters;
using Il2CppAssets.Scripts.Models.Towers.Projectiles;
using Il2CppAssets.Scripts.Models.Towers.Projectiles.Behaviors;
using Il2CppAssets.Scripts.Simulation.Towers.Projectiles;
using Il2CppAssets.Scripts.Unity.UI_New.InGame;
using Il2CppNinjaKiwi.Common.ResourceUtils;
namespace BTD_Mod_Helper.Extensions;

/// <summary>
/// Extensions for ProjectileModels
/// </summary>
public static class ProjectileModelExt
{
    /// <summary>
    /// Get the DamageModel behavior from the list of behaviors
    /// </summary>
    public static DamageModel GetDamageModel(this ProjectileModel projectileModel)
    {
        if (projectileModel.GetBehavior<DamageModel>() == null)
        {
            return projectileModel.GetDescendant<DamageModel>();
        }
        else
        {
            return projectileModel.GetBehavior<DamageModel>();
        }
    }
    /// <summary>
    /// Get all of the DamageModel behavior in this projectile and the DamageModel behaivors in the projectile's behaviors
    /// </summary>
    public static List<DamageModel> GetDamageModels(this ProjectileModel projectileModel) =>
        projectileModel.GetDescendants<DamageModel>().ToList();

    /// <summary>
    /// Get all Projectile Simulations that have this ProjectileModel
    /// </summary>
    public static List<Projectile> GetProjectileSims(this ProjectileModel projectileModel)
    {
        var projectileSims = InGame.instance.GetProjectiles();
        return projectileSims?.Where(projectile => projectile.projectileModel.name == projectileModel.name).ToList() ??
               new List<Projectile>();
    }


    /// <summary>
    /// Applies a given ModDisplay to this ProjectileModel
    /// </summary>
    /// <typeparam name="T">The type of ModDisplay</typeparam>
    public static void ApplyDisplay<T>(this ProjectileModel projectileModel) where T : ModDisplay
    {
        ModContent.GetInstance<T>().Apply(projectileModel);
    }

    /// <summary>
    /// Returns whether a projectile is able to hit Camo bloons
    /// </summary>
    public static bool CanHitCamo(this ProjectileModel projectileModel)
    {
        var projectileFilterModel = projectileModel.GetBehavior<ProjectileFilterModel>();
        var filterInvisibleModel =
            projectileFilterModel?.filters.GetItemOfType<FilterModel, FilterInvisibleModel>();
        if (filterInvisibleModel != null)
        {
            return !filterInvisibleModel.isActive;
        }

        return true;
    }

    /// <summary>
    /// Makes a projectile model able to see Camo or not
    /// </summary>
    /// ]
    public static void SetHitCamo(this ProjectileModel projectileModel, bool canHitCamo)
    {
        var projectileFilterModel = projectileModel.GetBehavior<ProjectileFilterModel>();
        if (projectileFilterModel == null)
        {
            projectileModel.AddBehavior(new ProjectileFilterModel("ProjectileFilterModel_" + projectileModel.name,
                new Il2CppReferenceArray<FilterModel>(new FilterModel[]
                    {new FilterInvisibleModel("FilterInvisibleModel_", !canHitCamo, false)})));
        }
        else
        {
            var filterInvisibleModel =
                projectileFilterModel.filters.GetItemOfType<FilterModel, FilterInvisibleModel>();
            if (filterInvisibleModel == null)
            {
                projectileFilterModel.filters =
                    projectileFilterModel.filters.AddTo(new FilterInvisibleModel("FilterInvisibleModel_",
                        !canHitCamo, false));
            }
            else
            {
                filterInvisibleModel.isActive = !canHitCamo;
            }
        }
    }

    /// <summary>
    /// Adds a new filter to this projectile model
    /// </summary>
    public static void AddFilter(this ProjectileModel projectile, FilterModel filter)
    {
        projectile.AddChildDependant(filter);
        projectile.filters = projectile.filters.AddTo(filter);

        if (projectile.HasBehavior(out ProjectileFilterModel projectileFilter))
        {
            projectileFilter.filters = projectileFilter.filters.AddTo(filter);
            projectileFilter.AddChildDependant(filter);
        }
        else
        {
            projectile.AddBehavior(new ProjectileFilterModel("", new[] {filter}));
        }
    }

    /// <summary>
    /// Removes a specific filter from this projectile model
    /// </summary>
    public static void RemoveFilter(this ProjectileModel projectile, FilterModel filter)
    {
        projectile.RemoveChildDependant(filter);
        projectile.filters = projectile.filters.Where(f => f != filter).ToArray();

        if (projectile.HasBehavior(out ProjectileFilterModel projectileFilter))
        {
            projectileFilter.RemoveChildDependant(filter);
            projectileFilter.filters = projectileFilter.filters.RemoveItem(filter);
        }
    }

    /// <summary>
    /// Removes the first filter of the given type from this projectile model
    /// </summary>
    public static void RemoveFilter<T>(this ProjectileModel projectile) where T : FilterModel
    {
        var filter = projectile.filters.OfIl2CppType<T>().FirstOrDefault();
        if (filter != null)
        {
            projectile.RemoveFilter(filter);
        }
    }

    /// <summary>
    /// Sets the display for this projectile
    /// </summary>
    public static void SetDisplay(this ProjectileModel projectileModel, PrefabReference display)
    {
        projectileModel.display = display;
        if (projectileModel.HasBehavior(out DisplayModel displayModel))
        {
            displayModel.display = display;
        }
        else
        {
            projectileModel.AddBehavior(new DisplayModel("", display, 0, DisplayCategory.Projectile));
        }
    }

    /// <summary>
    /// Sets the display for this projectile
    /// </summary>
    public static void SetDisplay(this ProjectileModel projectileModel, string display)
    {
        projectileModel.SetDisplay(new PrefabReference {guidRef = display});
    }
}