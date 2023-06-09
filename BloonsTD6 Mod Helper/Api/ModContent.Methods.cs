using System;
using System.Collections.Generic;
using System.Linq;
using BTD_Mod_Helper.Api.Bloons;
using BTD_Mod_Helper.Api.Display;
using BTD_Mod_Helper.Api.Scenarios;
using BTD_Mod_Helper.Api.Towers;
using Il2CppAssets.Scripts.Models.Towers;
using Il2CppAssets.Scripts.Unity;
using Il2CppAssets.Scripts.Utils;
using UnityEngine;
namespace BTD_Mod_Helper.Api;

public abstract partial class ModContent
{

    /// <summary>
    /// Gets the singleton instance of a particular ModContent or BloonsTD6Mod based on its type
    /// </summary>
    /// <typeparam name="T">The type to get the instance of</typeparam>
    /// <returns>The singleton instance of it</returns>
    public static T GetInstance<T>() where T : IModContent => ModContentInstance<T>.Instance;
    /// <summary>
    /// Gets the official instance of a particular ModContent or BloonsTD6Mod based on its type
    /// </summary>
    /// <param name="type">The type to get the instance of</param>
    /// <returns>The official instance of it</returns>
    public static IModContent GetInstance(Type type) =>
        ModContentInstances.Instances.TryGetValue(type, out var instance) ? instance[0] : default;

