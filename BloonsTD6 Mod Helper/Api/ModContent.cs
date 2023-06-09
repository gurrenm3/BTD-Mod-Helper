using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using BTD_Mod_Helper.Api.Bloons;
using BTD_Mod_Helper.Api.Display;
using BTD_Mod_Helper.Api.Scenarios;
using BTD_Mod_Helper.Api.Towers;
using Il2CppAssets.Scripts.Models.Towers;
using Il2CppAssets.Scripts.Unity;
using Il2CppAssets.Scripts.Utils;
using UnityEngine;
namespace BTD_Mod_Helper.Api;

/// <summary>
/// ModContent serves two major purposes:
/// <br />
/// 1. It is a base class for things that needs to be loaded via reflection from mods and given Ids,
///     such as ModTower and ModUpgrade
/// <br />
/// 2. It is a utility class with methods to access instances of those classes and other resources
/// </summary>
public abstract class ModContent : IModContent, IComparable<ModContent>
{

    private const BindingFlags ConstructorFlags = BindingFlags.Instance |
                                                  BindingFlags.Public |
                                                  BindingFlags.NonPublic;

    internal const string HijackSpriteAtlas = "Ui";


    internal readonly Stack<Action> rollbackActions = new();

    /// <summary>
    /// The BloonsTD6Mod that this content was added by
    /// </summary>
    public BloonsTD6Mod mod;
    /// <summary>
    /// The name that will be at the end of the ID for this ModContent, by default the class name
    /// </summary>
    public virtual string Name => GetType().Name;

    /// <summary>
    /// The id that this ModContent will be given; a combination of the Mod's prefix and the name
    /// </summary>
    public string Id => ID;

    /// <summary>
    /// Backing property for ID that's only able to be overriden internally
    /// </summary>
    private protected virtual string ID => GetId(mod, Name);

    /// <summary>
    /// Used to allow some ModContent to Register before or after others
    /// </summary>
    /// <exclude />
    protected virtual float RegistrationPriority => 5f;

    /// <summary>
    /// The order that this ModContent will be loaded/registered in by Mod Helper.
    /// Useful for changing the ordering that it will appear in in-game relative to other content of this type in your mod,
    /// or for making certain content load before others like may be necessary for sub-towers.
    /// Default/0 will use arbitrary ordering.
    /// </summary>
    protected virtual int Order => 0;

    /// <summary>
    /// How many of this ModContent should it try to register in each frame. Higher numbers could lead to faster but choppier
    /// loading.
    /// </summary>
    /// <exclude />
    public virtual int RegisterPerFrame => 20;

    /// <inheritdoc />
    public int CompareTo(ModContent other)
    {
        var compareTo = Order.CompareTo(other.Order);
        if (compareTo == 0)
        {
            compareTo = mod.Priority.CompareTo(other.mod.Priority);
        }
        if (compareTo == 0)
        {
            compareTo = string.Compare(Id, other.Id, StringComparison.Ordinal);
        }
        if (compareTo == 0)
        {
            compareTo = GetHashCode().CompareTo(other.GetHashCode());
        }
        return compareTo;
    }

    /// <summary>
    /// Used for when you want to programmatically create multiple instances of a given ModContent
    /// </summary>
    /// <returns></returns>
    /// <exclude />
    public virtual IEnumerable<ModContent> Load()
    {
        yield return this;
    }

    /// <summary>
    /// Registers this ModContent into the game
    /// </summary>
    /// <exclude />
    public abstract void Register();


    internal static void LoadModContent(BloonsTD6Mod mod)
    {
        mod.Content = mod.GetAssembly()
            .GetValidTypes()
            .Where(CanLoadType)
            .Select(type => CreateInstance(type, mod))
            .Where(content => content != null)
            .OrderBy<ModContent, float>(content => content.RegistrationPriority)
            .ThenBy(content => content.Order)
            .SelectMany(Load)
            .OrderBy(content => content.RegistrationPriority)
            .ThenBy(content => content.Order)
            .ToList();
    }

