using Il2CppSystem;
using UnhollowerBaseLib;

namespace BTD_Mod_Helper.Extensions
{
    public static class Il2CppSystemDelegateExxt
    {
        /// <summary>
        /// (Cross-Game compatible) Create a new and seperate copy of this object. Same as using:  .Clone().Cast();
        /// </summary>
        /// <typeparam name="T">Type of object you want to cast to when duplicating. Done automatically</typeparam>
        public static T Duplicate<T>(this Delegate del) where T : Il2CppObjectBase
        {
            return del.Clone().Cast<T>();
        }
    }
}