    /// <summary>
    /// Gets a sprite reference by name for a specific mod
    /// </summary>
    /// <param name="name">The file name of your texture, without the extension</param>
    /// <typeparam name="T">Your mod's main BloonsTD6Mod extending class</typeparam>
    /// <returns>A new SpriteReference</returns>
    public static SpriteReference GetSpriteReference<T>(string name) where T : BloonsTD6Mod =>
        CreateSpriteReference(GetTextureGUID<T>(name));
    /// <summary>
    /// Gets a sprite reference by name for this mod
    /// </summary>
    /// <param name="name">The file name of your texture, without the extension</param>
    /// <returns>A new SpriteReference</returns>
    protected SpriteReference GetSpriteReference(string name) => CreateSpriteReference(GetTextureGUID(name));
    /// <summary>
    /// Gets a sprite reference by name for a specific mod
    /// </summary>
    /// <param name="mod">The BloonsTD6Mod that the texture is from</param>
    /// <param name="name">The file name of your texture, without the extension</param>
    /// <returns>A new SpriteReference</returns>
    public static SpriteReference GetSpriteReference(BloonsTD6Mod mod, string name) =>
        CreateSpriteReference(GetTextureGUID(mod, name));
    /// <summary>
    /// Gets a sprite reference by name for a specific mod, returning null if the texture hasn't currently been
    /// loaded instead of an invalid SpriteReference
    /// </summary>
    /// <param name="name">The file name of your texture, without the extension</param>
    /// <typeparam name="T">Your mod's main BloonsTD6Mod extending class</typeparam>
    /// <returns>A new SpriteReference</returns>
    public static SpriteReference GetSpriteReferenceOrNull<T>(string name) where T : BloonsTD6Mod =>
        GetSpriteReferenceOrNull(GetInstance<T>(), name);
    /// <summary>
    /// Gets a sprite reference by name for this mod, returning null if the texture hasn't currently been
    /// loaded instead of an invalid SpriteReference
    /// </summary>
    /// <param name="name">The file name of your texture, without the extension</param>
    /// <returns>A new SpriteReference</returns>
    protected SpriteReference GetSpriteReferenceOrNull(string name) => GetSpriteReferenceOrNull(mod, name);
    /// <summary>
    /// Gets a sprite reference by name for a specific mod, returning null if the texture hasn't currently been
    /// loaded instead of an invalid SpriteReference
    /// </summary>
    /// <param name="mod">The BloonsTD6Mod that the texture is from</param>
    /// <param name="name">The file name of your texture, without the extension</param>
    /// <returns>A new SpriteReference</returns>
    public static SpriteReference GetSpriteReferenceOrNull(BloonsTD6Mod mod, string name) =>
        TextureExists(mod, name) ? GetSpriteReference(mod, name) : null;
    /// <summary>
    /// Gets a sprite reference by name for a specific mod, or if the mod does not include a texture with that name,
    /// treats it as a vanilla sprite reference
    /// </summary>
    /// <param name="mod">The BloonsTD6Mod that the texture is from</param>
    /// <param name="name">The file name of your texture, without the extension</param>
    /// <returns>A new SpriteReference</returns>
    public static SpriteReference GetSpriteReferenceOrDefault(BloonsTD6Mod mod, string name) =>
        TextureExists(mod, name) ? GetSpriteReference(mod, name) : CreateSpriteReference(name);
    /// <summary>
    /// Gets a sprite reference by name for a specific mod, or if the mod does not include a texture with that name,
    /// treats it as a vanilla sprite reference
    /// </summary>
    /// <param name="name">The file name of your texture, without the extension</param>
    /// <typeparam name="T">Your mod's main BloonsTD6Mod extending class</typeparam>
    /// <returns>A new SpriteReference</returns>
    public static SpriteReference GetSpriteReferenceOrDefault<T>(string name) where T : BloonsTD6Mod =>
        GetSpriteReferenceOrDefault(GetInstance<T>(), name);
    /// <summary>
    /// Gets a sprite reference by name for a specific mod, or if the mod does not include a texture with that name,
    /// treats it as a vanilla sprite reference
    /// </summary>
    /// <param name="name">The file name of your texture, without the extension</param>
    /// <returns>A new SpriteReference</returns>
    protected SpriteReference GetSpriteReferenceOrDefault(string name) => GetSpriteReferenceOrDefault(mod, name);
    /// <summary>
    /// Returns a new SpriteReference that uses the given guid
    /// </summary>
    /// <param name="guid">The guid that you'd like to assign to the SpriteReference</param>
    public static SpriteReference CreateSpriteReference(string guid) => new()
    {
        guidRef = guid
    };
    /// <summary>
    /// Returns a new PrefabReference that uses the given guid
    /// </summary>
    /// <param name="guid">The guid that you'd like to assign to the PrefabReference</param>
    public static PrefabReference CreatePrefabReference(string guid) => new()
    {
        guidRef = guid
    };
    /// <summary>
    /// Returns a new AudioSourceReference that uses the given guid
    /// </summary>
    /// <param name="guid">The guid that you'd like to assign to the AudioSourceReference</param>
    public static AudioSourceReference CreateAudioSourceReference(string guid) => new()
    {
        guidRef = guid
    };
    /// <summary>
    /// Creates a Prefab Reference for a ModDisplay
    /// </summary>
    public static PrefabReference CreatePrefabReference<T>() where T : ModDisplay =>
        CreatePrefabReference(GetInstance<T>().Id);
    /// <summary>
    /// Creates a Sprite reference from the unsigned ints that can be found for a vanilla Sprite in AssetStudio
    /// </summary>
    /// <param name="data"></param>
    /// <returns></returns>
    internal static SpriteReference CreateSpriteReferenceFromBytes(params uint[] data)
    {
        var bytes = new byte[16];
        for (var i = 0; i < 4; i++)
        {
            BitConverter.GetBytes(data[i]).CopyTo(bytes, i * 4);
        }

        var hexPairs = BitConverter.ToString(bytes).Split('-');
        var guid = string.Concat(hexPairs.Select(s => new string(s.Reverse().ToArray())));

        return CreateSpriteReference(guid.ToLower());
    }

    internal static string WrapGuid(string orig) => $"{HijackSpriteAtlas}[{orig}]";

