using System.Collections.Generic;
using System.Linq;
using BTD_Mod_Helper.Api.Towers;
using Il2CppAssets.Scripts.Models;
using Il2CppAssets.Scripts.Models.Bloons;
namespace BTD_Mod_Helper.Api.Bloons;

/// <summary>
/// Allows you to easily modify the models of multiple vanilla Bloons
/// </summary>
public abstract class ModVanillaBloons : ModVanillaContent<BloonModel>
{
    /// <summary>
    /// The ids of the vanilla Bloon to change
    /// </summary>
    public abstract IEnumerable<string> BloonIds { get; }

    /// <summary>
    /// Whether this should match by BaseId instead of Id.
    /// <br/>
    /// If true, RedCamo would be affected as well if your <see cref="BloonIds"/> was Red
    /// </summary>
    public virtual bool MatchBaseId => false;
    
    /// <summary>
    /// Gets the BloonModels affected by this ModVanillaBloons
    /// </summary>
    /// <param name="gameModel"></param>
    public override IEnumerable<BloonModel> GetAffected(GameModel gameModel)
    {
        foreach (var (name, bloon) in gameModel.bloonsByName)
        {
            if (BloonIds.Contains(MatchBaseId ? bloon.baseId : name))
            {
                yield return bloon;
            }
        }
    }
}