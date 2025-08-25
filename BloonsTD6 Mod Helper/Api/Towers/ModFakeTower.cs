using System;
using System.Collections.Generic;
using Il2CppAssets.Scripts.Models.Effects;
using Il2CppAssets.Scripts.Models.Towers;
using Il2CppAssets.Scripts.Models.TowerSets;
using Il2CppAssets.Scripts.Simulation;
using Il2CppAssets.Scripts.Simulation.Objects;
using Il2CppAssets.Scripts.Simulation.Towers;
using Il2CppAssets.Scripts.Unity.UI_New.InGame;
using Il2CppAssets.Scripts.Unity.UI_New.InGame.RightMenu;
using Il2CppNinjaKiwi.Common.ResourceUtils;
using UnityEngine;
using UnityEngine.UI;
using Vector3 = Il2CppAssets.Scripts.Simulation.SMath.Vector3;

namespace BTD_Mod_Helper.Api.Towers;

/// <summary>
/// Defines a "fake" tower that will be added as an entry to the shop but instead of placing down as normal, will just show its
/// icon being placed with custom conditions and an action upon placement
/// </summary>
public abstract class ModFakeTower : ModTower
{
    internal static Tower lastHighlightTower;

    /// <summary>
    /// No base tower
    /// </summary>
    public sealed override string BaseTower => null!;

    /// <inheritdoc />
    public override bool IncludeInMonkeyTeams => false;

    /// <inheritdoc />
    public sealed override int TopPathUpgrades => 0;

    /// <inheritdoc />
    public sealed override int MiddlePathUpgrades => 0;

    /// <inheritdoc />
    public sealed override int BottomPathUpgrades => 0;

    /// <inheritdoc />
    public sealed override IEnumerable<int[]> TowerTiers() => base.TowerTiers();

    /// <inheritdoc />
    public sealed override bool IsValidCrosspath(params int[] tiers) => base.IsValidCrosspath(tiers);

    /// <inheritdoc />
    public sealed override ParagonMode ParagonMode => ParagonMode.None;

    /// <inheritdoc />
    public override bool IncludeInRogueLegends => false;

    /// <inheritdoc />
    public override void ModifyBaseTowerModel(TowerModel towerModel)
    {
        towerModel.showBuffs = false;
    }





    /// <inheritdoc />
    public override SpriteReference PortraitReference => IconReference;

    /// <inheritdoc />
    public override string Portrait => Icon;

    /// <summary>
    /// Sound to play on successful placement
    /// </summary>
    public virtual AudioClipReference PlacementSound => null;

    /// <summary>
    /// Effect to spawn on successful placement
    /// </summary>
    public virtual EffectModel PlacementEffect => null;

    /// <summary>
    /// The sprite to show hovering in the world while placing the fake tower
    /// </summary>
    public virtual Sprite PlacementSprite => ShopMenu.instance
        .GetTowerButtonFromBaseId(Id)
        .gameObject.transform
        .Find("Icon")
        .GetComponent<Image>()
        .sprite;

    /// <summary>
    /// Set to true to be highlighting towers while placing the fake tower if placement is valid
    /// </summary>
    public virtual bool HighlightTowers => false;

    /// <summary>
    /// Controls whether the fake tower can be placed at a particular location
    /// </summary>
    /// <param name="at">location</param>
    /// <param name="hoveredTower">tower being hovered, or null if none</param>
    /// <param name="helperMessage">message that, if not null, will be shown to the user to explain why the spot they just tried to place in is not valid</param>
    /// <returns>if its a valid placement</returns>
    public virtual bool CanPlaceAt(Vector2 at, Tower hoveredTower, ref string helperMessage) => true;

    /// <summary>
    /// Defines the actions that will be performed when this fake tower model is placed
    /// </summary>
    /// <param name="at"></param>
    /// <param name="towerModelFake">fake towermodel, will not actually place</param>
    /// <param name="hoveredTower">tower being hovered, or null if none</param>
    /// <param name="cost"></param>
    public abstract void OnPlace(Vector2 at, TowerModel towerModelFake, Tower hoveredTower, float cost);


    /// <summary>
    /// Purchases this fake tower at a specific spot
    /// </summary>
    /// <param name="at">position</param>
    /// <param name="towerModelFake">fake towermodel, will not actually place</param>
    /// <param name="hoveredTower">tower being hovered, or null if none</param>
    public void Purchase(Vector2 at, TowerModel towerModelFake, Tower hoveredTower)
    {
        var owner = InGame.Bridge.MyPlayerNumber;
        var sim = InGame.Bridge.Simulation;

        var height = sim.Map.GetTerrainHeight(new Il2CppAssets.Scripts.Simulation.SMath.Vector2(at));
        var pos = new Vector3(at.x, at.y, height);

        var towerInventory = sim.GetTowerInventory(owner);
        var cost = sim.towerManager.GetTowerCost(towerModelFake, pos, towerInventory, owner);

        sim.RemoveCash(cost, Simulation.CashType.Normal, owner, Simulation.CashSource.TowerBrought);

        try
        {
            OnPlace(at, towerModelFake, hoveredTower, cost);
        }
        catch (Exception e)
        {
            mod.LoggerInstance.Error(e);
        }


        PlacementSideEffects(hoveredTower?.Position ?? pos, hoveredTower?.Transform.Cast<IRootBehavior>());

        var inventory = InGame.Bridge.Simulation.GetTowerInventory(InGame.Bridge.MyPlayerNumber);
        if (inventory.towerMaxes.TryGetValue(Id, out var max) && max > 0)
        {
            inventory.towerMaxes[Id]--;
        }
    }

    /// <summary>
    /// Runs side effects like the placement effect and placement sound
    /// </summary>
    public void PlacementSideEffects(Vector3 position, IRootBehavior root = null)
    {
        var sim = InGame.Bridge.Simulation;
        if (PlacementSound is not null)
        {
            sim.audioManager.PlaySound(PlacementSound, groupId: Name, groupLimit: 1);
        }

        if (PlacementEffect is not null)
        {
            var entity = sim.SpawnEffect(PlacementEffect.assetId,
                PlacementEffect.useCenterPosition ? Vector3.zero : position, 0,
                PlacementEffect.scale, PlacementEffect.lifespan, PlacementEffect.fullscreen, root,
                PlacementEffect.useTransformPosition, PlacementEffect.useTransformPosition,
                PlacementEffect.destroyOnTransformDestroy, PlacementEffect.alwaysUseAge,
                useRoundTime: PlacementEffect.useRoundTime);

            var time = InGame.Bridge.ElapsedTime;
            TaskScheduler.ScheduleTask(() => entity.Destroy(),
                () => InGame.Bridge.ElapsedTime > time + PlacementEffect.lifespan * 60,
                () => InGame.instance == null || InGame.Bridge is null || entity == null || entity.IsDestroyed);
        }
    }
}

/// <inheritdoc />
public abstract class ModFakeTower<T> : ModFakeTower where T : ModTowerSet
{
    /// <inheritdoc />
    public sealed override ModTowerSet ModTowerSet => GetInstance<T>();

    /// <inheritdoc />
    public sealed override TowerSet TowerSet => ModTowerSet.Set;
}