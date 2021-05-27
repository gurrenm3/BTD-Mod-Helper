using System;
using Assets.Scripts.Unity.UI_New.Main;
using BTD_Mod_Helper.Api;
using Harmony;
using System.Collections.Generic;
using System.Linq;
using Assets.Main.Scenes;
using Assets.Scripts.Unity;
using Assets.Scripts.Unity.Localization;
using BTD_Mod_Helper.Api.Towers;
using MelonLoader;

namespace BTD_Mod_Helper.Patches
{
    [HarmonyPatch(typeof(TitleScreen), nameof(TitleScreen.Start))]
    internal class TitleScreen_Start
    {
        [HarmonyPostfix]
        [HarmonyPriority(Priority.High)]
        internal static void Postfix()
        {
            foreach (var mod in MelonHandler.Mods.OfType<BloonsMod>())
            {
                try
                {
                    ResourceHandler.LoadEmbeddedTextures(mod);
                }
                catch (Exception e)
                {
                    MelonLogger.Error("Critical failure when loading resources for mod " + mod.Info.Name);
                    MelonLogger.Error(e);
                }
                
                try
                {
                    ModTowerHandler.LoadTowersAndUpgrades(mod);
                }
                catch (Exception e)
                {
                    MelonLogger.Error("Critical failure when loading Towers/Upgrades for mod " + mod.Info.Name);
                    MelonLogger.Error(e);
                }
            }
            
            MelonMain.DoPatchMethods(mod => mod.OnTitleScreen());
        }
    }
}