    private static bool CanLoadType(Type type)
    {
        return !type.IsAbstract &&
               !type.ContainsGenericParameters &&
               typeof(ModContent).IsAssignableFrom(type) &&
               type.GetConstructor(ConstructorFlags, null, Type.EmptyTypes, null) != null;
    }

    private static ModContent CreateInstance(Type type, BloonsTD6Mod mod)
    {
        ModContent instance;
        try
        {
            instance = (ModContent) Activator.CreateInstance(type)!;
            instance.mod = mod;
            ModContentInstances.AddInstance(type, instance);
        }
        catch (Exception e)
        {
            ModHelper.Error($"Error creating default {type.Name}");
            ModHelper.Error("A zero argument constructor is REQUIRED for all ModContent classes");
            ModHelper.Error(e);
            return null;
        }

        return instance;
    }

    /// <summary>
    /// Creates the Instances of a ModContent type within a Mod and adds them to ModContentInstances
    /// </summary>
    private static IEnumerable<ModContent> Load(ModContent instance)
    {
        var type = instance.GetType();
        var content = new List<ModContent>();
        try
        {
            content.AddRange(instance.Load());
            var instances = new List<ModContent>();
            foreach (var modContent in content)
            {
                modContent.mod = instance.mod;
                if (instance.GetType().IsInstanceOfType(modContent))
                {
                    instances.Add(modContent);
                }
            }

            ModContentInstances.AddInstances(type, instances);
        }
        catch (Exception e)
        {
            ModHelper.Error(
                $"Failed loading instances of type {type.Name} for mod {type.Assembly.GetName().Name}");
            ModHelper.Error(e);
        }

        return content;
    }

    /// <summary>
    /// Gets a sprite reference by name for a specific mod
    /// </summary>
    /// <param name="name">The file name of your texture, without the extension</param>
    /// <typeparam name="T">Your mod's main BloonsTD6Mod extending class</typeparam>
    /// <returns>A new SpriteReference</returns>
    public static SpriteReference GetSpriteReference<T>(string name) where T : BloonsTD6Mod
    {
        return CreateSpriteReference(GetTextureGUID<T>(name));
    }

    /// <summary>
    /// Gets a sprite reference by name for this mod
    /// </summary>
    /// <param name="name">The file name of your texture, without the extension</param>
    /// <returns>A new SpriteReference</returns>
    protected SpriteReference GetSpriteReference(string name)
    {
        return CreateSpriteReference(GetTextureGUID(name));
    }

    /// <summary>
    /// Gets a sprite reference by name for a specific mod
    /// </summary>
    /// <param name="mod">The BloonsTD6Mod that the texture is from</param>
    /// <param name="name">The file name of your texture, without the extension</param>
    /// <returns>A new SpriteReference</returns>
    public static SpriteReference GetSpriteReference(BloonsTD6Mod mod, string name)
    {
        return CreateSpriteReference(GetTextureGUID(mod, name));
    }

    /// <summary>
    /// Gets a sprite reference by name for a specific mod, returning null if the texture hasn't currently been
    /// loaded instead of an invalid SpriteReference
    /// </summary>
    /// <param name="name">The file name of your texture, without the extension</param>
    /// <typeparam name="T">Your mod's main BloonsTD6Mod extending class</typeparam>
    /// <returns>A new SpriteReference</returns>
    public static SpriteReference GetSpriteReferenceOrNull<T>(string name) where T : BloonsTD6Mod
    {
        return GetSpriteReferenceOrNull(GetInstance<T>(), name);
    }

    /// <summary>
    /// Gets a sprite reference by name for this mod, returning null if the texture hasn't currently been
    /// loaded instead of an invalid SpriteReference
    /// </summary>
    /// <param name="name">The file name of your texture, without the extension</param>
    /// <returns>A new SpriteReference</returns>
    protected SpriteReference GetSpriteReferenceOrNull(string name)
    {
        return GetSpriteReferenceOrNull(mod, name);
    }

