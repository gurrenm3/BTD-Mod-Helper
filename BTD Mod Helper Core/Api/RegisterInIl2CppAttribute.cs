using MelonLoader;
using System;
using System.Collections.Generic;
using System.Reflection;
using UnhollowerRuntimeLib;

namespace BTD_Mod_Helper.Api
{
    /// <summary>
    /// Attribute that can be used to automatically register custom MonoBehaviors in the game.
    /// <br/>Inspired by the implementation made by the Among Us modding community and the Reactor devs.
    /// </summary>
    public class RegisterInIl2CppAttribute : Attribute
    {
        /// <summary>
        /// List of already registered types. Used to prevent re-registering classes.
        /// </summary>
        private static HashSet<Type> registeredTypes = new HashSet<Type>();

        /// <summary>
        /// Iterates over all loaded mods and finds every class that uses this attribute.
        /// </summary>
        /// <returns>List of all types that use this attribute.</returns>
        internal static HashSet<Type> FindTypesToRegister()
        {
            HashSet<Type> typesToRegister = new HashSet<Type>();

            foreach (var mod in MelonHandler.Mods)
            {
                var types = mod.Assembly.GetValidTypes();
                foreach (var type in types)
                {
                    var attribute = type.GetCustomAttribute<RegisterInIl2CppAttribute>();
                    if (attribute != null)
                        typesToRegister.Add(type);
                }
            }

            return typesToRegister;
        }

        /// <summary>
        /// Iterates over a collection of types and registers them with the ClassInjector. 
        /// Ignores any class that has already been registered.
        /// </summary>
        /// <param name="typesToRegister">Collection of classes to register.</param>
        internal static void RegisterAllTypes(HashSet<Type> typesToRegister)
        {
            foreach (var itemToRegister in typesToRegister)
            {
                if (registeredTypes.Contains(itemToRegister))
                    continue;

                ClassInjector.RegisterTypeInIl2Cpp(itemToRegister);
                
                registeredTypes.Add(itemToRegister);
            }
        }
    }
}
