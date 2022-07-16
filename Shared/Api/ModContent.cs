using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using Assets.Scripts.Utils;
using BTD_Mod_Helper.Api.Bloons;
using BTD_Mod_Helper.Api.Display;
using BTD_Mod_Helper.Api.Towers;
using UnityEngine;
#if BloonsTD6
#endif

namespace BTD_Mod_Helper.Api
{
    /// <summary>
    /// ModContent serves two major purposes:
    ///     <br/>
    ///     1. It is a base class for things that needs to be loaded via reflection from mods and given Ids,
    ///     such as ModTower and ModUpgrade
    ///     <br/>
    ///     2. It is a utility class with methods to access instances of those classes and other resources
    /// </summary>
    public abstract partial class ModContent : IModContent
    {
        /// <summary>
        /// (Cross-Game compatible) The name that will be at the end of the ID for this ModContent, by default the class name
        /// </summary>
        public virtual string Name => GetType().Name;

        /// <summary>
        /// (Cross-Game compatible) The id that this ModContent will be given; a combination of the Mod's prefix and the name
        /// </summary>
        public string Id => ID;

        /// <summary>
        /// (Cross-Game compatible) Backing property for ID that's only able to be overriden internally
        /// </summary>
        protected internal virtual string ID => mod.IDPrefix + Name;

        /// <summary>
        /// (Cross-Game compatible) The BloonsMod that this content was added by
        /// </summary>
        public BloonsMod mod;

        /// <summary>
        /// (Cross-Game compatible) Used for when you want to programmatically create multiple instances of a given ModContent
        /// </summary>
        /// <returns></returns>
        public virtual IEnumerable<ModContent> Load()
        {
            yield return this;
        }

        /// <summary>
        /// (Cross-Game compatible) Registers this ModContent into the game
        /// </summary>
        public abstract void Register();

        /// <summary>
        /// (Cross-Game compatible) Used to allow some ModContent to Register before or after others
        /// </summary>
        protected virtual float RegistrationPriority => 5f;

        /// <summary>
        /// (Cross-Game compatible) How many of this ModContent should it try to register in each frame. Higher numbers could lead to faster but choppier loading.
        /// </summary>
        public virtual int RegisterPerFrame => 1;


        internal static void LoadModContent(BloonsMod mod)
        {
            mod.Content = mod.MelonAssembly.Assembly
                .GetValidTypes()
                .Where(CanLoadType)
                .SelectMany(type => CreateInstances(type, mod))
                .OrderBy(content => content.RegistrationPriority)
                .ToList();
        }


        internal readonly Stack<Action> rollbackActions = new();

        private const BindingFlags ConstructorFlags = BindingFlags.Instance |
                                                      BindingFlags.Public |
                                                      BindingFlags.NonPublic;

        private static bool CanLoadType(Type type) =>
            !type.IsAbstract &&
            !type.ContainsGenericParameters &&
            typeof(ModContent).IsAssignableFrom(type) &&
            type.GetConstructor(ConstructorFlags, null, Type.EmptyTypes, null) != null;

        /// <summary>
        /// (Cross-Game compatible) Creates the Instances of a ModContent type within a Mod and adds them to ModContentInstances
        /// </summary>
        private static IEnumerable<ModContent> CreateInstances(Type type, BloonsMod mod)
        {
            try
            {
                var instances = new List<ModContent>();
                ModContent instance;
                try
                {
                    instance = (ModContent) Activator.CreateInstance(type)!;
                }
                catch (Exception)
                {
                    ModHelper.Error($"Error creating default {type.Name}");
                    ModHelper.Error("A zero argument constructor is REQUIRED for all ModContent classes");
                    return instances;
                }

                instance.mod = mod;

                try
                {
                    instances.AddRange(instance.Load());
                    foreach (var modContent in instances)
                    {
                        modContent.mod = mod;
                    }
                }
                catch (Exception e)
                {
                    ModHelper.Error(
                        $"Failed loading instances of type {type.Name} for mod {type.Assembly.GetName().Name}");
                    ModHelper.Error(e);
                    return instances;
                }

                ModContentInstances.SetInstances(type, instances);

                return instances;
            }
            catch (Exception e)
            {
                ModHelper.Error("Failed to load " + type.Name);
                ModHelper.Error(e);
                return Array.Empty<ModContent>();
            }
        }

        /// <summary>
        /// (Cross-Game compatible) Gets a sprite reference by name for a specific mod
        /// </summary>
        /// <param name="name">The file name of your texture, without the extension</param>
        /// <typeparam name="T">Your mod's main BloonsMod extending class</typeparam>
        /// <returns>A new SpriteReference</returns>
        public static SpriteReference GetSpriteReference<T>(string name) where T : BloonsMod
        {
            return CreateSpriteReference(GetTextureGUID<T>(name));
        }

