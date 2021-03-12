using Assets.Scripts.Models;

namespace BTD_Mod_Helper.Extensions
{
    public static partial class ModelExt
    {
        public static bool IsEqual(this Model model, Model to)
        {
            return model == to;
        }
    }
}
