using MelonLoader;

namespace BTD_Mod_Helper.Api
{
    /// <summary>
    /// 
    /// </summary>
    public abstract class ModMap : ModContent
    {
        /// <inheritdoc />
        protected sealed override void Register()
        {
            MelonLogger.Msg($"Registered ModMap {Name}");
        }
    }
}
