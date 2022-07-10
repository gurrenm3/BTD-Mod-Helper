using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using System.Threading.Tasks;
using BTD_Mod_Helper.Api.ModOptions;
using UnityEngine;
using BTD_Mod_Helper.Api;
using BTD_Mod_Helper.Patches;
using BTD_Mod_Helper.Patches.Resources;
using Main = Assets.Main.Main;

namespace BTD_Mod_Helper;

/// <summary>
/// Expanded version of MelonMod to suit the needs of Bloons games and the Mod Helper
/// </summary>
public abstract partial class BloonsMod : MelonMod, IModContent
{
    /// <summary>
    /// All ModContent in ths mod
    /// </summary>
    public IReadOnlyList<ModContent> Content { get; internal set; }

    /// <summary>
    /// The settings in this mod organized by name
    /// </summary>
    public Dictionary<string, ModSetting> ModSettings { get; internal set; } = new();

    /// <summary>
    /// The embedded resources of this mod
    /// </summary>
    public Dictionary<string, byte[]> Resources { get; internal set; }

    /// <summary>
    /// The prefix used for the IDs of towers, upgrades, etc for this mod to prevent conflicts with other mods
    /// </summary>
    public virtual string IDPrefix => MelonAssembly.Assembly.GetName().Name + "-";

    /// <summary>
    /// Setting this to true will prevent your BloonsMod hooks from executing if the player could get flagged for using mods at that time.
    /// 
    /// For example, using mods in public co-op
    /// </summary>
    public virtual bool CheatMod => true;

    internal string SettingsFilePath
    {
        get
        {
            var oldPath = Path.Combine(ModHelper.ModSettingsDirectory, $"{Info.Name}.json");
            var newPath = Path.Combine(ModHelper.ModSettingsDirectory, $"{MelonAssembly.Assembly.GetName().Name}.json");
            return File.Exists(oldPath) ? oldPath : newPath;
        }
    }

    /// <summary>
    /// Github API URL used to check if this mod is up to date.
    ///
    ///     For example: "https://api.github.com/repos/gurrenm3/BTD-Mod-Helper/releases"
    /// </summary>
    [Obsolete("Switch to using ModHelperData (wiki page)")]
    public virtual string GithubReleaseURL => "";


    /// <summary>
    /// As an alternative to a GithubReleaseURL, a direct link to a web-hosted version of the .cs file that
    /// has the "MelonInfo" attribute with the version of your mod
    ///
    ///     
    ///     For example: "https://raw.githubusercontent.com/doombubbles/BTD6-Mods/main/MegaKnowledge/Main.cs"
    ///
    ///     because the file contains
    ///     [assembly: MelonInfo(typeof(MegaKnowledge.Main), "Mega Knowledge", "1.0.1", "doombubbles")]
    /// </summary>
    [Obsolete("Switch to using ModHelperData (wiki page)")]
    public virtual string MelonInfoCsURL => "";

    /// <summary>
    /// Link that people should be prompted to go to when this mod is out of date.
    ///
    ///     For example: "https://github.com/gurrenm3/BTD-Mod-Helper/releases/latest"
    /// </summary>
    [Obsolete("Switch to using ModHelperData (wiki page)")]
    public virtual string LatestURL => "";

    /// <summary>
    /// Allows you to define ways for other mods to interact with this mod. Other mods could do:
    /// <code>
    /// ModContent.GetMod("YourModName")?.Call("YourOperationName", ...);
    /// </code>
    /// to execute functionality here.
    /// <br/>
    /// </summary>
    /// <param name="operation">A string for the name of the operation that another mods wants to call</param>
    /// <param name="parameters">The parameters that another mod has provided</param>
    /// <returns>A possible result of this call</returns>
    public virtual object Call(string operation, params object[] parameters)
    {
        return null;
    }

    /// <summary>
    /// Signifies that the game shouldn't crash / the mod shouldn't stop loading if one of its patches fails
    /// </summary>
    public virtual bool OptionalPatches => true;

    internal List<string> loadErrors = new();

    /// <summary>
    /// Lets the ModHelper control patching, allowing for individual patches to fail without the entire mod getting
    /// unloaded. 
    /// </summary>
    internal bool modHelperPatchAll;

    /// <inheritdoc />
    public sealed override void OnInitializeMelon()
    {
        // If they haven't set OptionalPatches to false and haven't already signified they have their own patching plan
        // by using HarmonyDontPatchAll themselves...
        if (OptionalPatches && !MelonAssembly.HarmonyDontPatchAll)
        {
            typeof(MelonAssembly)
                .GetProperty(nameof(MelonAssembly.HarmonyDontPatchAll))!
                .GetSetMethod(true)!
                .Invoke(MelonAssembly, new object[] {true});

            modHelperPatchAll = true;
        }

        OnInitialize();
    }

    /// <inheritdoc />
    public sealed override void OnLoaderInitialized()
    {
        if (modHelperPatchAll)
        {
            AccessTools.GetTypesFromAssembly(MelonAssembly.Assembly).Do(type =>
            {
                try
                {
                    HarmonyInstance.CreateClassProcessor(type).Patch();
                }
                catch (Exception e)
                {
                    MelonLogger.Warning($"Failed to apply {Info.Name} patch(es) in {type.Name}: \"{e.Message}\" " +
                                        $"The mod might not function correctly. This needs to be fixed by {Info.Author}");

                    loadErrors.Add($"Failed to apply patch(es) in {type.Name}");

                    if (type == typeof(Task_EnumerateAction) || type == typeof(Main_GetInitialLoadTasks))
                    {
                        ModHelper.FallbackToOldLoading = true;
                    }
                }
            });
        }

        OnApplicationStart();
    }

    /// <inheritdoc cref="OnLoaderInitialized"/>
    public new virtual void OnApplicationStart()
    {
    }

    /// <inheritdoc cref="OnInitializeMelon"/>
    public virtual void OnInitialize()
    {
    }

    #region API Hooks

    /// <summary>
    /// Called whenever the Mod Options Menu gets opened, after it finishes initializing
    /// </summary>
    public virtual void OnModOptionsOpened()
    {
    }
    /*
    /// <summary>
    /// Called when the Mod Options Menu gets closed
    /// </summary>
    public virtual void OnModOptionsClosed() // not implemented for now
    {
    }*/

    #endregion

    #region Input Hooks

    /// <summary>
    /// Called on the frame that a key starts being held
    ///
    /// Equivalent to a HarmonyPostFix on Input.GetKeyDown
    /// </summary>
    [Obsolete("Use a ModSettingHotkey or Input.GetKeyDown within OnUpdate")]
    public virtual void OnKeyDown(KeyCode keyCode)
    {
    }

    /// <summary>
    /// Called on the frame that a key stops being held
    ///
    /// Equivalent to a HarmonyPostFix on Input.GetKeyUp
    /// </summary>
    [Obsolete("Use a ModSettingHotkey or Input.GetKeyUp within OnUpdate")]
    public virtual void OnKeyUp(KeyCode keyCode)
    {
    }

    /// <summary>
    /// Called every frame that a key is being held 
    ///
    /// Equivalent to a HarmonyPostFix on Input.GetKey
    /// </summary>
    [Obsolete("Use a ModSettingHotkey or Input.GetKey within OnUpdate")]
    public virtual void OnKeyHeld(KeyCode keyCode)
    {
    }

    #endregion
}