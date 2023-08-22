// Adapted from WarperSan's BossPack 

using System.Collections.Generic;
using System.Linq;
using BTD_Mod_Helper.Api.Components;
using BTD_Mod_Helper.Api.Enums;
using BTD_Mod_Helper.UI.Modded;
using Il2CppAssets.Scripts;
using Il2CppAssets.Scripts.Models.Bloons;
using Il2CppAssets.Scripts.Models.Bloons.Behaviors;
using Il2CppAssets.Scripts.Simulation.Bloons;
using Il2CppAssets.Scripts.Unity.UI_New.InGame;
using Il2CppTMPro;
using UnityEngine;
using UnityEngine.UI;
namespace BTD_Mod_Helper.Api.Bloons;

/// <summary>
/// Class for adding a new boss to the game
/// </summary>
public abstract class ModBoss : ModBloon
{
    internal static readonly new Dictionary<string, ModBoss> Cache = new();
    
    internal List<ModBossTier> tiers = new();
    internal SortedList<int, ModBossTier> tiersByRound = new();
    internal int highestTier = 0;

    internal ModBossTier currentTier = null;

    /// <summary>
    /// Apply your custom modifications to the base bloon
    /// </summary>
    /// <param name="bloonModel"></param>
    public abstract void ModifyBaseBloon(BloonModel bloonModel);
    
    internal void OnSpawn(Bloon bloon, ModBoss boss)
    {
        // Skulls
        if (bloon.bloonModel.HasBehavior<HealthPercentTriggerModel>() && currentTier.Skulls > 0)
        {
            // Puts default skulls placement
            if (currentTier.PercentageValues == null)
            {
                var skullsCount = currentTier.Skulls;

                var pV = new List<float>();

                if (skullsCount > 0)
                {
                    for (int i = 1; i <= skullsCount; i++)
                    {
                        pV.Add(1f - (1f / (skullsCount + 1)) * i);
                    }
                }

                currentTier.PercentageValues = pV.ToArray();
            }

            HealthPercentTriggerModel bossSkulls = bloon.bloonModel.GetBehavior<HealthPercentTriggerModel>();
            bossSkulls.percentageValues = currentTier.PercentageValues;
            bossSkulls.preventFallthrough = currentTier.PreventFallThrough;
        }

        // Timer
        if (bloon.bloonModel.HasBehavior<TimeTriggerModel>())
        {
            bloon.bloonModel.RemoveBehaviors<TimeTriggerModel>();
        }

        if (currentTier.Interval != null)
        {
            TimeTriggerModel timer = new TimeTriggerModel(Name + "-TimerTick")
            {
                actionIds = new[] {Name + "TimerTick"},
                //bloon.bloonModel.GetBehavior<TimeTriggerModel>();
                interval = currentTier.Interval.Value,
                triggerImmediately = currentTier.TriggerImmediately
            };


            bloon.bloonModel.AddBehavior(timer);
        }

        bloon.UpdatedModel(bloon.bloonModel);
        
        currentTier.BossPanel = CreateBossPanel(bloon);
        currentTier.BossPanel.transform.SetParent(ModBossUI.MainPanel.transform, false);
        
        currentTier.BossPanel.transform.SetAsFirstSibling();
        currentTier.OnSpawn(bloon);
    }

    internal void OnLeak(Bloon bloon)
    {
        RemoveUI(bloon);
        currentTier.OnLeak(bloon);
    }

    internal void OnPop(Bloon bloon)
    {
        RemoveUI(bloon);
        currentTier.OnPop(bloon);
    }

