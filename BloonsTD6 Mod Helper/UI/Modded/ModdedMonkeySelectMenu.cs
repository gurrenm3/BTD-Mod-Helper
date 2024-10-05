using System.Collections.Generic;
using System.Linq;
using BTD_Mod_Helper.Api;
using BTD_Mod_Helper.Api.Helpers;
using BTD_Mod_Helper.Api.Towers;
using Il2CppAssets.Scripts.Models.TowerSets;
using Il2CppAssets.Scripts.Unity;
using Il2CppAssets.Scripts.Unity.UI_New.Main;
using Il2CppAssets.Scripts.Unity.UI_New.Main.MapSelect;
using Il2CppAssets.Scripts.Unity.UI_New.Main.MonkeySelect;
using Il2CppInterop.Runtime;
using Il2CppNinjaKiwi.Common.ResourceUtils;
using Il2CppSystem;
using UnityEngine;
using UnityEngine.UI;
using Object = Il2CppSystem.Object;
namespace BTD_Mod_Helper.UI.Modded;

internal class ModdedMonkeySelectMenu
{
    private static MonkeySelectMenu menu;
    private static bool reOpening;
    private static TowerSet currentTowerSet = TowerSet.None;

    private static readonly Dictionary<TowerSet, int> Offsets = new();

    private static readonly Dictionary<TowerSet, List<TowerDetailsModel>> TowersInSets = new();

    // Total amount of towers in each set rounded up to the nearest multiple of 8
    private static readonly Dictionary<TowerSet, int> TotalSpotses = new();

    internal static GameObject pipHolder;
    internal static List<GameObject> pips = new();

    internal static readonly Dictionary<ModTowerSet, GameObject> customMonkeyGroupButtons = new();

    private static int Offset
    {
        get => Offsets[currentTowerSet];
        set => Offsets[currentTowerSet] = value;
    }

    private static int TotalSpots => TotalSpotses[currentTowerSet];

    private static int TotalPages => TotalSpotses.Values.Sum() / 8;

    private static int CurrentPage => (TotalSpotses.Values.Take(menu.currentSet).Sum() + Offset) / 8;


    private static TowerSet FromString(string s) => Enum.TryParse(s, out TowerSet towerSet) ? towerSet :
        ModTowerSet.Cache.TryGetValue(s, out var modTowerSet) ? modTowerSet.Set : TowerSet.None;

    /// <summary>
    /// OnUpdate the currentTowerSet tracker, and change the state if need be
    /// </summary>
    /// <param name="__instance"></param>
    /// <param name="offset"></param>
    internal static void UpdateTowerSet(MonkeySelectMenu __instance, int offset = 0)
    {
        var newTowerSet = MonkeySelectMenu.TowerSets[menu.currentSet];

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
    /// <br />
    /// Their order in the GameModel is what determines their order in the screen
    /// </summary>
    internal static void UpdateGameModel(TowerSet set = TowerSet.None)
    {
        if (set == TowerSet.None)
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

        foreach (var details in model.heroSet)
        {
            model.RemoveChildDependant(details);
            model.AddChildDependant(details);
        }
    }

    /// <summary>
    /// Change the MonkeySelectButtons on the current page
    /// </summary>
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
        menu.Open((int) currentTowerSet);
        reOpening = false;
    }

    public static bool ItComesAfter(TowerSet it, TowerSet maybeAfter)
    {
        var sets = MonkeySelectMenu.TowerSets;
        return (sets.IndexOf(it) - sets.IndexOf(maybeAfter) + sets.Length) % sets.Length == 1;
    }

    public static bool ItComesBefore(TowerSet it, TowerSet maybeBefore)
    {
        var sets = MonkeySelectMenu.TowerSets;
        return (sets.IndexOf(maybeBefore) - sets.IndexOf(it) + sets.Length) % sets.Length == 1;
    }

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

