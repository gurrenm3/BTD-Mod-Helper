using BTD_Mod_Helper.Api;
using BTD_Mod_Helper.Api.Bloons;
using BTD_Mod_Helper.Api.Components;
using BTD_Mod_Helper.Api.Enums;
using BTD_Mod_Helper.Api.ModOptions;
using Il2CppAssets.Scripts.Unity.UI_New.Settings;
using Il2CppTMPro;
using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

namespace BTD_Mod_Helper.UI.Menus.Bosses;

internal class BossesSettings : ModGameMenu<HotkeysScreen>
{
    static ModHelperPanel panel;
    static Dictionary<ModHelperButton, bool> buttons;

    const float size = 150;
    const float spacing = 25;
    const int maxBoss = 8;
    const int maxRounds = 12;

    static GameObject canvas;

    public override bool OnMenuOpened(Il2CppSystem.Object data)
    {
        canvas = GameMenu.gameObject;
        canvas.DestroyAllChildren();
        GameMenu.saved = true;

        CommonForegroundHeader.SetText("SETTINGS");

        int[] rounds = CompileAllRounds();

        //float tableWidth = (rounds.Length > maxRounds - 1 ? maxRounds : rounds.Length + 1) * (size + spacing);
        float tableWidth = maxRounds * (size + spacing);
        //float tableHeight = (ModBoss.Cache.Count > maxBoss - 1 ? maxBoss : ModBoss.Cache.Count + 1) * (size + spacing);
        float tableHeight = maxBoss * (size + spacing);

        var table = canvas.AddModHelperScrollPanel(new Info("Table", 0, (maxBoss * (size + spacing) - tableHeight) / 2, tableWidth, tableHeight), RectTransform.Axis.Horizontal, VanillaSprites.MainBGPanelBlueNotchesShadow);
        table.ScrollRect.vertical = ModBoss.Cache.Count > maxBoss - 1;
        table.ScrollRect.horizontal = rounds.Length > maxRounds - 1;
        table.ScrollContent.gameObject.RemoveComponent<HorizontalLayoutGroup>();

        AddBosses(table);

        return true;
    }

    public override void OnMenuClosed()
    {
        JsonSerializer.instance.SaveToFile(ModBoss.Permissions, mod.GetModSettingsDir() + "\\BossesSetting.json");
        ModHelper.Msg("Boss Settings Saved !");
    }

    private static int[] CompileAllRounds()
    {
        List<int> rounds = new List<int>();

        foreach (var b in ModBoss.Cache)
        {
            foreach (var r in b.Value.RoundsInfo)
            {
                if (!rounds.Contains(r.Key))
                    rounds.Add(r.Key);
            }
        }
        rounds.Sort();
        return rounds.ToArray();
    }

