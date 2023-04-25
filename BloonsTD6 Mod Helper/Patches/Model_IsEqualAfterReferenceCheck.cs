using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using Il2CppAssets.Scripts.Models;
using Il2CppAssets.Scripts.Models.Towers.Behaviors.Emissions;

namespace BTD_Mod_Helper.Patches;

// This patch fixes a technically harmless but annoying "during invoking..." bug
[HarmonyPatch]
internal class Model_IsEqualAfterReferenceCheck
{
    private static IEnumerable<Type> ModelsNeedingPatches()
    {
        // TODO expand this list with anything else that causes issues
        yield return typeof(SingleEmissionModel);
        yield return typeof(ArcEmissionModel);
    }

    private static IEnumerable<MethodBase> TargetMethods() => ModelsNeedingPatches()
        .Select(type => AccessTools.Method(type, nameof(Model.IsEqualAfterReferenceCheck)));

    internal static bool Prefix(Model __instance, Model to, ref bool __result)
    {
        if (__instance?.GetIl2CppType()?.Name != to?.GetIl2CppType()?.Name)
        {
            __result = false;
            return false;
        }

        return true;
    }
}