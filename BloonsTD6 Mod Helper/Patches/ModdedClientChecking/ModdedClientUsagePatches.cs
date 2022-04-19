using System.Collections.Generic;
using System.Reflection;
using Assets.Scripts.Unity.Player;
using Assets.Scripts.Unity.UI_New.DailyChallenge;
using Assets.Scripts.Unity.UI_New.GameOver;
using Assets.Scripts.Unity.UI_New.InGame;
using Assets.Scripts.Utils;
using HarmonyLib;

namespace BTD_Mod_Helper.Patches.ModdedClientChecking
{
    [HarmonyPatch]
    internal static class ModdedClientUsagePatches
    {
        private static IEnumerable<MethodBase> TargetMethods()
        {
            yield return AccessTools.Method(typeof(Btd6Player), nameof(Btd6Player.Save));
            yield return AccessTools.Method(typeof(Btd6Player), nameof(Btd6Player.SaveNow));
            yield return AccessTools.Method(typeof(Btd6Player), nameof(Btd6Player.SyncNow));
            yield return AccessTools.Method(typeof(InGame), nameof(InGame.Continue));
            yield return AccessTools.Method(typeof(InGame), nameof(InGame.ContinueFromCheckpoint));
            yield return AccessTools.Method(typeof(InGame), nameof(InGame.CreateMapSave));
            yield return AccessTools.Method(typeof(InGame), nameof(InGame.RoundEnd));
            yield return AccessTools.Method(typeof(InGame), nameof(InGame.OnVictory));
            yield return AccessTools.Method(typeof(OnlineProfileUpdater), nameof(OnlineProfileUpdater.LateUpdate));

            yield return AccessTools.Method(typeof(OnlineProfileManager._Upload_d__13),
                nameof(OnlineProfileManager._Upload_d__13.MoveNext));
            yield return AccessTools.Method(typeof(Btd6Player._LoadOnlineData_d__38),
                nameof(Btd6Player._LoadOnlineData_d__38.MoveNext));
            yield return AccessTools.Method(typeof(BossVictoryScreen._Open_d__24),
                nameof(BossVictoryScreen._Open_d__24.MoveNext));
            yield return AccessTools.Method(typeof(BossEventScreenPlayPanel._Open_d__24),
                nameof(BossEventScreenPlayPanel._Open_d__24.MoveNext));
            yield return AccessTools.Method(typeof(BossEventScreen._Open_d__43),
                nameof(BossEventScreen._Open_d__43.MoveNext));
        }

        [HarmonyPrefix]
        private static void Prefix()
        {
            ModdedClientBypassing.StartBypassingCheck();
        }

        [HarmonyPostfix]
        private static void Postfix()
        {
            ModdedClientBypassing.StopBypassingCheck();
        }
    }
}