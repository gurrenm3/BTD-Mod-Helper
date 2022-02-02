
﻿using MelonLoader;
using System;
using System.Collections.Generic;
using System.IO;

namespace BTD_Mod_Helper.Extensions
{
    public static class BloonsModExt
    {
        /// <summary>
        /// (Cross-Game compatible) Get the name of this mod from it's dll name
        /// </summary>
        /// <param name="bloonsMod"></param>
        /// <returns></returns>
        public static string GetModName(this BloonsMod bloonsMod)
        {
            return bloonsMod?.Assembly?.GetName()?.Name;
        }

        /// <summary>
        /// (Cross-Game compatible) Get the personal mod directory for this specific mod. Useful for keeping this mod's files seperate from other mods. Example: "BloonsTD6/Mods/BloonsTD6 Mod Helper/settings.txt"
        /// </summary>
        /// <param name="bloonsMod"></param>
        /// <returns></returns>
        public static string GetModDirectory(this BloonsMod bloonsMod)
        {
            return MelonHandler.ModsDirectory+"\\"+bloonsMod.GetModName();
        }

        /// <summary>
        /// (Cross-Game compatible) Get the personal mod directory for this specific mod. Useful for keeping this mod's files seperate from other mods. Example: "BloonsTD6/Mods/BloonsTD6 Mod Helper/settings.txt"
        /// </summary>
        /// <param name="bloonsMod"></param>
        /// <param name="createIfNotExists">Create the mod's directory if it doesn't exist yet?</param>
        /// <returns></returns>
        public static string GetModDirectory(this BloonsMod bloonsMod, bool createIfNotExists = true)
        {
            string path = $"{MelonHandler.ModsDirectory}\\{bloonsMod.GetModName()}";
            if (createIfNotExists) Directory.CreateDirectory(path);
            return path;
        }

        /// <summary>
        /// (Cross-Game compatible) Get's the directory where this mod's settings are or will be stored. Example: "BloonsTD6/Mods/BloonsTD6 Mod Helper/settings.txt"
        /// </summary>
        /// <param name="bloonsMod"></param>
        /// <returns></returns>
        public static string GetModSettingsDir(this BloonsMod bloonsMod)
        {
            return Path.Combine(bloonsMod.GetModDirectory(), "Mod Settings");
        }

        /// <summary>
        /// (Cross-Game compatible) Get's the directory where this mod's settings are or will be stored. Example: "BloonsTD6/Mods/BloonsTD6 Mod Helper/settings.txt"
        /// </summary>
        /// <param name="bloonsMod"></param>
        /// <param name="createIfNotExists">Create the mod's directory if it doesn't exist yet?</param>
        /// <returns></returns>
        public static string GetModSettingsDir(this BloonsMod bloonsMod, bool createIfNotExists = true)
        {
            var path = bloonsMod.GetModSettingsDir();
            if (createIfNotExists) Directory.CreateDirectory(path);
            return path;
        }
    }
}
