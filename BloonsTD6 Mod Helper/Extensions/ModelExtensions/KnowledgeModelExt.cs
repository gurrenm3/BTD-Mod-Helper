using Assets.Scripts.Models.Towers.Knowledge;
using Assets.Scripts.Unity;
using BTD_Mod_Helper.Extensions;

namespace BloonsTD6_Mod_Helper.Extensions
{
	public static class KnowledgeModelExt
	{
		/// <summary>
		/// Returns the KnowledgeSetModel that contains this KnowledgeModel
		/// </summary>
		/// <param name="knowledgeModel"></param>
		/// <returns></returns>
		public static KnowledgeSetModel GetKnowledgeSet(this KnowledgeModel knowledgeModel)
		{
			var sets = Game.instance?.model?.knowledgeSets;
			if (sets is null || sets.Length == 0)
				return null;

			foreach (var set in sets)
            {
				if (set.ContainsKnowledgeModel(knowledgeModel))
					return set;
            }

			return null;
		}
	}
}