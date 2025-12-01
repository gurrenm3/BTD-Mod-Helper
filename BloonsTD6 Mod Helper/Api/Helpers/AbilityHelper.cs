using Il2CppAssets.Scripts.Models;
using Il2CppAssets.Scripts.Models.Towers.Behaviors.Abilities;
using Il2CppNinjaKiwi.Common.ResourceUtils;
namespace BTD_Mod_Helper.Api.Helpers;

/// <summary>
/// A wrapper around AbilityModels for making them easier to create
/// </summary>
public class AbilityHelper : ModelHelper<AbilityModel>
{
    /// Default name
    /// <seealso cref="AbilityModel.displayName"/>
    public string DisplayName
    {
        get => Model.displayName;
        set => Model.displayName = value;
    }

    /// Default name
    /// <seealso cref="AbilityModel.description"/>
    public string Description
    {
        get => Model.description;
        set => Model.description = value;
    }

    /// Default -1
    /// <seealso cref="AbilityModel.animation"/>
    public int Animation
    {
        get => Model.animation;
        set => Model.animation = value;
    }

    /// Default 0
    /// <seealso cref="AbilityModel.AnimationOffset"/>
    public float AnimationOffset
    {
        get => Model.AnimationOffset;
        set => Model.AnimationOffset = value;
    }

    /// Default ""
    /// <seealso cref="AbilityModel.icon"/>
    public string Icon
    {
        get => Model.icon.guidRef;
        set => Model.icon = new SpriteReference(value);
    }

    /// Default { guidRef = "" }
    /// <seealso cref="AbilityModel.icon"/>
    public SpriteReference IconReference
    {
        get => Model.icon;
        set => Model.icon = value;
    }

    /// Default 0
    /// <seealso cref="AbilityModel.Cooldown"/>
    public float Cooldown
    {
        get => Model.Cooldown;
        set => Model.Cooldown = value;
    }

    /// Default null
    /// <seealso cref="AbilityModel.behaviors"/>
    public Model[] Behaviors
    {
        get => Model.behaviors ?? new Il2CppReferenceArray<Model>(0);
        set
        {
            Model.RemoveChildDependants(Model.behaviors);
            Model.behaviors = value;
            Model.AddChildDependants(Model.behaviors);
        }
    }


    /// Default false
    /// <seealso cref="AbilityModel.activateOnPreLeak"/>
    public bool ActivateOnPreLeak
    {
        get => Model.activateOnPreLeak;
        set => Model.activateOnPreLeak = value;
    }

    /// Default false
    /// <seealso cref="AbilityModel.activateOnLeak"/>
    public bool ActivateOnLeak
    {
        get => Model.activateOnLeak;
        set => Model.activateOnLeak = value;
    }

    /// Default ""
    /// <seealso cref="AbilityModel.addedViaUpgrade"/>
    public string AddedViaUpgrade
    {
        get => Model.addedViaUpgrade;
        set => Model.addedViaUpgrade = value;
    }

    /// Default 0
    /// <seealso cref="AbilityModel.CooldownSpeedScale" />
    public float CooldownSpeedScale
    {
        get => Model.CooldownSpeedScale;
        set => Model.CooldownSpeedScale = value;
    }

    /// Default 0
    /// <seealso cref="AbilityModel.livesCost" />
    public int LivesCost
    {
        get => Model.livesCost;
        set => Model.livesCost = value;
    }

    /// Default -1
    /// <seealso cref="AbilityModel.maxActivationsPerRound" />
    public int MaxActivationsPerRound
    {
        get => Model.maxActivationsPerRound;
        set => Model.maxActivationsPerRound = value;
    }

    /// Default false
    /// <seealso cref="AbilityModel.resetCooldownOnTierUpgrade" />
    public bool ResetCooldownOnTierUpgrade
    {
        get => Model.resetCooldownOnTierUpgrade;
        set => Model.resetCooldownOnTierUpgrade = value;
    }

    /// Default false
    /// <seealso cref="AbilityModel.activateOnLivesLost" />
    public bool ActivateOnLivesLost
    {
        get => Model.activateOnLivesLost;
        set => Model.activateOnLivesLost = value;
    }

    /// Default true
    /// <seealso cref="AbilityModel.enabled" />
    public bool Enabled
    {
        get => Model.enabled;
        set => Model.enabled = value;
    }

    /// Default false
    /// <seealso cref="AbilityModel.canActivateBetweenRounds" />
    public bool CanActivateBetweenRounds
    {
        get => Model.canActivateBetweenRounds;
        set => Model.canActivateBetweenRounds = value;
    }

    /// Default false
    /// <seealso cref="AbilityModel.sharedCooldown" />
    public bool SharedCooldown
    {
        get => Model.sharedCooldown;
        set => Model.sharedCooldown = value;
    }

    /// Default false
    /// <seealso cref="AbilityModel.dontShowStacked" />
    public bool DontShowStacked
    {
        get => Model.dontShowStacked;
        set => Model.dontShowStacked = value;
    }

    /// Default false
    /// <seealso cref="AbilityModel.animateOnMainAttackDisplay" />
    public bool AnimateOnMainAttackDisplay
    {
        get => Model.animateOnMainAttackDisplay;
        set => Model.animateOnMainAttackDisplay = value;
    }

    /// Default false
    /// <seealso cref="AbilityModel.restrictAbilityAfterMaxRoundTimer" />
    public bool RestrictAbilityAfterMaxRoundTimer
    {
        get => Model.restrictAbilityAfterMaxRoundTimer;
        set => Model.restrictAbilityAfterMaxRoundTimer = value;
    }

    private AbilityHelper(AbilityModel model) : base(model)
    {
    }

    /// <summary>
    /// Begins construction of a new AttackModel with sensible default values    
    /// <param name="name">The model name (don't need the AbilityModel_ part)</param>
    /// </summary>
    public AbilityHelper
        (string name = "") : base(new AbilityModel(name, name, name, -1, 0, new SpriteReference {guidRef = ""}, 0, null,
        false, false, "", 0, 0, -1, -1, false, false))
    {
    }

    /// <summary>
    /// Unwraps the model
    /// </summary>
    public static implicit operator AbilityModel(AbilityHelper helper) => helper.Model;

    /// <summary>
    /// Wraps a model
    /// </summary>
    public static implicit operator AbilityHelper(AbilityModel model) => new(model);
}