using System;
using System.Collections.Generic;
using System.Linq;
using BTD_Mod_Helper.Api.Legends;
using BTD_Mod_Helper.Api.Towers;
using Il2CppAssets.Scripts.Data;
using Il2CppAssets.Scripts.Data.Legends;
using Il2CppAssets.Scripts.Models.Profile;
using Il2CppAssets.Scripts.Models.ServerEvents;
using Il2CppAssets.Scripts.Unity;
using Il2CppAssets.Scripts.Utils;
namespace BTD_Mod_Helper.Api.Internal;

internal class ProfileManagement
{
    private static readonly string[] ParagonEvents = ["ParagonPanelViewed", "ParagonUpgradeAvailable"];

    private static readonly HashSet<string> UnlockedTowers = [];
    private static readonly Dictionary<string, KonFuze> TowersPlacedByBaseName = new();

    private static readonly Dictionary<string, KonFuze_NoShuffle> TowerXp = new();

    private static readonly HashSet<string> AcquiredUpgrades = [];

    private static readonly HashSet<string> UnlockedHeroes = [];
    private static readonly HashSet<string> SeenUnlockedNotification = [];
    private static readonly HashSet<string> SeenUnlockedHeroes = [];
    private static readonly HashSet<string> SeenNewHeroNotification = [];
    private static readonly Dictionary<string, KonFuze> HeroesPlacedByName = new();
    private static readonly Dictionary<string, KonFuze> HeroLevelsByName = new();

    private static readonly HashSet<string> SeenEvents = [];

    private static string primaryHero;

    private static readonly Dictionary<string, Dictionary<int, string>> MapPlayerHeroes = new();

    private static readonly Dictionary<string, string> SelectedTowerSkinData = new();

    private static readonly HashSet<string> UnlockedStarterArtifacts = [];

