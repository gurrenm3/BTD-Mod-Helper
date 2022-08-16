using System;
namespace BTD_Mod_Helper.Api.Helpers;

internal static class MelonLoaderChecker {
    public static bool IsVersionNewEnough() {
        try {
            SaySomethingOnlyTheRealMelonLoaderWouldKnow();
            return true;
        } catch (Exception) {
            return false;
        }
    }

    private static void SaySomethingOnlyTheRealMelonLoaderWouldKnow() {
        try {
            // ReSharper disable once ReturnValueOfPureMethodIsNotUsed
            MelonMod.RegisteredMelons.ToArray();
        } catch (Exception) {
            // ignored
        }
    }

}