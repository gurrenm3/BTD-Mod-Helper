using UnityEngine;

namespace BTD_Mod_Helper.Api
{
    public static class Animations
    {
        /// <summary>
        /// Button animation for shrinking a bit while pressing
        /// </summary>
        public static RuntimeAnimatorController ButtonAnimation { get; internal set; }

        /// <summary>
        /// Button animation for rising up a bit
        /// </summary>
        public static RuntimeAnimatorController TabAnimation  { get; internal set; }
        
        public static RuntimeAnimatorController PopUpwards { get; internal set; }
    }
}