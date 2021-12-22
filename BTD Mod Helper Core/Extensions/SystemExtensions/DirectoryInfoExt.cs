using System;
using System.IO;

namespace BTD_Mod_Helper.Extensions
{
    public static class DirectoryInfoExt
    {
        /// <summary>
        /// (Cross-Game compatible) Returns all Files in this directory that reference MelonLoader.dll or MelonLoader.ModHandler.dll
        /// </summary>
        /// <param name="directoryInfo"></param>
        /// <returns></returns>
        public static FileInfo[] GetAllMelonMods(this DirectoryInfo directoryInfo)
        {
            var files = directoryInfo.GetFiles();
            if (!files.Any())
                return null;

            return Array.FindAll(files, file => file.IsMelonMod());
        }
    }
}
