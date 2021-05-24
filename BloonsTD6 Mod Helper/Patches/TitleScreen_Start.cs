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
            MelonMain.DoPatchMethods(mod => mod.OnTitleScreen());
            
            foreach (var mod in MelonHandler.Mods.OfType<BloonsMod>())
            {
                ResourceHandler.LoadEmbeddedTextures(mod);
                ModTowerHandler.LoadTowersAndUpgrades(mod);
            }
        }
    }
}