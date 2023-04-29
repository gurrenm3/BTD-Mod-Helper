using BTD_Mod_Helper.Api.Bloons;
using BTD_Mod_Helper.Api.Components;
using Il2CppAssets.Scripts.Unity.UI_New.InGame;
using UnityEngine;
namespace BTD_Mod_Helper.UI.Modded;

internal class ModBossUI
{
    public static ModHelperPanel MainPanel { get; set; }
    
    internal static void Init()
    {
        MainPanel = InGame.instance.mapRect.gameObject.AddModHelperPanel(new Info("BossUIPanel",
            0, -50, 800,600,new Vector2(0.65f, .85f), new Vector2(.5f, .5f)),
            /*VanillaSprites.BrownInsertPanel*/null, RectTransform.Axis.Vertical, 200,0);

        foreach (var boss in ModBoss.Cache.Values)
        {
            boss.HoldingPanel = MainPanel.AddPanel(new Info("HoldingPanel-" + boss.Name));
            boss.WaitPanel = boss.AddWaitPanel(boss.HoldingPanel);
        }
    }
}