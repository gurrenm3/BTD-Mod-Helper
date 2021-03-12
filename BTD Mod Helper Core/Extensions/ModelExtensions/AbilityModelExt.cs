using Assets.Scripts.Models.Towers.Behaviors.Abilities;
using Assets.Scripts.Unity.Bridge;
using Assets.Scripts.Unity.UI_New.InGame;
using System.Collections.Generic;
using System.Linq;

namespace BTD_Mod_Helper.Extensions
{
    public static class AbilityModelExt
    {
        /// <summary>
        /// Get the all AbilityToSimulation with this AbilityModel
        /// </summary>
        /// <param name="abiltyModel"></param>
        /// <returns></returns>
        public static List<AbilityToSimulation> GetAbilitySims(this AbilityModel abiltyModel)
        {
            var abilities = InGame.instance?.GetAbilities();
            return abilities.Where(sim => sim.ability.abilityModel.IsEqual(abiltyModel)).ToList();
        }
    }
}
