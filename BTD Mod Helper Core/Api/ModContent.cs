using System;
using System.Collections.Generic;
using System.Linq;
using Assets.Scripts.Unity;
#if BloonsTD6
using Assets.Scripts.Models.Towers;
using BTD_Mod_Helper.Api.Towers;
#elif BloonsAT
#endif
using Assets.Scripts.Utils;
using BTD_Mod_Helper.Api.Display;
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
    public class ModContent
    {
        /// <summary>
        /// The name that will be at the end of the ID for this ModContent, by default the class name
        /// </summary>
        public virtual string Name => GetType().Name;

        /// <summary>
        /// The id that this ModContent will be given; a combination of the Mod's prefix and the name
        /// </summary>
        public string Id => mod.IDPrefix + Name;

        
        /// <summary>
        /// The BloonsMod that this content was added by
        /// </summary>
        public BloonsMod mod;

        internal static readonly Dictionary<Type, List<ModContent>> Instances = new Dictionary<Type, List<ModContent>>();

        /// <summary>
        /// Used for when you want to programmatically create multiple instances of a given ModContent
        /// </summary>
        /// <returns></returns>
        public virtual IEnumerable<ModContent> Load()
        {
            yield return this;
        }

#if BloonsTD6
        internal static void LoadAllModContent(BloonsMod mod)
        {
            try
            {
                ResourceHandler.LoadEmbeddedTextures(mod);
                ResourceHandler.LoadEmbeddedBundles(mod);
            }
            catch (Exception e)
            {
                MelonLogger.Error("Critical failure when loading resources for mod " + mod.Info.Name);
                MelonLogger.Error(e);
            }    
                            
            var modDisplays = GetModContent<ModDisplay>(mod);
            var modUpgrades = GetModContent<ModUpgrade>(mod);
            var modTowers = GetModContent<ModTower>(mod);
            var modTowerSets = GetModContent<ModTowerSet>(mod);
                            
            try
            {
                ModDisplayHandler.LoadModDisplays(modDisplays);
            }
            catch (Exception e)
            {
                MelonLogger.Error("Critical failure when loading Displays for mod " + mod.Info.Name);
                MelonLogger.Error(e);
            }
                            
            try
            {
                ModUpgradeHandler.LoadUpgrades(modUpgrades);
            }
            catch (Exception e)
            {
                MelonLogger.Error("Critical failure when loading Upgrades for mod " + mod.Info.Name);
                MelonLogger.Error(e);
            }
            
            try
            {
                ModTowerHandler.LoadTowers(modTowers);
            }
            catch (Exception e)
            {
                MelonLogger.Error("Critical failure when loading Towers for mod " + mod.Info.Name);
                MelonLogger.Error(e);
            }
            
            try
            {
                ModTowerSetHandler.LoadTowerSets(modTowerSets);
            }
            catch (Exception e)
            {
                MelonLogger.Error("Critical failure when loading Tower Sets for mod " + mod.Info.Name);
                MelonLogger.Error(e);
            }
            
        }
#endif
        
        internal static List<T> GetModContent<T>(BloonsMod mod) where T : ModContent
        {
            return mod.Assembly.GetTypes()
                .Where(type => !type.IsAbstract && type.IsSubclassOf(typeof(T)))
                .SelectMany(type => Create<T>(type, mod))
                .Where(content => content != null)
                .Select(content => (T) content).ToList();
        }

        internal static List<ModContent> Create<T>(Type type, BloonsMod mod) where T : ModContent
        {
            if (!typeof(T).IsAssignableFrom(type))
            {
                throw new ArgumentException("Wrong type to create");
            }

            try
            {
                if (!Instances.ContainsKey(type))
                {
                    ModContent instance;
                    try
                    {
                        instance = (ModContent) Activator.CreateInstance(type);
                    }
                    catch (Exception)
                    {
                        MelonLogger.Error($"Error creating default {type.Name}");
                        MelonLogger.Error("A zero argument constructor is REQUIRED for all ModContent classes");
                        throw;
                    }
                    var instances = instance.Load().ToList();
                    foreach (var modContent in instances)
                    {
                        modContent.mod = mod;
                    }

                    Instances[type] = instances;
                }

                return Instances[type];
            }
            catch (Exception e)
            {
                MelonLogger.Error("Failed to instantiate " + type.Name);
                MelonLogger.Error(e);
                MelonLogger.Error("Did you mess with the constructor?");
                return new List<ModContent>();
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
        /// Gets a texture's GUID by name for a specific mod
        /// </summary>
        /// <param name="mod">The BloonsMod that the texture is from</param>
        /// <param name="fileName">The file name of your texture, without the extension</param>
        /// <returns>The texture's GUID</returns>
        public static string GetTextureGUID(BloonsMod mod, string fileName)
        {
            return mod == null ? default : mod.IDPrefix + fileName;
        }
        
        /// <summary>
        /// Gets a texture's GUID by name for a specific mod
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
            var id = GetInstance<T>().Id;
            if (top + mid + bot > 0)
            {
                id += $"-{top}{mid}{bot}";
            }

            return id;
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
        /// Gets all loaded ModContent objects that are T or a subclass of T
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public static List<T> GetInstances<T>() where T : ModContent
         {
             return Instances.Where(pair => typeof(T).IsAssignableFrom(pair.Key))
                 .SelectMany(pair => pair.Value)
                 .Cast<T>()
                 .ToList();
        }
        
#endif

        /// <summary>
        /// Gets the singleton instance of a particular ModContent or BloonsMod based on its type
        /// </summary>
        /// <typeparam name="T">The type to get the instance of</typeparam>
        /// <returns>The official instance of it</returns>
        public static T GetInstance<T>()
        {
            if (typeof(T).IsSubclassOf(typeof(ModContent)) && Instances.ContainsKey(typeof(T)))
            {
                return (T) (object) Instances[typeof(T)][0];
            }

            if (typeof(T).IsSubclassOf(typeof(BloonsMod)))
            {
                return MelonHandler.Mods.OfType<T>().FirstOrDefault();
            }

            MelonLogger.Warning("Can't call GetInstance<T>() on type that is not ModContent or BloonsMod");

            return default;
        }

        /// <summary>
        /// Gets the official instance of a particular ModLoadable or BloonsMod based on its type
        /// </summary>
        /// <param name="type">The type to get the instance of</param>
        /// <returns>The official instance of it</returns>
        public static object GetInstance(Type type)
        {
            return !Instances.ContainsKey(type) ? default : Instances[type];
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

            MelonLogger.Error($"Couldn't find bundle with name \"{name}\"");
            var bundles = ResourceHandler.Bundles.Keys.Where(s => s.StartsWith(mod.IDPrefix)).ToList();
            if (bundles.Count == 0)
            {
                MelonLogger.Error($"In fact, {mod.GetModName()} doesn't have any bundles loaded. Did you forget to include them as an Embedded Resource?");
            }
            else
            {
                MelonLogger.Msg($"The bundles that we did find in {mod.GetModName()} have the names:");
                foreach (var s in bundles)
                {
                    MelonLogger.Error($"    {s.Replace(mod.IDPrefix, "")}");
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
    }
}