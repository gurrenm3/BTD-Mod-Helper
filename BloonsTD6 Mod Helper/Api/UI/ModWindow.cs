using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;
using BTD_Mod_Helper.Api.Components;
using Il2CppAssets.Scripts.Unity.UI_New.InGame;
using Il2CppSystem;
using Newtonsoft.Json.Linq;
using UnityEngine;
using Exception = System.Exception;

namespace BTD_Mod_Helper.Api.UI;

/// <summary>
/// Defines a kind of Window that can be opened in game from the custom Mod Helper start menu with specific name and content
/// </summary>
public abstract class ModWindow : ModStartMenuEntry
{
    internal static readonly Dictionary<string, SavedModWindow> SavedWindows = new();
    internal static bool saveSettingsAfterGame;
    internal static readonly Dictionary<string, ModWindow> Cache = new();

    /// <summary>
    /// Default width of the window
    /// </summary>
    public virtual int DefaultWidth => 1500;

    /// <summary>
    /// Default height of the window
    /// </summary>
    public virtual int DefaultHeight => 1000;

    /// <summary>
    /// Minimum width of the window when resizing
    /// </summary>
    public virtual int MinimumWidth => 500;

    /// <summary>
    /// Minimum height of the window when resizing
    /// </summary>
    public virtual int MinimumHeight => 250;

    /// <summary>
    /// Height of the top bar of the window which has the Close, Settings, and Minimize buttons by default
    /// </summary>
    public virtual int TopBarHeight => 50;

    /// <summary>
    /// Whether the user should be able to resize the window
    /// </summary>
    public virtual bool AllowResizing => true;

    /// <summary>
    /// What name this should display within the Dock. It's a small space by default, so the shorter the better. null for no text
    /// </summary>
    public virtual string DockName => DisplayName;

    /// <summary>
    /// Width of the button in the dock for this Window
    /// </summary>
    public virtual int DockButtonWidth => 200;

    /// <summary>
    /// Whether the window should show its icon in the upper left
    /// </summary>
    public virtual bool ShowIconOnWindow => true;

    /// <summary>
    /// Whether the window should show its title in the upper left
    /// </summary>
    public virtual bool ShowTitleOnWindow => true;

    /// <summary>
    /// Whether the dock entry should show the icon
    /// </summary>
    public virtual bool ShowIconInDock => true;

    /// <summary>
    /// Whether to rotate the dock icon so that it's facing upwards in the 16x9 aspect ratio dock setup
    /// </summary>
    public virtual bool RotateDockIcon => false;

    /// <summary>
    /// Whether to allow more than one of this window to be opened at once
    /// </summary>
    public virtual bool AllowMultiple => true;

    /// <summary>
    /// Whether to hide top bar elements when the window is sized too small so they would overlap
    /// </summary>
    public virtual bool HideOverlappingTopBarItems => true;

    internal readonly List<ModHelperWindow> openedWindows = [];

    /// <summary>
    /// All window instances that have been opened for this type of ModWindow. They may be minimized
    /// </summary>
    public IReadOnlyList<ModHelperWindow> OpenedWindows => openedWindows.AsReadOnly();

    /// <summary>
    /// All window instances that have been opened for this type of ModWindow and are currently not minimized
    /// </summary>
    public IReadOnlyList<ModHelperWindow> ActiveWindows =>
        openedWindows.Where(window => window != null && !window.IsMinimized).ToImmutableList();

    /// <summary>
    /// Override to change the default window color to something other than the user's defined default
    /// </summary>
    public virtual ModWindowColor DefaultWindowColor => MelonMain.CurrentDefaultWindowColor;

    /// <inheritdoc />
    public override void StartMenuEntryClicked()
    {
        Open();
    }

    /// <inheritdoc />
    public override void RegisterText(Il2CppSystem.Collections.Generic.Dictionary<string, string> textTable)
    {
        textTable[Id + " Short"] = DockName;
    }

    /// <inheritdoc />
    public sealed override void Register()
    {
        base.Register();
        Cache[Id] = this;
    }

    /// <summary>
    /// The Mod Helper <see cref="Info"/> used to initially define the <see cref="ModHelperWindow"/>
    /// </summary>
    public virtual Info WindowInfo => new(Name)
    {
        Width = DefaultWidth,
        Height = DefaultHeight,
        Anchor = new Vector2(0, 0),
        Pivot = new Vector2(0, 0),
        Position = new Vector2(ModHelperWindow.Margin, ModHelperWindow.Margin)
    };

    /// <summary>
    /// Opens a new <see cref="ModHelperWindow"/> for this window in game
    /// </summary>
    /// <returns>the ModModHelperWindow </returns>
    public ModHelperWindow Open()
    {
        if (InGame.instance == null) return null;

        var window = ModHelperWindow.Create(this);

        ModifyWindow(window);
        ModifyOptionsMenu(window, window.rightClickMenu);

        openedWindows.Add(window);

        return window;
    }

    /// <summary>
    /// Modifies the initial content of the window.
    /// Adding UI to <see cref="ModHelperWindow.content"/> and <see cref="ModHelperWindow.topLeftGroup"/> is most common
    /// </summary>
    /// <param name="window">the ModHelperWindow instance being created</param>
    public abstract void ModifyWindow(ModHelperWindow window);

    /// <summary>
    /// Modifies the content of the options / Right Click menu for the window. This happens after <see cref="ModifyWindow"/>
    /// </summary>
    /// <param name="window">the ModHelperWindow instance</param>
    /// <param name="menu">the right click menu</param>
    public virtual void ModifyOptionsMenu(ModHelperWindow window, ModHelperPopupMenu menu)
    {
    }

