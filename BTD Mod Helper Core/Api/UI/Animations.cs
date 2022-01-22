using UnityEngine;

namespace BTD_Mod_Helper.Api
{
    /// <summary>
    /// Class to statically store RuntimeAnimationControllers for different animations
    /// </summary>
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
        
        /// <summary>
        /// Animation for popping upwards
        /// </summary>
        public static RuntimeAnimatorController PopUpwards { get; internal set; }
    }
}