    private static void CleanProfile(ProfileModel profile, IReadOnlyCollection<string> towers,
        IReadOnlyCollection<string> upgrades, IReadOnlyCollection<string> heroes, IReadOnlyCollection<string> artifacts,
        bool current)
    {
        ModHelper.PerformHook(mod => mod.PreCleanProfile(profile));

        CleanHashSet(profile.unlockedTowers, Clean("unlockedTower", towers, current), UnlockedTowers);
        CleanDictionary(profile.analyticsKonFuze?.towersPlacedByBaseName,
            Clean("towerPlacedByBaseName", towers.Concat(heroes).ToList(), current), TowersPlacedByBaseName);
        CleanDictionary(profile.towerXp, Clean("towerXp", towers, current), TowerXp);

        CleanHashSet(profile.acquiredUpgrades, Clean("acquiredUpgrade", upgrades, current), AcquiredUpgrades);

        CleanHashSet(profile.unlockedHeroes, Clean("unlockedHero", heroes, current), UnlockedHeroes);
        CleanHashSet(profile.seenUnlockedNotification, Clean("seenUnlockedNotification", heroes, current),
            SeenUnlockedNotification);
        CleanHashSet(profile.seenUnlockedHeroes, Clean("seenUnlockedHero", heroes, current), SeenUnlockedHeroes);
        CleanHashSet(profile.seenNewHeroNotification, Clean("seenNewHeroNotification", heroes, current),
            SeenNewHeroNotification);
        CleanDictionary(profile.selectedTowerSkinData, Clean("selectedTowerSkinData", heroes, current),
            SelectedTowerSkinData);
        CleanDictionary(profile.analyticsKonFuze?.heroesPlacedByName, Clean("heroPlacedByName", heroes, current),
            HeroesPlacedByName);
        CleanDictionary(profile.analyticsKonFuze?.heroLevelsByName, Clean("heroLevelsByName", heroes, current),
            HeroLevelsByName);

        SeenEvents.Clear();
        profile.seenEvents?.RemoveWhere(new Func<string, bool>(s =>
        {
            if ((from paragonEvent in ParagonEvents
                    where s.StartsWith(paragonEvent)
                    let tower = s.Replace(paragonEvent, "")
                    where Clean(paragonEvent, towers, current)(tower)
                    select paragonEvent).Any())
            {
                SeenEvents.Add(s);
                return true;
            }

            return false;
        }));

        CleanDictionary(profile.instaTowers, Clean("instaTowers", towers, current),
            new Dictionary<string, Il2CppSystem.Collections.Generic.List<InstaTowerModel>>());

        primaryHero = null;
        if (Clean("primaryHero", heroes, current)(profile.primaryHero))
        {
            primaryHero = profile.primaryHero;
            profile.primaryHero = "Quincy";
        }

        MapPlayerHeroes.Clear();
        foreach (var (name, map) in profile.savedMaps)
        {
            if (map != null)
            {
                /*if (Clean($"{name} primaryHero", heroes, current)(map.primaryHero))
                {
                    MapPrimaryHeroes[name] = map.primaryHero;
                    map.primaryHero = "Quincy";
                }*/

                foreach (var (id, player) in map.players)
                {
                    if (player != null && Clean($"{id} primaryHero", heroes, current)(player.hero))
                    {
                        MapPlayerHeroes.TryAdd(name, new Dictionary<int, string>());
                        MapPlayerHeroes[name][id] = player.hero;
                        player.hero = "Quincy";
                    }
                }
            }
        }

        if (profile.savedNamedMonkeyStats != null)
        {
            foreach (var key in profile.savedNamedMonkeyStats.GetKeys())
            {
                if (ModHelper.Mods.Any(mod => key.StartsWith(mod.IDPrefix)))
                {
                    profile.savedNamedMonkeyStats.Remove(key);
                }
            }
        }

        if (profile.odysseysEditorData?.rules != null)
        {
            foreach (var rules in profile.odysseysEditorData.rules.GetValues())
            {
                rules.availableTowers?.RemoveAll(new Func<TowerData, bool>(towerData =>
                    ModHelper.Mods.Any(mod => towerData.tower.StartsWith(mod.IDPrefix))));

                if (rules.challenges != null)
                {
                    foreach (var dcm in rules.challenges)
                    {
                        dcm.towers?.RemoveAll(new Func<TowerData, bool>(towerData =>
                            ModHelper.Mods.Any(mod => towerData.tower.StartsWith(mod.IDPrefix))));
                    }
                }
            }
        }

        if (profile.legendsData is {unlockedStarterArtifacts: not null})
        {
            CleanHashSet(profile.legendsData.unlockedStarterArtifacts, Clean("unlockedStarterArtifacts", artifacts, current),
                UnlockedStarterArtifacts);
        }

        if (current) return;

        var artifactLists = new List<Il2CppSystem.Collections.Generic.List<ArtifactLoot>>();

        if (profile.legendsData is {selectedStarterArtifacts: not null})
        {
            artifactLists.Add(profile.legendsData.selectedStarterArtifacts);
        }

        if (profile.legendsData is {rogueSaves: not null})
        {
            foreach (var (_, save) in profile.legendsData.rogueSaves)
            {
                if (save is {artifactsInventory: not null})
                {
                    artifactLists.Add(save.artifactsInventory);
                }
            }
        }

        var amount = artifactLists.Sum(artifactList =>
            artifactList.RemoveAll(new Func<ArtifactLoot, bool>(loot => !artifacts.Contains(loot.artifactName))));

        if (amount > 0)
        {
            ModHelper.Msg(
                $"Cleaned {amount} artifact{(amount != 1 ? "s" : "")} that no longer exist{(amount != 1 ? "" : "s")}");
        }
    }

    internal static void CleanPastProfile(ProfileModel profile)
    {
        if (!MelonMain.CleanProfile || profile == null)
        {
            return;
        }

        // ModHelper.Msg("Cleaning past profile");

        var towers = Game.instance.model.towerSet.Select(model => model.towerId).ToList();
        var upgrades = Game.instance.model.upgrades.Select(model => model.name).ToList();
        var heroes = Game.instance.model.heroSet.Select(model => model.towerId).ToList();
        var artifacts = GameData.Instance.artifactsData.artifactDatas.Keys().ToList();

        CleanProfile(profile, towers, upgrades, heroes, artifacts, false);

        // FileIOUtil.SaveObject("profile.json", profile);
    }

    internal static void CleanCurrentProfile(ProfileModel profile)
    {
        if (!MelonMain.CleanProfile || profile == null)
        {
            return;
        }

        // ModHelper.Msg("Cleaning current profile");

        var towers = ModContent.GetContent<ModTower>().Select(tower => tower.Id).ToList();
        var upgrades = ModContent.GetContent<ModUpgrade>().Select(upgrade => upgrade.Id).ToList();
        var heroes = ModContent.GetContent<ModHero>().Select(hero => hero.Id).ToList();
        var artifacts = ModContent.GetContent<ModArtifact>().SelectMany(artifact => artifact.Ids).ToList();

        // handle dummy upgrades
        upgrades.AddRange(towers);
        upgrades.AddRange(heroes);

        CleanProfile(profile, towers, upgrades, heroes, artifacts, true);
    }