    internal static void CreatePips(MonkeySelectMenu menu)
    {
        DestroyPips();

        pipHolder = new GameObject("PipHolder",
            new Il2CppReferenceArray<Type>(new[] {Il2CppType.Of<RectTransform>()}))
        {
            transform = {parent = menu.transform}
        };
        var gridLayoutGroup = pipHolder.AddComponent<GridLayoutGroup>();
        gridLayoutGroup.cellSize = new Vector2(64, 64);
        gridLayoutGroup.spacing = new Vector2(25, 0);
        gridLayoutGroup.startAxis = GridLayoutGroup.Axis.Horizontal;
        gridLayoutGroup.childAlignment = TextAnchor.MiddleCenter;
        gridLayoutGroup.constraint = GridLayoutGroup.Constraint.FixedRowCount;
        gridLayoutGroup.constraintCount = 1;
        gridLayoutGroup.startCorner = GridLayoutGroup.Corner.UpperLeft;

        var scale = menu.monkeyGroupButtons[0].transform.lossyScale;
        var monkeyGroupButtonsPos = menu.monkeyGroupButtons[0].transform.parent.position;

        pipHolder.transform.position = monkeyGroupButtonsPos + new Vector3(0, 350, 0) * scale.x;
        pipHolder.transform.localScale = new Vector3(1, 1, 1);

        for (var i = 0; i < TotalPages; i++)
        {
            pips.Add(CreatePip(pipHolder.transform, menu));
        }
    }

    internal static GameObject CreatePip(Transform parent, MonkeySelectMenu menu)
    {
        var pip = new GameObject("CustomPip",
            new Il2CppReferenceArray<Type>(new[] {Il2CppType.Of<RectTransform>()}))
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
        mapPip.activatedSprite = ModContent.CreateSpriteReference("Ui[PagePipOn]");
        mapPip.deactivatedSprite = ModContent.CreateSpriteReference("Ui[PagePipOff]");
        mapPip.pipImage = image;
        pip.AddComponent<SpriteReleaser>();
        var layoutElement = pip.AddComponent<LayoutElement>();
        layoutElement.preferredHeight = 64;
        layoutElement.preferredWidth = 64;
        layoutElement.useGUILayout = true;
        var matchScale = pip.AddComponent<MatchScale>();
        matchScale.transformToCopy = menu.towerButtons[0].transform.parent;

        mapPip.Deactivate();

        pip.transform.localScale = new Vector3(1, 1, 1);

        return pip;
    }

    internal static void CreateCustomButtons(MonkeySelectMenu __instance)
    {
        DestroyCustomButtons();

        var monkeyGroupButtons = new List<MonkeyGroupButton>(__instance.monkeyGroupButtons);
        var horizontalLayoutGroup = __instance.monkeyGroupButtons[0].GetComponentInParent<HorizontalLayoutGroup>();
        foreach (var modTowerSet in ModContent.GetContent<ModTowerSet>())
        {
            horizontalLayoutGroup.enabled = true;
            var index = modTowerSet.GetTowerSetIndex(monkeyGroupButtons.Select(b => FromString(b.groupName)).ToList());
            var groupButton = CreateMonkeyGroupButton(__instance, modTowerSet);
            groupButton.transform.SetSiblingIndex(index);
            customMonkeyGroupButtons[modTowerSet] = groupButton;
            monkeyGroupButtons.Insert(index, groupButton.GetComponent<MonkeyGroupButton>());
        }

        __instance.monkeyGroupButtons = monkeyGroupButtons.ToArray();
    }

    internal static GameObject CreateMonkeyGroupButton(MonkeySelectMenu instance, ModTowerSet modTowerSet)
    {
        var primary = instance.monkeyGroupButtons.First(button => button.groupName == "Primary");
        var groupButton = UnityEngine.Object.Instantiate(primary.gameObject, primary.transform.parent);
        var monkeyGroupButton = groupButton.GetComponent<MonkeyGroupButton>();
        monkeyGroupButton.groupName = modTowerSet.Id;
        groupButton.name = modTowerSet.Id;
        groupButton.GetComponentInChildren<NK_TextMeshProUGUI>().localizeKey = modTowerSet.Id;
        ResourceLoader.LoadSpriteFromSpriteReferenceAsync(modTowerSet.ButtonReference, monkeyGroupButton.icon);
        monkeyGroupButton.button.SetOnClick(() => menu.SwitchTowerSet(modTowerSet.Set));
        TaskScheduler.ScheduleTask(() => monkeyGroupButton.SetLocked(false));
        return groupButton;
    }

