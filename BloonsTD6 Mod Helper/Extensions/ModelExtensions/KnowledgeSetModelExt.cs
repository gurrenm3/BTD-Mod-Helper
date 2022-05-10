using Assets.Scripts.Models.Towers.Knowledge;
using System.Collections.Generic;
using System.Linq;

namespace BTD_Mod_Helper.Extensions
{
    public static class KnowledgeSetModelExt
    {
        /// <summary>
        /// Returns whether or not this KnowledgeSetModel contains <paramref name="containsModel"/>
        /// </summary>
        /// <param name="set"></param>
        /// <param name="containsModel"></param>
        /// <returns></returns>
        public static bool ContainsKnowledgeModel(this KnowledgeSetModel set, KnowledgeModel containsModel)
        { 
            if (set.tiers == null) return false;

            List<KnowledgeLevelModel> levels = new List<KnowledgeLevelModel>();
            set.tiers.ForEach(tier => levels.AddRange(tier.levels));
            if (levels.Count == 0) return false;

            List<KnowledgeModel> knowledgeModels = new List<KnowledgeModel>();
            levels.ForEach(level => knowledgeModels.AddRange(level.items));

            return knowledgeModels.Any(model => model.Equals(containsModel));
        }
    }
}
