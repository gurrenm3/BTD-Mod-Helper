using Assets.Scripts.Models.Display;

namespace BTD_Mod_Helper.Api.Display
{
    public abstract partial class ModDisplay
    {
        /// <summary>
        /// Gets a new DisplayModel based on this ModDisplay
        /// </summary>
        /// <returns></returns>
        public DisplayModel GetDisplayModel(DisplayNodeCategory displayNode)
        {
            var display = new DisplayModel($"DisplayModel_{Name}", Id, displayNode, 0, 0, null, "", default, default);
            return display;
        }
    }
}
