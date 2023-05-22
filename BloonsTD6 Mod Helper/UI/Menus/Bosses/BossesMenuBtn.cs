using BTD_Mod_Helper.Api;
using BTD_Mod_Helper.Api.Bloons;
using BTD_Mod_Helper.Api.Components;
using BTD_Mod_Helper.Api.Enums;
using BTD_Mod_Helper.Extensions;
using Il2CppAssets.Scripts.Unity.UI_New.Main;
using Il2CppAssets.Scripts.Unity.UI_New.Main.Home;
using Il2CppAssets.Scripts.Utils;
using System;
using UnityEngine;
using UnityEngine.UI;

namespace BTD_Mod_Helper.UI.Menus.Bosses;

internal class BossesMenuBtn
{
    private static SpriteReference Sprite => ModContent.GetSpriteReference<BloonsTD6Mod>("BossMenuIcon");

    public static void Create(ModHelperPanel panel)
    {
        if (ModBoss.Cache.Count == 0)
            return;

        var bossesBtn = panel.AddButton(new Info("BossMenuBtn", -750, 50, 350, 350, new Vector2(1, 0), new Vector2(0.5f, 0)), Sprite.GUID,
            new Action(() => ModGameMenu.Open<BossesMenu>()));

        bossesBtn.AddText(new Info("Text", 0, -175, 500, 100), $"   Bosses ({ModBoss.Cache.Count})", 60f);
    }
}
