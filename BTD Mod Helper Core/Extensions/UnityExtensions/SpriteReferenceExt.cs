using Assets.Scripts.Utils;

namespace BTD_Mod_Helper.Extensions
{
    public static class SpriteReferenceExt
    {
        /// <summary>
        /// (Cross-Game compatible) Returns's the GUID of this SpriteReference
        /// </summary>
        /// <param name="spriteReference"></param>
        /// <returns></returns>
        public static string GetGUID(this SpriteReference spriteReference)
        {
#if BloonsTD6
            return spriteReference.GUID;
#elif BloonsAT
            return spriteReference.Guid;
#endif
        }
    }
}
