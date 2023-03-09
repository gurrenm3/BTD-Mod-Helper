using System;
using System.Collections.Generic;
using Il2CppAssets.Scripts.Models;
using Il2CppAssets.Scripts.Models.Towers.Mods;
using Il2CppAssets.Scripts.Unity;
using Il2CppAssets.Scripts.Utils;
namespace BTD_Mod_Helper.Api.Scenarios;

/// <summary>
/// Class for a custom GameMode that will be added to the modes screen when starting a new match
/// </summary>
public abstract class ModGameMode : NamedModContent
{
    internal static readonly Dictionary<string, ModGameMode> Cache = new();

    /// <summary>
    /// Registers after Round Sets
    /// </summary>
    /// <exclude/>
    protected override float RegistrationPriority => 10;

    /// <inheritdoc />
    public sealed override string DisplayNamePlural => base.DisplayNamePlural;

    /// <summary>
    /// Where this Mode should show up within the Mode Select screen. Use DifficultyType.[name]
    /// </summary>
    public abstract string Difficulty { get; }

    /// <summary>
    /// The id of the existing GameMode to use as a base. Use GameModeType.[name]
    /// If this GameModeType.None, empty, or null, then an empty base will be used
    /// </summary>
    public abstract string BaseGameMode { get; }

    /// <summary>
    /// Whether this GameMode ...
    /// </summary>
    protected virtual bool PreApplies => false;

    /// <summary>
    /// The Icon for the Button for this Mode within the UI, by default looking for the same name as the file
    /// </summary>
    public virtual string Icon => GetType().Name;

    /// <summary>
    /// If you're not going to use a custom .png for your Icon, use this to directly control its SpriteReference
    /// </summary>
    public virtual SpriteReference IconReference => GetSpriteReferenceOrDefault(Icon);

    /// <inheritdoc />
    public override void RegisterText(Il2CppSystem.Collections.Generic.Dictionary<string, string> textTable)
    {
        textTable["Mode " + Id] = DisplayName;
    }

    /// <summary>
    /// Implemented by a ModGameMode to modify the base game mode, for instance by adding or removing mutator mods
    /// </summary>
    public abstract void ModifyBaseGameModeModel(ModModel gameModeModel);

    /// <inheritdoc />
    public override void Register()
    {
        model = GetDefaultGameModeModel();

        try
        {
            ModifyBaseGameModeModel(model);
        }
        catch (Exception)
        {
            ModHelper.Error($"Failed to modify base GameMode for {Id}");
            throw;
        }
        
        model.GenerateDescendentNames();

        try
        {
            Game.instance.model.mods = Game.instance.model.mods.AddTo(model);
            Game.instance.model.AddChildDependant(model);
            Cache[Id] = this;
        }
        finally
        {
            rollbackActions.Push(() =>
            {
                Game.instance.model.mods = Game.instance.model.mods.RemoveItem(model);
                Game.instance.model.RemoveChildDependant(model);
            });
        }
    }

    internal ModModel model;

    internal ModModel GetDefaultGameModeModel()
    {
        ModModel modModel;
        if (string.IsNullOrEmpty(BaseGameMode))
        {
            modModel = new ModModel(Id, new[] {Id}, new Il2CppReferenceArray<MutatorModModel>(0), PreApplies);
        }
        else
        {
            modModel = Game.instance.model.GetModModel(BaseGameMode).Duplicate();
            modModel.toggles = new[] {Id};
            modModel.preApplies = PreApplies;

            foreach (var mutator in modModel.mutatorMods)
            {
                mutator.name = mutator.name = mutator.name.Replace(modModel.name, Id);
            }
        }

        modModel.name = modModel._name = Id;

        return modModel;
    }

    /// <summary>
    /// Modifies the GameModel that's used for matches played with this mode
    /// </summary>
    /// <param name="gameModel"></param>
    public virtual void ModifyGameModel(GameModel gameModel)
    {

    }
}