    internal static void UnCleanProfile(ProfileModel profile)
    {
        if (!MelonMain.CleanProfile || profile == null)
        {
            return;
        }

        foreach (var unlockedTower in UnlockedTowers)
        {
            profile.unlockedTowers.Add(unlockedTower);
        }

        foreach (var (name, tower) in TowersPlacedByBaseName)
        {
            profile.analyticsKonFuze.towersPlacedByBaseName.Add(name, tower);
        }

        foreach (var (tower, xp) in TowerXp)
        {
            profile.towerXp.Add(tower, xp);
        }

        foreach (var acquiredUpgrade in AcquiredUpgrades)
        {
            profile.acquiredUpgrades.Add(acquiredUpgrade);
        }

        foreach (var unlockedHero in UnlockedHeroes)
        {
            profile.unlockedHeroes.Add(unlockedHero);
        }

        foreach (var seenUnlockedNotification in SeenUnlockedNotification)
        {
            profile.seenUnlockedNotification.Add(seenUnlockedNotification);
        }

        foreach (var seenUnlockedHero in SeenUnlockedHeroes)
        {
            profile.seenUnlockedHeroes.Add(seenUnlockedHero);
        }

        foreach (var seenNewHeroNotification in SeenNewHeroNotification)
        {
            profile.seenNewHeroNotification.Add(seenNewHeroNotification);
        }

        foreach (var (name, hero) in HeroesPlacedByName)
        {
            profile.analyticsKonFuze.heroesPlacedByName.Add(name, hero);
        }

        foreach (var (name, level) in HeroLevelsByName)
        {
            profile.analyticsKonFuze.heroLevelsByName.Add(name, level);
        }

        foreach (var (name, skinData) in SelectedTowerSkinData)
        {
            profile.selectedTowerSkinData.Add(name, skinData);
        }

        foreach (var seenEvent in SeenEvents)
        {
            profile.seenEvents.Add(seenEvent);
        }

        if (primaryHero != null)
        {
            profile.primaryHero = primaryHero;
        }

        /*foreach (var (map, hero) in MapPrimaryHeroes)
        {
            if (profile.savedMaps.ContainsKey(map))
            {
                profile.savedMaps[map].primaryHero = hero;
            }
        }*/

        foreach (var (map, dict) in MapPlayerHeroes)
        {
            if (profile.savedMaps?.ContainsKey(map) != true) continue;

            var mapSaveDataModel = profile.savedMaps[map];
            foreach (var (player, hero) in dict)
            {
                if (mapSaveDataModel.players.ContainsKey(player))
                {
                    mapSaveDataModel.players[player].hero = hero;
                }
            }
        }

        if (profile.legendsData is {unlockedStarterArtifacts: not null})
        {
            foreach (var artifact in UnlockedStarterArtifacts)
            {
                profile.legendsData.unlockedStarterArtifacts.Add(artifact);
            }
        }

        ModHelper.PerformHook(mod => mod.PostCleanProfile(profile));
    }

    private static Func<T, bool> Clean<T>(string name, IReadOnlyCollection<T> things, bool current) => thing =>
    {
        if (thing is null || thing is "" || things == null)
        {
            return false;
        }

        var shouldRemove = current ? things.Contains(thing) : !things.Contains(thing);
        if (shouldRemove && !current)
        {
            ModHelper.Log($"Cleaning {name} {thing}");
        }

        return shouldRemove;
    };

    private static void CleanHashSet<T>(Il2CppSystem.Collections.Generic.HashSet<T> hashSet,
        Func<T, bool> clean, HashSet<T> storage)
    {
        storage.Clear();
        if (hashSet == null)
        {
            return;
        }

        foreach (var thing in hashSet)
        {
            if (clean(thing))
            {
                storage.Add(thing);
            }
        }

        foreach (var thing in storage)
        {
            hashSet.Remove(thing);
        }
    }

    private static void CleanDictionary<K, V>(Il2CppSystem.Collections.Generic.Dictionary<K, V> dictionary,
        Func<K, bool> clean, Dictionary<K, V> storage)
    {
        storage.Clear();
        if (dictionary == null)
        {
            return;
        }

        foreach (var (thing, value) in dictionary)
        {
            if (clean(thing))
            {
                storage.Add(thing, value);
            }
        }

        foreach (var thing in storage.Keys)
        {
            dictionary.Remove(thing);
        }
    }
}