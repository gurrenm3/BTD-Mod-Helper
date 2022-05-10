using Assets.Scripts.Models.Towers.Projectiles;
using Assets.Scripts.Models.Towers.Projectiles.Behaviors;
using Assets.Scripts.Models.Towers.Filters;
using UnhollowerBaseLib;

namespace BTD_Mod_Helper.Extensions
{
    public static partial class ProjectileModelExt
    {
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
    }
}