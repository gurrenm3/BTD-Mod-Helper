using System.Collections.Generic;
using System.Linq;
using Assets.Scripts.Models.TowerSets;
using Assets.Scripts.Unity;
using Assets.Scripts.Unity.UI_New.Main;
using Assets.Scripts.Unity.UI_New.Main.MapSelect;
using Assets.Scripts.Unity.UI_New.Main.MonkeySelect;
using Assets.Scripts.Utils;
using HarmonyLib;
using Il2CppSystem;
using MelonLoader;
using UnhollowerBaseLib;
using UnhollowerRuntimeLib;
using UnityEngine;
using UnityEngine.UI;
using Object = UnityEngine.Object;

namespace BTD_Mod_Helper.Api
{
    internal class ModdedMonkeySelectMenu
    {
        private static MonkeySelectMenu menu;
        private static bool reOpening;
        private static string currentTowerSet;

        private static readonly Dictionary<string, int> Offsets = new Dictionary<string, int>();

        private static int Offset
        {
            get => Offsets[currentTowerSet];
            set => Offsets[currentTowerSet] = value;
        }

        private static readonly Dictionary<string, List<TowerDetailsModel>> TowersInSets =
            new Dictionary<string, List<TowerDetailsModel>>();

        // Total amount of towers in each set rounded up to the nearest multiple of 8
        private static readonly Dictionary<string, int> TotalSpotses = new Dictionary<string, int>();
        private static int TotalSpots => TotalSpotses[currentTowerSet];


        /// <summary>
        /// Update the currentTowerSet tracker, and change the state if need be
        /// </summary>
        /// <param name="__instance"></param>
        /// <param name="offset"></param>
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
        /// <br/>
        /// Their order in the GameModel is what determines their order in the screen
        /// </summary>
        internal static void UpdateGameModel(string set = "")
        {
            if (set == "")
            {
                set = currentTowerSet;
            }

            var model = Game.instance.model;
            for (var index = 0; index < TowersInSets[set].Count; index++)
            {
                var details = TowersInSets[set][index];
                model.RemoveChildDependant(details);

                if (index >= Offsets[set])
                {
                    model.AddChildDependant(details);
                }
            }
        }

        /// <summary>
        /// Put the GameModel's TowerDetails ordering back to normal
        /// </summary>
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