    /// <summary>
    /// Gets a sprite reference by name for a specific mod, returning null if the texture hasn't currently been
    /// loaded instead of an invalid SpriteReference
    /// </summary>
    /// <param name="mod">The BloonsTD6Mod that the texture is from</param>
    /// <param name="name">The file name of your texture, without the extension</param>
    /// <returns>A new SpriteReference</returns>
    public static SpriteReference GetSpriteReferenceOrNull(BloonsTD6Mod mod, string name)
    {
        return TextureExists(mod, name) ? GetSpriteReference(mod, name) : null;
    }

    /// <summary>
    /// Gets a sprite reference by name for a specific mod, or if the mod does not include a texture with that name,
    /// treats it as a vanilla sprite reference
    /// </summary>
    /// <param name="mod">The BloonsTD6Mod that the texture is from</param>
    /// <param name="name">The file name of your texture, without the extension</param>
    /// <returns>A new SpriteReference</returns>
    public static SpriteReference GetSpriteReferenceOrDefault(BloonsTD6Mod mod, string name)
    {
        return TextureExists(mod, name) ? GetSpriteReference(mod, name) : CreateSpriteReference(name);
    }

    /// <summary>
    /// Gets a sprite reference by name for a specific mod, or if the mod does not include a texture with that name,
    /// treats it as a vanilla sprite reference
    /// </summary>
    /// <param name="name">The file name of your texture, without the extension</param>
    /// <typeparam name="T">Your mod's main BloonsTD6Mod extending class</typeparam>
    /// <returns>A new SpriteReference</returns>
    public static SpriteReference GetSpriteReferenceOrDefault<T>(string name) where T : BloonsTD6Mod
    {
        return GetSpriteReferenceOrDefault(GetInstance<T>(), name);
    }

    /// <summary>
    /// Gets a sprite reference by name for a specific mod, or if the mod does not include a texture with that name,
    /// treats it as a vanilla sprite reference
    /// </summary>
    /// <param name="name">The file name of your texture, without the extension</param>
    /// <returns>A new SpriteReference</returns>
    protected SpriteReference GetSpriteReferenceOrDefault(string name)
    {
        return GetSpriteReferenceOrDefault(mod, name);
    }

    /// <summary>
    /// Returns a new SpriteReference that uses the given guid
    /// </summary>
    /// <param name="guid">The guid that you'd like to assign to the SpriteReference</param>
    public static SpriteReference CreateSpriteReference(string guid)
    {
        return new SpriteReference
        {
            guidRef = guid
        };
    }

    /// <summary>
    /// Returns a new PrefabReference that uses the given guid
    /// </summary>
    /// <param name="guid">The guid that you'd like to assign to the PrefabReference</param>
    public static PrefabReference CreatePrefabReference(string guid)
    {
        return new PrefabReference
        {
            guidRef = guid
        };
    }

    /// <summary>
    /// Returns a new AudioSourceReference that uses the given guid
    /// </summary>
    /// <param name="guid">The guid that you'd like to assign to the AudioSourceReference</param>
    public static AudioSourceReference CreateAudioSourceReference(string guid)
    {
        return new AudioSourceReference
        {
            guidRef = guid
        };
    }

    /// <summary>
    /// Creates a Prefab Reference for a ModDisplay
    /// </summary>
    public static PrefabReference CreatePrefabReference<T>() where T : ModDisplay
    {
        return CreatePrefabReference(GetInstance<T>().Id);
    }

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

    internal static string WrapGuid(string orig)
    {
        return $"{HijackSpriteAtlas}[{orig}]";
    }

    /// <summary>
    /// Gets a texture's GUID by name for a specific mod
    /// </summary>
    /// <param name="mod">The BloonsTD6Mod that the texture is from</param>
    /// <param name="fileName">The file name of your texture, without the extension</param>
    /// <returns>The texture's GUID</returns>
    public static string GetTextureGUID(BloonsTD6Mod mod, string fileName)
    {
        return WrapGuid(GetId(mod, fileName));
    }

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
    public string GetTextureGUID(string name)
    {
        return GetTextureGUID(mod, name);
    }


