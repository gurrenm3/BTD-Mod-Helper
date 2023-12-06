using System;
using System.Collections.Generic;
using BTD_Mod_Helper.Api.Components;
using Il2CppAssets.Scripts;
using Il2CppAssets.Scripts.Unity.Audio;
using Il2CppAssets.Scripts.Unity.CollectionEvent;
using Il2CppAssets.Scripts.Unity.Menu;
using Il2CppAssets.Scripts.Unity.UI_New;
using Il2CppAssets.Scripts.Unity.UI_New.Achievements;
using Il2CppAssets.Scripts.Unity.UI_New.ChallengeEditor;
using Il2CppAssets.Scripts.Unity.UI_New.Coop;
using Il2CppAssets.Scripts.Unity.UI_New.GameEvents;
using Il2CppAssets.Scripts.Unity.UI_New.HeroInGame;
using Il2CppAssets.Scripts.Unity.UI_New.InGame.EditorMenus;
using Il2CppAssets.Scripts.Unity.UI_New.LevelUp;
using Il2CppAssets.Scripts.Unity.UI_New.Main.PowersSelect;
using Il2CppAssets.Scripts.Unity.UI_New.Settings;
using Object = Il2CppSystem.Object;
namespace BTD_Mod_Helper.Api;

/// <summary>
/// Class for a custom BTD6 menu
/// </summary>
public abstract class ModGameMenu : ModContent
{
    internal static readonly Dictionary<string, ModGameMenu> Cache = new();

    internal static readonly Dictionary<Type, string> Types = new()
    {
        {typeof(ExtraSettingsScreen), SceneNames.ExtraSettingsUI},
        {typeof(SettingsScreen), SceneNames.SettingsUI},
        {typeof(PowersSelectScreen), SceneNames.PowersSelectUI},
        //{typeof(TwitchSettingsUI), "TwitchSettingsUI"},
        {typeof(HotkeysScreen), SceneNames.HotkeysUI},
        {typeof(JukeBoxScreen), SceneNames.JukeboxUI},
        {typeof(CollectionEventUI), SceneNames.CollectionEventUI},
        {typeof(AchievementsScreen), SceneNames.AchievementsUI},
        {typeof(PlaySocialScreen), SceneNames.PlaySocial},
        {typeof(GameEventsScreen), SceneNames.GameEventsUI},
        {typeof(HeroInGameScreen), SceneNames.HeroInGameUI},
        {typeof(LevelUpScreen), SceneNames.LevelUpUI},
        {typeof(ContentBrowser), SceneNames.ContentBrowser},
        {typeof(MapEditorScreen), SceneNames.MapEditorUI},
        {typeof(ChallengeEditorPlay), SceneNames.ChallengeEditorPlay}
    };


    internal static readonly Dictionary<Type, string> DataNames = new()
    {
        {typeof(ExtraSettingsScreen), "menuData"},
        {typeof(SettingsScreen), "menuData"},
        {typeof(HotkeysScreen), "menuData"}
    };

    /// <summary>
    /// The text of the Header component that's on many UI screens, might be null
    /// </summary>
    protected NK_TextMeshProUGUI CommonForegroundHeader =>
        CommonForegroundScreen.instance.heading.GetComponentInChildren<NK_TextMeshProUGUI>();

    /// <summary>
    /// Whether the menu is currently closing
    /// </summary>
    protected internal bool Closing { get; internal set; }

    /// <summary>
    /// The string name of the in game menu to copy from
    /// </summary>
    public abstract string BaseMenu { get; }

    /// <summary>
    /// Whether this Menu is open or not
    /// </summary>
    public bool IsOpen { get; internal set; }

    /// <summary>
    /// The current GameMenu
    /// </summary>
    public GameMenu GameMenu { get; private set; }

    /// <inheritdoc />
    public override void Register()
    {
        Cache[Id] = this;
    }

    /// <summary>
    /// Runs right as your custom menu is being opened, with the optional data argument that can be passed into
    /// <see cref="Open{T}(Il2CppSystem.Object,Il2CppSystem.Object)" />
    /// </summary>
    /// <returns>Whether to run the base menu's OnOpen code</returns>
    public abstract bool OnMenuOpened(Object data);

    /// <summary>
    /// Runs right as your custom menu is being closed
    /// </summary>
    public virtual void OnMenuClosed()
    {
    }

    /// <summary>
    /// Runs every time that your custom menu updates
    /// </summary>
    public virtual void OnMenuUpdate()
    {
    }


    /// <summary>
    /// The name NinjaKiwi gave to the menu of the given screen type
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <returns></returns>
    protected static string MenuName<T>() where T : GameMenu => Types.TryGetValue(typeof(T), out var menuName)
        ? menuName
        : typeof(T).Name.Replace("Screen", "UI");

    internal static bool CheckOpen(GameMenu gameMenu, Object data, out Object outData)
    {
        if (data != null &&
            data.IsType(out ModMenuData menuData) &&
            GetContent<ModGameMenu>().Find(menu => menu.Id == menuData.id) is ModGameMenu modGameMenu)
        {
            outData = menuData.baseData;
            var tracker = gameMenu.gameObject.AddComponent<ModGameMenuTracker>();
            tracker.modGameMenuId = modGameMenu.Id;

            modGameMenu.GameMenu = gameMenu;
            modGameMenu.Closing = false;
            return gameMenu.enabled = modGameMenu.OnMenuOpened(menuData.modData);
        }

        outData = data;
        return true;
    }


    /// <summary>
    /// Opens a custom menu
    /// </summary>
    /// <param name="data">The custom data to pass into your ModGameMenu's <see cref="OnMenuOpened" /> method</param>
    /// <param name="baseData">
    /// The data that you want to pass into the base menu's Open method, if you're still running the
    /// code
    /// </param>
    /// <typeparam name="T">The custom menu type to open</typeparam>
    public static void Open<T>(Object data = null, Object baseData = null) where T : ModGameMenu
    {
        var modGameMenu = GetInstance<T>();
        modGameMenu.IsOpen = true;
        MenuManager.instance.OpenMenu(modGameMenu.BaseMenu, new ModMenuData(modGameMenu.Id, data, baseData));
    }

    internal static void PatchAllTheOpens(HarmonyLib.Harmony harmony)
    {
        foreach (var type in Types.Keys)
        {
            if (MelonUtils.IsUnderWineOrSteamProton() && type == typeof(AchievementsScreen)) continue;

            var data = DataNames.GetValueOrDefault(type, "data");
            try
            {
                harmony.PatchPrefix(type, "Open", typeof(ModGameMenu), "Patch_" + data);
            }
            catch (Exception e)
            {
                ModHelper.Warning($"Failed to apply Open patch for {type.Name}");
                ModHelper.Warning(e);
            }
        }
    }

    private static bool Patch_data(GameMenu __instance, ref Object data) => CheckOpen(__instance, data, out data);

    private static bool Patch_menuData(GameMenu __instance, ref Object menuData) =>
        CheckOpen(__instance, menuData, out menuData);
}

/// <summary>
/// Generic class for creating a ModGameMenu with the given type as it's base menu
/// </summary>
public abstract class ModGameMenu<T> : ModGameMenu where T : GameMenu
{
    /// <inheritdoc />
    public override string BaseMenu => MenuName<T>();

    /// <inheritdoc cref="ModGameMenu.GameMenu" />
    public new T GameMenu => base.GameMenu.Cast<T>();
}