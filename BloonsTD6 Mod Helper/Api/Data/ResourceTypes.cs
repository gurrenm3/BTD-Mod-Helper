using System.Collections.Generic;
using System.Linq;
using Il2CppAssets.Scripts.Models.Audio;
using Il2CppNinjaKiwi.Common.ResourceUtils;
using Newtonsoft.Json.Linq;
using UnityEngine;
namespace BTD_Mod_Helper.Api.Data;

/// <summary>
/// Base class for an embedded resource referenced by name.
/// </summary>
public abstract class Resource(string name)
{
    /// <summary>
    /// The resource's file name without extension.
    /// </summary>
    public string Name { get; } = name;

    /// <summary>
    /// Implicit conversion to the resource's name.
    /// </summary>
    public static implicit operator string(Resource resource) => resource.Name;
}

/// <summary>
/// An embedded sprite resource belonging to mod <typeparamref name="T"/>.
/// </summary>
public class SpriteResource<T>(string name) : Resource(name) where T : BloonsMod
{
    /// <summary>
    /// The <see cref="SpriteReference"/> for this resource.
    /// </summary>
    public virtual SpriteReference SpriteReference => ModContent.GetSpriteReference<T>(Name);

    /// <summary>
    /// Implicit conversion to <see cref="SpriteReference"/>.
    /// </summary>
    public static implicit operator SpriteReference(SpriteResource<T> resource) => resource.SpriteReference;

    /// <summary>
    /// The loaded <see cref="UnityEngine.Sprite"/> for this resource.
    /// </summary>
    public virtual Sprite Sprite => ModContent.GetSprite<T>(Name);

    /// <summary>
    /// Implicit conversion to <see cref="UnityEngine.Sprite"/>.
    /// </summary>
    public static implicit operator Sprite(SpriteResource<T> resource) => resource.Sprite;
}

/// <summary>
/// An embedded audio clip resource belonging to mod <typeparamref name="T"/>.
/// </summary>
public class AudioClipResource<T>(string name) : Resource(name) where T : BloonsMod
{
    /// <summary>
    /// The <see cref="AudioClipReference"/> for this resource.
    /// </summary>
    public virtual AudioClipReference AudioClipReference => ModContent.GetAudioClipReference<T>(Name);

    /// <summary>
    /// Implicit conversion to <see cref="AudioClipReference"/>.
    /// </summary>
    public static implicit operator AudioClipReference(AudioClipResource<T> resource) => resource.AudioClipReference;

    /// <summary>
    /// A created <see cref="SoundModel"/> for this audio clip
    /// </summary>
    public virtual SoundModel Sound => new("", AudioClipReference);

    /// <summary>
    /// Implicit conversion to <see cref="SoundModel"/>.
    /// </summary>
    public static implicit operator SoundModel(AudioClipResource<T> resource) => resource.Sound;
}

/// <summary>
/// An embedded JSON resource belonging to mod <typeparamref name="T"/>.
/// </summary>
public class JsonResource<T>(string name) : Resource(name) where T : BloonsMod
{
    /// <summary>
    /// The parsed <see cref="JObject"/> contents of this resource.
    /// </summary>
    public virtual JObject Json =>
        field ??= ModContent.GetInstance<T>().MelonAssembly.Assembly.GetEmbeddedJson(Name + ".json");

    /// <summary>
    /// Implicit conversion to <see cref="JObject"/>.
    /// </summary>
    public static implicit operator JObject(JsonResource<T> resource) => resource.Json;
}

/// <summary>
/// An embedded asset bundle resource belonging to mod <typeparamref name="T"/>.
/// </summary>
public class BundleResource<T>(string name) : Resource(name) where T : BloonsMod
{
    /// <summary>
    /// The loaded <see cref="AssetBundle"/> for this resource.
    /// </summary>
    public virtual AssetBundle Bundle => ModContent.GetBundle<T>(Name);

    /// <summary>
    /// Implicit conversion to <see cref="AssetBundle"/>.
    /// </summary>
    public static implicit operator AssetBundle(BundleResource<T> resource) => resource.Bundle;
}

/// <summary>
/// Randomized audio clip amongst a number of variants
/// </summary>
public class RandomizedAudioClipResource<T>(string name, params IEnumerable<AudioClipResource<T>> clips)
    : AudioClipResource<T>(name) where T : BloonsMod
{
    /// <inheritdoc />
    public override AudioClipReference AudioClipReference
    {
        get
        {
            ModContent.GetInstance<T>().RegisterRandomizedAudioClip(Name, clips.Select(clip => clip.Name).ToArray());
            return base.AudioClipReference;
        }
    }
}