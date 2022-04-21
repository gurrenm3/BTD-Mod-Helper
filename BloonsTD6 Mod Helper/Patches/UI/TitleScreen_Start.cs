using System;
using System.Linq;
using Assets.Main.Scenes;
using Assets.Scripts.Data;
using Assets.Scripts.Data.Global;
using Assets.Scripts.Models.TowerSets.Mods;
using Assets.Scripts.Unity;
using BTD_Mod_Helper.Api;
using BTD_Mod_Helper.Api.Towers;
using BTD_Mod_Helper.Extensions;
using HarmonyLib;

namespace BTD_Mod_Helper.Patches.UI
{
    [HarmonyPatch(typeof(TitleScreen), nameof(TitleScreen.Start))]
    internal class TitleScreen_Start
    {
        [HarmonyPostfix]
        [HarmonyPriority(Priority.High)]
        internal static void Postfix()
        {
            /*foreach (var mod in ModHelper.Mods.OrderByDescending(mod => mod.Priority))
            {
                try
                {
                    ModContent.RegisterModContent(mod);
                }
                catch (Exception e)
                {
                    ModHelper.Error("Critical failure when registering content for mod " + mod.Info.Name);
                    ModHelper.Error(e);
                }
            }*/

            ModHelper.PerformHook(mod => mod.OnTitleScreen());

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
            
            foreach (var modHero in ModContent.GetContent<ModHero>())
            {
                try
                {
                    var heroSprites = GameData.Instance.heroSprites;
                    heroSprites.heroSprite.Add(new HeroSprite
                    {
                        heroId = modHero.Id,
                        heroFontMaterial = heroSprites.GetFontMaterialRef(modHero.NameStyle),
                        backgroundBanner = heroSprites.GetBannerRef(modHero.GlowStyle),
                        backgroundColourTintOverride = heroSprites.GetBannerColourTintRef(modHero.BackgroundStyle)
                    });
                }
                catch (Exception e)
                {
                    ModHelper.Error(e);
                }
            }
            
        }
    }
}