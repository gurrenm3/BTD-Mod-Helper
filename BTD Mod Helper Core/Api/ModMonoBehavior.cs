using MelonLoader;
using System;
using System.Linq;
using UnhollowerRuntimeLib;
using UnityEngine;

namespace BTD_Mod_Helper.Api
{
    public class ModMonoBehavior : MonoBehaviour
    {
        public ModMonoBehavior(IntPtr ptr) : base(ptr) { }

        internal static void LoadAllModMonoBehaviors()
        {
            foreach (var mod in MelonHandler.Mods)
            {
                var types = mod?.Assembly?.GetTypes()?.Where(type => type.IsSubclassOf(typeof(ModMonoBehavior)));
                if (types != null && !types.Any())
                    continue;

                foreach (var customBehavior in types)
                {
                    ClassInjector.RegisterTypeInIl2Cpp(customBehavior);
                }
            }
        }
    }
}
