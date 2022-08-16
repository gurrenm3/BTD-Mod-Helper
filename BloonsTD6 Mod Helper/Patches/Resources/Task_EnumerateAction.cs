using Assets.Scripts.Unity.Tasks;

using BTD_Mod_Helper.Api;

namespace BTD_Mod_Helper.Patches.Resources;

[HarmonyPatch(typeof(Task._EnumerateAction_d__11), nameof(Task._EnumerateAction_d__11.MoveNext))]
internal static class Task_EnumerateAction {
    [HarmonyPrefix]
    private static bool Prefix(Task._EnumerateAction_d__11 __instance, ref bool __result) {
        if (ModLoadTask.Cache.TryGetValue(__instance.WorkAction.GetHashCode(), out var loadTask)) {
            __result = true;
            if (__instance.__1__state == 0) {
                __instance.__1__state = 1;
                loadTask.iEnumerator = loadTask.Coroutine();
            } else if (!loadTask.iEnumerator.MoveNext()) {
                __instance.__1__state = -1;
                __instance.__4__this.Resolve();
                __result = false;
            }

            return false;
        }

        return true;
    }
}