    internal static void DestroyPips()
    {
        foreach (var gameObject in pips)
        {
            UnityEngine.Object.Destroy(gameObject);
        }

        pips.Clear();

        if (pipHolder != null)
        {
            UnityEngine.Object.Destroy(pipHolder);
            pipHolder = null;
        }
    }

    internal static void DestroyCustomButtons()
    {
        foreach (var gameObject in customMonkeyGroupButtons.Values)
        {
            UnityEngine.Object.Destroy(gameObject);
        }

        customMonkeyGroupButtons.Clear();
    }

    #region Nested type: MainMenu_Awake

    [HarmonyPatch(typeof(MainMenu), nameof(MainMenu.Start))]
    internal class MainMenu_Awake
    {
        [HarmonyPostfix]
        internal static void Postfix(MainMenu __instance)
        {
            ResetGameModel();
        }
    }

    #endregion
    #region Nested type: MonkeyGroupButton_Initialise

    [HarmonyPatch(typeof(MonkeyGroupButton), nameof(MonkeyGroupButton.Initialise))]
    internal class MonkeyGroupButton_Initialise
    {
        [HarmonyPrefix]
        internal static bool Prefix(MonkeyGroupButton __instance) =>
            // Don't re-initialize the MonkeyGroupButtons while we're reloading
            !reOpening;
    }

    #endregion
    #region Nested type: MonkeySelectMenu_Open

    [HarmonyPatch(typeof(MonkeySelectMenu), nameof(MonkeySelectMenu.Open))]
    internal class MonkeySelectMenu_Open
    {
        [HarmonyPrefix]
        internal static void Prefix(MonkeySelectMenu __instance, Object data)
        {
            if (!reOpening)
            {
                var towerSets = new List<TowerSet>(MonkeySelectMenu.TowerSets);
                foreach (var modTowerSet in ModContent.GetContent<ModTowerSet>())
                {
                    if (towerSets.Contains(modTowerSet.Set)) continue;

                    var towerSetIndex = modTowerSet.GetTowerSetIndex(towerSets);
                    towerSets.Insert(towerSetIndex, modTowerSet.Set);
                }
                MonkeySelectMenu.TowerSets = towerSets.ToArray();
            }

            if (data == null)
            {
                menu = null;

                var model = Game.instance.model;
                foreach (var set in MonkeySelectMenu.TowerSets)
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
                CreateCustomButtons(__instance);
            }
        }

        [HarmonyPostfix]
        internal static void Postfix(MonkeySelectMenu __instance, Object data)
        {
            menu = __instance;
            UpdateTowerSet(__instance);
            UpdatePips();
        }
    }

    #endregion
    #region Nested type: MonkeySelectMenu_SwitchTowerSet

    /// <summary>
    /// Possible inputs:
    /// <br />
    /// towerSet=null swipeGesture=false (reOpening=false) - When opening the MonkeySelectMenu from the Main Menu
    /// <br />
    /// towerSet=not null swipeGesture=true (reOpening=false) - When swiping or clicking the left/right buttons
    /// <br />
    /// towerSet=not null swipeGesture=false (reOpening=false) - When clicking the MonkeyGroupButtons, also the initial call to
    /// Open()
    /// <br />
    /// towerSet=not null swipeGesture=false (reOpening=true) - Called during our calls to Open() to change the buttons
    /// </summary>
    [HarmonyPatch(typeof(MonkeySelectMenu), nameof(MonkeySelectMenu.SwitchTowerSet))]
    internal class MonkeySelectMenu_SwitchTowerSet
    {
        [HarmonyPrefix]
        internal static bool Prefix(MonkeySelectMenu __instance, ref TowerSet towerSet, bool swipeGesture,
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

    #endregion
}