        /// <summary>
        /// (Cross-Game compatible) Gets a sprite reference by name for this mod
        /// </summary>
        /// <param name="name">The file name of your texture, without the extension</param>
        /// <returns>A new SpriteReference</returns>
        protected SpriteReference GetSpriteReference(string name)
        {
            return CreateSpriteReference(GetTextureGUID(name));
        }

        /// <summary>
        /// (Cross-Game compatible) Gets a sprite reference by name for a specific mod
        /// </summary>
        /// <param name="mod">The BloonsMod that the texture is from</param>
        /// <param name="name">The file name of your texture, without the extension</param>
        /// <returns>A new SpriteReference</returns>
        public static SpriteReference GetSpriteReference(BloonsMod mod, string name)
        {
            return CreateSpriteReference(GetTextureGUID(mod, name));
        }

        /// <summary>
        /// (Cross-Game compatible) Gets a sprite reference by name for a specific mod, returning null if the texture hasn't currently been
        /// loaded instead of an invalid SpriteReference
        /// </summary>
        /// <param name="name">The file name of your texture, without the extension</param>
        /// <typeparam name="T">Your mod's main BloonsMod extending class</typeparam>
        /// <returns>A new SpriteReference</returns>
        public static SpriteReference GetSpriteReferenceOrNull<T>(string name) where T : BloonsMod
        {
            return GetSpriteReferenceOrNull(GetInstance<T>(), name);
        }

        /// <summary>
        /// (Cross-Game compatible) Gets a sprite reference by name for this mod, returning null if the texture hasn't currently been
        /// loaded instead of an invalid SpriteReference
        /// </summary>
        /// <param name="name">The file name of your texture, without the extension</param>
        /// <returns>A new SpriteReference</returns>
        protected SpriteReference GetSpriteReferenceOrNull(string name)
        {
            return GetSpriteReferenceOrNull(mod, name);
        }

        /// <summary>
        /// (Cross-Game compatible) Gets a sprite reference by name for a specific mod,returning null if the texture hasn't currently been
        /// loaded instead of an invalid SpriteReference
        /// </summary>
        /// <param name="mod">The BloonsMod that the texture is from</param>
        /// <param name="name">The file name of your texture, without the extension</param>
        /// <returns>A new SpriteReference</returns>
        public static SpriteReference GetSpriteReferenceOrNull(BloonsMod mod, string name)
        {
            return TextureExists(mod, name) ? GetSpriteReference(mod, name) : null;
        }

        /// <summary>
        /// (Cross-Game compatible) Returns a new SpriteReference that uses the given guid
        /// </summary>
        /// <param name="guid">The guid that you'd like to assign to the SpriteReference</param>
        /// <returns></returns>
        public static SpriteReference CreateSpriteReference(string guid)
        {
#if BloonsTD6
            return new SpriteReference(guid);
#elif BloonsAT
            var reference = new SpriteReference();
            reference.guid = guid;
            return reference;
#endif
        }

        /// <summary>
        /// (Cross-Game compatible) Creates a Sprite reference from the unsigned ints that can be found for a vanilla Sprite in AssetStudio
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        public static SpriteReference CreateSpriteReference(params uint[] data)
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


        /// <summary>
        /// (Cross-Game compatible) Gets a texture's GUID by name for a specific mod
        /// </summary>
        /// <param name="mod">The BloonsMod that the texture is from</param>
        /// <param name="fileName">The file name of your texture, without the extension</param>
        /// <returns>The texture's GUID</returns>
        public static string GetTextureGUID(BloonsMod mod, string fileName)
        {
            return mod.IDPrefix + fileName;
        }

        /// <summary>
        /// (Cross-Game compatible) Gets a texture's GUID by name for a specific mod
        /// <br/>
        /// Returns null if a Texture hasn't been loaded with that name
        /// </summary>
        /// <param name="name">The file name of your texture, without the extension</param>
        /// <typeparam name="T">Your mod's main BloonsMod extending class</typeparam>
        /// <returns>The texture's GUID</returns>
        public static string GetTextureGUID<T>(string name) where T : BloonsMod
        {
            var mod = GetInstance<T>();
            if (mod == null)
            {
                BloonsMod.GotModTooSoon.Add(typeof(T));
                return typeof(T).Assembly.GetName().Name + "-" + name;
            }

            return GetTextureGUID(mod, name);
        }

