namespace BTD_Mod_Helper.Api.Display
{
    internal interface ICustomDisplay
    { 
        /// <summary>
        /// The name of the asset bundle file that the model is in, not including the .bundle extension
        /// </summary>
        string AssetBundleName { get; }
        
                
        /// <summary>
        /// The name of the prefab that the model has within the Asset Bundle
        /// </summary>
        string PrefabName { get; }
        
        
        /// <summary>
        /// The name of the material that should be applied to the tower from the asset bundle
        /// </summary>
        string MaterialName { get; }
    }
}