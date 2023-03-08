using System.Collections.Generic;
using Il2CppAssets.Scripts.Models;
using Il2CppAssets.Scripts.Unity;
namespace BTD_Mod_Helper.Api.Towers;

/// <summary>
/// Class for changing Vanilla content within the game
/// </summary>
public abstract class ModVanillaContent : ModContent
{
    /// <summary>
    /// Whether this should only modify the Towers In-Game, or also affect the default GameModel outside a game
    /// </summary>
    public virtual bool AffectBaseGameModel => false;
        
    /// <inheritdoc />
    public sealed override int RegisterPerFrame => AffectBaseGameModel ? 3 : 10;
        
        
    /// <summary>
    /// Gets the TowerModels that this will affect in the GameModel
    /// </summary>
    /// <param name="gameModel"></param>
    /// <returns></returns>
    public abstract IEnumerable<Model> GetAffectedModels(GameModel gameModel);
        
    /// <inheritdoc />
    public sealed override string Name => base.Name;

    /// <summary>
    /// Change the name of it
    /// </summary>
    public virtual string DisplayName => "";
        
    /// <summary>
    /// Change the description of it
    /// </summary>
    public virtual string Description => "";

    /// <summary>
    /// Applies the modifications to the vanilla content
    /// </summary>
    internal virtual void Apply(Model model)
    {
    }
    
    /// <summary>
    /// Applies the modifications to the vanilla content
    /// </summary>
    internal virtual void Apply(Model model, GameModel gameModel)
    {
    }

    /// <summary>
    /// Whether this should apply or not. Useful for ModSettings
    /// </summary>
    public virtual bool ShouldApply => true;

    /// <inheritdoc />
    public override void Register()
    {
        if (AffectBaseGameModel && ShouldApply)
        {
            var gameModel = Game.instance.model;
            foreach (var affectedModel in GetAffectedModels(gameModel))
            {
                if (affectedModel == null)
                {
                    ModHelper.Warning($"Unable to modify vanilla {TypeName}, found null");
                    break;
                }
                Apply(affectedModel);
                Apply(affectedModel, gameModel);
            }
        }
    }

    internal abstract string TypeName { get; }
}
    
/// <summary>
/// ModContent Class for modifying a certain set of vanilla towers
/// </summary>
public abstract class ModVanillaContent<T> : ModVanillaContent where T : Model
{
    internal override string TypeName => typeof(T).Name;

    /// <inheritdoc />
    public sealed override IEnumerable<Model> GetAffectedModels(GameModel gameModel)
    {
        return GetAffected(gameModel);
    }

    /// <inheritdoc />
    internal override void Apply(Model model)
    {
        Apply(model.Cast<T>());
    }
        
    /// <inheritdoc />
    internal override void Apply(Model model, GameModel gameModel)
    {
        Apply(model.Cast<T>(), gameModel);
    }

    /// <summary>
    /// Gets the TowerModels that this will affect in the GameModel
    /// </summary>
    public abstract IEnumerable<T> GetAffected(GameModel gameModel);

    /// <summary>
    /// Applies the modifications to the vanilla content
    /// </summary>
    public virtual void Apply(T model)
    {
            
    }
        
    /// <summary>
    /// Applies the modifications to the vanilla content
    /// </summary>
    public virtual void Apply(T model, GameModel gameModel)
    {
            
    }

}