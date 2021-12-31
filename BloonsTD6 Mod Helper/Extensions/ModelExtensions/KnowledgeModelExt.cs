using System.Linq;
using Assets.Scripts.Models.Towers.Knowledge;
using Assets.Scripts.Unity;

namespace BTD_Mod_Helper.Extensions
{
	/// <summary>
	/// Extensions for KnowledgeModels
	/// </summary>
	public static class KnowledgeModelExt
	{
		/// <summary>
		/// Returns the KnowledgeSetModel that contains this KnowledgeModel
		/// </summary>
		/// <param name="knowledgeModel"></param>
		/// <returns></returns>
		public static KnowledgeSetModel GetKnowledgeSet(this KnowledgeModel knowledgeModel)
		{
			var sets = Game.instance.model?.knowledgeSets;
			if (sets is null || sets.Length == 0)
				return null;

			return sets.FirstOrDefault(set => set.ContainsKnowledgeModel(knowledgeModel));
		}
	}
}