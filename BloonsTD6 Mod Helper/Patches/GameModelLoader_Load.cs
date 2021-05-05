using Assets.Scripts.Models;
using Harmony;

namespace BTD_Mod_Helper.Patches
{
    [HarmonyPatch(typeof(GameModelLoader), nameof(GameModelLoader.Load))]
    internal class GameModelLoader_Load
    {
        [HarmonyPostfix]
        internal static void Postfix(GameModel __result)
        {
            MelonMain.DoPatchMethods(mod => mod.OnGameModelLoaded(__result));
        }
    }
}
