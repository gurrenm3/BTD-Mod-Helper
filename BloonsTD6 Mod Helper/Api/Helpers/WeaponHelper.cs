using Il2CppAssets.Scripts.Models.Towers.Behaviors.Emissions;
using Il2CppAssets.Scripts.Models.Towers.Projectiles;
using Il2CppAssets.Scripts.Models.Towers.Weapons;
using Il2CppAssets.Scripts.Simulation.SMath;
namespace BTD_Mod_Helper.Api.Helpers;

public class WeaponHelper : ModelHelper<WeaponModel>
{
    public int Animation
    {
        get => Model.animation;
        set => Model.animation = value;
    }

    public float Rate
    {
        get => Model.Rate;
        set => Model.Rate = value;
    }

    public ProjectileModel Projectile
    {
        get => Model.projectile;
        set => Model.SetProjectile(value);
    }

    public Vector3 Eject
    {
        get => Model.GetEject();
        set => Model.SetEject(value);
    }

    public float AnimationOffset
    {
        get => Model.animationOffset;
        set
        {
            Model.animationOffset = value;
            Model.animationOffsetFrames = (int) (value * 60);
        }
    }

    public bool FireWithoutTarget
    {
        get => Model.fireWithoutTarget;
        set => Model.fireWithoutTarget = value;
    }

    public bool FireBetweenRounds
    {
        get => Model.fireBetweenRounds;
        set => Model.fireBetweenRounds = value;
    }

    public EmissionModel Emission
    {
        get => Model.emission;
        set => Model.SetEmission(value);
    }

    public WeaponBehaviorModel[] Behaviors
    {
        get => Model.behaviors ?? new Il2CppReferenceArray<WeaponBehaviorModel>(0);
        set
        {
            Model.RemoveChildDependants(Model.behaviors);
            Model.behaviors = value;
            Model.AddChildDependants(Model.behaviors);
        }
    }

    public bool UseAttackPosition
    {
        get => Model.useAttackPosition;
        set => Model.useAttackPosition = value;
    }

    public bool StartInCooldown
    {
        get => Model.startInCooldown;
        set => Model.startInCooldown = value;
    }

    public float CustomStartCooldown
    {
        get => Model.customStartCooldown;
        set => Model.customStartCooldown = value;
    }

    public bool AnimateOnMainAttack
    {
        get => Model.animateOnMainAttack;
        set => Model.animateOnMainAttack = value;
    }

    private WeaponHelper(WeaponModel weapon) : base(weapon)
    {
    }

    public WeaponHelper(string name = "") : this(new WeaponModel(name, emission: new SingleEmissionModel("", null)))
    {
    }

    public static implicit operator WeaponModel(WeaponHelper helper) => helper.Model;

    public static implicit operator WeaponHelper(WeaponModel model) => new(model);

}