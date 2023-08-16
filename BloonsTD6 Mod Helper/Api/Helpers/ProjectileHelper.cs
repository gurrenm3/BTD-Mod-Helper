using System.Collections.Generic;
using System.Linq;
using Il2CppAssets.Scripts.Models;
using Il2CppAssets.Scripts.Models.GenericBehaviors;
using Il2CppAssets.Scripts.Models.Towers.Filters;
using Il2CppAssets.Scripts.Models.Towers.Projectiles;
using Il2CppAssets.Scripts.Models.Towers.Projectiles.Behaviors;
using Il2CppAssets.Scripts.Utils;
namespace BTD_Mod_Helper.Api.Helpers;

public class ProjectileHelper : ModelHelper<ProjectileModel>
{
    private ProjectileFilterModel Filter => Model.GetBehavior<ProjectileFilterModel>();
    private DisplayModel DisplayModel => Model.GetBehavior<DisplayModel>();

    public string Display
    {
        get => Model.display.guidRef;
        set => Model.display.guidRef = Model.GetBehavior<DisplayModel>().display.guidRef = value;
    }

    public PrefabReference DisplayReference
    {
        get => Model.display;
        set => Model.display = Model.GetBehavior<DisplayModel>().display = value;
    }

    public float Radius
    {
        get => Model.radius;
        set => Model.radius = value;
    }

    public float VsBlockerRadius
    {
        get => Model.vsBlockerRadius;
        set => Model.vsBlockerRadius = value;
    }

    public float Pierce
    {
        get => Model.pierce;
        set => Model.pierce = value;
    }

    public float MaxPierce
    {
        get => Model.maxPierce;
        set => Model.maxPierce = value;
    }

    public Model[] Behaviors
    {
        get => Model.behaviors ?? new Il2CppReferenceArray<Model>(0);
        set
        {
            Model.RemoveChildDependants(Model.behaviors);
            var newBehaviors = new List<Model>(value);
            if (!value.OfIl2CppType<ProjectileFilterModel>().Any()) newBehaviors.Insert(0, Filter);
            if (!value.OfIl2CppType<DisplayModel>().Any()) newBehaviors.Insert(0, DisplayModel);
            Model.behaviors = newBehaviors.ToIl2CppReferenceArray();
            Model.AddChildDependants(Model.behaviors);
            Model.hasDamageModifiers = value.OfIl2CppType<DamageModifierModel>().Any();
        }
    }

    public FilterModel[] Filters
    {
        get => Filter.filters;
        set
        {
            var invis = Filter.GetChild<FilterInvisibleModel>();
            Filter.RemoveChildDependants(Filter.filters);
            Filter.filters = value.OfIl2CppType<FilterInvisibleModel>().Any()
                ? value
                : value.Prepend(invis).ToArray();
            Filter.AddChildDependants(Model.behaviors);
        }
    }

    public bool IgnoreBlockers
    {
        get => Model.ignoreBlockers;
        set => Model.ignoreBlockers = value;
    }

    public bool UsePointCollisionWithBloons
    {
        get => Model.usePointCollisionWithBloons;
        set => Model.usePointCollisionWithBloons = value;
    }

    public bool CanCollisionBeBlockedByMapLos
    {
        get => Model.canCollisionBeBlockedByMapLos;
        set => Model.canCollisionBeBlockedByMapLos = value;
    }

    public float Scale
    {
        get => Model.scale;
        set => Model.scale = value;
    }

    public int[] CollissionPasses => CollissionPasses;

    public bool DontUseCollisionChecker
    {
        get => Model.dontUseCollisionChecker;
        set => Model.dontUseCollisionChecker = value;
    }

    public int CheckCollisionFrames
    {
        get => Model.checkCollisionFrames;
        set => Model.checkCollisionFrames = value;
    }

    public bool IgnoreNonTargetable
    {
        get => Model.ignoreNonTargetable;
        set => Model.ignoreNonTargetable = value;
    }

    public bool IgnorePierceExhaustion
    {
        get => Model.ignorePierceExhaustion;
        set => Model.ignorePierceExhaustion = value;
    }

    public string SaveId
    {
        get => Model.saveId;
        set => Model.saveId = value;
    }

    public bool CanHitCamo
    {
        get => !Filter.GetChild<FilterInvisibleModel>().isActive;
        set
        {
            Filter.GetChild<FilterInvisibleModel>().isActive = !value;
            Model.GetChild<FilterInvisibleModel>().isActive = !value;
        }
    }

    private ProjectileHelper(ProjectileModel Projectile) : base(Projectile)
    {
    }

    public ProjectileHelper(string name = "") : this(new ProjectileModel(
        new PrefabReference {guidRef = ""}, name, behaviors: new Model[]
        {
            new ProjectileFilterModel("", new[]
            {
                new FilterInvisibleModel("", true, false)
            }),
            new DisplayModel("", new PrefabReference {guidRef = ""}, 0, DisplayCategory.Projectile)
        }, filters: new[]
        {
            new FilterInvisibleModel("", true, false)
        }, collisionPasses: new[] {0}, maxPierce: 0, vsBlockerRadius: 0))
    {
    }

    public static implicit operator ProjectileModel(ProjectileHelper helper)
    {
        helper.Model.UpdateCollisionPassList();
        return helper.Model;
    }

    public static implicit operator ProjectileHelper(ProjectileModel model) => new(model);

}