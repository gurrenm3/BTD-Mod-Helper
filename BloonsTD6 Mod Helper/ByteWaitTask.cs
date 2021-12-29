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
    internal class ByteWaitTask : ModLoadTask
    {
        /// <inheritdoc />
        public override string DisplayName => "Waiting for ByteLoaders...";

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
            while (!ModByteLoader.loadedAllBytes)
            {
                yield return true;
            }
        }
    }
}