using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using BTD_Mod_Helper.Api;
using BTD_Mod_Helper.Api.Components;
using BTD_Mod_Helper.Api.Enums;
using BTD_Mod_Helper.Api.Helpers;
using BTD_Mod_Helper.Api.Internal;
using FuzzySharp.SimilarityRatio;
using FuzzySharp.SimilarityRatio.Scorer;
using FuzzySharp.SimilarityRatio.Scorer.Composite;
using Il2CppAssets.Scripts.Unity.Menu;
using Il2CppAssets.Scripts.Unity.UI_New.ChallengeEditor;
using Il2CppTMPro;
using UnityEngine;
using UnityEngine.UI;
using ModHelperData = BTD_Mod_Helper.Api.Data.ModHelperData;
using Object = Il2CppSystem.Object;
namespace BTD_Mod_Helper.UI.Menus;

internal class ModBrowserMenu : ModGameMenu<ContentBrowser>
{
    private const int SearchCutoff = 50;
    private const int TypingCooldown = 30;

    private static bool modsNeedRefreshing;

    private static readonly List<SortingMethod> SortingMethods =
        Enum.GetValues(typeof(SortingMethod)).Cast<SortingMethod>().ToList();

    private static readonly List<string> SortingMethodNames =
        SortingMethods.Select(method => ModHelper.Localize(method.ToString(), method.ToString().Spaced())).ToList();

    private static readonly IRatioScorer Scorer = ScorerCache.Get<WeightedRatioScorer>();

    private static IList<ModHelperData> currentMods = [];
    private static int currentPage;
    private static string currentSearch = "";
    private string currentTopic;

    private static ModBrowserMenuMod[] mods;

    private static SortingMethod sortingMethod = SortingMethod.RecentlyUpdated;
    private static bool templatesCreated;
    private IList<string> topicLabels;
    private IList<string> topics;

    private static int typingCooldown;

    private static int ModsPerPage => MelonMain.ModsPerPage;

    private static int TotalPages => 1 + ((currentMods?.Count ?? 1) - 1) / ModsPerPage;

    private static readonly string FilterByTopic = ModHelper.Localize(nameof(FilterByTopic), "Filter by Topic");
    private static readonly string ModBrowser = ModHelper.Localize(nameof(ModBrowser), "Mod Browser");

    private static ModHelperDropdown sortingDropdown = null!;

    public override bool OnMenuOpened(Object data)
    {
        mods = new ModBrowserMenuMod[ModsPerPage];

        topics = ModHelperGithub.VerifiedTopics.Prepend(null).ToList();
        topicLabels = ModHelperGithub.VerifiedTopics.Prepend(FilterByTopic).ToList();

        ModifyExistingElements();
        AddNewElements();

        templatesCreated = false;
        CreateModTemplates().StartCoroutine();

        sortingMethod = SortingMethod.RecentlyUpdated;
        currentMods = Sort(ModHelperGithub.VisibleMods, sortingMethod);

        SetPage(0);
        currentSearch = "";

        if (ModHelperGithub.FullyPopulated)
        {
            GameMenu.refreshBtn.interactable = true;
            modsNeedRefreshing = true;
        }
        else
        {
            GameMenu.refreshBtn.interactable = false;
            RefreshMods().StartCoroutine();
        }

        return false;
    }

    public IEnumerator CreateModTemplates()
    {
        var template =
            GameMenu.scrollRect.content.gameObject.AddModHelperComponent(ModBrowserMenuMod.CreateTemplate());

        yield return null;

        if (Closing) yield break;

        for (var i = 0; i < ModsPerPage; i++)
        {
            var newMod = mods[i] = template.Duplicate($"Mod {i}");
            newMod.AddTo(GameMenu.scrollRect.content);
            newMod.SetActive(false);
            yield return null;

            if (Closing) yield break;
        }

        templatesCreated = true;
    }

