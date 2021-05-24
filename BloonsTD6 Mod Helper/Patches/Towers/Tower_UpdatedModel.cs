using Assets.Scripts.Models;
using Assets.Scripts.Simulation.Factory;
using Assets.Scripts.Simulation.Objects;
using Assets.Scripts.Simulation.SMath;
using Assets.Scripts.Simulation.Towers;
using Assets.Scripts.Utils;
using BTD_Mod_Helper.Api.Towers;
using BTD_Mod_Helper.Extensions;
using Harmony;
using MelonLoader;
using UnhollowerBaseLib;

namespace BTD_Mod_Helper.Patches.Towers
{

    [HarmonyPatch(typeof(Tower), nameof(Tower.UpdatedModel))]
    internal class Tower_UpdatedModel
    {
        [HarmonyPostfix]
        internal static void Postfix(Tower __instance, Model modelToUse)
        {
            MelonMain.DoPatchMethods(mod => mod.OnTowerModelChanged(__instance, modelToUse));
        }
    }















}