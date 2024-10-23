using System;
using System.Collections.Generic;
using System.Linq;
using Il2CppAssets.Scripts.Data;
using Il2CppAssets.Scripts.Data.Bloons;
using Il2CppAssets.Scripts.Models.Towers.Projectiles;
using Il2CppNinjaKiwi.Common;
using Il2CppNinjaKiwi.Common.ResourceUtils;
using MelonLoader.Utils;
using UnityEngine;
namespace BTD_Mod_Helper.Api.Display;

/// <summary>
/// A special ModDisplay for Bloon Overlays. Handles automatically loading different instances of itself for each BloonOverlayClass
/// </summary>
public abstract class ModBloonOverlay : ModDisplay
{
    /// <summary>
    /// Whether the current MelonLoader version will support registering a BloonOverlay
    /// </summary>
    public static bool WorksOnCurrentMelonLoader => typeof(MelonEnvironment).Assembly.GetName().Version is
        {Major: 0, Minor: 6, Build: >= 6} or {Major: 0, Minor: 6, Build: <= 1} or {Major: 0, Minor: > 6} or {Major: > 0};

    /// <summary>
    /// Quick getter for all overlays
    /// </summary>
    protected static SerializableDictionary<string, BloonOverlayScriptable> AllOverlayTypes =>
        GameData.Instance.bloonOverlays.overlayTypes;
    
    /// <summary>
    /// The overlay class that this is for
    /// </summary>
    public BloonOverlayClass OverlayClass { get; private set; }

    /// <summary>
    /// The base Bloon Overlay to copy from.
    /// <br/>
    /// These come from the <see cref="ProjectileBehaviorWithOverlayModel.overlayType"/> fields of certain projectile behavior models
    /// <br/>
    /// To not copy from any Base Overlay, override this to be null/empty and modify <see cref="ModDisplay.BaseDisplay"/> or <see cref="ModDisplay.BaseDisplayReference"/> instead
    /// </summary>
    public virtual string BaseOverlay => null;

    /// <summary>
    /// <inheritdoc />
    /// <br/>
    /// If <see cref="BaseOverlay"/> is defined, will automatically get the correct display for each OverlayClass from there
    /// </summary>
    public override string BaseDisplay => string.IsNullOrEmpty(BaseOverlay)
        ? ""
        : AllOverlayTypes[BaseOverlay].assets[BaseOverlayClass].guidRef;

    /// <summary>
    /// The <see cref="BloonOverlayScriptable.displayLayer"/> of the overlay
    /// </summary>
    public virtual int DisplayLayer =>
        !string.IsNullOrEmpty(BaseOverlay) && AllOverlayTypes.TryGetValue(BaseOverlay, out var o) ? o.displayLayer : 0;

    private bool hasOverlayClass;
    private protected override string ID => hasOverlayClass ? BaseId + "-" + OverlayClass : BaseId;
    private string BaseId => GetId(mod, Name);

    /// <summary>
    /// Lets you control which BloonOverlayClass from the BaseOverlay is used for each BloonOverlayClass of your custom overlay.
    /// By default, uses the same <see cref="OverlayClass"/> as the base.
    /// <br/>
    /// <example>
    /// To make the non regrow bloons use the same overlays as the regrow bloons
    /// <code>
    /// public override BloonOverlayClass BaseOverlayClass => OverlayClass switch
    /// {
    ///     BloonOverlayClass.Red => BloonOverlayClass.RedRegrow,
    ///     BloonOverlayClass.Blue => BloonOverlayClass.BlueRegrow,
    ///     BloonOverlayClass.Green => BloonOverlayClass.GreenRegrow,
    ///     BloonOverlayClass.Yellow => BloonOverlayClass.YellowRegrow,
    ///     BloonOverlayClass.Pink => BloonOverlayClass.PinkRegrow,
    ///     BloonOverlayClass.White => BloonOverlayClass.WhiteRegrow,
    ///     _ => OverlayClass
    /// };
    /// </code>
    /// </example>
    /// </summary>
    public virtual BloonOverlayClass BaseOverlayClass => OverlayClass;

    /// <summary>
    /// Full list of BloonOverlayClasses to try to load this overlay for, defaults to all of them
    /// </summary>
    public virtual IEnumerable<BloonOverlayClass> BloonOverlayClasses => Enum.GetValues<BloonOverlayClass>();

    /// <summary>
    /// Which overlay type this Overlay uses
    /// </summary>
    public string OverlayType => WorksOnCurrentMelonLoader ? BaseId : BaseOverlay;

    /// <inheritdoc />
    public override IEnumerable<ModContent> Load() => WorksOnCurrentMelonLoader
        ? BloonOverlayClasses.Select(bc =>
        {
            try
            {
                var overlay = (ModBloonOverlay) Activator.CreateInstance(GetType());
                if (overlay != null)
                {
                    overlay.mod = mod;
                    overlay.OverlayClass = bc;
                    overlay.hasOverlayClass = true;
                    return overlay;
                }
            }
            catch (Exception e)
            {
                ModHelper.Error(e);
            }

            ModHelper.Error($"Unable to create {Id} {bc}, does it ");
            return null;
        })
        : [];

    /// <inheritdoc />
    public override void Register()
    {
        if (!WorksOnCurrentMelonLoader)
        {
            ModHelper.Warning("Custom Bloon Overlays sadly can't be added on this version of MelonLoader due to a bug");
            return;
        }

        if (!hasOverlayClass)
        {
            ModHelper.Error("Should not reach point of registering base ModBloonOverlay with no overlay class");
            return;
        }

        if (!string.IsNullOrEmpty(BaseOverlay))
        {
            if (!AllOverlayTypes.TryGetValue(BaseOverlay, out var baseOverlay))
            {
                ModHelper.Error($"Failed to register {Id}, no base overlay {BaseOverlay}");
                return;
            }

            if (!baseOverlay.assets.ContainsKey(BaseOverlayClass))
            {
                // Not an error, just doesn't have one for this overlay class
                return;
            }
        }

        try
        {
            var guid = BaseDisplayReference.guidRef;
            if (string.IsNullOrEmpty(guid))
            {
                ModHelper.Warning($"ModBloonOverlay {Id} has no base display");
            }
        }
        catch (Exception e)
        {
            ModHelper.Error($"Unable to get BaseDisplayReference for {Id}");
            ModHelper.Error(e);
            return;
        }

        base.Register();

        if (!AllOverlayTypes.TryGetValue(BaseId, out var overlay))
        {
            overlay = AllOverlayTypes[BaseId] = ScriptableObject.CreateInstance<BloonOverlayScriptable>();
            overlay.displayLayer = DisplayLayer;
            overlay.assets = new SerializableDictionary<BloonOverlayClass, PrefabReference>();
        }

        overlay.assets[OverlayClass] = CreatePrefabReference(Id);
    }

    /// <summary>
    /// Applies this overlay to a projectile behavior model
    /// </summary>
    /// <param name="projectileBehaviorWithOverlayModel">model to add to</param>
    public virtual void Apply(ProjectileBehaviorWithOverlayModel projectileBehaviorWithOverlayModel)
    {
        projectileBehaviorWithOverlayModel.overlayType = OverlayType;
    }
}