using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using BTD_Mod_Helper.Api;
using MelonLoader;

namespace BTD_Mod_Helper
{
    /// <summary>
    /// Initial task to register ModContent from other mods
    /// </summary>
    internal class ModContentTask : ModLoadTask
    {
        /// <inheritdoc />
        public override string DisplayName => $"Registering ModContent for {mod.Info.Name}...";

        /// <summary>
        /// Don't load this like a normal task
        /// </summary>
        /// <returns></returns>
        public override IEnumerable<ModContent> Load() => Enumerable.Empty<ModContent>();

        /// <summary>
        /// Registers ModContent from other mods
        /// </summary>
        public override IEnumerator Coroutine()
        {
            var current = 0f;
            foreach (var modContent in mod.Content)
            {
                current += 1f / modContent.RegisterPerFrame;
                if (current >= 1f)
                {
                    current = 0;
                    yield return null;
                }
                try
                {
                    modContent.Register();
                }
                catch (Exception e)
                {
                    MelonLogger.Error($"Failed to register {modContent.Name}");
                    MelonLogger.Error(e);
                }

            }
        }
    }
}