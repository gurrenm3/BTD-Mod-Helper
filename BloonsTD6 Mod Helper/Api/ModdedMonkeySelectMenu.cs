using System.Collections.Generic;
using System.Linq;
using Assets.Scripts.Models.TowerSets;
using Assets.Scripts.Unity;
using Assets.Scripts.Unity.UI_New.Main;
using Assets.Scripts.Unity.UI_New.Main.MonkeySelect;
using HarmonyLib;

namespace BTD_Mod_Helper.Api
{
    internal class ModdedMonkeySelectMenu
    {
        private static MonkeySelectMenu menu;

        private static readonly Dictionary<string, int> Offsets = new Dictionary<string, int>();

        private static int Offset
        {
            get => Offsets[currentTowerSet];
            set => Offsets[currentTowerSet] = value;
        }

        private static readonly Dictionary<string, List<TowerDetailsModel>> TowersInSets =
            new Dictionary<string, List<TowerDetailsModel>>();

        private static readonly Dictionary<string, int> StartIndices = new Dictionary<string, int>();

        private static string currentTowerSet;

        private static readonly Dictionary<string, int> TotalSpotses = new Dictionary<string, int>();

        private static int TotalSpots => TotalSpotses[currentTowerSet];

        internal static void UpdateTowerSet(MonkeySelectMenu __instance, int offset = 0)
        {
            var newTowerSet = menu.TowerSets[menu.currentSet];
            if (newTowerSet != currentTowerSet)
            {
                currentTowerSet = newTowerSet;

                if (offset != Offset)
                {
                    Cycle(offset);
                }
            }
        }

        /// <summary>
        /// Changes the order of the TowerDetails in the GameModel
        /// </summary>
        internal static void UpdateGameModel(string set = "")
        {
            if (set == "")
            {
                set = currentTowerSet;
            }

            var model = Game.instance.model;
            foreach (var details in TowersInSets[set])
            {
                model.RemoveChildDependant(details);

                if (details.towerIndex >= Offsets[set] + StartIndices[set])
                {
                    model.AddChildDependant(details);
                }
            }
        }

        internal static void ResetGameModel()
        {
            var model = Game.instance.model;
            foreach (var details in model.towerSet)
            {
                model.RemoveChildDependant(details);
                model.AddChildDependant(details);
            }
        }

        /// <summary>
        /// Change the MonkeySelectButtons on the current page
        /// </summary>
        /// <param name="delta"></param>
        internal static void Cycle(int offset)
        {
            if (menu != null)
            {
                Offset = offset;
                if (Offset < 0)
                {
                    Offset += TotalSpots;
                }

                if (Offset >= TotalSpots)
                {
                    Offset = 0;
                }

                UpdateGameModel();
                RefreshButtons();
            }
        }

        /// <summary>
        /// Actually make the displayed buttons change
        /// </summary>
        internal static void RefreshButtons()
        {
            menu.shopTowerDetailsModels = null;
            menu.buttonLeft.m_OnClick.RemoveAllListeners();
            menu.buttonRight.m_OnClick.RemoveAllListeners();

            menu.Open(currentTowerSet);
        }

        public static bool ItComesAfter(string it, string maybeAfter)
        {
            var sets = menu.TowerSets;
            return (sets.IndexOf(it) - sets.IndexOf(maybeAfter) + sets.Length) % sets.Length == 1;
        }

        public static bool ItComesBefore(string it, string maybeBefore)
        {
            var sets = menu.TowerSets;
            return (sets.IndexOf(maybeBefore) - sets.IndexOf(it) + sets.Length) % sets.Length == 1;
        }


        [HarmonyPatch(typeof(MonkeySelectMenu), nameof(MonkeySelectMenu.Open))]
        internal class MonkeySelectMenu_Open
        {
            [HarmonyPrefix]
            internal static void Prefix(MonkeySelectMenu __instance, Il2CppSystem.Object data)
            {
                if (data == null)
                {
                    menu = null;
                    var model = Game.instance.model;
                    foreach (var set in __instance.TowerSets)
                    {
                        Offsets[set] = 0;
                        TowersInSets[set] = model.towerSet.Where(details =>
                            model.GetTowerFromId(details.towerId).towerSet == set).ToList();
                        StartIndices[set] = TowersInSets[set].First(details =>
                            model.GetTowerFromId(details.towerId).towerSet == set).towerIndex;
                        TotalSpotses[set] = ((TowersInSets[set].Count - 1) / 8 + 1) * 8;
                    }
                }
            }

            [HarmonyPostfix]
            internal static void Postfix(MonkeySelectMenu __instance, Il2CppSystem.Object data)
            {
                menu = __instance;
                UpdateTowerSet(__instance);
            }
        }

        [HarmonyPatch(typeof(MonkeySelectMenu), nameof(MonkeySelectMenu.SwitchTowerSet))]
        internal class MonkeySelectMenu_SwitchTowerSet
        {
            [HarmonyPrefix]
            internal static bool Prefix(MonkeySelectMenu __instance, ref string towerSet, bool swipeGesture,
                ref int __state) // State is the offset that the page should be at after this switch
            {
                __state = Offset;

                if (towerSet != currentTowerSet)
                {
                    // By default, switches will take the 
                    __state = 0;

                    // Swipe gestures also include the left and right arrow buttons alongside swiping.
                    // This is how actual navigation between the different pages of the same tower sets happens
                    if (swipeGesture)
                    {
                        if (ItComesAfter(towerSet, currentTowerSet) && Offset != TotalSpots - 8)
                        {
                            // Move to next page of tower set
                            Cycle(Offset + 8);
                            return false; // Don't switch to next tower set
                        }

                        if (ItComesBefore(towerSet, currentTowerSet))
                        {
                            if (Offset != 0)
                            {
                                // Move to previous page of tower set
                                Cycle(Offset - 8);
                                return false; // Don't switch to previous tower set
                            }

                            // Move to previous tower set, with it's offset at the last place it can be at
                            __state = TotalSpotses[towerSet] - 8;
                        }
                    }
                }

                return true;
            }

            [HarmonyPostfix]
            internal static void Postfix(MonkeySelectMenu __instance, string towerSet, bool swipeGesture, int __state)
            {
                UpdateTowerSet(__instance, __state);
            }
        }

        [HarmonyPatch(typeof(MonkeyGroupButton), nameof(MonkeyGroupButton.Initialise))]
        internal class MonkeyGroupButton_Initialise
        {
            [HarmonyPrefix]
            internal static bool Prefix(MonkeyGroupButton __instance)
            {
                // Don't re-initialize the MonkeyGroupButtons while we're reloading
                return menu == null;
            }
        }

        [HarmonyPatch(typeof(MainMenu), nameof(MainMenu.Start))]
        internal class MainMenu_Awake
        {
            [HarmonyPostfix]
            internal static void Postfix(MainMenu __instance)
            {
                ResetGameModel();
            }
        }
    }
}