        /// <summary>
        /// (Cross-Game compatible) Gets a texture's GUID by name for this mod
        /// <br/>
        /// Returns null if a Texture hasn't been loaded with that name
        /// </summary>
        /// <param name="name">The file name of your texture, without the extension</param>
        /// <returns>The texture's GUID</returns>
        public string GetTextureGUID(string name)
        {
            return GetTextureGUID(mod, name);
        }


        /// <summary>
        /// (Cross-Game compatible) Gets whether a texture with a given name has been loaded by the Mod Helper for a mod
        /// </summary>
        /// <param name="bloonsMod">The mod to look in</param>
        /// <param name="name">The file name of your texture, without the extension</param>
        public static bool TextureExists(BloonsMod bloonsMod, string name)
        {
            return ResourceHandler.Resources.ContainsKey(GetTextureGUID(bloonsMod, name));
        }

        /// <summary>
        /// (Cross-Game compatible) Gets whether a texture with a given name has been loaded by the Mod Helper for a mod
        /// </summary>
        /// <param name="name">The file name of your texture, without the extension</param>
        /// <typeparam name="T">The mod to look in</typeparam>
        public static bool TextureExists<T>(string name) where T : BloonsMod
        {
            return TextureExists(GetInstance<T>(), name);
        }

        /// <summary>
        /// (Cross-Game compatible) Gets whether a texture with a given name has been loaded by the Mod Helper for this mod
        /// </summary>
        /// <param name="name">The file name of your texture, without the extension</param>
        protected bool TextureExists(string name)
        {
            return TextureExists(mod, name);
        }

        /// <summary>
        /// (Cross-Game compatible) Constructs a Texture2D for a given texture name within a mod
        /// </summary>
        /// <param name="bloonsMod">The mod that adds this texture</param>
        /// <param name="fileName">The file name of your texture, without the extension</param>
        /// <returns>A Texture2D</returns>
        public static Texture2D GetTexture(BloonsMod bloonsMod, string fileName)
        {
            return ResourceHandler.GetTexture(GetTextureGUID(bloonsMod, fileName));
        }

        /// <summary>
        /// (Cross-Game compatible) Constructs a Texture2D for a given texture name within this mod
        /// </summary>
        /// <param name="fileName">The file name of your texture, without the extension</param>
        /// <returns>A Texture2D</returns>
        protected Texture2D GetTexture(string fileName)
        {
            return GetTexture(mod, fileName);
        }

        /// <summary>
        /// (Cross-Game compatible) Constructs a Texture2D for a given texture name within a mod
        /// </summary>
        /// <param name="fileName">The file name of your texture, without the extension</param>
        /// <returns>A Texture2D</returns>
        public static Texture2D GetTexture<T>(string fileName) where T : BloonsMod
        {
            return GetTexture(GetInstance<T>(), fileName);
        }

        /// <summary>
        /// (Cross-Game compatible) Returns the Bytes associated with a texture.
        /// </summary>
        /// <param name="fileName">The file name of your texture, without the extension.</param>
        /// <returns>The bytes associated with the texture.</returns>
        protected byte[] GetTextureBytes(string fileName)
        {
            return GetTextureBytes(mod, fileName);
        }

        /// <summary>
        /// (Cross-Game compatible) Returns the Bytes associated with a texture.
        /// </summary>
        /// <param name="bloonsMod">The mod that adds this texture.</param>
        /// <param name="fileName">The file name of your texture, without the extension.</param>
        /// <returns>The bytes associated with the texture.</returns>
        public static byte[] GetTextureBytes(BloonsMod bloonsMod, string fileName)
        {
            return ResourceHandler.GetTextureBytes(GetTextureGUID(bloonsMod, fileName));
        }

        /// <summary>
        /// (Cross-Game compatible) Returns the Bytes associated with a texture.
        /// </summary>
        /// <param name="fileName">The file name of your texture, without the extension.</param>
        /// <returns>The bytes associated with the texture.</returns>
        public static byte[] GetTextureBytes<T>(string fileName) where T : BloonsMod
        {
            return GetTextureBytes(GetInstance<T>(), fileName);
        }

        /// <summary>
        /// (Cross-Game compatible) Constructs a Sprite for a given texture name within a given mod
        /// </summary>
        /// <param name="mod"></param>
        /// <param name="name">The file name of your texture, without the extension</param>
        /// <param name="pixelsPerUnit">The pixels per unit for the Sprite to have</param>
        /// <returns>A Sprite</returns>
        public static Sprite GetSprite(BloonsMod mod, string name, float pixelsPerUnit = 10f)
        {
            return ResourceHandler.GetSprite(GetTextureGUID(mod, name), pixelsPerUnit);
        }

