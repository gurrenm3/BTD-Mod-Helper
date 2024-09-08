using System;
using System.Collections.Generic;
using System.Linq;
using Il2CppAssets.Scripts.Data;
using Il2CppAssets.Scripts.Models;
using Il2CppAssets.Scripts.Models.Rounds;
using Il2CppAssets.Scripts.Unity;
using Il2CppNinjaKiwi.Common.ResourceUtils;
namespace BTD_Mod_Helper.Api.Bloons;

/// <summary>
/// Class for a custom RoundSet
/// </summary>
public abstract class ModRoundSet : NamedModContent
{
    internal static readonly Dictionary<string, ModRoundSet> Cache = new();

    internal RoundSetModel model;

    /// <summary>
    /// RoundSets register Bloons and before GameModes
    /// </summary>
    /// <exclude />
    protected override float RegistrationPriority => 9;

    /// <summary>
    /// The Base Rounds included in the RoundSet specified by BaseRoundSet
    /// </summary>
    protected List<RoundModel> BaseRounds =>
        GameData.Instance.roundSets.FirstOrDefault(set => set.name == BaseRoundSet)?.rounds.ToList() ??
        new List<RoundModel>();

    /// <inheritdoc />
    public sealed override string DisplayNamePlural => base.DisplayNamePlural;

    /// <summary>
    /// The id of the existing RoundSet to use as a base. Use RoundSetType.[name]
    /// If this RoundSetType.None, empty, or null, then an empty round set will be used
    /// </summary>
    public abstract string BaseRoundSet { get; }

    /// <summary>
    /// The total number of rounds that have specified Bloons.
    /// <br />
    /// After this number of rounds, randomized Free Play rounds will happen
    /// </summary>
    public abstract int DefinedRounds { get; }

    /// <summary>
    /// The Icon for the Button for this RoundSet within the UI, by default looking for the same name as the file
    /// </summary>
    public virtual string Icon => GetType().Name;

    /// <summary>
    /// If you're not going to use a custom .png for your Icon, use this to directly control its SpriteReference
    /// </summary>
    public virtual SpriteReference IconReference => GetSpriteReferenceOrDefault(Icon);

    /// <summary>
    /// Whether this Round set should show up in the menu allowing you to use any RoundSet for any GameMode
    /// </summary>
    public virtual bool AddToOverrideMenu => true;

    /// <summary>
    /// Whether these rounds should have custom hints, like Alternate Bloons Rounds does
    /// </summary>
    [Obsolete("No longer needs to be specified, just use return non null from GetHint")]
    public virtual bool CustomHints => false;

    /// <summary>
    /// Whether to bypass the base game hints settings. Useful for using your own ModSetting to control hints.
    /// </summary>
    public virtual bool AlwaysShowHints => false;

    /// <inheritdoc />
    public override void Register()
    {
        model = GetDefaultRoundSetModel();

        for (var i = 0; i < model.rounds.Count; i++)
        {
            try
            {
                ModifyRoundModels(model.rounds[i], i + 1);

                switch (i)
                {
                    case < 40:
                        ModifyEasyRoundModels(model.rounds[i], i + 1);
                        break;
                    case < 60:
                        ModifyMediumRoundModels(model.rounds[i], i + 1);
                        break;
                    case < 80:
                        ModifyHardRoundModels(model.rounds[i], i + 1);
                        break;
                    case < 100:
                        ModifyImpoppableRoundModels(model.rounds[i], i + 1);
                        break;
                }
            }
            catch (Exception)
            {
                ModHelper.Error($"Failed to modify round {i + 1} for round set {Id}");
                throw;
            }
        }

        model.GenerateDescendentNames();

        try
        {
            GameData.Instance.roundSets = GameData.Instance.roundSets.AddTo(model);
            // Game.instance.model.roundSetsByName[Id] = model;
            Game.instance.model.AddChildDependant(model);
            Cache[Id] = this;
        }
        finally
        {
            rollbackActions.Push(() =>
            {
                GameData.Instance.roundSets = GameData.Instance.roundSets.RemoveItem(model);
                // Game.instance.model.roundSetsByName.Remove(Id);
                Game.instance.model.RemoveChildDependant(model);
            });
        }

    }

    /// <summary>
    /// Called to modify any/all rounds from 1 to <see cref="DefinedRounds" />
    /// </summary>
    public virtual void ModifyRoundModels(RoundModel roundModel, int round)
    {
    }

    /// <summary>
    /// Called to modify specifically just rounds from 1 to 40
    /// </summary>
    public virtual void ModifyEasyRoundModels(RoundModel roundModel, int round)
    {
    }

    /// <summary>
    /// Called to modify specifically just rounds from 41 to 60
    /// </summary>
    public virtual void ModifyMediumRoundModels(RoundModel roundModel, int round)
    {
    }

    /// <summary>
    /// Called to modify specifically just rounds from 61 to 80
    /// </summary>
    public virtual void ModifyHardRoundModels(RoundModel roundModel, int round)
    {
    }

    /// <summary>
    /// Called to modify specifically just rounds from 81 to 100
    /// </summary>
    public virtual void ModifyImpoppableRoundModels(RoundModel roundModel, int round)
    {
    }

    /// <summary>
    /// Gets the custom hint for a specific round. This will be shown at the <b>end</b> of that round.
    /// <br />
    /// For no hint, return null.
    /// </summary>
    public virtual string GetHint(int round) => null;

    /// <summary>
    /// Modifies the GameModel that's used for matches played with this round set
    /// </summary>
    /// <param name="gameModel"></param>
    public virtual void ModifyGameModel(GameModel gameModel)
    {

    }

    internal RoundSetModel GetDefaultRoundSetModel()
    {
        var roundSetModel = new RoundSetModel(Id, new Il2CppReferenceArray<RoundModel>(DefinedRounds), "");

        var baseRounds = BaseRounds;
        for (var i = 0; i < DefinedRounds; i++)
        {
            roundSetModel.rounds[i] = i < baseRounds.Count
                ? baseRounds[i].Duplicate()
                : new RoundModel("", new Il2CppReferenceArray<BloonGroupModel>(0));
            roundSetModel.rounds[i].emissions_ = null;
        }

        return roundSetModel;
    }
}