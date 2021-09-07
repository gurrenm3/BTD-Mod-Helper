using Assets.Scripts.Unity.Display;
using BTD_Mod_Helper.Api.Towers;

namespace BTD_Mod_Helper.Api.Display
{
    public abstract class ModTowerCustomDisplay : ModTowerDisplay, ICustomDisplay
    {
        public abstract string AssetBundleName { get; }
        public abstract string PrefabName { get; }
        public abstract string MaterialName { get; }

        public override string BaseDisplay => null;

        public override void ModifyDisplayNode(UnityDisplayNode node)
        {
            
        }
    }

    public abstract class ModTowerCustomDisplay<T> : ModTowerCustomDisplay where T : ModTower
    {
        /// <inheritdoc />
        public override ModTower Tower => GetInstance<T>();
    }
}