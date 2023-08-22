using System.Linq;
using BTD_Mod_Helper.Api.Bloons;
using BTD_Mod_Helper.Api.Components;
using Il2CppAssets.Scripts.Unity.UI_New.InGame;
using UnityEngine;

namespace BTD_Mod_Helper.UI.Modded;

/// <summary>
/// Class that handles the boss UI ingame
/// </summary>
public static class ModBossUI
{
    public static ModHelperPanel MainPanel { get; set; }
    public static ModHelperScrollPanel WaitScrollPanel { get; set; }

    internal static void Init()
    {
        if (MainPanel != null)
        {
            MainPanel.DeleteObject();
            ModBoss.ClearUI();
        }
        
        MainPanel = InGame.instance.mapRect.gameObject.AddModHelperPanel(new Info("BossUIPanel", 800, 600, new Vector2(0.565f, .85f)), null, RectTransform.Axis.Vertical, 300, 150);

        WaitScrollPanel = MainPanel.AddScrollPanel(new Info("WaitPanelScroll", 0, 100, 1200, 350), RectTransform.Axis.Vertical, "", 75, 25);
        WaitScrollPanel.Mask.showMaskGraphic = false;
        UpdateWaitPanel();
    }

    private static void DeleteWaitingPanels()
    {
        WaitScrollPanel.ScrollContent.gameObject.DestroyAllChildren();
    }

    /// <summary>
    /// Updates the Wait Panel
    /// </summary>
    public static void UpdateWaitPanel()
    {
        DeleteWaitingPanels();
        var currentRound = InGame.Bridge.GetCurrentRound()+1;
        foreach (var (_, boss) in ModBoss.Cache.Where(keyValuePair => keyValuePair.Value.SpawnRounds.Any(x => x > currentRound)))
        {
            WaitScrollPanel.AddScrollContent(boss.CreateWaitPanel(boss.SpawnRounds.First(x => x > currentRound)));
        }
    }
}