    internal void OnDamage(Bloon bloon, float totalAmount)
    {
        currentTier.OnDamage(bloon, totalAmount);
        currentTier.OnDamageUI(bloon, totalAmount);
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
    /// Whether the game is lost if multiple tiers of the same boss are alive at the same time
    /// </summary>
    public virtual bool DefeatIfNotPopped => true;

    /// <summary>
    /// The rounds the boss should spawn on
    /// </summary>
    internal IEnumerable<int> SpawnRounds => tiers.Select(x => x.Round);

    /// <summary>
    /// Creates the panel that shows "Boss appears in X rounds".
    /// </summary>
    /// <returns>A new <see cref="ModHelperPanel"/> to be added to the waiting list, created using <see cref="ModHelperPanel.Create"/></returns>
    public virtual ModHelperPanel CreateWaitPanel(int nextSpawnRound)
    {
        var panel = ModHelperPanel.Create(new Info("WaitPanel", -125, 100, 1100, 175), VanillaSprites.SmallSquareWhite);
        panel.GetComponent<Image>().color = new Color(0, 0, 0, 0.314f);
        var numRounds = nextSpawnRound - (InGame.instance.bridge.GetCurrentRound() + 1);
        var waitText = panel.AddText(new Info("Text")
        {
            AnchorMin = new Vector2(0, 0),
            AnchorMax = new Vector2(.8f, 1),
            X = 200,
        }, $"{DisplayName} appears in {numRounds} round{(numRounds == 1 ? "" : "s")}");
        
        waitText.Text.alignment = TextAlignmentOptions.Left;
        waitText.Text.enableAutoSizing = true;
        waitText.Text.enableWordWrapping = false;
        waitText.Text.textWrappingMode = TextWrappingModes.NoWrap;
        
        panel.AddImage(new Info("Icon", -panel.RectTransform.sizeDelta.x / 2 * 0.85f, 0, 200), Icon);
        return panel;
    }

    /// <summary>
    /// Creates the panel for the boss health UI
    /// </summary>
    /// <param name="boss"></param>
    public virtual ModHelperPanel CreateBossPanel(Bloon boss)
    {
        var panel = ModHelperPanel.Create(new Info(Name + "-Panel"));

        // HP Text
        var hpText = panel.AddText(new Info("HealthText", 0, 120, 2000, 69), "", 69,
            TextAlignmentOptions.MidlineRight);
        hpText.Text.enableAutoSizing = true;
        SetHPText(boss.bloonModel.maxHealth, boss.bloonModel.maxHealth, hpText.Text);
        
        // Icon
        panel.AddImage(new Info(Name + "-Icon", -600, 0, 250), GetSprite(mod, Icon));

        // Stars
        var starsPanel = panel.AddPanel(new Info(Name + "-Stars")
            {
                X = -450,
                Y = 140,
            }, VanillaSprites.BrownInsertPanel,
            RectTransform.Axis.Horizontal);

        for (int i = 0; i < currentTier.Tier; i++)
        {
            starsPanel.AddImage(new Info("Star" + i, 100), GetTextureGUID<MelonMain>("BossStar"));
        }
        for (int i = currentTier.Tier; i < highestTier; i++)
        {
            starsPanel.AddImage(new Info("Star" + i, 100), GetTextureGUID<MelonMain>("BossStar")).Image.color =
                new Color(0, 0, 0, 0.5f);
        }
        
        GameObject healthBarContainer = new GameObject("HealthBarContainer")
        {
            transform =
            {
                parent = panel.transform,
                localScale = Vector3.one,
                localPosition = Vector3.zero
            }
        };

        // HP Bar
        GameObject fillArea = new GameObject("FillArea")
        {
            transform =
            {
                parent = healthBarContainer.transform,
                localScale = Vector3.one,
                localPosition = new Vector3(300, 0)
            }
        };
        RectTransform rtFillArea = fillArea.AddComponent<RectTransform>();
        rtFillArea.anchorMax = Vector2.one;
        rtFillArea.anchorMin = Vector2.zero;

        var bossBarSlider = fillArea.AddComponent<Image>();
        bossBarSlider.type = Image.Type.Filled;
        bossBarSlider.fillMethod = Image.FillMethod.Horizontal;
        bossBarSlider.SetSprite(GetTextureGUID<MelonMain>("BossBarGradient"));
        bossBarSlider.rectTransform.sizeDelta = new Vector2(1500, 120);
        
        // Frame
        GameObject frame = new GameObject("Frame")
        {
            transform =
            {
                parent = healthBarContainer.transform,
                localScale = Vector3.one,
                localPosition = fillArea.transform.localPosition
            }
        };
        RectTransform rtFrame = frame.AddComponent<RectTransform>();
        rtFrame.anchorMax = Vector2.one;
        rtFrame.anchorMin = Vector2.zero;

        Image frameImg = frame.AddComponent<Image>();
        frameImg.type = Image.Type.Sliced;
        frameImg.SetSprite(GetTextureGUID<MelonMain>("BossFrame"));
        Rect rect = new Rect(0, 0, frameImg.sprite.texture.width, frameImg.sprite.texture.height);
        frameImg.sprite = Sprite.Create(frameImg.sprite.texture, rect, new Vector2(0.5f, 0.5f), 100, 1,
            SpriteMeshType.FullRect, new Vector4(30, 30, 30, 30));
        frameImg.pixelsPerUnitMultiplier = 0.1f;
        var sizeDelta = bossBarSlider.rectTransform.sizeDelta;
        frameImg.rectTransform.sizeDelta = new Vector2(sizeDelta.x,
            sizeDelta.y + 40);

        // Skulls

        float width = rtFrame.sizeDelta.x;
        ModHelperPanel skullsHolder = panel.AddPanel(new Info("SkullsHolder", rtFrame.localPosition.x, -50, width, 150));

        List<ModHelperImage> skulls = new List<ModHelperImage>();
        Il2CppStructArray<float> percentageValues =
            boss.bloonModel.GetBehavior<HealthPercentTriggerModel>().percentageValues;

        var unityWhiteTexture = Resources.FindObjectsOfTypeAll<Texture2D>().First(texture2D => texture2D.name == "UnityWhite");
        foreach (var item in percentageValues)
        {
            if (item is > 1 or < 0)
            {
                ModHelper.Error($"A skull from {mod} is out of bounds. Ask {mod.Info.Author} to fix it.");
                continue;
            }

            var bar = skullsHolder.AddImage(new Info("Bar")
            {
                X = width * item - width / 2,
                Y = 50,
                SizeDelta = new Vector2(12, 0),
                AnchorMin = new Vector2(0.5f, 0.145F),
                AnchorMax = new Vector2(0.5f, .855f),
                Pivot = new Vector2(0.5f, 0.5f)
            }, "");
            bar.Image.color = new Color(0, 0, 0, 0.2353f);
            bar.Image.canvasRenderer.SetTexture(unityWhiteTexture);
            bar.Image.sprite = null;

            var skullIcon = bar.AddImage(new Info("Skull", 0, -50, 150),
                GetTextureGUID<MelonMain>("BossSkullPipOff"));

            skulls.Add(skullIcon);
        }

        foreach(var child in panel.GetComponentsInChildren<Graphic>())
            child.raycastTarget = false;
        foreach(var child in panel.GetComponents<Graphic>())
            child.raycastTarget = false;
        return panel;
    }

    internal static void SetHPText(float currentHealth, float maxHealth, NK_TextMeshProUGUI hpText)
    {
        hpText.SetText($"{currentHealth:n0} / {maxHealth:n0}");
    }

    internal static void ClearUI()
    {
        foreach (var o in ModBossUI.MainPanel.transform)
        {
            var item = o.Cast<Transform>().gameObject;
            if (item.name=="WaitPanelScroll")
            {
                continue;
            }
            item.Destroy();
        }
    }

    /// <summary>
    /// Called whenever the health UI should be removed, either because the boss was popped or leaked
    /// </summary>
    /// <param name="bloon"></param>
    public virtual void RemoveUI(Bloon bloon)
    {
        var ui = ModBossUI.MainPanel.transform.Find(Name + "-Panel");

        if (ui != null)
        {
            ui.gameObject.Destroy();
        }
    }
    
    
    /// <inheritdoc />
    public sealed override string BaseBloon => BloonType.Bad;

    /// <inheritdoc/>
    public sealed override void ModifyBaseBloonModel(BloonModel bloonModel)
    {
        bloonModel.RemoveAllChildren();
        bloonModel.danger = 16;
        bloonModel.overlayClass = BloonOverlayClass.Dreadbloon;
        bloonModel.bloonProperties = BloonProperties.None;
        bloonModel.tags = new Il2CppStringArray(new[] {"Bad", "Moabs", "Boss"});
        bloonModel.isBoss = true;

        if (!bloonModel.HasBehavior<HealthPercentTriggerModel>())
        {
            bloonModel.AddBehavior(new HealthPercentTriggerModel(Name + "-SkullEffect", false, System.Array.Empty<float>(),
                new[] {Name + "SkullEffect"}, false));
        }

        ModifyBaseBloon(bloonModel);
        Cache[bloonModel.name] = this;
    }


    /// <inheritdoc />
    public override void Register()
    {
        if (tiers.Count == 0)
            return;

        base.Register();
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