#if UNITY_EDITOR
using UnityEditor;
using System.IO;

public class CreateAssetBundles
{
    [MenuItem("Assets/Build AssetBundles")]
    static void BuildAllAssetBundles()
    {
        string assetBundleDirectory = "Assets/AssetBundles";
        Directory.Delete(assetBundleDirectory, true);
        Directory.CreateDirectory(assetBundleDirectory);
        BuildPipeline.BuildAssetBundles(assetBundleDirectory,
                                        BuildAssetBundleOptions.None,
                                        BuildTarget.StandaloneWindows);

        File.Copy(assetBundleDirectory + "/modoptions.bundle", "../BloonsTD6 Mod Helper/Resources/modoptions.bundle", true);
    }
}
#endif