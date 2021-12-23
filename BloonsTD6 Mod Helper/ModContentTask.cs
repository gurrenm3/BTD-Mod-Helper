using System;
using System.Linq;
using BTD_Mod_Helper.Api;
using MelonLoader;

namespace BTD_Mod_Helper
{
    /// <summary>
    /// Initial task to register ModContent from other mods
    /// </summary>
    public class ModContentTask : ModLoadTask
    {
        /// <inheritdoc />
        public override string DisplayName => "Registering ModContent...";

        /// <summary>
        /// Registers ModContent from other mods
        /// </summary>
        public override void Perform()
        {
            MelonLogger.Msg("Registering ModContent...");
            foreach (var bloonsMod in MelonHandler.Mods.OfType<BloonsMod>().OrderByDescending(bloonsMod => bloonsMod.Priority))
            {
                try
                {
                    RegisterModContent(bloonsMod);
                }
                catch (Exception e)
                {
                    MelonLogger.Error("Critical failure when registering content for mod " + bloonsMod.Info.Name);
                    MelonLogger.Error(e);
                }
            }
        }
    }
}