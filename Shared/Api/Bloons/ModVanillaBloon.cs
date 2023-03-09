using System.Collections.Generic;
using System.Linq;
using BTD_Mod_Helper.Api.Towers;
using Il2CppAssets.Scripts.Models;
using Il2CppAssets.Scripts.Models.Bloons;
namespace BTD_Mod_Helper.Api.Bloons;

/// <summary>
/// Allows you to easily modify the models of a specific vanilla Bloon
/// </summary>
public abstract class ModVanillaBloon : ModVanillaContent<BloonModel>
{
    /// <summary>
    /// The id of the vanilla Bloon to change
    /// </summary>
    public abstract string BloonId { get; }

    /// <summary>
    /// Whether this should match by BaseId instead of Id.
    /// <br/>
    /// If true, RedCamo would be affected as well if your <see cref="BloonId"/> was Red
    /// </summary>
    public virtual bool MatchBaseId => false;
    
    /// <summary>
    /// Gets the BloonModels affected by this ModVanillaBloon
    /// </summary>
    /// <param name="gameModel"></param>
    public override IEnumerable<BloonModel> GetAffected(GameModel gameModel)
    {
        if (MatchBaseId)
        {
            foreach (var bloonModel in gameModel.bloons.Where(model => model.GetBaseID() == BloonId))
            {
                yield return bloonModel;
            }
        }
        else yield return gameModel.GetBloon(BloonId);
    }
}