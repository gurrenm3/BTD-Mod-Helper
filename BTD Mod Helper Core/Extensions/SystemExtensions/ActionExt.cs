using System;

namespace BTD_Mod_Helper.Extensions
{
    public static class ActionExt
    {
        public static Il2CppSystem.Action ToIl2CppSystemAction(this Action action)
        {
            return (Il2CppSystem.Action)action;
        }
    }
}