using System;
using System.Collections.Generic;
using MelonLoader;

namespace BTD_Mod_Helper.Api.Display
{
#if BloonsTD6
    internal static class ModDisplayHandler
    {
        internal static readonly Dictionary<string, ModDisplay> ModDisplays = new Dictionary<string, ModDisplay>();

        internal static void LoadModDisplays(List<ModDisplay> modDisplays)
        {
            foreach (var modDisplay in modDisplays)
            {
                if (modDisplay is ModTowerDisplay modTowerDisplay)
                {
                    try
                    {
                        modTowerDisplay.Tower.displays.Add(modTowerDisplay);
                    }
                    catch (Exception e)
                    {
                        MelonLogger.Error(
                            $"Failed to assign ModTowerDisplay {modTowerDisplay.Name} to ModTower {modTowerDisplay.Tower.Name}");
                        MelonLogger.Error(e);
                    }
                }

                ModDisplays[modDisplay.Id] = modDisplay;
            }
        }
    }
#endif
}