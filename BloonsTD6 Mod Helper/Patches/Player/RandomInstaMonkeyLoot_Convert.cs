using Il2CppAssets.Scripts.Models.Store.Loot;
using UnityEngine;
using static Il2CppAssets.Scripts.Models.Towers.TowerType;
using Il2CppAssets.Scripts.Unity.UI_New.InGame;
namespace BTD_Mod_Helper.Patches;

[HarmonyPatch(typeof(RandomInstaMonkeyLoot), nameof(RandomInstaMonkeyLoot.Convert))]
internal static class RandomInstaMonkeyLoot_Convert
{
    // TODO better way to reliably get vanilla towers without explicitly having to know which are which,
    // and also accounting for ones not added directly by mod helper
    private static readonly string[] VanillaTowers =
    {
        DartMonkey, BoomerangMonkey, BombShooter, TackShooter, IceMonkey, GlueGunner,
        SniperMonkey, MonkeySub, MonkeyBuccaneer, MonkeyAce, HeliPilot, MortarMonkey, DartlingGunner,
        WizardMonkey, SuperMonkey, NinjaMonkey, Alchemist, Druid,
        BananaFarm, SpikeFactory, MonkeyVillage, EngineerMonkey, BeastHandler
    };

    [HarmonyPrefix]
    private static void Prefix(RandomInstaMonkeyLoot __instance)
    {
        if (string.IsNullOrEmpty(__instance.fixedBaseTower))
        {
            if (InGame.instance.GetGameModel().gameMode == "PrimaryOnly")
            {
                __instance.fixedBaseTower = VanillaTowers[Random.RandomRangeInt(0, 6)];
            }
            else if (InGame.instance.GetGameModel().gameMode == "MilitaryOnly")
            {
                __instance.fixedBaseTower = VanillaTowers[Random.RandomRangeInt(7, 13)];
            }
            else if (InGame.instance.GetGameModel().gameMode == "MagicOnly")
            {
                __instance.fixedBaseTower = VanillaTowers[Random.RandomRangeInt(14, 18)];
            }
            else
            {
                __instance.fixedBaseTower = VanillaTowers[Random.RandomRangeInt(0, VanillaTowers.Length)];
            }
        }
    }
}
