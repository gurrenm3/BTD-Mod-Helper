using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using BTD_Mod_Helper.Api;
using BTD_Mod_Helper.Api.Data;
using BTD_Mod_Helper.Api.Hooks;
using BTD_Mod_Helper.Api.Internal;
using BTD_Mod_Helper.Api.ModOptions;
using Newtonsoft.Json.Linq;
using Octokit;
using UnityEngine;

namespace BTD_Mod_Helper;

/// <summary>
/// Expanded version of MelonMod to suit the needs of BTD Mod Helper
/// </summary>
public abstract class BloonsMod : MelonMod, IModSettings
{
    internal static readonly HashSet<Type> GotModTooSoon = [];

    internal readonly List<string> loadErrors = [];
    private List<ModContent> content;

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
    public virtual string IDPrefix => field ??= this.GetAssembly().GetName().Name + "-";

    /// <summary>
    /// Setting this to true will prevent your BloonsTD6Mod hooks from executing if the player could get flagged for using mods
    /// at that time.
    /// <br />
    /// For example, using mods in public co-op
    /// </summary>
    public virtual bool CheatMod => true;

    /// <summary>
    /// The artifact models stored in the GameData don't have a proper setup of descendents like usual models in the GameModel.
    /// Generating the descendents can add an extra second to start time, so it will only be done if at least one mod says
    /// that it requires them.
    /// </summary>
    public virtual bool UsesArtifactDependants => false;

    internal ModLoadTask LoadContentTask => field ??= new ModContentTask {mod = this};

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

    /// <inheritdoc cref="Call" />
    public T Call<T>(string operation, params object[] parameters) => (T) Call(operation, parameters);

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
                .Invoke(MelonAssembly, [true]);

