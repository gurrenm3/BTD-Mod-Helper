using System.Collections.Generic;
using System.Linq;
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
using Il2CppAssets.Scripts.Unity.UI_New.LevelUp;
using Il2CppAssets.Scripts.Unity.UI_New.Main.PowersSelect;
using Il2CppAssets.Scripts.Unity.UI_New.Settings;
using Il2CppSystem;
using Exception = System.Exception;
using Type = System.Type;
namespace BTD_Mod_Helper.Api;

/// <summary>
/// Class for a custom BTD6 menu
/// </summary>
public abstract class ModGameMenu : ModContent
{
    internal static readonly Dictionary<string, ModGameMenu> Cache = new();

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

    /// <inheritdoc />
    public override void Register()
    {
        Cache[Id] = this;
    }

    /// <summary>
    /// The current GameMenu
    /// </summary>
    public GameMenu GameMenu { get; private set; }

    /// <summary>
    /// Runs right as your custom menu is being opened, with the optional data argument that can be passed into
    /// <see cref="Open{T}(Il2CppSystem.Object,Il2CppSystem.Object)"/>
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
    protected static string MenuName<T>() where T : GameMenu
    {
        return Types.TryGetValue(typeof(T), out var info) ? info.name : typeof(T).Name.Replace("Screen", "UI");
    }

    internal static bool CheckOpen(GameMenu gameMenu, Object data, out Object outData)
    {
        if (data != null &&
            data.IsType(out ModMenuData menuData) &&
            GetContent<ModGameMenu>().FirstOrDefault(menu => menu.Id == menuData.id) is ModGameMenu modGameMenu)
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
    /// <param name="data">The custom data to pass into your ModGameMenu's <see cref="OnMenuOpened"/> method</param>
    /// <param name="baseData">The data that you want to pass into the base menu's Open method, if you're still running the code</param>
    /// <typeparam name="T">The custom menu type to open</typeparam>
    public static void Open<T>(Object data = null, Object baseData = null) where T : ModGameMenu
    {
        var modGameMenu = GetInstance<T>();
        modGameMenu.IsOpen = true;
        MenuManager.instance.OpenMenu(modGameMenu.BaseMenu, new ModMenuData(modGameMenu.Id, data, baseData));
    }

    internal static readonly Dictionary<Type, (string name, string data)> Types = new()
    {
        {typeof(ExtraSettingsScreen), (SceneNames.ExtraSettingsUI, "menuData")},
        {typeof(SettingsScreen), (SceneNames.SettingsUI, "menuData")},
        {typeof(PowersSelectScreen), (SceneNames.PowersSelectUI, "data")},
        //{typeof(TwitchSettingsUI), ("TwitchSettingsUI", "data")},
        {typeof(HotkeysScreen), (SceneNames.HotkeysUI, "menuData")},
        {typeof(JukeBoxScreen), (SceneNames.JukeboxUI, "data")},
        {typeof(CollectionEventUI), (SceneNames.CollectionEventUI, "data")},
        {typeof(AchievementsScreen), (SceneNames.AchievementsUI, "data")},
        {typeof(PlaySocialScreen), (SceneNames.PlaySocial, "data")},
        {typeof(GameEventsScreen), (SceneNames.GameEventsUI, "data")},
        {typeof(HeroInGameScreen), (SceneNames.HeroInGameUI, "data")},
        {typeof(LevelUpScreen), (SceneNames.LevelUpUI, "data")},
        {typeof(ContentBrowser), (SceneNames.ContentBrowser, "data")}
    };

    internal static void PatchAllTheOpens(HarmonyLib.Harmony harmony)
    {
        foreach (var (type, (_, data)) in Types)
        {
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

    private static bool Patch_data(GameMenu __instance, ref Object data)
    {
        return CheckOpen(__instance, data, out data);
    }

    private static bool Patch_menuData(GameMenu __instance, ref Object menuData)
    {
        return CheckOpen(__instance, menuData, out menuData);
    }
}

/// <summary>
/// Generic class for creating a ModGameMenu with the given type as it's base menu
/// </summary>
public abstract class ModGameMenu<T> : ModGameMenu where T : GameMenu
{
    /// <inheritdoc />
    public override string BaseMenu => MenuName<T>();

    /// <inheritdoc cref="ModGameMenu.GameMenu"/>
    public new T GameMenu => base.GameMenu.Cast<T>();
}