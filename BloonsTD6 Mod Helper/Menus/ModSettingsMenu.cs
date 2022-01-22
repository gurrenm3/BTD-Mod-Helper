using System.Linq;
using System.Threading.Tasks;
using Assets.Scripts.Unity.UI_New.Settings;
using BTD_Mod_Helper.Api;
using BTD_Mod_Helper.Api.Components;
using BTD_Mod_Helper.Api.Enums;
using BTD_Mod_Helper.Api.ModOptions;
using BTD_Mod_Helper.Extensions;
using MelonLoader;
using UnityEngine;
using Object = Il2CppSystem.Object;

namespace BTD_Mod_Helper.Menus
{
    internal class ModSettingsMenu : ModGameMenu<HotkeysScreen>
    {
        private BloonsMod bloonsMod;

        public override bool OnMenuOpened(HotkeysScreen gameMenu, Object data)
        {
            var gameObject = gameMenu.gameObject;
            gameObject.DestroyAllChildren();

            bloonsMod = MelonHandler.Mods.OfType<BloonsMod>().First(m => m.IDPrefix == data?.ToString());
            CommonForegroundHeader.SetText(bloonsMod.Info.Name);

            var scrollPanel = gameObject.AddModHelperScrollPanel(
                new Info("ScrollPanel", anchorMin: Vector2.zero, anchorMax: Vector2.one),
                RectTransform.Axis.Vertical, null, 100, 500
            );

            foreach (var (_, modSetting) in bloonsMod.ModSettings)
            {
                scrollPanel.AddScrollContent(modSetting.CreateComponent());
            }

            return false;
        }

        public override void OnMenuClosed(HotkeysScreen gameMenu)
        {
            // Task.Run(() => ModSettingsHandler.SaveModSettings(ModHelper.Main.GetModSettingsDir()));
        }

        public static void Open(BloonsMod bloonsMod)
        {
            ModGameMenu.Open<ModSettingsMenu>(bloonsMod.IDPrefix);
        }
    }
}