            reOpening = true;
            menu.Open(currentTowerSet);
            reOpening = false;
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
                        TotalSpotses[set] = ((TowersInSets[set].Count - 1) / 8 + 1) * 8;
                    }
                }

                if (!reOpening)
                {
                    CreatePips(__instance);
                }
            }

            [HarmonyPostfix]
            internal static void Postfix(MonkeySelectMenu __instance, Il2CppSystem.Object data)
            {
                menu = __instance;
                UpdateTowerSet(__instance);
                UpdatePips();
            }
        }

        /// <summary>
        /// Possible inputs:
        /// <br/>
        /// towerSet=null swipeGesture=false (reOpening=false) - When opening the MonkeySelectMenu from the Main Menu
        /// <br/>
        /// towerSet=not null swipeGesture=true (reOpening=false) - When swiping or clicking the left/right buttons
        /// <br/>
        /// towerSet=not null swipeGesture=false (reOpening=false) - When clicking the MonkeyGroupButtons, also the initial call to Open()
        /// <br/>
        /// towerSet=not null swipeGesture=false (reOpening=true) - Called during our calls to Open() to change the buttons
        /// </summary>
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
                else if (!reOpening)
                {
                    // Like on the maps screen, clicking your current MonkeyGroupButton should cycle the set
                    Cycle(Offset + 8);
                }

                return true;
            }

            [HarmonyPostfix]
            internal static void Postfix(MonkeySelectMenu __instance, string towerSet, bool swipeGesture, int __state)
            {
                UpdateTowerSet(__instance, __state);
                UpdatePips();
            }
        }

        [HarmonyPatch(typeof(MonkeyGroupButton), nameof(MonkeyGroupButton.Initialise))]
        internal class MonkeyGroupButton_Initialise
        {
            [HarmonyPrefix]
            internal static bool Prefix(MonkeyGroupButton __instance)
            {
                // Don't re-initialize the MonkeyGroupButtons while we're reloading
                return !reOpening;
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

        [HarmonyPatch(typeof(MonkeySelectMenu), nameof(MonkeySelectMenu.Close))]
        internal class MonkeySelectMenu_Close
        {
            [HarmonyPrefix]
            internal static bool Prefix(MonkeySelectMenu __instance)
            {
                DestroyPips();
                return true;
            }
        }



        private static int TotalPages => TotalSpotses.Values.Sum() / 8;

        private static int CurrentPage => (TotalSpotses.Values.Take(menu.currentSet).Sum() + Offset) / 8;

        internal static GameObject pipHolder;
        internal static List<GameObject> pips = new List<GameObject>();

        internal const int PipCenterX = 800;
        internal const int PipY = 175;
        internal const int PipSpacing = 40;

        internal static void UpdatePips()
        {
            for (var index = 0; index < pips.Count; index++)
            {
                var pip = pips[index];
                if (index == CurrentPage)
                {
                    pip.GetComponent<MapPip>().Activate();
                }
                else
                {
                    pip.GetComponent<MapPip>().Deactivate();
                }
            }
        }
        
        internal static void CreatePips(MonkeySelectMenu __instance)
        {
            DestroyPips();

            pipHolder = new GameObject("PipHolder",
                new Il2CppReferenceArray<Type>(new[] { Il2CppType.Of<RectTransform>() }))
            {
                transform = { parent = __instance.transform}
            };
            var gridLayoutGroup = pipHolder.AddComponent<GridLayoutGroup>();
            gridLayoutGroup.cellSize = new Vector2(64, 64);
            gridLayoutGroup.spacing = new Vector2(25, 0);
            gridLayoutGroup.startAxis = GridLayoutGroup.Axis.Horizontal;
            gridLayoutGroup.childAlignment = TextAnchor.MiddleCenter;
            gridLayoutGroup.constraint = GridLayoutGroup.Constraint.FixedRowCount;
            gridLayoutGroup.constraintCount = 1;
            gridLayoutGroup.startCorner = GridLayoutGroup.Corner.UpperLeft;

            var scale = __instance.monkeyGroupButtons.First().transform.lossyScale;
            var monkeyGroupButtonsPos = __instance.monkeyGroupButtons.First().transform.parent.position;

            pipHolder.transform.position = monkeyGroupButtonsPos + new Vector3(0, 125, 0) * scale.x;
            pipHolder.transform.localScale = new Vector3(1, 1, 1);

            for (var i = 0; i < TotalPages; i++)
            {
                pips.Add(CreatePip(pipHolder.transform));
            }
        }

        internal static GameObject CreatePip(Transform parent)
        {
            var pip = new GameObject("CustomPip",
                new Il2CppReferenceArray<Type>(new[] { Il2CppType.Of<RectTransform>() }))
            {
                transform =
                {
                    parent = parent
                }
            };

            var canvasRenderer = pip.AddComponent<CanvasRenderer>();
            canvasRenderer.cullTransparentMesh = false;
            var image = pip.AddComponent<Image>();
            var mapPip = pip.AddComponent<MapPip>();
            mapPip.activatedSprite = new SpriteReference("Ui[PagePipOn]");
            mapPip.deactivatedSprite = new SpriteReference("Ui[PagePipOff]");
            mapPip.pipImage = image;
            pip.AddComponent<SpriteReleaser>();
            var layoutElement = pip.AddComponent<LayoutElement>();
            layoutElement.preferredHeight = 64;
            layoutElement.preferredWidth = 64;
            layoutElement.useGUILayout = true;

            mapPip.Deactivate();

            pip.transform.localScale = new Vector3(1, 1, 1);

            return pip;
        }

        internal static void DestroyPips()
        {
            foreach (var gameObject in pips)
            {
                Object.Destroy(gameObject);
            }
            pips.Clear();

            if (pipHolder != null)
            {
                Object.Destroy(pipHolder);
                pipHolder = null;
            }
        }
    }
}