//Adapted from WarperSan's BossPack 

using BTD_Mod_Helper.Api.Components;
using BTD_Mod_Helper.Api.Enums;
using BTD_Mod_Helper.UI.Menus;
using BTD_Mod_Helper.UI.Modded;
using Il2CppAssets.Scripts;
using Il2CppAssets.Scripts.Models.Bloons;
using Il2CppAssets.Scripts.Models.Bloons.Behaviors;
using Il2CppAssets.Scripts.Simulation.Bloons;
using Il2CppAssets.Scripts.Unity.UI_New.InGame;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;
using static BTD_Mod_Helper.UI.Menus.ModsMenu;

namespace BTD_Mod_Helper.Api.Bloons;

/// <summary>
/// Class for adding a new boss to the game
/// </summary>
public abstract class ModBoss : ModBloon
{
    /// <inheritdoc />
    public sealed override string BaseBloon => BloonType.Bad;

    internal static readonly new Dictionary<string, ModBoss> Cache = new();

    internal static Dictionary<ObjectId, ModHelperPanel> BossPanels = new();
    internal static Dictionary<ObjectId, Image> BossBars = new();
    internal static Dictionary<ObjectId, ModHelperText> BossHpTexts = new();
    internal static Dictionary<ObjectId, ModHelperButton> BossIcons = new();
    const uint maxLines = 3;

    /// <summary>
    /// The people who worked/helped to create the mod, but aren't the authors
    /// </summary>
    public virtual string ExtraCredits { get; }

    /// <summary>
    /// Called when the boss is spawned. Must not be overriden
    /// </summary>
    /// <param name="bloon"></param>
    public void OnSpawnMandatory(Bloon bloon)
    {
        int round = InGame.Bridge.GetCurrentRound() + 1;
        BossRoundInfo info = RoundsInfo[round];

        // No duplicates
        if (info.defeatIfPreviousNotDefeated != null && (bool) info.defeatIfPreviousNotDefeated)
        {
            for (int i = 0; i < ModBossUI.MainPanel.transform.childCount; i++)
            {
                if (ModBossUI.MainPanel.transform.GetChild(i).gameObject.name == $"{Name}-Panel")
                {
                    InGame.instance.Lose();
                    InGame.instance.SetHealth(0);
                    break;
                }
            }
        }

        // Skulls
        if (bloon.bloonModel.HasBehavior<HealthPercentTriggerModel>() && info.skullCount != null)
        {
            float[] percentageValues = info.percentageValues;

            // Puts default skulls placement
            if (percentageValues == null)
            {
                uint skullsCount = (uint) info.skullCount;

                List<float> pV = new List<float>();

                if (skullsCount > 0)
                {
                    for (int i = 1; i <= skullsCount; i++)
                    {
                        pV.Add(1f - 1f / (skullsCount + 1) * i);
                    }
                }

                percentageValues = pV.ToArray();
            }

            HealthPercentTriggerModel bossSkulls = bloon.bloonModel.GetBehavior<HealthPercentTriggerModel>();
            bossSkulls.percentageValues = percentageValues;
            bossSkulls.preventFallthrough = info.preventFallThrough != null ? (bool) info.preventFallThrough : false;
        }

        // Timer
        if (info.interval == null)
        {
            if (bloon.bloonModel.HasBehavior<TimeTriggerModel>())
            {
                bloon.bloonModel.RemoveBehavior<TimeTriggerModel>();
            }
        }
        else
        {
            if (!bloon.bloonModel.HasBehavior<TimeTriggerModel>())
            {
                bloon.bloonModel.AddBehavior(new TimeTriggerModel(Name + "-TimerTick"));
            }
            TimeTriggerModel timer = bloon.bloonModel.GetBehavior<TimeTriggerModel>();
            timer.actionIds = new string[] { Name + "TimerTick" };
            timer.interval = (float) info.interval;
            timer.triggerImmediately = info.triggerImmediately != null ? (bool) info.triggerImmediately : false;
        }

        // Boss Icon
        BossIcons.Add(bloon.Id, InGameButtonsHolder.subPanel.AddButton(new Info(Name + "-Icon", 170), ModContent.GetTextureGUID(mod, Icon), new System.Action(() =>
        {
            foreach (var item in BossPanels)
            {
                item.Value.SetActive(item.Key == bloon.Id);
            }
        })));

        BossPanels.Add(bloon.Id, AddBossPanel(ModBossUI.MainPanel, bloon));
        if (BossPanels.Count + ModBossUI.WaitingPanels.Count > maxLines)
        {
            var BossPanelsArray = BossPanels.Values.ToArray();
            for (int i = 0; i < BossPanels.Count - 1; i++)
            {
                BossPanelsArray[i].SetActive(false);
            }
        }

        OnSpawn(bloon);
    }