    public void ModifyExistingElements()
    {
        var title = GameMenu.GetComponentFromChildrenByName<NK_TextMeshProUGUI>("Title");
        title.localizeKey = ModBrowser;
        title.UpdateText(ModBrowser.Localize());

        GameMenu.GetComponentFromChildrenByName<RectTransform>("TopBar").gameObject.active = false;
        GameMenu.GetComponentFromChildrenByName<RectTransform>("Tabs").gameObject.active = false;

        var verticalLayoutGroup = GameMenu.scrollRect.content.GetComponent<VerticalLayoutGroup>();
        verticalLayoutGroup.SetPadding(50);
        verticalLayoutGroup.spacing = 50;
        verticalLayoutGroup.childControlWidth = true;
        verticalLayoutGroup.childControlHeight = true;
        GameMenu.scrollRect.rectTransform.sizeDelta += new Vector2(0, 200);
        GameMenu.scrollRect.rectTransform.localPosition += new Vector3(0, 100, 0);

        GameMenu.searchingImg.gameObject.SetActive(true);
        GameMenu.requiresInternetObj.SetActive(ModHelperGithub.VerifiedModders.Count == 0);

        GameMenu.refreshBtn.SetOnClick(() => RefreshMods().StartCoroutine());
        GameMenu.firstPageBtn.SetOnClick(() => SetPage(0));
        GameMenu.previousPageBtn.SetOnClick(() => SetPage(currentPage - 1));
        GameMenu.nextPageBtn.SetOnClick(() => SetPage(currentPage + 1));
        GameMenu.lastPageBtn.SetOnClick(() => SetPage(TotalPages - 1));
    }

    public void AddNewElements()
    {
        var topArea = GameMenu.GetComponentFromChildrenByName<RectTransform>("Container").gameObject
            .AddModHelperPanel(new Info("TopArea")
            {
                Y = -325, Height = 200, Pivot = new Vector2(0.5f, 1),
                AnchorMin = new Vector2(0, 1), AnchorMax = new Vector2(1, 1)
            }, layoutAxis: RectTransform.Axis.Horizontal, padding: 50);

        sortingDropdown = topArea.AddDropdown(new Info("Sorting", 1000, 150), SortingMethodNames.ToIl2CppList(), 600,
            new Action<int>(i =>
            {
                sortingMethod = SortingMethods[i];
                SetPage(0);
                RecalculateCurrentMods();
            }), VanillaSprites.BlueInsertPanelRound, 80f);

        topArea.AddPanel(new Info("Filler 1", InfoPreset.Flex));

        topArea.AddInputField(new Info("Searching", 1500, 150), currentSearch,
            VanillaSprites.BlueInsertPanelRound, new Action<string>(s =>
            {
                currentSearch = s;
                typingCooldown = TypingCooldown;
                SetPage(0);
            }), 80f, TMP_InputField.CharacterValidation.None, TextAlignmentOptions.CaplineLeft,
            LocalizationHelper.SearchText.Localize(),
            50);

        topArea.AddPanel(new Info("Filler 2", InfoPreset.Flex));

        topArea.AddDropdown(new Info("Filter", 1000, 150), topicLabels.ToIl2CppList(), 600,
            new Action<int>(i =>
            {
                currentTopic = topics[i];
                currentSearch = "";
                SetPage(0);
                RecalculateCurrentMods();
            }), VanillaSprites.BlueInsertPanelRound, 80f);
    }

    public override void OnMenuUpdate()
    {
        if (modsNeedRefreshing && templatesCreated && currentMods.Any())
        {
            UpdateModList();
            modsNeedRefreshing = false;
        }

        if (typingCooldown > 0)
        {
            typingCooldown--;
            if (typingCooldown == 0)
            {
                if (!string.IsNullOrEmpty(currentSearch) && sortingMethod != SortingMethod.Relevance)
                {
                    sortingDropdown.Dropdown.SetValue((int) SortingMethod.Relevance);
                }
                else if (string.IsNullOrEmpty(currentSearch) && sortingMethod == SortingMethod.Relevance)
                {
                    sortingDropdown.Dropdown.SetValue((int) SortingMethod.Popularity);
                }
                else
                {
                    RecalculateCurrentMods();
                }
            }
        }
    }

    private static int Score(ModHelperData data) => string.IsNullOrEmpty(currentSearch)
        ? 0
        : new[]
            {
                data.DisplayName?.NullIfEmpty()?.ToLower(),
                data.RepoName?.NullIfEmpty()?.ToLower(),
                data.RepoOwner?.NullIfEmpty()?.ToLower(),
                data.Author?.NullIfEmpty()?.ToLower(),
                data.Description?.NullIfEmpty()?.ToLower(),
                data.DllName?.NullIfEmpty()?.ToLower(),
                data.Topics.Join(delimiter: ", ")
            }.Where(s => s != null)
            .Max(value => Scorer.Score(currentSearch.ToLower(), value!.ToLower()));