    /// <summary>
    /// Gets the id of a resource by appending the mod's ID prefix to its name
    /// </summary>
    public static string GetId(BloonsTD6Mod BloonsTD6Mod, string name)
    {
        return BloonsTD6Mod.IDPrefix + name;
    }

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
    public string GetId(string name)
    {
        return GetId(mod, name);
    }


    /// <summary>
    /// Gets whether a texture with a given name has been loaded by the Mod Helper for a mod
    /// </summary>
    /// <param name="BloonsTD6Mod">The mod to look in</param>
    /// <param name="name">The file name of your texture, without the extension</param>
    public static bool TextureExists(BloonsTD6Mod BloonsTD6Mod, string name)
    {
        return ResourceHandler.Resources.ContainsKey(GetId(BloonsTD6Mod, name));
    }

    /// <summary>
    /// Gets whether a texture with a given name has been loaded by the Mod Helper for a mod
    /// </summary>
    /// <param name="name">The file name of your texture, without the extension</param>
    /// <typeparam name="T">The mod to look in</typeparam>
    public static bool TextureExists<T>(string name) where T : BloonsTD6Mod
    {
        return TextureExists(GetInstance<T>(), name);
    }

    /// <summary>
    /// Gets whether a texture with a given name has been loaded by the Mod Helper for this mod
    /// </summary>
    /// <param name="name">The file name of your texture, without the extension</param>
    protected bool TextureExists(string name)
    {
        return TextureExists(mod, name);
    }

    /// <summary>
    /// Constructs a Texture2D for a given texture name within a mod
    /// </summary>
    /// <param name="BloonsTD6Mod">The mod that adds this texture</param>
    /// <param name="fileName">The file name of your texture, without the extension</param>
    /// <returns>A Texture2D</returns>
    public static Texture2D GetTexture(BloonsTD6Mod BloonsTD6Mod, string fileName)
    {
        return ResourceHandler.GetTexture(GetId(BloonsTD6Mod, fileName));
    }

    /// <summary>
    /// Constructs a Texture2D for a given texture name within this mod
    /// </summary>
    /// <param name="fileName">The file name of your texture, without the extension</param>
    /// <returns>A Texture2D</returns>
    protected Texture2D GetTexture(string fileName)
    {
        return GetTexture(mod, fileName);
    }

    /// <summary>
    /// Constructs a Texture2D for a given texture name within a mod
    /// </summary>
    /// <param name="fileName">The file name of your texture, without the extension</param>
    /// <returns>A Texture2D</returns>
    public static Texture2D GetTexture<T>(string fileName) where T : BloonsTD6Mod
    {
        return GetTexture(GetInstance<T>(), fileName);
    }

    /// <summary>
    /// Returns the Bytes associated with a texture.
    /// </summary>
    /// <param name="fileName">The file name of your texture, without the extension.</param>
    /// <returns>The bytes associated with the texture.</returns>
    protected byte[] GetTextureBytes(string fileName)
    {
        return GetTextureBytes(mod, fileName);
    }

    /// <summary>
    /// Returns the Bytes associated with a texture.
    /// </summary>
    /// <param name="BloonsTD6Mod">The mod that adds this texture.</param>
    /// <param name="fileName">The file name of your texture, without the extension.</param>
    /// <returns>The bytes associated with the texture.</returns>
    public static byte[] GetTextureBytes(BloonsTD6Mod BloonsTD6Mod, string fileName)
    {
        return ResourceHandler.GetTextureBytes(GetTextureGUID(BloonsTD6Mod, fileName));
    }

    /// <summary>
    /// Returns the Bytes associated with a texture.
    /// </summary>
    /// <param name="fileName">The file name of your texture, without the extension.</param>
    /// <returns>The bytes associated with the texture.</returns>
    public static byte[] GetTextureBytes<T>(string fileName) where T : BloonsTD6Mod
    {
        return GetTextureBytes(GetInstance<T>(), fileName);
    }

