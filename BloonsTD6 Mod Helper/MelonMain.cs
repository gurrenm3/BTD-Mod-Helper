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
using Assets.Scripts.Models.Towers;

namespace BTD_Mod_Helper
{
    internal class MelonMain : MelonMod
    {
        internal static string modDir = $"{Environment.CurrentDirectory}\\Mods\\{Assembly.GetExecutingAssembly().GetName().Name}";
        public static string coopMessageCode = "BTD6_ModHelper";

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
                var towers = Game.instance.model.towers;
                if (towers[0] is TowerModel towerModel)
                {
                    MelonLogger.Log(towerModel.name);
                }
            }

            foreach (KeyCode key in Enum.GetValues(typeof(KeyCode)))
            {
                if (Input.GetKeyDown(key))
                {
                    DoPatchMethods(mod =>
                    {
                        mod.OnKeyDown(key);
                    });
                }

                if (Input.GetKeyUp(key))
                {
                    DoPatchMethods(mod =>
                    {
                        mod.OnKeyUp(key);
                    });
                }

                if (Input.GetKey(key))
                {
                    DoPatchMethods(mod =>
                    {
                        mod.OnKeyHeld(key);
                    });
                }
            }

            if (InGame.instance is null)
                return;

            
            if (useModOptionsDEBUG && modOptionsUI is null)
                modOptionsUI = new ModOptionsMenu();

            NotificationMgr.CheckForNotifications();
        }
        

        public static void DoPatchMethods(Action<BloonsTD6Mod> action)
        {
            foreach (var melonMod in MelonHandler.Mods)
            {
                if (melonMod is BloonsTD6Mod mod)
                {
                    action.Invoke(mod);
                }
            }
        }
        
    }
}