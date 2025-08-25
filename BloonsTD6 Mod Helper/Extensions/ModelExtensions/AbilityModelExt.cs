using System.Collections.Generic;
using System.Linq;
using Il2CppAssets.Scripts.Models.Towers.Behaviors.Abilities;
using Il2CppAssets.Scripts.Unity.Bridge;
using Il2CppAssets.Scripts.Unity.UI_New.InGame;
namespace BTD_Mod_Helper.Extensions;

/// <summary>
/// Extensions for AbilityModels
/// </summary>
public static class AbilityModelExt
{
    /// <summary>
    /// Get the all AbilityToSimulation with this AbilityModel
    /// </summary>
    /// <param name="abiltyModel"></param>
    /// <returns></returns>
    public static List<AbilityToSimulation> GetAbilitySims(this AbilityModel abiltyModel)
    {
        if (InGame.instance == null)
        {
            return new List<AbilityToSimulation>();
        }
        var abilities = InGame.instance.GetAbilities();
        return abilities.Where(sim => sim.ability.abilityModel.IsEqual(abiltyModel)).ToList();
    }

    /// <summary>
    /// Gets the effective cooldown of this ability factoring in its <see cref="AbilityModel.CooldownSpeedScale"/>
    /// </summary>
    /// <param name="abiltyModel"></param>
    /// <returns></returns>
    public static float EffectiveCooldown(this AbilityModel abiltyModel) =>
        abiltyModel.Cooldown * (1 - abiltyModel.CooldownSpeedScale);

    /// <summary>
    /// Gets the effective cooldown of this ability factoring in its <see cref="AbilityModel.CooldownSpeedScale"/>
    /// </summary>
    /// <param name="abiltyModel"></param>
    /// <returns></returns>
    public static int EffectiveCooldownFrames(this AbilityModel abiltyModel) =>
        (int) (abiltyModel.cooldownFrames * (1 - abiltyModel.CooldownSpeedScale));
}