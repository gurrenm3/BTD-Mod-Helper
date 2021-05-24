using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using Assets.Scripts.Models;
using Assets.Scripts.Unity;
#if BloonsTD6
using Assets.Scripts.Models.Towers.Upgrades;
using BTD_Mod_Helper.Api.Towers;
#elif BloonsAT

#endif
using Assets.Scripts.Utils;
using BTD_Mod_Helper.Extensions;
using MelonLoader;

namespace BTD_Mod_Helper.Api
{
    /// <summary>
    /// ModContent serves two major purposes:
    ///     1. It is a base class for things that needs to be loaded via reflection from mods and given Ids,
    ///     such as ModTower and ModUpgrade
    ///
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
        
        internal static readonly Dictionary<Type, ModContent> Instances = new Dictionary<Type, ModContent>();

        /// <summary>
        /// Gets a sprite reference by name for a specific mod
        /// </summary>
        /// <param name="name">The file name of your texture, without the extension</param>
        /// <typeparam name="T">Your mod's main BloonsMod extending class</typeparam>
        /// <returns>A new SpriteReference</returns>
        public static SpriteReference GetSpriteReference<T>(string name) where T : BloonsMod
        {
            return Game.instance?.CreateSpriteReference(GetTextureGUID<T>(name));
            // return new SpriteReference(GetTextureGUID<T>(name)); // previous method. Changed to support BATTD
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
            return !ResourceHandler.resources.ContainsKey(guid) ? null : Game.instance.CreateSpriteReference(guid);
        }

        /// <summary>
        /// Gets a texture's GUID by name for a specific mod
        /// </summary>
        /// <param name="name">The file name of your texture, without the extension</param>
        /// <typeparam name="T">Your mod's main BloonsMod extending class</typeparam>
        /// <returns>The texture's GUID</returns>
        public static string GetTextureGUID<T>(string name) where T : BloonsMod
        {
            return GetInstance<T>().IDPrefix + name;
        }

        /// <summary>
        /// Gets a texture's GUID by name for a specific mod
        /// </summary>
        /// <param name="mod">The BloonsMod that the texture is from</param>
        /// <param name="name">The file name of your texture, without the extension</param>
        /// <returns>The texture's GUID</returns>
        public static string GetTextureGUID(BloonsMod mod, string name)
        {
            return mod == null ? default : mod.IDPrefix + name;
        }

#if BloonsTD6
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
        /// Gets the internal upgrade name/id for a ModUpgrade
        /// </summary>
        /// <typeparam name="T">The ModUpgrade type</typeparam>
        /// <returns>The upgrade name/id</returns>
        public static string UpgradeID<T>() where T : ModUpgrade
        {
            return GetInstance<T>().Id;
        }

#endif
        
        /// <summary>
        /// Gets the official instance of a particular ModLoadable or BloonsMod based on its type
        /// </summary>
        /// <typeparam name="T">The type to get the instance of</typeparam>
        /// <returns>The official instance of it</returns>
        public static T GetInstance<T>()
        {
            if (typeof(T).IsSubclassOf(typeof(ModContent)) && Instances.ContainsKey(typeof(T)))
            {
                return (T) (object) Instances[typeof(T)];
            }

            if (typeof(T).IsSubclassOf(typeof(BloonsMod)))
            {
                return MelonHandler.Mods.OfType<T>().FirstOrDefault();
            }

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
    }
}