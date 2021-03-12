using Assets.Scripts.Models;

namespace BTD_Mod_Helper.Extensions
{
    public static partial class ModelExt
    {
        /// <summary>
        /// Check if model is equal to something else. Untested
        /// </summary>
        /// <param name="model"></param>
        /// <param name="to"></param>
        /// <returns></returns>
        public static bool IsEqual(this Model model, Model to)
        {
            return model == to;
        }
    }
}