    /// <summary>
    /// Constructs a Sprite for a given texture name within a given mod
    /// </summary>
    /// <param name="mod"></param>
    /// <param name="name">The file name of your texture, without the extension</param>
    /// <param name="pixelsPerUnit">The pixels per unit for the Sprite to have</param>
    /// <returns>A Sprite</returns>
    public static Sprite GetSprite(BloonsTD6Mod mod, string name, float pixelsPerUnit = 10f)
    {
        return ResourceHandler.GetSprite(GetId(mod, name), pixelsPerUnit);
    }


    /// <summary>
    /// Constructs a Sprite for a given texture name within a given mod
    /// </summary>
    /// <param name="name">The file name of your texture, without the extension</param>
    /// <param name="pixelsPerUnit">The pixels per unit for the Sprite to have</param>
    /// <returns>A Sprite</returns>
    public static Sprite GetSprite<T>(string name, float pixelsPerUnit = 10f) where T : BloonsTD6Mod
    {
        return GetSprite(GetInstance<T>(), name, pixelsPerUnit);
    }

    /// <summary>
    /// Constructs a Sprite for a given texture name within this mod
    /// </summary>
    /// <param name="name">The file name of your texture, without the extension</param>
    /// <param name="pixelsPerUnit">The pixels per unit for the Sprite to have</param>
    /// <returns>A Sprite</returns>
    protected Sprite GetSprite(string name, float pixelsPerUnit = 10f)
    {
        return GetSprite(mod, name, pixelsPerUnit);
    }

    /// <summary>
    /// Gets the singleton instance of a particular ModContent or BloonsTD6Mod based on its type
    /// </summary>
    /// <typeparam name="T">The type to get the instance of</typeparam>
    /// <returns>The singleton instance of it</returns>
    public static T GetInstance<T>() where T : IModContent
    {
        return ModContentInstance<T>.Instance;
    }

    /// <summary>
    /// Gets the official instance of a particular ModContent or BloonsTD6Mod based on its type
    /// </summary>
    /// <param name="type">The type to get the instance of</param>
    /// <returns>The official instance of it</returns>
    public static IModContent GetInstance(Type type)
    {
        return ModContentInstances.Instances.TryGetValue(type, out var instance) ? instance[0] : default;
    }

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
    public static AssetBundle GetBundle<T>(string name) where T : BloonsTD6Mod
    {
        return GetBundle(GetInstance<T>(), name);
    }

    /// <summary>
    /// Gets a bundle from your mod with the specified name (no file extension)
    /// </summary>
    /// <param name="name"></param>
    protected AssetBundle GetBundle(string name)
    {
        return GetBundle(mod, name);
    }

    /// <summary>
    /// Gets a BloonsTD6Mod by its name, or returns null if none are loaded with that name
    /// </summary>
    [Obsolete("Use ModHelper.GetMod instead")]
    public static BloonsTD6Mod GetMod(string name)
    {
        return ModHelper.GetMod(name);
    }

    /// <summary>
    /// Returns whether a mod with the given name is installed
    /// </summary>
    [Obsolete("Use ModHelper.HasMod instead")]
    public static bool HasMod(string name)
    {
        return ModHelper.HasMod(name);
    }

    /// <summary>
    /// Returns whether a mod with the given name is installed, and pass it to the out param if it is
    /// </summary>
    [Obsolete("Use ModHelper.HasMod instead")]
    public static bool HasMod(string name, out BloonsTD6Mod BloonsTD6Mod)
    {
        return ModHelper.HasMod(name, out BloonsTD6Mod);
    }


    /// <summary>
    /// Gets the ID for the given ModBloon
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <returns></returns>
    public static string BloonID<T>() where T : ModBloon
    {
        return GetInstance<T>().Id;
    }

