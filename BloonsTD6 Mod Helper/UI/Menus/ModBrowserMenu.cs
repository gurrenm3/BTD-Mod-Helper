using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BTD_Mod_Helper.Api;
using BTD_Mod_Helper.Api.Components;
using BTD_Mod_Helper.Api.Enums;
using FuzzySharp.SimilarityRatio;
using FuzzySharp.SimilarityRatio.Scorer;
using FuzzySharp.SimilarityRatio.Scorer.Composite;
using Il2CppAssets.Scripts.Unity.Menu;
using Il2CppAssets.Scripts.Unity.UI_New.ChallengeEditor;
using Il2CppTMPro;
using UnityEngine;
using UnityEngine.UI;
using Object = Il2CppSystem.Object;
namespace BTD_Mod_Helper.UI.Menus;

internal class ModBrowserMenu : ModGameMenu<ContentBrowser>
{
    private const int SearchCutoff = 50;
    private const int TypingCooldown = 30;

    private static int ModsPerPage => MelonMain.ModsPerPage;

    private static bool modsNeedRefreshing;

    private static readonly List<SortingMethod> SortingMethods =
        Enum.GetValues(typeof(SortingMethod)).Cast<SortingMethod>().ToList();

    private ModBrowserMenuMod[] mods;

    private readonly IRatioScorer scorer = ScorerCache.Get<WeightedRatioScorer>();

    private IList<ModHelperData> currentMods;
    private IList<ModHelperData> lastMods;
    private IList<string> topics;
    private IList<string> topicLabels;
    private int currentPage;
    private string currentSearch = "";
    private string currentTopic;

    private SortingMethod sortingMethod = SortingMethod.RecentlyUpdated;

    private int typingCooldown;
    private bool templatesCreated;

    private int TotalPages => 1 + ((currentMods?.Count ?? 1) - 1) / ModsPerPage;

    public override bool OnMenuOpened(Object obj)
    {
        mods = new ModBrowserMenuMod[ModsPerPage];
        sortingMethod = SortingMethod.RecentlyUpdated;
        currentMods = Sort(ModHelperGithub.VisibleMods, sortingMethod);

        var modTopics = ModHelperGithub.VisibleMods.SelectMany(data => data.Topics)
            .Where(s =>
                s != ModHelperGithub.RepoTopic &&
                s != ModHelperGithub.MonoRepoTopic &&
                (!ModHelperGithub.VerifiedOnly || ModHelperGithub.VerifiedTopics.Contains(s)))
            .GroupBy(topic => topic)
            .ToDictionary(grouping => grouping.Key, grouping => grouping.Count());
        
        topics = modTopics
            .OrderByDescending(pair => pair.Value)
            .Select(pair => pair.Key)
            .Prepend(null)
            .ToList();
        topicLabels = modTopics
            .OrderByDescending(pair => pair.Value)
            .Select(pair => $"{pair.Key} ({pair.Value})")
            .Prepend("Filter by Topic")
            .ToList();

        ModifyExistingElements();
        AddNewElements();

        templatesCreated = false;
        MelonCoroutines.Start(CreateModTemplates());

        sortingMethod = SortingMethod.RecentlyUpdated;
        lastMods = ModHelperGithub.Mods;
        currentMods = Sort(ModHelperGithub.VisibleMods, sortingMethod);

        modsNeedRefreshing = true;

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
        GameMenu.GetComponentFromChildrenByName<NK_TextMeshProUGUI>("Title").SetText("Mod Browser");

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
                AnchorMin = new Vector2(0, 1), AnchorMax = new Vector2(1, 1),
            }, layoutAxis: RectTransform.Axis.Horizontal, padding: 50);

        topArea.AddDropdown(new Info("Sorting", 1000, 150),
            SortingMethods.Select(method => method.ToString().Spaced()).ToIl2CppList(), 600,
            new Action<int>(i =>
            {
                sortingMethod = SortingMethods[i];
                RecalculateCurrentMods();
            }), VanillaSprites.BlueInsertPanelRound, 80f);

        topArea.AddPanel(new Info("Filler 1", InfoPreset.Flex));

        topArea.AddInputField(new Info("Searching", 1500, 150), currentSearch,
            VanillaSprites.BlueInsertPanelRound, new Action<string>(
                s =>
                {
                    currentSearch = s;
                    typingCooldown = TypingCooldown;
                }), 80f, TMP_InputField.CharacterValidation.None, TextAlignmentOptions.CaplineLeft, "Search...",
            50);

        topArea.AddPanel(new Info("Filler 2", InfoPreset.Flex));

        topArea.AddDropdown(new Info("Filter", 1000, 150), topicLabels.ToIl2CppList(), 600,
            new Action<int>(i =>
            {
                currentTopic = topics[i];
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
                RecalculateCurrentMods();
            }
        }
    }

    private void RecalculateCurrentMods()
    {
        Task.Run(() =>
        {
            // ModHelper.Log($"Recalculating for '{currentSearch}' and {sortingMethod.ToString()}");
            var filteredMods = ModHelperGithub.VisibleMods
                .Where(data => string.IsNullOrEmpty(currentTopic) || data.Topics.Contains(currentTopic))
                .Where(data => string.IsNullOrEmpty(currentSearch) ||
                               scorer.Score(currentSearch.ToLower(), data.DisplayName.ToLower()) >= SearchCutoff ||
                               scorer.Score(currentSearch.ToLower(), data.RepoOwner.ToLower()) >= SearchCutoff ||
                               scorer.Score(currentSearch.ToLower(), data.DisplayAuthor.ToLower()) >= SearchCutoff);

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

        modsNeedRefreshing = true;

        MenuManager.instance.buttonClick2Sound.Play("ClickSounds");
    }

    private void RefreshMods()
    {
        GameMenu.refreshBtn.interactable = false;
        GameMenu.searchingImg.gameObject.SetActive(true);
        foreach (var menuMod in mods)
        {
            menuMod.SetActive(false);
        }

        Task.Run(async () =>
        {
            await ModHelperGithub.PopulateMods();
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
        _ => mods
    }).ToList();

    private enum SortingMethod
    {
        RecentlyUpdated,
        Popularity,
        Alphabetical,
        New,
        Old
    }
}