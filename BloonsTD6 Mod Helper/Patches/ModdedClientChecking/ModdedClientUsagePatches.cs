using System.Collections.Generic;
using System.Reflection;
using Assets.Scripts.Unity.Player;
using Assets.Scripts.Unity.UI_New.DailyChallenge;
using Assets.Scripts.Unity.UI_New.GameOver;
using Assets.Scripts.Unity.UI_New.InGame;
using Assets.Scripts.Utils;
using BTD_Mod_Helper.Api;

namespace BTD_Mod_Helper.Patches.ModdedClientChecking;

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

        if (MoreAccessTools.TryGetNestedClassMethod(typeof(OnlineProfileManager), "Upload", "MoveNext", out var m))
            yield return m;
        if (MoreAccessTools.TryGetNestedClassMethod(typeof(Btd6Player), "LoadOnlineData", "MoveNext", out m))
            yield return m;
        if (MoreAccessTools.TryGetNestedClassMethod(typeof(BossVictoryScreen), "Open", "MoveNext", out m))
            yield return m;
        if (MoreAccessTools.TryGetNestedClassMethod(typeof(BossEventScreenPlayPanel), "Open", "MoveNext", out m))
            yield return m;
        if (MoreAccessTools.TryGetNestedClassMethod(typeof(BossEventScreen), "Open", "MoveNext", out m))
            yield return m;
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