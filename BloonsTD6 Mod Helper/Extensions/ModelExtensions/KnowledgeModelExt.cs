using Assets.Scripts.Models.Knowledge;
using Assets.Scripts.Unity;

namespace BTD_Mod_Helper.Extensions
{
	public static class KnowledgeModelExt
	{
		
		/* TODO fix knowledge stuff
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
		*/
		
	}
}