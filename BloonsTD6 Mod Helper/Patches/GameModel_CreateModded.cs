using Assets.Scripts.Models;
using Assets.Scripts.Models.Towers.Mods;
using Harmony;
using MelonLoader;

namespace BTD_Mod_Helper.Patches
{
    [HarmonyPatch(typeof(GameModel), nameof(GameModel.CreateModded), typeof(GameModel), typeof(Il2CppSystem.Collections.Generic.List<ModModel>))]
    internal class GameModel_CreateModded
    {
        [HarmonyPostfix]
        internal static void Postfix(GameModel result)
        {
            MelonMain.DoPatchMethods(mod => mod.OnNewGameModel(result));
        }
    }
}