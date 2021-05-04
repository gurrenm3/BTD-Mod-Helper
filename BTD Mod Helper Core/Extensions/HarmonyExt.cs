using Harmony;
using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;

namespace BTD_Mod_Helper.Extensions
{
    public static class HarmonyExt
    {
        public static void PatchPrefix(this HarmonyInstance harmonyInstance, Type classToPatch, int constructorIndex, Type myPatchClass, string myPatchMethod)
        {
            var constructor = classToPatch.GetConstructors()[constructorIndex];
            harmonyInstance.Patch(constructor, prefix: new HarmonyMethod(AccessTools.Method(myPatchClass, myPatchMethod)));
        }
        public static void PatchPrefix(this HarmonyInstance harmonyInstance, Type classToPatch, string methodToPatch, Type myPatchClass, string myPatchMethod)
        {
            var methodInfo = classToPatch.GetMethod(methodToPatch);
            harmonyInstance.Patch(methodInfo, prefix: new HarmonyMethod(AccessTools.Method(myPatchClass, myPatchMethod)));
        }
        public static void PatchPrefix(this HarmonyInstance harmonyInstance, MethodInfo methodToPatch, Type myPatchClass, string myPatchMethod)
        {
            harmonyInstance.Patch(methodToPatch, prefix: new HarmonyMethod(AccessTools.Method(myPatchClass, myPatchMethod)));
        }
        public static void PatchPrefix(this HarmonyInstance harmonyInstance, MethodInfo methodToPatch, MethodInfo myPatchMethod)
        {
            harmonyInstance.Patch(methodToPatch, prefix: new HarmonyMethod(myPatchMethod));
        }



        public static void PatchPostfix(this HarmonyInstance harmonyInstance, Type classToPatch, int constructorIndex, Type myPatchClass, string myPatchMethod)
        {
            var constructor = classToPatch.GetConstructors()[constructorIndex];
            harmonyInstance.Patch(constructor, postfix: new HarmonyMethod(AccessTools.Method(myPatchClass, myPatchMethod)));
        }
        public static void PatchPostfix(this HarmonyInstance harmonyInstance, Type classToPatch, string methodToPatch, Type myPatchClass, string myPatchMethod)
        {
            var methodInfo = classToPatch.GetMethod(methodToPatch);
            harmonyInstance.Patch(methodInfo, postfix: new HarmonyMethod(AccessTools.Method(myPatchClass, myPatchMethod)));
        }
        public static void PatchPostfix(this HarmonyInstance harmonyInstance, MethodInfo methodToPatch, Type myPatchClass, string myPatchMethod)
        {
            harmonyInstance.Patch(methodToPatch, postfix: new HarmonyMethod(AccessTools.Method(myPatchClass, myPatchMethod)));
        }
        public static void PatchPostfix(this HarmonyInstance harmonyInstance, MethodInfo methodToPatch, MethodInfo myPatchMethod)
        {
            harmonyInstance.Patch(methodToPatch, postfix: new HarmonyMethod(myPatchMethod));
        }
    }
}