    /// <summary>
    /// Gets a texture's GUID by name for a specific mod
    /// </summary>
    /// <param name="mod">The BloonsTD6Mod that the texture is from</param>
    /// <param name="fileName">The file name of your texture, without the extension</param>
    /// <returns>The texture's GUID</returns>
    public static string GetTextureGUID(BloonsTD6Mod mod, string fileName) => WrapGuid(GetId(mod, fileName));
    /// <summary>
    /// Gets a texture's GUID by name for a specific mod, to be used in SpriteReferences
    /// <br />
    /// Returns null if a Texture hasn't been loaded with that name
    /// </summary>
    /// <param name="name">The file name of your texture, without the extension</param>
    /// <typeparam name="T">Your mod's main BloonsTD6Mod extending class</typeparam>
    /// <returns>The texture's GUID</returns>
    public static string GetTextureGUID<T>(string name) where T : BloonsTD6Mod
    {
        var BloonsTD6Mod = GetInstance<T>();
        if (BloonsTD6Mod == null)
        {
            BloonsTD6Mod.GotModTooSoon.Add(typeof(T));
            return WrapGuid(GetId<T>(name));
        }

        return GetTextureGUID(BloonsTD6Mod, name);
    }
    /// <summary>
    /// Gets a texture's GUID by name for this mod
    /// <br />
    /// Returns null if a Texture hasn't been loaded with that name
    /// </summary>
    /// <param name="name">The file name of your texture, without the extension</param>
    /// <returns>The texture's GUID</returns>
    public string GetTextureGUID(string name) => GetTextureGUID(mod, name);
    /// <summary>
    /// Gets the id of a resource by appending the mod's ID prefix to its name
    /// </summary>
    public static string GetId(BloonsTD6Mod BloonsTD6Mod, string name) => BloonsTD6Mod.IDPrefix + name;
    /// <summary>
    /// Gets the id of a resource by appending the mod's ID prefix to its name
    /// </summary>
    public static string GetId<T>(string name) where T : BloonsTD6Mod
    {
        var BloonsTD6Mod = GetInstance<T>();
        if (BloonsTD6Mod == null)
        {
            BloonsTD6Mod.GotModTooSoon.Add(typeof(T));
            return typeof(T).Assembly.GetName().Name + "-" + name;
        }

        return GetId(BloonsTD6Mod, name);
    }
    /// <summary>
    /// Gets the id of a resource by appending the mod's ID prefix to its name
    /// </summary>
    public string GetId(string name) => GetId(mod, name);
    /// <summary>
    /// Gets whether a texture with a given name has been loaded by the Mod Helper for a mod
    /// </summary>
    /// <param name="BloonsTD6Mod">The mod to look in</param>
    /// <param name="name">The file name of your texture, without the extension</param>
    public static bool TextureExists(BloonsTD6Mod BloonsTD6Mod, string name) =>
        ResourceHandler.Resources.ContainsKey(GetId(BloonsTD6Mod, name));
    /// <summary>
    /// Gets whether a texture with a given name has been loaded by the Mod Helper for a mod
    /// </summary>
    /// <param name="name">The file name of your texture, without the extension</param>
    /// <typeparam name="T">The mod to look in</typeparam>
    public static bool TextureExists<T>(string name) where T : BloonsTD6Mod => TextureExists(GetInstance<T>(), name);
    /// <summary>
    /// Gets whether a texture with a given name has been loaded by the Mod Helper for this mod
    /// </summary>
    /// <param name="name">The file name of your texture, without the extension</param>
    protected bool TextureExists(string name) => TextureExists(mod, name);
    /// <summary>
    /// Constructs a Texture2D for a given texture name within a mod
    /// </summary>
    /// <param name="BloonsTD6Mod">The mod that adds this texture</param>
    /// <param name="fileName">The file name of your texture, without the extension</param>
    /// <returns>A Texture2D</returns>
    public static Texture2D GetTexture(BloonsTD6Mod BloonsTD6Mod, string fileName) =>
        ResourceHandler.GetTexture(GetId(BloonsTD6Mod, fileName));
    /// <summary>
    /// Constructs a Texture2D for a given texture name within this mod
    /// </summary>
    /// <param name="fileName">The file name of your texture, without the extension</param>
    /// <returns>A Texture2D</returns>
    protected Texture2D GetTexture(string fileName) => GetTexture(mod, fileName);
    /// <summary>
    /// Constructs a Texture2D for a given texture name within a mod
    /// </summary>
    /// <param name="fileName">The file name of your texture, without the extension</param>
    /// <returns>A Texture2D</returns>
    public static Texture2D GetTexture<T>(string fileName) where T : BloonsTD6Mod =>
        GetTexture(GetInstance<T>(), fileName);
    /// <summary>
    /// Returns the Bytes associated with a texture.
    /// </summary>
    /// <param name="fileName">The file name of your texture, without the extension.</param>
    /// <returns>The bytes associated with the texture.</returns>
    protected byte[] GetTextureBytes(string fileName) => GetTextureBytes(mod, fileName);
    /// <summary>
    /// Returns the Bytes associated with a texture.
    /// </summary>
    /// <param name="BloonsTD6Mod">The mod that adds this texture.</param>
    /// <param name="fileName">The file name of your texture, without the extension.</param>
    /// <returns>The bytes associated with the texture.</returns>
    public static byte[] GetTextureBytes(BloonsTD6Mod BloonsTD6Mod, string fileName) =>
        ResourceHandler.GetTextureBytes(GetTextureGUID(BloonsTD6Mod, fileName));
    /// <summary>
    /// Returns the Bytes associated with a texture.
    /// </summary>
    /// <param name="fileName">The file name of your texture, without the extension.</param>
    /// <returns>The bytes associated with the texture.</returns>
    public static byte[] GetTextureBytes<T>(string fileName) where T : BloonsTD6Mod =>
        GetTextureBytes(GetInstance<T>(), fileName);
    /// <summary>
    /// Constructs a Sprite for a given texture name within a given mod
    /// </summary>
    /// <param name="mod"></param>
    /// <param name="name">The file name of your texture, without the extension</param>
    /// <param name="pixelsPerUnit">The pixels per unit for the Sprite to have</param>
    /// <returns>A Sprite</returns>
    public static Sprite GetSprite(BloonsTD6Mod mod, string name, float pixelsPerUnit = 10f) =>
        ResourceHandler.GetSprite(GetId(mod, name), pixelsPerUnit);
    /// <summary>
    /// Constructs a Sprite for a given texture name within a given mod
    /// </summary>
    /// <param name="name">The file name of your texture, without the extension</param>
    /// <param name="pixelsPerUnit">The pixels per unit for the Sprite to have</param>
    /// <returns>A Sprite</returns>
    public static Sprite GetSprite<T>(string name, float pixelsPerUnit = 10f) where T : BloonsTD6Mod =>
        GetSprite(GetInstance<T>(), name, pixelsPerUnit);
    /// <summary>
    /// Constructs a Sprite for a given texture name within this mod
    /// </summary>
    /// <param name="name">The file name of your texture, without the extension</param>
    /// <param name="pixelsPerUnit">The pixels per unit for the Sprite to have</param>
    /// <returns>A Sprite</returns>
    protected Sprite GetSprite(string name, float pixelsPerUnit = 10f) => GetSprite(mod, name, pixelsPerUnit);
    /// <summary>
    /// Gets a bundle from a mod with the specified name (no file extension)
    /// </summary>
    /// <param name="mod"></param>
    /// <param name="name"></param>
    public static AssetBundle GetBundle(BloonsTD6Mod mod, string name)
    {
        if (ResourceHandler.Bundles.TryGetValue(GetId(mod, name), out var bundle))
        {
            return bundle;
        }

        ModHelper.Error($"Couldn't find bundle with name \"{name}\"");
        var bundles = ResourceHandler.Bundles.Keys.Where(s => s.StartsWith(mod.IDPrefix)).ToList();
        if (bundles.Count == 0)
        {
            ModHelper.Error(
                $"In fact, {mod.GetModName()} doesn't have any bundles loaded. Did you forget to include them as an Embedded Resource?");
        }
        else
        {
            ModHelper.Log($"The bundles that we did find in {mod.GetModName()} have the names:");
            foreach (var s in bundles)
            {
                ModHelper.Error($"    {s.Replace(mod.IDPrefix, "")}");
            }
        }

        return null;
    }
    /// <summary>
    /// Gets a bundle from the mod T with the specified name (no file extension)
    /// </summary>
    /// <param name="name"></param>
    public static AssetBundle GetBundle<T>(string name) where T : BloonsTD6Mod => GetBundle(GetInstance<T>(), name);
    /// <summary>
    /// Gets a bundle from your mod with the specified name (no file extension)
    /// </summary>
    /// <param name="name"></param>
    protected AssetBundle GetBundle(string name) => GetBundle(mod, name);
    /// <summary>
    /// Gets a BloonsTD6Mod by its name, or returns null if none are loaded with that name
    /// </summary>
    [Obsolete("Use ModHelper.GetMod instead")]
    public static BloonsTD6Mod GetMod(string name) => ModHelper.GetMod(name);
    /// <summary>
    /// Returns whether a mod with the given name is installed
    /// </summary>
    [Obsolete("Use ModHelper.HasMod instead")]
    public static bool HasMod(string name) => ModHelper.HasMod(name);
    /// <summary>
    /// Returns whether a mod with the given name is installed, and pass it to the out param if it is
    /// </summary>
    [Obsolete("Use ModHelper.HasMod instead")]
    public static bool HasMod(string name, out BloonsTD6Mod BloonsTD6Mod) => ModHelper.HasMod(name, out BloonsTD6Mod);
    /// <summary>
    /// Gets the ID for the given ModBloon
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <returns></returns>
    public static string BloonID<T>() where T : ModBloon => GetInstance<T>().Id;
    /// <summary>
    /// Gets the GUID (thing that should be used in the display field for things) for a specific ModDisplay
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <returns></returns>
    public static string GetDisplayGUID<T>() where T : ModDisplay => GetInstance<T>().Id;
    /// <summary>
    /// Gets all loaded ModContent objects that are T or a subclass of T
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <returns></returns>
    public static List<T> GetContent<T>() where T : ModContent
    {
        return ModHelper.Mods
            .SelectMany(BloonsTD6Mod => BloonsTD6Mod.Content)
            .OfType<T>()
            .ToList();
    }
    /// <summary>
    /// Gets all loaded ModContent objects that are exactly of type T
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <returns></returns>
    public static List<T> GetInstances<T>() where T : ModContent => ModContentInstance<T>.Instances;
    /// <summary>
    /// Finds the loaded ModContent with the given Id and type T
    /// </summary>
    /// <param name="id"></param>
    /// <typeparam name="T"></typeparam>
    /// <returns></returns>
    public static T Find<T>(string id) where T : ModContent
    {
        return GetContent<T>().Find(content => content.Id == id);
    }
    /// <inheritdoc cref="Find{T}(string)" />
    public static bool TryFind<T>(string id, out T result) where T : ModContent
    {
        result = Find<T>(id);
        return result != default;
    }
    /// <summary>
    /// Gets an AudioClip from a mod by its name (no file extension included)
    /// </summary>
    /// <param name="mod">The mod</param>
    /// <param name="name">Sound name (no .wav)</param>
    /// <returns>a playable AudioClip</returns>
    public static AudioClip GetAudioClip(BloonsTD6Mod mod, string name) => mod.AudioClips.GetValueOrDefault(name);
    /// <summary>
    /// Gets an AudioClip from a mod by its name (no file extension included)
    /// </summary>
    /// <param name="name">Sound name (no .wav)</param>
    /// <typeparam name="T">The mod</typeparam>
    /// <returns>a playable AudioClip</returns>
    public static AudioClip GetAudioClip<T>(string name) where T : BloonsTD6Mod => GetAudioClip(GetInstance<T>(), name);
    /// <summary>
    /// Gets an AudioClip from this mod by its name (no file extension included)
    /// </summary>
    /// <param name="name">Sound name (no .wav)</param>
    /// <returns>a playable AudioClip</returns>
    public AudioClip GetAudioClip(string name) => GetAudioClip(mod, name);
    /// <summary>
    /// Gets an AudioSource reference for a given sound within a mod
    /// </summary>
    /// <param name="mod"></param>
    /// <param name="name">Sound name (no .wav)</param>
    /// <returns>An AudioSoundReference</returns>
    public static AudioSourceReference GetAudioSourceReference(BloonsTD6Mod mod, string name) =>
        CreateAudioSourceReference(GetId(mod, name));
    /// <summary>
    /// Gets an AudioSource reference for a given sound within a mod
    /// </summary>
    /// <param name="name">Sound name (no .wav)</param>
    /// <typeparam name="T">The mod</typeparam>
    /// <returns>An AudioSoundReference</returns>
    [Obsolete("Use GetAudioSourceReference")]
    public static AudioSourceReference CreateAudioSourceReference<T>(string name) where T : BloonsTD6Mod =>
        GetAudioSourceReference(GetInstance<T>(), name);
    /// <summary>
    /// Gets an AudioSource reference for a given sound within a mod
    /// </summary>
    /// <param name="name">Sound name (no .wav)</param>
    /// <typeparam name="T">The mod</typeparam>
    /// <returns>An AudioSoundReference</returns>
    public static AudioSourceReference GetAudioSourceReference<T>(string name) where T : BloonsTD6Mod =>
        GetAudioSourceReference(GetInstance<T>(), name);
    /// <summary>
    /// Gets an AudioSource reference for a given sound within this mod
    /// </summary>
    /// <param name="name">Sound name (no .wav)</param>
    /// <returns>An AudioSoundReference</returns>
    public AudioSourceReference GetAudioSourceReference(string name) => GetAudioSourceReference(mod, name);
    /// <summary>
    /// Gets the ID for the given ModGameMode
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <returns></returns>
    public static string GameModeId<T>() where T : ModGameMode => GetInstance<T>().Id;
    /// <summary>
    /// Gets the ID for the given ModRoundSet
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <returns></returns>
    public static string RoundSetId<T>() where T : ModRoundSet => GetInstance<T>().Id;
    /// <summary>
    /// Gets the internal tower name/id for a ModTower
    /// </summary>
    /// <param name="top">The top path tier</param>
    /// <param name="mid">The middle path tier</param>
    /// <param name="bot">The bottom path tier</param>
    /// <typeparam name="T">The ModTower type</typeparam>
    /// <returns>The tower name/id</returns>
    public static string TowerID<T>(int top = 0, int mid = 0, int bot = 0) where T : ModTower
    {
        return GetInstance<T>().TowerId(new[] {top, mid, bot});
    }
    /// <summary>
    /// Gets the TowerModel for a ModTower at a specific tier level
    /// </summary>
    /// <param name="top">The top path tier</param>
    /// <param name="mid">The middle path tier</param>
    /// <param name="bot">The bottom path tier</param>
    /// <typeparam name="T">The ModTower type</typeparam>
    /// <returns>The tower name/id</returns>
    public static TowerModel GetTowerModel<T>(int top = 0, int mid = 0, int bot = 0) where T : ModTower =>
        Game.instance.model.GetTowerFromId(TowerID<T>(top, mid, bot));
    /// <summary>
    /// Gets the internal upgrade name/id for a ModUpgrade
    /// </summary>
    /// <typeparam name="T">The ModUpgrade type</typeparam>
    /// <returns>The upgrade name/id</returns>
    public static string UpgradeID<T>() where T : ModUpgrade => GetInstance<T>().Id;
}