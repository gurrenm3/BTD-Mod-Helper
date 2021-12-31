using System.Linq;
using Assets.Scripts.Unity;
using BTD_Mod_Helper.Api;
using BTD_Mod_Helper.Extensions;
using Il2CppSystem;
using MelonLoader;
using Exception = System.Exception;

namespace BTD_Mod_Helper
{
    /// <summary>
    /// Catch-all class for non-extension static methods that modders would find useful
    /// </summary>
    public static class ModHelper
    {
        /// <summary>
        /// The current version of the Mod. GitHub Release tags must match this exactly.
        /// </summary>
        public const string CurrentVersion = "3.0.0";

        /// <inheritdoc cref="ModByteLoader.Generate{T}"/>
        public static void GenerateByteLoader<T>(T model, string loaderFilePath, string bytesFilePath) where T : Object
        {
            ModByteLoader.Generate(model, loaderFilePath, bytesFilePath);
        }


        internal static BloonsMod Main => ModContent.GetInstance<MelonMain>();

        private static void PerformHook<T>(System.Action<T> action) where T : BloonsMod
        {
            foreach (var mod in MelonHandler.Mods.OfType<T>().OrderByDescending(mod => mod.Priority))
            {
                if (!mod.CheatMod || !Game.instance.CanGetFlagged())
                {
                    try
                    {
                        action.Invoke(mod);
                    }
                    catch (Exception e)
                    {
                        MelonLogger.Error(e);
                    }
                }
            }
        }

#if BloonsTD6
        internal static void PerformHook(System.Action<BloonsTD6Mod> action)
        {
            PerformHook<BloonsTD6Mod>(action);
        }
#elif BloonsAT
        internal static void PerformHook(System.Action<BloonsATMod> action)
        {
            PerformHook<BloonsATMod>(action);
        }
#endif
    }
}