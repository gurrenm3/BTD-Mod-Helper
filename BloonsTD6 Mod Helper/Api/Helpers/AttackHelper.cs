using System.Linq;
using Il2CppAssets.Scripts.Models;
using Il2CppAssets.Scripts.Models.Towers.Behaviors.Attack;
using Il2CppAssets.Scripts.Models.Towers.Behaviors.Attack.Behaviors;
using Il2CppAssets.Scripts.Models.Towers.Filters;
using Il2CppAssets.Scripts.Models.Towers.Weapons;
using Il2CppAssets.Scripts.Simulation.SMath;
namespace BTD_Mod_Helper.Api.Helpers;

public class AttackHelper : ModelHelper<AttackModel>
{
    private AttackFilterModel Filter => Model.GetBehavior<AttackFilterModel>();

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

    public float Range
    {
        get => Model.range;
        set => Model.range = value;
    }

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
            Model.AddChildDependant(value);
        }
    }

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

    public bool AttackThroughWalls
    {
        get => Model.attackThroughWalls;
        set => Model.attackThroughWalls = value;
    }

    public bool FireWithoutTarget
    {
        get => Model.fireWithoutTarget;
        set => Model.fireWithoutTarget = value;
    }


    public int FramesBeforeRetarget
    {
        get => Model.framesBeforeRetarget;
        set => Model.framesBeforeRetarget = value;
    }

    public bool AddToSharedGrid
    {
        get => Model.addsToSharedGrid;
        set => Model.addsToSharedGrid = value;
    }

    public float SharedGridRange
    {
        get => Model.sharedGridRange;
        set => Model.sharedGridRange = value;
    }

    public bool CanSeeCamo
    {
        get => !Filter.GetChild<FilterInvisibleModel>().isActive;
        set => Filter.GetChild<FilterInvisibleModel>().isActive = !value;
    }
    
    private AttackHelper(AttackModel attack) : base(attack)
    {
    }

    public AttackHelper(string name = "") : this(new AttackModel(name,
        new Il2CppReferenceArray<WeaponModel>(0), 0, new[]
        {
            new AttackFilterModel(name, new[]
            {
                new FilterInvisibleModel("", true, false)
            })
        }, null, 0, 0, 0, false, false, 0, false, 0))
    {
    }

    public static implicit operator AttackModel(AttackHelper helper) => helper.Model;

    public static implicit operator AttackHelper(AttackModel model) => new(model);

}