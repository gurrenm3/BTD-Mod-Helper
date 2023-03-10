using BTD_Mod_Helper.Api.Bloons;
using Il2CppAssets.Scripts.Models;
using Il2CppAssets.Scripts.Models.Bloons;
using Il2CppAssets.Scripts.Simulation.Bloons;
using Il2CppAssets.Scripts.Unity.UI_New.InGame;
namespace BTD_Mod_Helper.Patches.Bloons;

[HarmonyPatch(typeof(Bloon), nameof(Bloon.Initialise))]
internal class Bloon_Initialize
{

    [HarmonyPrefix]
    internal static bool Prefix(Bloon __instance, Model modelToUse)
    {
        return true;
    }

    [HarmonyPostfix]
    internal static void Postfix(Bloon __instance, Model modelToUse)
    {
        // removed from update 28.0
        //SessionData.Instance.bloonTracker.TrackBloon(__instance);
        // Creating new BloonToSimulation will automatically start Tracking BloonSim via the Constructor
        //__instance.CreateBloonToSim();

        ModHelper.PerformHook(mod => mod.OnBloonCreated(__instance));
        if (ModBoss.Cache.ContainsKey(modelToUse.Cast<BloonModel>().id))
        {
            var boss = ModBoss.Cache[modelToUse.Cast<BloonModel>().id];
            var baseboss = boss.bloonModel;
            var roundboss = boss.ModifyForRound(baseboss, InGame.instance.GetUnityToSimulation().GetCurrentRound()+1);
            __instance.bloonModel = roundboss;
            __instance.UpdateRootModel(roundboss);
            boss.OnSpawn(__instance);
        }
        
        ModHelper.PerformHook(mod => mod.OnBloonModelUpdated(__instance, modelToUse));
    }
}