    /// <summary>
    /// Called when the boss is spawned
    /// </summary>
    /// <param name="bloon"></param>
    public virtual void OnSpawn(Bloon bloon) { }

    /// <summary>
    /// Called when the boss is leaked
    /// </summary>
    /// <param name="bloon"></param>
    public virtual void OnLeak(Bloon bloon)
    {
        RemoveUI(bloon);
    }

    /// <summary>
    /// Called when the boss is popped
    /// </summary>
    /// <param name="bloon"></param>
    public virtual void OnPop(Bloon bloon)
    {
        RemoveUI(bloon);
    }

    /// <summary>
    /// Called when the boss takes a damage. Usually used to update the health bar
    /// </summary>
    /// <param name="bloon"></param>
    /// <param name="totalAmount"></param>
    public virtual void OnDamage(Bloon bloon, float totalAmount)
    {
        if (BossBars.TryGetValue(bloon.Id, out var hpBar))
        {
            hpBar.fillAmount = bloon.health / Health;
        }

        if (BossHpTexts.TryGetValue(bloon.Id, out var hpText))
        {
            hpText.SetText($"{Mathf.FloorToInt(bloon.health)} / {Health}");
        }
    }

    /// <summary>
    /// The speed of the boss, 4.5 is the default for a BAD and 25 is the default for a red bloon
    /// </summary>
    public virtual float Speed => this.bloonModel == null ? 4.5f : this.bloonModel.speed;

    /// <summary>
    /// The health of the boss
    /// </summary>
    public virtual float Health => this.bloonModel == null ? 20_000f : this.bloonModel.maxHealth;

    /// <summary>
    /// Defines if the boss is using the default waiting UI
    /// </summary>
    public virtual bool UsingDefaultWaitingUi => true;

    /// <summary>
    /// Creates the panel that shows "Boss appears in X rounds".
    /// </summary>
    /// <remarks>
    /// This must be overriden if UsingDefaultWaitingUi is set to false.
    /// </remarks>
    /// <param name="waitingHolderPanel"></param>
    /// <returns></returns>
    public virtual ModHelperPanel AddWaitPanel(ModHelperPanel waitingHolderPanel) => throw new System.NotImplementedException();

