using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using Assets.Scripts.Unity;
#if BloonsTD6
using Assets.Scripts.Models.Towers;
using BTD_Mod_Helper.Api.Towers;
#elif BloonsAT
#endif
using Assets.Scripts.Utils;
using BTD_Mod_Helper.Api.Bloons;
using BTD_Mod_Helper.Api.Display;
using BTD_Mod_Helper.Api.Scenarios;
using BTD_Mod_Helper.Extensions;
using MelonLoader;
using UnityEngine;

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
    public abstract class ModContent : IModContent
    {
        /// <summary>
        /// The name that will be at the end of the ID for this ModContent, by default the class name
        /// </summary>
        public virtual string Name => GetType().Name;

        /// <summary>
        /// The id that this ModContent will be given; a combination of the Mod's prefix and the name
        /// </summary>
        public string Id => ID;

        /// <summary>
        /// Backing property for ID that's only able to be overrided internally
        /// </summary>
        protected internal virtual string ID => mod.IDPrefix + Name;

        /// <summary>
        /// The BloonsMod that this content was added by
        /// </summary>
        public BloonsMod mod;

        /// <summary>
        /// Used for when you want to programmatically create multiple instances of a given ModContent
        /// </summary>
        /// <returns></returns>
        public virtual IEnumerable<ModContent> Load()
        {
            yield return this;
        }

        /// <summary>
        /// Registers this ModContent into the game
        /// </summary>
        public abstract void Register();

        /// <summary>
        /// Used to allow some ModContent to Register before or after others
        /// </summary>
        protected virtual float RegistrationPriority => 5f;

        /// <summary>
        /// How many of this ModContent should it try to register in each frame. Higher numbers could lead to faster but choppier loading.
        /// </summary>
        public virtual int RegisterPerFrame => 1;


        internal static void LoadModContent(BloonsMod mod)
        {
            mod.Content = mod.Assembly
                .GetValidTypes()
                .Where(CanLoadType)
                .SelectMany(type => CreateInstances(type, mod))
                .Where(content => content != null)
                .OrderBy(content => content.RegistrationPriority)
                .ToList();
        }

        private const BindingFlags ConstructorFlags = BindingFlags.Instance |
                                                      BindingFlags.Public |
                                                      BindingFlags.NonPublic;

        private static bool CanLoadType(Type type) =>
            !type.IsAbstract &&
            !type.ContainsGenericParameters &&
            typeof(ModContent).IsAssignableFrom(type) &&
            type.GetConstructor(ConstructorFlags, null, Type.EmptyTypes, null) != null;

        /// <summary>
        /// Creates the Instances of a ModContent type within a Mod and adds them to ModContentInstances
        /// </summary>
        private static IEnumerable<ModContent> CreateInstances(Type type, BloonsMod mod)
        {
            try
            {
                ModContent instance;
                try
                {
                    instance = (ModContent) Activator.CreateInstance(type);
                }
                catch (Exception)
                {
                    ModHelper.Error($"Error creating default {type.Name}");
                    ModHelper.Error("A zero argument constructor is REQUIRED for all ModContent classes");
                    throw;
                }

                instance.mod = mod;

                var instances = instance.Load().ToList();
                foreach (var modContent in instances)
                {
                    modContent.mod = mod;
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
        /// Gets a sprite reference by name for a specific mod
        /// </summary>
        /// <param name="name">The file name of your texture, without the extension</param>
        /// <typeparam name="T">Your mod's main BloonsMod extending class</typeparam>
        /// <returns>A new SpriteReference</returns>
        public static SpriteReference GetSpriteReference<T>(string name) where T : BloonsMod
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
        /// <param name="mod">The BloonsMod that the texture is from</param>
        /// <param name="name">The file name of your texture, without the extension</param>
        /// <returns>A new SpriteReference, or null if there's no resource</returns>
        public static SpriteReference GetSpriteReference(BloonsMod mod, string name)
        {
            var guid = GetTextureGUID(mod, name);
            if (ResourceHandler.resources.ContainsKey(guid))
            {
                return CreateSpriteReference(guid);
            }

            return null;
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
        /// Creates a Sprite reference from the unsigned ints that can be found for a Sprite in AssetStudio
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
        /// Gets a texture's GUID by name for a specific mod
        /// <br/>
        /// Returns null if a Texture hasn't been loaded with that name
        /// </summary>
        /// <param name="mod">The BloonsMod that the texture is from</param>
        /// <param name="fileName">The file name of your texture, without the extension</param>
        /// <returns>The texture's GUID</returns>
        public static string GetTextureGUID(BloonsMod mod, string fileName)
        {
            var guid = mod?.IDPrefix + fileName;
            return ResourceHandler.resources.ContainsKey(guid) ? guid : default;
        }

        /// <summary>
        /// Gets a texture's GUID by name for a specific mod
        /// <br/>
        /// Returns null if a Texture hasn't been loaded with that name
        /// </summary>
        /// <param name="name">The file name of your texture, without the extension</param>
        /// <typeparam name="T">Your mod's main BloonsMod extending class</typeparam>
        /// <returns>The texture's GUID</returns>
        public static string GetTextureGUID<T>(string name) where T : BloonsMod
        {
            return GetTextureGUID(GetInstance<T>(), name);
        }

        /// <summary>
        /// Gets a texture's GUID by name for this mod
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
        /// Constructs a Texture2D for a given texture name within a mod
        /// </summary>
        /// <param name="bloonsMod">The mod that adds this texture</param>
        /// <param name="fileName">The file name of your texture, without the extension</param>
        /// <returns>A Texture2D</returns>
        public static Texture2D GetTexture(BloonsMod bloonsMod, string fileName)
        {
            return ResourceHandler.GetTexture(GetTextureGUID(bloonsMod, fileName));
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
        public static Texture2D GetTexture<T>(string fileName) where T : BloonsMod
        {
            return GetTexture(GetInstance<T>(), fileName);
        }

        /// <summary>
        /// Constructs a Sprite for a given texture name within a given mod
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
        /// Constructs a Sprite for a given texture name within a given mod
        /// </summary>
        /// <param name="name">The file name of your texture, without the extension</param>
        /// <param name="pixelsPerUnit">The pixels per unit for the Sprite to have</param>
        /// <returns>A Sprite</returns>
        public static Sprite GetSprite<T>(string name, float pixelsPerUnit = 10f) where T : BloonsMod
        {
            return GetSprite(GetInstance<T>(), name, pixelsPerUnit);
        }

#if BloonsTD6
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

        /// <summary>
        /// Gets the internal tower set id for a given TowerSet
        /// </summary>
        /// <typeparam name="T">The ModUpgrade type</typeparam>
        /// <returns>The upgrade name/id</returns>
        public static string TowerSet<T>() where T : ModTowerSet
        {
            return GetInstance<T>().Id;
        }

        /// <summary>
        /// Gets all loaded ModContent objects that are of type T 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public static List<T> GetInstances<T>() where T : ModContent
        {
            return ModContentInstance<T>.Instances;
        }

        /// <summary>
        /// Gets all loaded ModContent objects that are T or a subclass of T
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

#endif

        /// <summary>
        /// Gets the singleton instance of a particular ModContent or BloonsMod based on its type
        /// </summary>
        /// <typeparam name="T">The type to get the instance of</typeparam>
        /// <returns>The singleton instance of it</returns>
        public static T GetInstance<T>() where T : IModContent
        {
            var instance = ModContentInstance<T>.Instance;
            if (instance == null)
            {
                ModHelper.Log($"The instance was null for {typeof(T).Name}");
            }

            return instance;
        }

        /// <summary>
        /// Gets the official instance of a particular ModContent or BloonsMod based on its type
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
        /// Gets a bundle from the mod T with the specified name (no file extension)
        /// </summary>
        /// <param name="name"></param>
        public static AssetBundle GetBundle<T>(string name) where T : BloonsMod
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
        /// Gets a BloonsMod by its name, or returns null if none are loaded with that name
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public static BloonsMod GetMod(string name)
        {
            return MelonHandler.Mods.OfType<BloonsMod>().FirstOrDefault(bloonsMod => bloonsMod.GetModName() == name);
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
    }
}