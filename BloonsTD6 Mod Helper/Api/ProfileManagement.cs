using System;
using System.Collections.Generic;
using System.Linq;
using Assets.Scripts.Models.Profile;
using Assets.Scripts.Unity;
using Assets.Scripts.Unity.Player;
using Assets.Scripts.Utils;
using BTD_Mod_Helper.Api.Towers;
using BTD_Mod_Helper.Extensions;
using HarmonyLib;
using MelonLoader;

namespace BTD_Mod_Helper.Api
{
    internal class ProfileManagement
    {
        private static readonly string[] ParagonEvents = { "ParagonPanelViewed", "ParagonUpgradeAvailable" };

        private static readonly HashSet<string> UnlockedTowers = new HashSet<string>();
        private static readonly Dictionary<string, KonFuze> TowersPlacedByBaseName = new Dictionary<string, KonFuze>();
        private static readonly Dictionary<string, KonFuze_NoShuffle> TowerXp = new Dictionary<string, KonFuze_NoShuffle>();

        private static readonly HashSet<string> AcquiredUpgrades = new HashSet<string>();

        private static readonly HashSet<string> UnlockedHeroes = new HashSet<string>();
        private static readonly HashSet<string> SeenUnlockedNotification = new HashSet<string>();
        private static readonly HashSet<string> SeenUnlockedHeroes = new HashSet<string>();
        private static readonly HashSet<string> SeenNewHeroNotification = new HashSet<string>();
        private static readonly Dictionary<string, KonFuze> HeroesPlacedByName = new Dictionary<string, KonFuze>();
        private static readonly Dictionary<string, KonFuze> HeroLevelsByName = new Dictionary<string, KonFuze>();

        private static readonly HashSet<string> SeenEvents = new HashSet<string>();

        private static string primaryHero;


        private static readonly Dictionary<string, string> SelectedTowerSkinData = new Dictionary<string, string>();

        private static void CleanProfile(ProfileModel profile, IReadOnlyCollection<string> towers,
            IReadOnlyCollection<string> upgrades, IReadOnlyCollection<string> heroes, bool current)
        {
            CleanHashSet(profile.unlockedTowers, Clean("unlockedTower", towers, current), UnlockedTowers);
            CleanDictionary(profile.analyticsKonFuze.towersPlacedByBaseName,
                Clean("towerPlacedByBaseName", towers, current), TowersPlacedByBaseName);
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
            CleanDictionary(profile.analyticsKonFuze.heroesPlacedByName, Clean("heroPlacedByName", heroes, current),
                HeroesPlacedByName);
            CleanDictionary(profile.analyticsKonFuze.heroLevelsByName, Clean("heroLevelsByName", heroes, current),
                HeroLevelsByName);

            SeenEvents.Clear();
            profile.seenEvents.RemoveWhere(new Func<string, bool>(s =>
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

            CleanDictionary(profile.instaTowers, Clean("instaTowers", towers, current), new Dictionary<string, Il2CppSystem.Collections.Generic.List<InstaTowerModel>>());

            primaryHero = null;
            if (Clean("primaryHero", heroes, current)(profile.primaryHero))
            {
                primaryHero = profile.primaryHero;
                profile.primaryHero = "Quincy";
            }
        }

        internal static void CleanPastProfile(ProfileModel profile)
        {
            MelonLogger.Msg("Cleaning past profile");

            var towers = Game.instance.model.towerSet.Select(model => model.towerId).ToList();
            var upgrades = Game.instance.model.upgrades.Select(model => model.name).ToList();
            var heroes = Game.instance.model.heroSet.Select(model => model.towerId).ToList();

            CleanProfile(profile, towers, upgrades, heroes, false);
        }

        internal static void CleanCurrentProfile(ProfileModel profile)
        {
            MelonLogger.Msg("Cleaning current profile");

            var towers = ModContent.GetInstances<ModTower>().Select(tower => tower.Id).ToList();
            var upgrades = ModContent.GetInstances<ModUpgrade>().Select(upgrade => upgrade.Id).ToList();
            var heroes = ModContent.GetInstances<ModHero>().Select(hero => hero.Id).ToList();

            CleanProfile(profile, towers, upgrades, heroes, true);
        }

        internal static void UnCleanProfile(ProfileModel profile)
        {
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
        }
        
        private static Func<string, bool> Clean(string name, IReadOnlyCollection<string> things, bool current)
        {
            return thing =>
            {
                var shouldRemove = current ? things.Contains(thing) : !things.Contains(thing);
                if (shouldRemove && !current)
                {
                    MelonLogger.Msg($"Cleaning {name} {thing}");
                }

                return shouldRemove;
            };
        }

        private static void CleanHashSet(Il2CppSystem.Collections.Generic.HashSet<string> hashSet,
            Func<string, bool> clean, HashSet<string> storage)
        {
            storage.Clear();

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
}