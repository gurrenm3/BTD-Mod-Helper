using HarmonyLib;
using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;
using UnhollowerRuntimeLib;

namespace BTD_Mod_Helper.Api
{
    /// <summary>
    /// (Cross-Game compatible) Utility attribute that registers a MonoBehavior as an Il2Cpp type. Allows for custom MonoBehaviors that work in the game.
    /// </summary>
    /// <remarks>Essentially it just automatically calls <see cref="ClassInjector.RegisterTypeInIl2Cpp{T}()"/> Thanks to the Reactor devs from the AmongUs Modding community for making the base implementation of this.</remarks>
    [AttributeUsage(AttributeTargets.Class)]
    public class RegisterInIl2CppAttribute : Attribute
    {
        public Type[] Interfaces { get; }

        public RegisterInIl2CppAttribute()
        {
            Interfaces = Type.EmptyTypes;
        }

        public RegisterInIl2CppAttribute(params Type[] interfaces)
        {
            Interfaces = interfaces;
        }

        [Obsolete("You don't need to call this anymore", true)]
        public static void Register()
        {
        }

        private static void Register(Type type, Type[] interfaces)
        {
            var baseTypeAttribute = type.BaseType?.GetCustomAttribute<RegisterInIl2CppAttribute>();
            if (baseTypeAttribute != null)
            {
                Register(type.BaseType, baseTypeAttribute.Interfaces);
            }
            

            try
            {
                ClassInjector.RegisterTypeInIl2Cpp(type);
            }
            catch (Exception e)
            {
                //Logger<ReactorPlugin>.Warning($"Failed to register {type.FullDescription()}: {e}");
            }
        }

        public static void Register(Assembly assembly)
        {
            foreach (var type in assembly.GetTypes())
            {
                var attribute = type.GetCustomAttribute<RegisterInIl2CppAttribute>();
                if (attribute != null)
                {
                    Register(type, attribute.Interfaces);
                }
            }
        }

        internal static void Initialize()
        {
            //ChainloaderHooks.PluginLoad += plugin => Register(plugin.GetType().Assembly);
        }
    }
}
