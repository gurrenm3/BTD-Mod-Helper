using System.Collections.Generic;
using Il2CppAssets.Scripts.Data;
using Il2CppAssets.Scripts.Data.Global;
using Il2CppAssets.Scripts.Models.GenericBehaviors;
using Il2CppAssets.Scripts.Models.Towers.Behaviors;
using Il2CppAssets.Scripts.Unity;
using Il2CppAssets.Scripts.Utils;
namespace BTD_Mod_Helper.Api.Display;

/// <summary>
/// Class for adding a new buff icon that can be displayed for towers
/// </summary>
public abstract class ModBuffIcon : NamedModContent
{
    internal static readonly Dictionary<string, SpriteReference> CustomBuffIcons = new();

    /// <inheritdoc />
    protected sealed override float RegistrationPriority => 1f;

    /// <inheritdoc />
    public sealed override string DisplayName => base.DisplayName;

    /// <inheritdoc />
    public sealed override string DisplayNamePlural => base.DisplayNamePlural;

    /// <inheritdoc />
    public sealed override string Description => base.Description;

    /// <summary>
    /// The Icon for to display for the buff
    /// <br/>
    /// (Name of .png or .jpg, not including file extension)
    /// </summary>
    public virtual string Icon => GetType().Name;

    /// <summary>
    /// If you're not going to use a custom .png for your Icon, use this to directly control its SpriteReference
    /// </summary>
    public virtual SpriteReference IconReference => GetSpriteReferenceOrDefault(Icon);

    /// <summary>
    /// Whether the buff affects every tower on screen
    /// </summary>
    public virtual bool GlobalRange => false;

    /// <summary>
    /// If greater than 0, the total number of stacks that a tower can have at one time
    /// </summary>
    public virtual int MaxStackSize => 0;

    /// <summary>
    /// Controls the OnlyShowBuffIfMutated property on the model
    /// </summary>
    public virtual bool OnlyShowBuffIfMutated => false;

    private BuffIndicatorModel CreateBuffIndicatorModel() => new($"BuffIndicatorModel_{Id}-{Icon}", Icon, Id, GlobalRange,
        MaxStackSize, OnlyShowBuffIfMutated);

    /// <summary>
    /// Makes a support model use this as its buff indicator
    /// </summary>
    /// <param name="model">The support model to apply to</param>
    public void ApplyTo(SupportModel model)
    {
        model.buffLocsName = BuffLocsName;
        model.buffIconName = BuffIconName;
        model.isGlobal = GlobalRange;
        model.maxStackSize = MaxStackSize;
        model.onlyShowBuffIfMutated = OnlyShowBuffIfMutated;
        model.showBuffIcon = true;
    }
    
    /// <summary>
    /// Makes a support model use this as its buff indicator
    /// </summary>
    /// <param name="model">The support model to apply to</param>
    public void ApplyTo(TowerBehaviorBuffModel model)
    {
        model.buffLocsName = BuffLocsName;
        model.buffIconName = BuffIconName;
        model.isGlobalRange = GlobalRange;
        model.maxStackSize = MaxStackSize;
    }

    /// <summary>
    /// What should go in a Model's buffLocsName field
    /// </summary>
    public string BuffLocsName => Icon;

    /// <summary>
    /// What should go in a Model's buffIconName field
    /// </summary>
    public string BuffIconName => Id;
    
    /// <inheritdoc />
    public override void Register()
    {
        CustomBuffIcons[Id] = IconReference;

        var model = CreateBuffIndicatorModel();

        var gameModel = Game.instance.model;

        gameModel.buffIndicatorModels = gameModel.buffIndicatorModels.AddTo(model);
        gameModel.AddChildDependant(model);
        
        GameData.Instance.buffIconSprites.buffIconSprites.Add(new BuffIconSprite
        {
            buffId = Id,
            icon = IconReference
        });
    }
}