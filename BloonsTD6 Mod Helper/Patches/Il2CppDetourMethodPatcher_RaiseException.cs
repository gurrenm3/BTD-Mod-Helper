using System;
using System.Collections.Generic;
using System.Reflection;
namespace BTD_Mod_Helper.Patches;

[HarmonyPatch]
internal static class Il2CppDetourMethodPatcher_RaiseException
{
    private static IEnumerable<MethodBase> TargetMethods()
    {
        yield return AccessTools.Method(Type.GetType("Il2CppInterop.HarmonySupport.Il2CppDetourMethodPatcher,Il2CppInterop.HarmonySupport"), "ReportException");
    }
    
    [HarmonyPostfix]
    private static void Postfix(Exception ex)
    {
        ModHelper.Error(ex);
    }
}