using Il2CppAssets.Scripts.Models.Towers.Behaviors.Emissions;
using Il2CppAssets.Scripts.Models.Towers.Projectiles;
using Il2CppAssets.Scripts.Models.Towers.Weapons;
using Il2CppAssets.Scripts.Simulation.SMath;
namespace BTD_Mod_Helper.Api.Helpers;

/// <summary>
/// A wrapper around WeaponModels for making them easier to create
/// </summary>
public class WeaponHelper : ModelHelper<WeaponModel>
{
    /// <seealso cref="WeaponModel.animation"/>
    public int Animation
    {
        get => Model.animation;
        set => Model.animation = value;
    }

    /// <seealso cref="WeaponModel.Rate"/>
    public float Rate
    {
        get => Model.Rate;
        set => Model.Rate = value;
    }

    /// <seealso cref="WeaponModel.projectile"/>
    public ProjectileModel Projectile
    {
        get => Model.projectile;
        set => Model.SetProjectile(value);
    }

    /// <seealso cref="WeaponModel.ejectX"/>
    /// <seealso cref="WeaponModel.ejectY"/>
    /// <seealso cref="WeaponModel.ejectZ"/>
    public Vector3 Eject
    {
        get => Model.GetEject();
        set => Model.SetEject(value);
    }

    /// <seealso cref="WeaponModel.animationOffset"/>
    public float AnimationOffset
    {
        get => Model.animationOffset;
        set
        {
            Model.animationOffset = value;
            Model.animationOffsetFrames = (int) (value * 60);
        }
    }

    /// <seealso cref="WeaponModel.fireWithoutTarget"/>
    public bool FireWithoutTarget
    {
        get => Model.fireWithoutTarget;
        set => Model.fireWithoutTarget = value;
    }

    /// <seealso cref="WeaponModel.fireBetweenRounds"/>
    public bool FireBetweenRounds
    {
        get => Model.fireBetweenRounds;
        set => Model.fireBetweenRounds = value;
    }

    /// <seealso cref="WeaponModel.emission"/>
    public EmissionModel Emission
    {
        get => Model.emission;
        set => Model.SetEmission(value);
    }

    /// <seealso cref="WeaponModel.behaviors"/>
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

    /// <seealso cref="WeaponModel.useAttackPosition"/>
    public bool UseAttackPosition
    {
        get => Model.useAttackPosition;
        set => Model.useAttackPosition = value;
    }

    /// <seealso cref="WeaponModel.startInCooldown"/>
    public bool StartInCooldown
    {
        get => Model.startInCooldown;
        set => Model.startInCooldown = value;
    }

    /// <seealso cref="WeaponModel.customStartCooldown"/>
    public float CustomStartCooldown
    {
        get => Model.customStartCooldown;
        set
        {
            Model.customStartCooldownFrames = (int) (value * 60);
            Model.customStartCooldown = value;
        }
    }

    /// <seealso cref="WeaponModel.animateOnMainAttack"/>
    public bool AnimateOnMainAttack
    {
        get => Model.animateOnMainAttack;
        set => Model.animateOnMainAttack = value;
    }

    private WeaponHelper(WeaponModel weapon) : base(weapon)
    {
    }

    /// <summary>
    /// Begins construction of a new WeaponModel with sensible default values
    /// </summary>
    /// <param name="name">The model name (don't need the WeaponModel_ part)</param>
    public WeaponHelper(string name = "") : this(new WeaponModel(name, emission: new SingleEmissionModel("", null)))
    {
    }
    
    /// <summary>
    /// Unwraps the model
    /// </summary>
    public static implicit operator WeaponModel(WeaponHelper helper) => helper.Model;
    
    /// <summary>
    /// Wraps a model
    /// </summary>
    public static implicit operator WeaponHelper(WeaponModel model) => new(model);

}