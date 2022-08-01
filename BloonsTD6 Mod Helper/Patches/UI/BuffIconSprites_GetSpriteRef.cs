using Assets.Scripts.Data.Global;
using Assets.Scripts.Utils;
using BTD_Mod_Helper.Api.Display;

namespace BTD_Mod_Helper.Patches.UI;

[HarmonyPatch(typeof(BuffIconSprites), nameof(BuffIconSprites.GetSpriteRef))]
internal static class BuffIconSprites_GetSpriteRef
{
    [HarmonyPrefix]
    private static bool Prefix(string buffId, ref SpriteReference __result)
    {
        if (ModBuffIcon.CustomBuffIcons.TryGetValue(buffId, out var spriteReference))
        {
            __result = spriteReference;
            return false;
        }
        
        return true;
    }
}