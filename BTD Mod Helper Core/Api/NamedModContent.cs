using System.Text.RegularExpressions;

namespace BTD_Mod_Helper.Api
{
    /// <summary>
    /// ModContent with DisplayName and Description that registers values in the LocalizationManger's textTable
    /// </summary>
    public abstract class NamedModContent : ModContent
    {
        /// <summary>
        /// The name that will be actually displayed for this in game
        /// </summary>
        public virtual string DisplayName => Regex.Replace(Name, "(\\B[A-Z])", " $1");

        /// <summary>
        /// The name that will actually be display when referring to multiple of these
        /// </summary>
        public virtual string DisplayNamePlural => DisplayName + "s";

        /// <summary>
        /// The in game description of this
        /// </summary>
        public virtual string Description => $"Default description for {Name}";


        /// <summary>
        /// Registers the text for this in the LocalizationManager
        /// </summary>
        /// <param name="textTable"></param>
        public virtual void RegisterText(Il2CppSystem.Collections.Generic.Dictionary<string, string> textTable)
        {
            textTable[Id] = DisplayName;
            textTable[Id + "s"] = DisplayNamePlural;
            textTable[Id + " Description"] = Description;
        }
    }
}