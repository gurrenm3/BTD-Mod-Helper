using System.Linq;
using Il2CppAssets.Scripts.Models;
using Il2CppAssets.Scripts.Models.Towers.Behaviors.Attack;
using Il2CppAssets.Scripts.Models.Towers.Behaviors.Attack.Behaviors;
using Il2CppAssets.Scripts.Models.Towers.Filters;
using Il2CppAssets.Scripts.Models.Towers.Weapons;
using Il2CppAssets.Scripts.Simulation.SMath;
namespace BTD_Mod_Helper.Api.Helpers;

/// <summary>
/// A wrapper around AttackModels for making them easier to create
/// </summary>
public class AttackHelper : ModelHelper<AttackModel>
{
    /// <summary>
    /// This AttackModel's AttackFilterModel
    /// </summary>
    public AttackFilterModel Filter => Model.GetBehavior<AttackFilterModel>();

    /// Default null
    /// <seealso cref="AttackModel.weapons"/>
    public WeaponModel Weapon
    {
        get => Model.GetChild<WeaponModel>();
        set
        {
            Model.RemoveChildDependants(Model.weapons);
            Model.weapons = new[] {value};
            Model.AddChildDependant(value);
        }
    }

    /// Default empty
    /// <seealso cref="AttackModel.weapons"/>
    public WeaponModel[] Weapons
    {
        get => Model.weapons;
        set
        {
            Model.RemoveChildDependants(Model.weapons);
            Model.weapons = value;
            Model.AddChildDependants(value);
        }
    }

    /// Default 0
    /// <seealso cref="AttackModel.range"/>
    public float Range
    {
        get => Model.range;
        set => Model.range = value;
    }

    /// Default null
    /// <seealso cref="AttackModel.behaviors"/>
    public Model[] Behaviors
    {
        get => Model.behaviors;
        set
        {
            Model.RemoveChildDependants(Model.behaviors);
            Model.behaviors = value.OfIl2CppType<AttackFilterModel>().Any() ? value : value.Prepend(Filter).ToArray();
            Model.AddChildDependants(Model.behaviors);
        }
    }
    
    /// Default includes the required FilterInvisibleModel
    /// <seealso cref="AttackFilterModel.filters"/>
    public FilterModel[] Filters
    {
        get => Filter.filters;
        set
        {
            Filter.RemoveChildDependants(Model.behaviors);
            Filter.filters = value.OfIl2CppType<FilterInvisibleModel>().Any()
                ? value
                : value.Prepend(Filter.GetChild<FilterInvisibleModel>()).ToArray();
            Filter.AddChildDependants(Model.behaviors);
        }
    }

    /// Default null
    /// <seealso cref="AttackModel.targetProvider"/>
    public TargetSupplierModel TargetProvider
    {
        get => Model.targetProvider;
        set
        {
            Model.RemoveChildDependant(Model.targetProvider);
            if (!Model.behaviors.Contains(value))
            {
                Model.AddBehavior(value);
            }
            Model.targetProvider = value;
        }
    }

    /// Default (0, 0, 0)
    /// <seealso cref="AttackModel.offsetX"/>
    /// <seealso cref="AttackModel.offsetY"/>
    /// <seealso cref="AttackModel.offsetZ"/>
    public Vector3 Offset
    {
        get => new(Model.offsetX, Model.offsetY, Model.offsetZ);
        set
        {
            Model.offsetX = value.x;
            Model.offsetY = value.y;
            Model.offsetZ = value.z;
        }
    }

    /// Default false
    /// <seealso cref="AttackModel.attackThroughWalls"/>
    public bool AttackThroughWalls
    {
        get => Model.attackThroughWalls;
        set => Model.attackThroughWalls = value;
    }

    /// Default false
    /// <seealso cref="AttackModel.fireWithoutTarget"/>
    public bool FireWithoutTarget
    {
        get => Model.fireWithoutTarget;
        set => Model.fireWithoutTarget = value;
    }

    /// Default 0
    /// <seealso cref="AttackModel.framesBeforeRetarget"/>
    public int FramesBeforeRetarget
    {
        get => Model.framesBeforeRetarget;
        set => Model.framesBeforeRetarget = value;
    }

    /// Default true
    /// <seealso cref="AttackModel.addsToSharedGrid"/>
    public bool AddToSharedGrid
    {
        get => Model.addsToSharedGrid;
        set => Model.addsToSharedGrid = value;
    }

    /// Default 0
    /// <seealso cref="AttackModel.sharedGridRange"/>
    public float SharedGridRange
    {
        get => Model.sharedGridRange;
        set => Model.sharedGridRange = value;
    }

    /// Default false
    /// <seealso cref="FilterInvisibleModel.isActive"/>
    public bool CanSeeCamo
    {
        get => !Filter.GetChild<FilterInvisibleModel>().isActive;
        set => Filter.GetChild<FilterInvisibleModel>().isActive = !value;
    }

    private AttackHelper(AttackModel attack) : base(attack)
    {
    }

    /// <summary>
    /// Begins construction of a new AttackModel with sensible default values
    /// </summary>
    /// <param name="name">The model name (don't need the AttackModel_ part)</param>
    /// <param name="airUnit">Create an AttackAirUnitModel instead of an AttackModel</param>
    public AttackHelper(string name = "", bool airUnit = false) : this(airUnit
        ? new AttackAirUnitModel(name,
            new Il2CppReferenceArray<WeaponModel>(0), 0, new[]
            {
                new AttackFilterModel(name, new[]
                {
                    new FilterInvisibleModel("", true, false)
                })
            }, null, 0, 0, 0, false, false, 0, true, 0, null)
        : new AttackModel(name,
            new Il2CppReferenceArray<WeaponModel>(0), 0, new[]
            {
                new AttackFilterModel(name, new[]
                {
                    new FilterInvisibleModel("", true, false)
                })
            }, null, 0, 0, 0, false, false, 0, true, 0, false)) // TODO should this be true
    {
    }

    /// <summary>
    /// Unwraps the model
    /// </summary>
    public static implicit operator AttackModel(AttackHelper helper) => helper.Model;

    /// <summary>
    /// Wraps a model
    /// </summary>
    public static implicit operator AttackHelper(AttackModel model) => new(model);

}