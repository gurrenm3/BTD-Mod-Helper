using System;
using System.Linq;
using Assets.Main.Scenes;
using Assets.Scripts.Data;
using Assets.Scripts.Data.Global;
using Assets.Scripts.Models.GenericBehaviors;
using Assets.Scripts.Models.TowerSets.Mods;
using Assets.Scripts.Unity;
using BTD_Mod_Helper.Api;
using BTD_Mod_Helper.Api.Display;
using BTD_Mod_Helper.Api.Towers;
using UnhollowerBaseLib;
using UnhollowerRuntimeLib;
using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.AddressableAssets.ResourceLocators;
using UnityEngine.ResourceManagement.ResourceLocations;
using UnityEngine.U2D;

namespace BTD_Mod_Helper.Patches.UI;

[HarmonyPatch(typeof(TitleScreen), nameof(TitleScreen.Start))]
internal class TitleScreen_Start
{
    [HarmonyPostfix]
    [HarmonyPriority(Priority.High)]
    internal static void Postfix()
    {
        if (ModHelper.FallbackToOldLoading)
        {
            ModContent.GetContent<ModByteLoader>().Do(loader => loader.LoadAllBytes());

            new PreLoadResourcesTask().RunSync();

            ModHelper.Mods
                .Where(mod => mod.Content.Count > 0)
                .OrderBy(mod => mod.Priority)
                .Select(mod => new ModContentTask {mod = mod})
                .Do(task => task.RunSync());

            ModContent.GetContent<ModLoadTask>().Do(task => task.RunSync());
        }


        foreach (var modParagonTower in ModContent.GetContent<ModVanillaParagon>())
        {
            modParagonTower.AddUpgradesToRealTowers();
        }

        foreach (var modelMod in Game.instance.model.mods)
        {
            if (modelMod.name.EndsWith("Only"))
            {
                var mutatorModModels = modelMod.mutatorMods.ToList();
                mutatorModModels.AddRange(ModContent.GetContent<ModTowerSet>()
                    .Where(set => !set.AllowInRestrictedModes)
                    .Select(set => new LockTowerSetModModel(modelMod.name, set.Id)));
                modelMod.mutatorMods = mutatorModModels.ToIl2CppReferenceArray();
            }
        }

        ModHelper.PerformHook(mod => mod.OnTitleScreen());
    }
}