    /// <summary>
    /// Gets the GUID (thing that should be used in the display field for things) for a specific ModDisplay
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <returns></returns>
    public static string GetDisplayGUID<T>() where T : ModDisplay
    {
        return GetInstance<T>().Id;
    }

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
    public static List<T> GetInstances<T>() where T : ModContent
    {
        return ModContentInstance<T>.Instances;
    }

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
    public static AudioClip GetAudioClip(BloonsTD6Mod mod, string name)
    {
        return mod.AudioClips.GetValueOrDefault(name);
    }

    /// <summary>
    /// Gets an AudioClip from a mod by its name (no file extension included)
    /// </summary>
    /// <param name="name">Sound name (no .wav)</param>
    /// <typeparam name="T">The mod</typeparam>
    /// <returns>a playable AudioClip</returns>
    public static AudioClip GetAudioClip<T>(string name) where T : BloonsTD6Mod
    {
        return GetAudioClip(GetInstance<T>(), name);
    }

    /// <summary>
    /// Gets an AudioClip from this mod by its name (no file extension included)
    /// </summary>
    /// <param name="name">Sound name (no .wav)</param>
    /// <returns>a playable AudioClip</returns>
    public AudioClip GetAudioClip(string name)
    {
        return GetAudioClip(mod, name);
    }

    /// <summary>
    /// Gets an AudioSource reference for a given sound within a mod
    /// </summary>
    /// <param name="mod"></param>
    /// <param name="name">Sound name (no .wav)</param>
    /// <returns>An AudioSoundReference</returns>
    public static AudioSourceReference GetAudioSourceReference(BloonsTD6Mod mod, string name)
    {
        return CreateAudioSourceReference(GetId(mod, name));
    }

    /// <summary>
    /// Gets an AudioSource reference for a given sound within a mod
    /// </summary>
    /// <param name="name">Sound name (no .wav)</param>
    /// <typeparam name="T">The mod</typeparam>
    /// <returns>An AudioSoundReference</returns>
    [Obsolete("Use GetAudioSourceReference")]
    public static AudioSourceReference CreateAudioSourceReference<T>(string name) where T : BloonsTD6Mod
    {
        return GetAudioSourceReference(GetInstance<T>(), name);
    }

    /// <summary>
    /// Gets an AudioSource reference for a given sound within a mod
    /// </summary>
    /// <param name="name">Sound name (no .wav)</param>
    /// <typeparam name="T">The mod</typeparam>
    /// <returns>An AudioSoundReference</returns>
    public static AudioSourceReference GetAudioSourceReference<T>(string name) where T : BloonsTD6Mod
    {
        return GetAudioSourceReference(GetInstance<T>(), name);
    }

    /// <summary>
    /// Gets an AudioSource reference for a given sound within this mod
    /// </summary>
    /// <param name="name">Sound name (no .wav)</param>
    /// <returns>An AudioSoundReference</returns>
    public AudioSourceReference GetAudioSourceReference(string name)
    {
        return GetAudioSourceReference(mod, name);
    }

    internal int GetOrder()
    {
        return Order;
    }

    /// <summary>
    /// Gets the ID for the given ModGameMode
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <returns></returns>
    public static string GameModeId<T>() where T : ModGameMode
    {
        return GetInstance<T>().Id;
    }

    /// <summary>
    /// Gets the ID for the given ModRoundSet
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <returns></returns>
    public static string RoundSetId<T>() where T : ModRoundSet
    {
        return GetInstance<T>().Id;
    }

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
    public static TowerModel GetTowerModel<T>(int top = 0, int mid = 0, int bot = 0) where T : ModTower
    {
        return Game.instance.model.GetTowerFromId(TowerID<T>(top, mid, bot));
    }

    /// <summary>
    /// Gets the internal upgrade name/id for a ModUpgrade
    /// </summary>
    /// <typeparam name="T">The ModUpgrade type</typeparam>
    /// <returns>The upgrade name/id</returns>
    public static string UpgradeID<T>() where T : ModUpgrade
    {
        return GetInstance<T>().Id;
    }
}