    private static void AddBosses(ModHelperScrollPanel table)
    {
        buttons = new Dictionary<ModHelperButton, bool>();

        int[] rounds = CompileAllRounds();
        panel = table.AddPanel(new Info("MainPanel", rounds.Length * size + (rounds.Length - 1) * spacing, ModBoss.Cache.Count * size + ModBoss.Cache.Count * spacing), null);
        table.AddScrollContent(panel);
        panel.RectTransform.localPosition = new Vector2((panel.RectTransform.sizeDelta.x - table.RectTransform.sizeDelta.x) / 2 + size / 2, -330);

        // Rounds
        var roundScrollPanel = canvas.AddModHelperScrollPanel(new Info("RoundsScrollPanel", table.RectTransform.localPosition.x, maxBoss * (size + spacing) / 2 + size, table.RectTransform.sizeDelta.x, 250), RectTransform.Axis.Horizontal, VanillaSprites.MainBGPanelGrey);
        var roundPanel = roundScrollPanel.AddPanel(new Info("RoundPanel"));
        roundScrollPanel.AddScrollContent(roundPanel);
        roundScrollPanel.ScrollRect.enabled = false;

        for (int i = 0; i < rounds.Length; i++)
        {
            ModHelperText t = roundPanel.AddText(new Info("RoundLabel" + rounds[i], (-5 + i) * (spacing + size) - spacing, 10, 150), rounds[i].ToString(), 69, TextAlignmentOptions.Left);
            t.Text.m_maxFontSize = 69;
            t.Text.enableAutoSizing = true;
            t.RectTransform.rotation = Quaternion.Euler(0, 0, 60);
        }

        // Bosses
        var bossScrollPanel = canvas.AddModHelperScrollPanel(new Info("BossesScrollPanel", table.RectTransform.localPosition.x - (maxBoss - 1) * (size + spacing) - spacing, table.RectTransform.localPosition.y, 350, table.RectTransform.sizeDelta.y), RectTransform.Axis.Vertical, VanillaSprites.MainBGPanelGrey);
        var bossPanel = bossScrollPanel.AddPanel(new Info("BossPanel"));
        bossScrollPanel.AddScrollContent(bossPanel);
        bossScrollPanel.ScrollRect.enabled = false;

        List<ModBoss> bosses = ModBoss.Cache.Values.ToList();
        for (int i = 0; i < bosses.Count; i++)
        {
            ModHelperText t = bossPanel.AddText(new Info("BossLabel" + bosses[i].Name,
                -spacing,
                (3 - i) * (spacing + size) + spacing * 2,
                bossScrollPanel.RectTransform.sizeDelta.x, 69),
                bosses[i].Name,
                69,
                TextAlignmentOptions.Right);
            t.Text.overflowMode = TextOverflowModes.Overflow;
            t.transform.SetAsFirstSibling();
        }

        float yCount = 0;

        foreach (var b in bosses)
        {
            for (int x = 0; x < rounds.Length; x++)
            {
                var round = rounds[x];

                if (b.RoundsInfo.Any(c => c.Key == round))
                {
                    bool isAllowed = ModBoss.GetPermission(b, round);
                    var d = panel.AddButton(new Info($"{b.Name}-Btn{round}",
                        (x - rounds.Length / 2) * (size + spacing) + (1 - rounds.Length % 2) * (size - 2 * spacing),
                        (ModBoss.Cache.Count / 2 - yCount) * (size + spacing), size),
                        GetSprite(isAllowed), null);

                    buttons.Add(d, isAllowed);

                    d.Button.AddOnClick(new Function(() =>
                    {
                        bool result = UpdateBossRound(b, round, !buttons[d]);
                        buttons[d] = result;

                        d.Image.LoadSprite(new Il2CppAssets.Scripts.Utils.SpriteReference(GetSprite(result)));
                    }));
                }
            }
            yCount++;
        }

        table.ScrollRect.onValueChanged.AddListener(new Action<Vector2>((r) =>
        {
            if (table.ScrollRect.velocity.x != 0)
            {
                roundScrollPanel.ScrollRect.content.position = FollowOtherScroll(roundScrollPanel, table, true, false);
            }

            if (table.ScrollRect.velocity.y != 0)
            {
                bossScrollPanel.ScrollRect.content.position = FollowOtherScroll(bossScrollPanel, table, false, true);
            }
        }));
    }

    private static string GetSprite(bool state) => state ? VanillaSprites.AddMoreBtn : VanillaSprites.AddRemoveBtn;

    private static bool UpdateBossRound(ModBoss boss, int round, bool state)
    {
        bool result = state;
        string bossName = boss.ToString();

        if (!ModBoss.Permissions.ContainsKey(bossName))
        {
            ModBoss.Permissions.Add(bossName, new());
        }

        if (ModBoss.Permissions.TryGetValue(bossName, out Dictionary<int, bool> value))
        {
            if (!value.ContainsKey(round))
                value.Add(round, false);
            value[round] = state;
        }

        return result;
    }

    private static Vector3 FollowOtherScroll(ModHelperScrollPanel target, ModHelperScrollPanel source, bool horizontal = false, bool vertical = false)
    {
        return new Vector3(
                horizontal ? target.RectTransform.position.x + source.ScrollRect.content.position.x - source.ScrollRect.rectTransform.position.x : target.ScrollRect.content.position.x,
                vertical ? target.RectTransform.position.y + source.ScrollRect.content.position.y - source.ScrollRect.rectTransform.position.y - size - spacing * 2 : target.ScrollRect.content.position.y,
                0);
    }
}