    /// <summary>
    /// Creates the panel for the boss health bar
    /// </summary>
    /// <param name="holderPanel"></param>
    /// <param name="boss"></param>
    /// <returns></returns>
    public virtual ModHelperPanel AddBossPanel(ModHelperPanel holderPanel, Bloon boss)
    {
        BossRoundInfo infos = RoundsInfo[InGame.Bridge.GetCurrentRound() + 1];
        var panel = holderPanel.AddPanel(new Info(Name + "-Panel"));
        panel.transform.SetAsFirstSibling();

        // HP Text
        var hpText = panel.AddText(new Info("HealthText", 0, 120, 2000, FontMedium), $"{Health} / {Health}", FontMedium, Il2CppTMPro.TextAlignmentOptions.MidlineRight);
        hpText.Text.enableAutoSizing = true;
        BossHpTexts.Add(boss.Id, hpText);

        // Icon
        panel.AddImage(new Info(Name + "-Icon", -600, 0, 250), ModContent.GetSprite(mod, Icon));

        // Stars
        if (infos.tier != null)
        {
            var starsPanel = panel.AddPanel(new Info(Name + "-Stars"), VanillaSprites.BrownInsertPanel, RectTransform.Axis.Horizontal);
            starsPanel.transform.localPosition = new Vector3(-450, 140, 0);

            for (int i = 0; i < infos.tier; i++)
            {
                starsPanel.AddImage(new Info("Star" + i, 100), ModContent.GetTextureGUID<MelonMain>("BossStar"));
            }
        }

        GameObject healthBarContainer = new GameObject("HealthBarContainer");
        healthBarContainer.transform.parent = panel.transform;
        healthBarContainer.transform.localScale = Vector3.one;
        healthBarContainer.transform.localPosition = Vector3.zero;

        // HP Bar
        GameObject fillArea = new GameObject("FillArea");
        fillArea.transform.parent = healthBarContainer.transform;
        fillArea.transform.localScale = Vector3.one;
        fillArea.transform.localPosition = new Vector3(300, 0);
        RectTransform rtFillArea = fillArea.AddComponent<RectTransform>();
        rtFillArea.anchorMax = Vector2.one;
        rtFillArea.anchorMin = Vector2.zero;

        var bossBarSlider = fillArea.AddComponent<Image>();
        bossBarSlider.type = Image.Type.Filled;
        bossBarSlider.fillMethod = Image.FillMethod.Horizontal;
        bossBarSlider.SetSprite(ModContent.GetTextureGUID<MelonMain>("BossBarGradient"));
        bossBarSlider.rectTransform.sizeDelta = new Vector2(1500, 120);
        BossBars.Add(boss.Id, bossBarSlider);

        // Frame
        GameObject frame = new GameObject("Frame");
        frame.transform.parent = healthBarContainer.transform;
        frame.transform.localScale = Vector3.one;
        frame.transform.localPosition = fillArea.transform.localPosition;
        RectTransform rtFrame = frame.AddComponent<RectTransform>();
        rtFrame.anchorMax = Vector2.one;
        rtFrame.anchorMin = Vector2.zero;

        Image frameImg = frame.AddComponent<Image>();
        frameImg.type = Image.Type.Sliced;
        frameImg.SetSprite(ModContent.GetTextureGUID<MelonMain>("BossFrame"));
        Rect rect = new Rect(0, 0, frameImg.sprite.texture.width, frameImg.sprite.texture.height);
        frameImg.sprite = Sprite.Create(frameImg.sprite.texture, rect, new Vector2(0.5f, 0.5f), 100, 1, SpriteMeshType.FullRect, new Vector4(30, 30, 30, 30));
        frameImg.pixelsPerUnitMultiplier = 0.1f;
        frameImg.rectTransform.sizeDelta = new Vector2(bossBarSlider.rectTransform.sizeDelta.x, bossBarSlider.rectTransform.sizeDelta.y + 40);

        return panel;
    }

    /// <summary>
    /// Whether the boss should always cause defeat on leak
    /// </summary>
    public virtual bool AlwaysDefeatOnLeak => true;

    /// <summary>
    /// Whether the boss should block rounds from spawning, behaving like a normal bloon
    /// </summary>
    public virtual bool BlockRounds => false;

    /// <summary>
    /// The rounds the boss should spawn on
    /// </summary>
    public IEnumerable<int> SpawnRounds => RoundsInfo.Keys;

    /// <summary>
    /// Modifies the boss before it is spawned, based on the round
    /// </summary>
    /// <param name="bloon"></param>
    /// <param name="round"></param>
    /// <returns></returns>
    public virtual BloonModel ModifyForRound(BloonModel bloon, int round) => bloon;

    /// <summary>
    /// Informations about the boss on the round
    /// </summary>
    public abstract Dictionary<int, BossRoundInfo> RoundsInfo { get; }

    /// <summary>
    /// All the informations a boss holds for a specific round
    /// </summary>
    public struct BossRoundInfo
    {
        /// <summary>
        /// Tier of the boss on this round
        /// </summary>
        public uint? tier = null;

        /// <summary>
        /// Amount of skulls the boss has
        /// </summary>
        public uint? skullCount = null;

        /// <summary>
        /// Positions of the skulls
        /// </summary>
        /// <remarks>
        /// If not specified, the skulls' position will be placed evenly (3 skulls => 0.75, 0.5, 0.25)
        /// </remarks>
        public float[] percentageValues = null;

