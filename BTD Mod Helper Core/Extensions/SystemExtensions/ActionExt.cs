using System;

namespace BTD_Mod_Helper.Extensions
{
    public static class ActionExt
    {
        /// <summary>
        /// (Cross-Game compatible) Return this as a System.Action
        /// </summary>
        /// <param name="action"></param>
        /// <returns></returns>
        public static Il2CppSystem.Action ToIl2CppSystemAction(this Action action)
        {
            return (Il2CppSystem.Action)action;
        }
    }
}