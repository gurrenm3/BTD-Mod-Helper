using BTD_Mod_Helper.Api;
using BTD_Mod_Helper.Api.Bloons;
using BTD_Mod_Helper.Api.Components;
using BTD_Mod_Helper.Api.Enums;
using Il2CppAssets.Scripts.Unity.UI_New.InGame;
using Il2CppTMPro;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using Image = UnityEngine.UI.Image;

namespace BTD_Mod_Helper.UI.Modded;

// Boss UI
// - Waiting Holder
// - Health Holder

internal class ModBossUI
{
    public static ModHelperPanel MainPanel { get; set; }
    public static ModHelperPanel WaitingHolderPanel { get; set; }
    public static ModHelperPanel WaitPanel { get; set; }
    private static ModHelperPanel IconsHolder { get; set; }
    public static ModHelperPanel BossBarsHolder { get; set; }

    public static Dictionary<int, List<ModBoss>> Rounds { get; set; }

    internal static void Init()
    {
        MainPanel = InGame.instance.mapRect.gameObject.AddModHelperPanel(new Info("BossUIPanel",
            -400, 200, 800, 600, new Vector2(0.65f, .85f), new Vector2(.5f, .5f)),
            /*VanillaSprites.BrownInsertPanel*/null);
        WaitingHolderPanel = MainPanel.AddPanel(new Info("WaitingHolderPanel"), null, RectTransform.Axis.Vertical, 100, 0);
        BossBarsHolder = MainPanel.AddPanel(new Info("BossBarsHolderPanel"), null, RectTransform.Axis.Vertical, 300, 0);

        Rounds = new Dictionary<int, List<ModBoss>>();

        foreach (var boss in ModBoss.Cache.Values)
        {
            boss.HoldingPanel = BossBarsHolder.AddPanel(new Info("BossPanel-" + boss.Name));
            boss.HoldingPanel.SetActive(false);

            foreach (var round in boss.SpawnRounds)
            {
                if (!Rounds.ContainsKey(round))
                    Rounds[round] = new List<ModBoss>();
                Rounds[round].Add(boss);
            }
        }
        UpdateWaitPanel(InGame.Bridge.GetCurrentRound());
    }

    public static ModHelperPanel AddWaitPanel(ModHelperPanel holderPanel)
    {
        var panel = holderPanel.AddPanel(new Info("WaitPanel", 0, -50, 1100, 175), VanillaSprites.SmallSquareWhite);
        panel.transform.localScale = new Vector3(1.5f, 1.5f);

        var color = panel.GetComponent<Image>().color;
        color.a = 0.314f;
        color.r = 0f;
        color.g = 0f;
        color.b = 0f;
        panel.GetComponent<Image>().color = color;
        panel.GetComponent<Image>().m_Color = color;

        panel.AddText(new Info("Title", 550, 5, 750, 255, new Vector2(.1f, .5f)), " appears in 888 rounds.");
        panel.transform.FindChild("Title").GetComponent<NK_TextMeshProUGUI>().alignment = TextAlignmentOptions.Left;

        return panel;
    }

    /// <summary>
    /// Updates the Wait Panel
    /// </summary>
    /// <param name="currentRound"></param>
    public static void UpdateWaitPanel(int currentRound)
    {
        WaitingHolderPanel.SetActive(true);

        for (int i = WaitingHolderPanel.transform.childCount - 1; i >= 0; i--)
        {
            GameObject.Destroy(WaitingHolderPanel.transform.GetChild(i).gameObject);
        }

        int closest = int.MaxValue;
        bool changed = false;

        foreach (var item in Rounds.Keys)
        {
            if (item < currentRound)
                continue;

            if (item - currentRound < closest)
            {
                closest = item - currentRound;
                changed = true;
            }
        }

        if (!changed)
            return;

        List<ModBoss> nearBosses = Rounds[closest + currentRound];

        int count = 2;

        if (nearBosses.Any(boss => boss.UsingDefaultWaitingUi))
        {
            CreateDefaultWaitingPanel(nearBosses, closest);
            count--;
        }

        List<ModBoss> customUiBosses = nearBosses.FindAll(boss => !boss.UsingDefaultWaitingUi);

        if (customUiBosses.Count < count)
            count = customUiBosses.Count;

        for (int i = 0; i < count; i++)
        {
            try
            {
                customUiBosses[i].AddWaitPanel(WaitingHolderPanel);
            }
            catch (System.Exception e)
            {
                ModHelper.Msg(e.Message);
            }
        }
    }

    /// <summary>
    /// Puts the given objects in a circular layout. If the list has 1 or 2 items, the layout is hardcoded;
    /// </summary>
    /// <param name="center"></param>
    /// <param name="objects"></param>
    /// <param name="radius"></param>
    private static void SetCircular(Vector2 center, List<GameObject> objects, float radius)
    {
        switch (objects.Count)
        {
            case 1:
                objects[0].transform.localPosition = center;
                break;
            case 2:
                objects[0].transform.localPosition = new Vector2(0.5f, 0.5f) * radius;
                objects[1].transform.localPosition = new Vector2(-0.5f, -0.5f) * radius;
                break;
            default:
                for (var pointNum = 0; pointNum < objects.Count; pointNum++)
                {
                    var i = pointNum * 1f / objects.Count;
                    var angle = i * Mathf.PI * 2;
                    var x = Mathf.Sin(angle);
                    var y = Mathf.Cos(angle);
                    objects[pointNum].transform.localPosition = new Vector2(x, y) * radius + center;
                }
                break;
        }
    }

    private static void CreateDefaultWaitingPanel(List<ModBoss> nearBosses, int inRounds)
    {
        List<GameObject> objs = new List<GameObject>();

        WaitPanel = AddWaitPanel(WaitingHolderPanel);
        IconsHolder = WaitPanel.AddPanel(new Info("IconsHolder"), null);
        IconsHolder.transform.localPosition = new Vector2(-WaitPanel.RectTransform.sizeDelta.x / 2 * 0.85f, 0);

        List<ModBoss> defaultUiBosses = nearBosses.FindAll(boss => boss.UsingDefaultWaitingUi);
        foreach (var boss in defaultUiBosses)
        {
            objs.Add(IconsHolder.AddImage(new Info(boss.Name + "-Icon", 0, 0, 200, new Vector2(.1f, .5f)), ModContent.GetSprite(boss.mod, boss.Icon)).gameObject);
        }
        SetCircular(Vector2.zero, objs, 100);

        NK_TextMeshProUGUI textDisplay = WaitPanel.transform.GetComponentInChildren<NK_TextMeshProUGUI>();

        if (defaultUiBosses.Count == 1)
            textDisplay.text = defaultUiBosses[0].DisplayName + " appears";
        else if (defaultUiBosses.Count == 2)
            textDisplay.text = defaultUiBosses[0].DisplayName + " & " + defaultUiBosses[1].DisplayName + " appear";
        else
            textDisplay.text = $"A float of {defaultUiBosses.Count} bosses appears";

        if (inRounds == 1)
            textDisplay.text += $" next round";
        else
            textDisplay.text += $" in {inRounds} rounds";
    }
}