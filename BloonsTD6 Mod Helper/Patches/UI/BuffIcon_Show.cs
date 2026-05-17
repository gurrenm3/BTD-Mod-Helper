using Il2CppAssets.Scripts.Simulation;
using Il2CppAssets.Scripts.Unity.UI_New.InGame;

namespace BTD_Mod_Helper.Patches.UI;

[HarmonyPatch(typeof(BuffIcon), nameof(BuffIcon.Show))]
internal static class BuffIcon_Show
{
    [HarmonyPrefix]
    private static void Prefix(BuffQuery buff)
    {
        if (buff.timedMutator?.mutator?.TryGetModMutator(out var modMutator) == true &&
            modMutator.OverrideStackCount)
        {
            buff.availableBuffCount = modMutator.StackCount(modMutator.GetData(buff.timedMutator.mutator));
        }
    }
}