    /// <summary>
    /// Called when the window is closed
    /// </summary>
    /// <param name="window">the ModHelperWindow instance</param>
    public virtual void OnClose(ModHelperWindow window)
    {
    }

    /// <summary>
    /// Called when the window is minimized to the dock
    /// </summary>
    /// <param name="window">the ModHelperWindow instance</param>
    public virtual void OnMinimized(ModHelperWindow window)
    {
    }

    /// <summary>
    /// Called when the window is unminimized from the deck
    /// </summary>
    /// <param name="window">the ModHelperWindow instance</param>
    public virtual void OnUnMinimized(ModHelperWindow window)
    {
    }

    /// <summary>
    /// Called each frame for each window that is Open / Unminimized
    /// </summary>
    /// <param name="window">the ModHelperWindow instance</param>
    public virtual void OnUpdate(ModHelperWindow window)
    {
    }

    /// <summary>
    /// Called each frame while a window is being resized by the user
    /// </summary>
    /// <param name="window">the ModHelperWindow instance</param>
    /// <param name="oldSize">the old height and width of the window</param>
    /// <param name="newSize">the new height and width of the window</param>
    public virtual void OnResize(ModHelperWindow window, Vector2 oldSize, Vector2 newSize)
    {
    }

    /// <summary>
    /// Called each frame while a window is being moved around by a user
    /// </summary>
    /// <param name="window">the ModHelperWindow instance</param>
    /// <param name="oldPos">the old position of the window</param>
    /// <param name="newPos">the new position of the window</param>
    public virtual void OnMove(ModHelperWindow window, Vector2 oldPos, Vector2 newPos)
    {
    }

    internal void SaveWindow(ModHelperWindow window)
    {
        var saveData = new JObject();
        if (!SaveWindow(window, ref saveData)) return;

        SavedWindows[window.id.ToString()] = new SavedModWindow
        {
            ID = window.id.ToString(),
            ModWindow = window.ModWindow.Id,
            X = window.RectTransform.anchoredPosition.x,
            Y = window.RectTransform.anchoredPosition.y,
            Width = window.RectTransform.sizeDelta.x,
            Height = window.RectTransform.sizeDelta.y,
            Color = window.WindowColor,
            Locked = window.locked,
            BackgroundOpacity = window.rootCanvas.alpha,
            ForegroundOpacity = window.contentCanvas.alpha,
            Data = saveData
        };

        saveSettingsAfterGame = true;
    }

    /// <summary>
    /// Called when this window is saved for reuse
    /// </summary>
    /// <param name="window">the ModHelperWindow instance</param>
    /// <param name="saveData">necessary save data</param>
    /// <returns>whether the window should be saved or not</returns>
    public virtual bool SaveWindow(ModHelperWindow window, ref JObject saveData)
    {
        return true;
    }

    internal static void LoadAllWindows()
    {
        foreach (var savedWindow in SavedWindows.Values)
        {
            ModHelperWindow window = null;
            try
            {
                LoadWindow(savedWindow, out window);
            }
            catch (Exception e)
            {
                ModHelper.Warning(e);
                window?.DestroyImmediate();
            }
        }
    }

    internal static void LoadWindow(SavedModWindow savedWindow, out ModHelperWindow window)
    {
        window = null;
        if (!Cache.TryGetValue(savedWindow.ModWindow, out var modWindow)) return;

        window = modWindow.Open();

        modWindow.LoadWindow(window, savedWindow);
    }

    internal void LoadWindow(ModHelperWindow window, SavedModWindow savedWindow)
    {
        window.id = Guid.Parse(savedWindow.ID);
        window.RectTransform.anchoredPosition = new Vector2(savedWindow.X, savedWindow.Y);
        window.RectTransform.sizeDelta = new Vector2(savedWindow.Width, savedWindow.Height);
        window.UpdateWindowColor(savedWindow.Color);
        if (window.locked != savedWindow.Locked)
        {
            window.ToggleLocked();
        }
        window.rootCanvas.alpha = Math.Clamp(savedWindow.BackgroundOpacity, .25f, 1);
        window.contentCanvas.alpha = Math.Clamp(savedWindow.ForegroundOpacity, .25f, 1);

        LoadWindow(window, savedWindow.Data);

        window.ToggleMinimized();
    }

    /// <summary>
    /// Called when this window is loaded in a new match because it was saved
    /// </summary>
    /// <param name="window">the ModHelperWindow instance</param>
    /// <param name="saveData">the save data for the window</param>
    public virtual void LoadWindow(ModHelperWindow window, JObject saveData)
    {

    }

    /// <summary>
    /// Called once each frame as long as any window of this type is open
    /// <seealso cref="OpenedWindows"/>
    /// </summary>
    public virtual void OnUpdate()
    {
    }

    internal static void Update()
    {
        if (InGame.Bridge is null) return;

        foreach (var modWindow in GetContent<ModWindow>().Where(modWindow => modWindow.ActiveWindows.Any()))
        {
            modWindow.OnUpdate();
        }
    }
}

/// <summary>
/// Helper class for defining a ModWindow whose start menu entry is nested beneath another
/// </summary>
/// <typeparam name="T">the parent Start Menu entry</typeparam>
public abstract class ModWindow<T> : ModWindow where T : ModStartMenuEntry
{
    /// <inheritdoc />
    public override ModStartMenuEntry ParentEntry => GetInstance<T>();
}