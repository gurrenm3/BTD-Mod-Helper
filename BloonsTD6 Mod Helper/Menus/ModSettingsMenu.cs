using System.Linq;
using Assets.Scripts.Unity.UI_New.Settings;
using BTD_Mod_Helper.Api;
using BTD_Mod_Helper.Api.ModOptions;
using BTD_Mod_Helper.Extensions;
using MelonLoader;
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

            return false;
        }

        public override void OnMenuClosed(HotkeysScreen gameMenu)
        {
            ModSettingsHandler.SaveModSettings(ModHelper.Main.GetModSettingsDir());
            ModHelper.Msg("Successfully saved mod settings");
        }

        public static void Open(BloonsMod bloonsMod)
        {
            ModGameMenu.Open<ModSettingsMenu>(bloonsMod.IDPrefix);
        }
    }
}