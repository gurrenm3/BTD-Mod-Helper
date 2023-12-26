using System;
using System.Collections.Generic;
using System.Linq;
using BTD_Mod_Helper.Api.Display;
using BTD_Mod_Helper.Api.Enums;
using Il2CppAssets.Scripts.Models;
using Il2CppAssets.Scripts.Models.Bloons;
using Il2CppAssets.Scripts.Models.Bloons.Behaviors;
using Il2CppAssets.Scripts.Models.GenericBehaviors;
using Il2CppAssets.Scripts.Unity;
using Il2CppAssets.Scripts.Utils;
namespace BTD_Mod_Helper.Api.Bloons;

/// <summary>
/// Class for adding in a new Bloon to the game
/// </summary>
public abstract class ModBloon : NamedModContent
{
    internal static readonly Dictionary<string, ModBloon> Cache = new();

    internal static readonly Dictionary<string, BloonModel> BloonModelCache = new();
    internal readonly List<ModBloonDisplay> displays = new();
    internal BloonModel bloonModel;

    /// <inheritdoc />
    public sealed override int RegisterPerFrame => 3;

    /// <summary>
    /// ModBloons with a BaseModBloon need to register after their base
    /// </summary>
    /// <exclude />
    protected override float RegistrationPriority => (BaseModBloon?.RegistrationPriority ?? 5) + 1;

    /// <summary>
    /// The ModBloon that this is based off of, or null if not based on a ModBloon
    /// </summary>
    protected virtual ModBloon BaseModBloon => null;


    private protected override string ID => KeepBaseId
        ? BloonModelUtils.ConstructBloonId(BaseBloon, Camo, Regrow, Fortified)
        : base.ID;

    /// <summary>
    /// The Bloon in the game that this should copy from as a base. Use BloonType.[Name]
    /// </summary>
    public abstract string BaseBloon { get; }


    /// <summary>
    /// Set this to true if you're making another version of the BaseBloon, like a Fortified Red Bloon
    /// </summary>
    public virtual bool KeepBaseId => false;

    /// <summary>
    /// The Icon for the Bloon within the UI, by default looking for the same name as the file
    /// </summary>
    public virtual string Icon => GetType().Name;

    /// <summary>
    /// If you're not going to use a custom .png for your Icon, use this to directly control its SpriteReference
    /// </summary>
    public virtual SpriteReference IconReference => GetSpriteReferenceOrDefault(Icon);

    /// <summary>
    /// Add the necessary properties to make this a Fortified Bloon
    /// </summary>
    public virtual bool Fortified => false;

    /// <summary>
    /// Add the necessary properties to make this a Regrow Bloon
    /// </summary>
    public virtual bool Regrow => false;

    /// <summary>
    /// The ID of the bloon that this should regrow into
    /// </summary>
    public virtual string RegrowsTo => "";

    /// <summary>
    /// Whether this Bloon should use its Icon as its display
    /// </summary>
    public virtual bool UseIconAsDisplay => !BaseBloonModel.IsMoabBloon();

    /// <summary>
    /// The regrow rate
    /// </summary>
    public virtual float RegrowRate => 3;

    /// <summary>
    /// Add the necessary properties to make this a Camo Bloon
    /// </summary>
    public virtual bool Camo => false;

    /// <summary>
    /// The list of displays to use as DamageStates for this Bloon
    /// </summary>
    public virtual IEnumerable<string> DamageStates => null;

    /// <summary>
    /// For 2D bloons, the ratio between pixels and display units. Higher number -> smaller Bloon.
    /// </summary>
    [Obsolete("Use Scale instead")]
    public virtual float PixelsPerUnit => 10f;

    /// <summary>
    /// For bloons with UseIconAsDisplay, the scale for the texture to use
    /// </summary>
    public virtual float Scale => 1f;


    internal BloonModel BaseBloonModel => Game.instance.model.GetBloon(BaseBloon);

