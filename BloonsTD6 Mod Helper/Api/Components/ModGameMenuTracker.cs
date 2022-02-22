using System;
using Assets.Scripts.Unity.Menu;
using MelonLoader;
using UnityEngine;

namespace BTD_Mod_Helper.Api.Components
{
    /// <summary>
    /// Component to track that a instance of a GameMenu's gameObject actually is the same ModGameMenu as was opened,
    /// as direct comparison on the Unity Objects does not work reliably
    /// </summary>
    [RegisterTypeInIl2Cpp(false)]
    public class ModGameMenuTracker : MonoBehaviour
    {
        /// <summary>
        /// The GameMenu object that this is attached to
        /// </summary>
        private GameMenu gameMenu;
        
        /// <summary>
        /// The Id of the ModGameMenu that this is for
        /// </summary>
        public string modGameMenuId;
        
        /// <inheritdoc />
        public ModGameMenuTracker(IntPtr ptr) : base(ptr)
        {
        }

        private void Update()
        {
            if (gameMenu == null)
            {
                gameMenu = gameObject.GetComponent<GameMenu>();
            }

            if (ModGameMenu.Cache.TryGetValue(modGameMenuId ?? "", out var modGameMenu))
            {
                modGameMenu.OnMenuUpdate(gameMenu);
            }
        }

        private void OnDestroy()
        {
            if (ModGameMenu.Cache.TryGetValue(modGameMenuId ?? "", out var modGameMenu))
            {
                modGameMenu.IsOpen = false;
            }
        }
    }
}