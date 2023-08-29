﻿using System.Collections.Generic;
using BTD_Mod_Helper.Api.Bloons.Bosses;
namespace BTD_Mod_Helper.Api.Display;

/// <summary>
/// The display for the <see cref="ModBoss.AmbientMapFXReference"/> for a boss
/// </summary>
public abstract class AmbientMapFXDisplay : ModContent
{
    internal static readonly Dictionary<string, AmbientMapFXDisplay> Cache = new();

    /// <summary>
    /// The name of the asset bundle file that the model is in, not including the .bundle extension
    /// </summary>
    public abstract string AssetBundleName { get; }

    /// <summary>
    /// The name of the prefab that the model has within the Asset Bundle
    /// </summary>
    public abstract string PrefabName { get; }

    /// <summary>
    /// Whether to try loading the asset from the bundle asynchronously.
    /// </summary>
    public abstract bool LoadAsync { get; }

    /// <summary>
    /// The ModBoss that this MapFXDisplay is used for
    /// </summary>
    public abstract ModBoss Boss { get; }

    /// <inheritdoc />
    public override void Register()
    {
        Cache[Id] = this;
        Boss.AmbientMapFX = Id;
    }
}

/// <summary>
/// A convenient generic class for applying a AmbientMapFXDisplay to a ModBoss
/// </summary>
/// <typeparam name="T"></typeparam>
public abstract class AmbientMapFXDisplay<T> : AmbientMapFXDisplay where T : ModBoss
{
    /// <inheritdoc />
    public override ModBoss Boss => GetInstance<T>();
}