    private void RecalculateCurrentMods()
    {
        var filteredMods = ModHelperGithub.VisibleMods
            .Where(data => (string.IsNullOrEmpty(currentTopic) || data.Topics.Contains(currentTopic)) &&
                           (string.IsNullOrEmpty(currentSearch) || Score(data) >= SearchCutoff))
            .ToList();

        currentMods = Sort(filteredMods, sortingMethod);
        modsNeedRefreshing = true;
    }

    private void UpdateModList()
    {
        GameMenu.searchingImg.gameObject.SetActive(false);
        GameMenu.requiresInternetObj.SetActive(ModHelperGithub.VerifiedModders.Count == 0);

        UpdatePagination();
        foreach (var modBrowserMenuMod in mods)
        {
            modBrowserMenuMod.SetActive(false);
        }

        var pageMods = currentMods.Skip(currentPage * ModsPerPage).Take(ModsPerPage).ToArray();

        var modsList = mods.ToList();
        for (var i = 0; i < pageMods.Length; i++)
        {
            var modHelperData = pageMods[i];
            if (modsList.Find(m => m.mod == modHelperData) is { } menuMod)
            {
                modsList.Remove(menuMod);
                modsList.Insert(i, menuMod);
            }
        }
        mods = modsList.ToArray();
        for (var i = 0; i < mods.Length; i++)
        {
            var m = mods[i];
            m.transform.SetSiblingIndex(i);
        }

        for (var i = 0; i < pageMods.Length; i++)
        {
            mods[i].SetMod(pageMods[i]);
        }
    }

    private void UpdatePagination()
    {
        GameMenu.firstPageBtn.interactable = TotalPages >= 2 && currentPage > 0;
        GameMenu.previousPageBtn.interactable = TotalPages >= 2 && currentPage > 0;

        GameMenu.nextPageBtn.interactable = TotalPages >= 2 && currentPage < TotalPages - 1;
        GameMenu.lastPageBtn.interactable = TotalPages >= 2 && currentPage < TotalPages - 1;

        GameMenu.totalPages = TotalPages;
        GameMenu.SetCurrentPage(currentPage + 1);
    }

    private void SetPage(int page)
    {
        if (currentPage != page)
        {
            GameMenu.scrollRect.verticalNormalizedPosition = 1f;
            modsNeedRefreshing = true;
            MenuManager.instance.buttonClick2Sound.Play("ClickSounds");
        }
        currentPage = page;
        if (currentPage < 0)
        {
            currentPage = 0;
        }
        if (currentPage > TotalPages - 1)
        {
            currentPage = TotalPages - 1;
        }
    }

    private IEnumerator RefreshMods()
    {
        if (ModHelperGithub.populatingMods != null && !ModHelperGithub.populatingMods.IsCompleted) yield break;

        GameMenu.refreshBtn.interactable = false;
        GameMenu.searchingImg.gameObject.SetActive(true);
        foreach (var menuMod in mods)
        {
            menuMod.Exists()?.SetActive(false);
        }

        ModHelperGithub.populatingMods = ModHelperGithub.PopulateMods(false);

        var lastCount = 0;
        while (!ModHelperGithub.populatingMods.IsCompleted)
        {
            yield return new WaitForSecondsRealtime(0.5f);

            var newCount = ModHelperGithub.VisibleMods.Count();
            if (newCount > lastCount)
            {
                lastCount = newCount;

                RecalculateCurrentMods();
            }
        }

        RecalculateCurrentMods();

        if (GameMenu == null || GameMenu.refreshBtn == null) yield break;
        GameMenu.refreshBtn.interactable = true;
    }


    private static List<ModHelperData> Sort(IEnumerable<ModHelperData> data, SortingMethod sort) => (sort switch
    {
        SortingMethod.Popularity => data.OrderByDescending(mod => mod.Stars),
        SortingMethod.Alphabetical => data.OrderBy(mod => mod.DisplayName),
        SortingMethod.RecentlyUpdated => data.OrderByDescending(mod => mod.UpdatedAtUtc),
        SortingMethod.New => data.OrderByDescending(mod => mod.Repository.CreatedAt),
        SortingMethod.Old => data.OrderBy(mod => mod.Repository.CreatedAt),
        SortingMethod.Relevance => data.OrderByDescending(Score).ThenByDescending(mod => mod.Stars),
        _ => data
    }).ToList();

    private enum SortingMethod
    {
        RecentlyUpdated,
        Popularity,
        Alphabetical,
        New,
        Old,
        Relevance
    }
}