            modHelperPatchAll = true;
        }

        OnEarlyInitialize();
    }

    /// <summary>
    /// Tries to apply all Harmony Patches defined within a type. Logs a warning and adds a load error if any fail.
    /// </summary>
    /// <param name="type"></param>
    public void ApplyHarmonyPatches(Type type)
    {
        try
        {
            HarmonyInstance.CreateClassProcessor(type).Patch();
        }
        catch (Exception e)
        {
            var message = e.InnerException?.Message ?? e.Message;

            if (ModHelper.IsEpic && message.Contains("Il2CppFacepunch.Steamworks")) return;

            LoadError($"Failed to apply patch(es) in {type.Name}");
            LoggerInstance.Error(message);
            LoggerInstance.Error($"The mod might not function correctly. This needs to be fixed by {Info.Author}");

            /*if (type == typeof(Task_EnumerateAction) || type == typeof(Main_GetInitialLoadTasks))
            {
                ModHelper.FallbackToOldLoading = true;
                ModHelper.Msg("Falling back to old loading method");
            }*/
        }
    }

    /// <summary>
    /// Tries to apply all mod hooks in the calling assembly, failing gracefully on errors.
    /// </summary>
    public void ApplyModHooks()
    {
        var allHookMethods = AccessTools.GetTypesFromAssembly(GetType().Assembly)
            .SelectMany(t => t.GetMethods(BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic)
                .Select(m => (Method: m, Attr: m.GetCustomAttribute<HookTargetAttribute>())))
            .Where(x => x.Attr != null)
            .Where(x =>
            {
                var ok = x.Attr!.TargetType.IsAssignableToGenericType(typeof(ModHook<,>));
                if (!ok)
                    MelonLogger.Warning(
                        $"Failed to apply hook {x.Method.Name}: {x.Attr!.TargetType.FullName} is not a ModHook<,>");
                return ok;
            });

        foreach (var (methodInfo, hook) in allHookMethods)
        {
            try
            {
                var hookType = hook!.TargetType;
                var genArgs = hookType.BaseType!.GetGenericArguments();
                var delegateType = genArgs[1];
                var invokeInfo = delegateType.GetMethod("Invoke") ??
                                 throw new InvalidOperationException($"Delegate {delegateType} has no Invoke()");

                var userParams = methodInfo.GetParameters();
                var delegateParams = invokeInfo.GetParameters();

                var exactMatch = userParams.Length == delegateParams.Length &&
                                 !delegateParams.Where((dp, i) =>
                                     dp.ParameterType.IsByRef != userParams[i].ParameterType.IsByRef ||
                                     (
                                         dp.ParameterType != userParams[i].ParameterType &&
                                         dp.ParameterType.GetElementType() != userParams[i].ParameterType.GetElementType()
                                     )).Any();

                Delegate hookDelegate;
                if (exactMatch)
                {
                    hookDelegate = methodInfo.CreateDelegate(delegateType);
                }
                else
                {
                    var lambdaParams = delegateParams
                        .Select(p => Expression.Parameter(p.ParameterType, p.Name ?? $"arg{p.Position}"))
                        .ToArray();

                    var byName = lambdaParams.ToDictionary(pe => pe.Name!, pe => pe, StringComparer.OrdinalIgnoreCase);

                    var instEntry = byName
                        .FirstOrDefault(kvp =>
                            kvp.Key.Equals("instance", StringComparison.OrdinalIgnoreCase) ||
                            kvp.Key.Equals("this", StringComparison.OrdinalIgnoreCase));
                    if (instEntry.Value != null)
                    {
                        byName["@this"] = instEntry.Value;
                        byName["__instance"] = instEntry.Value;
                    }

                    var resEntry =
                        byName.FirstOrDefault(kvp => kvp.Key.Equals("result", StringComparison.OrdinalIgnoreCase));
                    if (resEntry.Value != null)
                    {
                        byName["@result"] = resEntry.Value;
                        byName["__result"] = resEntry.Value;
                    }

                    var locals = new List<ParameterExpression>();
                    var preAssigns = new List<Expression>();
                    var callArgs = new Expression[userParams.Length];

                    for (var i = 0; i < userParams.Length; i++)
                    {
                        var up = userParams[i];
                        if (!byName.TryGetValue(up.Name!, out var src))
                            throw new InvalidOperationException($"Cannot bind parameter '{up.Name}' in {methodInfo.Name}");

                        var srcType = src.Type;
                        var tgtType = up.ParameterType;

                        switch (srcType.IsByRef)
                        {
                            case true when !tgtType.IsByRef:
                            {
                                var elem = srcType.GetElementType()!;
                                var unary = Expression.Convert(src, elem);
                                callArgs[i] = elem != tgtType ? Expression.Convert(unary, tgtType) : (Expression) unary;
                                break;
                            }
                            case true when tgtType.IsByRef:
                            {
                                if (tgtType.GetElementType() != srcType.GetElementType())
                                    throw new InvalidOperationException($"Mismatched by-ref for '{up.Name}'");
                                callArgs[i] = src;
                                break;
                            }
                            case false when tgtType.IsByRef:
                            {
                                var elem = tgtType.GetElementType()!;
                                var localVar = Expression.Variable(elem, up.Name + "_local");
                                locals.Add(localVar);

                                Expression srcConv = srcType != elem ? Expression.Convert(src, elem) : src;
                                preAssigns.Add(Expression.Assign(localVar, srcConv));

                                callArgs[i] = localVar;
                                break;
                            }
                            default:
                                callArgs[i] = srcType.IsAssignableTo(tgtType) ? src : Expression.Convert(src, tgtType);
                                break;
                        }
                    }

                    Expression body = Expression.Call(methodInfo, callArgs);
                    if (methodInfo.ReturnType != invokeInfo.ReturnType)
                        body = Expression.Convert(body, invokeInfo.ReturnType);

                    if (locals.Count > 0)
                    {
                        var blockExpressions = new List<Expression>();
                        blockExpressions.AddRange(preAssigns);
                        blockExpressions.Add(body);
                        body = Expression.Block(locals, blockExpressions);
                    }

                    hookDelegate = Expression.Lambda(delegateType, body, lambdaParams).Compile();
                }

                var addName = hook.HookType == HookTargetAttribute.EHookType.Prefix
                    ? "AddPrefix"
                    : "AddPostfix";
                var addMethod = hook.TargetType.GetMethod(addName, BindingFlags.Instance | BindingFlags.Public) ??
                                throw new MissingMethodException(hook.TargetType.FullName, addName);

                var hookInstance = ModContent.GetInstance(hook.TargetType)!;
                addMethod.Invoke(hookInstance, [hookDelegate]);
            }
            catch (Exception ex)
            {
                MelonLogger.Error(
                    $"Exception while applying hook {methodInfo.DeclaringType!.FullName}::{methodInfo.Name}: {ex}");
            }
        }
    }


    /// <inheritdoc />
    public sealed override void OnInitializeMelon()
    {
        if (modHelperPatchAll)
        {
            AccessTools.GetTypesFromAssembly(this.GetAssembly()).Do(ApplyHarmonyPatches);
        }

        if (GotModTooSoon.Contains(GetType()) && IDPrefix != this.GetAssembly().GetName().Name + "-")
        {
            // Happens when trying to get a custom embedded resource during the static constructor phase
            LoggerInstance.Warning("Tried to get mod id prefix too soon, used default value at least once");
        }

        ApplyModHooks();

        OnApplicationStart();
        OnInitialize();
    }

    /// <summary>
    /// Saves the current mod settings for this mod
    /// </summary>
    public void SaveModSettings() => ModSettingsHandler.SaveModSettings(this);

    internal void LoadError(object message)
    {
        LoggerInstance.Error(message);
        loadErrors.Add(message?.ToString());
    }

    /// <inheritdoc cref="OnInitializeMelon" />
    public new virtual void OnApplicationStart()
    {
    }

    /// <inheritdoc cref="OnEarlyInitializeMelon" />
    public virtual void OnEarlyInitialize()
    {
    }

    /// <inheritdoc cref="OnInitializeMelon" />
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

    /// <summary>
    /// Called when the settings for your mod are saved.
    /// </summary>
    /// <param name="settings">The json representation of the settings about to be saved</param>
    public virtual void OnSaveSettings(JObject settings)
    {
    }

    /// <summary>
    /// Called when the settings for your mod are loaded
    /// </summary>
    /// <param name="settings">The json representation of the settings that were just loaded</param>
    public virtual void OnLoadSettings(JObject settings)
    {
    }

    #endregion

    /// <summary>
    /// Adds a new randomized audio clip list for the given name to <see cref="ResourceHandler.RandomAudioClipIds"/>.
    /// Will include the mod Id in the name.
    /// </summary>
    /// <param name="name">Name to use for the randomized clip</param>
    /// <param name="clipNames">Names of audio clips within this mod</param>
    public void RegisterRandomizedAudioClip(string name, params string[] clipNames)
    {
        ResourceHandler.RandomAudioClipIds[ModContent.GetId(this, name)] = clipNames
            .Select(clipName => AudioClips[clipName])
            .ToArray();
    }
}