    /// <inheritdoc />
    public override void Register()
    {
        bloonModel = GetDefaultBloonModel();

        try
        {
            ModifyBaseBloonModel(bloonModel);
        }
        catch (Exception)
        {
            ModHelper.Error($"Failed to modify base Bloon model for {Id}");
            throw;
        }
        bloonModel.updateChildBloonModels = true;

        bloonModel.GenerateDescendentNames();

        displays.Find(display => display.Damage == 0)?.Apply(bloonModel);
        var damageDisplays = displays
            .Where(display => display.Damage > 0)
            .OrderBy(display => display.Damage)
            .ToList();
        if (damageDisplays.Any())
        {
            ApplyDamageStates(bloonModel, damageDisplays.Select(display => display.Id).ToList());
        }

        Game.instance.model.bloons = Game.instance.model.bloons.AddTo(bloonModel);
        Game.instance.model.AddChildDependant(bloonModel);
        Game.instance.model.bloonsByName[bloonModel.name] = bloonModel;
        BloonModelCache[bloonModel.name] = bloonModel;
        Cache[bloonModel.name] = this;
    }

    /// <summary>
    /// Apply your custom modifications to the base bloon
    /// </summary>
    /// <param name="bloonModel"></param>
    public abstract void ModifyBaseBloonModel(BloonModel bloonModel);

    internal virtual BloonModel GetDefaultBloonModel()
    {
        var model = BaseBloonModel.Duplicate();

        model.icon = IconReference;
        model.RemoveTag(model.GetBaseID());

        if (BaseModBloon != null)
        {
            model.baseId = BaseModBloon.Id;
        }

        if (!KeepBaseId)
        {
            model.baseId = Id;
        }

        model.AddTag(model.baseId);

        model.id = model.name = Id;
        model.SetCamo(Camo);
        model.SetFortified(Fortified);

        if (Regrow)
        {
            model.SetRegrow(RegrowsTo, RegrowRate);
        }
        else
        {
            model.RemoveRegrow();
        }

        if (DamageStates != null)
        {
            ApplyDamageStates(model, DamageStates.ToList());
        }

        if (UseIconAsDisplay)
        {
            var display = new ModDisplay2DImpl(mod, Id, Icon, Scale, ModDisplay.Bloon2dDisplay, DisplayCategory.Bloon);
            display.Apply(model);
        }

        return model;
    }

    internal void ApplyDamageStates(BloonModel model, List<string> damageStates)
    {
        // model.RemoveBehaviors<DamageStateModel>();
        var displayStates = new List<DamageStateModel>();

        var count = damageStates.Count + 1;
        var i = 1f;
        foreach (var damageState in damageStates)
        {
            var guid = damageState;
            if (!ModDisplay.Cache.ContainsKey(damageState) && TextureExists(mod, damageState))
            {
                guid = new ModDisplay2DImpl(mod, Id + i, damageState, Scale, ModDisplay.Bloon2dDisplay,
                    DisplayCategory.Bloon).Id;
            }

            displayStates.Add(new DamageStateModel($"DamageStateModel_damage_state_{i}",
                CreatePrefabReference(guid), 1 - i / count));
            i++;
        }

        model.damageDisplayStates = displayStates.ToIl2CppReferenceArray();

        /* No longer included as of v32.0
        foreach (var damageStateModel in displayStates)
        {
            model.AddBehavior(damageStateModel);
        }
        */
    }

    /// <summary>
    /// Further modifies this bloon when you go into a new match.
    /// Useful for making conditional effects happen based on settings.
    /// </summary>
    /// <param name="model">The Base bloon model</param>
    /// <param name="gameModes">What GameModes are active for the match</param>
    public virtual void ModifyBloonModelForMatch(BloonModel model, IReadOnlyList<ModModel> gameModes)
    {
    }
}

/// <summary>
/// Class for a ModBloon which has a different ModBloon as its base
/// </summary>
/// <typeparam name="T"></typeparam>
public abstract class ModBloon<T> : ModBloon where T : ModBloon
{
    /// <inheritdoc />
    public override bool KeepBaseId => true;

    /// <summary>
    /// The BaseBloon is the same as its base's
    /// </summary>
    public sealed override string BaseBloon => BloonID<T>();

    /// <inheritdoc />
    protected sealed override ModBloon BaseModBloon => GetInstance<T>();
}