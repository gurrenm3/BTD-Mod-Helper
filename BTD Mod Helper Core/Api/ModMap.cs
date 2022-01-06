using Assets.Scripts.Unity;
using BTD_Mod_Helper.Extensions;
using MelonLoader;

namespace BTD_Mod_Helper.Api
{
    /// <summary>
    /// 
    /// </summary>
    public abstract class ModMap : ModContent
    {
        public ModMap()
        {
            //var mapModel = new MapModel("", null, null, null, null, null, null, 3, null, null, 4); // testing if it's possible to create map model
            
        }

        /// <summary>
        /// <inheritdoc/>
        /// </summary>
        public sealed override void Register()
        {
            MelonLogger.Msg($"Registered ModMap {Name}");
        }
    }
}