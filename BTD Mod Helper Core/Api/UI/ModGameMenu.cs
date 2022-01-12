using System;
using System.Collections.Generic;
using System.Linq;
using Assets.Scripts.Unity.Menu;
using Assets.Scripts.Unity.UI_New.ChallengeEditor;
using Assets.Scripts.Unity.UI_New.Main.PowersSelect;
using Assets.Scripts.Unity.UI_New.Settings;
using BTD_Mod_Helper.Api.Components;
using BTD_Mod_Helper.Extensions;
using UnhollowerRuntimeLib;
using Object = Il2CppSystem.Object;

namespace BTD_Mod_Helper.Api
{
    /// <summary>
    /// Class for a custom BTD6 menu
    /// </summary>
    public abstract class ModGameMenu : ModContent
    {
        internal static readonly Dictionary<string, ModGameMenu> Cache = new Dictionary<string, ModGameMenu>();

        /// <summary>
        /// The string name of the in game menu to copy from
        /// </summary>
        public abstract string BaseMenu { get; }


        /// <inheritdoc />
        public override void Register()
        {
            Cache[Id] = this;
        }


        /// <summary>
        /// Runs right as your custom menu is being opened, with the optional data argument that can be passed into
        /// <see cref="Open{T}"/>
        /// </summary>
        /// <returns>Whether to run the base menu's OnOpen code</returns>
        public abstract bool OnMenuOpened(GameMenu gameMenu, Object data);

        /// <summary>
        /// Runs right as your custom menu is being closed
        /// </summary>
        public virtual void OnMenuClosed(GameMenu gameMenu)
        {
        }
        
        /// <summary>
        /// Runs every time that your custom menu updates
        /// </summary>
        public virtual void OnMenuUpdate(GameMenu gameMenu)
        {
        }


        /// <summary>
        /// The name NinjaKiwi gave to the menu of the given screen type
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        protected static string MenuName<T>() where T : GameMenu
        {
            var type = Il2CppType.Of<T>();
            
            if (type == Il2CppType.Of<PowersSelectScreen>()) return "PowerSelectUI";

            return type.Name.Replace("Screen", "UI");
        }

        internal static bool CheckOpen(GameMenu gameMenu, Object data, out Object outData)
        {
            if (data != null &&
                data.IsType(out ModMenuData menuData) &&
                GetContent<ModGameMenu>().FirstOrDefault(menu => menu.Id == menuData.id) is ModGameMenu modGameMenu)
            {
                outData = menuData.baseData;
                var tracker = gameMenu.gameObject.AddComponent<ModGameMenuTracker>();
                tracker.modGameMenuId = modGameMenu.Id;
                return modGameMenu.OnMenuOpened(gameMenu, menuData.modData);
            }
            outData = data;
            return true;
        }


        /// <summary>
        /// Opens a custom menu
        /// </summary>
        /// <param name="data">The custom data to pass into your ModGameMenu's <see cref="OnMenuOpened"/> method</param>
        /// <param name="baseData">The data that you want to pass into the base menu's Open method, if you're still running the code</param>
        /// <typeparam name="T">The custom menu type to open</typeparam>
        public static void Open<T>(Object data = null, Object baseData = null) where T : ModGameMenu
        {
            var modGameMenu = GetInstance<T>();

            MenuManager.instance.OpenMenu(modGameMenu.BaseMenu, new ModMenuData(modGameMenu.Id, data, baseData));
        }
    }

    /// <summary>
    /// Generic class for creating a ModGameMenu with the given type as it's base menu
    /// </summary>
    public abstract class ModGameMenu<T> : ModGameMenu where T : GameMenu
    {
        /// <inheritdoc />
        public override string BaseMenu => MenuName<T>();

        /// <inheritdoc />
        public sealed override bool OnMenuOpened(GameMenu gameMenu, Object data)
        {
            return OnMenuOpened(gameMenu.Cast<T>(), data);
        }

        /// <inheritdoc cref="OnMenuOpened(Assets.Scripts.Unity.Menu.GameMenu,Il2CppSystem.Object)" />
        public abstract bool OnMenuOpened(T gameMenu, Object data);


        /// <inheritdoc />
        public sealed override void OnMenuClosed(GameMenu gameMenu)
        {
            OnMenuClosed(gameMenu.Cast<T>());
        }

        /// <inheritdoc cref="OnMenuClosed(Assets.Scripts.Unity.Menu.GameMenu)" />
        public virtual void OnMenuClosed(T gameMenu)
        {
        }
        
        /// <inheritdoc/>
        public sealed override void OnMenuUpdate(GameMenu gameMenu)
        {
            OnMenuUpdate(gameMenu.Cast<T>());
        }
        
        
        /// <inheritdoc cref="OnMenuUpdate(Assets.Scripts.Unity.Menu.GameMenu)"/>
        public virtual void OnMenuUpdate(T gameMenu)
        {
        }
    }
}