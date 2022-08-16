using System.Collections.Generic;
using System.Linq;

using Assets.Scripts.Models.Towers.Behaviors.Abilities;
using Assets.Scripts.Unity.Bridge;
using Assets.Scripts.Unity.UI_New.InGame;

namespace BTD_Mod_Helper.Extensions;

/// <summary>
/// Extensions for AbilityModels
/// </summary>
public static class AbilityModelExt {
    /// <summary>
    /// Get the all AbilityToSimulation with this AbilityModel
    /// </summary>
    /// <param name="abiltyModel"></param>
    /// <returns></returns>
    public static List<AbilityToSimulation> GetAbilitySims(this AbilityModel abiltyModel) {
        if (InGame.instance == null) {
            return new List<AbilityToSimulation>();
        }
        var abilities = InGame.instance.GetAbilities();
        return abilities.Where(sim => sim.ability.abilityModel.IsEqual(abiltyModel)).ToList();
    }
}