using System.Linq;
using System.Threading.Tasks;
using Assets.Scripts.Unity.UI_New.Settings;
using BTD_Mod_Helper.Api;
using BTD_Mod_Helper.Api.Components;
using BTD_Mod_Helper.Api.ModOptions;
using UnityEngine;
using Object = Il2CppSystem.Object;

namespace BTD_Mod_Helper.Menus;

internal class ModSettingsMenu : ModGameMenu<HotkeysScreen>
{
    private BloonsMod bloonsMod = null!;

    private Animator animator = null!;

    private CanvasGroup canvasGroup = null!;

    private bool closing;

    public override bool OnMenuOpened(Object? data)
    {
        closing = false;
        var gameObject = GameMenu.gameObject;
        gameObject.DestroyAllChildren();

        bloonsMod = ModHelper.Mods.First(m => m.IDPrefix == data?.ToString());
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
                     .GroupBy(setting => setting.category)
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
                modSetting.currentOption = modHelperOption;
                if (modHelperOption.ResetButton.gameObject.active)
                {
                    modHelperOption.BottomRow.AddPanel(new Info("Empty", size: ModHelperOption.ResetSize));
                }

                content.Add(modHelperOption);
            }
        }

        return true;
    }

    public override void OnMenuUpdate()
    {
        if (closing)
        {
            canvasGroup.alpha -= .07f;
        }
    }

    public override void OnMenuClosed()
    {
        closing = true;
        animator.Play("PopupSlideOut");
        Task.Run(() => ModSettingsHandler.SaveModSettings());
    }

    public static void Open(BloonsMod bloonsMod)
    {
        ModGameMenu.Open<ModSettingsMenu>(bloonsMod.IDPrefix);
    }
}