using Assets.Scripts.Unity.Display;

namespace BTD_Mod_Helper.Api.Display
{
    public abstract class ModCustomDisplay : ModDisplay, ICustomDisplay
    {
        public abstract string AssetBundleName { get; }
        public abstract string PrefabName { get; }
        public abstract string MaterialName { get; }

        public override string BaseDisplay => null;

        public override void ModifyDisplayNode(UnityDisplayNode node)
        {
            
        }

    }
}