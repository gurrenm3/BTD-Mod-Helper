using Assets.Scripts.Unity;
using Assets.Scripts.Unity.UI_New.InGame;
using BTD_Mod_Helper.Api;
using BTD_Mod_Helper.Api.InGame_Mod_Options;
using MelonLoader;
using System;
using System.Reflection;
using UnityEngine;
using BTD_Mod_Helper.Extensions;
using System.IO;
using Assets.Scripts.Unity.Bridge;
using Assets.Scripts.Simulation.Towers;
using Assets.Scripts.Simulation.Behaviors;

namespace BTD_Mod_Helper
{
    internal class MelonMain : MelonMod
    {
        internal static string modDir = $"{Environment.CurrentDirectory}\\Mods\\{Assembly.GetExecutingAssembly().GetName().Name}";

        private bool useModOptionsDEBUG = false;
        private ModOptionsMenu modOptionsUI;

        public override void OnApplicationStart()
        {
            MelonLogger.Log("Mod has finished loading");
        }

        public override void OnUpdate()
        {
            if (Game.instance is null)
                return;

            // used to test new api methods
            if (Input.GetKeyDown(KeyCode.RightArrow))
            {
                
            }

            if (useModOptionsDEBUG && modOptionsUI is null)
                modOptionsUI = new ModOptionsMenu();

            NotificationMgr.CheckForNotifications();
        }
    }
}