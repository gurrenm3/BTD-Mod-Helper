using Il2CppAssets.Scripts.Models;
using Il2CppAssets.Scripts.Models.Store.Loot;
using Il2CppAssets.Scripts.Unity;
using UnityEngine;
using static Il2CppAssets.Scripts.Models.Towers.TowerType;
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
        BananaFarm, SpikeFactory, MonkeyVillage, EngineerMonkey
    };

    [HarmonyPrefix]
    private static void Prefix(RandomInstaMonkeyLoot __instance)
    {
        if (string.IsNullOrEmpty(__instance.fixedBaseTower))
        {
            __instance.fixedBaseTower = VanillaTowers[Random.RandomRangeInt(0, VanillaTowers.Length)];
        }
    }
}