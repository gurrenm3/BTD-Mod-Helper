using MelonLoader;

namespace BTD_Mod_Helper
{
    public abstract class BloonsMod : MelonMod
    {
        /// <summary>
        /// Github API URL used to check if this mod is up to date.
        ///
        ///     For example: "https://api.github.com/repos/gurrenm3/BTD-Mod-Helper/releases"
        /// </summary>
        public virtual string GithubReleaseURL => "";
        
        
        /// <summary>
        /// As an alternative to a GithubReleaseURL, a direct link to a web-hosted version of the .cs file that
        /// has the "MelonInfo" attribute with the version of your mod
        ///
        ///     
        ///     For example: "https://raw.githubusercontent.com/doombubbles/BTD6-Mods/main/MegaKnowledge/Main.cs"
        ///
        ///     because the file contains
        ///     [assembly: MelonInfo(typeof(MegaKnowledge.Main), "Mega Knowledge", "1.0.1", "doombubbles")]
        /// </summary>
        public virtual string MelonInfoCsURL => "";
        
        
        /// <summary>
        /// Link that people should be prompted to go to when this mod is out of date.
        ///
        ///     For example: "https://github.com/gurrenm3/BTD-Mod-Helper/releases/latest"
        /// </summary>
        public virtual string LatestURL => "";
    }
}