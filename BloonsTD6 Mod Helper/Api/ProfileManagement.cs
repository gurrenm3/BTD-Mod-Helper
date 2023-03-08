using System;
using System.Collections.Generic;
using System.Linq;
using BTD_Mod_Helper.Api.Towers;
using Il2CppAssets.Scripts.Models.Profile;
using Il2CppAssets.Scripts.Unity;
using Il2CppAssets.Scripts.Utils;
namespace BTD_Mod_Helper.Api;

internal class ProfileManagement
{
    private static readonly string[] ParagonEvents = {"ParagonPanelViewed", "ParagonUpgradeAvailable"};

    private static readonly HashSet<string> UnlockedTowers = new();
    private static readonly Dictionary<string, KonFuze> TowersPlacedByBaseName = new();

    private static readonly Dictionary<string, KonFuze_NoShuffle> TowerXp = new();

    private static readonly HashSet<string> AcquiredUpgrades = new();

    private static readonly HashSet<string> UnlockedHeroes = new();
    private static readonly HashSet<string> SeenUnlockedNotification = new();
    private static readonly HashSet<string> SeenUnlockedHeroes = new();
    private static readonly HashSet<string> SeenNewHeroNotification = new();
    private static readonly Dictionary<string, KonFuze> HeroesPlacedByName = new();
    private static readonly Dictionary<string, KonFuze> HeroLevelsByName = new();

    private static readonly HashSet<string> SeenEvents = new();

    private static string primaryHero;

    private static readonly Dictionary<(string, int), string> MapPlayerHeroes = new();

    private static readonly Dictionary<string, string> SelectedTowerSkinData = new();

    private static void CleanProfile(ProfileModel profile, IReadOnlyCollection<string> towers,
        IReadOnlyCollection<string> upgrades, IReadOnlyCollection<string> heroes, bool current)
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
            foreach (var paragonEvent in ParagonEvents)
            {
                if (s.StartsWith(paragonEvent))
                {
                    var tower = s.Replace(paragonEvent, "");
                    if (Clean(paragonEvent, towers, current)(tower))
                    {
                        SeenEvents.Add(s);
                        return true;
                    }
                }
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
                    if (player != null)
                    {
                        if (Clean($"{id} primaryHero", heroes, current)(player.hero))
                        {
                            MapPlayerHeroes[(name, id)] = player.hero;
                            player.hero = "Quincy";
                        }
                    }
                }
            }
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

        CleanProfile(profile, towers, upgrades, heroes, false);

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

        CleanProfile(profile, towers, upgrades, heroes, true);
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

        foreach (var ((map, player), hero) in MapPlayerHeroes)
        {
            if (profile.savedMaps?.ContainsKey(map) == true)
            {
                var mapSaveDataModel = profile.savedMaps[(string) map];
                if (mapSaveDataModel.players.ContainsKey(player))
                {
                    mapSaveDataModel.players[(int) player].hero = hero;
                }
            }
        }

        ModHelper.PerformHook(mod => mod.PostCleanProfile(profile));
    }

    private static Func<string, bool> Clean(string name, IReadOnlyCollection<string> things, bool current)
    {
        return thing =>
        {
            if (string.IsNullOrEmpty(thing) || things == null)
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
    }

    private static void CleanHashSet(Il2CppSystem.Collections.Generic.HashSet<string> hashSet,
        Func<string, bool> clean, HashSet<string> storage)
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

    private static void CleanDictionary<T>(Il2CppSystem.Collections.Generic.Dictionary<string, T> dictionary,
        Func<string, bool> clean, Dictionary<string, T> storage)
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