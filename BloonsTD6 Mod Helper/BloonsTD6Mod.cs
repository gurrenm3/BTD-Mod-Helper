using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using BTD_Mod_Helper.Api;
using BTD_Mod_Helper.Api.Internal;
using BTD_Mod_Helper.Api.ModOptions;
using UnityEngine;
namespace BTD_Mod_Helper;

/// <summary>
/// Extend this Class instead of MelonMod to gain access to dozens of easy to use built-in hooks
/// </summary>
public abstract partial class BloonsTD6Mod : MelonMod, IModContent
{
    internal static readonly HashSet<Type> GotModTooSoon = new();

    internal readonly List<string> loadErrors = new();
    private List<ModContent> content;

    private ModLoadTask loadContentTask;


    /// <summary>
    /// Lets the ModHelper control patching, allowing for individual patches to fail without the entire mod getting
    /// unloaded.
    /// </summary>
    internal bool modHelperPatchAll;

    /// <summary>
    /// All ModContent in ths mod
    /// </summary>
    public IReadOnlyList<ModContent> Content
    {
        get => content;
        internal set => content = value as List<ModContent>;
    }

    /// <summary>
    /// The settings in this mod organized by name
    /// </summary>
    public Dictionary<string, ModSetting> ModSettings { get; } = new();

    /// <summary>
    /// The embedded resources (textures) of this mod
    /// </summary>
    public Dictionary<string, byte[]> Resources { get; internal set; }

    /// <summary>
    /// Audio clips for the embedded sounds in this mod
    /// </summary>
    public Dictionary<string, AudioClip> AudioClips { get; internal set; }

    /// <summary>
    /// The prefix used for the IDs of towers, upgrades, etc for this mod to prevent conflicts with other mods
    /// </summary>
    public virtual string IDPrefix => this.GetAssembly().GetName().Name + "-";

    /// <summary>
    /// Setting this to true will prevent your BloonsTD6Mod hooks from executing if the player could get flagged for using mods
    /// at that time.
    /// <br />
    /// For example, using mods in public co-op
    /// </summary>
    public virtual bool CheatMod => true;

    internal string SettingsFilePath
    {
        get
        {
            var oldPath = Path.Combine(ModHelper.ModSettingsDirectory, $"{Info.Name}.json");
            var newPath = Path.Combine(ModHelper.ModSettingsDirectory, $"{this.GetAssembly().GetName().Name}.json");
            return File.Exists(oldPath) ? oldPath : newPath;
        }
    }

    internal ModLoadTask LoadContentTask => loadContentTask ??= new ModContentTask {mod = this};

    /// <summary>
    /// The path that this mod would most likely be at in the Mod Sources folder
    /// </summary>
    public string ModSourcesPath =>
        Path.Combine(ModHelper.ModSourcesDirectory, this.GetAssembly().GetName().Name!);

    /// <summary>
    /// Signifies that the game shouldn't crash / the mod shouldn't stop loading if one of its patches fails
    /// </summary>
    public virtual bool OptionalPatches => true;

    /// <summary>
    /// Allows you to define ways for other mods to interact with this mod. Other mods could do:
    /// <code>
    /// ModHelper.GetMod("YourModName")?.Call("YourOperationName", ...);
    /// </code>
    /// to execute functionality here.
    /// <br />
    /// </summary>
    /// <param name="operation">A string for the name of the operation that another mods wants to call</param>
    /// <param name="parameters">The parameters that another mod has provided</param>
    /// <returns>A possible result of this call</returns>
    public virtual object Call(string operation, params object[] parameters) => null;

    /// <summary>
    /// Manually adds new ModContent to the mod. Does not directly call <see cref="ModContent.Load()" /> or
    /// <see cref="ModContent.Register" />, but the latter will still end up being called if this is added before the
    /// Registration phase.
    /// </summary>
    /// <param name="modContent"></param>
    public void AddContent(ModContent modContent)
    {
        modContent.mod = this;
        content.Add(modContent);
        ModContentInstances.AddInstance(modContent.GetType(), modContent);
    }

    /// <summary>
    /// Manually adds multiple new ModContent to the mod. Does not directly call <see cref="ModContent.Load()" /> or
    /// <see cref="ModContent.Register" />, but the latter will still end up being called if this is added before the
    /// Registration phase.
    /// </summary>
    public void AddContent(IEnumerable<ModContent> modContents)
    {
        var contents = modContents.ToList();
        foreach (var modContent in contents)
        {
            modContent.mod = this;
            ModContentInstances.AddInstance(modContent.GetType(), modContent);
        }
        content.AddRange(contents);
    }

    #region ModHelper Overrides

    /// <inheritdoc />
    public sealed override void OnEarlyInitializeMelon()
    {
        ModContentInstances.AddInstance(GetType(), this);

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

        OnEarlyInitialize();
    }

    /// <inheritdoc />
    public sealed override void OnInitializeMelon()
    {
        if (modHelperPatchAll)
        {
            AccessTools.GetTypesFromAssembly(this.GetAssembly()).Do(type =>
            {
                try
                {
                    HarmonyInstance.CreateClassProcessor(type).Patch();
                }
                catch (Exception e)
                {
                    MelonLogger.Warning(
                        $"Failed to apply {Info.Name} patch(es) in {type.Name}: \"{e.InnerException?.Message ?? e.Message}\" " +
                        $"The mod might not function correctly. This needs to be fixed by {Info.Author}");

                    loadErrors.Add($"Failed to apply patch(es) in {type.Name}");

                    /*if (type == typeof(Task_EnumerateAction) || type == typeof(Main_GetInitialLoadTasks))
                    {
                        ModHelper.FallbackToOldLoading = true;
                        ModHelper.Msg("Falling back to old loading method");
                    }*/
                }
            });
        }

        if (GotModTooSoon.Contains(GetType()) && IDPrefix != this.GetAssembly().GetName().Name + "-")
        {
            // Happens when trying to get a custom embedded resource during the static constructor phase
            LoggerInstance.Warning("Tried to get mod id prefix too soon, used default value at least once");
        }

        OnApplicationStart();
        OnInitialize();
    }

    #endregion
}