        /// <summary>
        /// (Cross-Game compatible) Constructs a Sprite for a given texture name within this mod
        /// </summary>
        /// <param name="name">The file name of your texture, without the extension</param>
        /// <param name="pixelsPerUnit">The pixels per unit for the Sprite to have</param>
        /// <returns>A Sprite</returns>
        protected Sprite GetSprite(string name, float pixelsPerUnit = 10f)
        {
            return GetSprite(mod, name, pixelsPerUnit);
        }

        /// <summary>
        /// (Cross-Game compatible) Constructs a Sprite for a given texture name within a given mod
        /// </summary>
        /// <param name="name">The file name of your texture, without the extension</param>
        /// <param name="pixelsPerUnit">The pixels per unit for the Sprite to have</param>
        /// <returns>A Sprite</returns>
        public static Sprite GetSprite<T>(string name, float pixelsPerUnit = 10f) where T : BloonsMod
        {
            return GetSprite(GetInstance<T>(), name, pixelsPerUnit);
        }

        /// <summary>
        /// (Cross-Game compatible) Gets the singleton instance of a particular ModContent or BloonsMod based on its type
        /// </summary>
        /// <typeparam name="T">The type to get the instance of</typeparam>
        /// <returns>The singleton instance of it</returns>
        public static T GetInstance<T>() where T : IModContent => ModContentInstance<T>.Instance;

        /// <summary>
        /// (Cross-Game compatible) Gets the official instance of a particular ModContent or BloonsMod based on its type
        /// </summary>
        /// <param name="type">The type to get the instance of</param>
        /// <returns>The official instance of it</returns>
        public static IModContent GetInstance(Type type)
        {
            return ModContentInstances.Instances.TryGetValue(type, out var instance) ? instance[0] : default;
        }

        /// <summary>
        /// (Cross-Game compatible) Gets a bundle from a mod with the specified name (no file extension)
        /// </summary>
        /// <param name="mod"></param>
        /// <param name="name"></param>
        public static AssetBundle GetBundle(BloonsMod mod, string name)
        {
            if (ResourceHandler.Bundles.TryGetValue(mod.IDPrefix + name, out var bundle))
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
        /// (Cross-Game compatible) Gets a bundle from the mod T with the specified name (no file extension)
        /// </summary>
        /// <param name="name"></param>
        public static AssetBundle GetBundle<T>(string name) where T : BloonsMod
        {
            return GetBundle(GetInstance<T>(), name);
        }

        /// <summary>
        /// (Cross-Game compatible) Gets a bundle from your mod with the specified name (no file extension)
        /// </summary>
        /// <param name="name"></param>
        protected AssetBundle GetBundle(string name)
        {
            return GetBundle(mod, name);
        }

        /// <summary>
        /// (Cross-Game compatible) Gets a BloonsMod by its name, or returns null if none are loaded with that name
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public static BloonsMod GetMod(string name)
        {
            return ModHelper.Mods.FirstOrDefault(bloonsMod => bloonsMod.GetModName() == name);
        }


        /// <summary>
        /// (Cross-Game compatible) Gets the ID for the given ModBloon
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public static string BloonID<T>() where T : ModBloon
        {
            return GetInstance<T>().Id;
        }

        /// <summary>
        /// (Cross-Game compatible) Gets the GUID (thing that should be used in the display field for things) for a specific ModDisplay
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public static string GetDisplayGUID<T>() where T : ModDisplay
        {
            return GetInstance<T>().Id;
        }

        /// <summary>
        /// (Cross-Game compatible) Gets all loaded ModContent objects that are T or a subclass of T
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public static List<T> GetContent<T>() where T : ModContent
        {
            return ModContentInstances.Instances
                .Where(pair => typeof(T).IsAssignableFrom(pair.Key))
                .SelectMany(pair => pair.Value)
                .Cast<T>()
                .ToList();
        }

        /// <summary>
        /// (Cross-Game compatible) Gets all loaded ModContent objects that are of type T 
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
            if (typeof(ModTower).IsAssignableFrom(typeof(T)) &&
                ModTowerHelper.ModTowerCache.TryGetValue(id, out var modTower)) return modTower as T;
            if (typeof(ModUpgrade).IsAssignableFrom(typeof(T)) &&
                ModUpgrade.Cache.TryGetValue(id, out var modUpgrade)) return modUpgrade as T;
            if (typeof(ModBloon).IsAssignableFrom(typeof(T)) &&
                ModBloon.Cache.TryGetValue(id, out var modBloon)) return modBloon as T;

            return GetContent<T>().FirstOrDefault(content => content.Id == id);
        }
    }
}