        /// <summary>
        /// The description of this particular skull effect
        /// </summary>
        /// <remarks>
        /// If not specified, the API will use <see cref="SkullDescription"/>
        /// </remarks>
        public string skullDescription = null;

        /// <summary>
        /// Determines if the boss's health should go down while it's skull effect is on
        /// </summary>
        public bool? preventFallThrough = null;

        /// <summary>
        /// Determines if the timer starts immediately
        /// </summary>
        public bool? triggerImmediately = null;

        /// <summary>
        /// Interval between ticks
        /// </summary>
        public float? interval = null;

        /// <summary>
        /// The description of this particualr timer effect
        /// </summary>
        /// <remarks>
        /// If not specified, the API will use <see cref="TimerDescription"/>
        /// </remarks>
        public string timerDescription = null;

        /// <summary>
        /// Determines if the previous boss must be killed before this one
        /// </summary>
        public bool? defeatIfPreviousNotDefeated = null;

        public BossRoundInfo() { }
    }

    #region Skulls
    /// <summary>
    /// The description of the skull effect (only used by the Boss API)
    /// </summary>
    public virtual string SkullDescription => "???";

    /// <summary>
    /// Checks if the boss has any skull on any round
    /// </summary>
    public bool UsesSkulls => RoundsInfo.Any(info => info.Value.skullCount > 0);

    public virtual void SkullEffectUi()
    {

    }

    /// <summary>
    /// Called when the boss hits a skull
    /// </summary>
    /// <param name="boss"></param>
    public virtual void SkullEffect(Bloon boss) { }
    #endregion

    #region Timer
    /// <summary>
    /// The description of the timer effect (only used by the Boss API)
    /// </summary>
    public virtual string TimerDescription => "???";

    /// <summary>
    /// Checks if the boss uses a timer on any round
    /// </summary>
    public bool UsesTimer => RoundsInfo.Any(info => info.Value.interval != null);

    /// <summary>
    /// Called when the boss timer ticks
    /// </summary>
    /// <param name="boss"></param>
    public virtual void TimerTick(Bloon boss) { }
    #endregion

    internal sealed override BloonModel GetDefaultBloonModel()
    {
        var original = base.GetDefaultBloonModel();
        original.RemoveAllChildren();
        original.danger = 16;
        original.overlayClass = BloonOverlayClass.Dreadbloon;
        original.bloonProperties = BloonProperties.None;
        original.tags = new Il2CppStringArray(new[] { "Bad", "Moabs", "Boss" });
        original.maxHealth = Health;
        original.speed = Speed;
        original.isBoss = true;

        return original;
    }

    internal static void ResetUIs()
    {
        ModBoss.BossPanels = new();
        ModBoss.BossBars = new();
        ModBoss.BossHpTexts = new();
    }

    private void RemoveUI(Bloon bloon)
    {
        if (BossPanels.TryGetValue(bloon.Id, out var panel))
        {
            if (panel.enabled)
            {
                if (BossPanels.Count - 1 > 0)
                {
                    BossPanels[BossPanels.Keys.First(k => k != bloon.Id)].SetActive(true);
                }
            }

            panel.DeleteObject();
            BossPanels.Remove(bloon.Id);
        }

        if (BossIcons.TryGetValue(bloon.Id, out var btn))
        {
            btn.DeleteObject();
            BossIcons.Remove(bloon.Id);
        }
    }

    /// <inheritdoc />
    public override void Register()
    {
        base.Register();

        if (!bloonModel.HasBehavior<HealthPercentTriggerModel>())
        {
            bloonModel.AddBehavior(new HealthPercentTriggerModel(Name + "-SkullEffect", false, new float[] { }, new string[] { Name + "SkullEffect" }, false));
        }

        Cache[bloonModel.name] = this;
    }
    /// <inheritdoc />
    public sealed override bool KeepBaseId => false;
    /// <inheritdoc />
    public sealed override bool Regrow => false;
    /// <inheritdoc />
    public sealed override string RegrowsTo => "";
    /// <inheritdoc />
    public sealed override float RegrowRate => 3;
}