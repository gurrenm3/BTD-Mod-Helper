using BTD_Mod_Helper.Api.Display;
using Il2CppAssets.Scripts.Unity.Display;
namespace BTD_Mod_Helper.Patches.Resources;

[HarmonyPatch(typeof(Factory.__c__DisplayClass21_0), nameof(Factory.__c__DisplayClass21_0._CreateAsync_b__0))]
internal static class Factory_CreateAsync
{
    [HarmonyPrefix]
    private static bool Prefix(Factory.__c__DisplayClass21_0 __instance, ref UnityDisplayNode prototype)
    {
        var factory = __instance.__4__this;
        var prefabReference = __instance.objectId;
        var onComplete = __instance.onComplete;

        if (prototype == null && ModDisplay.Cache.TryGetValue(prefabReference.guidRef, out var modDisplay))
        {
            modDisplay.Create(factory, prefabReference, node => onComplete.Invoke(node));
            return false;
        }

        return true;
    }
}