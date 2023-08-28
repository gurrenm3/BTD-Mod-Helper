using System.Collections.Generic;
using BTD_Mod_Helper.Api.Bloons;
using BTD_Mod_Helper.Api.Bloons.Bosses;
using Il2CppAssets.Scripts.Models.GenericBehaviors;
using Il2CppAssets.Scripts.Unity;
namespace BTD_Mod_Helper.Api.Display;

/// <summary>
/// A ModDisplay that will automatically apply to a ModBloon
/// </summary>
public abstract class ModBossTierDisplay : ModBloonDisplay
{
    /// <summary>
    /// The ModBloon that this ModDisplay is used for, you can get it by doing ModContent.GetInstance();
    /// </summary>
    public abstract ModBoss Boss { get; }

    /// <inheritdoc />
    public sealed override ModBloon Bloon => Boss;

    /// <summary>
    /// The tiers of the boss that this display is used for
    /// </summary>
    public abstract IEnumerable<int> Tiers { get; }

    /// <inheritdoc />
    public override void Register()
    {
        Cache[Id] = this;
        Boss.displays.Add(this);
    }
}

/// <summary>
/// A convenient generic class for applying a ModBloonDisplay to a ModBloon
/// </summary>
public abstract class ModBossTierDisplay<T> : ModBossTierDisplay where T : ModBoss
{
    /// <inheritdoc />
    public override ModBoss Boss => GetInstance<T>();
}
