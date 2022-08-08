using System.Collections;
using System.Linq;
using Assets.Scripts.Unity.UI_New.Settings;
using BTD_Mod_Helper.Api;
using BTD_Mod_Helper.Api.Components;
using BTD_Mod_Helper.Api.ModMenu;
using BTD_Mod_Helper.Api.ModOptions;
using UnityEngine;
using Object = Il2CppSystem.Object;

namespace BTD_Mod_Helper.UI.Menus;

internal class ModSettingsMenu : ModGameMenu<HotkeysScreen>
{
    private BloonsMod bloonsMod;

    private Animator animator;

    private CanvasGroup canvasGroup;

    private bool closing;

    private ModHelperScrollPanel scrollPanel;

    public override bool OnMenuOpened(Object data)
    {
        closing = false;
        var gameObject = GameMenu.gameObject;
        gameObject.DestroyAllChildren();

        bloonsMod = ModHelper.Mods.First(m => m.IDPrefix == data?.ToString());
        CommonForegroundHeader.SetText(bloonsMod.Info.Name);

        scrollPanel = gameObject.AddModHelperScrollPanel(new Info("ScrollPanel", InfoPreset.FillParent),
            RectTransform.Axis.Vertical, null, 150, 300);

        animator = scrollPanel.AddComponent<Animator>();
        animator.runtimeAnimatorController = Animations.PopupAnim;
        animator.speed = .65f;
        animator.Rebind();

        canvasGroup = scrollPanel.AddComponent<CanvasGroup>();

        MelonCoroutines.Start(CreateMenuContent());

        return true;
    }

    public IEnumerator CreateMenuContent()
    {
        foreach (var (category, modSettings) in bloonsMod.ModSettings.Values
                     .GroupBy(setting => setting.category)
                     .OrderBy(kvp => kvp.Key?.order ?? 0))
        {
            var content = scrollPanel.ScrollContent;
            if (category != null)
            {
                var categoryOption = category.Create();
                yield return null;
                scrollPanel.AddScrollContent(categoryOption);
                content = categoryOption.CategoryContent;
                yield return null;
            }

            foreach (var modSetting in modSettings)
            {
                var modHelperOption = modSetting.CreateComponent();
                yield return null;
                modSetting.currentOption = modHelperOption;
                if (modHelperOption.ResetButton.gameObject.active)
                {
                    modHelperOption.BottomRow.AddPanel(new Info("Empty", size: ModHelperOption.ResetSize));
                }

                content.Add(modHelperOption);
                
                yield return null;
            }
        }
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
        if (!closing)
        {
            ModSettingsHandler.SaveModSettings(bloonsMod);
            ModHelperHttp.UpdateSettings();
            animator.Play("PopupSlideOut");
        }
        closing = true;
    }

    public static void Open(BloonsMod bloonsMod)
    {
        ModGameMenu.Open<ModSettingsMenu>(bloonsMod.IDPrefix);
    }
}