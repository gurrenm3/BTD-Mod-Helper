using System;
using System.Collections;
using System.Linq;
using BTD_Mod_Helper.Api;
using BTD_Mod_Helper.Extensions;
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
        public override IEnumerator Coroutine()
        {
            foreach (var bloonsMod in MelonHandler.Mods.OfType<BloonsMod>().OrderBy(bloonsMod => bloonsMod.Priority))
            {
                foreach (var modContent in mod.Content)
                {
                    try
                    {
                        modContent.TestRegister();
                    }
                    catch (Exception e)
                    {
                        MelonLogger.Error($"Failed to register {modContent.Name}");
                        MelonLogger.Error(e);
                    }

                    yield return null;
                }

                foreach (var modContent in mod.Content)
                {
                    try
                    {
                        modContent.PostRegister();
                    }
                    catch (Exception e)
                    {
                        MelonLogger.Error($"Failed to post register {modContent.Name}");
                        MelonLogger.Error(e);
                    }
                    yield return null;
                }
                
                yield return null;
            }
        }
    }
}