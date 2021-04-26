using Assets.Scripts.Models;
using Assets.Scripts.Models.Towers.Mods;
using BTD_Mod_Helper.Extensions;
using Harmony;
using Il2CppSystem.Collections.Generic;
using MelonLoader;

namespace BTD_Mod_Helper.Patches
{
    [HarmonyPatch(typeof(GameModel), nameof(GameModel.CreateModded), typeof(GameModel), typeof(List<ModModel>))]
    internal class GameModel_CreateModded
    {
        [HarmonyPostfix]
        internal static void Postfix(GameModel result, List<ModModel> mods)
        {
            MelonMain.DoPatchMethods(mod => mod.OnNewGameModel(result, mods));
            MelonMain.DoPatchMethods(mod => mod.OnNewGameModel(result));
        }
    }
}