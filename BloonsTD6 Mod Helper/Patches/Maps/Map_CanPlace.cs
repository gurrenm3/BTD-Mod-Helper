using BTD_Mod_Helper.Api.Towers;
using Il2CppAssets.Scripts.Models.Towers;
using Il2CppAssets.Scripts.Simulation.SMath;
using Il2CppAssets.Scripts.Simulation.Track;
using Il2CppAssets.Scripts.Unity.Bridge;
using Il2CppAssets.Scripts.Unity.UI_New.InGame;

namespace BTD_Mod_Helper.Patches;

[HarmonyPatch(typeof(Map), nameof(Map.CanPlace))]
internal static class Map_CanPlace
{
    [HarmonyPrefix]
    internal static bool Prefix(Vector2 at, TowerModel tm, ref bool __result)
    {
        if (tm.GetModTower() is not ModFakeTower fakeTower) return true;

        var tower = InGame.Bridge.GetSelection(at.ToUnity(), 20).Is(out TowerToSimulation tts) ? tts.tower : null;

        string fake = null;
        __result = fakeTower.CanPlaceAt(at.ToUnity(), tower, ref fake);

        return false;
    }

}