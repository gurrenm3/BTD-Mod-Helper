using Assets.Scripts.Models.Bloons.Behaviors;
using Assets.Scripts.Utils;

namespace BTD_Mod_Helper.Api.Bloons
{
    /// <summary>
    /// Provides Utility methods for dealing with BloonModels
    /// </summary>
    public class BloonModelUtils
    {
        /// <summary>
        /// (Cross-Game compatible) Constructs an accurate BloonID for a BloonModel based off of it's statuses.
        /// </summary>
        /// <param name="bloonName"></param>
        /// <param name="camo"></param>
        /// <param name="regrow"></param>
        /// <param name="fortified"></param>
        /// <returns></returns>
        public static string ConstructBloonId(string bloonName, bool camo, bool regrow, bool fortified)
        {
            string baseName = bloonName.Replace("Camo", "").Replace("Regrow", "").Replace("Fortified", "");
#if BloonsTD6
            return BloonTypeUtility.BloonType(baseName, camo, regrow, fortified);
#elif BloonsAT
            throw new NotImplementedException();
            return GameModelUtil.ConstructBloonId(baseName, camo, regrow, fortified);
#endif
        }

        /// <summary>
        /// (Cross-Game compatible) Creates a GrowModel behavior that adds Regrowth.
        /// </summary>
        /// <param name="regrowsTo"></param>
        /// <param name="regrowRate"></param>
        /// <returns></returns>
        public static GrowModel CreateGrowModel(string regrowsTo, float regrowRate)
        {
#if BloonsTD6
            return new GrowModel("GrowModel_", regrowRate, regrowsTo, null);
#elif BloonsAT
            return new GrowModel($"GrowModel_{regrowsTo}", regrowRate);
#endif
        }
    }
}