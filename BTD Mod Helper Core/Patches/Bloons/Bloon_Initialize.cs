using Assets.Scripts.Models;
using Assets.Scripts.Models.Bloons;
using Assets.Scripts.Simulation.Bloons;
using Assets.Scripts.Unity.Bridge;
using Assets.Scripts.Unity.UI_New.InGame;
using BTD_Mod_Helper.Extensions;
using Harmony;

namespace BTD_Mod_Helper.Patches.Bloons
{
    [HarmonyPatch(typeof(Bloon), nameof(Bloon.Initialise))]
    internal class Bloon_Initialize
    {
        [HarmonyPrefix]
        internal static bool Prefix(Bloon __instance, Model modelToUse)
        {
            SessionData.bloonTracker.TrackBloon(__instance);

            // Creating new BloonToSimulation will automatically start Tracking BloonSim via the Constructor
            new BloonToSimulation(InGame.instance.GetUnityToSimulation(), __instance.Id, new UnityEngine.Vector3(), modelToUse.Cast<BloonModel>());
            return true;
        }

        [HarmonyPostfix]
        internal static void Postfix(Bloon __instance)
        {
            MelonMain.DoPatchMethods(mod => mod.OnBloonCreated(__instance));
        }
    }
}