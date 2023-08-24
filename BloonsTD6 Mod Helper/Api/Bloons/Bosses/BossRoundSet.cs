#nullable enable
using System;
using System.Collections.Generic;
using System.Linq;
using BTD_Mod_Helper.Api.Enums;
using BTD_Mod_Helper.Api.Helpers;
using Il2CppAssets.Scripts.Data.Boss;
using Il2CppAssets.Scripts.Data.Gameplay;
using Il2CppAssets.Scripts.Models;
using Il2CppAssets.Scripts.Models.Rounds;
using Il2CppAssets.Scripts.Models.ServerEvents;
using Il2CppAssets.Scripts.Unity;
namespace BTD_Mod_Helper.Api.Bloons.Bosses;

/// <summary>
/// Class for a boss roundset
/// </summary>
internal class BossRoundSet : ModRoundSet
{
    internal static readonly Dictionary<string, BossRoundSet> Cache = new();

    public readonly BossType bossType;
    public readonly bool elite;
    public readonly ModBoss? modBoss;

    // ReSharper disable once UnusedMember.Global gotta have empty constructor for any ModContent
    /// <inheritdoc />
    public BossRoundSet()
    {
    }

    /// <inheritdoc />
    public BossRoundSet(BossType bossType, bool elite)
    {
        this.bossType = bossType;
        this.elite = elite;
        var boss = ModBoss.Cache.Values.FirstOrDefault(x => x.BossTypeInt == (int) bossType);
        if (boss != null)
        {
            modBoss = boss;
        }
    }

    /// <inheritdoc />
    public override string BaseRoundSet => RoundSetType.Default;

    /// <inheritdoc />
    public override int DefinedRounds => BaseRounds.Count;

    /// <inheritdoc />
    public override string Name => (elite ? "Elite" : "") + (modBoss is null ? bossType.ToString() : modBoss.DisplayName);

    /// <inheritdoc />
    public override string Icon
    {
        get
        {
            if (modBoss != null)
            {
                return modBoss.Icon;
            }

            var eliteStr = elite ? "Elite" : "";
            return VanillaSprites.ByName.TryGetValue(bossType + "Btn" + eliteStr, out var icon)
                ? icon
                : VanillaSprites.WoodenRoundButton;
        }
    }

    /// <summary>
    /// Load a BossRoundSet for each boss type / eliteness
    /// </summary>
    /// <returns></returns>
    public override IEnumerable<ModContent> Load()
    {
        foreach (var boss in Enum.GetValues(typeof(BossType)).Cast<BossType>())
        {
            yield return new BossRoundSet(boss, false);
            yield return new BossRoundSet(boss, true);
        }
    }

    private readonly Dictionary<int, RoundInfo> roundInfos = new();

    /// <inheritdoc />
    public override void Register()
    {
        if (SkuSettings.instance.gameEvents.roundSets.ContainsKey(bossType.ToString().ToLower()))
        {
            foreach (var round in SkuSettings.instance.gameEvents.roundSets[bossType.ToString().ToLower()].rounds)
            {
                roundInfos[round.roundNumber] = round;
            }
        }
        base.Register();
        Cache[Id] = this;
    }

    /// <inheritdoc />
    public override void ModifyRoundModels(RoundModel roundModel, int round)
    {
        if (!roundInfos.TryGetValue(round + 1, out var roundInfo)) return;

        var groups = roundInfo.GetRoundDef(1f).groups;

        if (roundInfo.addToRound)
        {
            roundModel.groups = roundModel.groups.Concat(groups).ToArray();
            roundModel.AddChildDependants(groups);
        }
        else
        {
            roundModel.RemoveChildDependants(roundModel.groups);
            roundModel.groups = groups;
            roundModel.AddChildDependants(groups);
        }

        modBoss?.ModifyRoundModels(roundModel, round);

        roundModel.emissions_ = null;
    }

    /// <inheritdoc />
    public override void ModifyGameModel(GameModel gameModel)
    {
        gameModel.endRound = 140;
    }
}