using System;
using System.IO;
using System.Reflection;
using System.Linq;
using UnityEngine;
using MelonLoader;
using Assets.Scripts.Unity.UI_New.InGame;
using System.Collections.Generic;
using BTD_Mod_Helper.Api.Updater;
using BTD_Mod_Helper.Api.InGame_Mod_Options;
using BTD_Mod_Helper.Api;
using System.Text;

namespace BTD_Mod_Helper
{
    public class Main : MelonMod
    {
        internal static readonly string modName = Assembly.GetExecutingAssembly().GetName().Name;
        internal static readonly string modDir = $"{Environment.CurrentDirectory}\\Mods\\{modName}";
        internal static readonly string ModSettingsDir = Path.Combine(modDir, "Mod Settings");

        private bool useModOptionsDEBUG = false;
        private ModOptionsMenu modOptionsUI;

        internal readonly List<UpdateInfo> modsNeedingUpdates = new List<UpdateInfo>();


        public override void OnApplicationStart()
        {
            MelonLogger.Msg("Mod has finished loading");
            MelonLogger.Msg("Checking for updates...");

            var updateDir = modDir + "\\UpdateInfo";
            if (!Directory.Exists(updateDir))
            {
                Directory.CreateDirectory(updateDir);
            }

            UpdateHandler.SaveModUpdateInfo(updateDir);
            var allUpdateInfo = UpdateHandler.LoadAllUpdateInfo(updateDir);
            UpdateHandler.CheckForUpdates(allUpdateInfo, modsNeedingUpdates);

            ModSettingsHandler.InitializeModSettings(ModSettingsDir);
            ModSettingsHandler.LoadModSettings(ModSettingsDir);
        }

        public override void OnUpdate()
        {
            foreach (KeyCode key in Enum.GetValues(typeof(KeyCode)))
            {
                if (Input.GetKeyDown(key))
                {
                    DoPatchMethods(mod => mod.OnKeyDown(key));
                }

                if (Input.GetKeyUp(key))
                {
                    DoPatchMethods(mod => mod.OnKeyUp(key));
                }

                if (Input.GetKey(key))
                {
                    DoPatchMethods(mod => mod.OnKeyHeld(key));
                }
            }

            if (InGame.instance is null)
                return;

            if (useModOptionsDEBUG && modOptionsUI is null)
                modOptionsUI = new ModOptionsMenu();

            NotificationMgr.CheckForNotifications();
        }

        public static void DoPatchMethods(Action<BloonsMod> action) => DoPatchMethods(action);

        public static void DoPatchMethods<T>(Action<T> action) where T : BloonsMod
        {
            foreach (var mod in MelonHandler.Mods.OfType<T>())
            {
                action.Invoke(mod);
            }
        }
    }
}
