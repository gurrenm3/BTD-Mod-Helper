using System.Linq;
using Assets.Scripts.Unity.UI_New.Settings;
using BTD_Mod_Helper.Api;
using BTD_Mod_Helper.Api.Components;
using BTD_Mod_Helper.Extensions;
using MelonLoader;
using UnityEngine;
using Object = Il2CppSystem.Object;

namespace BTD_Mod_Helper.Menus
{
    internal class ModSettingsMenu : ModGameMenu<HotkeysScreen>
    {
        private BloonsMod bloonsMod;

        private Animator animator;

        private CanvasGroup canvasGroup;

        private bool closing = false;

        public override bool OnMenuOpened(HotkeysScreen gameMenu, Object data)
        {
            closing = false;
            var gameObject = gameMenu.gameObject;
            gameObject.DestroyAllChildren();

            bloonsMod = MelonHandler.Mods.OfType<BloonsMod>().First(m => m.IDPrefix == data?.ToString());
            CommonForegroundHeader.SetText(bloonsMod.Info.Name);

            var scrollPanel = gameObject.AddModHelperScrollPanel(
                new Info("ScrollPanel", anchorMin: Vector2.zero, anchorMax: Vector2.one),
                RectTransform.Axis.Vertical, null, 150, 300
            );
            
            animator = scrollPanel.AddComponent<Animator>();
            animator.runtimeAnimatorController = Animations.PopupAnim;
            animator.speed = .65f;
            animator.Rebind();
            
            canvasGroup = scrollPanel.AddComponent<CanvasGroup>();

            foreach (var (category, modSettings) in bloonsMod.ModSettings.Values
                         .GroupBy(setting => setting.GetCategory())
                         .OrderBy(kvp => kvp.Key?.order ?? 0))
            {
                var content = scrollPanel.ScrollContent;
                if (category != null)
                {
                    var categoryOption = category.Create();
                    scrollPanel.AddScrollContent(categoryOption);
                    content = categoryOption.CategoryContent;
                }

                foreach (var modSetting in modSettings)
                {
                    var modHelperOption = modSetting.CreateComponent();
                    if (modHelperOption.ResetButton.gameObject.active)
                    {
                        modHelperOption.BottomRow.AddPanel(new Info("Empty", size: ModHelperOption.ResetSize));
                    }

                    content.Add(modHelperOption);
                }
            }

            return false;
        }

        public override void OnMenuUpdate(HotkeysScreen gameMenu)
        {
            if (closing)
            {
                canvasGroup.alpha -= .07f;
            }
        }

        public override void OnMenuClosed(HotkeysScreen gameMenu)
        {
            closing = true;
            animator.Play("PopupSlideOut");
            // Task.Run(() => ModSettingsHandler.SaveModSettings(ModHelper.Main.GetModSettingsDir()));
        }

        public static void Open(BloonsMod bloonsMod)
        {
            ModGameMenu.Open<ModSettingsMenu>(bloonsMod.IDPrefix);
        }
    }
}