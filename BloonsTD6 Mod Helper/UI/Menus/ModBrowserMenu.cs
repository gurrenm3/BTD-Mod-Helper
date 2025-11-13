using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
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
    private static IList<ModHelperData> lastMods;

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
        if (!ModHelperGithub.FullyPopulated)
        {
            RefreshMods();
        }

        var modTopics = ModHelperGithub.VerifiedTopics;

        topics = modTopics.Prepend(null).ToList();
        topicLabels = modTopics.Prepend(FilterByTopic).ToList();

        ModifyExistingElements();
        AddNewElements();

        templatesCreated = false;
        MelonCoroutines.Start(CreateModTemplates());

        sortingMethod = SortingMethod.RecentlyUpdated;
        lastMods = ModHelperGithub.Mods;
        currentMods = Sort(ModHelperGithub.VisibleMods, sortingMethod);

        modsNeedRefreshing = ModHelperGithub.FullyPopulated;
        SetPage(0);
        currentSearch = "";

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
        GameMenu.GetComponentFromChildrenByName<NK_TextMeshProUGUI>("Title").localizeKey = ModBrowser;

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

        GameMenu.refreshBtn.SetOnClick(RefreshMods);
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
        if (!ReferenceEquals(lastMods, ModHelperGithub.Mods))
        {
            ModHelper.Msg("Successfully refreshing after mod population");
            currentMods = Sort(ModHelperGithub.VisibleMods, sortingMethod);
            modsNeedRefreshing = true;
        }
        lastMods = ModHelperGithub.Mods;

        if (modsNeedRefreshing && currentMods.Any())
        {
            MelonCoroutines.Start(UpdateModList());
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
        Task.Run(() =>
        {
            // ModHelper.Log($"Recalculating for '{currentSearch}' and {sortingMethod.ToString()}");
            var filteredMods = ModHelperGithub.VisibleMods
                .Where(data => string.IsNullOrEmpty(currentTopic) || data.Topics.Contains(currentTopic))
                .Where(data => string.IsNullOrEmpty(currentSearch) || Score(data) >= SearchCutoff)
                .ToList();

            currentMods = Sort(filteredMods, sortingMethod);
            modsNeedRefreshing = true;
        });
    }

    private IEnumerator UpdateModList()
    {
        GameMenu.searchingImg.gameObject.SetActive(false);
        GameMenu.requiresInternetObj.SetActive(ModHelperGithub.VerifiedModders.Count == 0);
        while (!templatesCreated)
        {
            yield return null;

            if (Closing) yield break;
        }

        UpdatePagination();
        foreach (var modBrowserMenuMod in mods)
        {
            modBrowserMenuMod.SetActive(false);
        }

        yield return null;

        if (Closing) yield break;

        var pageMods = currentMods.Skip(currentPage * ModsPerPage).Take(ModsPerPage);
        var i = 0;
        foreach (var modHelperData in pageMods)
        {
            mods[i].SetMod(modHelperData);
            i++;
            yield return null;

            if (Closing) yield break;
        }
    }

    private void UpdatePagination()
    {
        GameMenu.refreshBtn.interactable = true;

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

    private void RefreshMods()
    {
        GameMenu.refreshBtn.interactable = false;
        GameMenu.searchingImg.gameObject.SetActive(true);
        foreach (var menuMod in mods)
        {
            menuMod.Exists()?.SetActive(false);
        }

        var populate = ModHelperGithub.PopulateMods(false);

        Task.Run(async () =>
        {
            await populate;
            currentPage = 0;
            RecalculateCurrentMods();
        });
    }

    private static List<ModHelperData> Sort(IEnumerable<ModHelperData> mods, SortingMethod sort) => (sort switch
    {
        SortingMethod.Popularity => mods.OrderByDescending(data => data.Stars),
        SortingMethod.Alphabetical => mods.OrderBy(data => data.DisplayName),
        SortingMethod.RecentlyUpdated => mods.OrderByDescending(data => data.UpdatedAtUtc),
        SortingMethod.New => mods.OrderByDescending(data => data.Repository.CreatedAt),
        SortingMethod.Old => mods.OrderBy(data => data.Repository.CreatedAt),
        SortingMethod.Relevance => mods.OrderByDescending(Score).ThenByDescending(data => data.Stars),
        _ => mods
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