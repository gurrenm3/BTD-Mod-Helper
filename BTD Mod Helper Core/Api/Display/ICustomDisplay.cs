namespace BTD_Mod_Helper.Api.Display
{
    internal interface ICustomDisplay
    { 
        string AssetBundleName { get; }
        string PrefabName { get; }
        string MaterialName { get; }
    }
}