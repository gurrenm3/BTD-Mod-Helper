using Il2CppAssets.Scripts.Unity.Display;
namespace BTD_Mod_Helper.Patches.Resources;

[HarmonyPatch(typeof(Factory), nameof(Factory.DestroyAllActive))]
internal class Factory_DestroyAllActive
{
    [HarmonyPostfix]
    internal static void Postfix(Factory __instance)
    {
        ModHelper.PerformHook(mod => mod.OnGameObjectsReset());
    }
}