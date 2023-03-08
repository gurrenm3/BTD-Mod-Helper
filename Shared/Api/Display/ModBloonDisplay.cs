using BTD_Mod_Helper.Api.Bloons;
using Il2CppAssets.Scripts.Unity;
namespace BTD_Mod_Helper.Api.Display;

/// <summary>
/// A ModDisplay that will automatically apply to a ModBloon
/// </summary>
public abstract class ModBloonDisplay : ModDisplay
{
    /// <inheritdoc />
    public override void Register()
    {
        base.Register();
        Bloon.displays.Add(this);
    }

    /// <summary>
    /// The ModBloon that this ModDisplay is used for
    /// </summary>
    public abstract ModBloon Bloon { get; }

    /// <summary>
    /// How damaged the Bloon is, higher numbers = use when more damaged
    /// </summary>
    public virtual int Damage => 0;

    /// <summary>
    /// Gets the display used by the given Bloon, optionally at a particular damage amount
    /// </summary>
    /// <param name="bloonId"></param>
    /// <param name="damagedAmount"></param>
    /// <returns></returns>
    protected static string GetBloonDisplay(string bloonId, int damagedAmount = 0)
    {
        var bloonModel = Game.instance.model.GetBloon(bloonId);
        if (damagedAmount == 0)
        {
            return bloonModel.GetDisplayGUID();
        }

        var damageStateModels = bloonModel.damageDisplayStates;
        return damageStateModels[damagedAmount - 1].displayPath.GUID;
    }
}

/// <summary>
/// A convenient generic class for applying a ModBloonDisplay to a ModBloon
/// </summary>
public abstract class ModBloonDisplay<T> : ModBloonDisplay where T : ModBloon
{
    /// <inheritdoc />
    public override ModBloon Bloon => GetInstance<T>();
}