using System.Collections.Generic;
using System.Linq;
using Il2CppAssets.Scripts.Models;
using Il2CppAssets.Scripts.Models.GenericBehaviors;
using Il2CppAssets.Scripts.Models.Towers.Filters;
using Il2CppAssets.Scripts.Models.Towers.Projectiles;
using Il2CppAssets.Scripts.Models.Towers.Projectiles.Behaviors;
using Il2CppAssets.Scripts.Utils;
namespace BTD_Mod_Helper.Api.Helpers;

/// <summary>
/// A wrapper around ProjectileModels for making them easier to create
/// </summary>
public class ProjectileHelper : ModelHelper<ProjectileModel>
{
    /// <summary>
    /// This ProjectileModel's ProjectileFilterModel
    /// </summary>
    public ProjectileFilterModel Filter => Model.GetBehavior<ProjectileFilterModel>();
    
    /// <summary>
    /// This ProjectileModel's DisplayModel
    /// </summary>
    public DisplayModel DisplayModel => Model.GetBehavior<DisplayModel>();

    /// <seealso cref="ProjectileModel.display"/>
    public string Display
    {
        get => Model.display.guidRef;
        set => Model.display.guidRef = Model.GetBehavior<DisplayModel>().display.guidRef = value;
    }

    /// <seealso cref="ProjectileModel.display"/>
    public PrefabReference DisplayReference
    {
        get => Model.display;
        set => Model.display = Model.GetBehavior<DisplayModel>().display = value;
    }

    /// <seealso cref="ProjectileModel.radius"/>
    public float Radius
    {
        get => Model.radius;
        set => Model.radius = value;
    }

    /// <seealso cref="ProjectileModel.vsBlockerRadius"/>
    public float VsBlockerRadius
    {
        get => Model.vsBlockerRadius;
        set => Model.vsBlockerRadius = value;
    }

    /// <seealso cref="ProjectileModel.pierce"/>
    public float Pierce
    {
        get => Model.pierce;
        set => Model.pierce = value;
    }

    /// <seealso cref="ProjectileModel.maxPierce"/>
    public float MaxPierce
    {
        get => Model.maxPierce;
        set => Model.maxPierce = value;
    }

    /// <seealso cref="ProjectileModel.behaviors"/>
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

    /// <seealso cref="ProjectileFilterModel.filters"/>
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

    /// <seealso cref="ProjectileModel.ignoreBlockers"/>
    public bool IgnoreBlockers
    {
        get => Model.ignoreBlockers;
        set => Model.ignoreBlockers = value;
    }

    /// <seealso cref="ProjectileModel.usePointCollisionWithBloons"/>
    public bool UsePointCollisionWithBloons
    {
        get => Model.usePointCollisionWithBloons;
        set => Model.usePointCollisionWithBloons = value;
    }

    /// <seealso cref="ProjectileModel.canCollisionBeBlockedByMapLos"/>
    public bool CanCollisionBeBlockedByMapLos
    {
        get => Model.canCollisionBeBlockedByMapLos;
        set => Model.canCollisionBeBlockedByMapLos = value;
    }

    /// <seealso cref="ProjectileModel.scale"/>
    public float Scale
    {
        get => Model.scale;
        set => Model.scale = value;
    }

    /// <seealso cref="ProjectileModel.collisionPasses"/>
    public int[] CollissionPasses
    {
        get => Model.collisionPasses;
        set => Model.collisionPasses = value;
    }

    
    /// <seealso cref="ProjectileModel.dontUseCollisionChecker"/>
    public bool DontUseCollisionChecker
    {
        get => Model.dontUseCollisionChecker;
        set => Model.dontUseCollisionChecker = value;
    }

    /// <seealso cref="ProjectileModel.checkCollisionFrames"/>
    public int CheckCollisionFrames
    {
        get => Model.checkCollisionFrames;
        set => Model.checkCollisionFrames = value;
    }

    /// <seealso cref="ProjectileModel.ignoreNonTargetable"/>
    public bool IgnoreNonTargetable
    {
        get => Model.ignoreNonTargetable;
        set => Model.ignoreNonTargetable = value;
    }

    /// <seealso cref="ProjectileModel.ignorePierceExhaustion"/>
    public bool IgnorePierceExhaustion
    {
        get => Model.ignorePierceExhaustion;
        set => Model.ignorePierceExhaustion = value;
    }

    /// <seealso cref="ProjectileModel.saveId"/>
    public string SaveId
    {
        get => Model.saveId;
        set => Model.saveId = value;
    }

    /// <seealso cref="FilterInvisibleModel.isActive"/>
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

    /// <summary>
    /// Begins construction of a new ProjectileModel with sensible default values
    /// </summary>
    /// <param name="name">The model name (don't need the ProjectileModel_ part)</param>
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

    /// <summary>
    /// Unwraps the model (and updates collission passes)
    /// </summary>
    public static implicit operator ProjectileModel(ProjectileHelper helper)
    {
        helper.Model.UpdateCollisionPassList();
        return helper.Model;
    }

    /// <summary>
    /// Wraps a model
    /// </summary>
    public static implicit operator ProjectileHelper(ProjectileModel model) => new(model);

}